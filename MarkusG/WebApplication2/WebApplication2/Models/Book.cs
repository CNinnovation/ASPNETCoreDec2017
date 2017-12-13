using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Book
    {
        public Book()
        { }

        public Book(int Id, string name, int pages)
        {
            this.Id = Id;
            this.name = name;
            this.pages = pages;
        }

        public int Id { get; set; }
        public string name { get; set; }
        public int pages { get; set; }
    }
}
