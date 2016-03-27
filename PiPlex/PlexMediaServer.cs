using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiPlex
{
    class PlexMediaServer
    {
        public static bool Run()
        {
            try
            {
                Process.Start(Properties.Settings.Default.PlexMediaServerPath);
                Logger.Info("PlexMediaServer:Run", "Run OK");
                return true;
            }
            catch (Exception exception)
            {
                Logger.Error("PlexMediaServer:Run", "Run KO: " + exception.Message);
            }
            return false;
        }
    }
}
