//author: futz
//helpers:
//last_checked: futz@04.12.2015

using System;

namespace TranslatoServiceLibrary.DEBUG
{
    internal class Log
    {
        private static System.IO.StringWriter writer = new System.IO.StringWriter();

        public static void Add(string line)
        {
            writer.WriteLineAsync(line);
        }

        public static void OutputDebugLogToConsole()
        {
            Console.WriteLine(writer.ToString());
        }
    }
}
