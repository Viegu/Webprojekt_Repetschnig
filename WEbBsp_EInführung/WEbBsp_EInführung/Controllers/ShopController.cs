using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WEbBsp_EInführung.Models;

namespace WEbBsp_EInführung.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {

            //normalerweise würden alle Artikel aus einer DB-Tabelle geladen
            List<Article> articles = CreateArticleList();
            return View(articles);
        }



        private List<Article> CreateArticleList()
        {
            return new List<Article>()
            {
                new Article(1,"IPhone 11 pro", "Apple",new DateTime(2020,3,18),999.90m,"Handy"),
                 new Article(1,"Samsung Galaxy S10 plus", "Samsung",new DateTime(2020,3,12),899.90m,"Handy"),
                  new Article(1,"Acer Aspire", "Acer",new DateTime(2017,9,26),999.90m,"Laptop"),
                   new Article(1,"Razer Naga Trinity", "Razer",new DateTime(2019,5,20),99.90m,"Elektronik"),
            };
        }
        public IActionResult Refund()
        {

           
            return View();
        }

    }
}
