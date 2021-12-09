using System;
using System.Collections.Generic;
using System.Text;

namespace lab8
{
    public class Plant
    {
        public string Name
        {
            get; set;
        }

        public Plant(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
