using System;
using System.Windows.Forms;
using BankApp.Forms;

namespace BankApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            
            Application.Run(new WelcomeForm());
        }
    }
}
