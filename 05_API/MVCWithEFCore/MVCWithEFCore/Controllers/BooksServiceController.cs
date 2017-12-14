using Microsoft.AspNetCore.Mvc;
using MVCWithEFCore.Models;
using MVCWithEFCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWithEFCore.Controllers
{
    public class BooksServiceController : Controller
    {
        private readonly IBooksService _booksService;

        public BooksServiceController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        public IActionResult Index()
        {
            var books = _booksService.GetAllBooks();
            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create1(Book book)
        {
            _booksService.AddBook(book);
            return View("Index");
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            return View();
        }

        
    }
}
