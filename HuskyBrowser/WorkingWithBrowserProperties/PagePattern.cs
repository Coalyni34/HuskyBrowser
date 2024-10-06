using CefSharp.WinForms;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuskyBrowser.WorkingWithBrowserProperties
{
    public class PagePattern
    {
        private static string Enabled_Search_System;
        public class SettingsPagePattern : PagePattern
        {
            public TabPage new_TapPage = new TabPage() 
            {
                Text = "Settings"                                
            };

            public MaterialButton closeSettings_Button = new MaterialButton() 
            {
                Text = "",
                Size = new Size(40, 36),
                Location = new Point(10, 10),
                DrawShadows = false,
                AutoSize = false,
            };
            public SettingsPagePattern(Image icon_ExitButton)
            {
                closeSettings_Button.Icon = icon_ExitButton;  
            }
        }
        public class SimplePagePattern : PagePattern
        {
            List<Image> images_buttons = new List<Image>();

            public List<MaterialButton> simplepagebuttons = new List<MaterialButton>();

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
            public MaterialButton settings_button = new MaterialButton()
            {
                Text = "",
                Size = new Size(40, 36),
                Location = new Point(1500, 10),
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
            public SimplePagePattern(List<Image> icons)
            {
                var _fM = new FileManager();

                Enabled_Search_System = _fM._ReadFileText(_fM._GetPathToFile("enabled_search_engine.txt"));

                cwb.Load(Enabled_Search_System);

                simplepagebuttons.Add(forward_button);
                simplepagebuttons.Add(back_button);
                simplepagebuttons.Add(refresh_button);
                simplepagebuttons.Add(createtab_button);
                simplepagebuttons.Add(closeTab_button);
                simplepagebuttons.Add(settings_button);

                for (short i = 0; i < simplepagebuttons.Count; i++)
                {
                    simplepagebuttons[i].Icon = icons[i];
                }                
            }
        }        
    }
}
