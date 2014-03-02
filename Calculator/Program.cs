using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }


        //Define main model
        private static MainModel mainModel;

        public static MainModel MainModel
        {
            get
            {
                if (mainModel == null) mainModel = new MainModel();
                return mainModel;
            }
            set { mainModel = value; }
        }


    }
}
