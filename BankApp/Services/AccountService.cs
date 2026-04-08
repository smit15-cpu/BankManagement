using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using BankApp.Data;
using BankApp.Models;

namespace BankApp.Services
{
    public class AccountService
    {
        private readonly DatabaseHelper dbHelper; 

        public AccountService()
        {
            dbHelper = new DatabaseHelper();
        }

        public DataTable GetAllAccounts()
        {
            string query = @"SELECT Id, AccountType, FirstName, Surname, Email, Phone, 
                             AccountNumber, SortCode, Balance, OverdraftLimit 
                             FROM Accounts";

            return dbHelper.ExecuteQuery(query);
        }

        public int GenerateNewAccountNumber()
        {
            // Simple generator: max account number + 1, starts at 10000000
            string query = "SELECT ISNULL(MAX(AccountNumber), 9999999) + 1 FROM Accounts";
            return Convert.ToInt32(dbHelper.ExecuteScalar(query));
        }

        public int GetDefaultSortCode()
        {
            if (int.TryParse(ConfigurationManager.AppSettings["BankSortCode"], out int code)) 
                return code;
            return 101010;
        }

        public void CreateAccount(Account account)
        {
            string query = @"INSERT INTO Accounts (AccountType, FirstName, Surname, Email, Phone, AddressLine1, AddressLine2, City, County, AccountNumber, SortCode, Balance, OverdraftLimit) 
                             VALUES (@Type, @FName, @SName, @Email, @Phone, @Add1, @Add2, @City, @County, @AccNum, @Sort, @Balance, @Overdraft)";

            SqlParameter[] parameters = new[]
            {
                new SqlParameter("@Type", SqlDbType.NVarChar) { Value = account.AccountType.ToString() },
                new SqlParameter("@FName", SqlDbType.NVarChar) { Value = account.FirstName },
                new SqlParameter("@SName", SqlDbType.NVarChar) { Value = account.Surname },
                new SqlParameter("@Email", SqlDbType.NVarChar) { Value = account.Email },
                new SqlParameter("@Phone", SqlDbType.NVarChar) { Value = account.Phone },
                new SqlParameter("@Add1", SqlDbType.NVarChar) { Value = account.AddressLine1 },
                new SqlParameter("@Add2", SqlDbType.NVarChar) { Value = (object)account.AddressLine2 ?? DBNull.Value },
                new SqlParameter("@City", SqlDbType.NVarChar) { Value = account.City },
                new SqlParameter("@County", SqlDbType.NVarChar) { Value = account.County },
                new SqlParameter("@AccNum", SqlDbType.Int) { Value = account.AccountNumber },
                new SqlParameter("@Sort", SqlDbType.Int) { Value = account.SortCode },
                new SqlParameter("@Balance", SqlDbType.Decimal) { Value = account.Balance },
                new SqlParameter("@Overdraft", SqlDbType.Decimal) { Value = account.OverdraftLimit }
            };

            dbHelper.ExecuteNonQuery(query, parameters);
        }

        public void UpdateAccount(Account account)
        {
            string query = @"UPDATE Accounts SET Email = @Email, Phone = @Phone, 
                             AddressLine1 = @Add1, AddressLine2 = @Add2, City = @City, County = @County 
                             WHERE Id = @Id";

            SqlParameter[] parameters = new[]
            {
                new SqlParameter("@Id", SqlDbType.Int) { Value = account.Id },
                new SqlParameter("@Email", SqlDbType.NVarChar) { Value = account.Email },
                new SqlParameter("@Phone", SqlDbType.NVarChar) { Value = account.Phone },
                new SqlParameter("@Add1", SqlDbType.NVarChar) { Value = account.AddressLine1 },
                new SqlParameter("@Add2", SqlDbType.NVarChar) { Value = (object)account.AddressLine2 ?? DBNull.Value },
                new SqlParameter("@City", SqlDbType.NVarChar) { Value = account.City },
                new SqlParameter("@County", SqlDbType.NVarChar) { Value = account.County }
            };

            dbHelper.ExecuteNonQuery(query, parameters);
        }

        public Account GetAccountById(int accountId)
        {
            string query = "SELECT * FROM Accounts WHERE Id = @Id";
            SqlParameter[] parameters = new[] { new SqlParameter("@Id", SqlDbType.Int) { Value = accountId } };
            
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            if(dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                AccountType type = (AccountType)Enum.Parse(typeof(AccountType), r["AccountType"].ToString());
                Account acc = type == AccountType.Current ? (Account)new CurrentAccount() : new SavingsAccount();
                
                acc.Id = Convert.ToInt32(r["Id"]);
                acc.AccountType = type;
                acc.FirstName = r["FirstName"].ToString();
                acc.Surname = r["Surname"].ToString();
                acc.Email = r["Email"].ToString();
                acc.Phone = r["Phone"].ToString();
                acc.AddressLine1 = r["AddressLine1"].ToString();
                acc.AddressLine2 = r["AddressLine2"] == DBNull.Value ? "" : r["AddressLine2"].ToString();
                acc.City = r["City"].ToString();
                acc.County = r["County"].ToString();
                acc.AccountNumber = Convert.ToInt32(r["AccountNumber"]);
                acc.SortCode = Convert.ToInt32(r["SortCode"]);
                acc.Balance = Convert.ToDecimal(r["Balance"]);
                acc.OverdraftLimit = Convert.ToDecimal(r["OverdraftLimit"]);

                return acc;
            }
            return null;
        }

        public Account GetAccountByAccountNumber(int accountNumber)
        {
            string query = "SELECT * FROM Accounts WHERE AccountNumber = @AccNum";
            SqlParameter[] parameters = new[] { new SqlParameter("@AccNum", SqlDbType.Int) { Value = accountNumber } };
            
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            if(dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                AccountType type = (AccountType)Enum.Parse(typeof(AccountType), r["AccountType"].ToString());
                Account acc = type == AccountType.Current ? (Account)new CurrentAccount() : new SavingsAccount();
                acc.Id = Convert.ToInt32(r["Id"]);
                acc.Balance = Convert.ToDecimal(r["Balance"]);
                acc.OverdraftLimit = Convert.ToDecimal(r["OverdraftLimit"]);
                return acc;
            }
            return null;
        }
    }
}
