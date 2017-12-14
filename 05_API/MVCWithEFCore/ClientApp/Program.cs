using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("client - wait for service");
            Console.ReadLine();

            HttpHelper<Book> httpBooks = new HttpHelper<Book>();
            IEnumerable<Book> books = await httpBooks.GetAllAsync("http://localhost:52048/api/ApiBooks");
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title}");
            }

            Console.ReadLine();
        }
    }
}
