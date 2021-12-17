using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace lab14
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Binary
            Flower Tulp = new Flower("Тюльпан", "равнина", "красный", 7);
            Console.WriteLine(Tulp);

            BinaryFormatter bf = new BinaryFormatter();
            using(FileStream fs = new FileStream(@"C:\Users\dima7\source\repos\lab14\flower.dat", FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, Tulp);
                Console.WriteLine("Сериализация выполнена!");
            }

            using (FileStream fs = new FileStream(@"C:\Users\dima7\source\repos\lab14\flower.dat", FileMode.OpenOrCreate))
            {
                Flower desFlower = (Flower)bf.Deserialize(fs);
                Console.WriteLine("Десериализация выполнена!");
                Console.WriteLine(desFlower); //Поле со значением диаметра = 0, т. к. помечено как несериализуемое.
            }

            //XML
            XmlSerializer xmlSer = new XmlSerializer(typeof(Flower));
            Console.WriteLine(Tulp);
            using (FileStream fs = new FileStream(@"C:\Users\dima7\source\repos\lab14\flowers.xml", FileMode.OpenOrCreate))
            {
                xmlSer.Serialize(fs, Tulp);
                Console.WriteLine("Сериализация выполнена!");
            }

            using (FileStream fs = new FileStream(@"C:\Users\dima7\source\repos\lab14\flowers.xml", FileMode.OpenOrCreate))
            {
                Flower myFlower = (Flower)xmlSer.Deserialize(fs);
                Console.WriteLine("Десериализация выполнена!");
                Console.WriteLine(myFlower);
            }


            //JSON
            using (FileStream fs = new FileStream(@"C:\Users\dima7\source\repos\lab14\flowers.json", FileMode.OpenOrCreate))
            {
                Flower newTulp = new Flower("Тюльпан", "равнина", "желтый", 5);
                Console.WriteLine(newTulp);
                await JsonSerializer.SerializeAsync<Flower>(fs, newTulp);
                Console.WriteLine("Сериализация выполнена!");
            }

            using (FileStream fs = new FileStream(@"C:\Users\dima7\source\repos\lab14\flowers.json", FileMode.OpenOrCreate))
            {
                Flower resFlower = await JsonSerializer.DeserializeAsync<Flower>(fs);
                Console.WriteLine("Десериализация выполнена!");
                Console.WriteLine(resFlower);
            }

            Flower sunflower = new Flower("Подсолнух", "степь", "золотистый", 16);
            Flower unknown = new Flower();
            Flower roze = new Flower("Роза идеальная", "равнина", "алый", 8);
            List<Flower> flowers = new List<Flower>();
            flowers.Add(sunflower);
            flowers.Add(unknown);
            flowers.Add(roze);
            foreach(var f in flowers)
            {
                using (FileStream fs = new FileStream(@"C:\Users\dima7\source\repos\lab14\flowersCollection.dat", FileMode.OpenOrCreate))
                {
                    bf.Serialize(fs, f);
                    Console.WriteLine("Сериализация выполнена!");
                }

                using (FileStream fs = new FileStream(@"C:\Users\dima7\source\repos\lab14\flowersCollection.dat", FileMode.OpenOrCreate))
                {
                    Flower desFlower = (Flower)bf.Deserialize(fs);
                    Console.WriteLine("Десериализация выполнена!");
                    Console.WriteLine(desFlower); //Поле со значением диаметра = 0, т. к. помечено как несериализуемое.
                }
            }

            PathSerial.XPath();
            LINQxml.CreateXmlDoc();
            LINQxml.XmlRead();
            LINQxml.XmlQuery();
        }
    }
}
