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
        public enum States { ACCEPTING_DIGITS, ACCEPTING_OPERATOR };

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

        //Four Functions
        abstract public string inputOperator(Operator op);

        abstract public string performOperation();

        public string clear()
        {
            this.state = States.ACCEPTING_DIGITS;

            return Program.MainModel.clear();
        }



        virtual public string pushValue() { return string.Empty; }
    }
}
