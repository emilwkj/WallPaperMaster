using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WallpaperMaster.DAL;

namespace WallpaperMaster.Service
{
    public class WallPaperService
    {
        private readonly IWallPaperRepository _wallPaperRepository;
        public WallPaperService(IWallPaperRepository wallPaperRepository)
        {
            _wallPaperRepository = wallPaperRepository;
        }

        public bool SetWallPaper(string wallpaperFile)
        {
            try
            {
                _wallPaperRepository.SetWallPaper(wallpaperFile, 1);
                return true;
            } catch
            {
                return false;
            }
        }
    }
}
