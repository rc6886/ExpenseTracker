﻿using System;
using ServiceStack.DataAnnotations;

namespace ExpenseTracker.Core.DataAccess.Models
{
    public class Transactions
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int VendorId { get; set; }
        public int TransactionTypeId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}