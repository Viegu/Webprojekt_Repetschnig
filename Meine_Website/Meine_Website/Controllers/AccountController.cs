using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meine_Website.Controllers
{
    public class AccountController : Controller
    {
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
