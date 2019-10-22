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
        private readonly DataRepository _dataRepository;

        public CommitStripService(HttpRepository httpRepository, DataRepository dataRepository)
        {
            _httpRepository = httpRepository;
            _dataRepository = dataRepository;
        }

        public void SaveLatestStrip(string saveLocation)
        {
            _httpRepository.DownloadPicture(GetLatestPictureURL(), saveLocation);
        }
        public void SaveNextStribInOrder(string saveLocation)
        {
            string lastSetDate = _dataRepository.GetLastSetDate();
            string nextStrib = _dataRepository.GetNextStrib();
            string firstStrib = _dataRepository.GetFirstStrib();
            HtmlDocument strib = null;

            if (!String.IsNullOrWhiteSpace(lastSetDate))
            {
                DateTime lastSet = DateTime.Parse(lastSetDate);
                if (lastSet.Date < DateTime.Now.Date)
                {
                    strib = DownloadSite(nextStrib);
                }
            }
            else
            {
                strib = DownloadSite(firstStrib);
            }

            if(strib != null)
            {
                _httpRepository.DownloadPicture(GetPictureURL(strib), saveLocation);
                _dataRepository.SetNextStrib(GetNextStribURL(strib));
                _dataRepository.SetLastSetDate(DateTime.Now.Date.ToString());
            }
        }

        /// <summary>
        /// Gets latest picture
        /// </summary>
        /// <returns></returns>
        private string GetLatestPictureURL()
        {
            string homePage = _httpRepository.GetSite("http://www.commitstrip.com/en/?").Result;
            HtmlDocument homePageDocument = new HtmlDocument();
            homePageDocument.LoadHtml(homePage);

            //Get the url for the newest strip
            string linkToNewest = homePageDocument.DocumentNode.SelectSingleNode("//div[@class='excerpt']//a").Attributes["href"].Value;
            HtmlDocument newest = DownloadSite(linkToNewest);
            return GetPictureURL(newest);
        }

        private string GetPictureURL(HtmlDocument picturePageDocument)
        {
            string imageSource = picturePageDocument.DocumentNode.SelectSingleNode("//div[@class='entry-content']//p//img").Attributes["src"].Value;

            return imageSource;
        }

        private string GetNextStribURL(HtmlDocument picturePageDocument)
        {
            string imageSource = picturePageDocument.DocumentNode.SelectSingleNode("//span[@class='nav-next']//a").Attributes["href"].Value;
            return imageSource;
        }

        private HtmlDocument DownloadSite(string url)
        {
            string picturePage = _httpRepository.GetSite(url).Result;
            HtmlDocument site = new HtmlDocument();
            site.LoadHtml(picturePage);
            return site;
        }
    }
}
