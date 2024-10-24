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

namespace HuskyBrowser.WorkingWithBrowserProperties.HistoryMagement
{
    public partial class HistoryJournal : MaterialForm
    {
        static Color _BackColor { get; set; } = Color.FromArgb(255, 50, 50, 50);
        public HistoryJournal()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo600, Primary.Indigo600, Primary.BlueGrey500, Accent.Cyan100, TextShade.WHITE);
            InitializeJournal();
        }

        private void InitializeJournal()
        {            
            var _fM = new FileManager();

            string pathToHistory = _fM._ReadFileText(_fM._GetPathToFile("history.json"));
            Dictionary<string, List<HistoryEntry>> entries_Dict = JsonSerializer.Deserialize<Dictionary<string, List<HistoryEntry>>>(pathToHistory);

            materialComboBox1.Items.AddRange(entries_Dict.Keys.ToArray());
            materialComboBox1.SelectedItem = $"{DateTime.Now}".Split(' ')[0];

            List<HistoryEntry> entries = entries_Dict[materialComboBox1.Text];                       

            foreach (HistoryEntry entry in entries)
            {
                materialMultiLineTextBox1.Text += $"{entry.URL} \n";
                materialMultiLineTextBox2.Text += $"{entry.Time} \n";
                materialMultiLineTextBox3.Text += $"{entry.Title} \n";
            }
        }

        private void HistoryJournal_Load(object sender, EventArgs e)
        {
           
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            var _fM = new FileManager();

            var path = _fM._GetPathToFile("history.json");

            _fM._DeleteFileText(path);
            _fM._WriteFile(string.Empty, path);

            MaterialMultiLineTextBox[] textBoxes = new MaterialMultiLineTextBox[] { materialMultiLineTextBox1, materialMultiLineTextBox2, materialMultiLineTextBox3 };
            foreach (var textBox in textBoxes)
            {
                textBox.Text = String.Empty;
            }
            materialComboBox1.Items.Clear();
            materialComboBox1.Text = String.Empty;

            Application.Restart();
        }

        private void materialComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var _fM = new FileManager();

            string pathToHistory = _fM._ReadFileText(_fM._GetPathToFile("history.json"));
            Dictionary<string, List<HistoryEntry>> entries_Dict = JsonSerializer.Deserialize<Dictionary<string, List<HistoryEntry>>>(pathToHistory);
                    
            List<HistoryEntry> entries = entries_Dict[materialComboBox1.Text];

            MaterialMultiLineTextBox[] textBoxes = new MaterialMultiLineTextBox[] { materialMultiLineTextBox1, materialMultiLineTextBox2, materialMultiLineTextBox3 };

            foreach(var textBox in textBoxes) 
            {
                textBox.Text = String.Empty;
                textBox.ReadOnly = true;
            }

            foreach (HistoryEntry entry in entries)
            {
                materialMultiLineTextBox1.Text += $"{entry.URL} \n";
                materialMultiLineTextBox2.Text += $"{entry.Time} \n";
                materialMultiLineTextBox3.Text += $"{entry.Title} \n";
            }
        }
    }
}
