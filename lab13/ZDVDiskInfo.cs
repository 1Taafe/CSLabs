using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace lab13
{
    public class ZDVDiskInfo
    {
        private static DriveInfo[] allDrives = DriveInfo.GetDrives();
        public static void FreeSpace()
        {
            List<string> info = new List<string>();
            foreach(var s in allDrives)
            {
                Console.WriteLine(s.Name + "\t" + Math.Round((s.AvailableFreeSpace / Math.Pow(1024.0, 3.0)), 2) + " (GB) Available space ");
                info.Add(s.Name + "\t" + Math.Round((s.AvailableFreeSpace / Math.Pow(1024.0, 3.0)), 2) + " (GB) Available space ");
            }
            ZDVLog.Write(info);
            Console.WriteLine();
        }

        public static void DriveFormat()
        {
            List<string> info = new List<string>();
            foreach (var s in allDrives)
            {
                Console.WriteLine(s.Name + "\t" + s.DriveFormat + " drive format ");
                info.Add(s.Name + "\t" + s.DriveFormat + " drive format ");
            }
            ZDVLog.Write(info);
            Console.WriteLine();
        }

        public static void FullInfo()
        {
            List<string> info = new List<string>();
            foreach (var s in allDrives)
            {
                double totalSize = Math.Round(s.TotalSize / Math.Pow(1024.0, 3.0), 2);
                double freeSpace = Math.Round(s.TotalFreeSpace / Math.Pow(1024.0, 3.0), 2);
                string strInfo = $"{s.Name} | {s.VolumeLabel} | {totalSize} (Gb) total space | {freeSpace} (Gb) total FREE space";
                Console.WriteLine(strInfo);
                info.Add(strInfo);
            }
            ZDVLog.Write(info);
            Console.WriteLine();
        }
    }
}
