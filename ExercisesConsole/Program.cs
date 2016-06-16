using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesConsole
{
    class Program
    {
        #region Static Methods

        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static void Display(string s)
        {
            Console.WriteLine(s);
        }

        public static decimal CalculateTieredSalesTax(decimal saleAmount)
        {
            if (saleAmount < 0.0M)
            {
                throw new ArgumentOutOfRangeException("Sale Amount must be positive");
            }
            if (saleAmount < 1000M)
            {
                return saleAmount * 0.07M;
            }
            else if (saleAmount < 5000M)
            {
                return saleAmount * 0.065M;
            }
            else
            {
                return saleAmount * 0.06M;
            }
        }

        #endregion
        
        static void Main(string[] args)
        {
            Console.WriteLine("Exercises:");

            // A Func for adding two integers
            Func<int, int, int> methAdd = Add;
            Console.WriteLine("Add using delegate: " + methAdd(2, 6));

            // Anonymous Method Implementation
            Func<int, int, int> anonAdd =
                delegate(int i, int j)
                {
                    return i + j;
                };
            Console.WriteLine("Add using anonymous method: " + anonAdd(2, 6));

            // Lambda Statement implementation
            Func<int, int, int> stmtAdd =
                (i, j) =>
                {
                    return i + j;
                };
            Console.WriteLine("Add using lambda statement: " + stmtAdd(2, 6));

            // Lambda Expression Implementation
            Func<int, int, int> exprAdd = (i, j) => i + j;
            Console.WriteLine("Add using lambda expression: " + exprAdd(2, 6));

            Console.WriteLine("\r\n\r\n");

            // An Action for writing to the console
            Action<string> methDisplay = Display;
            
            methDisplay("Display with delegate");

            Action<string> anonDisplay =
                delegate(string s)
                {
                    Console.WriteLine(s);
                };
            anonDisplay("Display with anonymous method");


            Action<string> stmtDisplay =
                s =>
                {
                    Console.WriteLine(s);
                };
            stmtDisplay("Display with lambda statement");

            Action<string> expDisplay = s => Console.WriteLine(s);
            expDisplay("Display with lambda expression");

            Console.WriteLine("\r\n\r\n");

            // A Func for calculating sales tax
            Func<decimal, decimal> methTax = CalculateTieredSalesTax;
            Console.WriteLine("Sales Tax Delegate: " + methTax(1200M));

            Func<decimal, decimal> anonTax =
                delegate(decimal saleAmount)
                {
                    if (saleAmount < 0.0M)
                    {
                        throw new ArgumentOutOfRangeException("Sale Amount must be positive");
                    }
                    if (saleAmount < 1000M)
                    {
                        return saleAmount * 0.07M;
                    }
                    else if (saleAmount < 5000M)
                    {
                        return saleAmount * 0.065M;
                    }
                    else
                    {
                        return saleAmount * 0.06M;
                    }
                };
            Console.WriteLine("Sales Tax Delegate: " + methTax(1200M));

            Func<decimal, decimal> stmtTax =
                saleAmount =>
                {
                    if (saleAmount < 0.0M)
                    {
                        throw new ArgumentOutOfRangeException("Sale Amount must be positive");
                    }
                    if (saleAmount < 1000M)
                    {
                        return saleAmount * 0.07M;
                    }
                    else if (saleAmount < 5000M)
                    {
                        return saleAmount * 0.065M;
                    }
                    else
                    {
                        return saleAmount * 0.06M;
                    }
                };
            Console.WriteLine("Sales Tax Lambda Statement: "
                + stmtTax(1200M));

            // Note: I was able to do the tiered calculation in a a single expression,
            // but was not able to find a way to throw the exception if the
            // sale amount was negative - not sure it can be done.
            // This is still pretty hard for a human to read, and I think 
            // the lambda statement implementation is better.
            Func<decimal, decimal> exprTax = s =>
                    (s < 1000M ? s * 0.07M :
                        (s < 5000M ? s * 0.065M :
                            s * 0.06M
                        )
                    );
            Console.WriteLine("Sales Tax Lambda Expression: " + exprTax(1200M));

            Console.WriteLine("Press <Enter> to quit the application");
            Console.ReadLine();

        }
    }
}
