using System;
using System.Data;
using Microsoft.Data.SqlClient;
using BankApp.Data;
using BankApp.Models;

namespace BankApp.Services
{
    public class TransactionService
    {
        private readonly DatabaseHelper dbHelper;
        private readonly AccountService accountService;

        public TransactionService()
        {
            dbHelper = new DatabaseHelper();
            accountService = new AccountService();
        }

        public void Deposit(int accountId, decimal amount) 
        {
            if (amount <= 0) throw new Exception("Amount must be greater than 0.");

            string updateQuery = "UPDATE Accounts SET Balance = Balance + @Amount WHERE Id = @Id";
            SqlParameter[] updateParams = new[] 
            {
                new SqlParameter("@Amount", SqlDbType.Decimal) { Value = amount },
                new SqlParameter("@Id", SqlDbType.Int) { Value = accountId }
            };

            dbHelper.ExecuteNonQuery(updateQuery, updateParams);
            LogTransaction(accountId, "Deposit", amount, $"DEP-{DateTime.Now.Ticks}");
        }

        public void Withdraw(int accountId, decimal amount)
        {
            if (amount <= 0) throw new Exception("Amount must be greater than 0.");

            Account acc = accountService.GetAccountById(accountId);
            if (acc == null) throw new Exception("Account not found.");
            
            if (amount > acc.GetAvailableFunds())
                throw new Exception("Insufficient funds.");

            string updateQuery = "UPDATE Accounts SET Balance = Balance - @Amount WHERE Id = @Id";
            SqlParameter[] updateParams = new[]
            {
                new SqlParameter("@Amount", SqlDbType.Decimal) { Value = amount },
                new SqlParameter("@Id", SqlDbType.Int) { Value = accountId }
            };

            dbHelper.ExecuteNonQuery(updateQuery, updateParams);
            LogTransaction(accountId, "Withdrawal", amount, $"WDL-{DateTime.Now.Ticks}");
        }

        public void Transfer(int sourceAccountId, int destSortCode, int destAccountNumber, decimal amount)
        {
            if (amount <= 0) throw new Exception("Amount must be greater than 0.");

            Account sourceAcc = accountService.GetAccountById(sourceAccountId);
            if (sourceAcc == null) throw new Exception("Source account not found.");

            if (amount > sourceAcc.GetAvailableFunds())
                throw new Exception("Insufficient funds for transfer.");

            // Internal transfer check
            Account destAcc = accountService.GetAccountByAccountNumber(destAccountNumber);
            bool isInternal = (destAcc != null);

            if (sourceAcc.AccountType == AccountType.Savings && !isInternal)
            {
                throw new Exception("Savings accounts can only transfer internally.");
            }

            string refNumber = $"TX-{DateTime.Now.Ticks}";

            // Withdraw from source
            string updateSourceQuery = "UPDATE Accounts SET Balance = Balance - @Amount WHERE Id = @Id";
            dbHelper.ExecuteNonQuery(updateSourceQuery, new[] {
                new SqlParameter("@Amount", SqlDbType.Decimal) { Value = amount },
                new SqlParameter("@Id", SqlDbType.Int) { Value = sourceAccountId }
            });
            LogTransaction(sourceAccountId, "TransferOut", amount, refNumber, destSortCode, destAccountNumber);

            // Deposit to destination if internal
            if (isInternal)
            {
                string updateDestQuery = "UPDATE Accounts SET Balance = Balance + @Amount WHERE Id = @Id";
                dbHelper.ExecuteNonQuery(updateDestQuery, new[] {
                    new SqlParameter("@Amount", SqlDbType.Decimal) { Value = amount },
                    new SqlParameter("@Id", SqlDbType.Int) { Value = destAcc.Id }
                });
                LogTransaction(destAcc.Id, "TransferIn", amount, refNumber, sourceAcc.SortCode, sourceAcc.AccountNumber);
            }
        }

        private void LogTransaction(int accountId, string type, decimal amount, string referenceNumber, int? destSortCode = null, int? destAccNum = null)
        {
            string query = @"INSERT INTO Transactions (AccountId, TransactionType, Amount, ReferenceNumber, DestinationSortCode, DestinationAccountNumber)
                             VALUES (@AccId, @Type, @Amt, @Ref, @DSort, @DAcc)";
            
            SqlParameter[] parameters = new[]
            {
                new SqlParameter("@AccId", SqlDbType.Int) { Value = accountId },
                new SqlParameter("@Type", SqlDbType.NVarChar) { Value = type },
                new SqlParameter("@Amt", SqlDbType.Decimal) { Value = amount },
                new SqlParameter("@Ref", SqlDbType.NVarChar) { Value = referenceNumber },
                new SqlParameter("@DSort", SqlDbType.Int) { Value = (object)destSortCode ?? DBNull.Value }, 
                new SqlParameter("@DAcc", SqlDbType.Int) { Value = (object)destAccNum ?? DBNull.Value }
            };

            dbHelper.ExecuteNonQuery(query, parameters);
        }

        // Get Transactions for an account
        public DataTable GetTransactions(int accountId)
        {
            string query = "SELECT TransactionDate, TransactionType, Amount, ReferenceNumber, DestinationSortCode, DestinationAccountNumber FROM Transactions WHERE AccountId = @Id ORDER BY TransactionDate DESC";
            return dbHelper.ExecuteQuery(query, new[] { new SqlParameter("@Id", SqlDbType.Int) { Value = accountId } });
        }
    }
}
