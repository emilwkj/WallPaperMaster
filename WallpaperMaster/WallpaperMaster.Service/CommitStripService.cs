using System;
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
        public void GetPicture()
        {

        }
    }
}
