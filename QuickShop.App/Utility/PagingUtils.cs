using System;
using System.Linq;

namespace QuickShop.App.Utility
{
    // Simple utlity class for dropdown logic of product number per page 
    public static class PagingUtils
    {
        public static readonly int[] AllowedProductValues = { 10, 25, 50, 100, 200 };
        public static int CheckProductNumberValue(int value)
        {
            if (AllowedProductValues.Contains(value))
                return value;
            int closest = AllowedProductValues[0];
            int diff = Math.Abs(closest - value);
            for (int i = 1; i < AllowedProductValues.Length; i++)
            {
                if (diff > Math.Abs(AllowedProductValues[i] - value))
                {
                    closest = AllowedProductValues[i];
                    diff = Math.Abs(closest - value);
                }    
            }
            return closest;
        }
    }
}
