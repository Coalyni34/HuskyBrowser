using CefSharp;
using CefSharp.WinForms;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HuskyBrowser.WorkingWithBrowserProperties.PagePattern.SettingsPagePattern;
using static HuskyBrowser.WorkingWithBrowserProperties.PagePattern;
using System.Text.Json;
using static System.Net.WebRequestMethods;
using HuskyBrowser.Properties;
using System.Text.Json.Serialization;
using static HuskyBrowser.WorkingWithBrowserProperties.FileManager;

namespace HuskyBrowser.WorkingWithBrowserProperties
{
    public class PagePattern
    {
        static MaterialTabControl tabControl { get; set; }
        static Color Page_BackColor { get; set; } = Color.FromArgb(255, 23, 25, 30);
        public class SettingsPagePattern : PagePattern
        {           
            private TabPage new_TapPage = new TabPage()
            {
                Text = "Settings",
                BackColor = Page_BackColor
            };
            private MaterialButton SaveSettings_Button = new MaterialButton() 
            {
                Text = "Save Settings",
                Size = new Size(70, 40),
                Location = new Point(90, 10),
                DrawShadows = false,
                AutoSize = false,
            };
            private MaterialButton Closing_Button = new MaterialButton()
            {
                Text = "Close Page",
                Size = new Size(70, 40),
                Location = new Point(10, 10),
                DrawShadows = false,
                AutoSize = false,
            };
            public MaterialLabel Choosing_SearchEngine_Text = new MaterialLabel()
            {
                Text = "Search Engine:",                
                Size = new Size(110, 30),
                Location = new Point(20, 130),                
                AutoSize = false,
            };
            public MaterialComboBox SearchEngine_ComboBox = new MaterialComboBox()
            {
                Text = "DuckDuckGo",
                Size = new Size(180, 50),                
                Location = new Point(130, 115),
                AutoSize = false,
            };
            public MaterialSwitch SaveHistory_Switch = new MaterialSwitch()
            {
                Text = "Save history",
                Size = new Size(180, 50),
                Location = new Point(0, 60),
                AutoSize = false,               
            };
            private List<string> Engines_Keys = new List<string>() { "DuckDuckGo", "Google", "Bing", "Brave" };
            private Dictionary<string, string> Search_Engines = new Dictionary<string, string>() 
            {
                { "DuckDuckGo", "https://start.duckduckgo.com/" },
                { "Google", "https://www.google.com/" },
                { "Bing", "https://www.bing.com/" },
                { "Brave", "https://search.brave.com/" }
            };
            public SettingsPagePattern(MaterialTabControl materialTabControl)
            {                               
                new_TapPage.Controls.Add(Choosing_SearchEngine_Text);
                new_TapPage.Controls.Add(SearchEngine_ComboBox);
                new_TapPage.Controls.Add(SaveSettings_Button);
                new_TapPage.Controls.Add(Closing_Button);
                new_TapPage.Controls.Add(SaveHistory_Switch);

                foreach (var engine in Engines_Keys) 
                {
                    SearchEngine_ComboBox.Items.Add(engine);
                }

                var _fM = new FileManager();

                string json = _fM._ReadFileText(_fM._GetPathToFile("browser_settings.json"));

                Settings settings = JsonSerializer.Deserialize<Settings>(json);

                SearchEngine_ComboBox.SelectedItem = settings.Search_Engine_Name;
                SaveHistory_Switch.Checked = settings.Save_History;

                SaveSettings_Button.Click += OnSave_Click;
                Closing_Button.Click += OnClose_Click;                

                tabControl.TabPages.Add(new_TapPage);
                tabControl.SelectTab(new_TapPage);
            }
            private void OnClose_Click(object sender, EventArgs e)
            {
                if (tabControl.TabCount > 1)
                {
                    tabControl.TabPages.Remove(tabControl.SelectedTab);
                }
                else if (tabControl.TabCount == 1)
                {
                    Application.Exit();
                }
            }
            private void OnSave_Click(object sender, EventArgs e)
            {
                string selected_engine = SearchEngine_ComboBox.Text;

                bool DoSaveHistory = SaveHistory_Switch.Checked;

                Settings settings = new Settings(Search_Engines[selected_engine], Search_Engines[selected_engine], DoSaveHistory, selected_engine);
                
                string jsonSettings = JsonSerializer.Serialize(settings);

                var _fM = new FileManager();
                if (_fM._IsFileExist(_fM._GetPathToFile("browser_settings.json")) == false) 
                {
                    _fM._WriteFile(jsonSettings, _fM._GetPathToFile("browser_settings.json"));
                }
                else 
                {
                    _fM._DeleteFileText(_fM._GetPathToFile("browser_settings.json"));
                    _fM._WriteFile(jsonSettings, _fM._GetPathToFile("browser_settings.json"));
                }              

                Application.Restart();
            }            
        }
        public class SimplePagePattern : PagePattern
        {
            List<Image> images_buttons = new List<Image>();

            public List<MaterialButton> simplePageButtons = new List<MaterialButton>();

            private TabPage new_TapPage = new TabPage()
            {
                BackColor = Page_BackColor
            };

            public Panel panel_1 = new Panel()
            {
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
                Location = new Point(0, 59),
                Size = new Size(786, 350)
            };
            public Panel panel_2 = new Panel()
            {
                Location = new Point(0, 0),
                Size = new Size(786, 50),
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };
            private MaterialButton back_button = new MaterialButton()
            {
                Text = "",
                Size = new Size(40, 36),
                Location = new Point(10, 10),
                DrawShadows = false,
                AutoSize = false,                
            };
            private MaterialButton forward_button = new MaterialButton()
            {
                Text = "",
                Size = new Size(40, 36),
                Location = new Point(55, 10),
                DrawShadows = false,
                AutoSize = false,
            };
            private MaterialButton refresh_button = new MaterialButton()
            {
                Text = "",
                Size = new Size(40, 36),
                Location = new Point(100, 10),
                DrawShadows = false,
                AutoSize = false,
            };
            private MaterialButton createtab_button = new MaterialButton()
            {
                Text = "",
                Size = new Size(40, 36),
                Location = new Point(145, 10),
                DrawShadows = false,
                AutoSize = false,
            };
            private MaterialButton closeTab_button = new MaterialButton()
            {
                Text = "",
                Size = new Size(40, 36),
                Location = new Point(190, 10),
                DrawShadows = false,
                AutoSize = false,
            };
            private MaterialButton settings_button = new MaterialButton()
            {
                Text = "",
                Size = new Size(40, 36),
                Location = new Point(1500, 10),
                DrawShadows = false,
                AutoSize = false,
            };
            private MaterialButton download_button = new MaterialButton()
            {
                Text = "",
                Size = new Size(40, 36),
                Location = new Point(1550, 10),
                DrawShadows = false,
                AutoSize = false,
            };
            public MaterialTextBox adress_line = new MaterialTextBox()
            {               
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                MaximumSize = new Size(1250, 50),
                Location = new Point(235, 10),
            };
            public ChromiumWebBrowser cwb = new ChromiumWebBrowser()
            {
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
            };
            public SimplePagePattern(List<Image> icons, string Enabled_Search_Engine, MaterialTabControl materialTabControl)
            {
                try
                {
                    tabControl = materialTabControl;

                    cwb.Load(Enabled_Search_Engine);

                    simplePageButtons.Add(forward_button);
                    simplePageButtons.Add(back_button);
                    simplePageButtons.Add(refresh_button);
                    simplePageButtons.Add(createtab_button);
                    simplePageButtons.Add(closeTab_button);
                    simplePageButtons.Add(settings_button);
                    simplePageButtons.Add(download_button);

                    for (short i = 0; i < simplePageButtons.Count; i++)
                    {
                        simplePageButtons[i].Icon = icons[i];
                    }

                    foreach (var button in simplePageButtons)
                    {
                        panel_2.Controls.Add(button);
                    }
                    panel_2.Controls.Add(adress_line);
                    panel_1.Controls.Add(cwb);

                    new_TapPage.Controls.Add(panel_1);
                    new_TapPage.Controls.Add(panel_2);

                    cwb.FrameLoadEnd += (sender, args) =>
                    {
                        SetTheme("dark");
                    };

                    tabControl.TabPages.Add(new_TapPage);
                    tabControl.SelectTab(new_TapPage);
                }
                catch (Exception ex) 
                {
                    Error_Logger error_Logger = new Error_Logger();
                    error_Logger.Log_Errors(ex.Message);
                }
            }
            private void SetTheme(string theme)
            {
                string js = $"document.documentElement.setAttribute('data-theme', '{theme}');";
                cwb.ExecuteScriptAsync(js);
            }
        }        
    }
}
