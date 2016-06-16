using System;
using Talent.Domain;
using Talent.Domain.TestData;

namespace DelegateEx05Console
{
    class Program
    {
        static void Main(string[] args)
        {
             
            Console.WriteLine("Delegate Example 5:");
            Console.WriteLine("Multicast Delegates");

            DomainObjectStore store = new DomainObjectStore();

           var people = store.People;

            Action<Person> act1 = null;
            
            act1 += PrintName;
            act1 += PrintAge;

            Console.WriteLine("\r\nPrintName and Age:");
            act1(people[0]);

            Console.WriteLine("\r\nSame method can be invoked multiple times:");
            act1 += PrintName;
            act1 += PrintAge;
            act1(people[1]);

            Console.WriteLine("\r\nCan remove method from invocation list:");
            act1 -= PrintName;
            act1(people[0]);

            Console.WriteLine("\r\nWhen a method in the invocation list fails:");
            Action<Person> act2 = null;
            act2 += PrintName;
            act2 += BadMethod;
            act2 += PrintAge;
            try
            {
                act2(people[1]);
            }
            catch (ApplicationException)
            {
                Console.WriteLine("When exception is thrown, "
                + "delegate stops processing methods on the invocation list!");
            }

            Console.WriteLine("\r\nManually iterating through invocation list:");
            Console.WriteLine("Allows handling exceptions or retrieving return values");
            foreach (Action<Person> m in act2.GetInvocationList())
            {
                try
                {
                    m(people[1]);
                }
                catch( ApplicationException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine("\r\nA Delegate with an empty invocation list");
            Console.WriteLine("throws an exception if invoked.");
            act2 -= PrintName;
            act2 -= BadMethod;
            act2 -= PrintAge;
            // act2(people[0]);  // this would throw an exception, since we 
            // need to check for empty invocation list
            // if it might be empty.
            if (act2 != null)
            {
                act2(people[0]);
            }

            Console.WriteLine("\r\nPress <Enter> to quit the program:");
            Console.ReadLine();
        }

        private static void PrintName(Person emp)
        {
            Console.WriteLine("Name: " + emp.LastFirstName);
        }

        private static void PrintAge(Person emp)
        {
            Console.WriteLine("Age: " + emp.Age);
        }

        private static void BadMethod(Person emp)
        {
            throw new ApplicationException("BadMethod failed!");
        }
    }
}
