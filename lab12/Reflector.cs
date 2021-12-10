using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;
using System.IO;

namespace lab12
{
    public static class Reflector
    {
        public static string GetAssemblyName(object o)
        {
            Type newType = o.GetType();
            Assembly newAssem = Assembly.GetAssembly(newType);
            Console.WriteLine("Имя сборки: " + newAssem.FullName);

            string writePath = @"C:\Users\dima7\source\repos\lab12\getAssemblyName.txt";
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(newAssem.FullName);
            }

            return newAssem.FullName;
        }

        public static bool HasPublicConstructors(object o)
        {
            Type newType = o.GetType();
            int counter = 0;
            foreach (var s in newType.GetConstructors())
            {
                if (s.IsPublic)
                {
                    counter++;
                }
            }

            string writePath = @"C:\Users\dima7\source\repos\lab12\HasPublicConstructors.txt";
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                if (counter > 0)
                {
                    sw.WriteLine(true);
                }
                else
                {
                    sw.WriteLine(false);
                }
            }

            if (counter > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static IEnumerable<string> GetPublicMethods(object o)
        {
            Type newType = o.GetType();
            var methods = newType.GetMethods();
            List<string> newList = new List<string>();
            foreach(var s in methods)
            {
                newList.Add(s.ToString());
            }
            string writePath = @"C:\Users\dima7\source\repos\lab12\GetPublicMethods.txt";
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                foreach(var s in newList)
                {
                    sw.WriteLine(s);
                }
            }
            return newList;
        }

        public static IEnumerable<string> GetFieldsAndProps(object o)
        {
            Type newType = o.GetType();
            var props = newType.GetProperties();
            var fields = newType.GetFields();
            List<string> newList = new List<string>();
            foreach(var s in props)
            {
                newList.Add(s.ToString() + " | Свойство");
            }
            foreach(var s in fields)
            {
                newList.Add(s.ToString() + " | Поле");
            }
            string writePath = @"C:\Users\dima7\source\repos\lab12\GetFieldsAndProps.txt";
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                foreach (var s in newList)
                {
                    sw.WriteLine(s);
                }
            }
            return newList;
        }

        public static IEnumerable<string> GetInterfaces(object o)
        {
            Type newType = o.GetType();
            var ints = newType.GetInterfaces();
            List<string> newList = new List<string>();
            foreach(var s in ints)
            {
                newList.Add(s.ToString());
            }
            string writePath = @"C:\Users\dima7\source\repos\lab12\GetInterfaces.txt";
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                foreach (var s in newList)
                {
                    sw.WriteLine(s);
                }
            }
            return newList;
        }

        public static IEnumerable<string> GetMethodsByParam(object o, Type t)
        {
            Type newType = o.GetType();
            var methods = newType.GetMethods();
            var result = methods.Where(a => a.GetParameters().Where(s => s.ParameterType == t).Count() != 0);
            Console.WriteLine($"Методы с параметром {t}:");
            List<string> newList = new List<string>();
            foreach(var s in result)
            {
                newList.Add(s.ToString());
            }
            string writePath = @"C:\Users\dima7\source\repos\lab12\GetMethodsByParam.txt";
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                foreach (var s in newList)
                {
                    sw.WriteLine(s);
                }
            }
            return newList;
        }

        public static void Invoke(object o, string methodName)
        {
            Type type = o.GetType();
            string filePath = @"C:\Users\dima7\source\repos\lab12\out.txt";
            List<string> paramsList = new List<string>();

            using (StreamReader sr = new StreamReader(filePath, Encoding.Default))
            {
                while(!sr.EndOfStream)
                {
                    string s = sr.ReadLine();
                    paramsList.Add(s);
                }
            }

            var method = type.GetMethod(methodName);
            List<double> doubleParam1 = new List<double>();
            foreach(var l in paramsList)
            {
                doubleParam1.Add(Convert.ToDouble(l));
            }

            double[] ds = new double[doubleParam1.Count];
            for(int i = 0; i < ds.Length; i++)
            {
                ds[i] = doubleParam1[i];
            }

            object objC = Activator.CreateInstance(type);
            if (paramsList.Count() != 0)
                method.Invoke(objC, new object[] { ds });
            else
                method.Invoke(objC, new object[] { });
        }

        public static object Create(object o)
        {
            Type newType = o.GetType();
            object res = Activator.CreateInstance(newType);
            return res;
        }
    }
}
