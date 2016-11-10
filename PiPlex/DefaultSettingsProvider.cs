using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiPlex
{
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
                return KnownFolders.GetPath(KnownFolder.Videos) + @"\MOVIES";
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
                return KnownFolders.GetPath(KnownFolder.Videos) + @"\TV SHOWS";
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
                return "";
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
                return "";
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
                return "";
            }
        }

        private static string GetProgramPath(string program)
        {
            var files = System.IO.Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), program, System.IO.SearchOption.AllDirectories);
            return files.Any() ? files.First() : null;
        }
    }
}
