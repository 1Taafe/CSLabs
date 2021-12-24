using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace lab15
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            using (StreamWriter sw = new StreamWriter(@"C:\Users\dima7\source\repos\lab15\processes.txt", false, System.Text.Encoding.Default))
            {
                var currentProcesses = Process.GetProcesses();
                foreach (var s in currentProcesses)
                {
                    sw.WriteLine($"ID: {s.Id} | Name: {s.ProcessName} | BasePriority: {s.BasePriority}");
                }
            }

            //2
            AppDomain myDomain = AppDomain.CurrentDomain;
            Console.WriteLine(myDomain.FriendlyName);
            var setupInfo = myDomain.SetupInformation;
            Console.WriteLine(setupInfo.ApplicationBase + " | " + setupInfo.TargetFrameworkName);
            var builds = myDomain.GetAssemblies();
            foreach (var s in builds)
            {
                Console.WriteLine(s);
            }

            //Isnt supported
            //AppDomain newDomain = AppDomain.CreateDomain("new");
            //newDomain.Load("AssemblyName");
            //builds = newDomain.GetAssemblies();
            //foreach (var s in builds)
            //{
            //    Console.WriteLine(s);
            //}
            // AppDomain.Unload(newDomain);


            //3
            Thread myThread = new Thread(new ParameterizedThreadStart(Numbers.Simple));
            myThread.Start(30);
            //myThread.Suspend(); 
            //myThread.Resume();
            Console.WriteLine($"{myThread.Name} | {myThread.Priority} | {myThread.ManagedThreadId}");

            Thread.Sleep(4000);

            //4
            Thread even = new Thread(new ParameterizedThreadStart(Numbers.Even));
            Thread odd = new Thread(new ParameterizedThreadStart(Numbers.Odd));

            even.Priority = ThreadPriority.AboveNormal;
            odd.Priority = ThreadPriority.BelowNormal;

            even.Start(10);
            odd.Start(10);

            //5
            TimerCallback tm = new TimerCallback(Numbers.GetRandomNumber);
            Timer timer = new Timer(tm, null, 0, 3000);

            Console.ReadLine();
        }
    }
}
