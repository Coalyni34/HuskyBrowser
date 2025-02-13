using CefSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using static HuskyBrowser.WorkingWithBrowserProperties.FileManager;
using static HuskyBrowser.WorkingWithBrowserProperties.PagePattern;
using static System.Net.WebRequestMethods;

namespace HuskyBrowser.HuskyBrowserManagement.BrowserManagement.SearchContextMenuManager
{
    public class SearchContextMenuHandler : IContextMenuHandler
    {
        Dictionary<string, CefMenuCommand> searchMenuItems = new Dictionary<string, CefMenuCommand>
        {
            {"Cut", CefMenuCommand.Cut },
            {"Copy", CefMenuCommand.Copy },
            {"Paste", CefMenuCommand.Paste },
            {"Search it", CefMenuCommand.Find },
            {"Select all", CefMenuCommand.SelectAll },
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

            model.SetEnabled(CefMenuCommand.Paste, !string.IsNullOrEmpty(Clipboard.GetText()));

            if (!string.IsNullOrEmpty(parameters.LinkUrl))
            {
                model.AddItem((CefMenuCommand)26504, "Copy link");
                model.SetEnabled((CefMenuCommand)26504, !string.IsNullOrEmpty(parameters.LinkUrl));
            }
            else
            {
                model.Remove((CefMenuCommand)26501);
            }

            if (parameters.HasImageContents)
            {
                model.Remove((CefMenuCommand)26501);
                model.AddItem((CefMenuCommand)26501, "Copy image as link");
                model.SetEnabled((CefMenuCommand)26501, !string.IsNullOrEmpty(parameters.LinkUrl));
                model.AddItem((CefMenuCommand)26502, "Copy as image");
                model.SetEnabled((CefMenuCommand)26502, parameters.HasImageContents);
            }
            else
            {
                model.Remove((CefMenuCommand)26502);
                model.Remove((CefMenuCommand)26501);
            }

            string file_url = parameters.LinkUrl;
            if (!string.IsNullOrEmpty(file_url))
            {
                model.AddItem((CefMenuCommand)10001, "Save as");
                model.SetEnabled((CefMenuCommand)10001, !string.IsNullOrEmpty(file_url));
            }
            else
            {
                model.Remove((CefMenuCommand)10001);
            }

            if (!string.IsNullOrWhiteSpace(parameters.SelectionText))
            {
                model.AddItem((CefMenuCommand)26503, "Search in the Rutracker");
                model.SetEnabled((CefMenuCommand)26503, !string.IsNullOrWhiteSpace(parameters.SelectionText));
            }
            else
            {
                model.Remove((CefMenuCommand)26503);
            }
        }

        public bool OnContextMenuCommand(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
        {
            switch (commandId)
            {
                case CefMenuCommand.Copy:
                    Clipboard.SetText(parameters.SelectionText);
                    return true;
                case CefMenuCommand.Find:
                    string Addres = MainForm.Enabled_Search_Engine + parameters.SelectionText;
                    chromiumWebBrowser.Load(Addres);
                    return true;
                case (CefMenuCommand)10001:
                    SaveFile(parameters.LinkUrl);
                    return true;
                case (CefMenuCommand)26501:
                    CopyLink(parameters.LinkUrl);
                    return true;
                case (CefMenuCommand)26502:
                    CopyImage(parameters.LinkUrl);
                    return true;
                case (CefMenuCommand)26503:
                    string rutracker_address = "https://rutracker.net/forum/tracker.php?nm=";
                    chromiumWebBrowser.Load(rutracker_address + parameters.SelectionText);
                    return true;
                case (CefMenuCommand)26504:
                    CopyLink(parameters.LinkUrl);
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
        private void CopyImage(string linkUrl)
        {
            try
            {
                var imageUrl = linkUrl;

                Clipboard.Clear();
                using (var webClient = new WebClient())
                {
                    byte[] imageBytes = webClient.DownloadData(imageUrl);
                    using (var ms = new MemoryStream(imageBytes))
                    {
                        var image = Image.FromStream(ms);
                        Clipboard.SetImage(image);
                    }
                }
            }
            catch (Exception e)
            {
                ErrorLogger logger = new ErrorLogger();
                logger.Log_Errors(e.Message);
            }
        }
        private void CopyLink(string linkUrl)
        {
            Clipboard.SetText(linkUrl);
        }
        private void SaveFile(string url)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            Uri uri = new Uri(url);
            string fileExtension = Path.GetExtension(uri.AbsolutePath);
            saveFileDialog.Filter = $"Files (*{fileExtension})|*{fileExtension}";
            saveFileDialog.FileName = Path.GetFileName(uri.AbsolutePath);
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
