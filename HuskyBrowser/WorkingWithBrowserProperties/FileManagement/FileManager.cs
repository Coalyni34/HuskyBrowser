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
                _WriteFile(message, _GetPathToFile("husky_errors_log.json"));
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
                var errors = new List<string>
                {
                    ex.Message
                };
                File.AppendAllLines(_GetPathToFile("husky_errors_log.json"), errors);
                errors.Clear();
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
                var errors = new List<string>
                {
                    ex.Message
                };
                File.AppendAllLines(_GetPathToFile("husky_errors_log.json"), errors);
                errors.Clear();
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
                var errors = new List<string>
                {
                    ex.Message
                };
                _WriteFile(errors, _GetPathToFile("husky_errors_log.json"));
                return errors;
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
                return path_ToFile;
            }
            else 
            {
                Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}/browser_properties");
                var path_ToFile = $"{Directory.GetCurrentDirectory()}/browser_properties/{filename}";
                return path_ToFile;
            }
        }
        public string _GetPathToFile(string filename, string directoryname)
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
        
    }
}
