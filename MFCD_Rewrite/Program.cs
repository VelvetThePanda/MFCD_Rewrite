using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Dasync.Collections;
using MFCD.BooruResults.e621;
using MFCD.Downloader;
using MFCD.Utilities;
using Newtonsoft.Json;
using SharpYaml;
using SharpYaml.Serialization;
using ShellProgressBar;
using File = System.IO.File;

if (!File.Exists("./search.yaml"))
    ErrorHelper.MissingSearchFile();


try
{
    var client = new HttpClient();
    var searchConfig = new Serializer().Deserialize<SearchConfig>(File.ReadAllText("./search.yaml"));

    if (searchConfig.Username is null)
        ErrorHelper.MissingUsername();
    if (searchConfig.ApiKey is null)
        ErrorHelper.MissingApiKey();

    var opts = new ProgressBarOptions() {ProgressBarOnBottom = true, CollapseWhenFinished = true, ProgressCharacter = '─'};
    using var bar = new ProgressBar(3, "Fetching content from e621.net", opts);

    foreach (Search search in searchConfig.Searches)
    {
        var e6 = new e621Downloader(searchConfig.Username, searchConfig.ApiKey, search.Pages ?? 1, bar);
        
        await foreach (Stream s in e6.GetContent(string.Join('+', search.Tags)))
            search.Streams.Add(s);
    }
    
    bar.Tick("Downloading");
    
    foreach (Search search in searchConfig.Searches)
    {
        await search.Streams.ParallelForEachAsync(async str =>
        {
            using var sr = new StreamReader(str);
            string json = await sr.ReadToEndAsync();
            var result = JsonConvert.DeserializeObject<E621Result>(json);
            string path = search.Folder is null ? $"./{string.Join(' ', search.Tags)}/" : $"./{search.Folder}/";
            Directory.CreateDirectory(path);

            bar.MaxTicks += result!.Posts.Length;

            foreach (Post post in result.Posts!)
            {
                var filename = $"{post.File.Md5}.{post.File.Ext}";
                using ChildProgressBar cbar = bar.Spawn(1, $"Downloading {filename}", opts);

                if (File.Exists(path + filename))
                {
                    cbar.Tick("File exists; skipping");
                    bar.Tick();
                    Thread.Sleep(10);
                    continue;
                }

                Stream imageContent = await client.GetStreamAsync(post.File.Url);
                await using var writer = new FileStream(path + filename, FileMode.Create);
                await imageContent.CopyToAsync(writer);
                cbar.Tick("Wrote to disk");
                bar.Tick();
            }
        }, 12);
    }

    bar.MaxTicks = 0;
    Console.Clear();
    Console.WriteLine("Done! Consider donating? https://ko-fi.com/VelvetThePanda\nPress any key to exit.");
    Console.ReadKey();
}
catch (YamlException)
{
    Console.WriteLine("There was an issue parsing your configuration file! Please see the example on GitHub and try again.");
    Thread.Sleep(4000);
    Environment.Exit(-1);
}