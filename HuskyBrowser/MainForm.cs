﻿using CefSharp;
using CefSharp.WinForms;
using HuskyBrowser.HuskyBrowserManagement.BrowserManagement.SettingsManagement;
using HuskyBrowser.HuskyBrowserManagement.BrowserManagement.ThemesManagement;
using HuskyBrowser.WorkingWithBrowserProperties;
using HuskyBrowser.WorkingWithBrowserProperties.BookMarksManager;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using static HuskyBrowser.WorkingWithBrowserProperties.FileManager;
using static HuskyBrowser.WorkingWithBrowserProperties.PagePattern;
using Settings = HuskyBrowser.WorkingWithBrowserProperties.Settings;

namespace HuskyBrowser
{
    public partial class MainForm : MaterialForm
    {
        public static string Enabled_Search_Engine;
        public string[] title_and_adress = new string[2];
        public static MainForm thisform;
        public static Color _BackColor { get; set; }
        public static Color _ForeColor { get; set; } = Color.White;
        public MainForm()
        {
            InitializeComponent();
            SettingsSetup settingsSetup = new SettingsSetup();

            thisform = this;

            ForeColor = _ForeColor;
                        
            FileManager fileManager = new FileManager();

            string json = fileManager._ReadFileText(fileManager._GetPathToFile("browser_theme.json"));

            var colorsettings = JsonSerializer.Deserialize<ThemeManager>(json);

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = colorsettings.ThemeName;
            if (materialSkinManager.Theme == MaterialSkinManager.Themes.DARK)
            {
                materialSkinManager.ColorScheme = new ColorScheme(colorsettings.Primaries["primary"], colorsettings.Primaries["darkprimary"], colorsettings.Primaries["lightprimary"], colorsettings.Accent, TextShade.WHITE);
                _BackColor = Color.FromArgb(50, 50, 50);
            }
            else
            {
                materialSkinManager.ColorScheme = new ColorScheme(colorsettings.Primaries["primary"], colorsettings.Primaries["darkprimary"], colorsettings.Primaries["lightprimary"], colorsettings.Accent, TextShade.WHITE);
                _BackColor = Color.FromArgb(255, 255, 255);
            }

            IntializationItems();
        }
        private void IntializationItems()
        {
            try
            {
                var _fM = new FileManager();

                string json = _fM._ReadFileText(_fM._GetPathToFile("browser_settings.json"));

                Settings settings;
                if (json == string.Empty)
                {
                    settings = JsonSerializer.Deserialize<Settings>(_fM._GetPathToFile("browser_settings.json", "simple_settings"));
                }
                else
                {
                    settings = JsonSerializer.Deserialize<Settings>(json);
                }

                Enabled_Search_Engine = settings.Enabled_Search_Engine;

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
                switch (settings.TypeOfStartPage)
                {
                    case "Simple page":
                        SimplePagePattern simplepage_pattern = new SimplePagePattern(icons, markbutton_icons, materialTabControl1, settings.Start_Page, Text);
                        break;
                    case "Empty page":
                        CustomPagePattern customPagePattern = new CustomPagePattern(icons, markbutton_icons, materialTabControl1);
                        break;
                }
                icons.Clear();
                markbutton_icons.Clear();
            }
            catch (Exception ex)
            {
                ErrorLogger error_Logger = new ErrorLogger();
                error_Logger.Log_Errors(ex.Message);
            }
        }        

        public void SetClicks(SimplePagePattern simplepage_pattern)
        {
            simplepage_pattern.simplePageButtons[0].Click += OnGoForward_Click;
            simplepage_pattern.simplePageButtons[1].Click += OnGoBack_Click;
            simplepage_pattern.simplePageButtons[2].Click += OnRefresh_Click;
            simplepage_pattern.simplePageButtons[3].Click += OnCreateSimplePage_Click;
            simplepage_pattern.simplePageButtons[4].Click += OnClose_Click;
            simplepage_pattern.simplePageButtons[5].Click += OnCreateSettingsPage_Click;
            simplepage_pattern.simplePageButtons[6].Click += OnShowDownloadManager;
            simplepage_pattern.savemark_button.MouseClick += Savemark_button_Click;
            simplepage_pattern.adress_line.KeyDown += OnLoad_Event;
            simplepage_pattern.cwb.AddressChanged += OnCwb_AdressChanged;
            simplepage_pattern.cwb.TitleChanged += OnCwb_TitleChanged;            
        }
        public void SetClicks(CustomPagePattern customPagePattern)
        {
            customPagePattern.simplePageButtons[0].Click += OnGoForward_Click;
            customPagePattern.simplePageButtons[1].Click += OnGoBack_Click;
            customPagePattern.simplePageButtons[2].Click += OnRefresh_Click;
            customPagePattern.simplePageButtons[3].Click += OnCreateSimplePage_Click;
            customPagePattern.simplePageButtons[4].Click += OnClose_Click;
            customPagePattern.simplePageButtons[5].Click += OnCreateSettingsPage_Click;
            customPagePattern.simplePageButtons[6].Click += OnShowDownloadManager;
            customPagePattern.savemark_button.MouseClick += Savemark_button_Click;
            customPagePattern.adress_line.KeyDown += OnCustomLoad_Event;
            customPagePattern.cwb.AddressChanged += OnCwb_AdressChanged;
            customPagePattern.cwb.TitleChanged += OnCwb_TitleChanged;
        }

        private void OnCustomLoad_Event(object sender, KeyEventArgs e)
        {
            try
            {
                materialTabControl1.Invoke((MethodInvoker)delegate
                {
                    TabPage selectedTab = materialTabControl1.SelectedTab;

                    var panel_1 = selectedTab.Controls[0] as Panel;
                    var panel_2 = selectedTab.Controls[1] as Panel;

                    var adress_line = panel_2.Controls[8] as MaterialTextBox;

                    var cwb = panel_1.Controls[0] as ChromiumWebBrowser;

                    string input = adress_line.Text;

                    if ((e.KeyCode == Keys.Enter))
                    {
                        cwb.Visible = true;
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
            catch (Exception ex)
            {
                ErrorLogger error_Logger = new ErrorLogger();
                error_Logger.Log_Errors(ex.Message);
            }
        }

        public void OnShowDownloadManager(object sender, EventArgs e)
        {
            if (!materialTabControl1.TabPages.ContainsKey("Downloads")) 
            {
                DownloadPagePattern downloadPagePattern = new DownloadPagePattern();
            }
            else 
            {
                materialTabControl1.SelectTab("Downloads");
            }
        }

        public void OnGoForward_Click(object sender, EventArgs e)
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
        public void OnGoBack_Click(object sender, EventArgs e)
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
        public void OnRefresh_Click(object sender, EventArgs e)
        {
            TabPage selectedTab = materialTabControl1.SelectedTab;

            var panel_1 = selectedTab.Controls[0] as Panel;
            var panel_2 = selectedTab.Controls[1] as Panel;

            var cwb = panel_1.Controls[0] as ChromiumWebBrowser;

            cwb.Load(cwb.Address);
        }
        public void OnClose_Click(object sender, EventArgs e)
        {
            if (materialTabControl1.TabCount > 1)
            {
                int selectTabIndex = materialTabControl1.SelectedIndex;
                materialTabControl1.TabPages.Remove(materialTabControl1.SelectedTab);
                Text = materialTabControl1.SelectedTab.Text;
            }
            else if (materialTabControl1.TabCount == 1)
            {
                Application.Exit();
            }
        }
        public void OnCreateSimplePage_Click(object sender, EventArgs e)
        {
            var _fM = new FileManager();

            string json = _fM._ReadFileText(_fM._GetPathToFile("browser_settings.json"));

            Settings settings;
            if (json == string.Empty)
            {
                settings = JsonSerializer.Deserialize<Settings>(_fM._GetPathToFile("browser_settings.json", "simple_settings"));
            }
            else
            {
                settings = JsonSerializer.Deserialize<Settings>(json);
            }
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
            switch (settings.TypeOfStartPage) 
            {
                case "Simple page":                   
                    SimplePagePattern simplepage_pattern = new SimplePagePattern(icons, markbutton_icons, materialTabControl1, settings.Start_Page, Text);
                    break;
                case "Empty page":
                    CustomPagePattern customPagePattern = new CustomPagePattern(icons, markbutton_icons, materialTabControl1);
                    break;
            }            
        }
        public void OnCreateSettingsPage_Click(object sender, EventArgs e)
        {
            List<Image> icons = new List<Image>();
            for (short i = 0; i < imageList3.Images.Count; i++)
            {
                icons.Add(imageList3.Images[i]);
            }

            if (!materialTabControl1.TabPages.ContainsKey("Settings"))
            {
                SettingsPagePattern settingsPage_Pattern = new SettingsPagePattern(materialTabControl1, icons.ToArray());
                Text = "Settings";
            }
            else
            {
                materialTabControl1.SelectTab("Settings");
                Text = "Settings";
            }            
        }
        public void OnLoad_Event(object sender, KeyEventArgs e)
        {
            try
            {
                materialTabControl1.Invoke((MethodInvoker)delegate
                {
                    TabPage selectedTab = materialTabControl1.SelectedTab;

                    var panel_1 = selectedTab.Controls[0] as Panel;
                    var panel_2 = selectedTab.Controls[1] as Panel;

                    var adress_line = panel_2.Controls[8] as MaterialTextBox;

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
            catch (Exception ex)
            {
                ErrorLogger error_Logger = new ErrorLogger();
                error_Logger.Log_Errors(ex.Message);
            }
        }
        public void OnCwb_AdressChanged(object sender, AddressChangedEventArgs e)
        {
            try
            {
                materialTabControl1.Invoke((MethodInvoker)delegate
                {
                    TabPage selectedTab = materialTabControl1.SelectedTab;

                    var panel_2 = selectedTab.Controls[1] as Panel;

                    var adress_line = panel_2.Controls[8] as MaterialTextBox;

                    string _address = e.Address;

                    FileManager _fM = new FileManager();

                    string json = _fM._ReadFileText(_fM._GetPathToFile("browser_settings.json"));
                    Settings settings;
                    if (json == string.Empty)
                    {
                        settings = JsonSerializer.Deserialize<Settings>(_fM._GetPathToFile("browser_settings.json", "simple_settings"));
                    }
                    else
                    {
                        settings = JsonSerializer.Deserialize<Settings>(json);
                    }

                    if (adress_line.Text != settings.Start_Page)
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
                ErrorLogger error_Logger = new ErrorLogger();
                error_Logger.Log_Errors(ex.Message);
            }
        }
        public void OnCwb_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            try
            {
                materialTabControl1.Invoke((MethodInvoker)delegate
                {
                    TabPage selectedTab = materialTabControl1.SelectedTab;

                    var panel_2 = selectedTab.Controls[1] as Panel;

                    var panel_1 = selectedTab.Controls[0] as Panel;

                    var cwb = panel_1.Controls[0] as ChromiumWebBrowser;

                    var savemark_button = panel_2.Controls[7] as MaterialButton;

                    var _fM = new FileManager();
                    string path = _fM._GetPathToFile("bookmarks.json", "bookmarks");

                    Dictionary<string, BookMarksManager.BookMark> bookMarks_Dict = new Dictionary<string, BookMarksManager.BookMark>();
                    string json = _fM._ReadFileText(path);

                    if (!string.IsNullOrEmpty(json))
                    {
                        bookMarks_Dict = JsonSerializer.Deserialize<Dictionary<string, BookMarksManager.BookMark>>(json);
                    }                                                          

                    selectedTab.Text = e.Title;

                    title_and_adress[0] = e.Title;
                    Text = e.Title;

                    HistoryManager history_Manager = new HistoryManager(title_and_adress[0], title_and_adress[1]);

                    if (bookMarks_Dict.ContainsKey(e.Title))
                    {
                        if (bookMarks_Dict[e.Title].URL == cwb.Address)
                        {
                            savemark_button.Icon = imageList2.Images[1];
                        }
                        else
                        {
                            savemark_button.Icon = imageList2.Images[0];
                        }
                    }
                    else 
                    {

                    }

                });
            }
            catch (Exception ex)
            {
                ErrorLogger error_Logger = new ErrorLogger();
                error_Logger.Log_Errors(ex.Message);
            }
        }
        public void Savemark_button_Click(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left) 
            {
                SaveBookMarks(Text);
            }            
        }
        public void SaveBookMarks(string Title) 
        {            
            var _fM = new FileManager();
            string path = _fM._GetPathToFile("bookmarks.json", "bookmarks");

            TabPage selectedTab = materialTabControl1.SelectedTab;

            var panel_1 = selectedTab.Controls[0] as Panel;

            var panel_2 = selectedTab.Controls[1] as Panel;

            var cwb = panel_1.Controls[0] as ChromiumWebBrowser;

            var savemark_button = panel_2.Controls[7] as MaterialButton;

            BookMarksManager.BookMark bookMark = new BookMarksManager.BookMark 
            {
                URL = cwb.Address,
                Title = Title
            };                   

            Dictionary<string, BookMarksManager.BookMark> bookMarks_Dict = new Dictionary<string, BookMarksManager.BookMark>();
            
            string json = _fM._ReadFileText(path);

            if (!string.IsNullOrEmpty(json))
            {
                bookMarks_Dict = JsonSerializer.Deserialize<Dictionary<string, BookMarksManager.BookMark>>(json);
            }

            if (!bookMarks_Dict.ContainsKey(Title))
            {
                bookMarks_Dict[Title] = bookMark;
                savemark_button.Icon = imageList2.Images[1];
            }

            string jsonMark = JsonSerializer.Serialize(bookMarks_Dict);

            File.WriteAllText(path, jsonMark);
        }
        private void materialTabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            Text = materialTabControl1.SelectedTab.Text;
        }
        public bool IsValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out _) || url.Contains(".");
        }                
    }
}