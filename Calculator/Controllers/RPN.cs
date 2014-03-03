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
            this.state = States.HAVE_NOTHING;

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
                case States.HAVE_NOTHING:
                    this.state = States.HAVE_OPERAND;
                    return Program.MainModel.setCurrentValue(value);

                case States.HAVE_OPERATOR:
                case States.HAVE_OPERAND:
                    this.state = States.HAVE_OPERAND;
                    return Program.MainModel.setCurrentValue(value);

                default:
                    return "ERROR"; //Should be impossible to get here
            }
        }

        public override string inputOperator(Operator op)
        {

            return Program.MainModel.pullValue(op);

            /*
            switch (state)
            {
                case States.HAVE_NOTHING:
                    return "ERROR";

                case States.HAVE_OPERAND:
                    this.state = States.HAVE_OPERATOR;
                    return Program.MainModel.setCurrentOp(op);

                default:
                    return "ERROR";
            }*/
        }

        public override string performOperation(bool flop)
        {
            return Program.MainModel.performOp(flop);
        }

    }
}
