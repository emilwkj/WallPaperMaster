using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using System;
using System.Text.RegularExpressions;
using WallpaperMaster.DAL;

namespace WallpaperMaster.Service
{
    public class CommitStripService
    {
        private readonly CommitStripRepository _commitStripRepository;
        public CommitStripService(CommitStripRepository commitStripRepository)
        {
            _commitStripRepository = commitStripRepository;
        }
        public string GetPictureURL()
        {
            string site = _commitStripRepository.GetSite().Result;
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(site);

            //Get the picture url
            string imageSource = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='excerpt']//a//img").Attributes["src"].Value;

            return imageSource;
        }
    }
}
