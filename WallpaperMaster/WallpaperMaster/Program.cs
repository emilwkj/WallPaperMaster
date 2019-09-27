using System;
using WallpaperMaster.DAL;
using WallpaperMaster.Service;

namespace WallpaperMaster.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get OS Version
            var osNameAndVersion = System.Runtime.InteropServices.RuntimeInformation.OSDescription;

            //Repo
            HttpRepository httpRepository = new HttpRepository();
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
