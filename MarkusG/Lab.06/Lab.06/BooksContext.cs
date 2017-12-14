using Lab._06.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab._06
{
    public class BooksContext : DbContext {
        private const string ConnectionString = @"server=(localdb)\mssqllocaldb;database=BookSample;trusted_connection=true";

        public DbSet<Book> Books { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
