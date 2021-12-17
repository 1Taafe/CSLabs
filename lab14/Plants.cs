using System;
using System.Collections.Generic;
using System.Text;

namespace lab14
{
    interface IRemove
    {
        void Recycle();
    }
    [Serializable]
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

    [Serializable]
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

    [Serializable]
    public class Flower : Bush, IRemove
    {
        public string Color
        {
            get; set;
        }

        [NonSerialized]
        public int Diameter;

        public Flower() : base("Неизвестно", "Нет информации")
        {
            Color = "Цвет не задан";
            Diameter = 0;
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
}
