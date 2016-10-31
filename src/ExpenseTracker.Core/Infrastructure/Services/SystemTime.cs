using System;

namespace ExpenseTracker.Core.Infrastructure.Services
{
    public interface ISystemTime
    {
        DateTime Now { get; }
    }

    public class SystemTime : ISystemTime
    {
        public DateTime Now => DateTime.Now;
    }
}