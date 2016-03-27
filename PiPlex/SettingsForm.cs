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

        public static bool ValidateSettings()
        {
            if (!Directory.Exists(Properties.Settings.Default.PlexMovieFolderPath))
                throw new IOException("Please specify a valid Plex Movie directory in the settings and restart PiPlex");
            if (!Directory.Exists(Properties.Settings.Default.PlexTvShowFolderPath))
                throw new IOException("Please specify a valid Plex TvShow directory in the settings and restart PiPlex");
            if (!Directory.Exists(Properties.Settings.Default.DonwloadFolderPath))
                throw new IOException("Please specify a valid download directory to bind in the settings and restart PiPlex");
            if (!File.Exists(Properties.Settings.Default.PlexMediaScannerPath))
                throw new IOException("Please specify a valid path for Plex Media Scanner in the settings and restart Piplex");
            if (!File.Exists(Properties.Settings.Default.PlexMediaServerPath))
                throw new IOException("Please specify a valid path for Plex Media Server in the settings and restart Piplex");
            return true;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.openFileDialog.Multiselect = false;
            this.openFileDialog.Filter = "Executable Files (.exe)|*.exe";

            this.plexMovieFolderTextBox.Text = Properties.Settings.Default.PlexMovieFolderPath;
            this.plexTvShowFolderTextBox.Text = Properties.Settings.Default.PlexTvShowFolderPath;
            this.downloadFolderTextBox.Text = Properties.Settings.Default.DonwloadFolderPath;
            this.plexMediaScannerTextBox.Text = Properties.Settings.Default.PlexMediaScannerPath;
            this.plexMediaServerTextBox.Text = Properties.Settings.Default.PlexMediaServerPath;
        }

    
        private void downloadFolderButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = Properties.Settings.Default.DonwloadFolderPath;
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                // UI
                this.downloadFolderTextBox.Text = folderBrowserDialog.SelectedPath;

                // Saved in settings
                Properties.Settings.Default.DonwloadFolderPath = folderBrowserDialog.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }
        private void plexTvShowFolderButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = Properties.Settings.Default.PlexTvShowFolderPath;
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                // UI
                this.plexTvShowFolderTextBox.Text = folderBrowserDialog.SelectedPath;

                // Saved in settings
                Properties.Settings.Default.PlexTvShowFolderPath = folderBrowserDialog.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }
        private void plexMediaScannerButton_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Path.GetDirectoryName(Properties.Settings.Default.PlexMediaScannerPath);
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                // UI
                this.plexMediaScannerTextBox.Text = openFileDialog.FileName;

                // Saved in settings
                Properties.Settings.Default.PlexMediaScannerPath = openFileDialog.FileName;
                Properties.Settings.Default.Save();
            }
        }
        private void plexMovieFolderButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = Properties.Settings.Default.PlexMovieFolderPath;
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                // UI
                this.plexMovieFolderTextBox.Text = folderBrowserDialog.SelectedPath;

                // Saved in settings
                Properties.Settings.Default.PlexMovieFolderPath = folderBrowserDialog.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }
        private void plexMediaServerButton_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Path.GetDirectoryName(Properties.Settings.Default.PlexMediaServerPath);
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                // UI
                this.plexMediaServerTextBox.Text = openFileDialog.FileName;

                // Saved in settings
                Properties.Settings.Default.PlexMediaServerPath = openFileDialog.FileName;
                Properties.Settings.Default.Save();
            }
        }
    }
}
