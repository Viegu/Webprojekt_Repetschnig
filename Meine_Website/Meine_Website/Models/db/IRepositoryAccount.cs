using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meine_Website.Models.db {
    interface IRepositoryAccount {



        void Open();
        void Close();

        Account GetAccountByUsername(string Username);

        List<Account> GetAllAccounts();

        bool Insert(Account account);
        bool Delete(int Account_ID);
        bool Update(int Account_ID,Account newAccountData );

    }
}
