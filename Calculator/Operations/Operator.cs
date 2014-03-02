using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    abstract class Operator
    {
        abstract public double perform(double value1, double value2);
    }
}
