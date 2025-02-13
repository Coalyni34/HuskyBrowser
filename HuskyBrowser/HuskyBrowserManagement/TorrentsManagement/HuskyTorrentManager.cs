using System;
using System.IO;
using System.Windows.Forms;
using static HuskyBrowser.WorkingWithBrowserProperties.FileManager;
using MonoTorrent.Client;
using MonoTorrent;


namespace HuskyBrowser.HuskyBrowserManagement.TorrentsManagement
{
    public class HuskyTorrentManager
    {
        ClientEngine _engine;
        TorrentManager _manager;

        public HuskyTorrentManager()
        {
            _engine = new ClientEngine(new EngineSettings());
        }
        public async void DownloadTorrent(string magnetLink)
        {
            if (string.IsNullOrEmpty(magnetLink))
            {
                MessageBox.Show("Please, set the magnetlink");
                return;
            }
            else 
            {
                try
                {
                    Torrent torrent;
                    if (magnetLink.StartsWith("magnet:"))
                    {
                        torrent = await Torrent.LoadAsync(magnetLink);

                        string savePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Downloads");

                        _manager = await _engine.AddAsync(torrent, savePath);

                        await _manager.StartAsync();
                    }                    
                }
                catch (Exception ex)
                {
                    ErrorLogger errorLogger = new ErrorLogger();
                    errorLogger.Log_Errors(ex.Message);
                }
            }
        }
    }
}
