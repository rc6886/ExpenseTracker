namespace ExpenseTracker.Core.ViewModels.Dashboard
{
    public class DashboardTotalsViewModel
    {
        public DashboardTotalsViewModel() { }

        public DashboardTotalsViewModel(double totalSpentToday, double totalSpentThisWeek, double totalSpentThisMonth, double totalIncomeThisMonth)
        {
            TotalSpentToday = totalSpentToday;
            TotalSpentThisWeek = totalSpentThisWeek;
            TotalSpentThisMonth = totalSpentThisMonth;
            TotalIncomeThisMonth = totalIncomeThisMonth;
        }
        
        public double TotalSpentToday { get; set; }
        public double TotalSpentThisWeek { get; set; }
        public double TotalSpentThisMonth { get; set; }
        public double TotalIncomeThisMonth { get; set; }
    }
}
