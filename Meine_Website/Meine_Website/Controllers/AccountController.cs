using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meine_Website.Models;
using Meine_Website.Models.db;
using System.Data.Common;

namespace Meine_Website.Controllers {
    public class AccountController : Controller {


        IRepositoryAccount rep = new RepositoryAccount();
        public IActionResult Index() {
            return View();
        }

        public IActionResult Register(Account neuerAccount) {
            if(neuerAccount == null) {
                return View(new Account());
            }
            
         

                ValidateAccountData(neuerAccount);

                if (ModelState.IsValid) {
                    try {
                        rep.Open();


                        if (rep.Insert(neuerAccount)) {
                            return View("Message", new Message("Datenbank-Erfolg", "Der Account wurde Erfolgreich erstellt und abgespeichert!"));
                        }

                    } catch (DbException) {
                        return View("Message", new Message("Datenbank-Fehler",
                        "Der Account konnte nicht erstellt werden!",
                        "Probieren Sie es bitte später erneut!"));
                    } finally {
                        rep.Close();
                    }
                    return RedirectToAction("index", "home");
                }
                return View(neuerAccount);
            
        }

        public IActionResult RegisteredAccounts() {
            try {
                rep.Open();
                return View(rep.GetAllAccounts());
            } catch (Exception e) {
                return View("Message", new Message(("Datenbankfehler"), e.Message));
            } finally {
                rep.Close();

            }
        }

        private void ValidateAccountData(Account account) {

            if (account == null) {
                return;
            }
            if (account.Username.Length < 3) {
                ModelState.AddModelError(nameof(Account.Username), "Der Username muss mind 3 Zeichen lang sein");

            }

            //if Username schon existiert

            if(account.Vorname == null || account.Vorname == "") {
                ModelState.AddModelError(nameof(Account.Vorname), "Der Vorname muss angegeben werden!");
            }

            if (account.Nachname == null || account.Nachname == "") {
                ModelState.AddModelError(nameof(Account.Nachname), "Der Nachname muss angegeben werden!");
            }

            if (!account.Email.Contains("@")||account.Email.Length<5) {
                ModelState.AddModelError(nameof(Account.Email), "Diese Email stimmt nicht!");
            }


            //PW wird ausgelassen kommt später noch

            if(account.Geburtsdatum== null) {
                ModelState.AddModelError(nameof(Account.Geburtsdatum), "Geburtsdatum muss angegeben werden!");
            }
        }
    }
}
