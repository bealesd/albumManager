using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace albumFinder
{
    public class Program
    {
        static void Main(string[] args)
        {
            string musicFilePath = "C:\\Bin\\Music";
            var musicManager = new MusicManager();
            var musicFolders = musicManager.GetFolders(musicFilePath);
            musicFolders.ForEach(f => Console.WriteLine(f));
            Console.ReadKey();
        }
    }
}
