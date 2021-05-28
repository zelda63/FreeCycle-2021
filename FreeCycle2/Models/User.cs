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


        public string login_pwd_encry { get; set; }

        public string first_name { get; set; }
        public string last_name { get; set; }

        public int group_id { get; set; }
    }
}