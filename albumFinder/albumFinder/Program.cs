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
            string titleText = @"
--------------------------------------------------------------------
Esthers music soughter - it finds a folder with 5 or more songs in 
                         & copies them to your output folder!

    To use:
        1. Enter the directory containing all your music.
        2. Enter the a new output directory to put music in.

    Example
        1. C:\MyMusic
        2. C:\SoughtedMusic
--------------------------------------------------------------------";

            Console.WriteLine(titleText);
            var fileManager = new FileManager();
            var musicManager = new MusicManager(fileManager);
            string musicFolderPath = UserInputReader.GetFolder("Enter exisitng music directory: ", fileManager);
            string outputFolderPath = UserInputReader.CreateFolder("Enter new output music directory: ", fileManager);
            musicManager.CopyMusicFolders(musicFolderPath, outputFolderPath);
            Console.ReadKey();
        }
    }
}
