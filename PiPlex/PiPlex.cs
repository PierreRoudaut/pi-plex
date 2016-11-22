using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using PiPlex.Properties;


namespace PiPlex
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            this.InitializeComponent();
            this.WindowState = FormWindowState.Minimized;
            this.notifyIcon.BalloonTipClicked += new EventHandler(notifyIcon_BalloonTipClicked);
        }

        /// <summary>
        /// Handles the BalloonTipClicked event of the notifyIcon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void notifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            Process.Start(Path.GetDirectoryName(this.notifyIcon.Tag.ToString()));
        }

        /// <summary>
        /// Initializes the file system watcher
        /// </summary>
        /// <param name="path">The path.</param>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        private void InitFileSystemWatcher(string path)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.SynchronizingObject = this;
            try
            {
                watcher.Path = path;
            }
            catch (Exception e)
            {
                Logger.Error("PiPlex:InitFileSystemWatcher", e.Message);
                notifyIcon.ShowBalloonTip(5 * 1000, "Error", "Folder does not exist", ToolTipIcon.Error);
                return;
            }
            watcher.NotifyFilter =
                NotifyFilters.LastAccess |
                NotifyFilters.LastWrite |
                NotifyFilters.FileName |
                NotifyFilters.DirectoryName;
            watcher.Changed += new FileSystemEventHandler(OnNewFileDownloaded);
            watcher.EnableRaisingEvents = true;
        }

        /// <summary>
        /// Handles the type of the video file.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        private string HandleVideoFileType(string path)
        {
            long duration = DurationProvier.GetDurationAsNanoSeconds(path);
            TimeSpan timeSpan = TimeSpan.FromSeconds(duration / DurationProvier.NANO_SECONDS);

            //DETERMINING VIDEO DURATION
            string foundDurationMessage = timeSpan.Hours + ":" + timeSpan.Minutes + ":" + timeSpan.Seconds;

            //DETERMINING VIDEO TYPE
            DurationProvier.VideoType videoType = DurationProvier.GetVideoTypeFromDuration(duration);
            Logger.Info("PiPlex:HandleVideoFileType", "Duration: " + foundDurationMessage + " - Type: " + videoType.ToString());

            string destPath = null;
            switch (videoType)
            {
                case DurationProvier.VideoType.UNDEFINED:
                case DurationProvier.VideoType.MOVIE:
                    destPath = Settings.Default.PlexMovieFolderPath + "\\" + Path.GetFileName(path);
                    break;
                case DurationProvier.VideoType.TV_SHOW:
                    destPath = Settings.Default.PlexTvShowFolderPath + "\\" + Path.GetFileName(path);
                    break;
            }


            //MOVING FILE TO DEST FOLDER
            Logger.Info("PiPlex:HandleVideoFileType", "Moving file to: " + destPath);
            try
            {
                if (File.Exists(destPath))
                {
                    File.Delete(destPath);
                }
                File.Move(path, destPath);
                Logger.Info("PiPlex:HandleVideoFileType", "File moved");
            }
            catch (Exception exception)
            {
                Logger.Error("PiPlex:HandleVideoFileType", "Unable to move file: " + exception.Message);
            }

            //Download subtitles with Filebot
            FileBot.GetSubtitles(destPath);
            return destPath;
        }

        /// <summary>
        /// Called when [new file downloaded].
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="e">The <see cref="FileSystemEventArgs"/> instance containing the event data.</param>
        private void OnNewFileDownloaded(object source, FileSystemEventArgs e)
        {
            //If file extension is correct
            if (!Properties.Settings.Default.SupportedFormats.Contains(Path.GetExtension(e.FullPath)))
            {
                Logger.Info("PiPlex:OnNewFileDownloaded", "Ignoring file " + e.Name);
                return;
            }
            else
            {
                Logger.Info("PiPlex:OnNewFileDownloaded", "Handling file " + e.Name);
            }

            // MOVE FILE TO PROPER PLEX FOLDER
            string newFilePath = HandleVideoFileType(e.FullPath);


            // UPDATE PLEX LIBRAIRY
            PlexMediaScanner.Update();

            // DONE
            notifyIcon.Tag = newFilePath;
            notifyIcon.ShowBalloonTip(5 * 1000, "PiPlex", newFilePath, ToolTipIcon.Info);
        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            //If PiPlex already instantiated
            if (Process.GetProcessesByName("PiPlex").Length == 2)
            {
                Application.Exit();
            }

            notifyIcon.ContextMenu = new ContextMenu();
# if DEBUG
            notifyIcon.ContextMenu.MenuItems.Add("Code Snippet", this.notifyIcon_CodeSnippet);
# endif
            notifyIcon.ContextMenu.MenuItems.Add("Settings", this.notifyIcon_OptionSettings);
            notifyIcon.ContextMenu.MenuItems.Add("Logs", this.notifyIcon_OptionLogs);
            notifyIcon.ContextMenu.MenuItems.Add("Quit", this.notifyIcon_OptionsQuit);

            Logger.Info("PiPlex:FormMain_Load", "Loading Piplex");
            try
            {
                if (SettingsHelper.SettingsAreBlank)
                {
                    DefaultSettingsProvider.ProvideDefaultSettings();
                }
                SettingsForm.AssertSettings();                
            }
            catch (Exception exception)
            {
                Logger.Error("PiPlex:FormMain_Load", "Invalid settings: " + exception.Message);
                notifyIcon.ShowBalloonTip(10 * 1000, "Check settings and restart PiPlex", exception.Message, ToolTipIcon.Warning);
                return;
            }
            //RUN PLEX MEDIA SERVER
            PlexMediaServer.Run();

            InitFileSystemWatcher(Settings.Default.DonwloadFolderPath);

        }

        /// <summary>
        /// Handles the CodeSnippet event of the notifyIcon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void notifyIcon_CodeSnippet(object sender, EventArgs e)
        {
            CodeSnippet.Run();
        }

        /// <summary>
        /// Handles the OptionsQuit event of the notifyIcon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void notifyIcon_OptionsQuit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Handles the OptionLogs event of the notifyIcon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void notifyIcon_OptionLogs(object sender, EventArgs e)
        {
            try
            {
                string logFilePath = Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData) + "\\" + Settings.Default.LogFile;
                Process.Start(logFilePath);
                Logger.Info("PiPlex:notifyIcon_OptionLogs", "Log file opened");
            }
            catch (Exception)
            {
                Logger.Error("PiPlex:notifyIcon_OptionLogs", "Log file does not exist");
                notifyIcon.ShowBalloonTip(10 * 1000, "Oops", "The log file has been removed or replace", ToolTipIcon.Warning);
            }
        }

        /// <summary>
        /// Handles the OptionSettings event of the notifyIcon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void notifyIcon_OptionSettings(object sender, EventArgs e)
        {
            SettingsForm f = new SettingsForm();
            f.Show();
        }

        /// <summary>
        /// Hide the Main form when loaded
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FormMain_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
