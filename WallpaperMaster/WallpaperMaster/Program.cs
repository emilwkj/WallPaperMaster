using System;
using WallpaperMaster.DAL;
using WallpaperMaster.Service;

namespace WallpaperMaster.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpRepository httpRepository = new HttpRepository();
            WallPaperRepository wallPaperRepository = new WallPaperRepository();
            DataRepository dataRepository = new DataRepository();

            //Service
            CommitStripService commitStripService = new CommitStripService(httpRepository, dataRepository);
            WallPaperService wallPaperService = new WallPaperService(wallPaperRepository);

            //variables
            string wallPaperSaveLocation = @"C:\Temp\wallpaper.jpg";

            //Do the actual work
            if(args.Length > 0 && args[0] == "2")
            {
                commitStripService.SaveNextStribInOrder(wallPaperSaveLocation);
            }
            else
            {
                commitStripService.SaveLatestStrip(wallPaperSaveLocation);
            }
            wallPaperService.SetWallPaper(wallPaperSaveLocation);

            //Write status to user
            Console.WriteLine("Jaw jo, your wallpaper has been changed");
        }
    }
}
