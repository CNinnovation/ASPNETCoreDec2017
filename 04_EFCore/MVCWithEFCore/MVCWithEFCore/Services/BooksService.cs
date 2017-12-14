using MVCWithEFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWithEFCore.Services
{
    public class BooksService : IBooksService
    {
        private BooksContext _booksContext;
        public BooksService(BooksContext booksContext)
        {
            _booksContext = booksContext;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _booksContext.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return _booksContext.Books.Find(id);
        }

        public Book AddBook(Book book)
        {
            _booksContext.Books.Add(book);
            _booksContext.SaveChanges();
            return book;
        }

        public void UpdateBook(Book book)
        {
            _booksContext.Books.Update(book);
            _booksContext.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            Book book = _booksContext.Books.Find(id);
            _booksContext.Books.Remove(book);
            _booksContext.SaveChanges();
        }
    }
}
