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
            throw new NotImplementedException();
        }

        public bool Insert(Account account) {
            throw new NotImplementedException();
        }

        public void Open() {
            if (this._conn == null) {
                this._conn = new MySqlConnection(this._connectionString);
            }
            if (this._conn.State != ConnectionState.Open) {
                this._conn.Open();
            }
        }

        public bool Update(int Account_ID, Account newAccountData) {
            throw new NotImplementedException();
        }
    }
}
