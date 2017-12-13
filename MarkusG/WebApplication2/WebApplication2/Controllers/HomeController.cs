using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBooksRepository _booksRepService;

        public HomeController(IBooksRepository booksRepService)
        {
            _booksRepService = booksRepService;
        }

        public string Index()
        {
            return ("Hello World");
        }

        public string Greeting1(string name) => $"Hello, {name}";

        public string Greeting2(string name) => $"Hello, {name}";

        private List<Book> _books = new List<Book> {
            new Book { Id = 1, name = "C#6", pages = 800 },
            new Book { Id = 2, name = "ASP.NET MVC", pages = 600 },
            new Book { Id = 3, name = ".NET Core", pages = 900 }
        };

        public JsonResult BookExample(int Id, string name, int pages) => Json(_booksRepService.GetBook(Id, name, pages));
    }
}