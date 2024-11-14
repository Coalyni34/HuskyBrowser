using System;
using System.Text.Json;
using CefSharp;
using HuskyBrowser.WorkingWithBrowserProperties;

namespace HuskyBrowser.HuskyBrowserManagement.DownloadingManager
{
    public class DownloadManager : IDownloadHandler
    {
        public event EventHandler<DownloadItem> OnBeforeDownloadFired;

        public event EventHandler<DownloadItem> OnDownloadUpdatedFired;
        public bool CanDownload(IWebBrowser chromiumWebBrowser, IBrowser browser, string url, string requestMethod)
        {
            return true;
        }
        public bool OnBeforeDownload(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem, IBeforeDownloadCallback callback)
        {
            OnBeforeDownloadFired?.Invoke(this, downloadItem);

            var _fM = new FileManager();

            string json = _fM._ReadFileText(_fM._GetPathToFile("browser_settings.json"));          

            Settings settings;

            if (json == string.Empty)
            {
                settings = JsonSerializer.Deserialize<Settings>(_fM._GetPathToFile("browser_settings.json", "simple_settings"));
            }
            else
            {
                settings = JsonSerializer.Deserialize<Settings>(json);
            }

            string path = settings.SaveDirectoryPath;

            if (!callback.IsDisposed)
            {
                using (callback)
                {
                    callback.Continue(path, showDialog: true);
                }
                return true;
            }
            else 
            {
                return false;
            }
        }

        public void OnDownloadUpdated(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem, IDownloadItemCallback callback)
        {
            
        }
    }
}
