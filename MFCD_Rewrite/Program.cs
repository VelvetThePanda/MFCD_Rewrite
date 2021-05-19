using System;
using System.IO;
using System.Threading;
using MFCD.Utilities;
using SharpYaml;
using SharpYaml.Serialization;

if (!File.Exists("./search.yaml"))
    ErrorHelper.MissingSearchFile();



var serial = new Serializer();
var search = new Search();



try
{
    search = serial.Deserialize<Search>(File.ReadAllText("./search.yaml"));
}
catch (YamlException)
{
    Console.WriteLine("There was an issue parsing your configuration file! Please see the example on GitHub and try again.");
    Thread.Sleep(4000);
    Environment.Exit(-1);
}

Console.ReadKey();