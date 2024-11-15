using HuskyBrowser.WorkingWithBrowserProperties;

namespace HuskyBrowser.HuskyBrowserManagement.BrowserManagement.SettingsManagement
{
    public class SettingsSetup
    {        
        public SettingsSetup() 
        {
            FileManager fileManager = new FileManager();
            fileManager._CreatePropertiesDirectory();            
        }
    }
}
