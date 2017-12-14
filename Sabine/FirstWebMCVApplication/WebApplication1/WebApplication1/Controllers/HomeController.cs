using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller

    {

        private readonly IBooksRepository _booksRepository;

        public HomeController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }
        public string Index() => "Index of Homecontroller";

        public string Greetings1(string name) => $"Hallo, {name}";

        public Book ShowBooks()
        {
            return _booksRepository.GetBook();
        }
    }
}