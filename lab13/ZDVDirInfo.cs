using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace lab13
{
    public static class ZDVDirInfo
    {
        private static string dirPath = @"C:\Users\dima7\source\repos\lab13\testDir";
        private static string firstPath = @"C:\Users\dima7\source\repos\lab13";
        private static DirectoryInfo myDir = new DirectoryInfo(dirPath);
        private static DirectoryInfo firstDir = new DirectoryInfo(firstPath);

        public static void FileAmount()
        {
            int counter = 0;
            foreach(var s in myDir.EnumerateFiles())
            {
                counter++;
            }
            string strInfo = $"Кол-во файлов: {counter}";
            Console.WriteLine(strInfo);
            ZDVLog.Write(dirPath, strInfo);
        }

        public static void CreationTime()
        {
            string strInfo = $"Время создания: {myDir.CreationTime}";
            Console.WriteLine(strInfo);
            ZDVLog.Write(dirPath, strInfo);
        }

        public static void SubDirsAmount()
        {
            int counter = 0;
            foreach (var s in myDir.EnumerateDirectories())
            {
                counter++;
            }
            string strInfo = $"Кол-во поддиректорий: {counter}";
            Console.WriteLine(strInfo);
            ZDVLog.Write(dirPath, strInfo);
        }

        public static void MainDirs()
        {
            List<string> info = new List<string>();
            string strInfo = $"Родительские директории: ";
            Console.WriteLine(strInfo);
            info.Add(strInfo);
            foreach (var s in firstDir.EnumerateDirectories())
            {
                info.Add(s.ToString());
                Console.WriteLine(s.ToString());
            }
            ZDVLog.Write(firstPath, info);
        }
    }
}
