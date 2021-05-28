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



        public ActionResult RemoveData()
        {

            var fn = new HttpCookie("first_name");
            fn.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(fn);

            var ui = new HttpCookie("user_id");
            ui.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(ui);

            var gi = new HttpCookie("group_id");
            gi.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(gi);
            return RedirectToAction("../Auth/Login");
        }



        [HttpPost]
        public ActionResult Login(string email, string login_pwd_encry)
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
                if (customer.login_pwd_encry != login_pwd_encry)
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

            HttpCookie user_id = new HttpCookie("user_id");
            HttpCookie first_name = new HttpCookie("first_name");
            HttpCookie group_id = new HttpCookie("group_id");

            user_id.Value = customer.user_id.ToString();
            group_id.Value = customer.group_id.ToString();
            first_name.Value = customer.first_name;
            HttpContext.Response.Cookies.Add(user_id);
            HttpContext.Response.Cookies.Add(group_id);
            HttpContext.Response.Cookies.Add(first_name);

            return RedirectToAction("../Home/Item");
        }
    }
}