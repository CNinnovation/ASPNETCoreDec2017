using System;
using Microsoft.EntityFrameworkCore;

namespace EFCoreSample
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateDatabase();
            AddRecords();
        }

        private static void CreateDatabase()
        {
            using (var context = new BooksContext())
            {
                bool created = context.Database.EnsureCreated();
                Console.WriteLine($"database created: {created}");
            }
        }

        private static void AddRecords()
        {
            using (var context = new BooksContext())
            {
                //int bookid = 42;

                //context.Database.ExecuteSqlCommand($"SELECT * FROM Books Where BookId == {bookid}");
                context.Books.Add(new Book { Title = "Professional C# 6", Publisher = "Wrox Press" });
                int recordschanged = context.SaveChanges();
                Console.WriteLine($"records changed: {recordschanged}");
            }
        }
    }
}
