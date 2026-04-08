using System;
using System.ComponentModel;
using System.Windows.Forms;
using BankApp.Services;

namespace BankApp.Forms
{
    public partial class LoginForm : Form
    {
        
        public bool IsAuthenticated { get; private set; } = false;
        
        public LoginForm()
        {
            
            InitializeComponent();
        }

        // Handles the click event for the Login button
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            lblMessage.Visible = false;
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text;

            // Simple validation to ensure fields are not empty
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                lblMessage.Text = "Please enter both username and password.";
                lblMessage.Visible = true;
                return;
            }

            try
            {
                //instantiate the BankSystemWrapper to access the authentication method
                var bankSystem = new BankSystemWrapper();
                var loggedInUser = bankSystem.AuthenticateUser(user, pass);

                if (loggedInUser != null)
                {
                    // Success!
                    IsAuthenticated = true;
                    this.Close(); // Close the login form, returning control to MainForm
                }
                else
                {
                    // Credentials did not match
                    lblMessage.Text = "Incorrect username or password.";
                    lblMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                // If there's a problem connecting to the DB, it will show here
                lblMessage.Text = "Database Error: " + ex.Message;
                lblMessage.Visible = true;
            }
        }
    }
}
