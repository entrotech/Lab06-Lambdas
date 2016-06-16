using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegateLibrary
{
    // Declare a generic delegate
    public delegate T Transformer<T>(T arg);

    public class Transformers
    {
        // Generic method operates on arrays of type
        // T, requiring Transformer delegate of same
        // type.
        public static void Transform<T>(T[] values
            , Transformer<T> trans)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = trans(values[i]);
            }
        }

        public static void TransformFunc<T>(T[] values,
            Func<T, T> trans)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = trans(values[i]);
            }
        }
    }
}
