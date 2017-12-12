using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace albumFinder
{
    [TestFixture]
    public class UnitTest
    {
        public string musicFolderPath = "C:\\Bin\\Music";
        public string musicFilesPath =  @"C:\Bin\Music\Queen\Greatest Hits I";

        [Test]
        public void GetFolders_In_Music_Directory_Returns_All_Sub_Folders()
        {
            var musicManager = new MusicManager();

            var musicFolders = musicManager.GetFolders(musicFolderPath);

            Assert.That(15, Is.EqualTo(musicFolders.Count));
        }

        [Test]
        public void GetFiles_In_A_Directory_Returns_All_Files()
        {
            var musicManager = new MusicManager();

            var musicFiles = musicManager.GetFiles(musicFilesPath);

            Assert.That(4, Is.EqualTo(musicFiles.Count));
        }

        [Test]
        public void IsMusicFolder_Returns_True_As_It_Contains_5_Or_More_Music_Files()
        {
            string path = @"C:\Bin\Music\Queen\Best\Greatest Hits III";
            var musicManager = new MusicManager();

            var isMusicFolder = musicManager.IsMusicFolder(path);

            Assert.That(true, Is.EqualTo(isMusicFolder));
        }

        [Test]
        public void Get_All_Music_Folders_Returns_List_Of_Music_Folders()
        {
            var musicManager = new MusicManager();
            var musicFolders = musicManager.GetMusicFolders(musicFolderPath);

            Assert.That(4, Is.EqualTo(musicFolders.Count));
        }

    }
}
