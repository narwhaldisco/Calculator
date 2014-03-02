using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Controllers
{
    class INFIX : Mode
    {
        public INFIX()
        {
            //Set initial state
            this.state = States.ACCEPTING_DIGITS;

            this.name = "INFIX";

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
