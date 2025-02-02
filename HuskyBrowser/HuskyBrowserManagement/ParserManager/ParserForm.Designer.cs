namespace HuskyBrowser.HuskyBrowserManagement.ParserManager
{
    partial class ParserForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParserForm));
            this.ChoosingBox = new MaterialSkin.Controls.MaterialComboBox();
            this.ChooseText = new MaterialSkin.Controls.MaterialLabel();
            this.PirateChoose = new MaterialSkin.Controls.MaterialComboBox();
            this.ClearButton = new MaterialSkin.Controls.MaterialButton();
            this.EnterRequest = new MaterialSkin.Controls.MaterialTextBox();
            this.PanelTorrents = new System.Windows.Forms.Panel();
            this.TorrentsInfoData = new System.Windows.Forms.DataGridView();
            this.NameOfTorrent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seeders = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Leechers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Magnet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GetTorrentsButton = new MaterialSkin.Controls.MaterialButton();
            this.ChromePanel = new System.Windows.Forms.Panel();
            this.HtmlBrowser = new CefSharp.WinForms.ChromiumWebBrowser();
            this.Login = new MaterialSkin.Controls.MaterialLabel();
            this.Password = new MaterialSkin.Controls.MaterialLabel();
            this.PanelTorrents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TorrentsInfoData)).BeginInit();
            this.ChromePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChoosingBox
            // 
            this.ChoosingBox.AutoResize = false;
            this.ChoosingBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ChoosingBox.Depth = 0;
            this.ChoosingBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ChoosingBox.DropDownHeight = 174;
            this.ChoosingBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ChoosingBox.DropDownWidth = 121;
            this.ChoosingBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ChoosingBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ChoosingBox.FormattingEnabled = true;
            this.ChoosingBox.IntegralHeight = false;
            this.ChoosingBox.ItemHeight = 43;
            this.ChoosingBox.Items.AddRange(new object[] {
            "Torrent sites",
            "Marketplaces"});
            this.ChoosingBox.Location = new System.Drawing.Point(156, 67);
            this.ChoosingBox.MaxDropDownItems = 4;
            this.ChoosingBox.MouseState = MaterialSkin.MouseState.OUT;
            this.ChoosingBox.Name = "ChoosingBox";
            this.ChoosingBox.Size = new System.Drawing.Size(142, 49);
            this.ChoosingBox.StartIndex = 0;
            this.ChoosingBox.TabIndex = 0;
            this.ChoosingBox.SelectedIndexChanged += new System.EventHandler(this.ChoosingBox_SelectedIndexChanged);
            // 
            // ChooseText
            // 
            this.ChooseText.AutoSize = true;
            this.ChooseText.Depth = 0;
            this.ChooseText.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ChooseText.Location = new System.Drawing.Point(6, 80);
            this.ChooseText.MouseState = MaterialSkin.MouseState.HOVER;
            this.ChooseText.Name = "ChooseText";
            this.ChooseText.Size = new System.Drawing.Size(144, 19);
            this.ChooseText.TabIndex = 1;
            this.ChooseText.Text = "Choose parsing site:";
            // 
            // PirateChoose
            // 
            this.PirateChoose.AutoResize = false;
            this.PirateChoose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.PirateChoose.Depth = 0;
            this.PirateChoose.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.PirateChoose.DropDownHeight = 174;
            this.PirateChoose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PirateChoose.DropDownWidth = 121;
            this.PirateChoose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.PirateChoose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.PirateChoose.FormattingEnabled = true;
            this.PirateChoose.IntegralHeight = false;
            this.PirateChoose.ItemHeight = 43;
            this.PirateChoose.Items.AddRange(new object[] {
            "Rutracker",
            "ThePirateBay"});
            this.PirateChoose.Location = new System.Drawing.Point(304, 67);
            this.PirateChoose.MaxDropDownItems = 4;
            this.PirateChoose.MouseState = MaterialSkin.MouseState.OUT;
            this.PirateChoose.Name = "PirateChoose";
            this.PirateChoose.Size = new System.Drawing.Size(167, 49);
            this.PirateChoose.StartIndex = 0;
            this.PirateChoose.TabIndex = 2;
            this.PirateChoose.SelectedValueChanged += new System.EventHandler(this.PirateChoose_SelectedValueChanged);
            // 
            // ClearButton
            // 
            this.ClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearButton.AutoSize = false;
            this.ClearButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClearButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Dense;
            this.ClearButton.Depth = 0;
            this.ClearButton.DrawShadows = false;
            this.ClearButton.HighEmphasis = true;
            this.ClearButton.Icon = null;
            this.ClearButton.Location = new System.Drawing.Point(1063, 179);
            this.ClearButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.ClearButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.ClearButton.Size = new System.Drawing.Size(89, 49);
            this.ClearButton.TabIndex = 6;
            this.ClearButton.Text = "Clear";
            this.ClearButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.ClearButton.UseAccentColor = false;
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButon_Click);
            // 
            // EnterRequest
            // 
            this.EnterRequest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EnterRequest.AnimateReadOnly = false;
            this.EnterRequest.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EnterRequest.Depth = 0;
            this.EnterRequest.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.EnterRequest.LeadingIcon = null;
            this.EnterRequest.Location = new System.Drawing.Point(9, 178);
            this.EnterRequest.MaxLength = 9999;
            this.EnterRequest.MouseState = MaterialSkin.MouseState.OUT;
            this.EnterRequest.Multiline = false;
            this.EnterRequest.Name = "EnterRequest";
            this.EnterRequest.Size = new System.Drawing.Size(950, 50);
            this.EnterRequest.TabIndex = 8;
            this.EnterRequest.Text = "";
            this.EnterRequest.TrailingIcon = null;
            // 
            // PanelTorrents
            // 
            this.PanelTorrents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelTorrents.Controls.Add(this.TorrentsInfoData);
            this.PanelTorrents.Location = new System.Drawing.Point(6, 233);
            this.PanelTorrents.Name = "PanelTorrents";
            this.PanelTorrents.Size = new System.Drawing.Size(642, 482);
            this.PanelTorrents.TabIndex = 9;
            // 
            // TorrentsInfoData
            // 
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.TorrentsInfoData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.TorrentsInfoData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TorrentsInfoData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameOfTorrent,
            this.Category,
            this.Seeders,
            this.Leechers,
            this.Size,
            this.Magnet});
            this.TorrentsInfoData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TorrentsInfoData.Location = new System.Drawing.Point(0, 0);
            this.TorrentsInfoData.Name = "TorrentsInfoData";
            this.TorrentsInfoData.Size = new System.Drawing.Size(642, 482);
            this.TorrentsInfoData.TabIndex = 0;
            this.TorrentsInfoData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Torrents__CellContentClick);
            // 
            // NameOfTorrent
            // 
            this.NameOfTorrent.HeaderText = "Name";
            this.NameOfTorrent.Name = "NameOfTorrent";
            this.NameOfTorrent.ReadOnly = true;
            // 
            // Category
            // 
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            // 
            // Seeders
            // 
            this.Seeders.HeaderText = "Seeders";
            this.Seeders.Name = "Seeders";
            this.Seeders.ReadOnly = true;
            // 
            // Leechers
            // 
            this.Leechers.HeaderText = "Leechers";
            this.Leechers.Name = "Leechers";
            this.Leechers.ReadOnly = true;
            // 
            // Size
            // 
            this.Size.HeaderText = "Size";
            this.Size.Name = "Size";
            this.Size.ReadOnly = true;
            // 
            // Magnet
            // 
            this.Magnet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Magnet.HeaderText = "Magnet";
            this.Magnet.Name = "Magnet";
            this.Magnet.ReadOnly = true;
            // 
            // GetTorrentsButton
            // 
            this.GetTorrentsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GetTorrentsButton.AutoSize = false;
            this.GetTorrentsButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GetTorrentsButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Dense;
            this.GetTorrentsButton.Depth = 0;
            this.GetTorrentsButton.DrawShadows = false;
            this.GetTorrentsButton.HighEmphasis = true;
            this.GetTorrentsButton.Icon = null;
            this.GetTorrentsButton.Location = new System.Drawing.Point(966, 178);
            this.GetTorrentsButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.GetTorrentsButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.GetTorrentsButton.Name = "GetTorrentsButton";
            this.GetTorrentsButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.GetTorrentsButton.Size = new System.Drawing.Size(89, 49);
            this.GetTorrentsButton.TabIndex = 10;
            this.GetTorrentsButton.Text = "Search Torrents";
            this.GetTorrentsButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.GetTorrentsButton.UseAccentColor = false;
            this.GetTorrentsButton.UseVisualStyleBackColor = true;
            this.GetTorrentsButton.Click += new System.EventHandler(this.GetMagnetLinks_ClickAsync);
            // 
            // ChromePanel
            // 
            this.ChromePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChromePanel.Controls.Add(this.HtmlBrowser);
            this.ChromePanel.Location = new System.Drawing.Point(654, 234);
            this.ChromePanel.Name = "ChromePanel";
            this.ChromePanel.Size = new System.Drawing.Size(633, 481);
            this.ChromePanel.TabIndex = 11;
            // 
            // HtmlBrowser
            // 
            this.HtmlBrowser.ActivateBrowserOnCreation = false;
            this.HtmlBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HtmlBrowser.Location = new System.Drawing.Point(0, 0);
            this.HtmlBrowser.Name = "HtmlBrowser";
            this.HtmlBrowser.Size = new System.Drawing.Size(633, 481);
            this.HtmlBrowser.TabIndex = 0;
            // 
            // Login
            // 
            this.Login.AutoSize = true;
            this.Login.Depth = 0;
            this.Login.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Login.Location = new System.Drawing.Point(6, 119);
            this.Login.MouseState = MaterialSkin.MouseState.HOVER;
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(247, 19);
            this.Login.TabIndex = 12;
            this.Login.Text = "Rutracker login: huskybrowser_ggg";
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Depth = 0;
            this.Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Password.Location = new System.Drawing.Point(6, 146);
            this.Password.MouseState = MaterialSkin.MouseState.HOVER;
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(281, 19);
            this.Password.TabIndex = 13;
            this.Password.Text = "Rutracker password: huskybrowser_ggg";
            // 
            // ParserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 721);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.ChromePanel);
            this.Controls.Add(this.GetTorrentsButton);
            this.Controls.Add(this.PanelTorrents);
            this.Controls.Add(this.EnterRequest);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.PirateChoose);
            this.Controls.Add(this.ChooseText);
            this.Controls.Add(this.ChoosingBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ParserForm";
            this.Text = "Parser";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.PanelTorrents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TorrentsInfoData)).EndInit();
            this.ChromePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialComboBox ChoosingBox;
        private MaterialSkin.Controls.MaterialLabel ChooseText;
        private MaterialSkin.Controls.MaterialComboBox PirateChoose;
        private MaterialSkin.Controls.MaterialButton ClearButton;
        private MaterialSkin.Controls.MaterialTextBox EnterRequest;
        private System.Windows.Forms.Panel PanelTorrents;
        private System.Windows.Forms.DataGridView TorrentsInfoData;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameOfTorrent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Seeders;
        private System.Windows.Forms.DataGridViewTextBoxColumn Leechers;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size;
        private System.Windows.Forms.DataGridViewTextBoxColumn Magnet;
        private MaterialSkin.Controls.MaterialButton GetTorrentsButton;
        private System.Windows.Forms.Panel ChromePanel;
        private CefSharp.WinForms.ChromiumWebBrowser HtmlBrowser;
        private MaterialSkin.Controls.MaterialLabel Login;
        private MaterialSkin.Controls.MaterialLabel Password;
    }
}