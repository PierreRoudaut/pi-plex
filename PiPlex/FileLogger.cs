using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiPlex.Properties;

namespace PiPlex
{
    class FileLogger : LoggerInterface
    {
        public void Log(string message)
        {
            //TODO: try IO exception
            using (StreamWriter w = File.AppendText(Settings.Default.LogFile))
            {
                Log(message, w);
            }
        }

        public static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            w.WriteLine("  :");
            w.WriteLine("  :{0}", logMessage);
            w.WriteLine("-------------------------------");
        }
    }
}
