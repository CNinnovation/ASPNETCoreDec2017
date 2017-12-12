using System;
using System.Collections.Generic;

namespace DelegatesIrInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>()
            {
                new Person { FirstName = "Niki", LastName = "Lauda"},
                new Person { FirstName = "Gerhard", LastName = "Berger"},
                new Person { FirstName = "Alex", LastName = "Wurz"}
            };

            people.Sort();

            foreach (var p in people)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();

            people.Sort(new PersonComparer(PersonCompareType.FirstName));

            Console.WriteLine("new sort");
            foreach (var p in people)
            {
                Console.WriteLine(p);
            }

            people.Sort((p1, p2) => 
                p2.LastName.CompareTo(p1.LastName));

            Console.WriteLine("new sort");
            foreach (var p in people)
            {
                Console.WriteLine(p);
            }
        }
    }
}
