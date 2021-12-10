using System;
using System.Reflection;
using System.Collections.Generic;

namespace lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer cust = new Customer("Adamovich", "Anton", "Maksimovich");
            List<int> list = new List<int>();
            string me = "Dmitry";
            Type intType = 1.GetType();

            Reflector.GetAssemblyName(cust);
            Reflector.GetFieldsAndProps(cust);
            Reflector.GetInterfaces(list);
            Reflector.GetMethodsByParam(me, intType);
            Reflector.GetPublicMethods(list);
            Reflector.HasPublicConstructors(cust);

            Reflector.Invoke(cust, "printDoubles");

            var s = Reflector.Create(cust);
            Console.WriteLine(s.GetType());
        }
    }
}
