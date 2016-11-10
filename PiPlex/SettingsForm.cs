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
    using PiPlex.Properties;

    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }


        public static bool ValidateSettings()
        {
            if (!Directory.Exists(Properties.Settings.Default.PlexMovieFolderPath))
                throw new IOException("Please specify a valid Plex Movie directory in the settings and restart PiPlex");
            if (!Directory.Exists(Properties.Settings.Default.PlexTvShowFolderPath))
                throw new IOException("Please specify a valid Plex TvShow directory in the settings and restart PiPlex");
            if (!Directory.Exists(Properties.Settings.Default.DonwloadFolderPath))
                throw new IOException("Please specify a valid download directory to bind in the settings and restart PiPlex");
            if (!File.Exists(Properties.Settings.Default.PlexMediaScannerPath))
                throw new IOException("Please specify a valid .exe path for Plex Media Scanner in the settings and restart Piplex");
            if (!File.Exists(Properties.Settings.Default.PlexMediaServerPath))
                throw new IOException("Please specify a valid .exe path for Plex Media Server in the settings and restart PiPlex");
            if (!File.Exists(Properties.Settings.Default.FileBotPath))
                throw new IOException("Please specify a valid .exe path for Filebot in the settings and restart PiPlex");

            return true;
        }

        //TODO: refactor for agnostic properties iteration
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.openFileDialog.Multiselect = false;
            this.openFileDialog.Filter = "Executable Files (.exe)|*.exe";

            this.plexMovieFolderTextBox.Text = Settings.Default.PlexMovieFolderPath;
            this.plexTvShowFolderTextBox.Text = Settings.Default.PlexTvShowFolderPath;
            this.downloadFolderTextBox.Text = Settings.Default.DonwloadFolderPath;
            this.plexMediaScannerTextBox.Text = Settings.Default.PlexMediaScannerPath;
            this.plexMediaServerTextBox.Text = Settings.Default.PlexMediaServerPath;
            this.filebotPathTextBox.Text = Settings.Default.FileBotPath;
        }
    
        //TODO: refactor only one click handler
        private void downloadFolderButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = Settings.Default.DonwloadFolderPath;
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                // UI
                this.downloadFolderTextBox.Text = folderBrowserDialog.SelectedPath;

                // Saved in settings
                Settings.Default.DonwloadFolderPath = folderBrowserDialog.SelectedPath;
                Settings.Default.Save();
            }
        }
        private void plexTvShowFolderButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = Settings.Default.PlexTvShowFolderPath;
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                // UI
                this.plexTvShowFolderTextBox.Text = folderBrowserDialog.SelectedPath;

                // Saved in settings
                Settings.Default.PlexTvShowFolderPath = folderBrowserDialog.SelectedPath;
                Settings.Default.Save();
            }
        }
        private void plexMediaScannerButton_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Path.GetDirectoryName(Settings.Default.PlexMediaScannerPath);
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                // UI
                this.plexMediaScannerTextBox.Text = openFileDialog.FileName;

                // Saved in settings
                Settings.Default.PlexMediaScannerPath = openFileDialog.FileName;
                Settings.Default.Save();
            }
        }
        private void plexMovieFolderButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = Settings.Default.PlexMovieFolderPath;
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                // UI
                this.plexMovieFolderTextBox.Text = folderBrowserDialog.SelectedPath;

                // Saved in settings
                Settings.Default.PlexMovieFolderPath = folderBrowserDialog.SelectedPath;
                Settings.Default.Save();
            }
        }
        private void plexMediaServerButton_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Path.GetDirectoryName(Settings.Default.PlexMediaServerPath);
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                // UI
                this.plexMediaServerTextBox.Text = openFileDialog.FileName;

                // Saved in settings
                Settings.Default.PlexMediaServerPath = openFileDialog.FileName;
                Settings.Default.Save();
            }
        }
        private void filebotButton_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Path.GetDirectoryName(Settings.Default.FileBotPath);
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                // UI
                this.filebotPathTextBox.Text = openFileDialog.FileName;

                // Saved in settings
                Settings.Default.FileBotPath = openFileDialog.FileName;
                Settings.Default.Save();
            }
        }
    }
}
