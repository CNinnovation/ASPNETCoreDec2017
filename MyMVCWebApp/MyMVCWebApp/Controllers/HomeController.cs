using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMVCWebApp.Controllers
{
    public class HomeController : Controller
    {
        public string Index() => "Hello, ASP.NET Core MVC";

        public string Demo() => "Demo";

        public string WithId(string id) => $"received id: {id}";
    }
}
