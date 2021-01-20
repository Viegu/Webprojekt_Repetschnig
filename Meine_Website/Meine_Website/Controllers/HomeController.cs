using Meine_Website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Meine_Website.Controllers
{
    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult News()
        {
            return View();
        }

        public IActionResult Impressum()
        {
            return View();
        }

        public IActionResult WhatIsBAFR()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

    }
}
