using FreeCycle2.DataAccessObjects;
using FreeCycle2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreeCycle2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Item(int? categoryID)
        {


            if (categoryID == null)
            {
                List<Category> categorylist = CategoryDAO.FCategory();
                ViewData["categorylist"] = categorylist;
                List<Item> itemlist = ItemDAO.AllItems();
                ViewData["itemlist"] = itemlist;
                ViewBag.a = 1;
                return View("Item");
            }
            else {
                int id2 = categoryID ?? default(int);
                List<Item> itemlist2 = ItemDAO.ItemsByCategory(id2);
                ViewData["itemlist2"] = itemlist2;
                ViewBag.a = 3;
                return View("Item");

            }

        }



     
        public ActionResult Post(int? user_id, int? category_id, string item_title, string item_detail, HttpPostedFileBase file, string Save)
        {
            ViewBag.Message = "Add a Movie Page.";
            int id22 = user_id ?? default(int);
            int id23 = category_id ?? default(int);

            
            if (Save == "Save")
            {
                ItemDAO dAO = new ItemDAO();
                if (file != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        file.InputStream.CopyTo(ms);
                        byte[] array = ms.ToArray();

                        dAO.Post(id22, id23, item_title, item_detail, array);


                    }
                    
                }
               
               
                ViewBag.Message = "Movie Added Successfully.";
            }
            return View("Post");
        }




        public ActionResult AllItems(ViewModel1 f, string Save, string Delete)
        {
            ViewBag.Message = "All Items.";
            CategoryDAO Cdao = new CategoryDAO();

            f.Images = Cdao.getImages();

            f.ItemsModel = Cdao.getAllItems();
            return View(f);
        }

        public ActionResult HomePage(ViewModel1 f, string Save, string Delete)
        {
            var models = new ViewModel1();
            CategoryDAO Cdao = new CategoryDAO();
            f.Images = Cdao.getImages();
            f.ItemsModel = Cdao.getAllItems();
            f.Categs = Cdao.getAllCategories();
            return View(f);
        }

    }
}