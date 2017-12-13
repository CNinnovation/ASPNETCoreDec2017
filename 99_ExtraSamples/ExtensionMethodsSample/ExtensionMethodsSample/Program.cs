using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegatesIrInterfaces
{
    static class CollectionExtensions
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T, bool> pred)
        {
            foreach (T item in source)
            {
                if (pred(item))
                    yield return item;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>()
            {
                new Person { FirstName = "Jochen", LastName = "Rindt"},
                new Person { FirstName = "Niki", LastName = "Lauda"},
                new Person { FirstName = "Juan Manuel", LastName = "Fangio"},
                new Person { FirstName = "Gerhard", LastName = "Berger"},
                new Person { FirstName = "Alex", LastName = "Wurz"},
                new Person { FirstName = "James", LastName = "Hunt"}
            };


            var jRacers = people.Where(p => p.FirstName.StartsWith("J")).ToList();
            people.Add(new Person { FirstName = "Jack", LastName = "Brabham" });
            foreach (var r in jRacers)
            {
                Console.WriteLine(r);
            }

            var orderedPeople = people.OrderBy(p => p.LastName);

        }
    }
}
