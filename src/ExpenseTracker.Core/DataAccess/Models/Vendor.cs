using System;
using ServiceStack.DataAnnotations;

namespace ExpenseTracker.Core.DataAccess.Models
{
    public class Vendor
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}