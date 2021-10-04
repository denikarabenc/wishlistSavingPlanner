//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.IO.IsolatedStorage;
//using System.Linq;
//using System.Text;
//using System.Text.Json;
//using System.Threading.Tasks;
//using WishlistSavingPlanner.Core.Interfaces;

//namespace WishlistSavingPlanner.Core.Database
//{
//    public class ImprovisedDatabase : IDatabaseOperations
//    {
//        public T ReadData<T>(string filename)
//        {
//            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly, null, null))
//            {
//                if (isoStore.FileExists("wishlist.json"))
//                {
//                    using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("wishlist.json", FileMode.Open, isoStore))
//                    {
//                        using (StreamReader reader = new StreamReader(isoStream))
//                        {
//                            try
//                            {
//                                return JsonSerializer.Deserialize<ObservableCollection<WishlistBrowserModel>>(reader.ReadToEnd()) ?? new ObservableCollection<WishlistBrowserModel>();
//                            }
//                            catch (Exception ex)
//                            {
//                                Console.WriteLine(ex.Message); //TODO replace this with logger
//                                return new ObservableCollection<WishlistBrowserModel>();
//                            }
//                        }
//                    }
//                }
//                else
//                {
//                    return new ObservableCollection<WishlistBrowserModel>();
//                }
//            }
//        }

//        public void SaveData<T>(T objectToSave)
//        {
//            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly, null, null))
//            {
//                if (isoStore.FileExists(objectToSave.GetType().ToString() + ".json"))
//                {
//                    // We already have an old one, delete it
//                    isoStore.DeleteFile(objectToSave.GetType().ToString() + ".json");
//                }
//                using (IsolatedStorageFileStream fs = isoStore.CreateFile(objectToSave.GetType().ToString() + ".json"))
//                {
//                    JsonSerializer.Serialize(fs, objectToSave);
//                }
//            }
//        }

//        private ObservableCollection<WishlistBrowserModel> ReadWishlistData()
//        {
            
//        }
//    }
//}
