using PakoCoreEF.Models;
using System;

namespace PakoCoreEF
{
    class Program
    {
        static void Main(string[] args)
        {
            var booksContext = new BooksContext();
            booksContext.Add(new Book() { Title = "Mein erstes Buch", BookId = 1, Publisher = "Selbstpublizierer" });
            booksContext.Add(new Book() { Title = "Mein zweites Buch", BookId = 2, Publisher = "Pakito" });
            booksContext.Add(new Book() { Title = "Mein drittes Buch", BookId = 3, Publisher = "Pako" });
            booksContext.Add(new Book() { Title = "Mein viertes Buch", BookId = 4, Publisher = "Selbstpublizierer" });
            booksContext.SaveChanges();
        }
    }
}
