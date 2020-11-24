using Meine_Website.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meine_Website.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View(CreateArticleList());
        }
        private List<Article> CreateArticleList()
        {

            // normalerweise würden die Artikel aus einer DB-Tabelle geladen
            return new List<Article>()
            {
                new Article(1, "Create a Logo", 5.0m, "Ich erstelle euch ein Logo innerhalb von 2 Tagen.", Models.Category.Design),
                new Article(2, "Automodell", 30.0m, "Ich modelliere euch in Blender ein Modell eines Autos", Models.Category.Modeling),
                new Article(3, "Ich bring dich zu Challenger", 200.0m, "League of Legends Boost-Service auf Challenger", Models.Category.Gaming),

            };
        }




    }



   
}