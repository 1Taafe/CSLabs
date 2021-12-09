using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace lab8
{
    class CollectionType<T> : IGeneric<T> where T : class
    {
        private List<T> myCollection = new List<T>();

        private string FilePath = @"C:\Users\dima7\source\repos\lab8\myFile.txt";

        public void Add(T obj)
        {
            myCollection.Add(obj);
        }

        public void Remove(T obj)
        {
            myCollection.Remove(obj);
        }

        public void View()
        {
            foreach (T s in myCollection)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();
        }

        public void WriteFile()
        {
            try
            {
                using (StreamWriter file = new StreamWriter(FilePath, false, System.Text.Encoding.Default))
                {
                    foreach (T s in myCollection)
                    {
                        file.WriteLine(s.ToString());
                    }
                }
                Console.WriteLine("Информация записана в файл!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ReadFile()
        {
            try
            {
                using (StreamReader file = new StreamReader(FilePath, System.Text.Encoding.Default))
                {
                    string temp;
                    while ((temp = file.ReadLine()) != null)
                    {
                        Plant pl = new Plant(temp);
                        myCollection.Add(pl as T);
                    }
                    Console.WriteLine("Информация прочитана!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
