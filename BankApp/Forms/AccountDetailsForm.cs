using System;
using System.ComponentModel;
using System.Windows.Forms;
using BankApp.Models;
using BankApp.Services;

namespace BankApp.Forms
{
    public partial class AccountDetailsForm : Form
    {
        private BankSystemWrapper bankSystem; //wrapper instance to call service methods. 
        private Account existingAccount; 

       
        public bool DataSaved { get; private set; } = false; // Flag to indicate if data was saved successfully, used by parent form to decide whether to refresh the account list


        public AccountDetailsForm()
        {
            InitializeComponent();
        }

        // Custom constructor to handle Create AND Edit correctly 
        // Pass isNewAccount = true to create a new account
        // Pass a valid Account object natively to edit it
        public AccountDetailsForm(bool isNewAccount = false, Account existingAccount = null)
        {
            InitializeComponent();
            bankSystem = new BankSystemWrapper();
            
            // Populate combo box
            cbCounty.Items.AddRange(new string[] { "Antrim", "Armagh", "Carlow", "Cavan", "Clare", "Cork", "Derry", "Donegal", "Down", "Dublin", "Fermanagh", "Galway", "Kerry", "Kildare", "Kilkenny", "Laois", "Leitrim", "Limerick", "Longford", "Louth", "Mayo", "Meath", "Monaghan", "Offaly", "Roscommon", "Sligo", "Tipperary", "Tyrone", "Waterford", "Westmeath", "Wexford", "Wicklow" });
            cbCounty.SelectedIndex = 0;

            if (!isNewAccount && existingAccount != null) // If we're editing, we must have an existing account to load
            {
                this.existingAccount = existingAccount;
                this.Text = "Edit Account - DBS Credit Union";
                lblHeader.Text = "Edit Account Details";
                LoadExistingData();
                DisableFieldsForEdit();
            }
            else
            {
                this.Text = "New Account - DBS Credit Union";
                lblHeader.Text = "Create New Account";
                RandomizeNewAccount();
            }
        }
        // This method sets up the form for creating a new account, including generating a random account number and sort code.
        private void RandomizeNewAccount()
        {
            
            txtAccountNumber.Text = ""; 
            txtSortCode.Text = System.Configuration.ConfigurationManager.AppSettings["BankSortCode"] ?? "101010"; // Use a fixed sort code from config or default to "101010"


            txtAccountNumber.ReadOnly = false;
            txtSortCode.ReadOnly = true;
        }

        private void LoadExistingData()
        {
            txtFirstName.Text = existingAccount.FirstName;
            txtSurname.Text = existingAccount.Surname;
            txtEmail.Text = existingAccount.Email;
            txtPhone.Text = existingAccount.Phone;
            txtAddress1.Text = existingAccount.AddressLine1;
            txtAddress2.Text = existingAccount.AddressLine2;
            txtCity.Text = existingAccount.City;
            cbCounty.SelectedItem = existingAccount.County;
            txtAccountNumber.Text = existingAccount.AccountNumber.ToString();
            txtSortCode.Text = existingAccount.SortCode.ToString();
            txtInitialBalance.Text = existingAccount.Balance.ToString("F2");
            
            if (existingAccount is CurrentAccount ca)
            {
                rbCurrent.Checked = true;
                txtOverdraftLimit.Text = ca.OverdraftLimit.ToString("F2");
            }
            else
            {
                rbSavings.Checked = true;
                txtOverdraftLimit.Text = "0";
            }
        }

        private void DisableFieldsForEdit() 
        {
            txtFirstName.ReadOnly = true;
            txtSurname.ReadOnly = true;
            
            rbCurrent.Enabled = false;
            rbSavings.Enabled = false;
            txtAccountNumber.ReadOnly = true;
            txtSortCode.ReadOnly = true;
            txtInitialBalance.ReadOnly = true;
            txtOverdraftLimit.ReadOnly = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtSurname.Text))
                {
                    MessageBox.Show("First Name and Surname are required.");
                    return;
                }

                //Must be exactly 8 digits integers
                if (txtAccountNumber.Text.Length != 8 || !int.TryParse(txtAccountNumber.Text, out _))
                {
                    MessageBox.Show("Error: Account Number must be a valid 8-digit number.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (existingAccount == null) // Creating
                {
                    Account newAcc;
                    decimal initBal = decimal.TryParse(txtInitialBalance.Text, out var b) ? b : 0;
                    
                    if (rbCurrent.Checked)
                    {
                        decimal overdraft = decimal.TryParse(txtOverdraftLimit.Text, out var o) ? o : 0;
                        newAcc = new CurrentAccount
                        {
                            FirstName = txtFirstName.Text,
                            Surname = txtSurname.Text,
                            Email = txtEmail.Text,
                            Phone = txtPhone.Text,
                            AddressLine1 = txtAddress1.Text,
                            AddressLine2 = txtAddress2.Text,
                            City = txtCity.Text,
                            County = cbCounty.Text,
                            AccountNumber = int.Parse(txtAccountNumber.Text),
                            SortCode = int.Parse(txtSortCode.Text),
                            Balance = initBal,
                            OverdraftLimit = overdraft
                        };
                    }
                    else
                    {
                        newAcc = new SavingsAccount
                        {
                            FirstName = txtFirstName.Text,
                            Surname = txtSurname.Text,
                            Email = txtEmail.Text,
                            Phone = txtPhone.Text,
                            AddressLine1 = txtAddress1.Text,
                            AddressLine2 = txtAddress2.Text,
                            City = txtCity.Text,
                            County = cbCounty.Text,
                            AccountNumber = int.Parse(txtAccountNumber.Text),
                            SortCode = int.Parse(txtSortCode.Text),
                            Balance = initBal
                        };
                    }

                    bankSystem.CreateAccount(newAcc);
                }
                else // Editing
                {
                    existingAccount.FirstName = txtFirstName.Text;
                    existingAccount.Surname = txtSurname.Text;
                    existingAccount.Email = txtEmail.Text;
                    existingAccount.Phone = txtPhone.Text;
                    existingAccount.AddressLine1 = txtAddress1.Text;
                    existingAccount.AddressLine2 = txtAddress2.Text;
                    existingAccount.City = txtCity.Text;
                    existingAccount.County = cbCounty.Text;

                    bankSystem.UpdateAccount(existingAccount);
                }

                DataSaved = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving account: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbCurrent_CheckedChanged(object sender, EventArgs e)
        {
            if (existingAccount == null)
            {
                txtOverdraftLimit.Enabled = rbCurrent.Checked;
                if (!rbCurrent.Checked) txtOverdraftLimit.Text = "0";
            }
        }
    }
}
