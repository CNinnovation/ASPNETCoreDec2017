using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMVCWebApp.Models
{
    public class MyBooksViewModel
    {
        public string Title { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
