using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Controllers
{
    class RPN : Mode
    {

        // No explicit states here, assignment did not require it and they're also very simple
        // One could derive states, they would be similar to the INFIX, possibly with the addition of condition of the stack

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
           return Program.MainModel.setCurrentValue(value);
        }

        public override string inputOperator(Operator op)
        {
            return Program.MainModel.pullValue(op);

        }

        public override string performOperation(bool flop)
        {
            return Program.MainModel.performOp(flop);
        }

    }
}
