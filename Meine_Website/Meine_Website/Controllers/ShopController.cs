using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Meine_Website.Models;
using Microsoft.AspNetCore.Http;

namespace Meine_Website.Controllers
{
    
    public class ShopController : Controller
    {
        IRepositoryShop rep = new RepositoryShop();
        
        public IActionResult Index()
        {
            try {
                rep.Open();
                return View(rep.GetArticles());
            }catch(Exception e) {
                return View("Message", new Message("Fehler", e.Message));
            } finally {
                rep.Close();

            }
            
        }

        [HttpGet]
        public IActionResult CreateNewArticle() {
            return View(new Article());

        }
        [HttpPost]
        public IActionResult CreateNewArticle(Article newArt) {
            if(newArt == null) {
                return RedirectToAction("createNewArticle");
            }

            //ValidateData(newArt);

            if (ModelState.IsValid) {
                try {
                    rep.Open();

                    if (rep.Insert(newArt, HttpContext.Session.GetString("username"))) {
                        return View("Message", new Message("Glückwunsch", "Ihr Artikel/Dienstleistung wurde erfolgreich hochgeladen"));
                    }
                }catch(System.Data.Common.DbException) {
                    return View("Message", new Message("Fehler", "Beim hochladen des Artkels ist anscheinend ein fehler aufgetreten, Bitte probieren SIe es später erneut!"));
                }
                finally{
                    rep.Close();
                }


                return RedirectToAction("index", "home");
            }

            return View(newArt);
        }

        private void ValidateData(Article a) {
            if(a== null) {
                return;
            }
            
        }

        public IActionResult Delete(int id) {
            try {
                rep.Open();

                if (rep.Delete(id)) {
                    return View("Message", new Message("Datebank", "Der Artikel wurde gelöscht!"));
                } else {
                    return View("Message", new Message("Datebank", "Der Artikel konnte nicht gelöscht werden!"));
                }
            } catch (Exception ex) {
                return View("Message", new Message("Datenbankfehler", ex.Message));
            } finally {
                rep.Close();
            }
        }

        public JsonResult UsernameArticles() {
            try {
                rep.Open();
                string username = HttpContext.Session.GetString("username");
                List <Article> art = rep.getAllArticlesFromUser(username);
              if(art!= null) {
                    return Json(art);
                } else {
                    return Json("Fehler!");
                }
            } catch (Exception e) {
                return Json("DBFehler!");
            } finally {
                rep.Close();

            }
        }


        
    }
 
}
