using System.Windows;
using WishlistSavingPlanner.Core;
using WishlistSavingPlanner.ViewModels;

namespace WishlistSavingPlanner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel viewModel = new MainWindowViewModel();
        public MainWindow(MainWindowViewModel vm)
        {
            vm.ThrowIfNull(nameof(vm));

            viewModel = vm;
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
