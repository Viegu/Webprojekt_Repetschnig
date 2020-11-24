using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meine_Website.Models
{
    public enum Category
    {
        Design, Modeling, Lessons, Gaming, notSpecified
    }


    public class Article
    {
        public int ArticleId { get; set; }
        public string Articlename { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }




        public Article() : this(0, "", 0.0m, "", Category.notSpecified) { }
        public Article(int id, string articlename, decimal price,
            string description, Category category)
        {
            this.ArticleId = id;
            this.Articlename = articlename;
            this.Price = price;
            this.Description = description;
            this.Category = category;
        }

        public override string ToString()
        {
            return this.ArticleId + " " + this.Articlename + " " + this.Price + " Euro";
        }
    }

   
}
