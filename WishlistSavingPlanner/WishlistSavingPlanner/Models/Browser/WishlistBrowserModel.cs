using System;
using System.ComponentModel;
using WishlistSavingPlanner.Models.Wishlist;

namespace WishlistSavingPlanner.Models.Browser
{
    public class WishlistBrowserModel : INotifyPropertyChanged
    {
        private WishlistItem wishlistItem;
        private DateTime availableToPurchaseDate;
        public WishlistBrowserModel(WishlistItem wishlistItem, DateTime availableToPurchaseDate)
        {
            this.wishlistItem = wishlistItem;
            this.availableToPurchaseDate = availableToPurchaseDate;
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public DateTime AvailableToPurchaseDate
        {
            get => availableToPurchaseDate;
            set
            {
                availableToPurchaseDate = value;
                OnPropertyChanged(nameof(AvailableToPurchaseDate));
            }
        }
        public WishlistItem WishlistItem
        {
            get => wishlistItem;
            set
            {
                wishlistItem = value;
                OnPropertyChanged(nameof(WishlistItem));
            }
        }
    }
}
