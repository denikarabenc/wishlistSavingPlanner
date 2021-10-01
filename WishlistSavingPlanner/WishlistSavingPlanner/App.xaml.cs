using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WishlistSavingPlanner.ViewModels;

namespace WishlistSavingPlanner
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App() 
        {
            MainWindowViewModel vm = new MainWindowViewModel();
            MainWindow mv = new MainWindow(vm);
            mv.Show();
        }

    }
}
