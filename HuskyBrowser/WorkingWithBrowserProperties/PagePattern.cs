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

        List<Image> images_buttons = new List<Image>();

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
        public MaterialButton back_button = new MaterialButton()
        {
            Text = "",
            Size = new Size(40, 36),
            Location = new Point(10, 10),
            DrawShadows = false,
            AutoSize = false,
        };
        public MaterialButton forward_button = new MaterialButton()
        {
            Text = "",
            Size = new Size(40, 36),
            Location = new Point(55, 10),
            DrawShadows = false,
            AutoSize = false,
        };
        public MaterialButton refresh_button = new MaterialButton()
        {
            Text = "",
            Size = new Size(40, 36),
            Location = new Point(100, 10),
            DrawShadows = false,
            AutoSize = false,
        };
        public MaterialButton createtab_button = new MaterialButton()
        {
            Text = "",
            Size = new Size(40, 36),
            Location = new Point(145, 10),
            DrawShadows = false,
            AutoSize = false,
        };
        public MaterialButton closetab_button = new MaterialButton()
        {
            Text = "",
            Size = new Size(40, 36),
            Location = new Point(190, 10),
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
        public PagePattern(List<Image> icons)
        {
            var _fM = new FileManager();

            Enabled_Search_System = _fM._ReadFileText(_fM._GetPathToFile("enabled_search_engine.txt"));

            cwb.Load(Enabled_Search_System);

            back_button.Icon = icons[1];
            forward_button.Icon = icons[0];
            refresh_button.Icon = icons[2];
            closetab_button.Icon = icons[4];
            createtab_button.Icon = icons[3];
        }
    }
}
