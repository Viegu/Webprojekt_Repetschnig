using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meine_Website.Models;
using Meine_Website.Models.db;
using System.Data.Common;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Http;

namespace Meine_Website.Controllers {
    public class AccountController : Controller {
        MySqlConnection conn = new MySqlConnection();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader dr;


        IRepositoryAccount rep = new RepositoryAccount();
        public IActionResult Index() {
            return View();
        }

        [HttpGet]
        public IActionResult Register() {
            return View(new Account());

        }


            [HttpPost]
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
            ConnectionString();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "select * from Accounts where username='" + account.Username+"'";

            if (account == null) {
               
            }
            if (account.Username.Length < 3) {
                ModelState.AddModelError(nameof(Account.Username), "Der Username muss mind 3 Zeichen lang sein");

            }
            dr = cmd.ExecuteReader();
            if (dr.Read()) {
                ModelState.AddModelError(nameof(Account.Username), "Der Username existiert bereits!");
              

            } else {
                
                
            }

            if (account.Passwort != account.Passwort2) {
                ModelState.AddModelError(nameof(Account.Passwort), "Die Passswörter stimmen nicht überein!");
            }


            //if Username schon existiert

            if (account.Vorname == null || account.Vorname == "") {
                ModelState.AddModelError(nameof(Account.Vorname), "Der Vorname muss angegeben werden!");
            }

            if (account.Nachname == null || account.Nachname == "") {
                ModelState.AddModelError(nameof(Account.Nachname), "Der Nachname muss angegeben werden!");
            }

            if (!account.Email.Contains("@")||account.Email.Length<5) {
                ModelState.AddModelError(nameof(Account.Email), "Diese Email stimmt nicht!");
            }
            if (account.Passwort == null || account.Passwort2 == "") {
                ModelState.AddModelError(nameof(Account.Vorname), "Das Passwort muss angegeben werden!");
            }



            if (account.Geburtsdatum== null) {
                ModelState.AddModelError(nameof(Account.Geburtsdatum), "Geburtsdatum muss angegeben werden!");
            }
        }



        //Login
        [HttpGet]
     
        public IActionResult Login() {
            return View(new Login());
        }

        [HttpPost]
        void ConnectionString() {
              conn.ConnectionString = "server=localhost;database=db_accounts;user=root;pwd=ABC13Y@12Bz";
    }
        public IActionResult Login(Login login) {
            bool suc;
            ConnectionString();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText ="select * from Accounts where username='" + login.Username + "' and passwort='" + login.Passwort + "'";
            
            dr = cmd.ExecuteReader();

            if (dr.Read()) {
                suc = true;
               
                

            } else {
                suc = false;
              
            }
            conn.Close();
            conn.Open();
            cmd.Connection = conn;
            if(suc == true)
            {
                cmd.CommandText = "select * from Accounts where username='" + login.Username + "' and istModerator=true";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    HttpContext.Session.SetInt32("mod", 1);
                }
             
                HttpContext.Session.SetString("username", login.Username);


                conn.Close();
                return View("LoginSuccesfull");
            }
            else
            {
                conn.Close();
                return View("LoginNotSuccesfull");
            }
           
                    

        }
        //Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("mod");
            return RedirectToAction("index", "home");
        }



    }
}
