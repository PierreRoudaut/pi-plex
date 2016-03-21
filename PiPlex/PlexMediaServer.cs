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
        public static void Run()
        {
            Process.Start(Properties.Settings.Default.PlexMediaServerPath);
        }
    }
}
