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
        public string musicTopFolderPath = "C:\\Bin\\Music";
        public string musicFilesPath =  @"C:\Bin\Music\Queen\Greatest Hits I";

        [Test]
        public void GetFolders_In_Music_Directory_Returns_All_Sub_Folders()
        {
            var musicManager = new MusicManager();

            var musicFolders = musicManager.GetFolders(musicTopFolderPath);

            Assert.That(15, Is.EqualTo(musicFolders.Count));
        }

        [Test]
        public void GetFiles_In_A_Directory_Returns_All_Files()
        {
            var musicManager = new MusicManager();

            var musicFiles = musicManager.GetFiles(musicFilesPath);

            Assert.That(4, Is.EqualTo(musicFiles.Count));
        }



    }
}
