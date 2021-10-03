using System.ComponentModel;

namespace WishlistSavingPlanner.Models.Wishlist
{
    public class WishlistItem : INotifyPropertyChanged
    {
        private string name;
        private string link;
        private int priority;
        private int price;

        public WishlistItem(string name, string link, int priority, int price)
        {
            this.name = name;
            this.link = link;
            this.priority = priority;
            this.price = price;
        }

        public string Name { get => name; set => name = value; }
        public string Link { get => link; set => link = value; }
        public int Priority { get => priority; set => priority = value; }
        public int Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
