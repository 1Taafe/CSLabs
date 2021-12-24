using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;

namespace lab16
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            Task SimpleNumbers = new Task(Operation.Simple);
            SimpleNumbers.Start();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Console.WriteLine($"Status: {SimpleNumbers.IsCompleted}");
            SimpleNumbers.Wait();
            stopWatch.Stop();

            Console.WriteLine($"Время: {stopWatch.ElapsedMilliseconds / 1000} сек {stopWatch.ElapsedMilliseconds % 1000} мс");

            //2
            new Task(Operation.Simple).Start();
            Operation.myToken.Cancel();

            //3
            Task<int> task1 = new Task<int>(Operation.Task1);
            Task<int> task2 = new Task<int>(Operation.Task2);
            Task<int> task3 = new Task<int>(Operation.Task3);
            Task[] tasks = {
                task1, task2, task3
            };

            foreach(var t in tasks)
            {
                t.Start();
            }
            Task.WaitAll(tasks);

            double geometric = Math.Pow((task1.Result * task2.Result * task3.Result), 1.0/3.0);
            Console.WriteLine($"Среднее геометрическое 3 чисел: {geometric}");

            //4
            Task taskID = new Task(() => {
                Console.WriteLine($"Id задачи: {Task.CurrentId}");
            });
            Task taskContinue = taskID.ContinueWith(Operation.CurrentTask);
            taskID.Start();
            taskContinue.Wait();
            
            //4.2
            Task<int> what = Task.Run(() => Enumerable.Range(1, 100000)
                .Count(n => (n % 2 == 0)));
            // Получаем объект продолжения
            var awaiter = what.GetAwaiter();
            // что делать после окончания предшественника
            awaiter.OnCompleted(() => {
                // получаем результат вычислений предшественника
                int res = awaiter.GetResult(); // делегат, содержащий код продолжения
                Console.WriteLine(res);
            });

            //5
            List<int> list = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };
            Console.WriteLine("\nParallel loop: ");
            ParallelLoopResult result = Parallel.ForEach<int>(list,
                Factorial);

            Console.WriteLine("\nDefault loop: ");
            foreach (long l in list)
            {
                long result1 = 1;

                for (int i = 1; i <= l; i++)
                    result1 *= i;
                Console.WriteLine($"Factorial of {l} is {result1}.");
            }

            //6
            Console.WriteLine("Parallel.Invoke(): ");
            Parallel.Invoke(Operation.CurrentTask,
                () =>
                {
                    Console.WriteLine($"Выполняется задача {Task.CurrentId}");
                    Thread.Sleep(3000);
                },
                () => Operation.Factorial(5)
            );

            //8
            FactorialAsync();

            //7
            BlockingCollection<string> bc = new BlockingCollection<string>(5);
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken CToken = cts.Token;

            Task[] consumers = new Task[5]
            {
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(300);
                        bc.Take();
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(500);
                        bc.Take();
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(600);
                        bc.Take();
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(500);
                        bc.Take();
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(350);
                        bc.Take();
                    }
                }),
            };

            Task[] sellers = new Task[10]
            {
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(1000);
                        bc.Add("Sony");
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(1000);
                        bc.Add("Vivo");
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(1000);
                        bc.Add("Huawei");
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(1000);
                        bc.Add("Honor");
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(1000);
                        bc.Add("Samsung");
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(1000);
                        bc.Add("Lenovo");
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(1000);
                        bc.Add("Nokia");
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(1000);
                        bc.Add("Motorola");
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(1000);
                        bc.Add("Xiaomi");
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(1000);
                        bc.Add("Apple");
                    }
                }),
            };

            foreach (var item in consumers)
            {
                if (item.Status != TaskStatus.Running)
                {
                    item.Start();
                }
            }

            foreach (var item in sellers)
            {
                if (item.Status != TaskStatus.Running)
                {
                    item.Start();
                }
            }

            int count = 0;
            while (true)
            {
                if (bc.Count != count && bc.Count != 0)
                {
                    count = bc.Count;
                    Thread.Sleep(500);
                    Console.WriteLine("СКЛАД");

                    foreach (var item in bc)
                    {
                        Console.WriteLine(item);
                    }

                    if (CToken.IsCancellationRequested)
                    {
                        Console.WriteLine("\nProcess Stopped!");
                        break;
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine("******");
            Console.ReadKey();

        }

        static void Factorial(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            Console.WriteLine($"Выполняется задача {Task.CurrentId}");
            Console.WriteLine($"Факториал числа {x} равен {result}");
            Thread.Sleep(3000);
        }

        public static async void FactorialAsync()
        {
            Console.WriteLine("Start of FactorialAsync");
            await Task.Run(() => Factorial(10));
            Console.WriteLine("End of FactorialAsync");
        }
    }
}
