using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharp
{
    public static class NumberHelpers
    {
        public static bool IsEven(this int value)
        {
            return value % 2 == 0;
        }
    }
}
