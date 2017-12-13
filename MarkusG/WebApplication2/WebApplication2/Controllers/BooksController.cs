using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class BooksController : Controller
    {
        private List<Book> _books = new List<Book> {
            new Book { Id = 1, name = "C#6", pages = 800 },
            new Book { Id = 2, name = "ASP.NET MVC", pages = 600 },
            new Book { Id = 3, name = ".NET Core", pages = 900 }
        };

        public JsonResult Index() => Json(_books);

        public RedirectResult RedirectSample () => Redirect("http://www.cninnovation.com");
    }
}