using CefSharp;
using CefSharp.DevTools.Autofill;
using CefSharp.WinForms;
using HuskyBrowser.WorkingWithBrowserProperties;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HuskyBrowser.WorkingWithBrowserProperties.PagePattern;

namespace HuskyBrowser
{
    public partial class Form1 : MaterialForm
    {
        public static string Enabled_Search_Engine;
        private string[] title_and_adress = new string[2];
        public Form1()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo600, Primary.Indigo600, Primary.BlueGrey500, Accent.Cyan100, TextShade.WHITE);

            Browser_Initialize();
        }
        private void Browser_Initialize()
        {
            var _fM = new FileManager();
            Enabled_Search_Engine = _fM._ReadFileText(_fM._GetPathToFile("enabled_search_engine.txt", "search_engines"));

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
                
                SimplePagePattern simplepage_pattern = new SimplePagePattern(icons, Enabled_Search_Engine, materialTabControl1);

                icons.Clear();

                simplepage_pattern.simplePageButtons[0].Click += OnGoForward_Click;
                simplepage_pattern.simplePageButtons[1].Click += OnGoBack_Click;
                simplepage_pattern.simplePageButtons[2].Click += OnRefresh_Click;
                simplepage_pattern.simplePageButtons[3].Click += OnCreateSimplePage_Click;
                simplepage_pattern.simplePageButtons[4].Click += OnClose_Click;
                simplepage_pattern.simplePageButtons[5].Click += OnCreateSettingsPage_Click;
                simplepage_pattern.adress_line.KeyDown += OnLoad_Event;
                simplepage_pattern.cwb.AddressChanged += OnCwb_AdressChanged;
                simplepage_pattern.cwb.TitleChanged += OnCwb_TitleChanged;                                                      
            }
            catch (Exception ex)
            {
                var file_Manager = new FileManager();
                file_Manager._WriteFile(ex.Message, file_Manager._GetPathToFile("husky_errors_config.txt"));
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
            Controls_Initialize();
        }
        private void OnCreateSettingsPage_Click(object sender, EventArgs e)
        {
            List<Image> icons = new List<Image>();
            for (short i = 0; i < materialTabControl1.ImageList.Images.Count; i++)
            {
                icons.Add(materialTabControl1.ImageList.Images[i]);
            }

            SettingsPagePattern settingsPage_Pattern = new SettingsPagePattern(icons, materialTabControl1);
                       
            settingsPage_Pattern.closeSettings_Button.Click += OnClose_Click;            
        }        
        private void OnLoad_Event(object sender, KeyEventArgs e)
        {
            try
            {
                materialTabControl1.Invoke((MethodInvoker)delegate
                {
                    TabPage selectedTab = materialTabControl1.SelectedTab;

                    var panel_1 = selectedTab.Controls[0] as Panel;
                    var panel_2 = selectedTab.Controls[1] as Panel;

                    var adress_line = panel_2.Controls[7] as MaterialTextBox;

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
                            string result = Enabled_Search_Engine + input;
                            cwb.Load(result);
                        }
                    }
                });
            }     
            catch(Exception ex)
            {
                var _fM = new FileManager();
                _fM._WriteFile(ex.Message, _fM._GetPathToFile("husky_errors_config.txt"));
            }
        }
        private void OnCwb_AdressChanged(object sender, AddressChangedEventArgs e)
        {
            try
            {
                materialTabControl1.Invoke((MethodInvoker)delegate
                {
                    TabPage selectedTab = materialTabControl1.SelectedTab;

                    var panel_2 = selectedTab.Controls[1] as Panel;

                    var adress_line = panel_2.Controls[7] as MaterialTextBox;

                    string _address = e.Address;

                    if (adress_line.Text != Enabled_Search_Engine)
                    {
                        adress_line.Text = _address;                                               

                        title_and_adress[1] = _address;
                    }
                    else
                    {
                        adress_line.Text = "";
                    }
                });                
            }
            catch (Exception ex) 
            {
                var _fM = new FileManager();

                _fM._WriteFile(ex.Message, _fM._GetPathToFile("husky_errors_config.txt"));
            }
        }       
        private void OnCwb_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            try
            {
                materialTabControl1.Invoke((MethodInvoker)delegate
                {
                    materialTabControl1.SelectedTab.Text = e.Title;

                    title_and_adress[0] = e.Title;

                    SaveHistory(title_and_adress[0], title_and_adress[1]);
                });
            }
            catch (Exception ex)
            {
                var _fM = new FileManager();
                _fM._WriteFile(ex.Message, _fM._GetPathToFile("husky_errors_config.txt"));                
            }
        }        
        private void SaveHistory(string title, string adress)
        {
            var _fM = new FileManager();

            string page = $"{DateTime.Now}: {title} {adress}";

            var ListOfPages = new List<string>() { page };

            _fM._WriteFile(ListOfPages, _fM._GetPathToFile("history.txt", "histоry"));

            ListOfPages.Clear();
        }
        private bool IsValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out _) || url.Contains(".");
        }
    }
}
