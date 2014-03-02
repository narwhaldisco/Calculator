using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Controllers
{
    class RPN : Mode
    {
        public RPN()
        {
            //Set initial state
            this.state = States.ACCEPTING_DIGITS;

            this.name = "RPN";

        }

        override public string pushValue()
        {
            return Program.MainModel.pushValue();
        }


        override public string inputDigit(string value)
        {
            switch (state)
            {
                case States.ACCEPTING_DIGITS:
                    this.state = States.ACCEPTING_OPERATOR;
                    return Program.MainModel.setCurrentValue(value);

                case States.ACCEPTING_OPERATOR:
                    return Program.MainModel.setCurrentValue(value);

                default:
                    return "ERROR"; //Should be impossible to get here
            }
        }

        public override string inputOperator(Operator op)
        {
            switch (state)
            {
                case States.ACCEPTING_DIGITS:
                    return "ERROR";

                case States.ACCEPTING_OPERATOR:
                    this.state = States.ACCEPTING_DIGITS;
                    return Program.MainModel.setCurrentOp(op);

                default:
                    return "ERROR";
            }
        }

        public override string performOperation()
        {
            return Program.MainModel.performOp();
        }

    }
}
