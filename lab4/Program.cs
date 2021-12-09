using System;
using System.Collections.Generic;
using System.Linq;

namespace lab4
{
    public class Owner
    {
        public int ID;
        public string Name;
        public string Organization;

        public Owner()
        {
            ID = 4;
            Name = "Dmitry";
            Organization = "BSTU";
        }
    }

    public class Set
    {

        public Owner myOwner = new Owner();

        public static class Date
        {
            public static DateTime date = new DateTime(2021, 10, 8);
        }

        public List<int> mySet;
        public Set(List<int> localSet)
        {

            this.mySet = localSet;
        }

        public static Set operator -(Set set1, int item1)
        {
            set1.mySet.Remove(item1);
            return set1;
        }

        public static Set operator *(Set set1, Set set2)
        {
            var finalSet = new Set(new List<int>());
            foreach(var s in set1.mySet)
            {
                if (set2.mySet.Contains(s))
                {
                    finalSet.mySet.Add(s);
                }
            }
            return finalSet;
        }

        public static bool operator <(Set set1, Set set2)
        {
            int am1 = set1.mySet.Count;
            int am2 = set2.mySet.Count;
            if(am1 <= am2)
            {
                Console.WriteLine("1 множество меньше 2");
                return false; // 1 множество меньше 2
            }
            else
            {
                Console.WriteLine("1 множество больше 2");
                return true; // 1 множество больше 2
            }
        }

        public static bool operator >(Set set1, Set set2)
        { // 1-ый параметр - подмножесто, 2-ой - множество
            int c = set1.mySet.Count;
            int counter = 0;
            foreach(var s in set1.mySet)
            {
                if (set2.mySet.Contains(s))
                {
                    counter++;
                }
            }
            if(counter == c)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //добавление элемента в множество
        public static Set operator &(Set set1, int q)
        {
            set1.mySet.Add(q);
            return set1;
        }

        public void Print()
        {
            this.mySet.ForEach(i => Console.Write(i + " "));
            Console.WriteLine();
        }

        public static void SetTest()
        {
            var newSet = new Set(new List<int>() { 0, 1, 2, 5, 6, 0, 7 });
            var newSet2 = new Set(new List<int>() { 1, 2, 5, 7 });
            newSet.Print();
            newSet2.Print();
            Console.WriteLine("Удаляем из первого множества 5");
            var test = newSet - 5;
            test.Print();
            Console.WriteLine("Добавляем в первое множество 9");
            test = newSet & 9;
            test.Print();
            Console.WriteLine("Пересечение множеств: ");
            newSet.Print();
            newSet2.Print();
            Console.WriteLine("Результат");
            test = newSet2 * newSet;
            test.Print();
            Console.WriteLine("Сравниваем два множества");
            Console.WriteLine(newSet2 < newSet);
            Console.WriteLine("Включает ли 1 множество в себе 2");
            newSet.Print();
            newSet2.Print();
            Console.WriteLine(newSet2 > newSet);
            test = newSet2 - 5;
            newSet.Print();
            newSet2.Print();
            Console.WriteLine(newSet2 > newSet);
        }
    }

    public static class StatisticOperation
    {
        public static string AddPoint(this string str)
        {
            str += '.';
            return str;
        }

        public static Set RemoveZero(this Set set1)
        {
            while (set1.mySet.Remove(0))
            {

            }
            return set1;
        }

        public static int Sum(Set set1, Set set2)
        {
            return set1.mySet.Count + set2.mySet.Count;
        }

        public static int Diff(Set set1)
        {
            return set1.mySet.Max() - set1.mySet.Min();
        }

        public static int Length(Set set1)
        {
            return set1.mySet.Count;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Set.SetTest();
            var newSet = new Set(new List<int>() { 0, 1, 2, 5, 6, 0, 7 });
            Console.WriteLine(newSet.myOwner.Name);
        }
    }
}
