using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace lab15
{
    public static class Numbers
    {

        static Random rnd = new Random();
        static int value;
        public static void Simple(object n)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Users\dima7\source\repos\lab15\nums.txt", false, System.Text.Encoding.Default))
            {
                for (int i = 2; i < (int)n; i++)
                    for (int j = 2; j * j <= i; j++)
                    {
                        if (i % j == 0)
                            break;
                        else if (j + 1 > Math.Sqrt(i))
                        {
                            Console.WriteLine(i);
                            Thread.Sleep(100);
                            sw.WriteLine(i);
                        }

                    }
            }
        }

        public static void Even(object n)
        {
            for(int i = 1; i <= (int)n; i++)
            {
                if(i % 2 == 0)
                {
                    Thread.Sleep(100);
                    Console.WriteLine(i);
                    Write(i);
                }
            }
        }

        public static void Odd(object n)
        {
            for (int i = 1; i <= (int)n; i++)
            {
                if (i % 2 == 1)
                {
                    Thread.Sleep(300);
                    Console.WriteLine(i);
                    Write(i);
                }
            }
        }

        static void Write(int o)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Users\dima7\source\repos\lab15\evenANDodd.txt", true, System.Text.Encoding.Default))
            {
                sw.WriteLine(o);
            }
        }

        public static void GetRandomNumber(object o)
        {
            value = rnd.Next(0, 100);
            Console.WriteLine($"New RANDOM VALUE GENERATED : {value}");
        }
    }
}
