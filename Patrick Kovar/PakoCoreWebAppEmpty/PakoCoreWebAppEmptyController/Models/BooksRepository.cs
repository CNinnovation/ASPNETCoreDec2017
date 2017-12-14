using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PakoCoreWebAppEmptyController.Models
{
    public class BooksRepository : IBooksRepository {

        public Book GetBook() {

            var book = new Book() { Title = "BuchTitel", Author = "Pako", IsPublished = true };
            return book;
        }
    }
}
