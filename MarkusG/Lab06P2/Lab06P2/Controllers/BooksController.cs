using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab06P2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab06P2.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult Add(Book book) 
        {
            return View();
        }
    }
}