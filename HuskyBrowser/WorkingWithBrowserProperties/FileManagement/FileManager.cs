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
        public void _WriteFile(List<string> msg, string path)
        {
            try
            {
                File.AppendAllLines(path, msg);
            }
            catch (Exception ex)
            {
                Error_Logger errors = new Error_Logger(); 
                errors.Log_Errors(ex.Message);
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
                Error_Logger errors = new Error_Logger();
                errors.Log_Errors(ex.Message);
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
                Error_Logger errors = new Error_Logger();
                errors.Log_Errors(ex.Message);
                return null;
            }
        }
        public string _ReadFileText(string path)
        {
            var messages = File.ReadAllText(path);
            return messages;
        }
        public bool _IsFileExist(string path) 
        {
            bool exist = File.Exists(path);
            return exist;
        }
        public void _DeleteFileText(string path)
        {
            File.Delete(path);
        }
        public string _GetPathToFile(string filename)
        {
            if (Directory.Exists($"{Directory.GetCurrentDirectory()}/browser_properties"))
            {
                var path_ToFile = $"{Directory.GetCurrentDirectory()}/browser_properties/{filename}";
                if (File.Exists(path_ToFile) != true) 
                {
                    File.Create(path_ToFile);
                }
                else 
                {

                }
                return path_ToFile;
            }
            else
            {
                Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}/browser_properties");
                var path_ToFile = $"{Directory.GetCurrentDirectory()}/browser_properties/{filename}";
                File.Create(path_ToFile);
                return path_ToFile;
            }
        }
        public string _GetPathToFile(string filename, string directoryname)
        {
            if (Directory.Exists($"{Directory.GetCurrentDirectory()}/browser_properties/{directoryname}"))
            {
                var path_ToFile = $"{Directory.GetCurrentDirectory()}/browser_properties/{directoryname}/{filename}";
                if (File.Exists(path_ToFile) != true)
                {
                    File.Create(path_ToFile);
                }
                else
                {

                }
                return path_ToFile;
            }
            else
            {
                Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}/browser_properties/{directoryname}");
                var path_ToFile = $"{Directory.GetCurrentDirectory()}/browser_properties/{directoryname}/{filename}";
                File.Create(path_ToFile);
                return path_ToFile;
            }
        }
        public string _GetPathToDirectory(string directoryname) 
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
    }
}
