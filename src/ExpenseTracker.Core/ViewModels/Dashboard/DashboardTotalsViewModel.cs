namespace ExpenseTracker.Core.ViewModels.Dashboard
{
    public class DashboardTotalsViewModel
    {
        public DashboardTotalsViewModel() { }

        public DashboardTotalsViewModel(decimal totalSpentToday, decimal totalSpentThisWeek, decimal totalSpentThisMonth, decimal totalIncomeThisMonth)
        {
            TotalSpentToday = totalSpentToday;
            TotalSpentThisWeek = totalSpentThisWeek;
            TotalSpentThisMonth = totalSpentThisMonth;
            TotalIncomeThisMonth = totalIncomeThisMonth;
        }
        
        public decimal TotalSpentToday { get; set; }
        public decimal TotalSpentThisWeek { get; set; }
        public decimal TotalSpentThisMonth { get; set; }
        public decimal TotalIncomeThisMonth { get; set; }
    }
}
