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
        public static void Update()
        {
            Process.Start(Properties.Settings.Default.PlexMediaScannerPath + " -r -a -s");
        }
    }
}
