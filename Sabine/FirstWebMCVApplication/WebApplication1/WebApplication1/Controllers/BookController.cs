using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BookController : Controller
    {
        private List<Book> _books = new List<Book>
        {
            new Book { Id = 1, Author="Me", Titel="Book 1" },
            new Book { Id = 2, Author="You", Titel="Book 2" }
        };

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetBooksAsJson()
        {
            return Json(_books);
        }


    }
}