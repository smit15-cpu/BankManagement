using System;
using System.Windows.Forms;

namespace BankApp.Forms
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var loginForm = new LoginForm())
            {
                loginForm.ShowDialog();
                if (loginForm.IsAuthenticated)
                {
                    this.Hide(); // Hide welcome screen

                    // Open the main dashboard
                    using (var mainForm = new MainForm())
                    {
                        mainForm.ShowDialog();
                    }

                    // Once main dashboard closes, exit app entirely
                    Application.Exit();
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }
    }
}
