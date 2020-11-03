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
            ViewBag.tours = DBTour.tours.ToList();
            ViewBag.tourLength = DBTour.tours.ToList().Count;
            ViewBag.doanLength = DBTour.doans.ToList().Count;
            ViewBag.khachLength = DBTour.khachhangs.ToList().Count;
            ViewBag.giaLength = DBTour.gias.ToList().Count;
            if (Session["login"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }
    }
}