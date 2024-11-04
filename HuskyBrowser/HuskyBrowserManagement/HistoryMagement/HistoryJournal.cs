using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using static HuskyBrowser.WorkingWithBrowserProperties.HistoryManager;
using HuskyBrowser.WorkingWithBrowserProperties.BookMarksManager;

namespace HuskyBrowser.WorkingWithBrowserProperties.HistoryMagement
{
    public partial class HistoryJournal : MaterialForm
    {
        static Color _BackColor { get; set; } = Color.FromArgb(255, 50, 50, 50);
        MaterialTabControl tabControl;
        public HistoryJournal(MaterialTabControl tabControl)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo600, Primary.Indigo600, Primary.BlueGrey500, Accent.Cyan100, TextShade.WHITE);
            InitializeJournal(tabControl);
        }

        private void InitializeJournal(MaterialTabControl _tabControl)
        {
            var History_Files = new FileManager.History_Files();

            string path = History_Files._GetPathToHistoryFile("history.json"); 
            string jsonHistory = History_Files._ReadFileText(path);
            
            Dictionary<string, List<HistoryEntry>> entries_Dict = JsonSerializer.Deserialize<Dictionary<string, List<HistoryEntry>>>(jsonHistory);
            
            materialComboBox1.Items.AddRange(entries_Dict.Keys.ToArray());
            materialComboBox1.SelectedItem = $"{DateTime.Now}".Split(' ')[0];

            List<HistoryEntry> entries = entries_Dict[materialComboBox1.Text];

            tabControl = _tabControl;

            foreach (HistoryEntry entry in entries)
            {
                dataGridView1.Rows.Add($"{entry.Title}", $"{entry.Time}", $"{entry.URL}");                
            }
            
        }

        private void HistoryJournal_Load(object sender, EventArgs e)
        {
           
        }
        private void materialButton1_Click(object sender, EventArgs e)
        {
            var History_Files = new FileManager.History_Files();
            string path = History_Files._GetPathToHistoryFile("history.json");

            History_Files._DeleteFileText(path);
            History_Files._WriteFile(string.Empty, path);
            
            dataGridView1.Rows.Clear();
            
            materialComboBox1.Items.Clear();
            materialComboBox1.SelectedItem = string.Empty;
        }

        private void materialComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var History_Files = new FileManager.History_Files();

            string jsonHistory = History_Files._ReadFileText(History_Files._GetPathToHistoryFile("history.json"));
            Dictionary<string, List<HistoryEntry>> entries_Dict = JsonSerializer.Deserialize<Dictionary<string, List<HistoryEntry>>>(jsonHistory);
                    
            List<HistoryEntry> entries = entries_Dict[materialComboBox1.Text];

            dataGridView1.Rows.Clear(); 
            
            foreach (HistoryEntry entry in entries)
            {
                dataGridView1.Rows.Add(entry.Title, entry.Time, entry.URL);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var url = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            var title = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex - 2].Value.ToString();

            if (url.StartsWith("https://") || url.StartsWith("http://"))
            {
                var _fM = new FileManager();
                string path = _fM._GetPathToFile("bookmarks.json", "bookmarks");
                string json = _fM._ReadFileText(path);
                Dictionary<string, BookMarksManager.BookMarksManager.BookMark> bookMarks_Dict = JsonSerializer.Deserialize<Dictionary<string, BookMarksManager.BookMarksManager.BookMark>>(json);

                List<Image> icons = new List<Image>();
                for (short i = 0; i < imageList1.Images.Count; i++)
                {
                    icons.Add(imageList1.Images[i]);
                }
                List<Image> markbutton_icons = new List<Image>();
                for (short i = 0; i < imageList2.Images.Count; i++)
                {
                    markbutton_icons.Add(imageList2.Images[i]);
                }
                PagePattern.SimplePagePattern simplePagePattern = new PagePattern.SimplePagePattern(icons, markbutton_icons, tabControl, url, title);
                Form1.thisform.Text = title;
            }
        }
    }
}
