using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using WishlistSavingPlanner.Core.Command;
using WishlistSavingPlanner.Models.Browser;
using WishlistSavingPlanner.Models.Wishlist;
using WishlistSavingPlanner.Views;

namespace WishlistSavingPlanner.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private int wishlistPrice;
        private string? wishlistName;
        private string? wishlistLink;
        private string? wishlistPriority;

        private ICommand? addButtonClick;
        private ICommand? removeButtonClick;
        private ICommand? setupIncomeAndExpensesButtonClick;

        private WishlistBrowserModel? selectedWishlistItem;

        private ObservableCollection<WishlistBrowserModel> wishlistBrowserItemList;

        public MainWindowViewModel()
        {
            wishlistBrowserItemList = ReadWishlistData();
            wishlistBrowserItemList.CollectionChanged += WishlistBrowserItemList_CollectionChanged;
        }

        private void WishlistBrowserItemList_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UpdateAvailableDates();
            SaveData();
        }

        public ICommand AddButtonClick
        {
            get => addButtonClick ?? (addButtonClick = new RelayCommand(param => AddWishlistItem(), param => CanAddWishlistItem()));
        }

        public ICommand RemoveButtonClick
        {
            get => removeButtonClick ?? (removeButtonClick = new RelayCommand(param => RemoveWishlistItem(), param => CanRemoveWishlistItem()));
        }

        public ICommand SetupIncomeAndExpensesButtonClick
        {
            get => setupIncomeAndExpensesButtonClick ?? (setupIncomeAndExpensesButtonClick = new RelayCommand(param => OpenIncomeAndExpensesButtonWindow()));
        }
        

        public ObservableCollection<WishlistBrowserModel> WishlistBrowserItemList
        {
            get => wishlistBrowserItemList;
            set
            {
                wishlistBrowserItemList = value;
            }
        }

        public int WishlistPrice { get => wishlistPrice; set => wishlistPrice = value; }
        public string? WishlistName { get => wishlistName; set => wishlistName = value; }
        public string? WishlistLink { get => wishlistLink; set => wishlistLink = value; }
        public string? WishlistPriority { get => wishlistPriority; set => wishlistPriority = value; }
        public WishlistBrowserModel? SelectedWishlistItem { get => selectedWishlistItem; set => selectedWishlistItem = value; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void OpenIncomeAndExpensesButtonWindow()
        {
            IncomeAndExpensesViewModel incomeAndExpensesViewModel = new IncomeAndExpensesViewModel();
            IncomeAndExpensesWindow setupWindow = new IncomeAndExpensesWindow(incomeAndExpensesViewModel);
            setupWindow.ShowDialog();
        }

        private void RemoveWishlistItem()
        {
            if (selectedWishlistItem != null)
            {
                WishlistBrowserItemList.Remove(SelectedWishlistItem);
            }
        }

        private bool CanRemoveWishlistItem()
        {
            return SelectedWishlistItem != null;
        }

        private void AddWishlistItem()
        {
            WishlistItem newWishlistItem = new WishlistItem(WishlistName, WishlistLink, WishlistPriority, WishlistPrice);
            WishlistBrowserItemList.Add(new WishlistBrowserModel(newWishlistItem, new DateTime()));
        }

        private bool CanAddWishlistItem()
        {
            return !string.IsNullOrEmpty(WishlistName);
        }

        private void UpdateAvailableDates()
        {

        }

        private void SaveData()
        {
            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly, null, null))
            {
                if (isoStore.FileExists("wishlist.json"))
                {
                    // We already have an old one, delete it
                    isoStore.DeleteFile("wishlist.json");
                }
                using (IsolatedStorageFileStream fs = isoStore.CreateFile("wishlist.json"))
                {
                    JsonSerializer.Serialize(fs, WishlistBrowserItemList);
                }
            }
        }

        private ObservableCollection<WishlistBrowserModel> ReadWishlistData()
        {
            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly, null, null))
            {
                if (isoStore.FileExists("wishlist.json"))
                {
                    using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("wishlist.json", FileMode.Open, isoStore))
                    {
                        using (StreamReader reader = new StreamReader(isoStream))
                        {
                            return JsonSerializer.Deserialize<ObservableCollection<WishlistBrowserModel>>(reader.ReadToEnd()) ?? new ObservableCollection<WishlistBrowserModel>();
                        }
                    }
                }
                else
                {
                    return new ObservableCollection<WishlistBrowserModel>();
                }
            }
        }
    }
}
