using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCWithEFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWithEFCore.Controllers
{
    public class BooksController : Controller
    {
        private BooksContext _booksContext;
        public BooksController(BooksContext booksContext)
        {
            _booksContext = booksContext;
        }

        public IActionResult Index()
        {
            return Json(_booksContext.Books);
        }

        public bool CreateDatabase()
        {
            bool created = _booksContext.Database.EnsureCreated();
            return created;
        }

        public bool CreateDatabaseWithMigrations()
        {
            _booksContext.Database.Migrate();
            return true;
        }
    }
}
