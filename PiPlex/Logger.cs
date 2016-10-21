using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using PiPlex.Properties;

namespace PiPlex
{
    public class Logger
    {
        private static void Log(string mode, string context, string logMessage)
        {
            string logFilePath = Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData) + "\\" + Settings.Default.LogFile;
            using (StreamWriter w = File.AppendText(logFilePath))
            {
                string outpout = "[" + DateTime.Now.ToString() + "] [" + mode + "] [" + context + "] [" + logMessage + "]";

                //Loging to debug console
                Debug.WriteLine(outpout);

                //Loging to file
                w.WriteLine(outpout);
            }
        }

        public static void Info(string context, string logMessage)
        {
            Log("INFO", context, logMessage);
        }
        public static void Warning(string context, string logMessage)
        {
            Log("WARNING", context, logMessage);
        }
        public static void Error(string context, string logMessage)
        {
            Log("ERROR", context, logMessage);
        }
    }
}
