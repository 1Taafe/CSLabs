using System;
using System.Collections;

namespace lab10
{
    public class CEmployee
    {
        public static int CollectionAmount = 0;
        public Hashtable Collection = new Hashtable();
        public void Add(string surname, string name, byte age, string position, double salary, string organization)
        {
            Employee newEmployee = new Employee(surname, name, age, position, salary, organization);
            CollectionAmount++;
            Collection.Add(CollectionAmount, newEmployee);
        }

        public void Add(Employee employee)
        {
            CollectionAmount++;
            Collection.Add(CollectionAmount, employee);
        }

        public void Remove(int key)
        {
            Collection.Remove(key);
        }

        public void Display()
        {
            foreach (var s in Collection.Values)
            {
                Console.WriteLine(s);
            }
        }

        public void DisplayKeys()
        {
            foreach (var s in Collection.Keys)
            {
                Console.WriteLine(s);
            }
        }

        public void FindByKey(int key)
        {
            if (Collection.ContainsKey(key))
            {
                Console.WriteLine($"{key} -  {Collection[key]}");
            }
            else
            {
                Console.WriteLine("По ключу ничего не найдено!");
            }
        }

        public void FindByValue(Employee emp)
        {
            int myKey = 0;
            if (Collection.ContainsValue(emp))
            {
                foreach(var s in Collection.Keys)
                {
                    if(Collection[s] == emp)
                    {
                        myKey = (int)s;
                        Console.WriteLine($"{myKey} - {Collection[myKey]}");
                    }
                }
            }
            else
            {
                Console.WriteLine("По значению ничего не найдено!");
            }
        }

    }
}
