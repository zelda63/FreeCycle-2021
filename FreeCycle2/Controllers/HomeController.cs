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

        public ActionResult AdminPage() {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult exchanges(exchanges movies)
        {

            movies = exchangesDAO.AllExchanges();
            return View("exchanges", movies);


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

        public ActionResult AddMovie(Category movie, string Save)
        {
            ViewBag.Message = "Add a Category Page.";

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

        public ActionResult MoviesDelete(int? id, Item movies)
        {
            int id2 = id ?? default(int);
            var value = Request.Cookies["user_id"].Value;
            int.TryParse(value, out int result);
            ItemDAO dAO = new ItemDAO();
            dAO.deleteMovie(id2);
            movies = dAO.ItemsByUser(result);
            ViewBag.Message = "All Movies.";
            return View("AllMovies", movies);
        }

        public ActionResult Post(int? user_id, int? category_id, char? is_active, DateTime? create_date, DateTime? last_renewed_on, string item_title, string item_detail, HttpPostedFileBase file, string Save)
        {

            ViewBag.Message = "Add an Item Page.";
            int id22 = user_id ?? default(int);
            int id23 = category_id ?? default(int);
            char id24 = is_active ?? default(char);
            DateTime id25 = create_date ?? default(DateTime);
            DateTime id26 = last_renewed_on ?? default(DateTime);

            if (Save == "Save")
            {
                ItemDAO dAO = new ItemDAO();
                if (file != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        file.InputStream.CopyTo(ms);
                        byte[] array = ms.ToArray();

                        dAO.Post(id22, id23, id24, id25, id26, item_title, item_detail, array);


                    }

                }


                ViewBag.Message = "Item posted Successfully.";
            }
            return View("Post");
        }

    }
}