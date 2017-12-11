using System.Collections.Generic;
using System.IO;
using System.Threading;
using NUnit.Framework;

namespace albumFinder
{
    public class MusicManager
    {
        //public string musicFolder { get; set; }

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
    }
}