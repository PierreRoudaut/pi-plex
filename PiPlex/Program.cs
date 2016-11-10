using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using CommandLine;

namespace PiPlex
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            string[] args = Environment.GetCommandLineArgs();

            switch (args.Length)
            {
                case 1:
                    //Direct download
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new FormMain());
                    break;
                default:
                    //CLI stuff
                    var options = new CliArguments();
                    if (Parser.Default.ParseArguments(args, options))
                    {
                        Application.Run(new CliAppContext(options));
                    }
                    else
                    {
                        
                    }
                    break;
            }
        }
    }
}
