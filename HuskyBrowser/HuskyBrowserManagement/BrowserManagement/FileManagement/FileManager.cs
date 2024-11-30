using HuskyBrowser.HuskyBrowserManagement.BrowserManagement.ThemesManagement;
using MaterialSkin;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Windows.Forms.VisualStyles;

namespace HuskyBrowser.WorkingWithBrowserProperties
{
    public class FileManager
    {
        public class Error_Logger : FileManager
        {
            public void Log_Errors(string message) 
            {
                File.AppendAllText(_GetPathToFile("husky_errors_log.txt"), message);
            }
        }
        public class History_Files : FileManager
        {
            public string _GetPathToHistoryFile(string filename)
            {
                var path_ToFile = $"{Directory.GetCurrentDirectory()}/browser_properties/history/{filename}";
                return path_ToFile;                               
            }
        }
        public void _WriteFile(List<string> msg, string path)
        {
            try
            {
                File.AppendAllLines(path, msg);
            }
            catch (Exception ex)
            {
                Error_Logger error_Logger = new Error_Logger();
                error_Logger.Log_Errors(ex.Message);
            }
        }
        public void _WriteFile(string msg, string path)
        {
            try
            {
                File.AppendAllText(path, msg);
            }
            catch (Exception ex)
            {
                Error_Logger error_Logger = new Error_Logger();
                error_Logger.Log_Errors(ex.Message);
            }
        }
        public List<string> _ReadFileLines(string path)
        {
            try
            {
                var messages = new List<string>(File.ReadAllLines(path));
                return messages;
            }
            catch (Exception ex)
            {
                Error_Logger error_Logger = new Error_Logger();
                error_Logger.Log_Errors(ex.Message);
                return null;
            }
        }
        public string _ReadFileText(string path)
        {
            try 
            {
                var messages = File.ReadAllText(path);
                return messages;
            }
            catch (Exception ex)
            {
                Error_Logger error_Logger = new Error_Logger();
                error_Logger.Log_Errors(ex.Message);
                return null;
            }
        }
        public bool _IsFileExist(string path) 
        {
            try
            {
                bool exist = File.Exists(path);
                return exist;
            }
            catch (Exception ex)
            {
                Error_Logger error_Logger = new Error_Logger();
                error_Logger.Log_Errors(ex.Message);
                return false;
            }
        }
        public void _DeleteFileText(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception ex)
            {
                Error_Logger error_Logger = new Error_Logger();
                error_Logger.Log_Errors(ex.Message);
            }
        }
        public string _GetPathToFile(string filename)
        {
            try
            {
                if (Directory.Exists($"{Directory.GetCurrentDirectory()}\\browser_properties"))
                {
                    var path_ToFile = $"{Directory.GetCurrentDirectory()}\\browser_properties\\{filename}";
                    return path_ToFile;
                }
                else
                {
                    Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}\\browser_properties");
                    var path_ToFile = $"{Directory.GetCurrentDirectory()}\\browser_properties\\{filename}";
                    return path_ToFile;
                }
            }
            catch (Exception ex)
            {
                Error_Logger error_Logger = new Error_Logger();
                error_Logger.Log_Errors(ex.Message);
                return null;
            }
        }
        public string _GetPathToFile(string filename, string directoryname)
        {
            try
            {
                if (Directory.Exists($"{Directory.GetCurrentDirectory()}\\browser_properties\\{directoryname}"))
                {
                    var path_ToFile = $"{Directory.GetCurrentDirectory()}\\browser_properties\\{directoryname}\\{filename}";
                    return path_ToFile;
                }
                else
                {
                    Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}\\browser_properties\\{directoryname}");
                    var path_ToFile = $"{Directory.GetCurrentDirectory()}\\browser_properties\\{directoryname}\\{filename}";
                    return path_ToFile;
                }
            }
            catch(Exception ex)
            {
                Error_Logger error_Logger = new Error_Logger();
                error_Logger.Log_Errors(ex.Message);
                return null;
            }
        }
        public string _GetPathToDirectory(string directoryname) 
        {
            try
            {
                if (Directory.Exists($"{Directory.GetCurrentDirectory()}\\browser_properties\\{directoryname}"))
                {
                    var pathToDirectory = $"{Directory.GetCurrentDirectory()}\\browser_properties\\{directoryname}";
                    return pathToDirectory;
                }
                else
                {
                    Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}\\browser_properties\\{directoryname}");
                    var pathToDirectory = $"{Directory.GetCurrentDirectory()}\\browser_properties\\{directoryname}";
                    return pathToDirectory;
                }
            }
            catch (Exception ex)
            {
                Error_Logger error_Logger = new Error_Logger();
                error_Logger.Log_Errors(ex.Message);
                return null;
            }
        }
        public string[] _GetFilesFromDirectory(string directoryname) 
        {
            try 
            {
                var files = Directory.GetFiles(_GetPathToDirectory(directoryname));                               

                var names = new string[files.Length];

                for(int i = 0; i < names.Length; i++) 
                {
                    names[i] = Path.GetFileName(files[i]);
                }

                return names;
            }
            catch (Exception ex)
            {
                Error_Logger error_Logger = new Error_Logger();
                error_Logger.Log_Errors(ex.Message);
                return null;
            }
        }
        public string[] _GetFilesFromAnyDirectory(string path)
        {
            try
            {
                var files = Directory.GetFiles(path);

                var names = new string[files.Length];

                for (int i = 0; i < names.Length; i++)
                {
                    names[i] = Path.GetFileName(files[i]);
                }

                return names;
            }
            catch (Exception ex)
            {
                Error_Logger error_Logger = new Error_Logger();
                error_Logger.Log_Errors(ex.Message);
                return null;
            }
        }
        public void _CreatePropertiesDirectory() 
        {
            try
            {
                var pathToDirectory = $"{Directory.GetCurrentDirectory()}\\browser_properties";
                if (!Directory.Exists(pathToDirectory))
                {                    
                    Directory.CreateDirectory(pathToDirectory + "\\history");
                    Directory.CreateDirectory(pathToDirectory + "\\simple_settings");
                    Directory.CreateDirectory(pathToDirectory + "\\bookmarks"); 
                    Settings settings = new Settings("https://duckduckgo.com/?t=ffab\u0026q=",
                        "https://start.duckduckgo.com/",
                        true, "DuckDuckGo", 
                        new int[] { 1920, 1080 },
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                        "Downloads"),
                        "Simple page"
                        );
                    string jsonSettings = JsonSerializer.Serialize(settings);
                    _WriteFile(jsonSettings, _GetPathToFile("browser_settings.json"));
                    _WriteFile(jsonSettings, _GetPathToFile("browser_settings.json", "simple_settings"));
                    ThemeManager themeManager = new ThemeManager(new Dictionary<string, Primary> { { "primary", Primary.Indigo600 },
                        { "darkprimary", Primary.Indigo600 },
                        { "lightprimary", Primary.BlueGrey500 }, },
                    MaterialSkinManager.Themes.DARK, Accent.Cyan100
                    );                    
                    string jsonTheme = JsonSerializer.Serialize(themeManager);
                    _WriteFile(jsonTheme, _GetPathToFile("browser_theme.json"));
                    _WriteFile(jsonTheme, _GetPathToFile("browser_theme.json", "simple_settings"));
                    _WriteFile(string.Empty, pathToDirectory + "\\history\\history.json");
                    _WriteFile(string.Empty, pathToDirectory + "\\bookmarks\\bookmarks.json");
                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {
                Error_Logger error_Logger = new Error_Logger();
                error_Logger.Log_Errors(ex.Message);               
            }
        }
        public string _GetPropertiesDirectory() 
        {
            try
            {
                if (Directory.Exists($"{Directory.GetCurrentDirectory()}\\browser_properties"))
                {
                    var pathToDirectory = $"{Directory.GetCurrentDirectory()}\\browser_properties";
                    return pathToDirectory;
                }
                else
                {
                    Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}\\browser_properties");
                    var pathToDirectory = $"{Directory.GetCurrentDirectory()}\\browser_properties";
                    return pathToDirectory;
                }
            }
            catch (Exception ex)
            {
                Error_Logger error_Logger = new Error_Logger();
                error_Logger.Log_Errors(ex.Message);
                return null; 
            }
        }        
    }
}
