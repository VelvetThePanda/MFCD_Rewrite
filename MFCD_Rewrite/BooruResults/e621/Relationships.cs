using System.Collections.Generic;

namespace MFCD.BooruResults.e621{ 

    public class Relationships
    {
        public int? ParentId            { get; set; }
        public bool HasChildren         { get; set; }
        public bool HasActiveChildren   { get; set; }
        public List<int> Children       { get; set; }
    }
}