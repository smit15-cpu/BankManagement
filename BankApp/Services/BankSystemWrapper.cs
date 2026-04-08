using System;
using System.Data;
using BankApp.Models;

namespace BankApp.Services
{
    
    public class BankSystemWrapper
    {
        /// This wrapper class serves as a single point of access for the UI layer to interact with the various services (AccountService, TransactionService, AuthService).


        private AccountService accountService = new AccountService(); 
        private TransactionService transactionService = new TransactionService();
        private AuthService authService = new AuthService();


        /// AUTHENTICATION RELATED WRAPPER METHODS
        public User AuthenticateUser(string username, string password)
        {
            // Passes login credentials down to the AuthService layer
            return authService.Login(username, password);
        }

        /// ACCOUNT RELATED WRAPPER METHODS
        public DataTable GetAllAccounts()
        {
            // The wrapper safely passes the request down to the AccountService 
            // to fetch all records from the SQL Database.
            return accountService.GetAllAccounts(); 
        }
        
        public Account GetAccountById(int accountId)
        {
            
            return accountService.GetAccountById(accountId); 
        }

        public void CreateAccount(Account newAccount)
        {
            // Forwards the new account object to be inserted into the DB
            accountService.CreateAccount(newAccount);
        }

        public void UpdateAccount(Account accountToUpdate)
        {
            // Forwards the updated account object to be saved in the DB. 
            accountService.UpdateAccount(accountToUpdate);
        }

        /// TRANSACTION RELATED WRAPPER METHODS

        public void PerformDeposit(int accountId, decimal amount)
        {
            // Forwards the deposit command. The TransactionService will ultimately 
            // ensure the math is correct before using DatabaseHelper to update the DB.
            transactionService.Deposit(accountId, amount);
        }

        public void PerformWithdrawal(int accountId, decimal amount)
        {
            transactionService.Withdraw(accountId, amount);
        }

        public void PerformTransfer(int sourceAccountId, int targetSortCode, int targetAccountNumber, decimal amount)
        {
            // Forwards the transfer command. The TransactionService will check the source account's available funds,
            transactionService.Transfer(sourceAccountId, targetSortCode, targetAccountNumber, amount);
        }

        public DataTable GetTransactionAuditHistory(int accountId)
        {
            // Pulls the historical logs for the DataGridView in the Audit screen
            return transactionService.GetTransactions(accountId);
        }
    }
}
