using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Text;

namespace Calculator
{
    public partial class Form1 : Form
    {

        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts); //Ignore this.

        FontFamily ff;
        Font font;

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

        private void PrivateFontCollection()
        {
            // Create the byte array and get its length

            byte[] fontArray = Calculator.Properties.Resources.digital_7;
            int dataLength = Calculator.Properties.Resources.digital_7.Length;


            // ASSIGN MEMORY AND COPY  BYTE[] ON THAT MEMORY ADDRESS
            IntPtr ptrData = Marshal.AllocCoTaskMem(dataLength);
            Marshal.Copy(fontArray, 0, ptrData, dataLength);


            uint cFonts = 0;
            AddFontMemResourceEx(ptrData, (uint)fontArray.Length, IntPtr.Zero, ref cFonts);

            PrivateFontCollection pfc = new PrivateFontCollection();
            //PASS THE FONT TO THE  PRIVATEFONTCOLLECTION OBJECT
            pfc.AddMemoryFont(ptrData, dataLength);

            //FREE THE  "UNSAFE" MEMORY
            Marshal.FreeCoTaskMem(ptrData);

            ff = pfc.Families[0];
            font = new Font(ff, 15f, FontStyle.Bold);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PrivateFontCollection();
            this.calcWindow.Font = new Font(ff, 28, FontStyle.Regular);
        }

        

    }
}
