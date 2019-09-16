using System;
using WallpaperMaster.DAL;
using WallpaperMaster.Service;

namespace WallpaperMaster.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Repo
            HttpRepository httpRepository = new HttpRepository();
            WallPaperRepository wallPaperRepository = new WallPaperRepository();

            //Service
            CommitStripService commitStripService = new CommitStripService(httpRepository);
            
            commitStripService.SaveLatestStrip(@"C:\Temp\wallpaper.jpg");

            Console.WriteLine("Got the fucking picture");
        }
    }
}
