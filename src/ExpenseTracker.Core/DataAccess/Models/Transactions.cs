using System;

namespace ExpenseTracker.Core.DataAccess.Models
{
    public class Transactions
    {
        public Guid Id { get; set; }
        public Guid VendorId { get; set; }
        public Guid TransactionTypeId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}