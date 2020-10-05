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
            return View();
        }

        public ActionResult QuanLyTour()
        {
            DBTOUREntities1 DBTour = new DBTOUREntities1();
            var tourList = DBTour.tours.ToList();
            return View(tourList);
        }

        public ActionResult QuanLyDoan()
        {
            return View();
        }

        public ActionResult QuanLyKhach()
        {
            return View();
        }

    }
}