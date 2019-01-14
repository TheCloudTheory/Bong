using System;
using System.IO;

namespace Bong.Common
{
    public class InternalLogger
    {
        public static void Log(string message)
        {
            var logsDirectory = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "Data", "Logs"));
            if (logsDirectory.Exists == false)
            {
                logsDirectory.Create();
            }

            var formattedMessage = $"[{DateTime.Now}] {message}\r\n";
            File.AppendAllText(
                Path.Combine(Directory.GetCurrentDirectory(), "Data", "Logs",
                    DateTime.Now.ToString("yyyyMMdd") + ".txt"), formattedMessage);
        }
    }
}