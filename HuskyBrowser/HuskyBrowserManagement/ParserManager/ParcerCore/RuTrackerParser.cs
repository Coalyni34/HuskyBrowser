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
        public string htmlPageTracker;
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
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");

            HttpResponseMessage response = await client.PostAsync(loginUrl, formData);
            if (response.IsSuccessStatusCode)
            {
                htmlPageTracker = await client.GetStringAsync(searchUrl);
            }
            else
            {
                MessageBox.Show("Ошибка: " + response.StatusCode);
            } 
        }
        public Dictionary<string, string> GetLinksOfPages(string html)
        {
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(html);
            var linkNodes = htmlDoc.DocumentNode.SelectNodes("//a");

            Dictionary<string, string> links = new Dictionary<string, string>();
            foreach (var node in linkNodes)
            {
                string hrefValue = node.GetAttributeValue("href", string.Empty);
                string classValue = node.GetAttributeValue("class", string.Empty);
                if (hrefValue.StartsWith("viewtopic.php?t=") && classValue.StartsWith("med tLink"))
                {
                    string newlink = "https://rutracker.net/forum/" + hrefValue;
                    MessageBox.Show(node.InnerText + "\n" + newlink);
                    links.Add(node.InnerText, newlink);
                }
            }
            return links;
        }
        /* public void GetLinkOfPage(string html, DataGridView dataGrid)
         {
             HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
             htmlDoc.LoadHtml(html);
             var linkNodes = htmlDoc.DocumentNode.SelectNodes("//a");                       

             string links = string.Empty;                        

             foreach (var node in linkNodes)
             {
                 string hrefValue = node.GetAttributeValue("href", string.Empty);
                 string classValue = node.GetAttributeValue("class", string.Empty);

                 if (hrefValue.StartsWith("viewtopic.php?t=") && classValue.StartsWith("med tLink"))
                 {
                     string newlink = "https://rutracker.net/forum/" + hrefValue;
                     MessageBox.Show(node.InnerText + "\n" + newlink);
                     //dataGrid.Rows.Add(node.InnerText, newlink);
                 }
             }        */
    }            
}
