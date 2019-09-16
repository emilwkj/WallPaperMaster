using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using System;
using System.Text.RegularExpressions;
using WallpaperMaster.DAL;

namespace WallpaperMaster.Service
{
    public class CommitStripService
    {
        private readonly HttpRepository _httpRepository;
        public CommitStripService(HttpRepository httpRepository)
        {
            _httpRepository = httpRepository;
        }

        public void SaveLatestStrip(string saveLocation)
        {
            _httpRepository.DownloadPicture(GetPictureURL(), saveLocation);
        }
        private string GetPictureURL()
        {
            string homePage = _httpRepository.GetSite("http://www.commitstrip.com/en/?").Result;
            HtmlDocument homePageDocument = new HtmlDocument();
            homePageDocument.LoadHtml(homePage);

            //Get the url for the newest strip
            string linkToNewest = homePageDocument.DocumentNode.SelectSingleNode("//div[@class='excerpt']//a").Attributes["href"].Value;
            
            //Get picture from that url
            string picturePage = _httpRepository.GetSite(linkToNewest).Result;
            HtmlDocument picturePageDocument = new HtmlDocument();
            picturePageDocument.LoadHtml(picturePage);

            string imageSource = picturePageDocument.DocumentNode.SelectSingleNode("//div[@class='entry-content']//p//img").Attributes["src"].Value;

            return imageSource;
        }
    }
}
