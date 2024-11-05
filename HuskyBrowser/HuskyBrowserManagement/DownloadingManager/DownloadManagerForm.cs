using HuskyBrowser.WorkingWithBrowserProperties;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuskyBrowser.HuskyBrowserManagement.DownloadingManager
{
    public partial class DownloadManagerForm : MaterialForm
    {
        public DownloadManagerForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo600, Primary.Indigo600, Primary.BlueGrey500, Accent.Cyan100, TextShade.WHITE);
            
            var _fM = new FileManager();

            var files = _fM._GetFilesFromDirectory("downloads");                       

            foreach (var f in files) 
            {
                FileInfo fileInfo = new FileInfo(_fM._GetPathToFile(f, "downloads"));
                var dateTime = fileInfo.CreationTime;
                dataGridView1.Rows.Add($"{dateTime.Day}.{dateTime.Month}.{dateTime.Year}", f);
            }            
        }       
        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) 
        {
                   
        }
    }
}
