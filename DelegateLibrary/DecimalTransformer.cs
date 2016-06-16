using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegateLibrary
{
    public class DecimalTransformer
    {
        public static void Transform(decimal[] values
            , AdjustDelegate adj)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = adj(values[i]);
            }
        }
    }
}
