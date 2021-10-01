using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishlistSavingPlanner.Models.Wishlist;

namespace WishlistSavingPlanner.Models.Browser
{
    public class WishlistBrowserModel
    {
        private WishlistItem wishlistItem;
        private DateTime availableToPurchaseDate;
        public WishlistBrowserModel(WishlistItem wishlistItem, DateTime availableToPurchaseDate)
        {
            this.wishlistItem = wishlistItem;
            this.availableToPurchaseDate = availableToPurchaseDate;
        }

        public DateTime AvailableToPurchaseDate { get => availableToPurchaseDate; set => availableToPurchaseDate = value; }
        public WishlistItem WishlistItem { get => wishlistItem; set => wishlistItem = value; }
    }
}
