using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using FreeCycle2.Models;
using System.Diagnostics;
using System.Web.Mvc;

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



        public int GetID()
        {
            int items = 0;
            using (SqlConnection conn = new SqlConnection(("Server=.; Database=FreeCycleDatabase; Integrated Security=true")))
            {
                conn.Open();
                string sql = @"Select IDENT_CURRENT('items')";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    items = int.Parse(reader[0].ToString());

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

        public void updateMovie(Item movie)
        {
            //This method accepts updates with, or without, a description
            SqlConnection con = new SqlConnection(("Server=.; Database=FreeCycleDatabase; Integrated Security=true"));
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            if (movie.image != null)
            {
                cmd.CommandText = @" UPDATE images SET image=@image where item_id=@item_id; UPDATE items SET item_title=@item_title,item_detail=@item_detail where item_id=@item_id;";
                cmd.Parameters.AddWithValue("@item_title", movie.item_title);
                cmd.Parameters.AddWithValue("@item_detail", movie.item_detail);
                cmd.Parameters.AddWithValue("@item_id", movie.item_id);
                cmd.Parameters.AddWithValue("@image", movie.image);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            else {
                cmd.CommandText = @"UPDATE items SET item_title=@item_title,item_detail=@item_detail where item_id=@item_id;";
                cmd.Parameters.AddWithValue("@item_title", movie.item_title);
                cmd.Parameters.AddWithValue("@item_detail", movie.item_detail);
                cmd.Parameters.AddWithValue("@item_id", movie.item_id);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public void deleteMovie(int id)
        {
            SqlConnection con = new SqlConnection(("Server=.; Database=FreeCycleDatabase; Integrated Security=true"));
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"Delete from images where item_id=@item_id; Delete from items where item_id=@item_id";
            cmd.Parameters.AddWithValue("@item_id", id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public int setMovieToEditMode(List<Item> movies, int id)
        {
            int editIndex = 0;
            foreach (Item m in movies)
            {
                if (m.item_id == id)
                {
                    m.IsEditable2 = true;
                    return editIndex;
                }
                editIndex++;
            }
            return -1;
        }

        public Item ItemsByUser(int id)
        {
            List<Item> items3 = new List<Item>();
            using (SqlConnection conn = new SqlConnection(("Server=.; Database=FreeCycleDatabase; Integrated Security=true")))
            {
                conn.Open();
                string sql = @"SELECT items.item_id,items.create_date,items.item_title,items.item_detail, images.image
                            from items 
                            inner join images on items.item_id = images.item_id where items.user_id ='" + id + "'";
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
                    items3.Add(i);

                }
                Item allItems = new Item();
                allItems.allItems = items3;
                return allItems;
            }

        }

        public Item ItemsForAdmin()
        {
            List<Item> items3 = new List<Item>();
            using (SqlConnection conn = new SqlConnection(("Server=.; Database=FreeCycleDatabase; Integrated Security=true")))
            {
                conn.Open();
                string sql = @"SELECT items.item_id,items.create_date,items.item_title,items.item_detail, images.image
                            from items 
                            inner join images on items.item_id = images.item_id";
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
                    items3.Add(i);

                }
                Item allItems = new Item();
                allItems.allItems = items3;
                return allItems;
            }

        }

        public static List<Item> ItemsByID(int id)
        {
            List<Item> items2 = new List<Item>();
            using (SqlConnection conn = new SqlConnection(("Server=.; Database=FreeCycleDatabase; Integrated Security=true")))
            {
                conn.Open();
                string sql = @"SELECT items.item_id,items.create_date,items.item_title,items.item_detail, images.image, user_account.first_name,user_account.last_name, user_account.email
                            from items 
                            inner join images on items.item_id = images.item_id inner join user_account on items.user_id = user_account.user_id where items.item_id ='" + id + "'";
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
                        image = (byte[])reader["image"],
                        first_name = (string)reader["first_name"],
                        last_name = (string)reader["last_name"],
                        email = (string)reader["email"]
                    };
                    items2.Add(i);

                }
            }
            return items2;
        }

        public void Post(int user_id, int category_id, char is_active, DateTime create_date, DateTime last_renewed_on, string item_title, string item_detail, byte[] image)
        {

            SqlConnection con = new SqlConnection(("Server=.; Database=FreeCycleDatabase; Integrated Security=true"));
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO items( user_id, category_id, is_active,create_date,last_renewed_on, item_title, item_detail) VALUES ( @user_id, @category_id, @is_active,@create_date,@last_renewed_on, @item_title, @item_detail)";

            cmd.Parameters.AddWithValue("@user_id", user_id);
            cmd.Parameters.AddWithValue("@category_id", category_id);
            cmd.Parameters.AddWithValue("@item_title", item_title);
            cmd.Parameters.AddWithValue("@item_detail", item_detail);
            cmd.Parameters.AddWithValue("@is_active", is_active);
            cmd.Parameters.AddWithValue("@create_date", create_date);
            cmd.Parameters.AddWithValue("@last_renewed_on", last_renewed_on);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


            int sd = GetID();

            SqlConnection con2 = new SqlConnection(("Server=.; Database=FreeCycleDatabase; Integrated Security=true"));
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con2;
            cmd2.CommandText = "INSERT INTO images( item_id, image) VALUES ( @item_id, @image)";
            cmd2.Parameters.AddWithValue("@image", image);
            cmd2.Parameters.AddWithValue("@item_id", sd);
            con2.Open();
            cmd2.ExecuteNonQuery();
            con2.Close();
        }
    }
}