using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace FreeCycle2.Models
{
    public class User
    {
        public int user_id { get; set; }


        public string email { get; set; }

   
        public string password { get; set; }

        public string firstname { get; set; }
        public string lastname { get; set; }
    }
}