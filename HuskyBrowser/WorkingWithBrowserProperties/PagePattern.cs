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
using Newtonsoft.Json;
using static HuskyBrowser.WorkingWithBrowserProperties.PagePattern.SettingsPagePattern;
using static HuskyBrowser.WorkingWithBrowserProperties.PagePattern;

namespace HuskyBrowser.WorkingWithBrowserProperties
{
    public class PagePattern
    {        
        public class SettingsPagePattern : PagePattern
        {           
            public TabPage new_TapPage = new TabPage()
            {
                Text = "Settings",
            };
            public MaterialButton closeSettings_Button = new MaterialButton() 
            {
                Text = "",
                Size = new Size(40, 36),
                Location = new Point(10, 10),
                DrawShadows = false,
                AutoSize = false,
            };
            public MaterialLabel choosing_SearchEngine_Text = new MaterialLabel()
            {
                Text = "Search Engine:",                
                Size = new Size(110, 30),
                Location = new Point(10, 60),                
                AutoSize = false,
            };
            public MaterialComboBox searchEngine_ComboBox = new MaterialComboBox()
            {
                Size = new Size(180, 50),                
                Location = new Point(130, 45),
                AutoSize = false,
            };            
            public SettingsPagePattern(List<Image> icons, MaterialTabControl tabControl)
            {
                closeSettings_Button.Icon = icons[0];
                                
                new_TapPage.Controls.Add(closeSettings_Button);
                new_TapPage.Controls.Add(choosing_SearchEngine_Text);
                new_TapPage.Controls.Add(searchEngine_ComboBox);                               

                tabControl.TabPages.Add(new_TapPage);
                tabControl.SelectTab(new_TapPage);
            }            
        }
        public class SimplePagePattern : PagePattern
        {
            List<Image> images_buttons = new List<Image>();

            public List<MaterialButton> simplePageButtons = new List<MaterialButton>();

            public TabPage new_TapPage = new TabPage();

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
                MinimumSize = new Size(197, 50),
                MaximumSize = new Size(1250, 50),
                Location = new Point(235, 10),
            };
            public ChromiumWebBrowser cwb = new ChromiumWebBrowser()
            {
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
            };            
            public SimplePagePattern(List<Image> icons, string Enabled_Search_Engine, MaterialTabControl tabControl)
            {               
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
