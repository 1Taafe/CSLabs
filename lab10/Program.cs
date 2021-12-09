using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList mylist = new List();
            Employee myEe = new Employee("Адамович", "Антон", 18, "Python-девелопер", 999999.99, "Wargaming.net");
            foreach(var s in myEe)
            {
                Console.WriteLine(s);
            }

            Employee newEmp = new Employee("Иванов", "Петр", 24);

            CEmployee eCollection = new CEmployee();

            eCollection.Add(myEe);
            eCollection.Add(newEmp);
            eCollection.Add("Филатов", "Алексей", 21, "TypeScript Junior Developer", 1234.89, "IsSoft");
            eCollection.Display();
            eCollection.DisplayKeys();
            eCollection.Remove(3);
            eCollection.Display();
            eCollection.FindByKey(2);
            eCollection.FindByValue(myEe);

            //
            Hashtable myTable = new Hashtable();
            int a = 16;
            char b = 'D';
            byte c = 2;
            double d = 147.999;
            myTable.Add(a.GetHashCode(), a);
            myTable.Add(b.GetHashCode(), b);
            myTable.Add(c.GetHashCode(), c);
            myTable.Add(d.GetHashCode(), d);

            foreach(var s in myTable.Values)
            {
                Console.WriteLine(s);
            }

            int n = 2;
            int k = 1;
            int am = myTable.Count;
            //Удаление n элементов
            Hashtable copy = (Hashtable)myTable.Clone();
            foreach(var s in copy.Keys)
            {
                if(k > n)
                {
                    break;
                }
                myTable.Remove(s);
                k++;
            }

            Console.WriteLine();

            foreach (var s in myTable.Values)
            {
                Console.WriteLine(s);
            }

            int e = 227;
            char f = 'S';
            myTable.Add(e.GetHashCode(), e);
            myTable.Add(f.GetHashCode(), f);

            Console.WriteLine();

            foreach (var s in myTable.Values)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine();

            ArrayList myArray = new ArrayList();
            foreach(var s in myTable.Values)
            {
                myArray.Add(s);
            }

            foreach(var s in myArray)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine();

            if(myArray.IndexOf(f) != -1)
            {
                Console.WriteLine(myArray[myArray.IndexOf(f)]);
            }

            //
            ObservableCollection<Employee> Emp = new ObservableCollection<Employee>();
            Emp.CollectionChanged += EmployeeNotification;
            Emp.Add(myEe);
            Emp.Add(newEmp);
            Emp.Remove(myEe);
        }

        private static void EmployeeNotification(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // если добавление
                    Employee newEmployee = e.NewItems[0] as Employee;
                    Console.WriteLine($"Добавлен новый объект: {newEmployee.Name}");
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    Employee oldEmployee = e.OldItems[0] as Employee;
                    Console.WriteLine($"Удален объект: {oldEmployee.Name}");
                    break;
            }
        }
    }
}
