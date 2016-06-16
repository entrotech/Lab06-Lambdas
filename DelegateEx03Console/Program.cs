using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DelegateLibrary;

namespace DelegateEx03Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Delegate Example 3:");
            Console.WriteLine("Generic Delegate as a Call-Back method");

            double[] myDoubles = { 2, 1.41, 7.2 };
            int[] myIntegers = { 2, 3, 7 };
            decimal[] myDecimals = { 5.6M, 8.2M, -2.345M };

            // Because myDoubles is a double array,
            // compiler looks for method Square that
            // has type parameter of  double.
            Console.WriteLine("\r\nSquaring doubles with callback:");
            Transformer<double> doubleTransformer = Square;
            Transformers.Transform(myDoubles, doubleTransformer);

            foreach (var item in myDoubles)
            {
                Console.WriteLine("Squared Double: "
                    + item);
            }

            // Because myIntegers is an integer array,
            // compiler looks for method Square that
            // has type parameter of int.
            Console.WriteLine("\r\nSquaring integers with callback:");
            Transformers.Transform(myIntegers, Square);

            foreach (var item in myIntegers)
            {
                Console.WriteLine("Squared Int: "
                    + item);
            }

            Console.WriteLine("\r\nUsing pre-defined Func delegate:");
            Transformers.TransformFunc(myDecimals, Square);

            foreach (var item in myDecimals)
            {
                Console.WriteLine("Squared Decimal: "
                    + item);
            }

            Console.WriteLine("Press <Enter> to quit the program:");
            Console.ReadLine();
        }

        static double Square(double d)
        {
            return d * d;
        }

        static int Square(int i)
        {
            return i * i;
        }

        static decimal Square(decimal d)
        {
            return d * d;
        }
    }
}
