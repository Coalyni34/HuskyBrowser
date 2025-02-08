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
            this.progrssText = new System.Windows.Forms.Label();
            this.Percent = new System.Windows.Forms.Label();
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
            // progrssText
            // 
            this.progrssText.AutoSize = true;
            this.progrssText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.progrssText.Location = new System.Drawing.Point(3, 6);
            this.progrssText.Name = "progrssText";
            this.progrssText.Size = new System.Drawing.Size(76, 20);
            this.progrssText.TabIndex = 1;
            this.progrssText.Text = "Progress:";
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
            // TorrentClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 684);
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
    }
}