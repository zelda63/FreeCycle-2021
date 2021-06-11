using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FreeCycle2.DataAccessObjects;
using FreeCycle2.Models;
using System.Data.SqlClient;

namespace FreeCycle2.Controllers
{
    public class SearchController : Controller
    {

        public ActionResult Search(string search)
        {
            if (search == "")
            {
                ViewBag.a = "Please enter a search item..";
            }
            List<Item> items = new List<Item>();
            using (SqlConnection conn = new SqlConnection("Server=.; Database=FreeCycleDatabase; Integrated Security=true"))
            {
                conn.Open();
                string sql = @"SELECT items.item_id,items.create_date,items.item_title,items.is_active, items.item_detail, images.image
                                from items 
                                inner join images on items.item_id = images.item_id where items.item_title like '%" + search + "%' or items.item_detail like '%" + search + "%' ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Item p = new Item()
                    {

                        item_id = (int)reader["item_id"],
                        create_date = (DateTime)reader["create_date"],
                        item_title = (string)reader["item_title"],
                        is_active = (char)reader["is_active"].ToString()[0],
                        item_detail = (string)reader["item_detail"],
                        image = (byte[])reader["image"]

                    };
                    if (p.is_active == '1')
                    {
                        items.Add(p);
                    }
                    else
                    {

                    }
                }
            }


            ViewData["searchlist"] = items;


            ViewBag.a = 2;

            return View("../Home/Item");
        }
    }
}