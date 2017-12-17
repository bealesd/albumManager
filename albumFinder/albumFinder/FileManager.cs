using System.Collections.Generic;
using System.IO;
using System.Linq;;

namespace albumFinder
{
    public class FileManager
    {
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

        public bool IsFolder(string folder)
        {
            return Directory.Exists(folder);
        }

        public bool CreateFolder(string folder)
        {
            Directory.CreateDirectory(folder);
            return IsFolder(folder);
        }
    }
}