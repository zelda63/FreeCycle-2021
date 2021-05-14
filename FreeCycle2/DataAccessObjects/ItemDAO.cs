using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using FreeCycle2.Models;
using System.Diagnostics;

namespace FreeCycle2.DataAccessObjects
{
    public class ItemDAO
    {
        public static List<Item> AllItems()
        {
            List<Item> items = new List<Item>();
            using (SqlConnection conn = new SqlConnection(("Server=.; Database=FreeCycleDatabase; Integrated Security=true")))
            {
                conn.Open();
                string sql = @"
                                SELECT items.item_id,items.create_date,items.item_title,items.item_detail, images.image
                                from items 
                                inner join images on items.item_id = images.item_id;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Item i = new Item()
                    {
                        item_id = (int)reader["item_id"],
                        create_date = (DateTime)reader["create_date"],
                        item_title = (string)reader["item_title"],
                        item_detail = (string)reader["item_detail"],
                        image = (byte[])reader["image"]
                    };
                    items.Add(i);
                   
                }
            }
            return items;
        }

        public static List<Item> ItemsByCategory(int id)
        {
            List<Item> items2 = new List<Item>();
            using (SqlConnection conn = new SqlConnection(("Server=.; Database=FreeCycleDatabase; Integrated Security=true")))
            {
                conn.Open();
                string sql = @"SELECT items.item_id,items.create_date,items.item_title,items.item_detail, images.image
                                from items 
                                    inner join images on items.item_id = images.item_id where category_id ='" + id + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
        
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Item i = new Item()
                    {
                        item_id = (int)reader["item_id"],
                        create_date = (DateTime)reader["create_date"],
                        item_title = (string)reader["item_title"],
                        item_detail = (string)reader["item_detail"],
                        image = (byte[])reader["image"]
                    };
                    items2.Add(i);

                }
            }
            return items2;
        }


        public static List<Item> ItemsByID(int id)
        {
            List<Item> items2 = new List<Item>();
            using (SqlConnection conn = new SqlConnection(("Server=.; Database=FreeCycleDatabase; Integrated Security=true")))
            {
                conn.Open();
                string sql = @"SELECT items.item_id,items.create_date,items.item_title,items.item_detail, images.image
                            from items 
                            inner join images on items.item_id = images.item_id where items.item_id ='" + id + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Item i = new Item()
                    {
                        item_id = (int)reader["item_id"],
                        create_date = (DateTime)reader["create_date"],
                        item_title = (string)reader["item_title"],
                        item_detail = (string)reader["item_detail"],
                        image = (byte[])reader["image"]
                    };
                    items2.Add(i);

                }
            }
            return items2;
        }

        public void Post( int user_id, int category_id,string item_title, string item_detail, byte[] image)
        {

            SqlConnection con = new SqlConnection(("Server=.; Database=FreeCycleDatabase; Integrated Security=true"));
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO items( user_id, category_id, item_title, item_detail, image) VALUES ( @user_id, @category_id, @item_title, @item_detail, @image)";

            cmd.Parameters.AddWithValue("@user_id", user_id);
            cmd.Parameters.AddWithValue("@category_id", category_id);
            cmd.Parameters.AddWithValue("@item_title", item_title);
            cmd.Parameters.AddWithValue("@item_detail", item_detail);
            cmd.Parameters.AddWithValue("@image", image);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();




        } 
    }
}