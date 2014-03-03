using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Controllers
{
    abstract class Mode
    {
        //States
        public enum States { HAVE_NOTHING, HAVE_OPERAND, HAVE_OPERATOR };

        //Current state
        public States state;

        //The name of the mode
        public string name;

        public string getName()
        {
            return name;
        }

        //Input digits
        abstract public string inputDigit(string value);

        //Functions reflect the states
        abstract public string inputOperator(Operator op);

        abstract public string performOperation(bool flop);

        public string clear()
        {
            this.state = States.HAVE_NOTHING;

            return Program.MainModel.clear();
        }


        //Only for RPN
        virtual public string pushValue() { return string.Empty; }
    }
}
