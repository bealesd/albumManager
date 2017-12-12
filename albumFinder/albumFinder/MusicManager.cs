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
        private List<string> musicExtensions = new List<string>(){"mp3", "wma", "ogg", "wav", "m4a", "m4p", "aac"};
        private FileManager _fileManager;

        public MusicManager(FileManager fileManager)
        {
            _fileManager = fileManager;
        }
        public bool IsMusicFolder(string path)
        {
            var musicFilesCount = 0;
            foreach (var file in _fileManager.GetFiles(path))
            {
                if (musicExtensions.Contains(new FileInfo(file).Extension.Substring(1)))
                    musicFilesCount++;
            }
            return musicFilesCount >= 5;
        }

        public List<string> GetMusicFolders(string folder)
        {
            var musicFolders = new List<string>();
            foreach (var subFolder in _fileManager.GetFolders(folder))
            {
                if (IsMusicFolder(subFolder))
                    musicFolders.Add(subFolder);
            }
            return musicFolders;
        }

        public void CopyMusicFolders(string folder, string outputDirectory)
        {
            var musicFolders = GetMusicFolders(folder);
            foreach (var musicFolder in musicFolders)
            {
                foreach (FileInfo file in new DirectoryInfo(musicFolder).GetFiles())
                {
                    var newDirectory = Path.Combine(outputDirectory, file.Directory.Name);

                    if ( !Directory.Exists(newDirectory))
                        Directory.CreateDirectory(newDirectory);

                    file.CopyTo(Path.Combine(newDirectory, file.Name));
                }
            }
        }
    }
}