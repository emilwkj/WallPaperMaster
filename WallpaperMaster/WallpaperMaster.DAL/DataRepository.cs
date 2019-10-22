using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallpaperMaster.DAL
{
    public class DataRepository
    {
        /// <summary>
        /// Text File Definition:
        /// Line 1: URL To first commitstrib strib on site
        /// Line 2: URL To next strib that should be shown
        /// Line 3: Date of when the wallpaper was last changed
        /// </summary>

        private readonly string _directory;
        private readonly string _file;
        private readonly string _firstCommitStrib = "http://www.commitstrip.com/en/2012/02/22/interview/";
        public DataRepository()
        {
            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            _directory = Path.Combine(appdata, "wallpapermaster");
            _file = Path.Combine(appdata, "wallpapermaster", "commitstribData.txt");

            System.IO.Directory.CreateDirectory(_directory);
            if(!File.Exists(_file))
            {
                string[] lines = { _firstCommitStrib, "", "" };
                File.WriteAllLines(_file, lines);
            }
        }
        public string GetFirstStrib()
        {
            return ReadLine(0);
        }
        public string GetNextStrib()
        {
            return ReadLine(1);
        }
        public void SetNextStrib(string nextStrib)
        {
            SetLine(1, nextStrib);
        }
        public string GetLastSetDate()
        {
            return ReadLine(2);
        }
        public void SetLastSetDate(string lastSetDate)
        {
            SetLine(2, lastSetDate);
        }

        private string ReadLine(int index)
        {
            string[] lines = new string[4];
            lines = File.ReadAllLines(_file);
            if(lines.Length >= index)
            {
                return lines[index];
            }
            return "";
        }

        private void SetLine(int index, string text)
        {
            
            string[] lines = new string[4];

            lines = File.ReadAllLines(_file);

            
            lines[index] = text;
            File.WriteAllLines(_file, lines);
        }
    }
}
