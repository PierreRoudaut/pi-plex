using System;

namespace PiPlex
{
    public class SettingsHelper
    {
        public static bool SettingsAreSet
        {
            get
            {
                return !String.IsNullOrEmpty(Properties.Settings.Default.FileBotPath)
                       && !String.IsNullOrEmpty(Properties.Settings.Default.PlexMediaScannerPath)
                       && !String.IsNullOrEmpty(Properties.Settings.Default.PlexMediaServerPath)
                       && !String.IsNullOrEmpty(Properties.Settings.Default.DonwloadFolderPath)
                       && !String.IsNullOrEmpty(Properties.Settings.Default.PlexMovieFolderPath)
                       && !String.IsNullOrEmpty(Properties.Settings.Default.PlexTvShowFolderPath);
            }
        }

        public static bool SettingsAreBlank
        {
            get
            {
                return String.IsNullOrEmpty(Properties.Settings.Default.FileBotPath)
                       && String.IsNullOrEmpty(Properties.Settings.Default.PlexMediaScannerPath)
                       && String.IsNullOrEmpty(Properties.Settings.Default.PlexMediaServerPath)
                       && String.IsNullOrEmpty(Properties.Settings.Default.DonwloadFolderPath)
                       && String.IsNullOrEmpty(Properties.Settings.Default.PlexMovieFolderPath)
                       && String.IsNullOrEmpty(Properties.Settings.Default.PlexTvShowFolderPath);
            }
            
        }
    }
}
