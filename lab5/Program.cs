using System;

namespace lab5
{
    interface IRemove
    {
        void Recycle();
        static void Hello()
        {
            Console.WriteLine("Hello world");
        }
    }

    class Printer
    {
        public void IAmPrinting(Plant obj)
        {
            Console.WriteLine(obj.ToString());
        }
    }

    sealed class Paper
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

    class Bouquet : IRemove
    {
        public string BouquetName { set; get; }
        public Paper BouquetPaper { set; get; }
        public Flower[] Flowers = new Flower[3];
        public Bouquet(string bouquetName, Paper myPaper, Roze myRoze, Gladiolus myGladiolus, Cactus myCactus)
        {
            BouquetName = bouquetName;
            BouquetPaper = myPaper;
            Flowers[0] = myRoze;
            Flowers[1] = myGladiolus;
            Flowers[2] = myCactus;
        }

        public override string ToString()
        {
            return $"{GetType()} {BouquetName} {BouquetPaper} {Flowers[0]} {Flowers[1]} {Flowers[2]}";
        }

        public void Recycle()
        {
            Console.WriteLine($"Букет {BouquetName} отправлен в переработку. ");
        }

    }

    abstract class Plant
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

    class Bush : Plant, IRemove
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

    class Flower : Bush, IRemove
    {
        public string Color
        {
            get; set;
        }

        public int Diameter
        {
            get; set;
        }

        public Flower(string name, string growLocation, string color, int diameter) : base(name, growLocation)
        {
            Color = color;
            Diameter = diameter;
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
            return $"{this.GetType()} {Name} {LifeForm} {GrowLocation} {Color} {Diameter}";
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

        public Roze(string name, string growLocation, string color, int diameter, int thornLength) : base(name, growLocation, color, diameter)
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
            return $"{this.GetType()} {Name} {GrowLocation} {Color} {Diameter} {HasThorns} {ThornLenth}";
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

        public Gladiolus(string name, string growLocation, string color, int diameter, int flowersOnStem) : base(name, growLocation, color, diameter)
        {
            FlowersOnStem = flowersOnStem;
        }

        public override string ToString()
        {
            return $"{this.GetType()} {Name} {LifeForm} {GrowLocation} {Color} {Diameter} {FlowersOnStem}";
        }
    }

    class Cactus : Flower
    {
        public bool HasSingleFlower
        {
            get; set;
        }

        public Cactus(string name, string growLocation, string color, int diameter) : base(name, growLocation, color, diameter)
        {
            HasSingleFlower = true;
        }

        public override string ToString()
        {
            return $"{this.GetType()} {Name} {LifeForm} {GrowLocation} {Color} {Diameter} {HasSingleFlower}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Bush myBush = new Bush("Шиповник", "Равнина");
            Flower myFlower = new Flower("Тюльпан", "Лес", "Желтый", 6);
            Roze myRoze = new Roze("Роза голандская", "Равнина", "Красный", 5, 2);
            Gladiolus myGlad = new Gladiolus("Гладиолус обычкновенный", "Лес", "Белый", 3, 4);
            Cactus myCactus = new Cactus("Кактус великий", "Пустыня", "Салатовый", 3);
            Paper myPaper = new Paper("Розовый");
            Bouquet myBouquet = new Bouquet("Прелесть", myPaper, myRoze, myGlad, myCactus);
            Console.WriteLine($"{myBush} \n {myFlower} \n {myRoze} \n {myGlad} \n {myCactus} \n {myPaper} \n {myBouquet}");

            Plant myPlant = new Bush("Малина", "Лес"); // объект Plant создать нельзя, может хранить объекты производных классов

            //Преобразование Plant в Bush
            Console.WriteLine(myBush.Name);
            Console.WriteLine(myPlant.Name + " " + myPlant.LifeForm); // не можем вывести myPlant.growLocation, нужно преобразовать к Bush
            myBush = myPlant as Bush;
            if( myBush == null)
            {
                Console.WriteLine("Преобразование НЕ удалось");
            }
            else{
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
            dynamic[] myArray = new dynamic[] {myPlant, myBush, myFlower, myRoze, myGlad, myCactus};
            foreach(var s in myArray)
            {
                myPrinter.IAmPrinting(s);
            }
            IRemove.Hello();
            myBush.Recycle();
            ((IRemove) myBush).Recycle();
        }
    }
}
