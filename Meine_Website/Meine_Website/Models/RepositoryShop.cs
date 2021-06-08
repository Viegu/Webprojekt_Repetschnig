using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Meine_Website.Models
{
    public class RepositoryShop : IRepositoryShop
    {
        private String _connectionString = "server=localhost;database=db_shop;uid=root;pwd=ABC13Y@12Bz";
        private MySqlConnection _conn = null;

        public void Open()
        {
            if (this._conn == null)
            {
                
                this._conn = new MySqlConnection(this._connectionString);
            }
            
            if (this._conn.State != ConnectionState.Open)
            {
                this._conn.Open();
            }
        }
        public void Close()
        {
            if ((this._conn != null) && (this._conn.State == ConnectionState.Open))
            {
                this._conn.Close();
            }
        }

        public List<Article> getAllArticlesFromGenre(Genre genre)
        {
            throw new NotImplementedException();
        }

        public Article GetarticleByID(int articleID)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetArticles()
        {
            throw new NotImplementedException();
        }

        public bool Insert(Article art)
        {
            throw new NotImplementedException();
        }
        //delete-> Benutzer kann eigene Uploads löschen
        //Suchen nach Artikeln mittels Ajax (Nach Genres)
       
    }
}
