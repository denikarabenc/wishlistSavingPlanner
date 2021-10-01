using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishlistSavingPlanner.Models.Wishlist;

namespace WishlistSavingPlanner.ViewModels
{
    public class MainWindowViewModel
    {
        private List<WishlistItem> wishlistItemList;
        public MainWindowViewModel()
        {
            wishlistItemList = new List<WishlistItem>();
            wishlistItemList.Add(new WishlistItem("Test name", "Test link", "Test url", 100));
        }

        public List<WishlistItem> WishlistItemList
        {
            get => wishlistItemList;
            set
            {
                wishlistItemList = value;
            }
        }
    }
}
