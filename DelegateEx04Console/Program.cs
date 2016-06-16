using System;
using Talent.Domain;
using Talent.Domain.TestData;

namespace DelegateEx04Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Delegate Example 4:");
            Console.WriteLine("Using the FCL-defined Comparison<T> delegate as");
            Console.WriteLine(
                "an argument to the List<T>.Sort(Comparison<T> comp) method");

            DomainObjectStore store = new DomainObjectStore();

            // Use override of Sort method that takes a Comparison<T> delegate.
            // The point here is that the .Net Framework has a pre-defined delegate
            // Comparison<T> so we don't define a new delegate type, but use 
            // an existing one. Then the List<T> class has a 
            // Sort(Comparison<T> comp) method overload that can use the 
            // delegate to sort. Compare this to the Sort(IComparer c)
            // and you can see that this is a bit simpler than creating a whole
            // new class that just implements the IComparer.Compare() method. 
            store.People.Sort(FirstNameComparison);

            foreach (var item in store.People)
            {
                Console.WriteLine("\t" + item);
            }

            Console.WriteLine("Press <Enter> to quit the program:");
            Console.ReadLine();
        }

        /// <summary>
        /// Sort by FirstName then LastName.
        /// </summary>
        private static int FirstNameComparison(Person p1, Person p2)
        {
            return String.Compare(p1.FirstLastName, p2.FirstLastName, true);
        }
    }
}
