using System;
using System.Diagnostics;

namespace PiPlex
{
    public class PlexMediaServer
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
