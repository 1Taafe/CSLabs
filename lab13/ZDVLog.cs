using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace lab13
{
    public class ZDVLog
    {
        private static string WritePath = @"C:\Users\dima7\source\repos\lab13\ZDVlogfile.txt";
        public static void Write(string path, IEnumerable<string> logMessage)
        {
            using (StreamWriter sw = new StreamWriter(WritePath, true, System.Text.Encoding.Default))
            {
                sw.WriteLine(DateTime.Now);
                sw.WriteLine(path);
                foreach(var s in logMessage)
                {
                    sw.WriteLine(s);
                }
                sw.WriteLine();
            }
        }

        public static void Write(IEnumerable<string> logMessage)
        {
            using (StreamWriter sw = new StreamWriter(WritePath, true, System.Text.Encoding.Default))
            {
                sw.WriteLine(DateTime.Now);
                foreach (var s in logMessage)
                {
                    sw.WriteLine(s);
                }
                sw.WriteLine();
            }
        }

        public static void Write(string logMessage)
        {
            using (StreamWriter sw = new StreamWriter(WritePath, true, System.Text.Encoding.Default))
            {
                sw.WriteLine(DateTime.Now);
                sw.WriteLine(logMessage);
                sw.WriteLine();
            }
        }

        public static void Write(string path, string logMessage)
        {
            using (StreamWriter sw = new StreamWriter(WritePath, true, System.Text.Encoding.Default))
            {
                sw.WriteLine(DateTime.Now);
                sw.WriteLine(path);
                sw.WriteLine(logMessage);
                sw.WriteLine();
            }
        }

        public static int CountLogs()
        {
            int c = 0;
            using(StreamReader sr = new StreamReader(WritePath, true))
            {
                while (!sr.EndOfStream)
                {
                    string temp = sr.ReadLine();
                    if(temp.Length < 1)
                    {
                        c++;
                    }
                }
            }
            Console.WriteLine("Кол-во записей в логе: " + c);
            return c;
        }

        public static void LastHourLog()
        {
            Console.WriteLine();
            using (StreamReader sr = new StreamReader(WritePath, true))
            {
                while (!sr.EndOfStream)
                {
                    string temp = sr.ReadLine();
                    try
                    {
                        DateTime tempDate = DateTime.Parse(temp);
                        if (tempDate > DateTime.Now.AddHours(-1))
                        {
                            Console.WriteLine(tempDate);
                            break;
                        }
                    }
                    catch { }
                }

                while (!sr.EndOfStream)
                {
                    string temp = sr.ReadLine();
                    Console.WriteLine(temp);
                }
            }
        }
    }
}
