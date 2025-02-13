namespace HuskyBrowser.HuskyBrowserManagement.TorrentsManagement.TorrentDialogs
{
    partial class DownloadMagnetTorrent
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
            this.MagnetText = new MaterialSkin.Controls.MaterialLabel();
            this.MagnetLinks = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.StartDownloadingButton = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // MagnetText
            // 
            this.MagnetText.AutoSize = true;
            this.MagnetText.Depth = 0;
            this.MagnetText.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.MagnetText.Location = new System.Drawing.Point(6, 75);
            this.MagnetText.MouseState = MaterialSkin.MouseState.HOVER;
            this.MagnetText.Name = "MagnetText";
            this.MagnetText.Size = new System.Drawing.Size(236, 19);
            this.MagnetText.TabIndex = 0;
            this.MagnetText.Text = "Please, set your magnet-link here:";
            // 
            // MagnetLinks
            // 
            this.MagnetLinks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MagnetLinks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.MagnetLinks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MagnetLinks.Depth = 0;
            this.MagnetLinks.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.MagnetLinks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.MagnetLinks.Location = new System.Drawing.Point(6, 97);
            this.MagnetLinks.MouseState = MaterialSkin.MouseState.HOVER;
            this.MagnetLinks.Name = "MagnetLinks";
            this.MagnetLinks.Size = new System.Drawing.Size(613, 123);
            this.MagnetLinks.TabIndex = 1;
            this.MagnetLinks.Text = "";
            // 
            // StartDownloadingButton
            // 
            this.StartDownloadingButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.StartDownloadingButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.StartDownloadingButton.Depth = 0;
            this.StartDownloadingButton.DrawShadows = false;
            this.StartDownloadingButton.HighEmphasis = true;
            this.StartDownloadingButton.Icon = null;
            this.StartDownloadingButton.Location = new System.Drawing.Point(227, 229);
            this.StartDownloadingButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.StartDownloadingButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.StartDownloadingButton.Name = "StartDownloadingButton";
            this.StartDownloadingButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.StartDownloadingButton.Size = new System.Drawing.Size(176, 36);
            this.StartDownloadingButton.TabIndex = 2;
            this.StartDownloadingButton.Text = "Start downloading";
            this.StartDownloadingButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.StartDownloadingButton.UseAccentColor = false;
            this.StartDownloadingButton.UseVisualStyleBackColor = true;
            this.StartDownloadingButton.Click += new System.EventHandler(this.StartDownloadingButton_Click);
            // 
            // DownloadMagnetTorrent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 271);
            this.Controls.Add(this.StartDownloadingButton);
            this.Controls.Add(this.MagnetLinks);
            this.Controls.Add(this.MagnetText);
            this.Name = "DownloadMagnetTorrent";
            this.Text = "Download Torrent";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel MagnetText;
        private MaterialSkin.Controls.MaterialMultiLineTextBox MagnetLinks;
        private MaterialSkin.Controls.MaterialButton StartDownloadingButton;
    }
}