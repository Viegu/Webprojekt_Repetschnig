using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meine_Website.Models {
    public class Message {


        public string Header { get; set; }
        public string Messagetext { get; set; }
        public string Solution { get; set; }


        public Message() : this("", "", "") { }


        public Message(string header, string messagetext, string solution = "") {
            this.Header = header;
            this.Messagetext = messagetext;
            this.Solution = solution;
        }

            public override string ToString() {
            return this.Header + " \n" + this.Messagetext + " " + this.Solution;
        }
    }

    }

