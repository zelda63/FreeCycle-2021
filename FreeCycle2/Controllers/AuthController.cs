using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FreeCycle2.Models;
using FreeCycle2.DataAccessObjects;

namespace FreeCycle2.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            if (email == null)
                return View();

            User customer = UserDAO.UserByEmail(email);
            if (customer == null)
            {
                ViewData["warningUsername"] = "Wrong Username, Please try again";
                return View();
            }

            if (customer.email.Equals(email))
            {
                if (customer.password != password)
                {
                    ViewData["warningPassword"] = "Wrong password, Please try again";
                    return View();
                }
            }
            else
            {
                ViewData["warning"] = "Invalid username";
                return View();
            }

            return RedirectToAction("../Home/Item");
        }
    }
}