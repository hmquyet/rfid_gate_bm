using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
namespace UHFReader288Demo
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            bool createNew;
            using (Mutex mutex = new Mutex(true, Application.ProductName, out createNew))
            {
                if (createNew)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());

                }
                else
                {
                    MessageBox.Show("The application is already running...");
                    System.Threading.Thread.Sleep(1000);

                    System.Environment.Exit(1);
                }
            }  
        }
    }
}
