//author: futz
//helpers:
//last_checked: futz@08.12.2015

using System;

namespace TranslatoServiceLibrary.X
{
    internal static class Log
    {
        private static System.IO.StringWriter writer = new System.IO.StringWriter();

        internal static void Add(string line)
        {
            writer.WriteLineAsync(line);
        }

        internal static void OutputDebugLogToConsole()
        {
            Console.WriteLine(writer.ToString());
        }
    }
}
