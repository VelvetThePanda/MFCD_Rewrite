using System;
using System.Collections.Generic;
using MFCD.Downloader;
using ShellProgressBar;

namespace MFCD.UI
{
    public static class Display
    {
        private static readonly ProgressBar _mainBar = new(0, "Fetching content", ConsoleColor.Blue);
        private static readonly Dictionary<object, ChildProgressBar> _progressBars = new();

        public static void AddProgressBar(object o, int max, string message) => _progressBars.Add(o, _mainBar.Spawn(max, message));

        public static void SetTicks(int ticks) => _mainBar.MaxTicks = ticks;
        
        public static void Update(object downloader)
        {
            ChildProgressBar cpb = _progressBars[downloader];
            cpb.Tick();
            
            if (cpb.CurrentTick >= cpb.MaxTicks) 
                _mainBar.Tick();
        }
    }
}