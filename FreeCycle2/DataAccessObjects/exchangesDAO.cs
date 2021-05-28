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
                string sql = @"SELECT exchange_id, item_id ,receiver_id,date_txn from exchanges;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    exchanges i = new exchanges()
                    {
                        exchange_id = (int)reader["exchange_id"],
                        item_id = (int)reader["item_id"],
                        receiver_id = (int)reader["receiver_id"],
                        date_txn = (DateTime)reader["date_txn"]
                    };
                    exchanges.Add(i);

                }
                exchanges a = new exchanges();
                a.allexchanges = exchanges;
                return a;
            }
         
        }

    }
}