namespace PiPlex
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Windows.Forms;

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
            var sourcePath = Path.Combine(Settings.Default.DonwloadFolderPath, inputFolder);
            var destPath = Path.Combine(Settings.Default.PlexTvShowFolderPath, inputFolder);
            if (Directory.Exists(destPath))
            {
                Directory.Delete(destPath, true);
            }
            //todo: check sourcePath exist before moving
            Directory.Move(sourcePath, destPath);
            return destPath;
        }

        /// <summary>
        /// Imports the specified input folder.
        /// </summary>
        /// <param name="inputFolder">The input folder.</param>
        private void Import(string inputFolder)
        {
            var destPath = this.MoveTargetFolder(inputFolder);
            Debug.WriteLine(destPath);
            FileBot.GetSubtitles(destPath);
            PlexMediaScanner.Update();
        }

        public CliAppContext(CliArguments options)
        {
            this.Import(options.InputFolder);
            Environment.Exit(0);
        }
    }
}
