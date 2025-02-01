using System.Collections.Generic;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using System.Net.Http;
using System;
using System.Linq;
using HtmlAgilityPack;
using System.IO;


namespace HuskyBrowser.HuskyBrowserManagement.ParserManager.ParcerCore
{
    public class ThePirateBayParser
    {
        public class Torrent 
        {
            public string name {  get; set; }
            public int seeders { get; set; }
            public int leechers { get; set; }
            public long size { get; set; }
            public string username { get; set; }
            public string infoHash { get; set; }
            public string magnetLink { get; set; }
            public string category { get; set; }
            public string description { get; set; }
            public Torrent(string name, int seeders, int leechers, long size, string username, string infoHash, string magnetLink, string category, string description)
            {
                this.name = name;
                this.seeders = seeders;
                this.leechers = leechers;
                this.size = size;
                this.username = username;
                this.infoHash = infoHash;
                this.magnetLink = magnetLink;
                this.category = category;
                this.description = description;
            }
        }

        public List<Torrent> Torrents { get; set; } = new List<Torrent>();

        public async System.Threading.Tasks.Task FindTorrents(string query) 
        {
            HttpClient client = new HttpClient();

            string url = $"https://apibay.org/q.php?q={Uri.EscapeDataString(query)}&cat=";

            HttpResponseMessage response = await client.GetAsync(url);

            string json = await response.Content.ReadAsStringAsync();
            dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

            int count = 0;
            foreach (var item in data)
            {
                count++;                
                string name = item.name;
                int seeders = item.seeders;
                int leechers = item.leechers;
                long size = item.size;
                string username = item.username;
                string infoHash = item.info_hash;
                string category = item.category;
                                                
                string magnetLink = GenerateMagnetLink(infoHash, name);
                magnetLink = AddTrackersToMagnetLink(magnetLink);

                var torrent = new Torrent(name, seeders, leechers, size, username, infoHash, magnetLink, category, string.Empty);
                Torrents.Add(torrent);
            }           
        }
        static string GenerateMagnetLink(string infoHashHex, string displayName)
        {
            byte[] infoHashBytes = new byte[20];
            for (int i = 0; i < 20; i++)
            {
                infoHashBytes[i] = Convert.ToByte(infoHashHex.Substring(i * 2, 2), 16);
            }

            byte[] displayNameBytes = Encoding.UTF8.GetBytes(displayName);

            SHA1 sha1 = SHA1.Create();
            byte[] hashBytes = sha1.ComputeHash(infoHashBytes.Concat(displayNameBytes).ToArray());

            string infoHash = BitConverter.ToString(infoHashBytes).Replace("-", "").ToLower();
            string displayNameEncoded = Uri.EscapeDataString(displayName);

            string magnetLink = $"magnet:?xt=urn:btih:{infoHash}&dn={displayNameEncoded}";

            return magnetLink;
        }

        static string AddTrackersToMagnetLink(string magnetLink)
        {
            string[] trackers = new string[] {
            "udp://tracker.openbittorrent.com:80",
            "udp://tracker.opentrackr.org:1337",
            "udp://tracker.coppersurfer.tk:6969"
        };

            string trackersString = "";
            for (int i = 0; i < trackers.Length; i++)
            {
                trackersString += "&tr=" + Uri.EscapeDataString(trackers[i]);
            }

            magnetLink += trackersString;

            return magnetLink;
        }
    }
}
