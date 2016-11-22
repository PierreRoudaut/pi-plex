using System;
using System.Linq;

using PiPlex.Properties;

namespace PiPlex
{
    using System.Collections.Generic;
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
        /// Push recursively all the files from a given root directory
        /// </summary>
        /// <param name="path">The path of the iteration</param>
        /// <param name="files">The reference to the list of files</param>
        private static void RecAddFilesFromPath(string path, IList<string> files)
        {
            try
            {
                Directory.GetFiles(path)
                    .ToList()
                    .ForEach(s => files.Add(s));

                Directory.GetDirectories(path)
                    .ToList()
                    .ForEach(s => RecAddFilesFromPath(s, files));
            }
            catch (UnauthorizedAccessException)
            {
                //ignoring unauthorized
            }
        }
        

        /// <summary>
        /// Locates an installed application in Program Files and Program Files(X86)
        /// </summary>
        /// <param name="applicationExecutable">The application executable.</param>
        /// <returns></returns>
        private static string LocateInstalledApplication(string applicationExecutable)
        {
            var files = new List<String>();

            //search in Program Files
            var programFiles = Environment.GetEnvironmentVariable("ProgramW6432");
            if (programFiles != null)
            {
                RecAddFilesFromPath(programFiles, files);
                var applicationPath = files.FirstOrDefault(f => f.EndsWith(applicationExecutable));
                if (applicationPath != null)
                {
                    return applicationPath;
                }
            }
            files.Clear();

            //search in Program Files x86
            var programFilesX86 = Environment.GetEnvironmentVariable("ProgramFiles(x86)");
            if (programFilesX86 != null)
            {
                RecAddFilesFromPath(programFilesX86, files);
                var applicationPath = files.FirstOrDefault(f => f.EndsWith(applicationExecutable));
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
