using System;
using System.Threading;

namespace MFCD.Utilities
{
    public static class ErrorHelper
    {
        public static void MissingSearchFile() => ShowError("You're missing search.yaml in the same folder as this application!");

        public static void MissingUsername() => ShowError("You seem to be missing your \"username\" property in your search.yaml file\nCheck https://github.com/VelvetThePanda/MFCD_Rewrite for the accepted format and try again.");

        public static void MissingApiKey() => ShowError("You're missing the \"key\" property in your search.yaml file.\nCheck https://github.com/VelvetThePanda/MFCD_Rewrite for the accepted format and try again.");
        
        private static void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.WriteLine("Press any key to exit." );
            Console.ReadKey(true);
            Environment.Exit(-1);  
        }
    }
}