using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PiPlex
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void tableLayoutP0anel_Paint(object sender, PaintEventArgs e)
        {

        }

        public static bool ValidateSettings()
        {
            if (!Directory.Exists(Properties.Settings.Default.PlexMovieFolderPath))
                throw new IOException(Properties.Settings.Default.PlexMovieFolderPath + " is not a valid folder");
            if (!Directory.Exists(Properties.Settings.Default.PlexTvShowFolderPath))
                throw new IOException(Properties.Settings.Default.PlexTvShowFolderPath + " is not a valid folder");
            if (!Directory.Exists(Properties.Settings.Default.DonwloadFolderPath))
                throw new IOException(Properties.Settings.Default.DonwloadFolderPath + " is not a valid folder");
            if (!File.Exists(Properties.Settings.Default.PlexMediaScannerPath))
                throw new IOException(Properties.Settings.Default.PlexMediaScannerPath + " does not exist");
            return true;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            this.textBoxPlexMovieFolders.Text = Properties.Settings.Default.PlexMovieFolderPath;
            this.textBoxTvShowFolder.Text = Properties.Settings.Default.PlexTvShowFolderPath;
            this.textBoxDownloadFolder.Text = Properties.Settings.Default.DonwloadFolderPath;
            this.textBoxPlexMediaManagerUrl.Text = Properties.Settings.Default.PlexMediaManagerUrl;
            this.textBoxPlexMediaScanner.Text = Properties.Settings.Default.PlexMediaScannerPath;
        }

        // PLEX MOVIE FOLDER PATH
        private void buttonMovieFolders_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = Properties.Settings.Default.PlexMovieFolderPath;
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                // UI
                this.textBoxPlexMovieFolders.Text = folderBrowserDialog.SelectedPath;

                // Saved in settings
                Properties.Settings.Default.PlexMovieFolderPath = folderBrowserDialog.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }

        private void buttonTvShowsFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = Properties.Settings.Default.PlexTvShowFolderPath;
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                // UI
                this.textBoxTvShowFolder.Text = folderBrowserDialog.SelectedPath;

                // Saved in settings
                Properties.Settings.Default.PlexTvShowFolderPath = folderBrowserDialog.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }

        private void buttonDownloadsFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = Properties.Settings.Default.DonwloadFolderPath;
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                // UI
                this.textBoxDownloadFolder.Text = folderBrowserDialog.SelectedPath;

                // Saved in settings
                Properties.Settings.Default.DonwloadFolderPath = folderBrowserDialog.SelectedPath;
                Properties.Settings.Default.Save();
            }

        }

        private void buttonPlexMediaScanner_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = Properties.Settings.Default.PlexMediaScannerPath;
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                // UI
                this.buttonPlexMediaScanner.Text = folderBrowserDialog.SelectedPath;

                // Saved in settings
                Properties.Settings.Default.PlexMediaScannerPath = folderBrowserDialog.SelectedPath;
                Properties.Settings.Default.Save();
            }

        }

        private void buttonPlexMediaManagerUrl_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = Properties.Settings.Default.PlexMediaManagerUrl;
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                // UI
                this.textBoxPlexMediaManagerUrl.Text = folderBrowserDialog.SelectedPath;

                // Saved in settings
                Properties.Settings.Default.PlexMediaManagerUrl = folderBrowserDialog.SelectedPath;
                Properties.Settings.Default.Save();
            }


        }
    }
}
