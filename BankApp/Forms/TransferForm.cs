using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BankApp.Models;
using BankApp.Services;

namespace BankApp.Forms
{
    public partial class TransferForm : Form
    {
        private Account sourceAccount;
        private BankSystemWrapper bankSystem;

     
        public bool TransactionCompleted { get; private set; } = false;

      
        public TransferForm()
        {
            InitializeComponent();
        }

        public TransferForm(Account sourceAccount)
        {
            InitializeComponent(); 
            this.sourceAccount = sourceAccount;
            bankSystem = new BankSystemWrapper();
            SetupContext();
        }

        private void SetupContext()
        {
            lblSourceAcc.Text = $"Source Account: {sourceAccount.FirstName} {sourceAccount.Surname} ({sourceAccount.AccountNumber} - {sourceAccount.SortCode})";
            lblBalance.Text = $"Available Balance: €{sourceAccount.GetAvailableFunds():F2}";

            // If it's a Savings Account, they CANNOT transfer to another bank/external account
            if (sourceAccount is SavingsAccount)
            {
                chkInternal.Checked = true;
                chkInternal.Enabled = false; // Force internal only
                lblNotice.Visible = true;
            }
        }

        private void chkInternal_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInternal.Checked)
            {
                // Auto-fill the sort code with our bank's sort code
                txtDestSortCode.Text = System.Configuration.ConfigurationManager.AppSettings["BankSortCode"] ?? "101010";
                txtDestSortCode.Enabled = false;
            }
            else
            {
                txtDestSortCode.Text = "";
                txtDestSortCode.Enabled = true;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Please enter a valid transfer amount greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (amount > sourceAccount.GetAvailableFunds())
            {
                MessageBox.Show("Insufficient funds for this transfer.", "Transaction Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string destSort = txtDestSortCode.Text;
            string destAcc = txtDestAccNum.Text;

            if (string.IsNullOrWhiteSpace(destSort) || string.IsNullOrWhiteSpace(destAcc))
            {
                MessageBox.Show("Destination Account and Sort Code must be provided.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bankSystem.PerformTransfer(sourceAccount.Id, int.Parse(destSort), int.Parse(destAcc), amount);
                MessageBox.Show("€" + amount.ToString("F2") + " transferred successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TransactionCompleted = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transfer failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblAmount_Click(object sender, EventArgs e)
        {

        }
    }
}
