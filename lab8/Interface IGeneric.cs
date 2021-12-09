using System;
using System.Collections.Generic;
using System.Text;

namespace lab8
{
    interface IGeneric<T>
    {
        void Add(T obj);
        void Remove(T obj);
        void View();
        void WriteFile();
        void ReadFile();

    }
}
