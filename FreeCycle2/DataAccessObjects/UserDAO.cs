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

            using (SqlConnection conn = new SqlConnection(("Server=.; Database=FreeCycleDB2; Integrated Security=true")))
            {
                conn.Open();
                string sql = @"SELECT user_id, email, group_id, login_pwd_encry, first_name, last_name from user_account WHERE email = '" + email + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user = new User()
                    {
                        user_id = (int)reader["user_id"],
                        email = (string)reader["email"],
                        group_id = (int)reader["group_id"],
                        login_pwd_encry = (string)reader["login_pwd_encry"],
                        first_name = (string)reader["first_name"],
                        last_name = (string)reader["last_name"]
                    };
                }
            }
            return user;
        }



    }
}
