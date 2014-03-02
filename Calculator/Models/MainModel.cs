using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models
{
    class MainModel
    {

        //Members for INFIX
        public double value1 { get; set; }
        public double value2 { get; set; }

        public string stringValue1;
        public string stringValue2;

        public bool valFlag;

        public Operator currentOp;

        //Members for RPN
        public Stack<double> rpnStack;

        public MainModel()
        {
            stringValue1 = string.Empty;
            stringValue2 = string.Empty;

            value1 = 0;
            value2 = 0;
            valFlag = true;

            rpnStack = new Stack<double>();
        }

        public string setCurrentValue(string currentValue)
        {
            if (valFlag)
            {
                //Check if 0 for asthetic reasons, ie no leading zeros
                if (stringValue1 == "0")
                    stringValue1 = "";

                stringValue1 += currentValue;
                value1 = Convert.ToDouble(stringValue1);
                return stringValue1;
            }
            else
            {
                //Check if 0 for asthetic reasons, ie no leading zeros
                if (stringValue2 == "0")
                    stringValue2 = "";

                stringValue2 += currentValue;
                value2 = Convert.ToDouble(stringValue2);
                return stringValue2;
            }
        }

        public string setCurrentOp(Operator op)
        {
            //Set operator
            currentOp = op;
            
            //If either of the values are not empty, ie it's not first operator
            if (!(stringValue1 == string.Empty || stringValue2 == string.Empty))
            {
                //do the operation
                return performOp();
            }

            //Set value flag
            valFlag = !valFlag;

            //else, carry on
            return stringValue1;

        }

        public string performOp()
        {
            //Put result of operation into value1
            value1 = currentOp.perform(value1, value2);
            stringValue1 = value1.ToString();

            //Set value flag
            valFlag = false;

            //Empty other value for further operations
            stringValue2 = "0";
            value2 = 0;

            //Return result to display
            return value1.ToString();
        }

        public string clear()
        {
            stringValue1 = string.Empty;
            stringValue2 = string.Empty;

            value1 = 0;
            value2 = 0;

            valFlag = true;

            return value1.ToString();
        }




        internal string pushValue()
        {


            rpnStack.Push(value1);

            value1 = 0;
            stringValue1 = "0";

            return value1.ToString();

            
        }
    }
}
