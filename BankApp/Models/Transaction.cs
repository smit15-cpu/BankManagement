using System;

namespace BankApp.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string TransactionType { get; set; } = string.Empty; // Deposit, Withdrawal, TransferIn, TransferOut
        public decimal Amount { get; set; }
        public string ReferenceNumber { get; set; } = string.Empty;
        public DateTime TransactionDate { get; set; }
        public int? DestinationSortCode { get; set; } 
        public int? DestinationAccountNumber { get; set; }
    }
}
