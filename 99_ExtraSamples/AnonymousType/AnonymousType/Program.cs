using System;

namespace AnonymousType
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new { FirstName = "Tom", LastName = "Turbo" };
            Console.WriteLine(x.GetType().Name);
        }
    }
}
