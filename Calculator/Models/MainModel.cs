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

        //Flag to tell which value should be filled
        public bool valFlag;

        //Current operator, or next to be computed operator
        public Operator currentOp;

        //Members for RPN
        public Stack<double> rpnStack;

        public MainModel()
        {
            //Initialize everything to empty
            stringValue1 = string.Empty;
            stringValue2 = string.Empty;

            value1 = 0;
            value2 = 0;
            valFlag = true;

            rpnStack = new Stack<double>();
        }

        public string setCurrentValue(string currentValue)
        {
            //Which value to fill
            if (valFlag)
            {
                //Check if 0 for asthetic reasons, ie no leading zeros
                if (stringValue1 == "0" || stringValue1 == "" && currentValue ==".")
                {
                    stringValue1 = "";

                    if (currentValue == ".")
                        stringValue1 = "0";
                }
                

                //Append new value on end of number, just like a calculator
                stringValue1 += currentValue;

                //Convert it to a double
                try
                {
                    value1 = Convert.ToDouble(stringValue1);
                }
                catch (FormatException)
                {
                    //This should catch any weird stuff getting entered, try 1.1.1 or the like
                    return "ERROR";
                }
 
                //Return value to display
                return stringValue1;
            }
            else
            {
                //Check if 0 for asthetic reasons, ie no leading zeros
                if (stringValue2 == "0" || stringValue2 == "" && currentValue == ".")
                {
                    stringValue2 = "";
                    if (currentValue == ".")
                        stringValue2 = "0";
                }

                //Append new value on end of number, just like a calculator
                stringValue2 += currentValue;

                //Convert it to a double
                try
                {
                    value2 = Convert.ToDouble(stringValue2);
                }
                catch(FormatException)
                {
                    //This should catch any weird stuff getting entered, try 1.1.1 or the like
                    return "ERROR";
                }

                //Return value to display
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
                return performOp(true);
            }

            //Set value flag
            valFlag = !valFlag;

            //else, carry on
            return stringValue1;

        }

        public string performOp(bool flop)
        {
            //Put result of operation into value1
            try
            {
                value1 = currentOp.perform(value1, value2);
            }
            catch (NullReferenceException)
            {
                //Do Nothing, if you somehow get value1 as null
            }


            stringValue1 = value1.ToString();

            if (flop)
                //Set value flag
                valFlag = false;
            else
                valFlag = true;

            //Empty other value for further operations
            stringValue2 = "";
            value2 = 0;

            //Return result to display
            return value1.ToString();
        }

        public string clear()
        {
            //Clear everything
            stringValue1 = string.Empty;
            stringValue2 = string.Empty;

            value1 = 0;
            value2 = 0;

            valFlag = true;

            rpnStack = new Stack<double>();

            return value1.ToString();
        }




        internal string pushValue()
        {

            //Push value to stack
            rpnStack.Push(value1);

            value1 = 0;
            stringValue1 = "0";

            return "PUSHED";
            
        }

        internal string pullValue(Operator op)
        {
            //Pop 2 values and perform operation
            try
            {
                value1 = rpnStack.Pop();
                value2 = rpnStack.Pop();
            }
            catch (InvalidOperationException)
            {
                //If stack has less than 2 values, return error and clear
                clear();
                return "ERROR";
            }

            //Do operation
            value1 = op.perform(value1, value2);

            //Push back onto stack
            rpnStack.Push(value1);

            //display computed value, note: in this implementation it will already be pushed before displaying
            return value1.ToString();

        }
    }
}
