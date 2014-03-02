using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Add : Operator
    {
        override public double perform(double value1, double value2)
        {
            return value1 + value2;
        }
    }
}
