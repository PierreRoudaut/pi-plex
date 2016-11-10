using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiPlex.Properties;

namespace PiPlex
{
    using System.IO;

    /// <summary>
    /// Guesses default PiPlex settings
    /// </summary>
    public class DefaultSettingsProvider
    {
        /// <summary>
        /// Gets the download folder.
        /// </summary>
        /// <value>
        /// The download folder.
        /// </value>
        public static string DownloadFolder
        {
            get
            {
                return KnownFolders.GetPath(KnownFolder.Downloads);
            }
        }

        /// <summary>
        /// Gets the plex movie folder.
        /// </summary>
        /// <value>
        /// The plex movie folder.
        /// </value>
        public static string PlexMovieFolder
        {
            get
            {
                var plexMovieFolder = KnownFolders.GetPath(KnownFolder.Videos) + @"\MOVIES";
                return Directory.Exists(plexMovieFolder) ? plexMovieFolder : null;
            }            
        }

        /// <summary>
        /// Gets the plex tv show folder.
        /// </summary>
        /// <value>
        /// The plex tv show folder.
        /// </value>
        public static string PlexTvShowFolder
        {
            get
            {
                var plexTvShowFolder = KnownFolders.GetPath(KnownFolder.Videos) + @"\TV SHOWS";
                return Directory.Exists(plexTvShowFolder) ? plexTvShowFolder : null;
            }
        }

        /// <summary>
        /// Gets the plex media scanner path.
        /// </summary>
        /// <value>
        /// The plex media scanner path.
        /// </value>
        public static string PlexMediaScannerPath
        {
            get
            {
                return LocateInstalledApplication("Plex Media Scanner.exe");
            }     
        }

        /// <summary>
        /// Gets the plex media server path.
        /// </summary>
        /// <value>
        /// The plex media server path.
        /// </value>
        public static string PlexMediaServerPath
        {
            get
            {
                return LocateInstalledApplication("Plex Media Server.exe");
            }
        }

        /// <summary>
        /// Gets the file bot path.
        /// </summary>
        /// <value>
        /// The file bot path.
        /// </value>
        public static string FileBotPath
        {
            get
            {
                return LocateInstalledApplication("filebot.exe");
            }
        }

        /// <summary>
        /// Locates an installed application in Program Files and Program Files(X86)
        /// </summary>
        /// <param name="applicationExecutable">The application executable.</param>
        /// <returns></returns>
        private static string LocateInstalledApplication(string applicationExecutable)
        {
            //search in Program Files
            var programFiles = Environment.GetEnvironmentVariable("ProgramW6432");
            if (programFiles != null)
            {
                var applicationPath = Directory.GetFiles(programFiles, applicationExecutable, SearchOption.AllDirectories).FirstOrDefault();
                if (applicationPath != null)
                {
                    return applicationPath;
                }
            }

            //search in Program Files x86
            var programFilesX86 = Environment.GetEnvironmentVariable("ProgramFiles(x86)");
            if (programFilesX86 != null)
            {
                var applicationPath = Directory.GetFiles(programFilesX86, applicationExecutable, SearchOption.AllDirectories).FirstOrDefault();
                if (applicationPath != null)
                {
                    return applicationPath;
                }
            }
            return null;
        }

        /// <summary>
        /// Provides the default settings.
        /// </summary>
        public static void ProvideDefaultSettings()
        {
            Settings.Default.DonwloadFolderPath = DownloadFolder;
            Settings.Default.PlexMovieFolderPath = PlexMovieFolder;
            Settings.Default.PlexTvShowFolderPath = PlexTvShowFolder;
            Settings.Default.PlexMediaServerPath = PlexMediaServerPath;
            Settings.Default.PlexMediaScannerPath = PlexMediaScannerPath;
            Settings.Default.FileBotPath = FileBotPath;
            Settings.Default.Save();
        }
    }
}
