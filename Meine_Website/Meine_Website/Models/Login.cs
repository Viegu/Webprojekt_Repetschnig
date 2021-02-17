using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meine_Website.Models {
    public class Login {

        public string Username { get; set; }

        public string Passwort { get; set; }

        public Login() : this("", "") { }

        public Login(string un,string pw) {
          
            this.Username = un;
       
            this.Passwort = pw;
           
        }

        public override string ToString() {
            return this.Username + " " + this.Passwort;
        }



    }






}
