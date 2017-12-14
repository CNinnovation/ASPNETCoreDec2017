using System;

namespace Lab._06
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateDatabase();
            AddBooks();
            Console.ReadLine();
        }

        private static void AddBooks() {
            using (var context = new BooksContext()) {
                context.Books.Add(new Models.Book { Title = "Programming C#6", Publisher = "Wox", Pages = 20});
                int saved = context.SaveChanges();
                Console.WriteLine($"Saved: {saved}");
            }
        }

        private static void CreateDatabase() {
            using (var context = new BooksContext()) {
                bool created = context.Database.EnsureCreated();
                Console.WriteLine($"Is created:{created}");
            }
        }
    }
}
