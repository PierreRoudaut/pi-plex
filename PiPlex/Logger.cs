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
    class Logger
    {
        private static void Log(string mode, string context, string logMessage)
        {
            using (StreamWriter w = File.AppendText(Settings.Default.LogFile))
            {
                string outpout = "["+DateTime.Now.ToLongDateString()+"] ["+mode+"] ["+context+"] ["+logMessage+"]";
                
                //Loging to debug console
                #if DEBUG
                Debug.WriteLine(outpout);
                #endif

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
