
#region imports

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace XLog {
    public class Logger {
        public string logFilePath { get; set; } = string.Empty;
        private static string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        private static void FileWriter(string logFilePath, LogType logType, string logText) {
            if (logFilePath == string.Empty) {
                Directory.CreateDirectory("logs");
                logFilePath = "logs/log";
            }

            var logDirectory = Path.GetDirectoryName(logFilePath);
            if (!string.IsNullOrEmpty(logDirectory) && !Directory.Exists(logDirectory)) {
                Directory.CreateDirectory(logDirectory);
            }

            if (logFilePath != string.Empty) {
                using (StreamWriter streamWriter = new StreamWriter($"{logFilePath}.xlog", true)) {
                    streamWriter.WriteLine("{0} - {1} - {2}", currentTime, logType.ToString(), logText);
                }
            }
            else return;
        }
        public void Log(LogType logType, string logText) {
            FileWriter(logFilePath, logType, logText);

            ConsoleColor color = ColorsAssociations(logType);
            Console.ForegroundColor = color;
            Console.WriteLine("{0} - {1} - {2}", currentTime, logType.ToString(), logText);
            Console.ResetColor();
        }
        private static ConsoleColor ColorsAssociations(LogType logType) {
            var color = ConsoleColor.White;

            switch(logType) {
                case LogType.DEBUG:
                    color = ConsoleColor.White;
                    break;
                case LogType.INFO:
                    color = ConsoleColor.Blue;
                    break;
                case LogType.WARNING:
                    color = ConsoleColor.DarkYellow;
                    break;
                case LogType.ERROR:
                    color = ConsoleColor.Red;
                    break;
            }
            return color;
        }
    }
}
