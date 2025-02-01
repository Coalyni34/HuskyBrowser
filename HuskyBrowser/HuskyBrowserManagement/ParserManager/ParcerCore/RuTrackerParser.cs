using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Collections.Generic;
using HtmlAgilityPack;
using CefSharp.DevTools.Accessibility;
using System.Text.RegularExpressions;
using System.Linq;
using CefSharp.DevTools.Storage;
using System.IO;
using static System.Windows.Forms.LinkLabel;
using MonoTorrent;
using System;

namespace HuskyBrowser.HuskyBrowserManagement.ParserManager.ParcerCore
{
    public class RuTrackerParser
    {
        public class Torrent 
        {
            public string name { get; set; }
            public int seeders { get; set; }
            public int leechers { get; set; }
            public long size { get; set; }
            public string username { get; set; }
            public string magnetLink { get; set; }
            public string category { get; set; }
            public string page { get; set; }
            public Torrent() 
            {

            }
            public Torrent(string name, int seeders, int leechers, long size, string username, string magnetLink, string category, string page)
            {
                this.name = name;
                this.seeders = seeders;
                this.leechers = leechers;
                this.size = size;
                this.username = username;
                this.magnetLink = magnetLink;
                this.category = category;
                this.page = page;
            }
        }

        public static List<Torrent> Torrents = new List<Torrent>();

        public async Task ParseTorrents(string query, DataGridView dataGrid) 
        {
            string loginUrl = "https://rutracker.net/forum/login.php?redirect=tracker.php?nm=%C5%C3%DD";
            string searchQuery = query.Replace(" ", "%20");
            string searchUrl = $"https://rutracker.net/forum/tracker.php?nm={searchQuery}";
            MessageBox.Show(searchUrl);
            var formData = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("login_username", "huskybrowser_ggg"),
            new KeyValuePair<string, string>("login_password", "huskybrowser_ggg"),
            new KeyValuePair<string, string>("login", "Вход") 
        });
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");
                
                HttpResponseMessage response = await client.PostAsync(loginUrl, formData);

                if (response.IsSuccessStatusCode)
                {
                    string htmlContent = await client.GetStringAsync(searchUrl);

                    await GetTorrentsInfo(GetLinksOfPages(htmlContent), client, dataGrid);
                }
                else
                {
                    MessageBox.Show("Ошибка: " + response.StatusCode);
                }                
            }            
        }        
        public List<string> GetLinksOfPages(string html) 
        {
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();

            htmlDoc.LoadHtml(html);

            var linkNodes = htmlDoc.DocumentNode.SelectNodes("//a");
           
            List<string> links = new List<string>();

            if (linkNodes != null)
            {                
                foreach (var node in linkNodes)
                {
                    string hrefValue = node.GetAttributeValue("href", string.Empty);
                    string classValue = node.GetAttributeValue("class", string.Empty);
                    if (hrefValue.StartsWith("viewtopic.php?t=") && classValue.StartsWith("med tLink"))
                    {
                        string newlink = "https://rutracker.net/forum/" + hrefValue;
                        links.Add(newlink);
                        MessageBox.Show(newlink);
                    }
                }
                return links;
            }
            else 
            {
                return null;
            }            
        }
        public async Task GetTorrentsInfo(List<string> links, HttpClient client, DataGridView dataGrid)
        {
            for (int i = 0; i < links.Count; i++)
            {                
                Torrents.Add(await SetTorrent(links[i], client));
                MessageBox.Show($"{Torrents[i].name} \n" +
               $" {Torrents[i].category} \n" +
               $" {Torrents[i].seeders} \n" +
               $" {Torrents[i].leechers} \n" +
               $" {Torrents[i].size / 1048576} MB ({(Torrents[i].size) / 1073741824} GB) \n" +
               $" {Torrents[i].magnetLink}");
                dataGrid.Rows.Add(Torrents[i].name, Torrents[i].category, Torrents[i].seeders, Torrents[i].leechers, $"{(Torrents[i].size) / 1048576} MB ({(Torrents[i].size) / 1073741824} GB)", Torrents[i].magnetLink);
            }
        }

        private async Task<Torrent> SetTorrent(string link, HttpClient client)
        {           
            string linkhtml = await client.GetStringAsync(link);
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(linkhtml);

            var magnetnode = htmlDoc.DocumentNode.SelectNodes("//a");
            var nicknode = htmlDoc.DocumentNode.SelectNodes("//p");
            var seedleechnode = htmlDoc.DocumentNode.SelectNodes("//span");

            string magnetlink = string.Empty;
            string username = string.Empty;
            string name = string.Empty;
            string category = string.Empty;
            string page = linkhtml;
            long size = 0;
            int seeds = 0;
            int leech = 0;

            foreach (var node in magnetnode)
            {
                string magnetValue = node?.GetAttributeValue("href", string.Empty);
                if (magnetValue.StartsWith("magnet:"))
                {
                    magnetlink = magnetValue;
                }
                if (magnetValue.StartsWith("viewforum.php?f=") && magnetValue != "viewforum.php?f=1649")
                {
                    string categoryInfo = node.InnerText;

                    string[] wordsToRemove = { "Авторские раздачи", "Конкурсы", "Новости &quot;Хранителей&quot; и &quot;Антикваров&quot;" };

                    category += categoryInfo + "\n";
                    foreach (var word in wordsToRemove)
                    {
                        category = category.Replace(word, string.Empty);
                    }

                    category = string.Join(" ", category.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                }
            }
            foreach (var node in htmlDoc.DocumentNode.SelectNodes("//a"))
            {
                string idnode = node?.GetAttributeValue("id", string.Empty);
                if (idnode == "topic-title")
                {
                    name = node.InnerText.Trim();
                }
            }
            foreach (var node in nicknode)
            {
                if (node?.GetAttributeValue("class", string.Empty) == "nick nick-author")
                {
                    var text = node.InnerText;
                    username = text;
                }
            }
            foreach (var node in seedleechnode)
            {
                string idValue = node?.GetAttributeValue("id", string.Empty);
                if (idValue == "tor-size-humn")
                {
                    string sizeValue = node?.GetAttributeValue("title", string.Empty);
                    size = int.Parse(sizeValue);
                }
                if (node.HasClass("seed"))
                {
                    var seedValue = new string(node.InnerText.Where(char.IsDigit).ToArray());
                    seeds = int.Parse(seedValue);
                }
                else if (node.HasClass("leech"))
                {
                    var leechValue = new string(node.InnerText.Where(char.IsDigit).ToArray());
                    leech = int.Parse(leechValue);
                }
            }
            Torrent torrent = new Torrent(name, seeds, leech, size, username, magnetlink, category, page);           
            return torrent;
        }
    }
}
