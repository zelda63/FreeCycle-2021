using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using FreeCycle2.Models;

namespace FreeCycle2.DataAccessObjects
{
    public class exchangesDAO
    {
        public static exchanges AllExchanges()
        {
            List<exchanges> exchanges = new List<exchanges>();
            using (SqlConnection conn = new SqlConnection(("Server=.; Database=FreeCycleDatabase; Integrated Security=true")))
            {
                conn.Open();
                string sql = @"SELECT exchanges.exchange_id, exchanges.item_id, items.item_title, exchanges.receiver_id,user_account.email, exchanges.date_txn
from exchanges
 inner join 
 items on exchanges.item_id = items.item_id inner join user_account on exchanges.receiver_id = user_account.user_id;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    exchanges i = new exchanges()
                    {
                        exchange_id = (int)reader["exchange_id"],
                        item_id = (int)reader["item_id"],
                        item_title = (string)reader["item_title"],
                        receiver_id = (int)reader["receiver_id"],
                        email = (string)reader["email"],
                        date_txn = (DateTime)reader["date_txn"]
                    };
                    exchanges.Add(i);

                }
                exchanges a = new exchanges();
                a.allexchanges = exchanges;
                return a;
            }

        }


        public void updateExchange(string email, Item movie)
        {
            SqlConnection con = new SqlConnection(("Server=.; Database=FreeCycleDatabase; Integrated Security=true"));
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            if (email != null)
            {
                cmd.CommandText = "INSERT INTO exchanges( item_id, receiver_id, date_txn) SELECT  @item_id, user_account.user_id, @date_txn FROM user_account WHERE user_account.email ='" + email + "'";

            }
            cmd.Parameters.AddWithValue("@item_id", movie.item_id);

            cmd.Parameters.AddWithValue("@date_txn", DateTime.Now.ToString("yyyy-MM-dd"));
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }
}