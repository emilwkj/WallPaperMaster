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
            DataRepository dataRepository = new DataRepository();
            
            //Get OS Version
            var osNameAndVersion = System.Runtime.InteropServices.RuntimeInformation.OSDescription;

            //Repo
            IWallPaperRepository wallPaperRepository;

            if(osNameAndVersion.StartsWith("Microsoft Windows 10"))
            {
                wallPaperRepository = new Windows10WallPaperRepository();
            }
            //Assume windows 7
            else
            {
                wallPaperRepository = new Windows7WallPaperRepository();
            }

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
