using System;

namespace BankApp.Models
{
    public enum AccountType 
    {
        Current,
        Savings
    }

    public abstract class Account 
    {
        public int Id { get; set; }
        public AccountType AccountType { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string AddressLine1 { get; set; } = string.Empty;
        public string AddressLine2 { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string County { get; set; } = string.Empty;
        public int AccountNumber { get; set; }
        public int SortCode { get; set; }
        public decimal Balance { get; set; }
        public decimal OverdraftLimit { get; set; }

       
        public virtual decimal GetAvailableFunds() 
        {
            return Balance;
        }

        
        public string DisplayName => $"{FirstName} {Surname} - {AccountNumber}"; // A read-only property to display the account holder's name and account number
    }

    public class CurrentAccount : Account // Inherit from Account and set the account type to Current
    {
        public CurrentAccount() // Set the account type to Current in the constructor
        {
            AccountType = AccountType.Current;
        }

        public override decimal GetAvailableFunds() // For current accounts, available funds include the overdraft limit
        {
            return Balance + OverdraftLimit;
        }
    }

    public class SavingsAccount : Account
    {
        public SavingsAccount()
        {
            AccountType = AccountType.Savings;
            OverdraftLimit = 0; // Savings have no overdraft
        }

        public override decimal GetAvailableFunds() // For savings accounts, available funds are just the balance since there is no overdraft
        {
            return Balance;
        }
    }
}
