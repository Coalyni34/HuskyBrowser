using HuskyBrowser.HuskyBrowserManagement.TorrentsManagement.TorrentDialogs;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuskyBrowser.HuskyBrowserManagement.TorrentsManagement
{
    public partial class TorrentClientForm : MaterialForm
    {
        static Color Page_BackColor { get; set; } = MainForm._BackColor;
        public TorrentClientForm()
        {
            InitializeComponent();
            BackColor = Page_BackColor;
        }

        string MagnetLink;
        private void DownloadTorrent_Click(object sender, EventArgs e)
        {
            DownloadMagnetTorrent downloadMagnetTorrent = new DownloadMagnetTorrent();
            downloadMagnetTorrent.Show();
        }
    }
}
