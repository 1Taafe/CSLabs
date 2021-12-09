using System;
using System.Collections.Generic;
using System.Text;

namespace lab7
{
    public class FlowerExceptions
    {
        protected internal class CostLessThanZeroException : Exception
        {
            public CostLessThanZeroException(string message) : base(message) { }
        }

        protected internal class CostIsZeroException : Exception
        {
            public CostIsZeroException(string message) : base(message) { }
        }

        protected internal class CantBeBlackException : Exception
        {
            public CantBeBlackException(string message) : base(message) { }
        }
    }
}
