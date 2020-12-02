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

        [HttpGet]
        public IActionResult Free()
        {
            return View(new Models.Account());
        }
        [HttpPost]
        public IActionResult Free(Models.Account newAccount)
        {
            // Parameter überprüfen
            if (newAccount == null)
            {
                return RedirectToAction("Free");
            }
            ValidateAccountData(newAccount);

            if (ModelState.IsValid)
            {
              
                return RedirectToAction("index", "home");
            }
            return View(newAccount);
        }
        

        public IActionResult Standard()
        {
            return View();
        }

        public IActionResult Premium()
        {
            return View();
        }

        private void ValidateAccountData(Models.Account a)
        {
            if(a == null)
            {
                return;
            }

            a.Username = a.Username ?? "";

            if(a.Username.Length < 4)
            {
                ModelState.AddModelError(nameof(Models.Account.Username),"Der Username muss mind. 5 Zeichen lang sein!");
            }


            if (a.Passwort != a.Passwort1)
            {
                ModelState.AddModelError(nameof(Models.Account.Passwort), "Die Passwörter stimmen nicht überein");
            }

            if (!a.Email.Contains("@"))
            {
                ModelState.AddModelError(nameof(Models.Account.Email), "Die email Stimmt nicht!!");
            }


            if (a.Vorname == null)
            {
                ModelState.AddModelError(nameof(Models.Account.Vorname), "Pflichtfeld!");
            }

            if (a.Nachname == null)
            {
                ModelState.AddModelError(nameof(Models.Account.Nachname), "Pflichtfeld!");
            }

            if (a.Geschlecht == Models.Geschlecht.nichtAngegeben)
            {
                ModelState.AddModelError(nameof(Models.Account.Nachname), "Bitte GEschlecht angeben");
            }

        }

    }
}
