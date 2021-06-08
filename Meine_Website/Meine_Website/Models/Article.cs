using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meine_Website.Models
{
    public enum Genre
    {
        Music, Design, Gaming, Coding, Creativity, VoiceActing,Fitness,SomethingElse
    }


    public class Article
    {

        public int ArticleID{ get; set; }
        public string ArticleName { get; set; }
        public  decimal Price { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public string username { get; set; }


        public Article() : this(0, "", 0.0m, "",  Genre.SomethingElse,"") { }

        public Article(int id, String name, decimal price,string desc,Genre genre,string us)
        {
            this.ArticleID = id;
            this.ArticleName = name;
            this.Price = price;
            this.Description = desc;
            this.Genre = genre;
            this.username = us;
        }

        public override string ToString()
        {
            return this.ArticleID + " " + this.ArticleName + " " + this.Description + " " + this.Price + " " + this.Genre + " " +this.username;

            
        }



    }
}
