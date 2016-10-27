using System;
using System.Collections.Generic;

namespace ExpenseTracker.Core.ViewModels.Dashboard
{
    public class DashboardPieChartViewModel
    {
        public IEnumerable<PieChartCategory> PieChartCategories { get; set; }
    }

    public class PieChartCategory
    {
        public PieChartCategory() { }

        public PieChartCategory(string categoryName, decimal percentageOfExpenses)
        {
            CategoryName = categoryName;
            PercentageOfExpenses = percentageOfExpenses;
            Color = GetRandomColor();
        }

        public string CategoryName { get; set; }
        public decimal PercentageOfExpenses { get; set; }
        public string Color { get; private set; }

        private string GetRandomColor()
        {
            var random = new Random();
            var color = string.Format("#{0:X6}", random.Next(0x1000000));
            return color;
        }
    }
}