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

        public ActionResult AdminPage()
        {
            return View();
        }

        public ActionResult Contact()
        {
           

            return View();
        }


        public ActionResult exchanges(exchanges items)
        {

            items = exchangesDAO.AllExchanges();
            return View("exchanges", items);


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
            else
            {
                List<Category> categorylist = CategoryDAO.FCategory();
                ViewData["categorylist"] = categorylist;
                int id2 = categoryID ?? default(int);
                List<Item> itemlist2 = ItemDAO.ItemsByCategory(id2);
                ViewData["itemlist2"] = itemlist2;
                ViewBag.a = 3;

                ViewBag.category_name = ItemDAO.GetCategory_Name(id2);
                return View("Item");

            }

        }

        public ActionResult AllItemsDelete(ViewModel1 f, string Save, string Delete)
        {
      
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

        public ActionResult AddCategory(Category item, string Save)
        {
          

            if (Save == "Save")
            {
                CategoryDAO dAO = new CategoryDAO();
                dAO.InsertCategory(item);
                ViewBag.Message = "Category Added Successfully.";
            }
            return View("AddCategory");
        }

        public ActionResult AllItems(Item items, HttpPostedFileBase file, bool? IsActive, string email, string Save)
        {
           
            ItemDAO dAO = new ItemDAO();
            exchangesDAO edAO = new exchangesDAO();
            bool id2 = IsActive ?? default(bool);



            if (Save == "Save")
            {
                if (file != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        file.InputStream.CopyTo(ms);
                        byte[] array = ms.ToArray();
                        Item item = items.allItems[items.EditIndex2];
                        item.image = array;
                        if (id2 == true)
                        {
                            item.is_active = '1';

                        }
                        else
                        {
                            item.is_active = '0';
                        }
                        if (email != null)
                        {
                            item.exchanged = '1';
                            edAO.updateExchange(email, item);
                        }
                        else
                        {
                            item.exchanged = '0';
                        }
                        dAO.updateMovie(item);
                        item.IsEditable2 = false;
                        items.EditIndex2 = -1;
                    }
                }
                else
                {
                    Item item = items.allItems[items.EditIndex2];
                    if (id2 == true)
                    {
                        item.is_active = '1';

                    }
                    else
                    {
                        item.is_active = '0';
                    }
                    if (email != null)
                    {
                        item.exchanged = '1';
                        edAO.updateExchange(email, item);
                    }
                    else
                    {
                        item.exchanged = '0';
                    }
                    dAO.updateMovie(item);
                    item.IsEditable2 = false;
                    items.EditIndex2 = -1;
                }

            }
            var value = Request.Cookies["user_id"].Value;
            var groupidvalue = Request.Cookies["group_id"].Value;
            if (groupidvalue == "1")
            {
                items = dAO.ItemsForAdmin();
            }
            else
            {
                int.TryParse(value, out int result);
                items = dAO.ItemsByUser(result);
            }
            return View(items);
        }

        public ActionResult EditCategory(Category items, string Save)
        {
            
            CategoryDAO dAO = new CategoryDAO();
            if (Save == "Save")
            {
                Category item = items.allCategories[items.EditIndex];
                dAO.UpdateCategory(item);
                item.IsEditable = false;
                items.EditIndex = -1;
            }
            items = dAO.FCategory2();
            return View(items);
        }

        public ActionResult CategoryEdits(int? id, Category categories)
        {
            int id2 = id ?? default(int);
            CategoryDAO dAO = new CategoryDAO();
            categories = dAO.FCategory2();
            categories.EditIndex = dAO.setCategoryToEditMode(categories.allCategories, id2);
            ViewBag.Message = "All items.";
            return View("EditCategory", categories);
        }

        public ActionResult CategoriesDeleted(int? id, Category categories)
        {
            int id2 = id ?? default(int);
            CategoryDAO dAO = new CategoryDAO();
            dAO.DeleteItems(id2);
            categories = dAO.FCategory2();
           
            return View("EditCategory", categories);
        }
        public ActionResult ItemsEdit(int? id, Item items)
        {
            int id2 = id ?? default(int);
            var value = Request.Cookies["user_id"].Value;
            int.TryParse(value, out int result);
            ItemDAO dAO = new ItemDAO();
            var groupidvalue = Request.Cookies["group_id"].Value;
            if (groupidvalue == "1")
            {
                items = dAO.ItemsForAdmin();
            }
            else
            {
                items = dAO.ItemsByUser(result);
            }
            items.EditIndex2 = dAO.setMovieToEditMode(items.allItems, id2);
            ViewBag.Message = "All items.";
            return View("AllItems", items);
        }

        public ActionResult ItemsDelete(int? id, Item items)
        {
            int id2 = id ?? default(int);
            var value = Request.Cookies["user_id"].Value;
            int.TryParse(value, out int result);
            ItemDAO dAO = new ItemDAO();
            dAO.deleteMovie(id2);
            items = dAO.ItemsByUser(result);
            ViewBag.Message = "All Movies.";
            return View("AllItems", items);
        }


        public ActionResult Post(int? user_id, int? category_id, char? is_active, char? exchanged, DateTime? create_date, DateTime? last_renewed_on, string item_title, string item_detail, HttpPostedFileBase file, string Save)
        {

            
            int id22 = user_id ?? default(int);
            int id23 = category_id ?? default(int);
            char id24 = is_active ?? default(char);
            char id27 = exchanged ?? default(char);
            DateTime id25 = create_date ?? default(DateTime);
            DateTime id26 = last_renewed_on ?? default(DateTime);

            if (Save == "Add Item")
            {
                ItemDAO dAO = new ItemDAO();
                if (file != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        file.InputStream.CopyTo(ms);
                        byte[] array = ms.ToArray();

                        dAO.Post(id22, id23, id24, id27, id25, id26, item_title, item_detail, array);


                    }

                }


                ViewBag.Message = "Item posted Successfully.";
            }
            List<Category> categorylist = CategoryDAO.FCategory();
            ViewData["categorylist"] = categorylist;
            ViewBag.Categories = categorylist;
            return View("Post");
        }

    }
}