using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tour_du_lich.Models;

namespace Tour_du_lich.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            Session.Clear();
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            LoginModel l = new LoginModel();
            l.UserName = model.UserName;
            l.Password = model.Password;
            if(l.UserName == "admin" && l.Password == "admin")
            {
                Session["login"] = "login";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Index");
            }   
        }
    }
}