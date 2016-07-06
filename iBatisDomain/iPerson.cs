using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iBatisDomain
{
    public class iPerson
    {
        public string UserID { set; get; }

        public string UserName { set; get; }

        public string Password {set; get;}

        public DateTime Birthday {set; get;}

        public int Gender {set; get;}

        public string Email {set; get;}

        public string Phone {set; get;}
    }
}
