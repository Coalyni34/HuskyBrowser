using CefSharp;
using CefSharp.WinForms;
using HuskyBrowser.WorkingWithBrowserProperties;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuskyBrowser
{
    public partial class Form1 : MaterialForm
    {
        public static string Enabled_Search_Engine;
        public Form1()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo600, Primary.Indigo600, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            Browser_Initialize();
        }
        private void Browser_Initialize()
        {
            var _file_Reader = new FileManager();
            string[] search_engines = new string[_file_Reader._ReadFileLines(_file_Reader._GetPathToFile("search_engine.txt")).Count];
            for (short i = 0; i < search_engines.Length; i++)
            {
                search_engines[i] = _file_Reader._ReadFileLines(_file_Reader._GetPathToFile("search_engine.txt"))[i];
            }
            Enabled_Search_Engine = search_engines[0];

            Controls_Initialize();
        }
        private void Controls_Initialize() 
        {
            try
            {
                List<Image> icons = new List<Image>();
                for (short i = 0; i < imageList1.Images.Count; i++)
                {
                    icons.Add(imageList1.Images[i]);
                }

                PagePattern.SimplePagePattern simplepage_pattern = new PagePattern.SimplePagePattern(icons);

                icons.Clear();

                simplepage_pattern.simplepagebuttons[0].Click += OnGoForward_Click;
                simplepage_pattern.simplepagebuttons[1].Click += OnGoBack_Click;
                simplepage_pattern.simplepagebuttons[2].Click += OnRefresh_Click;
                simplepage_pattern.simplepagebuttons[3].Click += OnCreateSimplePage_Click;
                simplepage_pattern.simplepagebuttons[4].Click += OnClose_Click;
                simplepage_pattern.simplepagebuttons[5].Click += OnCreateSettingsPage_Click;
                simplepage_pattern.adress_line.KeyDown += OnLoad_Event;
                                             
                foreach(var button in simplepage_pattern.simplepagebuttons) 
                {
                    simplepage_pattern.panel_2.Controls.Add(button);
                }                                

                simplepage_pattern.panel_2.Controls.Add(simplepage_pattern.adress_line);
                simplepage_pattern.panel_1.Controls.Add(simplepage_pattern.cwb);

                simplepage_pattern.new_TapPage.Controls.Add(simplepage_pattern.panel_1);
                simplepage_pattern.new_TapPage.Controls.Add(simplepage_pattern.panel_2);

                materialTabControl1.TabPages.Add(simplepage_pattern.new_TapPage);
                materialTabControl1.SelectTab(simplepage_pattern.new_TapPage);
            }
            catch (Exception ex)
            {
                var file_Manager = new FileManager();
                file_Manager._WriteFile(ex.Message, file_Manager._GetPathToFile("errors_config.txt"));
            }
        }                

        private void OnGoForward_Click(object sender, EventArgs e)
        {
            TabPage selectedTab = materialTabControl1.SelectedTab;

            var panel_ = selectedTab.Controls[0] as Panel;

            var cwb = panel_.Controls[0] as ChromiumWebBrowser;

            if (cwb.CanGoForward)
            {
                cwb.Forward();
            }
            else
            {

            }
        }
        private void OnGoBack_Click(object sender, EventArgs e)
        {
            TabPage selectedTab = materialTabControl1.SelectedTab;

            var panel_ = selectedTab.Controls[0] as Panel;

            var cwb = panel_.Controls[0] as ChromiumWebBrowser;

            if (cwb.CanGoBack)
            {
                cwb.Back();
            }
            else
            {

            }
        }
        private void OnRefresh_Click(object sender, EventArgs e)
        {
            TabPage selectedTab = materialTabControl1.SelectedTab;

            var panel_ = selectedTab.Controls[0] as Panel;

            var cwb = panel_.Controls[0] as ChromiumWebBrowser;

            cwb.Refresh();
        }
        private void OnClose_Click(object sender, EventArgs e)
        {
            if (materialTabControl1.TabCount > 1)
            {
                materialTabControl1.TabPages.Remove(materialTabControl1.SelectedTab);
            }
            else if (materialTabControl1.TabCount == 1)
            {
                Application.Exit();
            }
        }
        private void OnCreateSimplePage_Click(object sender, EventArgs e)
        {
            try
            {
                List<Image> icons = new List<Image>();
                for (short i = 0; i < imageList1.Images.Count; i++)
                {
                    icons.Add(imageList1.Images[i]);
                }

                PagePattern.SimplePagePattern simplePage_Pattern = new PagePattern.SimplePagePattern(icons);

                icons.Clear();

                simplePage_Pattern.simplepagebuttons[0].Click += OnGoForward_Click;
                simplePage_Pattern.simplepagebuttons[1].Click += OnGoBack_Click;
                simplePage_Pattern.simplepagebuttons[2].Click += OnRefresh_Click;
                simplePage_Pattern.simplepagebuttons[3].Click += OnCreateSimplePage_Click;
                simplePage_Pattern.simplepagebuttons[4].Click += OnClose_Click;
                simplePage_Pattern.simplepagebuttons[5].Click += OnCreateSettingsPage_Click;
                simplePage_Pattern.adress_line.KeyDown += OnLoad_Event;

                foreach (var button in simplePage_Pattern.simplepagebuttons)
                {
                    simplePage_Pattern.panel_2.Controls.Add(button);
                }

                simplePage_Pattern.panel_2.Controls.Add(simplePage_Pattern.adress_line);
                simplePage_Pattern.panel_1.Controls.Add(simplePage_Pattern.cwb);

                simplePage_Pattern.new_TapPage.Controls.Add(simplePage_Pattern.panel_1);
                simplePage_Pattern.new_TapPage.Controls.Add(simplePage_Pattern.panel_2);

                materialTabControl1.TabPages.Add(simplePage_Pattern.new_TapPage);
                materialTabControl1.SelectTab(simplePage_Pattern.new_TapPage);
            }
            catch (Exception ex)
            {
                var file_Manager = new FileManager();
                file_Manager._WriteFile(ex.Message, file_Manager._GetPathToFile("errors_config.txt"));
            }
        }
        private void OnCreateSettingsPage_Click(object sender, EventArgs e)
        {
            PagePattern.SettingsPagePattern settingsPage_Pattern = new PagePattern.SettingsPagePattern(imageList1.Images[6]);

            settingsPage_Pattern.closeSettings_Button.Click += OnClose_Click;            

            var newTab = settingsPage_Pattern.new_TapPage;
            newTab.Controls.Add(settingsPage_Pattern.closeSettings_Button);

            materialTabControl1.TabPages.Add(newTab);
            materialTabControl1.SelectTab(newTab);
        }
        private void OnLoad_Event(object sender, KeyEventArgs e)
        {
            TabPage selectedTab = materialTabControl1.SelectedTab;

            var panel_1 = selectedTab.Controls[0] as Panel;

            var panel_2 = selectedTab.Controls[1] as Panel;

            var adress_line = panel_2.Controls[5] as MaterialTextBox;

            var cwb = panel_1.Controls[0] as ChromiumWebBrowser;

            string input = adress_line.Text;

            if ((e.KeyCode == Keys.Enter))
            {
                e.SuppressKeyPress = true;
                if (IsValidUrl(input))
                {
                    cwb.Load(input.StartsWith("http://") || input.StartsWith("https://") ? input : "http://" + input);
                }
                else
                {
                    cwb.Load(Enabled_Search_Engine + input);
                }
            }
        }
        private bool IsValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out _) || url.Contains(".");
        }
    }
}
