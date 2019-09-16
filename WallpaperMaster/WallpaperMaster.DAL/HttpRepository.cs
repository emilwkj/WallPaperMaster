using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WallpaperMaster.DAL
{
    public class HttpRepository
    {
        public async Task<string> GetSite(string url)
        {
            return await GetAsync(url);
        }
        private async Task<string> GetAsync(string url)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            var result = await client.SendAsync(request);
            string stringResult = await result.Content.ReadAsStringAsync();
            return stringResult;
        }
        public bool DownloadPicture(string url, string downloadLocation)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(new Uri(url), downloadLocation);
                }
                return true;
            }
            catch {
                return false;
            }
            
        }
    }
}
