using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Linq;

namespace lab14
{
    public static class LINQxml
    {
        public static void CreateXmlDoc()
        {
            XDocument xdoc = new XDocument();
            // создаем первый элемент
            XElement flower1 = new XElement("flower");
            // создаем атрибут
            XAttribute flower1NameAttr = new XAttribute("name", "Ромашка");
            XElement flower1ColorElem = new XElement("color", "белый");
            XElement flower1LocationElem = new XElement("growLocation", "равнина");
            // добавляем атрибут и элементы в первый элемент
            flower1.Add(flower1NameAttr);
            flower1.Add(flower1ColorElem);
            flower1.Add(flower1LocationElem);

            // создаем второй элемент
            XElement flower2 = new XElement("flower");
            // создаем атрибут
            XAttribute flower2NameAttr = new XAttribute("name", "Роза");
            XElement flower2ColorElem = new XElement("color", "красный");
            XElement flower2LocationElem = new XElement("growLocation", "степь");
            // добавляем атрибут и элементы в первый элемент
            flower2.Add(flower2NameAttr);
            flower2.Add(flower2ColorElem);
            flower2.Add(flower2LocationElem);

            // создаем третий элемент
            XElement flower3 = new XElement("flower");
            // создаем атрибут
            XAttribute flower3NameAttr = new XAttribute("name", "Гладиолус");
            XElement flower3ColorElem = new XElement("color", "белый");
            XElement flower3LocationElem = new XElement("growLocation", "степь");
            // добавляем атрибут и элементы в первый элемент
            flower3.Add(flower3NameAttr);
            flower3.Add(flower3ColorElem);
            flower3.Add(flower3LocationElem);

            // создаем корневой элемент
            XElement myFlowers = new XElement("flowers");
            // добавляем в корневой элемент
            myFlowers.Add(flower1);
            myFlowers.Add(flower2);
            myFlowers.Add(flower3);
            // добавляем корневой элемент в документ
            xdoc.Add(myFlowers);
            //сохраняем документ
            xdoc.Save(@"C:\Users\dima7\source\repos\lab14\flowersLINQ.xml");
        }

        public static void XmlRead()
        {
            Console.WriteLine();
            XDocument xdoc = XDocument.Load(@"C:\Users\dima7\source\repos\lab14\flowersLINQ.xml");
            foreach (XElement flowerElement in xdoc.Element("flowers").Elements("flower"))
            {
                XAttribute nameAttribute = flowerElement.Attribute("name");
                XElement colorElement = flowerElement.Element("color");
                XElement locationElement = flowerElement.Element("growLocation");

                if (nameAttribute != null && colorElement != null && locationElement != null)
                {
                    Console.WriteLine($"Название цветка: {nameAttribute.Value}");
                    Console.WriteLine($"Цвет: {colorElement.Value}");
                    Console.WriteLine($"Место: {locationElement.Value}");
                }
                Console.WriteLine();
            }
        }

        public static void XmlQuery()
        {
            XDocument xdoc = XDocument.Load(@"C:\Users\dima7\source\repos\lab14\flowersLINQ.xml");
            var items = from xe in xdoc.Element("flowers").Elements("flower")
                        where xe.Element("growLocation").Value == "степь"
                        select new Flower
                        {
                            Name = xe.Attribute("name").Value,
                            Color = xe.Element("color").Value,
                            GrowLocation = xe.Element("growLocation").Value
                        };

            foreach (var item in items)
                Console.WriteLine(item);

            items = from xe in xdoc.Element("flowers").Elements("flower")
                    where xe.Element("color").Value == "белый"
                    select new Flower
                    {
                        Name = xe.Attribute("name").Value,
                        Color = xe.Element("color").Value,
                        GrowLocation = xe.Element("growLocation").Value
                    };

            Console.WriteLine(); 

            foreach (var item in items)
                Console.WriteLine(item);
        }
    }
}
