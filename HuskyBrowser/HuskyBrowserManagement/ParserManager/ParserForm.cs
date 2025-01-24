using MaterialSkin.Controls;
using RuTracker.Client.Model.SearchTopics.Request;
using RuTracker.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HuskyBrowser.HuskyBrowserManagement.ParserManager
{
    public partial class ParserForm : MaterialForm
    {
        static Color _BackColor { get; set; } = MainForm._BackColor;
        public ParserForm()
        {
            InitializeComponent();
            BackColor = _BackColor;
        }

        private void ChoosingBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Control[,] controls = new Control[,] {
                { PirateChoose, EnterRequest, GetMagnetLinks, MagnerLinksBox }
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
            
        }                
    }
}
