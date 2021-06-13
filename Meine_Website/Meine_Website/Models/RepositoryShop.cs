using Microsoft.AspNetCore.Http;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Meine_Website.Models {
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
            if (this._conn.State == ConnectionState.Open)
            {
                List<Article> articles = new List<Article>();

                // leeres Command erzeugen
                DbCommand cmdSelect = this._conn.CreateCommand();
                cmdSelect.CommandText = "select * from articles where genre = " + genre;

                using (DbDataReader reader = cmdSelect.ExecuteReader())
                {

                    // Read() liest den nächsten Record ein
                    while (reader.Read())
                    {
                        articles.Add(new Article
                        {
                            ArticleID = Convert.ToInt32(reader["article_id"]),
                            ArticleName = Convert.ToString(reader["name"]),
                            Price = Convert.ToDecimal(reader["price"]),
                            Description = Convert.ToString(reader["description"]),
                            Genre = (Genre)Convert.ToInt32(reader["genre"]),
                            username = Convert.ToString(reader["username"]),
                        });

                    }
                  
                }
                if (articles.Count == 0)
                {
                    return null;
                }
                return articles;

            }


            throw new Exception("Datenbankfehler: Verbindung konnte nicht aufgebaut werden ");
        }

        public Article GetarticleByID(int articleId)
        {
            if (this._conn.State == ConnectionState.Open)
            {
                Article article = null;

                // leeres Command erzeugen
                DbCommand cmdSelect = this._conn.CreateCommand();
                cmdSelect.CommandText = "select * from articles where article_id = " + articleId;

                using (DbDataReader reader = cmdSelect.ExecuteReader())
                {

                    // Read() liest den nächsten Record ein
                    if (reader.Read())
                    {
                        article = new Article();

                        article.ArticleID = Convert.ToInt32(reader["article_id"]);
                        article.ArticleName = Convert.ToString(reader["name"]);
                        article.Price = Convert.ToDecimal(reader["price"]);
                        article.Description = Convert.ToString(reader["description"]);
                        article.Genre = (Genre)Convert.ToInt32(reader["genre"]);
                        article.username = Convert.ToString(reader["username"]);
                    }
                }   

                return article;
            }

            
            throw new Exception("Datenbankfehler: Verbindung konnte nicht aufgebaut werden ");
        }


        public List<Article> GetArticles()
        {

            if (this._conn.State == ConnectionState.Open)
            {
                List<Article> articles = new List<Article>();

                // leeres Command erzeugen
                DbCommand cmdSelect = this._conn.CreateCommand();
                cmdSelect.CommandText = "select * from articles order by article_id";

                using (DbDataReader reader = cmdSelect.ExecuteReader())
                {

                    // Read() liest den nächsten Record ein
                    while (reader.Read())
                    {

                        articles.Add(new Article
                        {
                            // article_id innerhalb der []-Klammern entspricht dem
                            //      Feldname article_id in der DB-Tabelle
                            ArticleID = Convert.ToInt32(reader["article_id"]),
                            ArticleName = Convert.ToString(reader["name"]),
                            Price = Convert.ToDecimal(reader["price"]),
                            Description = Convert.ToString(reader["description"]),
                            Genre = (Genre)Convert.ToInt32(reader["genre"]),
                            username = Convert.ToString(reader["username"]),
                        });

                    }

                }   // an dieser Stelle wird der reader wieder automatisch geschlossen

             
                
                if (articles.Count == 0) {
                    return null;
                }
                return articles;
                
            }

            //return null;
            throw new Exception("Datenbank: Verbindung ist nicht geöffnet!");
        }

        public bool Insert(Article art)
        {
            if(art == null) {
                return false;
            }
            if (this._conn.State != ConnectionState.Open) {
                return false;
            }

            DbCommand cmd = this._conn.CreateCommand();
            cmd.CommandText = "insert into articles values(null, @name, @price, @description, @genre, @username);";

            DbParameter paramArticlename = cmd.CreateParameter();
            paramArticlename.ParameterName = "name";
            paramArticlename.DbType = DbType.String;
            paramArticlename.Value = art.ArticleName;

            DbParameter paramPrice = cmd.CreateParameter();
            paramPrice.ParameterName = "price";
            paramPrice.DbType = DbType.Decimal;
            paramPrice.Value = art.Price;

            DbParameter paramDesc = cmd.CreateParameter();
            paramDesc.ParameterName = "description";
            paramDesc.DbType = DbType.String;
            paramDesc.Value = art.Description;

            DbParameter paramGenre = cmd.CreateParameter();
            paramGenre.ParameterName = "genre";
            paramGenre.DbType = DbType.Int32;
            paramGenre.Value = art.Genre;
           
            DbParameter paramUsername = cmd.CreateParameter();
            paramUsername.ParameterName = "username";
            paramUsername.DbType = DbType.String;
            paramUsername.Value = "admin";
            


            cmd.Parameters.Add(paramArticlename);
            cmd.Parameters.Add(paramPrice);
            cmd.Parameters.Add(paramDesc);
            cmd.Parameters.Add(paramGenre);
            cmd.Parameters.Add(paramUsername);


            return cmd.ExecuteNonQuery() == 1;

        }

        public bool Delete(int ArticleID)
        {
            if(this._conn.State == ConnectionState.Open) {
                DbCommand cmdDelete = this._conn.CreateCommand();
                cmdDelete.CommandText = "delete from articles where article_id = "+ArticleID;
                return cmdDelete.ExecuteNonQuery() == 1;
            
            }
            throw new Exception("Datenbankfehler (Delete Methode)");
        }
        //delete-> Benutzer kann eigene Uploads löschen
        //Suchen nach Artikeln mittels Ajax (Nach Genres)

    }
}
