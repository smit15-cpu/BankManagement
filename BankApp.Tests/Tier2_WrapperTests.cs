using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankApp.Services;

namespace BankApp.Tests
{
    [TestClass]
    public class Tier2_WrapperTests
    {
        [TestMethod]
        public void BankSystemWrapper_AuthenticateUser_WithBlankStrings_ReturnsNull()
        {
            // Arrange
            var wrapper = new BankSystemWrapper();

            // Act
            // Attempting to bypass login by sending empty data to the Facade structure
            var user = wrapper.AuthenticateUser("", "");

            // Assert
            // The wrapper should safely identify it as invalid and decline the object creation
            Assert.IsNull(user, "Wrapper failed: It should strictly return NULL when attempting to authenticate blank credentials.");
        }
    }
}
