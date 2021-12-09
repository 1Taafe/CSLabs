using System;

namespace lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectorHandler dir = DisplayMessage;
            //Водитель(подписан на два события)
            Driver myDriver = new Driver(100);
            Console.WriteLine(myDriver.ToString());
            myDriver.RaiseNotify += DisplayMessage;
            myDriver.DropNotify += DisplayMessage;
            myDriver.Raise(199.99);
            myDriver.Drop(59.99);
            myDriver.Raise(35);
            myDriver.Drop(10.50);
            Console.WriteLine(myDriver.ToString());

            Console.WriteLine();

            //Механик(подписан на одно событие)
            Mechanic myMechanic = new Mechanic(100);
            Console.WriteLine(myMechanic.ToString());
            myMechanic.DropNotify += DisplayMessage;
            myMechanic.Raise(99.99);
            myMechanic.Drop(19.85);
            myMechanic.Raise(10);
            myMechanic.Drop(5.55);
            Console.WriteLine(myMechanic.ToString());

            Console.WriteLine();
            //Работа со строкой
            string testString = "H e llo.. Wor ld !??!";
            Func<string, string> myFunc;
            Console.WriteLine($"Первоначальный вид строки: {testString}");
            myFunc = StringOps.ImplementAllOps;
            testString = myFunc(testString);
            Console.WriteLine($"Измененная строка: {testString}");
        }
        static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
