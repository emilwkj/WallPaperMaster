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
            WallPaperService wallPaperService = new WallPaperService(wallPaperRepository);

            //variables
            string wallPaperSaveLocation = @"C:\Temp\wallpaper.jpg";

            //Do the actual work
            commitStripService.SaveLatestStrip(wallPaperSaveLocation);
            wallPaperService.SetWallPaper(wallPaperSaveLocation);

            //Write status to user
            Console.WriteLine("Jaw jo, your wallpaper has been changed");
        }
    }
}
