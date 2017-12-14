using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace PakoCoreEF.Models
{
    class BooksContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        private const string ConnectionString = @"server=(localdb)\mssqllocaldb;database=BooksSample;trusted_connection=true";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
