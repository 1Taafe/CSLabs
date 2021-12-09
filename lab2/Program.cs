using System;
using System.Text;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {

            //task 1
            // task a + Convert(b)

            bool a = Convert.ToBoolean(Console.ReadLine());
            byte b = Convert.ToByte(Console.ReadLine());
            sbyte c = Convert.ToSByte(Console.ReadLine());
            char d = Convert.ToChar(Console.ReadLine());
            decimal e = Convert.ToDecimal(Console.ReadLine());
            double f = Convert.ToDouble(Console.ReadLine());
            float g = Convert.ToSingle(Console.ReadLine());
            int h = Convert.ToInt32(Console.ReadLine());
            uint i = Convert.ToUInt32(Console.ReadLine());
            long j = Convert.ToInt64(Console.ReadLine());
            ulong k = Convert.ToUInt64(Console.ReadLine());
            short l = Convert.ToInt16(Console.ReadLine());
            ushort m = Convert.ToUInt16(Console.ReadLine());

            Console.WriteLine($" \n Вывод типов: \n {a} \n {b} \n {c} \n {d} \n {e} \n {f} \n {g} \n {h} \n {i} \n {j} \n {k} \n {l} \n {m} \n");


            //task b

            ushort q = b;

            double q2 = h;

            float q3 = i;

            int q4 = d;

            long q5 = l;

            double q6 = (double)g;

            long q7 = (long)h;

            sbyte q8 = (sbyte)b;

            ulong q9 = (ulong)m;

            uint q10 = (uint)f;

            //task c

            //packing
            Object myObj1 = a;
            Object myObj2 = b;
            Object myObj3 = c;
            Object myObj4 = d;
            Object myObj5 = e;
            Object myObj6 = f;
            Object myObj7 = g;
            Object myObj8 = h;
            Object myObj9 = i;
            Object myObj10 = j;
            Object myObj11 = k;
            Object myObj12 = l;
            Object myObj13 = m;

            //unpacking
            bool a1 = (bool)myObj1;
            byte a2 = (byte)myObj2;
            sbyte a3 = (sbyte)myObj3;
            char a4 = (char)myObj4;
            decimal a5 = (decimal)myObj5;
            double a6 = (double)myObj6;
            float a7 = (float)myObj7;
            int a8 = (int)myObj8;
            uint a9 = (uint)myObj9;
            long a10 = (long)myObj10;
            ulong a11 = (ulong)myObj11;
            short a12 = (short)myObj12;
            ushort a13 = (ushort)myObj13;

            //task d
            var myVar = "Hello World";
            Console.WriteLine(myVar);
            Console.WriteLine(myVar.GetType());

            //task e
            int? z = null;
            if (z.HasValue)
            {
                Console.WriteLine(z.Value);
            }
            else
            {
                Console.WriteLine(z.HasValue);
            }


            //task f
            var newVar = "Hello world";
            //newVar = 15;
            // newVar присваивается строка и переменная получает тип string;
            // во втором случае при присвоении int переменной newVar получаем ошибку, т. к.
            // невозможно присвоить переменной типа string значение int;

            //task 2
            //task a
            string aStr = "hello world!!!!";
            string bStr = "Hello. I think the weather is fine today, isn't it?";
            Console.WriteLine(string.Compare(aStr, bStr));

            //task b
            string b1 = "Hello";
            string b2 = "The string that hasn't got any usefull information!";
            string b3 = "Apple";
            Console.WriteLine(string.Concat(b1, b3));
            Console.WriteLine(string.Copy(b1));


            Console.WriteLine(b2.Substring(10));
            string[] b4 = b2.Split(" ");
            foreach (var sub in b4)
            {
                Console.WriteLine($"Substrings of b4 are: {sub}");
            }
            Console.WriteLine(b2.Insert(4, b1));
            Console.WriteLine(b2.Remove(25));
            Console.WriteLine($"String b1: {b1} \n String b3: {b3}");

            //task c
            string str1 = "";
            string str2 = null;

            if (string.IsNullOrEmpty(str1))
            {
                Console.WriteLine("str1 is null or empty");
            }

            if (string.IsNullOrEmpty(str2))
            {
                Console.WriteLine("str2 is null or empty");
            }

            //task d

            StringBuilder myString = new StringBuilder("The clouds are disappearing!");
            Console.WriteLine(myString.Remove(4, 6));
            Console.WriteLine(myString.Append(" Sun is shining!"));
            Console.WriteLine(myString.Insert(0, "At the same time "));

            //task 3
            //task a
            const int rows = 2;
            const int cols = 4;
            int[,] nums = new int[rows, cols] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 } };
            for(i = 0; i < rows; i++)
            {
                for(k = 0; k < cols; k++)
                {
                    Console.Write($"{nums[i, k]} \t");
                }
                Console.Write("\n");
            }

            //task b
            string[] diffStrings = new string[4];
            diffStrings[0] = "Hellow world!";
            diffStrings[1] = "Replace me!";
            diffStrings[2] = "Move on!";
            diffStrings[3] = "Black and White!";

            foreach(var unit in diffStrings)
            {
                Console.WriteLine(unit);
            }
            Console.WriteLine($"Длина массива строк: {diffStrings.Length}");

            int option = 0;
            string newStr;
            Console.WriteLine("Введите номер элемента, который хотите изменить: ");
            option = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите новую строку: ");
            newStr = Console.ReadLine();
            diffStrings[option] = newStr;
            Console.WriteLine("Новый массив: ");
            foreach (var unit in diffStrings)
            {
                Console.WriteLine(unit);
            }

            //task c
            int[][] numbers = new int[3][];
            numbers[0] = new int[2];
            numbers[1] = new int[3];
            numbers[2] = new int[4];

           for(i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine("Введите строку зубчатого массива: ");
                for(j = 0; j < numbers[i].Length; j++)
                {
                    numbers[i][j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            for (i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine();
                for (j = 0; j < numbers[i].Length; j++)
                {
                    Console.Write($"{numbers[i][j]} \t");
                }
            }

            //task d
            var myName = "Dmitry";
            var digits = new[] { 1, 2, 3, 8, 10};

            //task 4
            //task a
            (int, string, char, string, ulong) myTuple = (129, "Hello", 'Q', "World", 178889996);
            (int, string, char, string, ulong) myTuple2 = (121, "Hello", 'Q', "World", 178889996);
            (int, string, char, string, ulong) myTuple3 = (129, "Hello", 'Q', "World", 178889996);

            //task b
            Console.Write($"\n {myTuple}");
            Console.Write($"\n {myTuple.Item1} \t {myTuple.Item3} \t {myTuple.Item4} \n");

            //task c
            (int myNum, string myString1, char myChar, string myString2, ulong myULong) = myTuple;
            var (qmyNum, qmyString1, qmyChar, qmyString2, qmyULong) = myTuple;

            //task d
            Console.WriteLine(myTuple == myTuple2);
            Console.WriteLine(myTuple == myTuple3);

            //task 5
            (int, int, int, char) localFunc(int[] intArray, string theStr)
            {
                int sum = 0, min, max;
                min = intArray[0];
                max = intArray[0];
                for(i = 0; i < intArray.Length; i++)
                {
                    if(min > intArray[i])
                    {
                        min = intArray[i];
                    }
                    if(max < intArray[i])
                    {
                        max = intArray[i];
                    }
                    sum += intArray[i];
                }
                var result = (max,min,sum, theStr[0]);
                return result;
            }
            int[] testArr = new int[] { 1, 2, 3, 0, 5 };
            string testStr = "Sun";
            var theRes = localFunc(testArr, testStr);
            Console.WriteLine(theRes);

            //task 6
            int tChecked(){
                checked
                {
                    int q = 2147483647;
                    q++;
                    return 0;
                }
                
            }

            int tUnchecked()
            {
                unchecked
                {
                    int q = 2147483647;
                    return 0;
                }
            }

            tChecked();
            tUnchecked();
        }
    }
}
