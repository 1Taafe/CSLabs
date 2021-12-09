using System;
using System.Collections.Generic;
using System.Linq;

namespace lab11
{

    public class CardType
    {
        public string Name { set; get; }
        public CardType(string name)
        {
            Name = name;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] months = { "January", "February", "March", "April", "May",
                "June", "July", "August", "September", "October", "November", "December"
            };
            int n = 4;

            //List<string> selectedStrings = new List<string>();
            var selectedItems = from s in months
                                where s.Length == n
                                select s;

            foreach (var s in selectedItems)
            {
                Console.WriteLine(s);
            }

            selectedItems = from s in months
                            where Array.IndexOf(months, s) < 2 || (Array.IndexOf(months, s) > 4
                            && Array.IndexOf(months, s) < 8) || Array.IndexOf(months, s) == 11
                            select s;

            Console.WriteLine();

            foreach (var s in selectedItems)
            {
                Console.WriteLine(s);
            }

            selectedItems = from s in months
                            orderby s
                            select s;

            Console.WriteLine();

            foreach (var s in selectedItems)
            {
                Console.WriteLine(s);
            }

            selectedItems = from s in months
                            where s.Contains('u') && s.Length > 4
                            select s;

            Console.WriteLine();

            foreach (var s in selectedItems)
            {
                Console.WriteLine(s);
            }

            List<Customer> myCustomers = new List<Customer>();
            myCustomers.Add(new Customer("Zayankovsky", "Dmitry", "Vladimirovich", "Oshmyany", 4330358755699874, 699.75));
            myCustomers.Add(new Customer("Adamovich", "Anton", "Maksimovich", "Cherven", 4785968574857433, 145.99));
            myCustomers.Add(new Customer("Petrov", "Ivan", "Pavlovich", "Minsk", 4785554469321141, 98699.75));
            myCustomers.Add(new Customer("Filatov", "Aleksei", "Vladimirovich", "Vitebsk", 4331755588689999, 68.86));
            myCustomers.Add(new Customer("Ivanov", "Petr", "Stepanovich", "Grodno", 3589997752144638, 1677.78));
            myCustomers.Add(new Customer("Smelov", "Andrei", "Petrovich", "Oshmyany", 4330112244559874, 64449.45));
            myCustomers.Add(new Customer("Livanov", "Maksim", "Andreevich", "Oshmyany", 3475869321447748, 1114.75));
            myCustomers.Add(new Customer("Prostoi", "Dmitry", "Nikolaevich", "Mogilev", 4788559966332245, 675.00));
            myCustomers.Add(new Customer("Timoshenko", "Alena", "Alekseevna", "Turov", 4311458744775599, 8547.95));
            myCustomers.Add(new Customer("Zenkovich", "Nadezhda", "Vladimirovna", "Oshmyany", 4330358755697777, 47896.97));

            Console.WriteLine();

            var selectedItems2 = from s in myCustomers
                            orderby s.Surname
                            select s;

            foreach(var s in selectedItems2)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine();

            var selectedItems3 = myCustomers.Where(s => s.CreditCardNumber >= 3000000000000000 && s.CreditCardNumber <= 3999999999999999);

            foreach (var s in selectedItems3)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine();

            var item = myCustomers.OrderByDescending(s => s.Balance).First();
                      

            Console.WriteLine(item);

            Console.WriteLine();

            var newItems = myCustomers.Where(s => s.CreditCardNumber >= 4000000000000000 && s.CreditCardNumber <= 4999999999999999)
                                      .OrderByDescending(s => s.Surname)
                                      .SkipLast(1)
                                      .ToList();
                                      
            
            foreach(var s in newItems)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine();

            var newType = myCustomers.Join(
                myCustomers,
                w => w.Name,
                q => q.Name,
                (w, q) => new { id = q.ID, name = w.Name }).Distinct().OrderBy(o => o.name);

            foreach(var s in newType)
            {
                Console.WriteLine(s);
            }
        }
    }
}
