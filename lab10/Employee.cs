using System.Collections;
using System.Collections.Generic;

namespace lab10
{
    public class Employee : IEnumerable<string>
    {
        public string Surname { set; get; }
        public string Name { set; get; }
        public byte Age { set; get; }
        public string Position { set; get; }
        public double Salary { set; get; }
        public string Organization { set; get; }

        public Employee(string surname, string name, byte age, string position, double salary, string organization)
        {
            Surname = surname;
            Name = name;
            Age = age;
            Position = position;
            Salary = salary;
            Organization = organization;
        }

        public Employee(string surname, string name, byte age)
        {
            Surname = surname;
            Name = name;
            Age = age;
            Position = "Не задано";
            Organization = "Не задано";
            Salary = 0;
        }

        public override string ToString()
        {
            return $"Работник | {Surname} | {Name} | Возраст - {Age} | Должность - {Position} | Зарплата - {Salary}";
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return Surname;
            yield return Name;
            yield return Age;
            yield return Position;
            yield return Salary;
            yield return Organization;
        }

        public IEnumerator<string> GetEnumerator()
        {
            yield return Surname;
            yield return Name;
            yield return Position;
            yield return Organization;
        }
    }
}
