﻿using System;
using MediatR;

namespace ExpenseTracker.Core.Common.Command.Transactions
{
    public class AddTransactionCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid VendorId { get; set; }
        public Guid TransactionTypeId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}