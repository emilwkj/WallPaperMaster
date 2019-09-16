using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WallpaperMaster.DAL;

namespace WallpaperMaster.Service
{
    public class WallPaperService
    {
        private readonly WallPaperRepository _wallPaperRepository;
        public WallPaperService(WallPaperRepository wallPaperRepository)
        {
            _wallPaperRepository = wallPaperRepository;
        }

        public bool SetWallPaper(string wallpaperFile)
        {
            if(_wallPaperRepository.SetBackGround(wallpaperFile) == 1)
            {
                return true;
            }
            return false;
        }
    }
}
