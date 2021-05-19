using System;
using System.Threading;

namespace MFCD.Utilities
{
    public static class ErrorHelper
    {
        public static void MissingSearchFile() => ShowError("You're missing search.yaml in the same folder as this application!");

        private static void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Thread.Sleep(4000);
            Environment.Exit(-1);  
        }
    }
}