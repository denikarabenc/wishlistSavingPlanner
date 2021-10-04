using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WishlistSavingPlanner.Core;
using WishlistSavingPlanner.ViewModels;

namespace WishlistSavingPlanner.Views
{
    /// <summary>
    /// Interaction logic for IncomeAndExpensesWindow.xaml
    /// </summary>
    public partial class IncomeAndExpensesWindow : Window
    {
        private IncomeAndExpensesViewModel viewModel;
        public IncomeAndExpensesWindow(IncomeAndExpensesViewModel viewModel)
        {
            viewModel.ThrowIfNull(nameof(viewModel));
            this.viewModel = viewModel;

            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
