using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meine_Website.Models {
    public class Account {

        public int AccountID { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Passwort { get; set; }
        public DateTime? Geburtsdatum { get; set; }
        public bool istModerator { get; set; }




        public Account() : this(0, "", "", "", "", "", null, false) { }

        public Account(int id, string vn, string nn, string un, string mail, string pw, DateTime? bday,bool isMod) {
            this.AccountID = id;
            this.Vorname = vn;
            this.Nachname = nn;
            this.Username = un;
            this.Email = mail;
            this.Passwort = pw;
            this.Geburtsdatum = bday;
            this.istModerator = isMod;
        }

        public override string ToString() {
            return this.AccountID + " " + this.Vorname + " " + this.Nachname + " " + this.Username;     
        }


    }
}
