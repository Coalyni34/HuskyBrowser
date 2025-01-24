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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParserForm));
            this.ChoosingBox = new MaterialSkin.Controls.MaterialComboBox();
            this.ChooseText = new MaterialSkin.Controls.MaterialLabel();
            this.PirateChoose = new MaterialSkin.Controls.MaterialComboBox();
            this.OrText = new MaterialSkin.Controls.MaterialLabel();
            this.PirateSiteLink = new MaterialSkin.Controls.MaterialTextBox();
            this.GetMagnetLinks = new MaterialSkin.Controls.MaterialButton();
            this.MagnerLinksBox = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.EnterRequest = new MaterialSkin.Controls.MaterialTextBox();
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
            "Marketplaces",
            "Else"});
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
            this.PirateChoose.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.PirateChoose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.PirateChoose.FormattingEnabled = true;
            this.PirateChoose.IntegralHeight = false;
            this.PirateChoose.ItemHeight = 43;
            this.PirateChoose.Items.AddRange(new object[] {
            "Rutracker",
            "The Pirate Bay"});
            this.PirateChoose.Location = new System.Drawing.Point(9, 122);
            this.PirateChoose.MaxDropDownItems = 4;
            this.PirateChoose.MouseState = MaterialSkin.MouseState.OUT;
            this.PirateChoose.Name = "PirateChoose";
            this.PirateChoose.Size = new System.Drawing.Size(167, 49);
            this.PirateChoose.StartIndex = 0;
            this.PirateChoose.TabIndex = 2;
            // 
            // OrText
            // 
            this.OrText.AutoSize = true;
            this.OrText.Depth = 0;
            this.OrText.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.OrText.Location = new System.Drawing.Point(182, 136);
            this.OrText.MouseState = MaterialSkin.MouseState.HOVER;
            this.OrText.Name = "OrText";
            this.OrText.Size = new System.Drawing.Size(182, 19);
            this.OrText.TabIndex = 3;
            this.OrText.Text = "or you can send other link";
            // 
            // PirateSiteLink
            // 
            this.PirateSiteLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PirateSiteLink.AnimateReadOnly = false;
            this.PirateSiteLink.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PirateSiteLink.Depth = 0;
            this.PirateSiteLink.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.PirateSiteLink.LeadingIcon = null;
            this.PirateSiteLink.Location = new System.Drawing.Point(370, 121);
            this.PirateSiteLink.MaxLength = 50;
            this.PirateSiteLink.MouseState = MaterialSkin.MouseState.OUT;
            this.PirateSiteLink.Multiline = false;
            this.PirateSiteLink.Name = "PirateSiteLink";
            this.PirateSiteLink.Size = new System.Drawing.Size(424, 50);
            this.PirateSiteLink.TabIndex = 4;
            this.PirateSiteLink.Text = "";
            this.PirateSiteLink.TrailingIcon = null;
            // 
            // GetMagnetLinks
            // 
            this.GetMagnetLinks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GetMagnetLinks.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GetMagnetLinks.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.GetMagnetLinks.Depth = 0;
            this.GetMagnetLinks.HighEmphasis = true;
            this.GetMagnetLinks.Icon = null;
            this.GetMagnetLinks.Location = new System.Drawing.Point(632, 180);
            this.GetMagnetLinks.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.GetMagnetLinks.MouseState = MaterialSkin.MouseState.HOVER;
            this.GetMagnetLinks.Name = "GetMagnetLinks";
            this.GetMagnetLinks.NoAccentTextColor = System.Drawing.Color.Empty;
            this.GetMagnetLinks.Size = new System.Drawing.Size(161, 36);
            this.GetMagnetLinks.TabIndex = 6;
            this.GetMagnetLinks.Text = "Get Magnet links!";
            this.GetMagnetLinks.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.GetMagnetLinks.UseAccentColor = false;
            this.GetMagnetLinks.UseVisualStyleBackColor = true;
            // 
            // MagnerLinksBox
            // 
            this.MagnerLinksBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MagnerLinksBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.MagnerLinksBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MagnerLinksBox.Depth = 0;
            this.MagnerLinksBox.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.MagnerLinksBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.MagnerLinksBox.Location = new System.Drawing.Point(9, 233);
            this.MagnerLinksBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.MagnerLinksBox.Name = "MagnerLinksBox";
            this.MagnerLinksBox.Size = new System.Drawing.Size(785, 211);
            this.MagnerLinksBox.TabIndex = 7;
            this.MagnerLinksBox.Text = "";
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
            this.EnterRequest.Location = new System.Drawing.Point(9, 177);
            this.EnterRequest.MaxLength = 50;
            this.EnterRequest.MouseState = MaterialSkin.MouseState.OUT;
            this.EnterRequest.Multiline = false;
            this.EnterRequest.Name = "EnterRequest";
            this.EnterRequest.Size = new System.Drawing.Size(616, 50);
            this.EnterRequest.TabIndex = 8;
            this.EnterRequest.Text = "";
            this.EnterRequest.TrailingIcon = null;
            // 
            // ParserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.EnterRequest);
            this.Controls.Add(this.MagnerLinksBox);
            this.Controls.Add(this.GetMagnetLinks);
            this.Controls.Add(this.PirateSiteLink);
            this.Controls.Add(this.OrText);
            this.Controls.Add(this.PirateChoose);
            this.Controls.Add(this.ChooseText);
            this.Controls.Add(this.ChoosingBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ParserForm";
            this.Text = "Parser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialComboBox ChoosingBox;
        private MaterialSkin.Controls.MaterialLabel ChooseText;
        private MaterialSkin.Controls.MaterialComboBox PirateChoose;
        private MaterialSkin.Controls.MaterialLabel OrText;
        private MaterialSkin.Controls.MaterialTextBox PirateSiteLink;
        private MaterialSkin.Controls.MaterialButton GetMagnetLinks;
        private MaterialSkin.Controls.MaterialMultiLineTextBox MagnerLinksBox;
        private MaterialSkin.Controls.MaterialTextBox EnterRequest;
    }
}