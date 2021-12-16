using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace lab13
{
    public static class ZDVFileManager
    {
        private static string dirDrive = @"C:\";
        //private static DirectoryInfo myDir = new DirectoryInfo(dirPath);

        public static void FilesAndDirs(string dirPath)
        {
            DirectoryInfo myDir = new DirectoryInfo(dirPath);
            List<string> info = new List<string>();
            string strInfo = $"Директории: ";
            Console.WriteLine(strInfo);
            info.Add(strInfo);
            foreach (var s in myDir.EnumerateDirectories())
            {
                info.Add(s.ToString());
                Console.WriteLine(s.ToString());
            }
            strInfo = $"Файлы: ";
            Console.WriteLine(strInfo);
            info.Add(strInfo);
            foreach (var s in myDir.EnumerateFiles())
            {
                info.Add(s.ToString());
                Console.WriteLine(s.ToString());
            }
            ZDVLog.Write(dirPath, info);
        }

        public static void ZDVInspect()
        {
            List<string> info = new List<string>();
            DirectoryInfo myDir = new DirectoryInfo(Path.Combine(dirDrive, "ZDVInspect"));
            info.Add($"Создание директории {Path.Combine(dirDrive, "ZDVInspect")}");
            myDir.Create();
            string filePath = Path.Combine(dirDrive, "ZDVInspect", "ZDVdirinfo.txt");
            using(StreamWriter sw = new StreamWriter(filePath, false))
            {
                sw.WriteLine("Hello world!");
            }
            info.Add($"Создание файла {Path.Combine(dirDrive, "ZDVInspect", "ZDVdirinfo.txt")}");
            FileInfo myFile = new FileInfo(filePath);
            try
            {
                myFile.CopyTo(Path.Combine(dirDrive, "ZDVInspect", "ZDVdirinfoNEW.txt"));
            }
            catch {
                Console.WriteLine("Файл\\Директория уже существуют и не будут созданы снова!");
            }
            info.Add($"Копирование файла {Path.Combine(dirDrive, "ZDVInspect", "ZDVdirinfoNEW.txt")}");
            myFile.Delete();
            info.Add($"Удаление файла {Path.Combine(dirDrive, "ZDVInspect", "ZDVdirinfo.txt")}");
            ZDVLog.Write(Path.Combine(dirDrive, "ZDVInspect"), info);
        }

        public static void ZDVFiles(string yourPath)
        {
            List<string> info = new List<string>();
            DirectoryInfo myDir = new DirectoryInfo(Path.Combine(dirDrive, "ZDVFiles"));
            myDir.Create();
            info.Add($"Создание директории {Path.Combine(dirDrive, "ZDVFiles")}");
            DirectoryInfo userDir = new DirectoryInfo(yourPath);
            foreach(var s in userDir.EnumerateFiles("*.txt"))
            {
                info.Add($"Копирование файла {Path.Combine(dirDrive, "ZDVFiles", s.Name)}");
                try
                {
                    s.CopyTo(Path.Combine(dirDrive, "ZDVFiles", $"{s.Name}"));
                }
                catch {
                    Console.WriteLine("Файл\\Директория уже существуют и не будут созданы снова!");
                }
            }
            info.Add($"Перемещение директории {Path.Combine(dirDrive, "ZDVInspect", "ZDVFiles")}");
            try
            {
                myDir.MoveTo(Path.Combine(dirDrive, "ZDVInspect", "ZDVFiles"));
            }
            catch {
                Console.WriteLine("Файл\\Директория уже существуют и не будут созданы снова!");
            }
            ZDVLog.Write(info);
        }

        public static void Arch()
        {
            List<string> info = new List<string>();
            string filesPath = Path.Combine(dirDrive, "ZDVInspect", "ZDVFiles");
            string zipTo = Path.Combine(dirDrive, "ZDVInspect", "myArch.zip");
            info.Add($"Создание архива {zipTo}");
            try
            {
                ZipFile.CreateFromDirectory(filesPath, zipTo);
            }
            catch {
                Console.WriteLine("Файл\\Директория уже существуют и не будут созданы снова!");
            }
            info.Add($"Разархивация в папку {@"C:\Users\dima7\source\repos\lab13\arch"}");
            try
            {
                ZipFile.ExtractToDirectory(zipTo, @"C:\Users\dima7\source\repos\lab13\arch");
            }
            catch {
                Console.WriteLine("Файл\\Директория уже существуют и не будут созданы снова!");
            }
            ZDVLog.Write(info);
        }
    }
}
