namespace PiPlex
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxFolders = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.labelPlexMoviesFolder = new System.Windows.Forms.Label();
            this.textBoxPlexMovieFolders = new System.Windows.Forms.TextBox();
            this.buttonMovieFolders = new System.Windows.Forms.Button();
            this.textBoxTvShowFolder = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonTvShowsFolder = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxDownloadFolder = new System.Windows.Forms.TextBox();
            this.buttonDownloadsFolder = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonPlexMediaScanner = new System.Windows.Forms.Button();
            this.textBoxPlexMediaScanner = new System.Windows.Forms.TextBox();
            this.buttonPlexMediaManagerUrl = new System.Windows.Forms.Button();
            this.textBoxPlexMediaManagerUrl = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBoxFolders.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88.51351F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.48649F));
            this.tableLayoutPanel1.Controls.Add(this.groupBoxFolders, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.04986F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.95014F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(843, 361);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBoxFolders
            // 
            this.groupBoxFolders.Controls.Add(this.tableLayoutPanel2);
            this.groupBoxFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxFolders.Location = new System.Drawing.Point(3, 3);
            this.groupBoxFolders.Name = "groupBoxFolders";
            this.groupBoxFolders.Size = new System.Drawing.Size(740, 217);
            this.groupBoxFolders.TabIndex = 0;
            this.groupBoxFolders.TabStop = false;
            this.groupBoxFolders.Text = "Folders";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.73319F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.26681F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.labelPlexMoviesFolder, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBoxPlexMovieFolders, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonMovieFolders, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBoxTvShowFolder, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonTvShowsFolder, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.textBoxDownloadFolder, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.buttonDownloadsFolder, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.buttonPlexMediaScanner, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.textBoxPlexMediaScanner, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.buttonPlexMediaManagerUrl, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.textBoxPlexMediaManagerUrl, 1, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(734, 196);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(4, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(279, 35);
            this.label4.TabIndex = 7;
            this.label4.Text = "Plex Media Manager URL";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPlexMoviesFolder
            // 
            this.labelPlexMoviesFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPlexMoviesFolder.Location = new System.Drawing.Point(4, 1);
            this.labelPlexMoviesFolder.Name = "labelPlexMoviesFolder";
            this.labelPlexMoviesFolder.Size = new System.Drawing.Size(279, 36);
            this.labelPlexMoviesFolder.TabIndex = 0;
            this.labelPlexMoviesFolder.Text = "Plex movies folder";
            this.labelPlexMoviesFolder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxPlexMovieFolders
            // 
            this.textBoxPlexMovieFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPlexMovieFolders.Location = new System.Drawing.Point(290, 4);
            this.textBoxPlexMovieFolders.Name = "textBoxPlexMovieFolders";
            this.textBoxPlexMovieFolders.ReadOnly = true;
            this.textBoxPlexMovieFolders.Size = new System.Drawing.Size(375, 22);
            this.textBoxPlexMovieFolders.TabIndex = 1;
            // 
            // buttonMovieFolders
            // 
            this.buttonMovieFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMovieFolders.Location = new System.Drawing.Point(672, 4);
            this.buttonMovieFolders.Name = "buttonMovieFolders";
            this.buttonMovieFolders.Size = new System.Drawing.Size(58, 30);
            this.buttonMovieFolders.TabIndex = 2;
            this.buttonMovieFolders.Text = "...";
            this.buttonMovieFolders.UseVisualStyleBackColor = true;
            this.buttonMovieFolders.Click += new System.EventHandler(this.buttonMovieFolders_Click);
            // 
            // textBoxTvShowFolder
            // 
            this.textBoxTvShowFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTvShowFolder.Location = new System.Drawing.Point(290, 41);
            this.textBoxTvShowFolder.Name = "textBoxTvShowFolder";
            this.textBoxTvShowFolder.ReadOnly = true;
            this.textBoxTvShowFolder.Size = new System.Drawing.Size(375, 22);
            this.textBoxTvShowFolder.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(4, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(279, 42);
            this.label5.TabIndex = 10;
            this.label5.Text = "Plex TV show folder";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonTvShowsFolder
            // 
            this.buttonTvShowsFolder.Location = new System.Drawing.Point(672, 41);
            this.buttonTvShowsFolder.Name = "buttonTvShowsFolder";
            this.buttonTvShowsFolder.Size = new System.Drawing.Size(50, 23);
            this.buttonTvShowsFolder.TabIndex = 11;
            this.buttonTvShowsFolder.Text = "...";
            this.buttonTvShowsFolder.UseVisualStyleBackColor = true;
            this.buttonTvShowsFolder.Click += new System.EventHandler(this.buttonTvShowsFolder_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(279, 44);
            this.label6.TabIndex = 12;
            this.label6.Text = "Download folder";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxDownloadFolder
            // 
            this.textBoxDownloadFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDownloadFolder.Location = new System.Drawing.Point(290, 84);
            this.textBoxDownloadFolder.Name = "textBoxDownloadFolder";
            this.textBoxDownloadFolder.ReadOnly = true;
            this.textBoxDownloadFolder.Size = new System.Drawing.Size(375, 22);
            this.textBoxDownloadFolder.TabIndex = 13;
            // 
            // buttonDownloadsFolder
            // 
            this.buttonDownloadsFolder.Location = new System.Drawing.Point(672, 84);
            this.buttonDownloadsFolder.Name = "buttonDownloadsFolder";
            this.buttonDownloadsFolder.Size = new System.Drawing.Size(50, 23);
            this.buttonDownloadsFolder.TabIndex = 14;
            this.buttonDownloadsFolder.Text = "...";
            this.buttonDownloadsFolder.UseVisualStyleBackColor = true;
            this.buttonDownloadsFolder.Click += new System.EventHandler(this.buttonDownloadsFolder_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(4, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(279, 33);
            this.label7.TabIndex = 15;
            this.label7.Text = "Plex Media Scanner";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonPlexMediaScanner
            // 
            this.buttonPlexMediaScanner.Location = new System.Drawing.Point(672, 129);
            this.buttonPlexMediaScanner.Name = "buttonPlexMediaScanner";
            this.buttonPlexMediaScanner.Size = new System.Drawing.Size(50, 23);
            this.buttonPlexMediaScanner.TabIndex = 16;
            this.buttonPlexMediaScanner.Text = "...";
            this.buttonPlexMediaScanner.UseVisualStyleBackColor = true;
            this.buttonPlexMediaScanner.Click += new System.EventHandler(this.buttonPlexMediaScanner_Click);
            // 
            // textBoxPlexMediaScanner
            // 
            this.textBoxPlexMediaScanner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPlexMediaScanner.Location = new System.Drawing.Point(290, 129);
            this.textBoxPlexMediaScanner.Name = "textBoxPlexMediaScanner";
            this.textBoxPlexMediaScanner.ReadOnly = true;
            this.textBoxPlexMediaScanner.Size = new System.Drawing.Size(375, 22);
            this.textBoxPlexMediaScanner.TabIndex = 17;
            // 
            // buttonPlexMediaManagerUrl
            // 
            this.buttonPlexMediaManagerUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPlexMediaManagerUrl.Location = new System.Drawing.Point(672, 163);
            this.buttonPlexMediaManagerUrl.Name = "buttonPlexMediaManagerUrl";
            this.buttonPlexMediaManagerUrl.Size = new System.Drawing.Size(58, 29);
            this.buttonPlexMediaManagerUrl.TabIndex = 18;
            this.buttonPlexMediaManagerUrl.Text = "...";
            this.buttonPlexMediaManagerUrl.UseVisualStyleBackColor = true;
            this.buttonPlexMediaManagerUrl.Click += new System.EventHandler(this.buttonPlexMediaManagerUrl_Click);
            // 
            // textBoxPlexMediaManagerUrl
            // 
            this.textBoxPlexMediaManagerUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPlexMediaManagerUrl.Location = new System.Drawing.Point(290, 163);
            this.textBoxPlexMediaManagerUrl.Name = "textBoxPlexMediaManagerUrl";
            this.textBoxPlexMediaManagerUrl.ReadOnly = true;
            this.textBoxPlexMediaManagerUrl.Size = new System.Drawing.Size(375, 22);
            this.textBoxPlexMediaManagerUrl.TabIndex = 19;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 361);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBoxFolders.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBoxFolders;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label labelPlexMoviesFolder;
        private System.Windows.Forms.Button buttonMovieFolders;
        public System.Windows.Forms.TextBox textBoxPlexMovieFolders;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxTvShowFolder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonTvShowsFolder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxDownloadFolder;
        private System.Windows.Forms.Button buttonDownloadsFolder;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonPlexMediaScanner;
        private System.Windows.Forms.TextBox textBoxPlexMediaScanner;
        private System.Windows.Forms.Button buttonPlexMediaManagerUrl;
        private System.Windows.Forms.TextBox textBoxPlexMediaManagerUrl;
    }
}