using System;

namespace WishlistSavingPlanner.Core
{
    public static class NullChecker
    {
        public static void ThrowIfNull<T>(this T o, string parameName) where T : class
        {
            if (o == null)
                throw new ArgumentNullException(parameName);
        }
    }
}
