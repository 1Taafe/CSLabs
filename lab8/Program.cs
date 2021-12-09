using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CollectionType<Plant> coll = new CollectionType<Plant>();
                Plant[] plants = { new Plant("Ежевика"), new Plant("Картофель"), new Plant("Малина"), new Plant("Капуста") };
                foreach (Plant s in plants)
                {
                    coll.Add(s);
                }

                coll.View();

                coll.WriteFile();

                coll.ReadFile();

                coll.View();

                foreach (Plant s in plants)
                {
                    coll.Remove(s);
                }

                coll.View();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Работа с коллекцией завершена!");
            }

            
        }
    }
}
