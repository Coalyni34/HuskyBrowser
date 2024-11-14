using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace HuskyBrowser.WorkingWithBrowserProperties
{
    public class HistoryManager
    {        
        public class HistoryEntry
        {
            public string URL { get; set; }
            public string Title { get; set; }            
            public string Time { get; set; }          
            public HistoryEntry(string url, string title, string time)
            {
                URL = url;
                Title = title;
                Time = time;
            }
        }
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
            var History_Files = new FileManager.History_Files();
            string path = History_Files._GetPathToHistoryFile("history.json");    

            string date = $"{DateTime.Now}".Split(' ')[0];
            string time = $"{DateTime.Now}".Split(' ')[1];
            
            Dictionary<string, List<HistoryEntry>> historyEntries = new Dictionary<string, List<HistoryEntry>>();

            string json = History_Files._ReadFileText(path);
            if (!string.IsNullOrEmpty(json))
            {                   
               historyEntries = JsonSerializer.Deserialize<Dictionary<string, List<HistoryEntry>>>(json);                    
            }
            
            HistoryEntry newEntry = new HistoryEntry(adress, title, time);

            if (!historyEntries.ContainsKey(date))
            {
                historyEntries[date] = new List<HistoryEntry>();
            }

            historyEntries[date].Add(newEntry);

            string updatedJson = JsonSerializer.Serialize(historyEntries, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(path, updatedJson);            
        }
    }
}
