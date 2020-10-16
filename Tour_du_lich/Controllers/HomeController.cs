using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tour_du_lich.Models;

namespace Tour_du_lich.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DBTOUREntities DBTour = new DBTOUREntities();
            var tourList = DBTour.tours.ToList();
            //return View(tourList);
            if (Session["login"] != null)
            {
                return View(tourList);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }
    }
}