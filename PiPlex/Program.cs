using System;
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
            var options = new CliArguments();

            switch (args.Length)
            {
                case 1:
                    //Direct download
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new FormMain());
                    break;
                case 3:
                    //CLI stuff
                    if (Parser.Default.ParseArguments(args, options))
                    {
                        Application.Run(new CliAppContext(options));
                    }
                    break;
                default:
                    Debug.Write(options.GetUsage());
                    Console.Write(options.GetUsage());
                    Environment.Exit(1);
                    break;
            }
        }
    }
}
