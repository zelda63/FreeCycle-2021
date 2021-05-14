using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FreeCycle2.DataAccessObjects;
using FreeCycle2.Models;

namespace FreeCycle2.Controllers
{
    public class ItemDetailsController : Controller
    {
        // GET: ItemDetails
        public ActionResult ItemDetails(int? item_id)
        {
            int id45 = item_id ?? default(int);
            List<Item> itemlist45 = ItemDAO.ItemsByID(id45);
            ViewData["itemlist45"] = itemlist45;
            ViewBag.a = 45;
            return View("../Home/ItemDetails");


        }
    }
}