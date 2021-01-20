using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meine_Website.Models {
    public class Account {

        public int AccountID { get; set; }
        public String Vorname { get; set; }
        public String Nachname { get; set; }
        public String Nickname { get; set; }
        public String Email { get; set; }
        public String Passwort { get; set; }
        public DateTime? BirthDay { get; set; }
        public bool isModerator { get; set; }




        public Account() : this(0, "", "", "", "", "", null, false) { }

        public Account(int id, String vn, String nn, String nickn, String mail, String pw, DateTime? bday,bool isMod) {
            this.AccountID = id;
            this.Vorname = vn;
            this.Nachname = nn;
            this.Nickname = nickn;
            this.Email = mail;
            this.Passwort = pw;
            this.BirthDay = bday;
            this.isModerator = isMod;
        }

        public override string ToString() {
            return this.AccountID + " " + this.Vorname + " " + this.Nachname + " " + this.Nickname;        }


    }
}
