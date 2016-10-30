using System.Collections.Generic;

namespace ExpenseTracker.Core.Domain.Budget
{
    public class Budget
    {
        public Budget()
        {
            _budgetCategories = new List<BudgetCategory>();
        }

        private List<BudgetCategory> _budgetCategories;
        public IReadOnlyCollection<BudgetCategory> BudgetCategories => _budgetCategories;

        public void AddBudgetCategory(BudgetCategory budgetCategory)
        {
            _budgetCategories.Add(budgetCategory);
        }
    }

    public class BudgetCategory
    {
        public BudgetCategory(string name, decimal dollarAmountSpentInCategory, decimal dollarAmountBudgetedToCategory)
        {
            Name = name;
            DollarAmountSpentInCategory = dollarAmountSpentInCategory;
            DollarAmountBudgetedToCategory = dollarAmountBudgetedToCategory;
        }

        public string Name { get; private set; }
        public decimal DollarAmountSpentInCategory { get; }
        public decimal DollarAmountBudgetedToCategory { get; }

        public decimal PercentOfBudgetSpent
        {
            get
            {
                if (DollarAmountSpentInCategory == 0 || DollarAmountBudgetedToCategory == 0) { return 0; }

                return DollarAmountSpentInCategory / DollarAmountBudgetedToCategory;
            }
        }
    }
}