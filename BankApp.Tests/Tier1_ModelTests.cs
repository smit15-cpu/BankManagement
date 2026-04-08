using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankApp.Models;

namespace BankApp.Tests
{
    [TestClass]
    public class Tier1_ModelTests
    {
        [TestMethod]
        public void SavingsAccount_GetAvailableFunds_ShouldReturnOnlyBalance()
        {
            // Arrange
            var savings = new SavingsAccount { Balance = 500m };

            // Act
            decimal available = savings.GetAvailableFunds();

            // Assert
            Assert.AreEqual(500m, available, "A Savings Account should strictly limit its available funds to the exact Balance with no overdrafting.");
        }

        [TestMethod]
        public void CurrentAccount_GetAvailableFunds_ShouldIncludeOverdraft()
        {
            // Arrange
            var current = new CurrentAccount { Balance = 500m, OverdraftLimit = 250m };

            // Act
            decimal available = current.GetAvailableFunds();

            // Assert
            Assert.AreEqual(750m, available, "Polymorphism check failed: A Current Account must calculate and include its OverdraftLimit in its available funds.");
        }
    }
}
