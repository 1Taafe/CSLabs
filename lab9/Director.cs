using System;
using System.Collections.Generic;
using System.Text;

namespace lab9
{
    public delegate void DirectorHandler(string message);

    public class Worker
    {
        public event DirectorHandler RaiseNotify;
        public event DirectorHandler DropNotify;
        public double Sum { get; private set; }
        public Worker(double sum)
        {
            Sum = sum;
        }

        public void Raise(double sum)
        {
            Sum += sum;
            RaiseNotify?.Invoke($"Прибавка к зарплате: {sum}");
        }

        public void Drop(double sum)
        {
            if (this.Sum - sum < 0)
            {
                Console.WriteLine("Уменьшить зарплату не удалось! Она не может быть отрицательной.");
                sum = 0;
            }
            Sum -= sum;
            DropNotify?.Invoke($"Уменьшение зарплаты: {sum}");
        }
    }

    public class Driver : Worker
    {
        public Driver(double sum) : base(sum) { }
        public override string ToString() => "Водитель | Зарплата: " + this.Sum;
    }

    public class Mechanic : Worker
    {
        public Mechanic(double sum) : base(sum) { }
        public override string ToString() => "Механик | Зарплата: " + this.Sum;
    }
}
