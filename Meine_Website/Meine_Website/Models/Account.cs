using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meine_Website.Models
{


    public enum Geschlecht
    {
        maennlich,weiblich,nichtAngegeben
    }
    public class Account
    {
        public string Email { get; set; }

        public string Vorname { get; set; }

        public string Nachname { get; set; }

        public string Username { get; set; }
        public string Passwort { get; set; }

        public string Passwort1 { get; set; }
        public Geschlecht Geschlecht { get; set; }


        public Account() : this("","","","","","",Geschlecht.nichtAngegeben) { }
        public Account(string email, string vorname, string nachname, string username, string passwort, string passwort1, Geschlecht geschlecht)
        {
            this.Email = email;
            this.Vorname = vorname;
            this.Nachname = nachname;
            this.Username = username;
            this.Passwort = passwort;
            this.Passwort1 = passwort1;
            this.Geschlecht = geschlecht;
        }

        public override string ToString()
        {
            return this.Username + " " + this.Vorname + " " + this.Nachname + " "+ this.Geschlecht;
        }

    }
}
