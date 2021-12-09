using System;

namespace lab3
{
    partial class Customer //: IComparable<Customer>
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
                if(surname == null)
                {
                    Console.WriteLine("Null!");
                }
                else{
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
                if(name == null)
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
                if(patro == null)
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
                if(adress == null)
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
                if(creditCardNumber < 1000000000000000 && creditCardNumber > 9999999999999999)
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
            this.Balance += newMoney;
        }

        public void removeMoney(ref double newMoney, out double eMoney)
        {
            this.Balance -= newMoney;
            eMoney = this.Balance;
        }

        private Customer(int q)
        {
            if(q == 99)
            {
                Console.WriteLine("Private");
            }
        }
        static Customer()
        {
            Console.WriteLine("Покупатель создан!");
        }
        public Customer() {
            surname = "Не задано";
            name = "Не задано";
            patro = "Не задано";
            adress = "Не задано";
            creditCardNumber = 1000000000000000;
            balance = 0.0;
            ID = surname.GetHashCode() * idCoeff;
            amountOfObj++;
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

        /*public int CompareTo(Customer c)
        {
            return this.Surname.CompareTo(c.Surname);
        }*/

        static public Customer[] cSort(Customer[] localCustomers)
        {
            Customer[] newCustomers = new Customer[localCustomers.Length];
            string[] s = new string[localCustomers.Length];
            for(int i = 0; i < localCustomers.Length; i++)
            {
                s[i] = localCustomers[i].Surname;
            }
            //Array.Sort(s);
            string temp;
            for(int i = 0; i < s.Length; i++)
            {
                for(int j = s.Length - 1; j > i; j--)
                {
                    if(s[j - 1].CompareTo(s[j]) > 0)
                    {
                        temp = s[j - 1];
                        s[j - 1] = s[j];
                        s[j] = temp;
                    }
                }
            }

            for(int i = 0; i < localCustomers.Length; i++)
            {
                for(int k = 0; k < localCustomers.Length; k++)
                {
                    if(s[i] == localCustomers[k].Surname)
                    {
                        newCustomers[i] = localCustomers[k];
                    }
                }
            }
            return newCustomers;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Customer new1 = new Customer();
            Customer new2 = new Customer("Zayankovsky", "Dmitry", "Vladimirovich", "Oshmyany", 4330358755699874, 699.75);
            Customer new3 = new Customer("Ivanov", "Petr", "Dmitrievich");

            Console.WriteLine(new1.ID);
            Console.WriteLine(new1.Surname);
            Console.WriteLine(new1.Adress);
            Console.WriteLine(new2.Name);
            Console.WriteLine(new2.CreditCardNumber);
            Console.WriteLine(new3.Patro);
            Console.WriteLine(new3.Balance);

            new3.addMoney(999.89);
            Console.WriteLine(new3.Balance);

            double rMoney = 125.66;
            double z;
            new3.removeMoney(ref rMoney, out z);
            Console.WriteLine(z);
            Console.WriteLine(new3.Balance);

            Console.WriteLine(new1.Equals(new2));
            Console.WriteLine(new1.GetType());

            Console.WriteLine();
            Customer new4 = new Customer("Ivanov", "Alexey", "Petrovich", "Minsk", 4255698874563321, 89.06);
            Customer new5 = new Customer("Arhipov", "Vitaliy", "Andreevich", "Borisov", 5266963514233887, 1200.99);
            Customer[] myCustomers = new Customer[3];
            myCustomers[0] = new2;
            myCustomers[1] = new4;
            myCustomers[2] = new5;
            foreach(var s in myCustomers)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();
            //Array.Sort(myCustomers);
            myCustomers = Customer.cSort(myCustomers);
            foreach (var s in myCustomers)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine();

            foreach(var s in myCustomers)
            {
                if(s.CreditCardNumber >= 420000000000 && s.CreditCardNumber <= 4900000000000000)
                {
                    Console.WriteLine(s);
                }
            }

            var newPerson = new {ID = 0000, Surname = "Ivanov", Name = "Ivan", Patro = "Ivanovich", Adress = "Riga", CreditCardNumber = 4111000023665411, Balance = 88.99};
            Console.WriteLine(newPerson.GetType());
            Console.WriteLine(newPerson.ToString());
            Console.WriteLine(new5.Equals(newPerson));
        }
    }
}
