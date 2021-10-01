using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishlistSavingPlanner.Models.Browser;
using WishlistSavingPlanner.Models.Wishlist;

namespace WishlistSavingPlanner.ViewModels
{
    public class MainWindowViewModel
    {
        private List<WishlistBrowserModel> wishlistBrowserItemList;
        public MainWindowViewModel()
        {
            wishlistBrowserItemList = new List<WishlistBrowserModel>();
            wishlistBrowserItemList.Add(new WishlistBrowserModel(new WishlistItem("Test name", "Test link", "Test url", 100), DateTime.Now));
        }

        public List<WishlistBrowserModel> WishlistBrowserItemList
        {
            get => wishlistBrowserItemList;
            set
            {
                wishlistBrowserItemList = value;
            }
        }
    }
}
