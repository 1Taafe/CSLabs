using System;
using System.Collections.Generic;
using System.Text;

namespace lab3
{
    partial class Customer
    {
        public override bool Equals(Object obj)
        {
            Customer newOne;
            if (obj == null || (newOne = obj) == null)
            {
                return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            int myHashCode;
            myHashCode = (this.Surname.Length + this.Name.Length + this.Patro.Length) * this.ID;
            return myHashCode;
        }

        public override string ToString()
        {
            string res = $"{this.ID} {this.Surname} {this.Name} {this.Patro} {this.Adress} {this.CreditCardNumber} {this.Balance}";
            //Console.WriteLine(res);
            return res;
        }
    }
}
