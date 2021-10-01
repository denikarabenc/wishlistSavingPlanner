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
using System.Windows.Navigation;
using System.Windows.Shapes;
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
            if(vm == null)
            {
                throw new ArgumentNullException("view model cannot be null");
            }

            viewModel = vm;
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
