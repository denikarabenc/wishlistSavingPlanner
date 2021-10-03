using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishlistSavingPlanner.ViewModels.IncomeAndExpenses.Expenses;
using WishlistSavingPlanner.ViewModels.IncomeAndExpenses.Income;

namespace WishlistSavingPlanner.ViewModels
{
    public class IncomeAndExpensesViewModel
    {
        private IncomeViewModel incomeViewModel;
        private ExpensesViewModel expensesViewModel;

        public IncomeAndExpensesViewModel()
        {
            IncomeViewModel = new IncomeViewModel();
            ExpensesViewModel = new ExpensesViewModel();
        }

        public IncomeViewModel IncomeViewModel { get => incomeViewModel; set => incomeViewModel = value; }
        public ExpensesViewModel ExpensesViewModel { get => expensesViewModel; set => expensesViewModel = value; }
    }
}
