using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class BooksRepository : IBooksRepository
    {
        public Book GetBook(int Id, string name, int pages) => new Book(Id, name, pages);
    }
}
