using System.Collections.Generic;
using MVCWithEFCore.Models;

namespace MVCWithEFCore.Services
{
    public interface IBooksService
    {
        Book AddBook(Book book);
        void DeleteBook(int id);
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        void UpdateBook(Book book);
    }
}