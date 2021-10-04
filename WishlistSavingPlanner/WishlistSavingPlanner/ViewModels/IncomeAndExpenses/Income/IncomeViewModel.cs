using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishlistSavingPlanner.Enums;
using WishlistSavingPlanner.Models;
using System.Linq;
using System.Windows.Input;
using WishlistSavingPlanner.Core.Command;
using System.IO.IsolatedStorage;
using System.Text.Json;
using System.IO;

namespace WishlistSavingPlanner.ViewModels.IncomeAndExpenses.Income
{
    public class IncomeViewModel
    {
        private ObservableCollection<CashflowModel> cashflowItems;

        private double amount;
        private string name;
        private DateTime dateOccure;
        private CashflowRate selectedRate;
        private CashflowModel selectedCashflowItem;
        private List<CashflowRate> cashflowRates;

        private ICommand? addButtonClick;
        private ICommand? removeButtonClick;

        public IncomeViewModel()
        {
            cashflowItems = ReadData();
            cashflowItems.CollectionChanged += CashflowItems_CollectionChanged;

            cashflowRates = new List<CashflowRate>(Enum.GetValues(typeof(CashflowRate)) as CashflowRate[]);
            dateOccure = DateTime.Now;
        }

        private void CashflowItems_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            SaveData();
        }

        public CashflowRate SelectedRate { get => selectedRate; set => selectedRate = value; }
        public DateTime DateOccure { get => dateOccure; set => dateOccure = value; }
        public string Name { get => name; set => name = value; }
        public double Amount { get => amount; set => amount = value; }

        public ObservableCollection<CashflowModel> CashflowItems => cashflowItems;
        public CashflowModel SelectedCashflowItem { get => selectedCashflowItem; set => selectedCashflowItem = value; }

        public List<CashflowRate> CashflowRates => cashflowRates;

        public ICommand AddButtonClick
        {
            get => addButtonClick ?? (addButtonClick = new RelayCommand(param => AddCashflowItem(), param => CanAddCashflowItem()));
        }

        public ICommand RemoveButtonClick
        {
            get => removeButtonClick ?? (removeButtonClick = new RelayCommand(param => RemoveCashflowItem(), param => CanRemoveCashflowItem()));
        }

        private void AddCashflowItem()
        {
            CashflowModel cashflow = new CashflowModel(Amount, Name, SelectedRate, DateOccure);
            CashflowItems.Add(cashflow);
        }

        private bool CanAddCashflowItem()
        {
            return Amount > 0;
        }

        private void RemoveCashflowItem()
        {
            CashflowItems.Remove(SelectedCashflowItem);
        }

        private bool CanRemoveCashflowItem()
        {
            return SelectedCashflowItem != null;
        }

        public string Title => "Income tab";

        private void SaveData()
        {
            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly, null, null))
            {
                if (isoStore.FileExists("income.json"))
                {
                    // We already have an old one, delete it
                    isoStore.DeleteFile("income.json");
                }
                using (IsolatedStorageFileStream fs = isoStore.CreateFile("income.json"))
                {
                    JsonSerializer.Serialize(fs, CashflowItems);
                }
            }
        }

        private ObservableCollection<CashflowModel> ReadData()
        {
            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly, null, null))
            {
                if (isoStore.FileExists("income.json"))
                {
                    using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("income.json", FileMode.Open, isoStore))
                    {
                        using (StreamReader reader = new StreamReader(isoStream))
                        {
                            try
                            {
                                return JsonSerializer.Deserialize<ObservableCollection<CashflowModel>>(reader.ReadToEnd()) ?? new ObservableCollection<CashflowModel>();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message); //TODO replace this with logger
                                return new ObservableCollection<CashflowModel>();
                            }
                        }
                    }
                }
                else
                {
                    return new ObservableCollection<CashflowModel>();
                }
            }
        }
    }
}
