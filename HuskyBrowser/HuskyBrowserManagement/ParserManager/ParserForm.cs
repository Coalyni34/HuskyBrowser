﻿using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;
using HuskyBrowser.HuskyBrowserManagement.ParserManager.ParcerCore;
using System.Collections.Generic;
using CefSharp;
using static HuskyBrowser.HuskyBrowserManagement.ParserManager.ParcerCore.RuTrackerParser;

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

            DataGridViewTextBoxColumn[] dataGridViewTextBoxColumns = new DataGridViewTextBoxColumn[] { NameOfTorrent, Category, Seeders, Leechers, Size, magnet};

            foreach(var column in dataGridViewTextBoxColumns) 
            {
                column.DefaultCellStyle.BackColor = _BackColor;
                column.DefaultCellStyle.ForeColor = Color.White;
            }
        }

        private void ChoosingBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Control[,] controls = new Control[,] {
                { PirateChoose, EnterRequest, GetTorrentsButton, ClearButton, TorrentsInfoData}
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

        private async void GetMagnetLinks_ClickAsync(object sender, EventArgs e)
        {            
            if (EnterRequest.Text != string.Empty) 
            {
                switch (PirateChoose.SelectedItem) 
                {
                    case "Rutracker":
                        RuTrackerParser ruTrackerParser = new RuTrackerParser();
                        TorrentsInfoData.Rows.Clear();
                        await ruTrackerParser.ParseTorrents(EnterRequest.Text, TorrentsInfoData);
                        break;
                    case "ThePirateBay":
                        ThePirateBayParser thePirateBayParser = new ThePirateBayParser();
                        TorrentsInfoData.Rows.Clear();
                        await thePirateBayParser.FindTorrents(EnterRequest.Text);                       
                        foreach (var torrent in thePirateBayParser.Torrents)
                        {
                            TorrentsInfoData.Rows.Add(torrent.name, torrent.category, torrent.seeders, torrent.leechers, $"{(torrent.size)/1048576} MB ({(torrent.size)/1073741824} GB)", torrent.magnetLink);
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
                Torrents.Clear();
            }
        }

        private async void Torrents__CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var value = TorrentsInfoData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            Clipboard.SetText(value);
        }       
    }
}
