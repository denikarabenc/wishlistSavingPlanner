using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishlistSavingPlanner.Core.Interfaces
{
    internal interface IDatabaseOperations
    {
        void SaveData();

        T ReadData<T>();

    }
}
