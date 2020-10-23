using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tour_du_lich.Dao;
using Tour_du_lich.Models;
namespace Tour_du_lich.Controllers
{
    public class TourController : Controller
    {
        TourDao tDao = new TourDao();
        // GET: Tour
        public ActionResult QuanLyTour()
        {

            var tourList = tDao.GetAllTour();
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