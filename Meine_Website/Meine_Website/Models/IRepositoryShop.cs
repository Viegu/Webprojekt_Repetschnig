using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meine_Website.Models
{
    interface IRepositoryShop {

        void Open();
        void Close();

        Article GetarticleByID(int articleID);

        List<Article> GetArticles();
        bool Insert(Article art, string username);

        List<Article> getAllArticlesFromGenre(Genre genre);
        bool Delete(int articleID);
        List<Article> getAllArticlesFromUser(string username);




    }
}
