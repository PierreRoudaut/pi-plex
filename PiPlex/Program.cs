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
                    //Directdownload
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new FormMain());
                    break;
                default:
                    //CLI stuff
                    var options = new CliArguments();
                    if (CommandLine.Parser.Default.ParseArguments(args, options))
                    {
                        Console.ReadKey();
                        Application.Run(new CliAppContext());
                    }
                    else
                    {
                        
                    }
                    break;
            }
        }
    }
}
