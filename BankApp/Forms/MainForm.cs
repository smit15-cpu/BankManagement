using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using BankApp.Services;
using BankApp.Models;

namespace BankApp.Forms
{
    public partial class MainForm : Form
    {
        
        private BankSystemWrapper bankSystem;

        public MainForm()
        {
            InitializeComponent();
            bankSystem = new BankSystemWrapper();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Whenever grid opens, auto populate
            LoadAccountsGrid();
        }

        private void LoadAccountsGrid()
        {
            try
            {
                // Wrapper handles DB operations automatically!
                DataTable accounts = bankSystem.GetAllAccounts();
                dgvAccounts.DataSource = accounts; // Bind the DataTable directly to the DataGridView for automatic display
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load accounts from database. Details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int? GetSelectedAccountId() // Helper method to get the ID of the currently selected account in the grid. Returns null if no selection.
        {
            if (dgvAccounts.SelectedRows.Count > 0) 
            {
                return Convert.ToInt32(dgvAccounts.SelectedRows[0].Cells["Id"].Value);
            }
            MessageBox.Show("Please select an account by clicking the left margin of a row.", "Information");
            return null;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Just close the form
            this.Close();
        }

        //sidebar menu

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadAccountsGrid();
        }

        private void btnNewAccount_Click(object sender, EventArgs e)
        {
            using (var form = new AccountDetailsForm(isNewAccount: true))
            {
                form.ShowDialog();
                LoadAccountsGrid();
            }
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            int? id = GetSelectedAccountId();
            if (id.HasValue)
            {
                var acc = bankSystem.GetAccountById(id.Value);
                using (var form = new AccountDetailsForm(isNewAccount: false, existingAccount: acc))
                {
                    form.ShowDialog();
                    LoadAccountsGrid();
                }
            }
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            int? id = GetSelectedAccountId();
            if (id.HasValue)
            {
                var acc = bankSystem.GetAccountById(id.Value);
                using (var form = new DepositWithdrawForm(acc, true))
                {
                    form.ShowDialog();
                    LoadAccountsGrid();
                }
            }
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            int? id = GetSelectedAccountId();
            if (id.HasValue)
            {
                var acc = bankSystem.GetAccountById(id.Value);
                using (var form = new DepositWithdrawForm(acc, false))
                {
                    form.ShowDialog();
                    LoadAccountsGrid();
                }
            }
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            int? id = GetSelectedAccountId();
            if (id.HasValue)
            {
                var acc = bankSystem.GetAccountById(id.Value);
                using (var form = new TransferForm(acc))
                {
                    form.ShowDialog();
                    LoadAccountsGrid();
                }
            }
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            int? id = GetSelectedAccountId();
            if (id.HasValue)
            {
                var acc = bankSystem.GetAccountById(id.Value);
                using (var form = new TransactionHistoryForm(acc))
                {
                    form.ShowDialog();
                }
            }
        }
    }
}
