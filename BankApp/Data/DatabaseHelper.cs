using System;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace BankApp.Data
{
    
    public class DatabaseHelper
    {
        
        private readonly string connectionString; 

        public DatabaseHelper()
        {
            // Fallback connection string primarily to satisfy MSTest isolation
            connectionString = ConfigurationManager.ConnectionStrings["BankDB"]?.ConnectionString 
                ?? @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Abc\Documents\BankAppDB.mdf;Integrated Security=True;Connect Timeout=30";
        }

        private SqlConnection GetConnection()
        {
            // Simply returns a prepared connection object.
            return new SqlConnection(connectionString);
        }

        //Executes INSERT, UPDATE, DELETE queries. Returns the number of affected rows.
        public int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            try
            {
                // The "using" blocks automatically close and dispose of the SQL connection 
                using (var connection = GetConnection()) // Get a new connection from the helper method
                using (var command = new SqlCommand(query, connection)) // Create a command object with the query and connection
                {
                    if (parameters != null)  
                        command.Parameters.AddRange(parameters); 

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                
                throw new Exception($"Database Execution Error: {ex.Message}", ex); 
            }
            catch (Exception ex)
            {
                
                throw new Exception($"General System Error: {ex.Message}", ex);
            }
        }
        /// Executes SELECT queries and returns the results in a DataTable.
        public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            try 
            {
                using (var connection = GetConnection()) 
                using (var command = new SqlCommand(query, connection)) // Create a command object with the query and connection
                using (var adapter = new SqlDataAdapter(command)) //filling DataTables
                {
                    if (parameters != null)
                        command.Parameters.AddRange(parameters); //paramater binding 

                    DataTable dt = new DataTable(); // Create a new DataTable to hold the results
                    adapter.Fill(dt); // Fills the table 
                    return dt; 
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Database Query Error: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"General System Error: {ex.Message}", ex);
            }
        }

        // Executes a query that returns a single value and returns it as an object.
        public object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            try
            {
                using (var connection = GetConnection()) 
                using (var command = new SqlCommand(query, connection)) 
                {
                    if (parameters != null)
                        command.Parameters.AddRange(parameters); 

                    connection.Open();
                    return command.ExecuteScalar();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Database Scalar Error: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"General System Error: {ex.Message}", ex);
            }
        }
    }
}
