using System;
using System.ComponentModel;
using System.Windows.Forms;
using BankApp.Models;
using BankApp.Services;

namespace BankApp.Forms
{
    public partial class TransactionHistoryForm : Form
    {
        private Account account;
        private BankSystemWrapper bankSystem;

       
        public TransactionHistoryForm()
        {
            InitializeComponent();
        }

        public TransactionHistoryForm(Account account)
        {
            InitializeComponent(); 
            this.account = account;
            bankSystem = new BankSystemWrapper();
            SetupContext();
        }

        private void SetupContext()
        {
            lblAccountDetails.Text = $"Transaction History for: {account.FirstName} {account.Surname} ({account.AccountNumber})";
            try
            {
                dgvTransactions.DataSource = bankSystem.GetTransactionAuditHistory(account.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load transactions: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
