namespace HuskyBrowser.HuskyBrowserManagement.TorrentsManagement
{
    partial class TorrentClientForm
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
            this.TorrentDownloadProgress = new System.Windows.Forms.ProgressBar();
            this.DataTorrentsPanel = new System.Windows.Forms.Panel();
            this.InfoTorrentPanel = new System.Windows.Forms.Panel();
            this.Percent = new System.Windows.Forms.Label();
            this.progrssText = new System.Windows.Forms.Label();
            this.StopButton = new MaterialSkin.Controls.MaterialButton();
            this.StartButton = new MaterialSkin.Controls.MaterialButton();
            this.Settings = new MaterialSkin.Controls.MaterialButton();
            this.DeleteTorrent = new MaterialSkin.Controls.MaterialButton();
            this.OpenTorrent = new MaterialSkin.Controls.MaterialButton();
            this.DownloadTorrent = new MaterialSkin.Controls.MaterialButton();
            this.InfoTorrentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TorrentDownloadProgress
            // 
            this.TorrentDownloadProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TorrentDownloadProgress.Location = new System.Drawing.Point(85, 6);
            this.TorrentDownloadProgress.Name = "TorrentDownloadProgress";
            this.TorrentDownloadProgress.Size = new System.Drawing.Size(612, 23);
            this.TorrentDownloadProgress.TabIndex = 0;
            // 
            // DataTorrentsPanel
            // 
            this.DataTorrentsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataTorrentsPanel.Location = new System.Drawing.Point(6, 132);
            this.DataTorrentsPanel.Name = "DataTorrentsPanel";
            this.DataTorrentsPanel.Size = new System.Drawing.Size(788, 321);
            this.DataTorrentsPanel.TabIndex = 1;
            // 
            // InfoTorrentPanel
            // 
            this.InfoTorrentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InfoTorrentPanel.Controls.Add(this.Percent);
            this.InfoTorrentPanel.Controls.Add(this.progrssText);
            this.InfoTorrentPanel.Controls.Add(this.TorrentDownloadProgress);
            this.InfoTorrentPanel.Location = new System.Drawing.Point(6, 459);
            this.InfoTorrentPanel.Name = "InfoTorrentPanel";
            this.InfoTorrentPanel.Size = new System.Drawing.Size(788, 219);
            this.InfoTorrentPanel.TabIndex = 2;
            // 
            // Percent
            // 
            this.Percent.AutoSize = true;
            this.Percent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Percent.Location = new System.Drawing.Point(703, 9);
            this.Percent.Name = "Percent";
            this.Percent.Size = new System.Drawing.Size(0, 20);
            this.Percent.TabIndex = 2;
            // 
            // progrssText
            // 
            this.progrssText.AutoSize = true;
            this.progrssText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.progrssText.ForeColor = System.Drawing.SystemColors.Control;
            this.progrssText.Location = new System.Drawing.Point(3, 6);
            this.progrssText.Name = "progrssText";
            this.progrssText.Size = new System.Drawing.Size(76, 20);
            this.progrssText.TabIndex = 1;
            this.progrssText.Text = "Progress:";
            // 
            // StopButton
            // 
            this.StopButton.AutoSize = false;
            this.StopButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.StopButton.BackColor = System.Drawing.SystemColors.Control;
            this.StopButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.StopButton.Depth = 0;
            this.StopButton.DrawShadows = false;
            this.StopButton.HighEmphasis = true;
            this.StopButton.Icon = global::HuskyBrowser.Properties.Resources.stop;
            this.StopButton.Location = new System.Drawing.Point(201, 87);
            this.StopButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.StopButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.StopButton.Name = "StopButton";
            this.StopButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.StopButton.Size = new System.Drawing.Size(41, 32);
            this.StopButton.TabIndex = 8;
            this.StopButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.StopButton.UseAccentColor = false;
            this.StopButton.UseVisualStyleBackColor = false;
            // 
            // StartButton
            // 
            this.StartButton.AutoSize = false;
            this.StartButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.StartButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.StartButton.Depth = 0;
            this.StartButton.HighEmphasis = true;
            this.StartButton.Icon = global::HuskyBrowser.Properties.Resources.play;
            this.StartButton.Location = new System.Drawing.Point(152, 87);
            this.StartButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.StartButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.StartButton.Name = "StartButton";
            this.StartButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.StartButton.Size = new System.Drawing.Size(41, 32);
            this.StartButton.TabIndex = 7;
            this.StartButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.StartButton.UseAccentColor = false;
            this.StartButton.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.Settings.AutoSize = false;
            this.Settings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Settings.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.Settings.Depth = 0;
            this.Settings.HighEmphasis = true;
            this.Settings.Icon = global::HuskyBrowser.Properties.Resources.settings;
            this.Settings.Location = new System.Drawing.Point(254, 87);
            this.Settings.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Settings.MouseState = MaterialSkin.MouseState.HOVER;
            this.Settings.Name = "Settings";
            this.Settings.NoAccentTextColor = System.Drawing.Color.Empty;
            this.Settings.Size = new System.Drawing.Size(41, 32);
            this.Settings.TabIndex = 6;
            this.Settings.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.Settings.UseAccentColor = false;
            this.Settings.UseVisualStyleBackColor = true;
            // 
            // DeleteTorrent
            // 
            this.DeleteTorrent.AutoSize = false;
            this.DeleteTorrent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DeleteTorrent.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.DeleteTorrent.Depth = 0;
            this.DeleteTorrent.HighEmphasis = true;
            this.DeleteTorrent.Icon = global::HuskyBrowser.Properties.Resources.bin;
            this.DeleteTorrent.Location = new System.Drawing.Point(103, 87);
            this.DeleteTorrent.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.DeleteTorrent.MouseState = MaterialSkin.MouseState.HOVER;
            this.DeleteTorrent.Name = "DeleteTorrent";
            this.DeleteTorrent.NoAccentTextColor = System.Drawing.Color.Empty;
            this.DeleteTorrent.Size = new System.Drawing.Size(41, 32);
            this.DeleteTorrent.TabIndex = 5;
            this.DeleteTorrent.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.DeleteTorrent.UseAccentColor = false;
            this.DeleteTorrent.UseVisualStyleBackColor = true;
            // 
            // OpenTorrent
            // 
            this.OpenTorrent.AutoSize = false;
            this.OpenTorrent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.OpenTorrent.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.OpenTorrent.Depth = 0;
            this.OpenTorrent.HighEmphasis = true;
            this.OpenTorrent.Icon = global::HuskyBrowser.Properties.Resources.plus;
            this.OpenTorrent.Location = new System.Drawing.Point(54, 87);
            this.OpenTorrent.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.OpenTorrent.MouseState = MaterialSkin.MouseState.HOVER;
            this.OpenTorrent.Name = "OpenTorrent";
            this.OpenTorrent.NoAccentTextColor = System.Drawing.Color.Empty;
            this.OpenTorrent.Size = new System.Drawing.Size(41, 32);
            this.OpenTorrent.TabIndex = 4;
            this.OpenTorrent.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.OpenTorrent.UseAccentColor = false;
            this.OpenTorrent.UseVisualStyleBackColor = true;
            // 
            // DownloadTorrent
            // 
            this.DownloadTorrent.AutoSize = false;
            this.DownloadTorrent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DownloadTorrent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.DownloadTorrent.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Dense;
            this.DownloadTorrent.Depth = 0;
            this.DownloadTorrent.HighEmphasis = true;
            this.DownloadTorrent.Icon = global::HuskyBrowser.Properties.Resources.link;
            this.DownloadTorrent.Location = new System.Drawing.Point(7, 87);
            this.DownloadTorrent.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.DownloadTorrent.MouseState = MaterialSkin.MouseState.HOVER;
            this.DownloadTorrent.Name = "DownloadTorrent";
            this.DownloadTorrent.NoAccentTextColor = System.Drawing.Color.Empty;
            this.DownloadTorrent.Size = new System.Drawing.Size(39, 32);
            this.DownloadTorrent.TabIndex = 3;
            this.DownloadTorrent.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.DownloadTorrent.UseAccentColor = false;
            this.DownloadTorrent.UseVisualStyleBackColor = true;
            this.DownloadTorrent.Click += new System.EventHandler(this.DownloadTorrent_Click);
            // 
            // TorrentClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 684);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.Settings);
            this.Controls.Add(this.DeleteTorrent);
            this.Controls.Add(this.OpenTorrent);
            this.Controls.Add(this.DownloadTorrent);
            this.Controls.Add(this.InfoTorrentPanel);
            this.Controls.Add(this.DataTorrentsPanel);
            this.Name = "TorrentClientForm";
            this.Text = "Husky Client";
            this.InfoTorrentPanel.ResumeLayout(false);
            this.InfoTorrentPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar TorrentDownloadProgress;
        private System.Windows.Forms.Panel DataTorrentsPanel;
        private System.Windows.Forms.Panel InfoTorrentPanel;
        private System.Windows.Forms.Label Percent;
        private System.Windows.Forms.Label progrssText;
        private MaterialSkin.Controls.MaterialButton DownloadTorrent;
        private MaterialSkin.Controls.MaterialButton OpenTorrent;
        private MaterialSkin.Controls.MaterialButton DeleteTorrent;
        private MaterialSkin.Controls.MaterialButton Settings;
        private MaterialSkin.Controls.MaterialButton StartButton;
        private MaterialSkin.Controls.MaterialButton StopButton;
    }
}