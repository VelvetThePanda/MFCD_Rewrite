using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dasync.Collections;
using MFCD.Downloader;
using MFCD.Utilities;
using SharpYaml;
using SharpYaml.Serialization;
using ShellProgressBar;

if (!File.Exists("./search.yaml"))
    ErrorHelper.MissingSearchFile();

try
{
    var search = new Serializer().Deserialize<Search>(File.ReadAllText("./search.yaml"));
}
catch (YamlException)
{
    Console.WriteLine("There was an issue parsing your configuration file! Please see the example on GitHub and try again.");
    Thread.Sleep(4000);
    Environment.Exit(-1);
}

Console.ReadKey();