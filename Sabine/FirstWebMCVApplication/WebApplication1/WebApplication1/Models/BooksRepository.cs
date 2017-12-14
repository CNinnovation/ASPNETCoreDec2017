using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class BooksRepository : IBooksRepository
    {
        public Book GetBook()
        {
            return new Book() { Id = 3, Author = "Author", Titel = "MyBook" };
        }
    }
}
