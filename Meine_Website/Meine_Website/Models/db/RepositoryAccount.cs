using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Meine_Website.Models.db {
    public class RepositoryAccount : IRepositoryAccount {


        private string _connectionString = "server=localhost;database=db_accounts;user=root;pwd=ABC13Y@12Bz";

        private MySqlConnection _conn= null;
        public void Close() {
            if ((this._conn != null) && (this._conn.State == ConnectionState.Open)) {
                this._conn.Close();
            }
        }

        public bool Delete(int Account_ID) {
            if (this._conn.State == ConnectionState.Open) {
                DbCommand cmdDelete = this._conn.CreateCommand();
                cmdDelete.CommandText = "delete from accoutns where account_id = " + Account_ID;

                return cmdDelete.ExecuteNonQuery() == 1;
            }
            throw new Exception("Verbindung zur DB ist nicht geöffnet!");
        }

        public Account GetAccountByUsername(string Username) {
            throw new NotImplementedException();
        }

        public List<Account> GetAllAccounts() {
            if (this._conn.State == ConnectionState.Open) {
                List<Account> accounts = new List<Account>();

                // leeres Command erzeugen
                DbCommand cmdSelect = this._conn.CreateCommand();

                cmdSelect.CommandText = "select * from accounts order by account_id";

                using (DbDataReader reader = cmdSelect.ExecuteReader()) {
                    while (reader.Read()) {
                        accounts.Add(new Account {
                           
                            AccountID = Convert.ToInt32(reader["account_id"]),
                            Vorname = Convert.ToString(reader["vorname"]),
                            Nachname = Convert.ToString(reader["nachname"]),
                            Username = Convert.ToString(reader["username"]),
                            Email = Convert.ToString(reader["email"]),
                            Passwort = Convert.ToString(reader["passwort"]),
                            Geburtsdatum = reader["geburtsdatum"] == DBNull.Value ? Convert.ToDateTime(null) : Convert.ToDateTime(reader["geburtsdatum"]),
                            istModerator = Convert.ToBoolean(reader["istModerator"])

                        });
                    }

                }  

                if (accounts.Count == 0) {
                    return null;
                }

                return accounts;
            }
            
            throw new Exception("Datebank: Verbindung ist nicht geöffnet!");
        }

        public bool Insert(Account account) {
            if (account == null) {
                return false;
            }
            if (this._conn.State != ConnectionState.Open) {
                return false;
            }

           
            DbCommand cmdInsert = this._conn.CreateCommand();

          

            cmdInsert.CommandText = "insert into accounts values(null, @vorname, @nachname, @username, @email, @passwort, @geburtsdatum, @istModerator);";

           
            DbParameter paramVorname = cmdInsert.CreateParameter();
            paramVorname.ParameterName = "vorname";
            paramVorname.DbType = DbType.String;
            paramVorname.Value = account.Vorname;

            DbParameter paramNachname = cmdInsert.CreateParameter();
            paramNachname.ParameterName = "nachname";
            paramNachname.DbType = DbType.String;
            paramNachname.Value = account.Nachname;

            DbParameter paramUsername = cmdInsert.CreateParameter();
            paramUsername.ParameterName = "username";
            paramUsername.DbType = DbType.String;
            paramUsername.Value = account.Username;

            DbParameter paramEmail = cmdInsert.CreateParameter();
            paramEmail.ParameterName = "email";
            paramEmail.DbType = DbType.String;
            paramEmail.Value = account.Email;

            DbParameter paramPasswort = cmdInsert.CreateParameter();
            paramPasswort.ParameterName = "passwort";
            paramPasswort.DbType = DbType.String;
            paramPasswort.Value = account.Passwort;

            DbParameter paramGeburtsdatum = cmdInsert.CreateParameter();
            paramGeburtsdatum.ParameterName = "geburtsdatum";
            paramGeburtsdatum.DbType = DbType.DateTime;
            paramGeburtsdatum.Value = account.Geburtsdatum;

            DbParameter paramIstModerator = cmdInsert.CreateParameter();
            paramIstModerator.ParameterName = "istModerator";
            paramIstModerator.DbType = DbType.Boolean;
            paramIstModerator.Value = account.istModerator;


            // jetzt sind alle Parameter definiert und mit dem Parametername verknüpft

            // die Parameter müssen noch der Liste "Parameters" hinzugefügt werden
            cmdInsert.Parameters.Add(paramVorname);
            cmdInsert.Parameters.Add(paramNachname);
            cmdInsert.Parameters.Add(paramUsername);
            cmdInsert.Parameters.Add(paramEmail);
            cmdInsert.Parameters.Add(paramPasswort);
            cmdInsert.Parameters.Add(paramGeburtsdatum);
            cmdInsert.Parameters.Add(paramIstModerator);

            // nun muss der INSERT-Befehl an den DB-Server gesendet werden
            // ExecuteNonQuery() wird für insert, update, delete, ... verwendet
            // ExecuteReader() wird bei select verwendet
            return cmdInsert.ExecuteNonQuery() == 1;
            /*
            if (cmdInsert.ExecuteNonQuery() == 1)
            {
                return true;
            }  else
            {
                return false;
            }*/
        }

        public void Open() {
            if (this._conn == null) {
                this._conn = new MySqlConnection(this._connectionString);
            }
            if (this._conn.State != ConnectionState.Open) {
                this._conn.Open();
            }
        }

        public bool IsUsernameTaken(String imputUsername) {
            bool vergeben = false;

            if (this._conn.State == ConnectionState.Open) {
                

               
                DbCommand cmdSelect = this._conn.CreateCommand();

                cmdSelect.CommandText = "select username from accounts";
                List<String> usernames = new List<string>();
                using (DbDataReader reader = cmdSelect.ExecuteReader()) {
                    
                    while (reader.Read()) {


                        usernames.Add(Convert.ToString(reader["username"]));  
                    }


                }

                for(int i = 0; i < usernames.Count; i++) {
                    if (imputUsername.Equals(usernames[i])){
                        vergeben = true;
                    }
                       
                    
                    
                }
                
                if(vergeben == true) {
                    return true;
                } else {
                    return false;
                }
            }

            throw new Exception("Datebank: Verbindung ist nicht geöffnet!");
        }

        public bool IsEmailTaken(String imputEmail) {
            bool vergeben = false;

            if (this._conn.State == ConnectionState.Open) {
                

               
                DbCommand cmdSelect = this._conn.CreateCommand();

                cmdSelect.CommandText = "select email from accounts";
                List<String> emails = new List<string>();
                using (DbDataReader reader = cmdSelect.ExecuteReader()) {

                    while (reader.Read()) {


                        emails.Add(Convert.ToString(reader["email"]));
                    }


                }

                for (int i = 0; i < emails.Count; i++) {
                    if (imputEmail.Equals(emails[i])){
                        vergeben = true;
                    }



                }

                if (vergeben == true) {
                    return true;
                } else {
                    return false;
                }
            }

            throw new Exception("Datebank: Verbindung ist nicht geöffnet!");
        }

        public  bool IsLoginCorrect(String inputUsername, String inputPasswort) {
            bool usernamecorrect = false;
            bool pwcorrect = false;
          

            if (this._conn.State == ConnectionState.Open) {
                List<String> usernames = new List<String>();

               
                DbCommand cmdSelect = this._conn.CreateCommand();

                cmdSelect.CommandText = "select username,passwort from accounts";
                Dictionary<String, String> User = new Dictionary<string, string>();
                using (DbDataReader reader = cmdSelect.ExecuteReader()) {

                    while (reader.Read()) {


                        User.Add(Convert.ToString(reader["username"]), Convert.ToString(reader["passwort"]));
                        usernames.Add(Convert.ToString(reader["username"]));

                    }


                }
                for(int i =0; i<usernames.Count;i++) {
                    if (inputUsername.Equals(usernames[i])) {
                        if (inputPasswort.Equals(User[inputUsername])) ;
                    }
                }
                
            }

        }



    }
}
