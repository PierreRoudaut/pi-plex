namespace PiPlex
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Windows.Forms;
    using Microsoft.VisualBasic.FileIO;
    using PiPlex.Properties;

    /// <summary>
    /// The cli app context.
    /// </summary>
    public class CliAppContext : ApplicationContext
    {
        /// <summary>
        /// Moves the downloaded folder to the apropriate
        /// </summary>
        /// <param name="inputFolder">The input folder.</param>
        /// <returns>The destination path of the imported folder</returns>
        private string MoveTargetFolder(string inputFolder)
        {
            var destPath = Path.Combine(Settings.Default.PlexTvShowFolderPath, Path.GetFileName(inputFolder));
            if (Directory.Exists(destPath))
            {
                Logger.Warning("CliAppContext:MoveTargetFolder", "Removing existing: " + destPath);
                Directory.Delete(destPath, true);
            }
            FileSystem.CopyDirectory(inputFolder, destPath);
            Logger.Info("CliAppContext:MoveTargetFolder", "Folder moved to: " + destPath);
            return destPath;
        }

        /// <summary>
        /// Imports the specified input folder.
        /// </summary>
        /// <param name="inputFolder">The input folder.</param>
        private void Import(string inputFolder)
        {
            File.WriteAllLines(@"C:\Users\proud\Desktop\args.txt", new[] { inputFolder });
            var destPath = this.MoveTargetFolder(inputFolder);
            Debug.WriteLine(destPath);
            FileBot.GetSubtitles(destPath);
            PlexMediaScanner.Update();
        }

        public CliAppContext(CliArguments options)
        {
            Debug.WriteLine(System.Environment.SpecialFolder.LocalApplicationData);
            this.Import(options.InputFolder);
            Environment.Exit(0);
        }
    }
}
