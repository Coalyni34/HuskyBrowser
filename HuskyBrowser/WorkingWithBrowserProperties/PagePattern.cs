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

namespace HuskyBrowser.WorkingWithBrowserProperties
{
    public class PagePattern
    {
        static MaterialTabControl tabControl { get; set; }        
        public class SettingsPagePattern : PagePattern
        {           
            private TabPage new_TapPage = new TabPage()
            {
                Text = "Settings",
            };
            private MaterialButton SaveSettings_Button = new MaterialButton() 
            {
                Text = "",
                Size = new Size(40, 36),
                Location = new Point(10, 10),
                DrawShadows = false,
                AutoSize = false,
            };
            private MaterialButton Closing_Button = new MaterialButton()
            {
                Text = "",
                Size = new Size(40, 36),
                Location = new Point(50, 10),
                DrawShadows = false,
                AutoSize = false,
            };
            public MaterialLabel Choosing_SearchEngine_Text = new MaterialLabel()
            {
                Text = "Search Engine:",                
                Size = new Size(110, 30),
                Location = new Point(10, 60),                
                AutoSize = false,
            };
            public MaterialComboBox SearchEngine_ComboBox = new MaterialComboBox()
            {
                Text = "DuckDuckGo",
                Size = new Size(180, 50),                
                Location = new Point(130, 45),
                AutoSize = false,
            };   
            public SettingsPagePattern(MaterialTabControl materialTabControl)
            {                                
                new_TapPage.Controls.Add(SaveSettings_Button);
                new_TapPage.Controls.Add(Choosing_SearchEngine_Text);
                new_TapPage.Controls.Add(SearchEngine_ComboBox);
                new_TapPage.Controls.Add(SaveSettings_Button);

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
                Settings settings = new Settings()
                {
                    Search_Engine_Key = SearchEngine_ComboBox.Text,
                };
            }
        }
        public class SimplePagePattern : PagePattern
        {
            List<Image> images_buttons = new List<Image>();

            public List<MaterialButton> simplePageButtons = new List<MaterialButton>();

            private TabPage new_TapPage = new TabPage();

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

                tabControl.TabPages.Add(new_TapPage);
                tabControl.SelectTab(new_TapPage);
            }           
        }        
    }
}
