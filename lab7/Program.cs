using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace lab7
{
    interface IRemove
    {
        void Recycle();
    }

    public static class Controller
    {
        public static void SortByName(Bouquet bouquet)
        {
            bouquet.Flowers.Sort();
        }

        public static void FindByColor(Bouquet bouquet, string color)
        {
            foreach (var s in bouquet.Flowers)
            {
                if (s.Color == color)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }

    class Printer
    {
        public void IAmPrinting(Plant obj)
        {
            Console.WriteLine(obj.ToString());
        }
    }

    public class Bouquet : IRemove
    {
        public string BouquetName { set; get; }
        public Paper BouquetPaper { set; get; }
        public double Cost = 0;
        public List<Flower> Flowers { set; get; } = new List<Flower>();
        public Bouquet(string bouquetName, Paper myPaper, params Flower[] flowers)
        {
            BouquetName = bouquetName;
            BouquetPaper = myPaper;
            foreach (Flower s in flowers)
            {
                AddFlower(s);
            }
        }

        public Bouquet()
        {
            BouquetName = "Не задано";
            BouquetPaper = null;
        }

        public void AddFlower(Flower f)
        {
            Flowers.Add(f);
            Cost += f.Cost;
            Cost = Math.Round(Cost, 2);
        }

        public void RemFlower(Flower f)
        {
            Flowers.Remove(f);
        }

        public void GetInfo()
        {
            Console.WriteLine($"\n {BouquetName} \n Бумага: {BouquetPaper} \t Цена: {Cost}");
            foreach (var s in this.Flowers)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();
        }

        public void Recycle()
        {
            Console.WriteLine($"Букет {BouquetName} отправлен в переработку. ");
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
        private string color;
        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                try
                {
                    if(value == "Черный")
                    {
                        throw new FlowerExceptions.CantBeBlackException("Черные цветы нам не нужны!");
                    }
                    else
                    {
                        color = value;
                    }
                }
                catch(FlowerExceptions.CantBeBlackException e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }
        }

        public int Diameter
        {
            get; set;
        }

        private double cost;
        public double Cost
        {
            get { return cost; } 
            set
            {
                try
                {
                    if (value < 0)
                    {
                        throw new FlowerExceptions.CostLessThanZeroException("Цена цветка не может быть отрицательной!");
                    }
                    else if (value == 0)
                    {
                        throw new FlowerExceptions.CostIsZeroException("Цветы не бесплатны!");
                    }
                    else
                    {
                        cost = value;
                    }
                }
                catch(FlowerExceptions.CostLessThanZeroException e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
                catch (FlowerExceptions.CostIsZeroException e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
                
            }
        }

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
        private int flowersOnStem;
        public int FlowersOnStem
        {
            get
            {
                return flowersOnStem;
            }

            set
            {
                Debug.Assert(value >= 1 && value <= 10);
                flowersOnStem = value;
            }
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

    struct Buyer : IRemove
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
            //lab7 exceptions
            Flower testFlower = new Flower("Тюльпан", "Лес", "Желтый", 6, 9.99);
            Gladiolus myGlad = new Gladiolus("Гладиолус обычкновенный", "Лес", "Белый", 3, 1, 17.46, Season.Fall);

            //e1
            try
            {
                testFlower.Cost = 0;
            }
            catch(FlowerExceptions.CostIsZeroException e)
            {
                Console.WriteLine("Цена присвоена неверно " + e);
                Console.WriteLine(e.Message);
                Console.WriteLine(e.Source);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.TargetSite);
            }

            //e2
            try
            {
                testFlower.Cost = -15.6;
            }
            catch (FlowerExceptions.CostLessThanZeroException e)
            {
                Console.WriteLine(e.Message);
            }

            //e3
            try
            {
                testFlower.Color = "Черный";
            }
            catch (FlowerExceptions.CantBeBlackException e)
            {
                Console.WriteLine(e.Message);
            }

            //e4
            try
            {
                int a = 0;
                int b = 7 / a;
            }
            catch(DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }

            //e5
            try
            {
                int[] nums = new int[2];
                nums[3] = 15;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

            //e6
            try
            {
                checked
                {
                    int c = int.MaxValue;
                    c++;
                }
            }
            catch(OverflowException e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                int myInt1 = 0;
                int myInt2 = 5 / myInt1;
            }
            catch (OverflowException)
            {

            }
            

            //catch-finally
            catch (Exception e)
            {
                Console.WriteLine("Возникла непредвиденная ошибка, описание ошибки:");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.TargetSite);
                Console.WriteLine(e.Source);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Console.WriteLine("Finally выполняется всегда!");
            }

        }
    }
}
