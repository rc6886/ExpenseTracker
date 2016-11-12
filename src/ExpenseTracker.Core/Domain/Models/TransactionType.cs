using System;
using ExpenseTracker.Core.Infrastructure;

namespace ExpenseTracker.Core.Domain.Models
{
    public class TransactionType : Enumeration
    {
        public static readonly TransactionType Income = new TransactionType(1, "Income");
        public static readonly TransactionType Expense = new TransactionType(2, "Expense");

        private TransactionType() { }
        private TransactionType(int value, string displayName) : base(value, displayName) { }
    }
}