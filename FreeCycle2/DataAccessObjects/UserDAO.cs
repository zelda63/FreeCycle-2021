using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using FreeCycle2.Models;

namespace FreeCycle2.Controllers
{
    public class UserDAO
    {
        public static User UserByEmail(string email)

        {
            User user = null;
            
            using (SqlConnection conn = new SqlConnection(("Server=.; Database=FreeCycleDatabase; Integrated Security=true")))
            {
                conn.Open();
                string sql = @"SELECT user_id, email, password, firstname, lastname from [User] WHERE email = '" + email + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user = new User()
                    {
                        user_id = (int)reader["user_id"],
                        email = (string)reader["email"],
                        password = (string)reader["password"],
                        firstname = (string)reader["firstname"],
                        lastname = (string)reader["lastname"]
                    };
                }
            }
            return user;
        }
    }
}
