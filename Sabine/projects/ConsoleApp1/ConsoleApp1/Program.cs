using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ConsoleApp1 {
    class Program {
        static void Main(string[] args) {
            using (var context = new BookContext()) {
                context.Database.Migrate();
                context.SaveChanges();
            }

            AddRecords();
            Console.ReadLine();

        }



        public static void CreateDatabase() {
            using (var context = new BookContext()) {
                bool created = context.Database.EnsureCreated();
                Console.WriteLine($"database created: {created}");
            }

        }

        public static void AddRecords() {
            using (var context = new BookContext()) {
                context.Books.Add(new Book { Title = "My Book", Publisher = "Me", NewProp = "test" });
                int recordschanged = context.SaveChanges();
                Console.WriteLine($"records changed: {recordschanged}");
            }
        }
    }
}
