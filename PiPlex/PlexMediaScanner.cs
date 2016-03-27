using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiPlex
{
    class PlexMediaScanner
    {
        public static bool Update()
        {
            try
            {
                Process process = new Process();
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.FileName = Properties.Settings.Default.PlexMediaScannerPath;

                //Scan
                process.StartInfo.Arguments = "-s";
                process.Start();

                Logger.Info("PlexMediaScanner:Update", "Updated OK");
                return true;
            }
            catch (Exception exception)
            {
                Logger.Error("PlexMediaScanner:Update", "Updated KO: " + exception.Message);
            }
            return false;
        }
    }
}
