using DelegateLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaStatementConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lambda Statements:");
            Console.WriteLine("Generic Delegate as a Call-Back method");

            double[] myDoubles = { 2, 1.41, 7.2 };
            int[] myIntegers = { 2, 3, 7 };
            decimal[] myDecimals = { 5.6M, 8.2M, -2.345M };

            // Because myDoubles is a double array,
            // compiler looks for method Square that
            // has type parameter of  double.
            Console.WriteLine("\r\nSquaring doubles with callback:");
            Transformer<double> doubleTransform =
                    (double x) =>
                    {
                        return x * x;
                    };

            Transformers.Transform(myDoubles, doubleTransform);

            foreach (var item in myDoubles)
            {
                Console.WriteLine("Squared Double: "
                    + item);
            }

            // Because myIntegers is an integer array,
            // compiler looks for method Square that
            // has type parameter of int.
            Console.WriteLine("\r\nSquaring integers with callback:");
            Transformers.Transform(myIntegers,
                i =>
                {
                    return i * i;
                }
                );


            foreach (var item in myIntegers)
            {
                Console.WriteLine("Squared Int: "
                    + item);
            }

            Console.WriteLine("\r\nUsing pre-defined Func delegate:");
            Transformers.TransformFunc(myDecimals,
                d =>
                {
                    return d * d;
                }
                );


            foreach (var item in myDecimals)
            {
                Console.WriteLine("Squared Decimal: "
                    + item);
            }

            Console.WriteLine("Press <Enter> to quit the program:");
            Console.ReadLine();
        }
    }
}
