using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Models {
    class BookContext : DbContext {

        private const string ConnectionString = @"server=(localdb)\mssqllocaldb;database=BooksSample2;trusted_connection=true";
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        
    }
}
