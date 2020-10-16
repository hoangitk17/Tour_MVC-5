using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tour_du_lich.Models;
namespace Tour_du_lich.Controllers
{
    public class TourController : Controller
    {
        // GET: Tour
        public ActionResult QuanLyTour()
        {
            DBTOUREntities DBTour = new DBTOUREntities();
            var tourList = DBTour.tours.ToList();
            return View(tourList);
        }
    }
}