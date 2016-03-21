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
    public partial class FormMain : Form, LoggerInterface
    {
        static string[] SUPPORTED_EXTENSIONS = {".avi", ".mp4", ".mkv" };
        const string PROMPT = ">> ";

        public void Log(string message)
        {
            this.textBoxLog.Text += PROMPT + message + Environment.NewLine;
            this.textBoxLog.ScrollToCaret();
        }

        public FormMain()
        {
            InitializeComponent();
            worker = new BackgroundWorker();
        }

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
                throw new Exception("Folder does not exist:" + e.Message);
            }
            watcher.NotifyFilter = 
                NotifyFilters.LastAccess | 
                NotifyFilters.LastWrite | 
                NotifyFilters.FileName | 
                NotifyFilters.DirectoryName;
            watcher.Changed += new FileSystemEventHandler(OnNewFileDownloaded);
            watcher.EnableRaisingEvents = true;
        }

        private void HandleVideoFileType(string path)
        {
            Trace.WriteLine("trace test");
            Log("Calculating video file duration...");
            long duration = DurationProvier.GetDurationAsNanoSeconds(path);
            TimeSpan timeSpan = TimeSpan.FromSeconds(duration / DurationProvier.NANO_SECONDS);

            //DETERMINING VIDEO DURATION
            string foundDurationMessage = timeSpan.Hours + ":" + timeSpan.Minutes + ":" + timeSpan.Seconds;

            //DETERMINING VIDEO TYPE
            DurationProvier.VideoType videoType = DurationProvier.GetVideoTypeFromDuration(duration);
            Log("Duration: " + foundDurationMessage + "   Type: " + videoType.ToString());


            string destPath = null;
            switch (videoType)
            {
                case DurationProvier.VideoType.UNDEFINED:
                case DurationProvier.VideoType.MOVIE:
                    destPath = Settings.Default.PlexMovieFolderPath + Path.GetFileName(path);
                    break;
                case DurationProvier.VideoType.TV_SHOW:
                    destPath = Settings.Default.PlexTvShowFolderPath + Path.GetFileName(path);
                    break;
            }


            //MOVING FILE TO DEST FOLDER
            Log("Moving file to:  " + destPath);
            try
            {
                if (File.Exists(destPath))
                {
                    File.Delete(destPath);
                }
                File.Move(path, destPath);
                notifyIcon.ShowBalloonTip(1000, "New " + videoType.ToString() + " updated to Plex", Path.GetFileName(destPath), ToolTipIcon.Info);
            }
            catch (Exception exception)
            {
                Log("ERROR [unable to move file]: " + exception.Message);
            }            
        }

        private void OnNewFileDownloaded(object source, FileSystemEventArgs e)
        {
            try
            {
                SettingsForm.ValidateSettings();
                Log("Settings are ok");
            }
            catch (Exception exception)
            {
                Log(exception.Message);
            }
            this.pictureBox.Image = Resources.spin;
            //If file extension is correct
            if (!SUPPORTED_EXTENSIONS.Contains(Path.GetExtension(e.FullPath)))
            {
                Log("Ignoring file [" + e.Name + "]");
                this.pictureBox.Image = Resources.plex;
                return;
            }
            else
            {
                Log("Detecting file [" + e.Name + "]");
            }

            //MOVE FILE TO PROPER PLEX FOLDER
            HandleVideoFileType(e.FullPath);

            //RUN PLEX MEDIA SERVER
            PlexMediaServer.Run();

            //UPDATE PLEX LIBRAIRY
            PlexMediaScanner.Update();

            this.pictureBox.Image = Resources.plex;
            //DONE

        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            string downloadFolderPath = Settings.Default.DonwloadFolderPath;
            InitFileSystemWatcher(downloadFolderPath);
            this.pictureBox.Image = Resources.plex;
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SettingsForm f = new SettingsForm();
            f.Show();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}
