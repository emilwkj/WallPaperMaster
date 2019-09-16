using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WallpaperMaster.DAL
{
    public class CommitStripRepository
    {
        public async Task<JObject> GetSite()
        {
            return await GetAsync("http://www.commitstrip.com/en/?");
        }
        private async Task<JObject> GetAsync(string url)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            var result = await client.SendAsync(request);
            string stringResult = await result.Content.ReadAsStringAsync();

            return JObject.Parse(stringResult);
        }
    }
}
