using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meine_Website.Models {
    public class MySession {
     public 
IHttpContextAccessor accessor;

        public MySession(IHttpContextAccessor accessor) {
            this.accessor = accessor;
        }
    }
}
