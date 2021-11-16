using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationLayer.Helpers
{
    public static class Extensions
    {
        public static bool IsNullOrEmpty(this string str)
        {
            if (str == null || str.Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
