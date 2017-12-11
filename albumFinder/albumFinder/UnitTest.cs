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
        public string musicFilePath = "C:\\Bin\\Music";

        [Test]
        public void List_All_Folders_In_Music_Direcotry()
        {
            //Arrange
            var musicManager = new MusicManager();//{ musicFolder = musicFilePath};
            //Act
            var musicFolders = musicManager.GetFolders(musicFilePath);
            //Assert
            Assert.That(15, Is.EqualTo(musicFolders.Count));
        }


    }
}
