﻿using CefSharp.WinForms;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Text.Json;
using HuskyBrowser.WorkingWithBrowserProperties.HistoryMagement;
using HuskyBrowser.WorkingWithBrowserProperties.BookMarksManager;
using Application = System.Windows.Forms.Application;
using Image = System.Drawing.Image;
using HuskyBrowser.HuskyBrowserManagement.DownloadingManager;
using System.Diagnostics;
using HuskyBrowser.HuskyBrowserManagement.BrowserManagement.SearchContextMenuManager;

namespace HuskyBrowser.WorkingWithBrowserProperties
{
    public class PagePattern
    {
        static MaterialTabControl tabControl { get; set; }
        static Color Page_BackColor { get; set; } = Color.FromArgb(255, 50, 50, 50);
        public class DownloadPagePattern : PagePattern 
        {            
            private TabPage new_TapPage = new TabPage()
            {
                Text = "Downloads",
                Name = "Downloads",
                BackColor = Page_BackColor
            };
            private DataGridView Downloads = new DataGridView 
            {
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
                ReadOnly = true,
                AllowUserToDeleteRows = false,
                AllowUserToResizeColumns = false,
                AllowUserToOrderColumns = false,
                AllowUserToResizeRows = false,
                Location = new Point(75, 0),
            };
            private MaterialButton Closing_Button = new MaterialButton
            {
                Text = "Close Page",
                Size = new Size(70, 40),
                Location = new Point(0, 10),
                Anchor = AnchorStyles.Left | AnchorStyles.Top,
                DrawShadows = false,
                AutoSize = false
            };
            public DownloadPagePattern()
            {
                var _fM = new FileManager();

                string json = _fM._ReadFileText(_fM._GetPathToFile("browser_settings.json"));
                Settings settings = GetSettings(_fM, json);

                string path = settings.SaveDirectoryPath;

                var files = _fM._GetFilesFromAnyDirectory(path);

                if (files.Length != 0)
                {
                    Downloads.DefaultCellStyle.ForeColor = Color.White;
                    Downloads.DefaultCellStyle.BackColor = Page_BackColor;
                    Downloads.DefaultCellStyle.SelectionBackColor = Color.Silver;

                    Downloads.Columns.Add("Time", "Time");
                    Downloads.Columns.Add("Name", "Name");
                    Downloads.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    Downloads.CellClick += DownloadClick;
                    Closing_Button.Click += OnClose_Click;

                    foreach (var f in files)
                    {
                        FileInfo fileInfo = new FileInfo($"{path}\\{f}");
                        var dateTime = fileInfo.CreationTime;
                        Downloads.Rows.Add($"{dateTime.Day}.{dateTime.Month}.{dateTime.Year}", f);
                    }

                    new_TapPage.Controls.Add(Closing_Button);
                    new_TapPage.Controls.Add(Downloads);

                    tabControl.TabPages.Add(new_TapPage);
                    tabControl.SelectTab(new_TapPage);
                }
                else
                {
                    MessageBox.Show("You haven't any downloads");
                }
            }

            private static Settings GetSettings(FileManager _fM, string json)
            {
                Settings settings;

                if (json == string.Empty)
                {
                    settings = JsonSerializer.Deserialize<Settings>(_fM._GetPathToFile("browser_settings.json", "simple_settings"));
                }
                else
                {
                    settings = JsonSerializer.Deserialize<Settings>(json);
                }

                return settings;
            }

            public void DownloadClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.ColumnIndex == 1)
                {
                    var title = Downloads.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                    var _fM = new FileManager();
                    string json = _fM._ReadFileText(_fM._GetPathToFile("browser_settings.json"));
                    Settings settings = GetSettings(_fM, json);
                    string path = settings.SaveDirectoryPath + "\\" + title;

                    if (title != null)
                    {
                        Process.Start("explorer.exe", $"/select,\"{path}\"");
                    }
                }
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
        }
        public class SettingsPagePattern : PagePattern
        {
            private TabPage new_TapPage = new TabPage
            {
                Text = "Settings",
                Name = "Settings",
                BackColor = Page_BackColor
            };
            private MaterialButton SaveSettings_Button = new MaterialButton
            {
                Text = "Save Settings",
                Size = new Size(70, 40),
                Location = new Point(90, 15),
                DrawShadows = false,
                AutoSize = false
            };
            private MaterialButton Closing_Button = new MaterialButton
            {
                Text = "Close Page",
                Size = new Size(70, 40),
                Location = new Point(10, 15),
                DrawShadows = false,
                AutoSize = false
            };
            public MaterialLabel Choosing_SearchEngine_Text = new MaterialLabel
            {
                Text = "Search engine:",
                Size = new Size(110, 30),
                Location = new Point(20, 130),
                AutoSize = false
            };
            public MaterialComboBox SearchEngine_ComboBox = new MaterialComboBox
            {
                Text = "DuckDuckGo",
                Size = new Size(180, 50),
                Location = new Point(160, 115),
                AutoSize = false
            };
            public MaterialSwitch SaveHistory_Switch = new MaterialSwitch
            {
                Size = new Size(180, 50),
                Location = new Point(140, 245),
                AutoSize = false
            };
            public MaterialLabel SaveHistory_Label = new MaterialLabel
            {
                Text = "Save history:",
                Location = new Point(20, 260),
                AutoSize = false
            };            
            public MaterialComboBox ResolutionOfScreen = new MaterialComboBox
            {
                Size = new Size(180, 50),
                Location = new Point(160, 185),
                AutoSize = false
            };
            public MaterialLabel ResolutionOfScreen_Text = new MaterialLabel
            {
                TextAlign = ContentAlignment.TopCenter,
                Text = "Screen resolution:",
                Size = new Size(145, 50),
                Location = new Point(10, 200),
                AutoSize = false
            };
            public MaterialButton OpenHistoryJournal_Button = new MaterialButton
            {
                TextAlign = ContentAlignment.TopCenter,
                Text = "Open history journal",
                Size = new Size(130, 50),
                Location = new Point(170, 10),
                AutoSize = false
            };
            public MaterialButton OpenBookMarks_Button = new MaterialButton
            {
                TextAlign = ContentAlignment.TopCenter,
                Text = "Open bookmarks",
                Size = new Size(130, 50),
                Location = new Point(310, 10),
                AutoSize = false
            };
            public MaterialLabel SavePath_Label = new MaterialLabel
            {
                Text = "Save folder path:",
                Size = new Size(125, 30),
                Location = new Point(20, 300),
                AutoSize = false
            };
            public MaterialMultiLineTextBox SavePath_TextBox = new MaterialMultiLineTextBox
            {
                Size = new Size(700, 20),
                Location = new Point(160, 300),
                AutoSize = false
            };
            public MaterialButton SelectedPath_Button = new MaterialButton
            {
                Size = new Size(40, 40),
                Location = new Point(865, 290),
                AutoSize = false,
                Type = MaterialButton.MaterialButtonType.Text
            };
            private List<string> Engines_Keys = new List<string>() { "DuckDuckGo", "Google", "Bing", "Brave" };
            private Dictionary<string, string> Search_Engines = new Dictionary<string, string>()
            {
                { "DuckDuckGo", "https://start.duckduckgo.com/" },
                { "Google", "https://www.google.com/search?q=" },
                { "Bing", "https://www.bing.com/search?=" },
                { "Brave", "https://search.brave.com/search?q=" }
            };
            private string SaveDirectoryPath;
            public SettingsPagePattern(MaterialTabControl materialTabControl, Image[] button_icons)
            {
                new_TapPage.Controls.Add(Choosing_SearchEngine_Text);
                new_TapPage.Controls.Add(SearchEngine_ComboBox);
                new_TapPage.Controls.Add(SaveSettings_Button);
                new_TapPage.Controls.Add(Closing_Button);
                new_TapPage.Controls.Add(SaveHistory_Switch);
                new_TapPage.Controls.Add(ResolutionOfScreen);
                new_TapPage.Controls.Add(ResolutionOfScreen_Text);
                new_TapPage.Controls.Add(OpenHistoryJournal_Button);
                new_TapPage.Controls.Add(OpenBookMarks_Button);
                new_TapPage.Controls.Add(SaveHistory_Label);
                new_TapPage.Controls.Add(SavePath_Label);
                new_TapPage.Controls.Add(SavePath_TextBox);
                new_TapPage.Controls.Add(SelectedPath_Button);

                SelectedPath_Button.Icon = button_icons[0];

                foreach (var engine in Engines_Keys)
                {
                    SearchEngine_ComboBox.Items.Add(engine);
                }

                foreach (var screen in Screen.AllScreens)
                {
                    string resolution = $"{screen.Bounds.Width}X{screen.Bounds.Height}";
                    ResolutionOfScreen.Items.Add(resolution);
                }

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

                string path = settings.SaveDirectoryPath;

                SearchEngine_ComboBox.SelectedItem = settings.Search_Engine_Name;
                SaveHistory_Switch.Checked = settings.Save_History;
                ResolutionOfScreen.Text = $"{settings.ScreenResolution[0]}X{settings.ScreenResolution[1]}";
                SavePath_TextBox.Text = settings.SaveDirectoryPath;

                SaveSettings_Button.Click += OnSave_Click;
                Closing_Button.Click += OnClose_Click;
                OpenHistoryJournal_Button.Click += OnOpenJournal_Click;
                OpenBookMarks_Button.Click += OnOpenBookmarks_Click;
                SelectedPath_Button.Click += SelectedPath_Click;

                tabControl.TabPages.Add(new_TapPage);
                tabControl.SelectTab(new_TapPage);
            }

            private void SelectedPath_Click(object sender, EventArgs e)
            {
                FolderBrowserDialog folderDialog = new FolderBrowserDialog();
                folderDialog.Description = "Select folder";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    SaveDirectoryPath = folderDialog.SelectedPath;
                    SavePath_TextBox.Text = folderDialog.SelectedPath;
                }
            }

            private void OnOpenJournal_Click(object sender, EventArgs e)
            {
                var _fM = new FileManager();

                string path = _fM._GetPathToFile("history.json", "history");

                string jsonHistory = _fM._ReadFileText(path);
                if(jsonHistory != string.Empty) 
                {
                    HistoryJournal historyJournal = new HistoryJournal(tabControl);
                    historyJournal.Show();
                }
                else 
                {
                    MessageBox.Show("History has deleted. You have to search some in the Internet or reload the program");
                }
            }
            private void OnOpenBookmarks_Click(object sender, EventArgs e)
            {
                BookMarkForm bookMarks = new BookMarkForm(Form1.thisform)
                {
                    _tabControl = tabControl
                };
                bookMarks.Show();
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

                string[] res = ResolutionOfScreen.Text.Split('X');
                int[] ScreenResolution;

                if (res != null)
                {
                    ScreenResolution = new int[] { int.Parse(res[0]), int.Parse(res[1]) };
                }
                else
                {
                    ScreenResolution = new int[] { Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height };
                }

                string sdpt = $"C:\\Users\\{System.Security.Principal.WindowsIdentity.GetCurrent().Name}\\Downloads";
                if(SaveDirectoryPath != string.Empty)
                {
                    sdpt = SaveDirectoryPath;
                }

                Settings settings = new Settings(Search_Engines[selected_engine], Search_Engines[selected_engine], DoSaveHistory, selected_engine, ScreenResolution, sdpt);

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

            public Panel panel_1 = new Panel
            {
                AutoSize = false,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
                Location = new Point(0, 59),
                Size = new Size(786, 330)
            };
            public Panel panel_2 = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(786, 70),
                AutoSize = false,
                MaximumSize = new Size(1920, 70),
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom
            };
            private MaterialButton back_button = new MaterialButton
            {
                Text = "",
                Size = new Size(40, 36),
                Location = new Point(10, 10),
                DrawShadows = false,
                AutoSize = false
            };
            private MaterialButton forward_button = new MaterialButton
            {
                Text = "",
                Size = new Size(40, 36),
                Location = new Point(55, 10),
                DrawShadows = false,
                AutoSize = false,
            };
            private MaterialButton refresh_button = new MaterialButton
            {
                Text = "",
                Size = new Size(40, 36),
                Location = new Point(100, 10),
                DrawShadows = false,
                AutoSize = false,
            };
            private MaterialButton createtab_button = new MaterialButton
            {
                Text = "",
                Size = new Size(40, 36),
                Location = new Point(145, 10),
                DrawShadows = false,
                AutoSize = false,
            };
            private MaterialButton closeTab_button = new MaterialButton
            {
                Text = "",
                Size = new Size(40, 36),
                Location = new Point(190, 10),
                DrawShadows = false,
                AutoSize = false,
            };
            private MaterialButton download_button = new MaterialButton
            {
                Text = "",
                Size = new Size(40, 36),
                Location = new Point(940, 10),
                DrawShadows = false,
                AutoSize = false
            };
            private MaterialButton settings_button = new MaterialButton
            {
                Text = "",
                Size = new Size(40, 36),
                Location = new Point(985, 10),
                DrawShadows = false,
                AutoSize = false
            };
            public MaterialButton savemark_button = new MaterialButton
            {
                Text = "",
                Size = new Size(40, 36),
                Location = new Point(1030, 10),
                DrawShadows = false,
                AutoSize = false
            };
            public MaterialTextBox adress_line = new MaterialTextBox
            {
                AutoSize = false,
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                MinimumSize = new Size(200, 35),
                MaximumSize = new Size(700, 35),
                Location = new Point(235, 10),
                DetectUrls = true,
                MaxLength = 1000
            };
            public ChromiumWebBrowser cwb = new ChromiumWebBrowser()
            {
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };
            public SimplePagePattern(List<Image> icons, List<Image> savemarksbuttons_icons, MaterialTabControl materialTabControl, string URL, string Title)
            {
                tabControl = materialTabControl;

                var _fm = new FileManager();
                string json = _fm._ReadFileText(_fm._GetPathToFile("browser_settings.json"));
                var settings = JsonSerializer.Deserialize<Settings>(json);

                SearchContextMenuHandler menuHandler = new SearchContextMenuHandler();
                cwb.Load(URL);
                DownloadManager downloadManager = new DownloadManager();
                cwb.DownloadHandler = downloadManager;   
                cwb.MenuHandler = menuHandler;

                simplePageButtons.Add(forward_button);
                simplePageButtons.Add(back_button);
                simplePageButtons.Add(refresh_button);
                simplePageButtons.Add(createtab_button);
                simplePageButtons.Add(closeTab_button);
                simplePageButtons.Add(settings_button);
                simplePageButtons.Add(download_button);                

                ScreenSettings(simplePageButtons[5], simplePageButtons[6], savemark_button, adress_line, settings.ScreenResolution[0]);

                for (short i = 0; i < simplePageButtons.Count; i++)
                {
                    simplePageButtons[i].Icon = icons[i];
                    simplePageButtons[i].Type = MaterialButton.MaterialButtonType.Text;
                }

                savemark_button.Icon = savemarksbuttons_icons[0];
                savemark_button.Type = MaterialButton.MaterialButtonType.Text;                                             

                Form1.thisform.SetClicks(this);

                var marktab = new TabPage()
                {
                    BackColor = Page_BackColor
                };

                foreach (var button in simplePageButtons)
                {
                    panel_2.Controls.Add(button);
                }

                panel_2.Controls.Add(savemark_button);
                panel_2.Controls.Add(adress_line);
                panel_1.Controls.Add(cwb);

                new_TapPage.Controls.Add(panel_1);
                new_TapPage.Controls.Add(panel_2);                               

                tabControl.TabPages.Add(new_TapPage);
                tabControl.SelectTab(new_TapPage);
                tabControl.SelectedTab.Text = Title;
            }            
            public void OnClose_Click(object sender, EventArgs e)
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
            private void ScreenSettings(MaterialButton settingsButton, MaterialButton downloadButton, MaterialButton savemarksButton, MaterialTextBox adressLine, int Width)
            {
                switch (Width)
                {
                    case 1600:
                        settingsButton.Location = new Point(1070, 10);
                        downloadButton.Location = new Point(1110, 10);
                        savemarksButton.Location = new Point(1150, 10);
                        adressLine.MinimumSize = new Size(200, 35);
                        adressLine.MaximumSize = new Size(900, 35);
                        cwb.MaximumSize = new Size(1600, 740);
                        break;
                    case 1280:
                        settingsButton.Location = new Point(985, 10);
                        downloadButton.Location = new Point(940, 10);
                        savemarksButton.Location = new Point(1030, 10);
                        adressLine.MinimumSize = new Size(200, 35);
                        adressLine.MaximumSize = new Size(700, 35);
                        cwb.MaximumSize = new Size(1280, 870);
                        break;
                    case 1920:
                        settingsButton.Location = new Point(1500, 10);
                        downloadButton.Location = new Point(1550, 10);
                        savemarksButton.Location = new Point(1600, 10);
                        adressLine.MinimumSize = new Size(200, 35);
                        adressLine.MaximumSize = new Size(1250, 35);
                        cwb.MaximumSize = new Size(1920, 932);
                        break;
                    case 1536:
                        settingsButton.Location = new Point(1500, 10);
                        downloadButton.Location = new Point(1550, 10);
                        savemarksButton.Location = new Point(1600, 10);
                        adressLine.MinimumSize = new Size(200, 35);
                        adressLine.MaximumSize = new Size(1250, 35);
                        cwb.MaximumSize = new Size(1920, 932);
                        break;
                }
            }
        }
    }
}
