using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace lab14
{
    public static class PathSerial
    {
        public static void XPath()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"C:\Users\dima7\source\repos\lab14\flowers.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            Console.WriteLine($"\nXPath");
            Console.WriteLine("\nВсе узлы (дочерние):  ");
            XmlNodeList childNodes = xRoot.SelectNodes("*");
            foreach (XmlNode node in childNodes)
            {
                Console.WriteLine(node.OuterXml);
            }

            Console.WriteLine("\nТекущий узел + потомки:  ");
            XmlNodeList currentNodes = xRoot.SelectNodes(".");
            foreach (XmlNode node in currentNodes)
            {
                Console.WriteLine(node.OuterXml);
            }

            Console.WriteLine("\nРодительский узел + потомки:  ");
            XmlNodeList parentNodes = xRoot.SelectNodes("..");
            foreach (XmlNode node in parentNodes)
            {
                Console.WriteLine(node.OuterXml);
            }
        }
    }
}
