using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace albumFinder
{
    [TestFixture]
    public class UnitTest
    {
        public string musicFolderPath = "C:\\Dev\\Projects\\fileManager\\albumFinder\\albumFinder\\music";
        public string musicFilesPath = @"C:\Dev\Projects\fileManager\albumFinder\albumFinder\music\Queen\Greatest Hits I";
        public string temp = "C:\\Dev\\Projects\\fileManager\\albumFinder\\albumFinder\\temp";

        [SetUp]
        public void Setup()
        {
            if (Directory.Exists(temp))
            {
                Directory.Delete(temp, true);
            }

        }

        [Test]
        public void GetFolders_In_Music_Directory_Returns_All_Sub_Folders()
        {
            var fileManager = new FileManager();

            var musicFolders = fileManager.GetFolders(musicFolderPath);

            Assert.That(15, Is.EqualTo(musicFolders.Count));
        }

        [Test]
        public void GetFiles_In_A_Directory_Returns_All_Files()
        {
            var fileManager = new FileManager();

            var musicFiles = fileManager.GetFiles(musicFilesPath);

            Assert.That(4, Is.EqualTo(musicFiles.Count));
        }

        [Test]
        public void IsMusicFolder_Returns_True_As_It_Contains_5_Or_More_Music_Files()
        {
            string path = @"C:\Bin\Music\Queen\Best\Greatest Hits III";
            var musicManager = new MusicManager(new FileManager());

            var isMusicFolder = musicManager.IsMusicFolder(path);

            Assert.That(true, Is.EqualTo(isMusicFolder));
        }

        [Test]
        public void Get_All_Music_Folders_Returns_List_Of_Music_Folders()
        {
            var musicManager = new MusicManager(new FileManager());
            var musicFolders = musicManager.GetMusicFolders(musicFolderPath);
            
            Assert.That(4, Is.EqualTo(musicFolders.Count));
        }

        [Test]
        public void Copy_All_Music_Folders_To_Folder_Root()
        {
            var fileManager = new FileManager();
            var musicManager = new MusicManager(fileManager);

            musicManager.CopyMusicFolders(musicFolderPath, temp);

            Assert.That(4, Is.EqualTo(fileManager.GetFolders(temp).Count));
        }
    }
}
