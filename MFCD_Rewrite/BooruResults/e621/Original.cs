using System.Collections.Generic;

namespace MFCD.BooruResults.e621{ 

    public class Original
    {
        public string Type { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public List<string> Urls { get; } = new();
    }

}