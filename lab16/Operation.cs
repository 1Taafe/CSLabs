using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab16
{
    public static class Operation
    {
        public static CancellationTokenSource myToken = new CancellationTokenSource();
        public static void Simple()
        {
            Console.Write($"CurrentTask ID: {Task.CurrentId} \n\n");

            int n = 1200;
            var numbers = new List<uint>();
            //заполнение списка числами от 2 до n-1
            for (var i = 2u; i < n; i++)
            {
                numbers.Add(i);
            }

            if (myToken.IsCancellationRequested)
            {
                Console.WriteLine("TASK STOPPED");
                return;
            }

            for (var i = 0; i < numbers.Count; i++)
            {
                for (var j = 2u; j < n; j++)
                {
                    //удаляем кратные числа из списка
                    numbers.Remove(numbers[i] * j);
                }
            }

            foreach (var s in numbers)
            {
                Console.WriteLine(s);
            }
        }

        public static int Task1()
        {
            return 111;
        }

        public static int Task2()
        {
            return 222;
        }

        public static int Task3()
        {
            return 333;
        }

        public static void CurrentTask(Task t)
        {
            Console.WriteLine($"Выполняется задача {Task.CurrentId}");
            Thread.Sleep(3000);
        }

        public static void CurrentTask()
        {
            Console.WriteLine($"Выполняется задача {Task.CurrentId}");
            Thread.Sleep(3000);
        }

        public static void Factorial(uint f)
        {
            uint result = 1;
            for (uint i = 1; i <= f; i++)
            {
                result *= i;
            }

            Console.WriteLine($"Выполняется задача {Task.CurrentId}");
            Thread.Sleep(3000);
            Console.WriteLine($"Factorial of {f} is {result}");
        }
    }
}
