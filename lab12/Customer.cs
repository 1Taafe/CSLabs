using System;
using System.Collections.Generic;
using System.Text;

namespace lab12
{
    class Customer //: IComparable<Customer>
    {

        public static int amountOfObj = 0;

        public static void Info()
        {
            Console.WriteLine(@"Класс Customer.
Содержит поля Surname, Name, Patro, Adress, CreditCardNumber, Balance.
Содержит статическое поле amountOfObj.
Методы класса: addMoney(); removeMoney();");
        }

        private string surname;
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                if (surname == null)
                {
                    Console.WriteLine("Null!");
                }
                else
                {
                    surname = value;
                }
            }
        }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name == null)
                {
                    Console.WriteLine("NUll!");
                }
                else
                {
                    name = value;
                }
            }
        }
        private string patro;
        public string Patro
        {
            get
            {
                return patro;
            }
            set
            {
                if (patro == null)
                {
                    Console.WriteLine("Null!!");
                }
                else
                {
                    patro = value;
                }
            }
        }
        private string adress;
        public string Adress
        {
            get
            {
                return adress;
            }
            set
            {
                if (adress == null)
                {
                    Console.WriteLine("NULL!");
                }
                else
                {
                    adress = value;
                }
            }
        }
        private ulong creditCardNumber;
        public ulong CreditCardNumber
        {
            get
            {
                return creditCardNumber;
            }
            set
            {
                if (creditCardNumber < 1000000000000000 && creditCardNumber > 9999999999999999)
                {
                    Console.WriteLine("Ошибка! Номер кредитной карты должен состоять из 16 цифр!");
                }
                else
                {
                    creditCardNumber = value;
                }
            }
        }
        private double balance;
        public double Balance
        {
            get
            {
                return balance;
            }
            set
            {
                balance = value;
            }
        }
        public const int idCoeff = 3;
        public readonly int ID;

        public void addMoney(double newMoney)
        {
            Balance += newMoney;
        }

        public void removeMoney(double newMoney)
        {
            Balance -= newMoney;
            Console.WriteLine("Minus");
        }

        public void printDoubles(params double[] numbers)
        {
            Console.WriteLine($"Your number from file: ");
            foreach (var n in numbers)
            {
                Console.WriteLine(n);
            }
        }

        public Customer()
        {
            Console.WriteLine("Покупатель создан!");

        }
        public Customer(string newSurname, string newName, string newPatro, string newAdress, ulong newCreditCardNumber, double newBalance)
        {
            surname = newSurname;
            name = newName;
            patro = newPatro;
            adress = newAdress;
            creditCardNumber = newCreditCardNumber;
            balance = newBalance;
            ID = surname.GetHashCode() * idCoeff;
            amountOfObj++;
        }

        public Customer(string newSurname, string newName, string newPatro, double newBalance = 123.456)
        {
            surname = newSurname;
            name = newName;
            patro = newPatro;
            adress = "Не задано";
            creditCardNumber = 1000000000000000;
            balance = newBalance;
            ID = surname.GetHashCode() * idCoeff;
            amountOfObj++;
        }

     
    }
}
