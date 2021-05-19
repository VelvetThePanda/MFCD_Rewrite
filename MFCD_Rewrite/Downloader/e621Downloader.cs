using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.Http;
using System.Text;
using MFCD.BooruResults.e621;
using ShellProgressBar;

namespace MFCD.Downloader
{
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "e621.net")]
    public class e621Downloader
    {
        private readonly HttpClient _client = new();
        private readonly ChildProgressBar _bar;
        private readonly int _pages;
        public e621Downloader(string username, string apiKey, int pages, ProgressBar bar) // For the best experience, this is required. //
        {
            _bar = bar.Spawn(pages, "fetching content from e621.net..", new() {ProgressBarOnBottom = true, CollapseWhenFinished = true, ProgressCharacter = '─'});
            _pages = pages;
            byte[] cred = Encoding.GetEncoding("ISO-8859-1").GetBytes($"{username}:{apiKey}");
            _client.DefaultRequestHeaders.Add("Authorization", $"Basic {Convert.ToBase64String(cred)}");
            _client.DefaultRequestHeaders.UserAgent.ParseAdd("MFCD by VelvetThePanda / v0.1a");
        }
        
        /// <summary>
        /// Gets a list of json responses for deserialization. <paramref name="take"/> should not be adjusted if <paramref name="skip"/> is defined.
        /// </summary>
        /// <param name="tags">The tags to query e621.net with.</param>
        /// <param name="take">How many pages to take.</param>
        /// <param name="skip">How many pages to skip. Defaults to 0.</param>
        /// <returns>A list of JSON responses to be deserialized into <see cref="List{Stream}"/> of <see cref="Post"/>.</returns>
        public async IAsyncEnumerable<Stream> GetContent(string tags)
        {
            var baseUrl = "https://e621.net/posts.json?";
            
            for (int i = 1; i < _pages + 1; i++)
            {
                Stream contentStream = await _client.GetStreamAsync($"{baseUrl}page={i}&tags={tags.Replace(' ', '+')}");
                _bar.Tick($"Fetching page {i} of {_pages} from e621.net..");
                yield return contentStream;
            }
        }
    }
}