using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;
using HuskyBrowser.HuskyBrowserManagement.ParserManager.ParcerCore;
using System.Collections.Generic;
using CefSharp;
using static HuskyBrowser.HuskyBrowserManagement.ParserManager.ParcerCore.RuTrackerParser;
using System.Web.UI.WebControls;
using System.Linq;
using System.Net.Http;
using CefSharp.DevTools.IO;
using HuskyBrowser.HuskyBrowserManagement.DownloadingManager;
using HuskyBrowser.HuskyBrowserManagement.BrowserManagement.SearchContextMenuManager;

namespace HuskyBrowser.HuskyBrowserManagement.ParserManager
{
    public partial class ParserForm : MaterialForm
    {
        static Color _BackColor { get; set; } = MainForm._BackColor;
        public ParserForm()
        {
            InitializeComponent();
            BackColor = _BackColor;
            TorrentsInfoData.BackgroundColor = _BackColor;
            TorrentsInfoData.GridColor = _BackColor;

            DataGridViewTextBoxColumn[] dataGridViewTextBoxColumns = new DataGridViewTextBoxColumn[] { NameOfTorrent, Category, Seeders, Leechers, Size, Magnet};

            foreach(var column in dataGridViewTextBoxColumns) 
            {
                column.DefaultCellStyle.BackColor = _BackColor;
                column.DefaultCellStyle.ForeColor = Color.White;
            }

            SearchContextMenuHandler menuHandler = new SearchContextMenuHandler();
            DownloadManager downloadManager = new DownloadManager();
            HtmlBrowser.DownloadHandler = downloadManager;
            HtmlBrowser.MenuHandler = menuHandler;
        }

        private void ChoosingBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Control[,] controls = new Control[,] {
                { PirateChoose, EnterRequest, GetTorrentsButton, ClearButton, TorrentsInfoData, HtmlBrowser}
            };
            if (ChoosingBox.SelectedIndex == 0) 
            {
                for (int i = 0; i < controls.GetLength(1); i++) 
                {
                    controls[0, i].Visible = true;
                }                
            }
            else
            {
                for (int i = 0; i < controls.GetLength(1); i++)
                {
                    controls[0, i].Visible = false;
                }
            }
        }

        ThePirateBayParser thePirateBayParser = new ThePirateBayParser();
        private async void GetMagnetLinks_ClickAsync(object sender, EventArgs e)
        {            
            if (EnterRequest.Text != string.Empty) 
            {
                switch (PirateChoose.SelectedItem) 
                {
                    case "Rutracker":                        
                        TorrentsInfoData.Columns.Clear();
                        TorrentsInfoData.Rows.Clear();
                        TorrentsInfoData.Columns.Add("NameColumn", "Name");
                        TorrentsInfoData.Columns.Add("LinkColumn", "Link");
                        TorrentsInfoData.Columns[0].DefaultCellStyle.BackColor = _BackColor;
                        TorrentsInfoData.Columns[0].DefaultCellStyle.ForeColor = Color.White;
                        TorrentsInfoData.Columns[1].DefaultCellStyle.BackColor = _BackColor;
                        TorrentsInfoData.Columns[1].DefaultCellStyle.ForeColor = Color.White;
                        TorrentsInfoData.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        RuTrackerParser ruTrackerParser = new RuTrackerParser();
                        await ruTrackerParser.ParseTorrents(EnterRequest.Text, TorrentsInfoData);
                        var info = ruTrackerParser.GetLinksOfPages(ruTrackerParser.htmlPageTracker);
                        for (int i = 0; i < info.Count; i++)
                        {
                            TorrentsInfoData.Rows.Add(info.Keys.ToList()[i], info.Values.ToList()[i]);
                        }                     
                        break;
                    case "ThePirateBay":
                        thePirateBayParser.Torrents.Clear();
                        await thePirateBayParser.FindTorrents(EnterRequest.Text);
                        TorrentsInfoData.Columns.Clear();
                        TorrentsInfoData.Rows.Clear();
                        TorrentsInfoData.Columns.Add("NameColumn", "Name");
                        TorrentsInfoData.Columns.Add("CategoryColumn", "Category");
                        TorrentsInfoData.Columns.Add("SeedColumn", "Seeders");
                        TorrentsInfoData.Columns.Add("LeechColumn", "Leechers");
                        TorrentsInfoData.Columns.Add("SizeColumn", "Size");
                        TorrentsInfoData.Columns.Add("MagnetColumn", "MagnetLink");      
                        foreach (var torrent in thePirateBayParser.Torrents)
                        {
                            TorrentsInfoData.Rows.Add(torrent.name, torrent.category, torrent.seeders, torrent.leechers, $"{(torrent.size)/1048576} MB ({(torrent.size)/1073741824} GB)", torrent.magnetLink);
                        }
                        for (int i = 0; i < TorrentsInfoData.Columns.Count; i++)
                        {
                            TorrentsInfoData.Columns[i].DefaultCellStyle.BackColor = _BackColor;
                            TorrentsInfoData.Columns[i].DefaultCellStyle.ForeColor = Color.White;
                            TorrentsInfoData.Columns[TorrentsInfoData.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }
                        break;
                }
            }            
        }     
        private void ClearButon_Click(object sender, EventArgs e) 
        {
            if (EnterRequest.Text != string.Empty || TorrentsInfoData.Rows != null)  
            {
                EnterRequest.Clear();
                TorrentsInfoData.Rows.Clear();
                thePirateBayParser.Torrents.Clear();
                HtmlBrowser.Enabled = false;
                HtmlBrowser.Visible = false;
            }
        }

        private async void Torrents__CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var value = TorrentsInfoData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();            
            if (value.StartsWith("https://rutracker.net/"))
            {
                HtmlBrowser.Enabled = true;
                HtmlBrowser.Visible = true;
                HtmlBrowser.Load(value);
            }            
            Clipboard.SetText(value);
        }

        private void PirateChoose_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (PirateChoose.SelectedItem)
            {
                case "Rutracker":
                    RuTrackerParser ruTrackerParser = new RuTrackerParser();
                    TorrentsInfoData.Columns.Clear();
                    TorrentsInfoData.Rows.Clear();
                    TorrentsInfoData.Columns.Add("NameColumn", "Name");
                    TorrentsInfoData.Columns.Add("LinkColumn", "Link");
                    TorrentsInfoData.Columns[0].DefaultCellStyle.BackColor = _BackColor;
                    TorrentsInfoData.Columns[0].DefaultCellStyle.ForeColor = Color.White;
                    TorrentsInfoData.Columns[1].DefaultCellStyle.BackColor = _BackColor;
                    TorrentsInfoData.Columns[1].DefaultCellStyle.ForeColor = Color.White;
                    TorrentsInfoData.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    Login.Visible = true;
                    Password.Visible = true;
                    HtmlBrowser.Enabled = true;
                    HtmlBrowser.Visible = true;
                    break;
                case "ThePirateBay":                  
                    TorrentsInfoData.Columns.Clear();
                    TorrentsInfoData.Rows.Clear();
                    TorrentsInfoData.Columns.Add("NameColumn", "Name");
                    TorrentsInfoData.Columns.Add("CategoryColumn", "Category");
                    TorrentsInfoData.Columns.Add("SeedColumn", "Seeders");
                    TorrentsInfoData.Columns.Add("LeechColumn", "Leechers");
                    TorrentsInfoData.Columns.Add("SizeColumn", "Size");
                    TorrentsInfoData.Columns.Add("MagnetColumn", "MagnetLink");
                    Login.Visible = false;
                    Password.Visible = false;
                    for (int i = 0; i < TorrentsInfoData.Columns.Count; i++)
                    {
                        TorrentsInfoData.Columns[i].DefaultCellStyle.BackColor = _BackColor;
                        TorrentsInfoData.Columns[i].DefaultCellStyle.ForeColor = Color.White;
                        TorrentsInfoData.Columns[TorrentsInfoData.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    HtmlBrowser.Enabled = false;
                    HtmlBrowser.Visible = false;
                    break;
            }
        }
    }
}
