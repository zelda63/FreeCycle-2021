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
            using (SqlConnection conn = new SqlConnection("Server=.; Database=FreeCycleDB2; Integrated Security=true"))
            {
                conn.Open();
                string sql = @"select * from items where item_title like '%" + search + "%'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Item p = new Item()
                    {

                        item_id = (int)reader["item_id"],
                        create_date = (DateTime)reader["create_date"],
                        item_title = (string)reader["item_title"],
                        item_detail = (string)reader["item_detail"],
                        image = (byte[])reader["image"]

                    };
                    items.Add(p);
                }
            }
           
            
                ViewData["searchlist"] = items;
         
                
            ViewBag.a = 2;
            
            return View("../Home/Item");
        }
    }
}