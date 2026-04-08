using System;
using System.Data;
using Microsoft.Data.SqlClient;
using BankApp.Data;
using BankApp.Models;

namespace BankApp.Services
{
    public class AuthService
    {
        private readonly DatabaseHelper dbHelper;

        public AuthService()
        {
            dbHelper = new DatabaseHelper();
        }

        // Returns the User object if login is successful, null otherwise
        public User Login(string username, string password)
        {
            string query = "SELECT Id, Username, IsStaff FROM Users WHERE Username = @Username AND Password = @Password";
            
            SqlParameter[] parameters = new[]
            {
                new SqlParameter("@Username", SqlDbType.NVarChar) { Value = username },
                new SqlParameter("@Password", SqlDbType.NVarChar) { Value = password }
            };

            try
            {
                DataTable result = dbHelper.ExecuteQuery(query, parameters);

                if (result.Rows.Count == 1)
                {
                    DataRow row = result.Rows[0];
                    return new User
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        Username = row["Username"].ToString(),
                       
                        IsStaff = Convert.ToBoolean(row["IsStaff"])
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
               
                throw new Exception("Error during login.", ex);
            }
        }
    }
}
