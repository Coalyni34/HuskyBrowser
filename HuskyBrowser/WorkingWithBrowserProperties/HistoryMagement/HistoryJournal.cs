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

namespace HuskyBrowser.WorkingWithBrowserProperties.HistoryMagement
{
    public partial class HistoryJournal : MaterialForm
    {
        static Color _BackColor { get; set; } = Color.FromArgb(255, 23, 25, 30);
        public HistoryJournal()
        {
            InitializeComponent();           

            BackColor = _BackColor;

            var _fM = new FileManager();
            string[] _history = _fM._ReadFileLines(_fM._GetPathToFile("history.txt", "histоry")).ToArray();

            foreach (var _title in _history)
            {
                materialMultiLineTextBox1.Text += _title + "\n";
            }
        }
        private void HistoryJournal_Load(object sender, EventArgs e)
        {
           
        }
        private void materialButton1_Click(object sender, EventArgs e)
        {
            var _fM = new FileManager();
            _fM._DeleteFileText(_fM._GetPathToFile("history.txt", "histоry"));
            _fM._WriteFile("", _fM._GetPathToFile("history.txt", "histоry"));

            materialMultiLineTextBox1.Text = "";
        }
    }
}
