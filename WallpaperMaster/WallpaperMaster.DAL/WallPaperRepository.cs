using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WallpaperMaster.DAL
{
    public class WallPaperRepository
    {
        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        public static extern int SystemParametersInfo(UAction uAction, int uParam, StringBuilder lpvParam, int fuWinIni);
        public enum UAction
        {
            /// <summary>
            /// set the desktop background image
            /// </summary>
            SPI_SETDESKWALLPAPER = 0x0014,
            /// <summary>
            /// set the desktop background image
            /// </summary>
            SPI_GETDESKWALLPAPER = 0x0073,
        }
        public int SetBackGround(string wallpaperFile)
        {
            int result = 0;
            if (File.Exists(wallpaperFile))
            {
                StringBuilder s = new StringBuilder(wallpaperFile);
                result = SystemParametersInfo(UAction.SPI_SETDESKWALLPAPER, 0, s, 0x2);
            }
            return result;
        }
    }
}
