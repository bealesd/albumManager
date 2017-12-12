using System;

namespace albumFinder
{
    public static class UserInputReader
    {
        public static string GetFolder(string userMessage, FileManager fileManager)
        {
            Console.WriteLine(userMessage);
            string folder = Console.ReadLine();
            while (!fileManager.IsFolder(folder))
            {
                Console.WriteLine("Folder doesn't exist.");
                folder = Console.ReadLine();
            }
            return folder;
        }
        public static string CreateFolder(string userMessage, FileManager fileManager)
        {
            Console.WriteLine(userMessage);
            string folder = Console.ReadLine();
            while (!fileManager.CreateFolder(folder))
            {
                Console.WriteLine("Folder can't be created.");
                folder = Console.ReadLine();
            }
            return folder;
        }
    }
}