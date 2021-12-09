using System;
using System.Collections.Generic;
using System.Linq;

namespace lab6
{
    interface IRemove
    {
        void Recycle();
    }

    class Printer
    {
        public void IAmPrinting(Plant obj)
        {
            Console.WriteLine(obj.ToString());
        }
    }

    public sealed class Paper
    {
        public string Color { set; get; }
        public bool HasUniqueStyle { set; get; }
        public bool IsTransparent { set; get; }
        public Paper(string color)
        {
            Color = color;
            HasUniqueStyle = true;
            IsTransparent = false;
        }

        public override string ToString()
        {
            return $"{GetType()} {Color} {HasUniqueStyle} {IsTransparent}";
        }
    }

    public abstract class Plant
    {
        public abstract void Recycle();
        public string Name
        {
            get; set;
        }

        public string LifeForm
        {
            get; set;
        }

        public Plant(string name, string lifeForm)
        {
            Name = name;
            LifeForm = lifeForm;
        }

        public override string ToString()
        {
            return $"{this.GetType()} {Name} {LifeForm}";
        }
    }

    public class Bush : Plant, IRemove
    {
        public string GrowLocation
        {
            get; set;
        }

        public Bush(string name, string growLocation, string lifeForm = "Кустарник") : base(name, lifeForm)
        {
            GrowLocation = growLocation;
        }

        void IRemove.Recycle()
        {
            Console.WriteLine($"Куст {Name} переработали! *Интерфейс*");
        }
        public override void Recycle()
        {
            Console.WriteLine($"Куст {Name} переработали! *Абстрактный класс*");
        }

        virtual public void Uproot()
        {
            Console.WriteLine($"Куст {Name} был выкорчеван.");
        }

        public override string ToString()
        {
            return $"{this.GetType()} {Name} {LifeForm} {GrowLocation}";
        }
    }

    public class Flower : Bush, IRemove, IComparable<Flower>
    {
        public string Color
        {
            get; set;
        }

        public int Diameter
        {
            get; set;
        }

        public double Cost;

        public Flower(string name, string growLocation, string color, int diameter, double cost) : base(name, growLocation)
        {
            Color = color;
            Diameter = diameter;
            Cost = cost;
        }

        public int CompareTo(Flower f)
        {
            return this.Name.CompareTo(f.Name);
        }

        public override void Uproot()
        {
            Console.WriteLine($"Цветок {Name} срезан для букета.");
        }

        public override void Recycle()
        {
            Console.WriteLine($"Цветок {Name} выбросили. Жаль. Получился бы отличный букет.");
        }

        public override string ToString()
        {
            return $"{this.GetType()} {Name} {LifeForm} {GrowLocation} {Color} {Diameter} \t Цена:  {Cost} р";
        }
    }

    class Roze : Flower
    {
        public bool HasThorns
        {
            get; set;
        }

        public int ThornLenth
        {
            get; set;
        }

        public Roze(string name, string growLocation, string color, int diameter, int thornLength, double cost) : base(name, growLocation, color, diameter, cost)
        {
            ThornLenth = thornLength;
            HasThorns = true;
        }

        public override void Recycle()
        {
            Console.WriteLine("Пожалуй розы лучше подарить, чем выбрасывать!");
        }

        public override string ToString()
        {
            return $"{this.GetType()} {Name} {LifeForm} {GrowLocation} {Color} {Diameter} {HasThorns} {ThornLenth} \t Цена: {Cost}";
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + ThornLenth.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                Roze m = obj as Roze; // возвращает null если объект нельзя привести к типу Roze
                if (m as Roze == null)
                    return false;

                return m.Name == this.Name && m.ThornLenth == this.ThornLenth;
            }
            else
            {
                return false;
            }

        }

    }

    class Gladiolus : Flower
    {
        public int FlowersOnStem
        {
            get; set;
        }

        public Season Season { set; get; }

        public Gladiolus(string name, string growLocation, string color, int diameter, int flowersOnStem, double cost, Season season) : base(name, growLocation, color, diameter, cost)
        {
            FlowersOnStem = flowersOnStem;
            Season = season;
        }

        public override string ToString()
        {
            return $"{this.GetType()} {Name} {LifeForm} {GrowLocation} {Color} {Diameter} {FlowersOnStem} {(int)Season}  \t Цена: {Cost}";
        }
    }

    class Cactus : Flower
    {
        public bool HasSingleFlower
        {
            get; set;
        }

        public Cactus(string name, string growLocation, string color, int diameter, double cost) : base(name, growLocation, color, diameter, cost)
        {
            HasSingleFlower = true;
        }

        public override string ToString()
        {
            return $"{this.GetType()} {Name} {LifeForm} {GrowLocation} {Color} {Diameter} {HasSingleFlower} \t Цена: {Cost}";
        }
    }

    //lab6
    enum Season : short
    {
        Winter = 1,
        Spring,
        Summer,
        Fall,
    }

    struct Buyer: IRemove
    {

        public string Name;
        public short Age;
        public bool HasDiscount;
        public Buyer(string name, short age)
        {
            Name = name;
            Age = age;
            // HasDiscount = discount;
            HasDiscount = true;
        }

        public void Recycle()
        {
            throw new NotImplementedException();
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Покупатель {Name} {Age} \t Скидка: {HasDiscount}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Bush myBush = new Bush("Шиповник", "Равнина");
            Flower myFlower = new Flower("Тюльпан", "Лес", "Желтый", 6, 9.99);
            Roze myRoze = new Roze("Роза голандская", "Равнина", "Красный", 5, 2, 14.99);
            Gladiolus myGlad = new Gladiolus("Гладиолус обычкновенный", "Лес", "Белый", 3, 4, 17.46, Season.Fall);
            Cactus myCactus = new Cactus("Кактус великий", "Пустыня", "Салатовый", 3, 29.99);
            Paper myPaper = new Paper("Розовый");
            
            Console.WriteLine($"{myBush} \n {myFlower} \n {myRoze} \n {myGlad} \n {myCactus} \n {myPaper}");

            Plant myPlant = new Bush("Малина", "Лес"); // объект Plant создать нельзя, может хранить объекты производных классов

            //Преобразование Plant в Bush
            Console.WriteLine(myBush.Name);
            Console.WriteLine(myPlant.Name + " " + myPlant.LifeForm); // не можем вывести myPlant.growLocation, нужно преобразовать к Bush
            myBush = myPlant as Bush;
            if (myBush == null)
            {
                Console.WriteLine("Преобразование НЕ удалось");
            }
            else
            {
                Console.WriteLine(myBush.Name + " " + myBush.GrowLocation);
            }

            //Преобразование Roze в Flower
            Console.WriteLine(myFlower.Name);
            if (myRoze is Flower)
            {
                myFlower = (Flower)myRoze;
                Console.WriteLine(myFlower.Name); //  Roze преобразован во Flower, получить доступ к .ThornsLength невозможно.
            }
            else
            {
                Console.WriteLine("Преобразование не допустимо");
            }

            //Ссылка на Bush типа IRemove
            IRemove theBush = new Bush("Смородина", "Лес");
            //Вызовется метод интерфейса т. к. ссылка типа IRemove
            theBush.Recycle();

            Plant newBush;
            //Преобразование IRemove в Plant
            newBush = theBush as Plant;
            if (newBush == null)
            {
                Console.WriteLine("Преобразование НЕ удалось");
            }
            else
            {
                Console.WriteLine(newBush.Name); //вывести поле growLocation не получится.
                //Вызовется метод Recycle() от Plant, т. к. ссылка типа Plant
                newBush.Recycle();
            }

            Printer myPrinter = new Printer();
            dynamic[] myArray = new dynamic[] { myPlant, myBush, myFlower, myRoze, myGlad, myCactus };
            foreach (var s in myArray)
            {
                myPrinter.IAmPrinting(s);
            }

            //lab6
            Console.WriteLine($"{Season.Winter}, {Season.Spring}, {Season.Summer}, {Season.Fall}");
            Console.WriteLine($"{(int)Season.Winter}, {(int)Season.Spring}, {(int)Season.Summer}, {(int)Season.Fall}");

            Buyer person1; 
            //person1.ShowInfo();  Вызвать метод объекта нельзя, нужно проинициализировать поля.
            person1.Name = "Ivan";
            person1.Age = 19;
            person1.HasDiscount = true;
            person1.ShowInfo();

            Buyer person2 = new Buyer();
            person2.ShowInfo();
            person2.Name = "Pavel";
            person2.Age = 29;
            person2.HasDiscount = false;
            person2.ShowInfo();

            Buyer person3 = new Buyer("Roman", 18);
            person3.ShowInfo();

            Bouquet myBouquet = new Bouquet("Прелесть", myPaper, myRoze, myGlad, myCactus);
            myBouquet.GetInfo();
            Flower myTulp = new Flower("Тюльпан", "Лес", "Желтый", 6, 8.79);
            myBouquet.AddFlower(myTulp);
            myBouquet.GetInfo();
            Controller.SortByName(myBouquet);
            myBouquet.GetInfo();
            Controller.FindByColor(myBouquet, "Желтый");
        }
    }
}
