using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockExchange
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger("Program.cs");
        public static Form1 MyForm { get; set; }
        /// 
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MyForm = new Form1();
            Logger.Debug("Started Program");
            Application.Run(MyForm);
            System.Environment.Exit(1);
   
        }
    }
}
