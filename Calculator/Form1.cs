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
using Calculator.Controllers;

namespace Calculator
{
    public partial class Form1 : Form
    {


        //Members-----------------------------------------------------------------------------------------------------------------------------
        

        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts); //Ignore this.

        FontFamily ff;
        Font font;

        Mode currentMode;

        //Functions-----------------------------------------------------------------------------------------------------------------------------

        public Form1()
        {
            InitializeComponent();

            currentMode = new INFIX();
        }

        private void inputDigit(object sender, EventArgs e)
        {
            this.calcWindow.Text = currentMode.inputDigit(sender.ToString()[sender.ToString().Length - 1].ToString());
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            this.calcWindow.Text = currentMode.clear();
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            this.calcWindow.Text = currentMode.inputOperator(new Add());
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            this.calcWindow.Text = currentMode.performOperation();
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            this.calcWindow.Text = currentMode.inputOperator(new Subtract());
        }

        private void buttonMult_Click(object sender, EventArgs e)
        {
           this.calcWindow.Text = currentMode.inputOperator(new Multiply());
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
           this.calcWindow.Text = currentMode.inputOperator(new Divide());
        }

        private void buttonDec_Click(object sender, EventArgs e)
        {
            this.calcWindow.Text = currentMode.inputDigit(".");

        }

        private void buttonMode_Click(object sender, EventArgs e)
        {
            this.calcWindow.Text = currentMode.clear();

            if (currentMode.GetType() == typeof(RPN))
            {
                currentMode = new INFIX();
                this.enterBtn.Visible = false;
            }
            else
            {
                currentMode = new RPN();
                this.enterBtn.Visible = true;
            }

            this.modeLabel.Text = currentMode.getName();

        }

        private void PrivateFontCollection() //SUPER IMPORTANT FONTS
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

        private void enterBtn_Click(object sender, EventArgs e)
        {
            this.calcWindow.Text = currentMode.pushValue();
        }
    }
}
