using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankApp.Data;

namespace BankApp.Tests
{
    [TestClass]
    public class Tier3_DataAccessTests
    {
        [TestMethod]
        public void DatabaseHelper_ExecuteQuery_WithBadSql_ShouldThrowException()
        {
            // Arrange
            var db = new DatabaseHelper();
            
            // Act & Assert
            // We forcefully send a maliciously bad query to determine if the ADO.NET exception handling securely catches the crash
            var ex = Assert.ThrowsException<Exception>(() => 
            {
                db.ExecuteQuery("SELECT * FROM ABSOLUTELY_FAKE_TABLE_NAME");
            });

            // If the message contains our native wrapper text, then it caught it correctly!
            Assert.IsTrue(ex.Message.Contains("Database Query Error"), "Our DatabaseHelper failed to safely capture and wrap the SQL Exception.");
        }
    }
}
