using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace lab13
{
    public static class ZDVFileInfo
    {
        private static string Location = @"C:\Users\dima7\source\repos\lab13\testFile.txt";
        private static FileInfo myFile = new FileInfo(Location);

        public static void FullPath()
        {
            string strInfo = $"Путь к файлу: {myFile.FullName}";
            Console.WriteLine(strInfo);
            ZDVLog.Write(strInfo);
        }

        public static void InfoPart()
        {
            double fileSize = Math.Round(myFile.Length / Math.Pow(1024.0, 3.0), 2);
            string strInfo = $"Имя: {myFile.Name} | Размер: {fileSize} | Аттрибуты: {myFile.Attributes} ";
            Console.WriteLine(strInfo);
            ZDVLog.Write(Location, strInfo);
        }

        public static void FileTime()
        {
            string strInfo = $"Дата создания: {myFile.CreationTime} | Дата изменения: {myFile.LastWriteTime}";
            Console.WriteLine(strInfo);
            ZDVLog.Write(Location, strInfo);
        }
    }
}
