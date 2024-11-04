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
        public string Start_Page { get; set; }
        public bool Save_History { get; set; }
        public string Search_Engine_Name { get; set; }
        public int[] ScreenResolution { get; set; }
        public Settings(string enabled_search_engine, string start_page, bool save_history, string search_Engine_Name, int[] screenResolution)
        {
            Enabled_Search_Engine = enabled_search_engine;
            Start_Page = start_page;
            Save_History = save_history;
            Search_Engine_Name = search_Engine_Name;
            ScreenResolution = screenResolution;
        }
    }
}
