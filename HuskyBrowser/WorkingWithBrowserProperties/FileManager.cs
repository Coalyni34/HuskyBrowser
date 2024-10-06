using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuskyBrowser.WorkingWithBrowserProperties
{
    public class FileManager
    {
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
                File.AppendAllLines(_GetPathToFile("husky_errors.json"), errors);
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
                File.AppendAllLines(_GetPathToFile("husky_errors.json"), errors);
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
                _WriteFile(errors, _GetPathToFile("husky_errors.json"));
                return errors;
            }
        }
        public string _ReadFileText(string path)
        {
            var messages = File.ReadAllText(path);
            return messages;
        }
        public void _DeleteFileText(string path)
        {
            File.Delete(path);
        }
        public string _GetPathToFile(string filename)
        {
            var path = $"{Directory.GetCurrentDirectory()}/browser_properties/{filename}";
            Console.WriteLine(path);
            return path;
        }
    }
}
