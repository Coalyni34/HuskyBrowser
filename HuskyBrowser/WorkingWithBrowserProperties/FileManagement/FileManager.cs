using CefSharp.DevTools.Debugger;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                if (Directory.Exists($"{Directory.GetCurrentDirectory()}/browser_properties"))
                {
                    var path_ToFile = $"{Directory.GetCurrentDirectory()}/browser_properties/{filename}";
                    return path_ToFile;
                }
                else
                {
                    Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}/browser_properties");
                    var path_ToFile = $"{Directory.GetCurrentDirectory()}/browser_properties/{filename}";
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
                if (Directory.Exists($"{Directory.GetCurrentDirectory()}/browser_properties/{directoryname}"))
                {
                    var path_ToFile = $"{Directory.GetCurrentDirectory()}/browser_properties/{directoryname}/{filename}";
                    return path_ToFile;
                }
                else
                {
                    Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}/browser_properties/{directoryname}");
                    var path_ToFile = $"{Directory.GetCurrentDirectory()}/browser_properties/{directoryname}/{filename}";
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
                if (Directory.Exists($"{Directory.GetCurrentDirectory()}/browser_properties/{directoryname}"))
                {
                    var pathToDirectory = $"{Directory.GetCurrentDirectory()}/browser_properties/{directoryname}";
                    return pathToDirectory;
                }
                else
                {
                    Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}/browser_properties/{directoryname}");
                    var pathToDirectory = $"{Directory.GetCurrentDirectory()}/browser_properties/{directoryname}";
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
