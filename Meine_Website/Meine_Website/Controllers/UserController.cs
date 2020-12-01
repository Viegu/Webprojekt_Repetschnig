using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meine_Website.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyAccount()
        {
            return View();
        }

        public IActionResult Free()
        {
            return View();
        }

        public IActionResult Standard()
        {
            return View();
        }

        public IActionResult Premium()
        {
            return View();
        }
    }
}
