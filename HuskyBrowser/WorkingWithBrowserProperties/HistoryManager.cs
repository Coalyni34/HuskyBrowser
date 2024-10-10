using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HuskyBrowser.WorkingWithBrowserProperties
{
    public class HistoryManager
    {
        public bool Save_History { get; set; }
        public HistoryManager(string title, string adress)
        {
            var _fM = new FileManager();
            string json = _fM._ReadFileText(_fM._GetPathToFile("browser_settings.json"));

            Settings settings = JsonSerializer.Deserialize<Settings>(json);

            Save_History = settings.Save_History;
            switch (Save_History) 
            {
                case true:
                    SaveHistory(title, adress);
                    break;
                case false:
                    break;
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
    }
}
