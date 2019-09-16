using System;
using WallpaperMaster.DAL;
using WallpaperMaster.Service;

namespace WallpaperMaster.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            CommitStripRepository commitStripRepository = new CommitStripRepository();
            CommitStripService commitStripService = new CommitStripService(commitStripRepository);
            commitStripService.GetPicture();
            Console.WriteLine("Got the fucking picture");
        }
    }
}
