using MaterialSkin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuskyBrowser.HuskyBrowserManagement.BrowserManagement.ThemesManagement
{
    public class ThemeManager
    {
        public Dictionary<string, Primary> Primaries {  get; set; }
        public Accent Accent { get; set; }
        public MaterialSkinManager.Themes ThemeName { get; set; }
        public ThemeManager(Dictionary<string, Primary> primaries, MaterialSkinManager.Themes themeName, Accent accent) 
        {
            Primaries = primaries;
            ThemeName = themeName;
            Accent = accent;
        }
    }
}
