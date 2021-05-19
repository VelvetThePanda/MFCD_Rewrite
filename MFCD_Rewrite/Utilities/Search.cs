using System.Collections.Generic;
using SharpYaml.Serialization;

namespace MFCD.Utilities
{
    public class Search
    {
        [YamlMember("search")]
        public List<SearchType> Searches { get; set; }
    }

    public class SearchType
    {
        [YamlMember("tags")]
        public List<string> Tags { get; set;  }

        [YamlMember("pages")]
        int? Pages { get; set; }

        [YamlMember("folder")]
        public string? Folder { get; set; }
    }
}