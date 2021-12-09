using System;
using System.Text;

namespace lab2_task2
{
    class Program
    {
        static void Main(string[] args)
        {
            //task a
            string a = "hello world!!!!";
            string b = "Hello. I think the weather is fine today, isn't it?";
            Console.WriteLine(string.Compare(a, b));

            //task b
            string b1 = "Hello";
            string b2 = "The string that hasn't got any usefull information!";
            string b3 = "Apple";
            Console.WriteLine(string.Concat(b1, b3));
            Console.WriteLine(string.Copy(b1));


            Console.WriteLine(b2.Substring(10));
            string[] b4 = b2.Split(" ");
            foreach(var sub in b4)
            {
                Console.WriteLine($"Substrings of b4 are: {sub}");
            }
            Console.WriteLine(b2.Insert(4, b1));
            Console.WriteLine(b2.Remove(25));
            Console.WriteLine($"String b1: {b1} \n String b3: {b3}");

            //task c
            string str1 = "";
            string str2 = null;

            if (string.IsNullOrEmpty(str1))
            {
                Console.WriteLine("str1 is null or empty");
            }

            if (string.IsNullOrEmpty(str2))
            {
                Console.WriteLine("str2 is null or empty");
            }

            //task d

            StringBuilder myString = new StringBuilder("The clouds are disappearing!");
            Console.WriteLine(myString.Remove(4, 6));
            Console.WriteLine(myString.Append(" Sun is shining!"));
            Console.WriteLine(myString.Insert(0, "At the same time "));
        }
    }
}
