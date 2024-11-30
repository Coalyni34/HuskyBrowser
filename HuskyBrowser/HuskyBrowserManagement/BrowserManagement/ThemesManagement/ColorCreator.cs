using HuskyBrowser.WorkingWithBrowserProperties;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuskyBrowser.HuskyBrowserManagement.BrowserManagement.ThemesManagement
{
    public partial class ColorCreator : MaterialForm
    {
        static Color Page_BackColor { get; set; } = Form1._BackColor;
        Dictionary<string, Primary> colors = new Dictionary<string, Primary>();
        Dictionary<string, Accent> accents = new Dictionary<string, Accent>();
        public ColorCreator()
        {
            InitializeComponent();
            BackColor = Page_BackColor;    
            ForeColor = Form1._ForeColor;
            foreach(var primary in Enum.GetValues(typeof(Primary))) 
            {
                colors.Add($"{primary}", (Primary)primary);
            }
            materialComboBox2.Items.AddRange(colors.Keys.ToArray());
            materialComboBox3.Items.AddRange(colors.Keys.ToArray());           
            materialComboBox4.Items.AddRange(colors.Keys.ToArray());
            foreach(var accent  in Enum.GetValues(typeof(Accent))) 
            {
                accents.Add($"{accent}", (Accent)accent);
            }
            materialComboBox5.Items.AddRange(accents.Keys.ToArray());

            var _fM = new FileManager();

            string json = _fM._ReadFileText(_fM._GetPathToFile("browser_theme.json"));

            ThemeManager themeManager;

            if (json == string.Empty)
            {
                themeManager = JsonSerializer.Deserialize<ThemeManager>(_fM._GetPathToFile("browser_theme.json", "simple_settings"));
            }
            else
            {
                themeManager = JsonSerializer.Deserialize<ThemeManager>(json);
            }
                        
            materialComboBox1.Text = themeManager.ThemeName.ToString();
            materialComboBox2.Text = themeManager.Primaries["primary"].ToString();
            materialComboBox3.Text = themeManager.Primaries["darkprimary"].ToString();
            materialComboBox4.Text = themeManager.Primaries["lightprimary"].ToString();
            materialComboBox5.Text = themeManager.Accent.ToString();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {            
            Dictionary<string, Primary> data = new Dictionary<string, Primary> { { "primary", colors[materialComboBox2.Text] }, { "darkprimary", colors[materialComboBox3.Text] }, { "lightprimary", colors[materialComboBox4.Text] } };

            Accent saveaccent = accents[materialComboBox5.Text];

            MaterialSkinManager.Themes theme;
            if (materialComboBox1.Text == "Dark")
            {
                theme = MaterialSkinManager.Themes.DARK;
            }
            else
            {
                theme = MaterialSkinManager.Themes.LIGHT;
            }
            
            ThemeManager themeManager = new ThemeManager(data, theme, saveaccent);
            string saveJson = JsonSerializer.Serialize(themeManager);
            var fileManager = new FileManager();
            if (fileManager._IsFileExist(fileManager._GetPathToFile("browser_theme.json")))
            {
                fileManager._DeleteFileText(fileManager._GetPathToFile("browser_theme.json"));
            }
            fileManager._WriteFile(saveJson, fileManager._GetPathToFile("browser_theme.json"));
        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }                
    }
}
