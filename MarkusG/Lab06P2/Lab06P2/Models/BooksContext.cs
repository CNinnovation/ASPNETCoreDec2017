using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab06P2.Models
{
    public class BooksCOntext : DbContext
    {
        private const string ConnectionString = @"server=(localdb)\mssqllocaldb;database=BookSample;trusted_connection=true";

        public DbSet<Book> Books { get; set; }

        private BooksCOntext _booksContext;

        public BooksCOntext(BooksCOntext bookContext) {
            _booksContext = bookContext;
        }

        public bool CreateDatabase() {
            bool created = _booksContext.Database.EnsureCreated();
            return created;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        public void AddBook(Book book) {
            _booksContext.Add(book);
            _booksContext.SaveChanges();
        }
    }
}
