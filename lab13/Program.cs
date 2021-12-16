using System;

namespace lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            ZDVLog.CountLogs();
            ZDVFileManager.ZDVInspect();
            ZDVFileManager.ZDVFiles(@"C:\Users\dima7\source\repos\lab13\testDir");
            ZDVFileManager.Arch();

            ZDVLog.LastHourLog();
        }
    }
}
