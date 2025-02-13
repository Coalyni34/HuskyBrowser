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

namespace HuskyBrowser.HuskyBrowserManagement.TorrentsManagement.TorrentDialogs
{
    public partial class DownloadMagnetTorrent : MaterialForm
    {
        static Color Page_BackColor { get; set; } = MainForm._BackColor;
        public List<string> MagnetTorrents;
        public DownloadMagnetTorrent()
        {
            InitializeComponent();
            BackColor = Page_BackColor;
        }

        private void StartDownloadingButton_Click(object sender, EventArgs e)
        {
            foreach (var torrent in MagnetLinks.Text.Split(' ')) 
            {
                MagnetTorrents.Add(torrent);
            }
        }
    }
}
