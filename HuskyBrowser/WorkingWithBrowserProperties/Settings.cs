using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuskyBrowser.WorkingWithBrowserProperties
{
    public class Settings
    {        
        public string Enabled_Search_Engine { get; set; }
        public string Search_Engine_Key { get; set; }
        public string Start_Page { get; set; }
        public bool Save_History { get; set; }        

        public List<string> Search_Engine_Adress { get; set; } = new List<string>() { "https://duckduckgo.com/" };

        public Dictionary<string, Dictionary<string, string>> Search_Engines { get; set; }
        public Settings() 
        {
            var _fM = new FileManager();

            string test = _fM._ReadFileText(_fM._GetPathToFile("search_engines.json", "search_engines"));

            Search_Engines = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(test);

            var Under_Dictionary = Search_Engines["search_engines"];

            Enabled_Search_Engine = Under_Dictionary["DuckDuckGo"];             
        }
    }
}
