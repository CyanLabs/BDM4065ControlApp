namespace BDM4065ControlApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Form1());

            Console.WriteLine("Number of command line parameters = {0}",
               args.Length);
            foreach (string s in args)
            {
                Console.WriteLine(s);
            }
        }
    }
}
