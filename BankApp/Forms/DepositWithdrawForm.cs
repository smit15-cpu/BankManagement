using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BankApp.Models;
using BankApp.Services;

namespace BankApp.Forms
{
    public partial class DepositWithdrawForm : Form
    {
        private Account account; 
        private bool isDeposit;
        private BankSystemWrapper bankSystem; 

        public bool TransactionCompleted { get; private set; } = false; 

        
        public DepositWithdrawForm()
        {
            InitializeComponent();
        }
        // This constructor is used when we want to perform a deposit or withdrawal on a specific account.
        public DepositWithdrawForm(Account account, bool isDeposit)
        {
            InitializeComponent(); 
            this.account = account;
            this.isDeposit = isDeposit;
            bankSystem = new BankSystemWrapper();
            SetupContext();
        }

        private void SetupContext()
        {
            this.Text = isDeposit ? "Deposit Funds - DBS Credit Union" : "Withdraw Funds - DBS Credit Union";
            lblHeader.Text = isDeposit ? "Deposit into Account" : "Withdraw from Account";
            btnSubmit.Text = isDeposit ? "DEPOSIT" : "WITHDRAW";

            lblAccInfo.Text = $"Account: {account.FirstName} {account.Surname} ({account.AccountNumber})"; // Display account holder's name and number
            lblCurrentBalance.Text = $"Current Balance: €{account.Balance:F2}"; // Show current balance with 2 decimal places

            // If withdrawing, we want to warn them using a red color 
            if (!isDeposit)
            {
                panelTop.BackColor = Color.DarkRed;
                btnSubmit.BackColor = Color.DarkRed;
                
                // Show available funds (with overdraft for current accounts)
                lblAvailable.Text = $"Available to withdraw: €{account.GetAvailableFunds():F2}"; // This will call the overridden GetAvailableFunds() method which accounts for overdraft if it's a CurrentAccount
                lblAvailable.Visible = true; // Only show this label for withdrawals, as it's not relevant for deposits
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0) // Validate that the input is a valid decimal number and greater than 0
            {
                MessageBox.Show("Please enter a valid amount greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (isDeposit)
                {
                    bankSystem.PerformDeposit(account.Id, amount);
                    MessageBox.Show("€" + amount.ToString("F2") + " deposited successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else //Withdrawal
                {
                    if (amount > account.GetAvailableFunds())
                    {
                        MessageBox.Show("Insufficient funds for withdrawal.", "Transaction Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    bankSystem.PerformWithdrawal(account.Id, amount);
                    MessageBox.Show("€" + amount.ToString("F2") + " withdrawn successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                TransactionCompleted = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
