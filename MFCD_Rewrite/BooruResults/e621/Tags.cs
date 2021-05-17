using System.Collections.Generic;

namespace MFCD.BooruResults.e621
{
    public class Tags
    {
        public List<string> General     { get; } = new();
        public List<string> Species     { get; } = new();
        public List<string> Character   { get; } = new();
        public List<string> Copyright   { get; } = new();
        public List<string> Artist      { get; } = new();
        public List<string> Invalid     { get; } = new();
        public List<string> Lore        { get; } = new();
        public List<string> Meta        { get; } = new();
    }
}