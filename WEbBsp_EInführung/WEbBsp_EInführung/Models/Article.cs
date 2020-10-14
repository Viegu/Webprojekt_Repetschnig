using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEbBsp_EInführung.Models
{
    public class Article
    {
        public int ID { get; set; }
        public string ArticleName { get; set; }
        public string Brand { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public string category { get; set; }

        public Article() : this(0,"","",DateTime.MinValue,0.0m,"") { }

        public Article(int id, string articleName, string brand, DateTime releasedate,decimal price, string category)
        {
            this.ID = id;
            this.ArticleName = articleName;
            this.Brand = brand;
            this.ReleaseDate = releasedate;
            this.Price = price;
            this.category = category;
        }

        public override string ToString()
        {
            return this.ID + " " + this.ArticleName + " " + this.Brand + " " + this.ReleaseDate + " " + this.Price + "Euro " + this.category;
        }
    }
}
