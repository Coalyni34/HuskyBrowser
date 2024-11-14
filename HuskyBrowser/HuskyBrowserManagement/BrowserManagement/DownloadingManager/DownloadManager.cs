using System;
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
            string path = _fM._GetPathToFile(downloadItem.SuggestedFileName, "downloads");

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
