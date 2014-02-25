using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {

        String value1 = "0";
        String value2 = "0";

        bool valFlag = true;
        bool opFlag = true;

        String currentValue;

        Operator currentOperator;

        public Form1()
        {
            InitializeComponent();

            currentValue = "0";

        }

        private void inputDigit(object sender, EventArgs e)
        {
            if (currentValue == "0")
                currentValue = "";

            currentValue += sender.ToString()[sender.ToString().Length - 1].ToString();
            this.calcWindow.Text = currentValue;

            if (valFlag)
                value1 = currentValue;
            else
                value2 = currentValue;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            currentValue = "0";
            value1 = "";
            value2 = "";
            this.calcWindow.Text = currentValue;
            opFlag = true;
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {

            if (!opFlag)
            {
                buttonEquals_Click(sender, e);
            }

            opFlag = false;

            currentOperator = new Add();
            valFlag = !valFlag;
            currentValue = "0";
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            try
            {
                value1 = currentOperator.perform(Convert.ToDouble(value1), Convert.ToDouble(value2)).ToString();
            }
            catch (FormatException)
            {
                this.calcWindow.Text = "ERROR";
                value1 = "0";
                value2 = "0";
                return;
            }
            valFlag = !valFlag;
            this.calcWindow.Text = value1;
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            if (!opFlag)
            {
                buttonEquals_Click(sender, e);
            }

            opFlag = false;

            currentOperator = new Subtract();
            valFlag = !valFlag;
            currentValue = "0";
        }

        private void buttonMult_Click(object sender, EventArgs e)
        {
            if (!opFlag)
            {
                buttonEquals_Click(sender, e);
            }

            opFlag = false;

            currentOperator = new Multiply();
            valFlag = !valFlag;
            currentValue = "0";
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {

            if (!opFlag)
            {
                buttonEquals_Click(sender, e);
            }

            opFlag = false;


            currentOperator = new Divide();
            valFlag = !valFlag;
            currentValue = "0";
        }

        private void buttonDec_Click(object sender, EventArgs e)
        {
            if (currentValue == "0")
                currentValue = "";

            currentValue += ".";
            this.calcWindow.Text = currentValue;

            if (valFlag)
                value1 = currentValue;
            else
                value2 = currentValue;
        }

        private void buttonMode_Click(object sender, EventArgs e)
        {
            //TODO: RPN mode
        }

        

    }
}
