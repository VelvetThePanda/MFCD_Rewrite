using System.Collections.Generic;
using System.IO;
using SharpYaml.Serialization;

namespace MFCD.Utilities
{
    public class SearchConfig
    {
        [YamlMember("search")]
        public List<Search> Searches { get; set; }
        
        [YamlMember("key")]
        public string ApiKey { get; set; }
        
        [YamlMember("username")]
        public string Username { get; set; }
    }

    public class Search
    {
        [YamlMember("tags")]
        public List<string> Tags { get; set;  }

        [YamlMember("pages")]
        public int? Pages { get; set; }

        [YamlMember("folder")]
        public string? Folder { get; set; }

        [YamlIgnore]
        public List<Stream> Streams { get; set; } = new();
    }
}