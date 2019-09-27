namespace WallpaperMaster.DAL
{
    public interface IWallPaperRepository
    {
        /// <summary>
        /// Sets the wallpaper
        /// </summary>
        /// <param name="tempPath"></param>
        /// <param name="style">
        /// Style of wallpaper
        /// 0 = Tiled
        /// 1 = Centered
        /// 2 = Stretched
        /// </param>
        void SetWallPaper(string tempPath, int style);
    }
}