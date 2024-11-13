using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuskyBrowser.HuskyBrowserManagement.BrowserManagement.SearchContextMenuManager
{
    public class SearchContextMenuHandler : IContextMenuHandler
    {
        private Dictionary<string, CefMenuCommand> searchMenuItems = new Dictionary<string, CefMenuCommand>
        {
            {"Cut", CefMenuCommand.Cut },
            {"Copy", CefMenuCommand.Copy },
            {"Paste", CefMenuCommand.Paste },            
            {"Search it", CefMenuCommand.Find },
            {"Select all", CefMenuCommand.SelectAll },           
            {"Save file", (CefMenuCommand)10001}
        };
        public void OnBeforeContextMenu(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
        {
            model.Clear();

            foreach (var key in searchMenuItems.Keys)
            {
                model.AddItem(searchMenuItems[key], key);
            }
            for (short i = 0; i < 4; i++)
            {
                model.SetEnabledAt(i, !string.IsNullOrWhiteSpace(parameters.SelectionText));
            }
            
            string file_url = parameters.LinkUrl;
            model.SetEnabled((CefMenuCommand)10001, !string.IsNullOrEmpty(file_url));
        }

        public bool OnContextMenuCommand(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
        {
            switch (commandId) 
            {                
                case CefMenuCommand.Copy:
                    Clipboard.SetText(parameters.SelectionText);
                    return true;
                case CefMenuCommand.Find:
                    string Addres = Form1.Enabled_Search_Engine + parameters.SelectionText;
                    chromiumWebBrowser.Load(Addres);
                    return true;
                case (CefMenuCommand)10001:
                    SaveFile(parameters.LinkUrl);
                    return true;
            }
            return false;
        }

        public void OnContextMenuDismissed(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame)
        {
            
        }

        public bool RunContextMenu(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
        {
            return false;            
        }

        private void SaveFile(string url)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            Uri uri = new Uri(url);
            string fileExtension = Path.GetExtension(uri.AbsolutePath);
            saveFileDialog.Filter = $"Image Files (*{fileExtension})|*{fileExtension}";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(url, saveFileDialog.FileName);
                }
            }                 
        }
    }
}
