using System;
using System.Windows.Forms;
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
                    Logger.Info("Program:Main", "Starting PiPlex Watcher");
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new FormMain());
                    break;
                case 3:
                    //CLI stuff
                    if (Parser.Default.ParseArguments(args, options))
                    {
                        Logger.Info("Program:Main", "Starting PiPlex CLI");
                        Application.Run(new CliAppContext(options));
                    }
                    break;
                default:
                    Console.Write(options.GetUsage());
                    Environment.Exit(1);
                    break;
            }
        }
    }
}
