using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Domain;
using Talent.Domain.TestData;

namespace LambdaSortConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lambda Expression Sorting:");
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
            store.People.Sort( (p1, p2) => 
                String.Compare(p1.FirstLastName, p2.FirstLastName));

            foreach (var item in store.People)
            {
                Console.WriteLine("\t" + item);
            }

            Console.WriteLine("Example of Variable Capture with Lambdas");
            while(true)
            {
                Console.WriteLine("Enter a partial name and <Enter> to search, or just <Enter> to quit:");
                string criterion = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(criterion)) break;

                Person person = store.People
                    .Find(p => p.FirstLastName.ToUpper().Contains(criterion.ToUpper()));
                if (person == null)
                {
                    Console.WriteLine("(No matches)");
                }
                else
                {
                    Console.WriteLine(person.FirstLastName);
                }
            }
            

            //Console.WriteLine("Press <Enter> to quit the program:");
            //Console.ReadLine();
        }

        ///// <summary>
        ///// Sort by FirstName then LastName.
        ///// </summary>
        //private static int FirstNameComparison(Person p1, Person p2)
        //{
        //    return String.Compare(p1.FirstLastName, p2.FirstLastName, true);
        //}
    }
}
