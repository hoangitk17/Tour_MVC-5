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
        LoaiTourDao ltDao = new LoaiTourDao();

     
        // GET: Tour
        public ActionResult QuanLyTour()
        {

  
            ViewBag.tours = tDao.GetAllTour();
            ViewBag.loaitours = ltDao.GetAllLoaiTour();
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