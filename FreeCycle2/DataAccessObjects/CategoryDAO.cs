using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FreeCycle2.Models;
using System.Data.SqlClient;
using System.Diagnostics;

namespace FreeCycle2.DataAccessObjects
{
    public class CategoryDAO
    {

        string conString =
          "Data Source=localhost;Initial Catalog=FreeCycleDatabase;Integrated Security=True";

        public static List<Category> FCategory()
        {
            List<Category> categories = new List<Category>();
            using (SqlConnection conn = new SqlConnection(("Server=.; Database=FreeCycleDatabase; Integrated Security=true")))
            {
                conn.Open();
                string sql = @"SELECT * from Category";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Category p = new Category()
                    {
                        Category_Id = (int)reader["category_id"],
                        Category_name = (string)reader["category_name"]

                    };
                    categories.Add(p);
                }
            }
            return categories;
        }




        public Categs getAllCategories()
        {
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT category_id, category_name, max_images_allowed, post_validity_interval_in_days from category;";
            List<Category> ms = new List<Category>();
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Category m = new Category(
                Convert.ToInt32(reader["category_id"]),
                reader["category_name"].ToString(),
               Convert.ToInt32(reader["max_images_allowed"]),
               Convert.ToInt32(reader["post_validity_interval_in_days"])
                );
                ms.Add(m);
            }

            Categs allCategories = new Categs(); // create an instance of the class assign the collection and return it
            allCategories.Items = ms;
            return allCategories;
        }

        public ItemsModel getAllItems()
        {
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT [item_id],[user_id],[category_id],[item_title],[item_detail],[is_active] FROM [FreeCycleDatabase].[dbo].[items]";
            List<Item1> itemlist = new List<Item1>();
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Item1 item = new Item1(
                Convert.ToInt32(reader["item_id"]),
                Convert.ToInt32(reader["user_id"]),
                Convert.ToInt32(reader["category_id"]),
                reader["item_title"].ToString(),
                reader["item_detail"].ToString(),
                Convert.ToChar(reader["is_active"])
                );
                itemlist.Add(item);
            }

            ItemsModel allItems = new ItemsModel(); // create an instance of the class assign the collection and return it
            allItems.Items = itemlist;
            return allItems;
        }

        public Images getImages()
        {
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT image_id, item_id, image FROM [FreeCycleDatabase].[dbo].[images];";
            List<Image> image_list = new List<Image>();
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Image image = new Image(
                Convert.ToInt32(reader["image_id"]),
                Convert.ToInt32(reader["item_id"]),
                (byte[])(reader["image"])
                );
                image_list.Add(image);
            }

            Images Images_all = new Images(); // create an instance of the class assign the collection and return it
            Images_all.Items = image_list;
            return Images_all;

        }

    }
}