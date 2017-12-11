using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using NUnit.Framework;

namespace albumFinder
{
    public class MusicManager
    {
        //public string musicFolder { get; set; }
        private List<string> musicExtensions = new List<string>(){"mp3", "wma", "ogg", "wav", "m4a", "m4p", "aac"};

        public List<string> GetFolders(string folder)
        {
            List<string> directories = new List<string>();
            foreach (var directory in Directory.GetDirectories(folder))
            {
                directories.Add(directory);
                foreach (var subDirectory in GetFolders(directory))
                {
                    directories.Add(subDirectory);
                }
            }
            return directories;
        }

        public List<string> GetFiles(string musicFilesPath)
        {
            return Directory.GetFiles(musicFilesPath).ToList();
        }

        public bool IsMusicFolder(string path)
        {
            var musicFilesCount = 0;
            foreach (var file in GetFiles(path))
            {
                if (musicExtensions.Contains(new FileInfo(file).Extension.Substring(1)))
                    musicFilesCount++;
            }

            return musicFilesCount >= 5;
        }
    }
}