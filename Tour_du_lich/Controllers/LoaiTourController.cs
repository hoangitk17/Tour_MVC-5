using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tour_du_lich.Models;

namespace Tour_du_lich.Controllers
{
    public class LoaiTourController : Controller
    {
        // GET: LoaiTour
        public ActionResult QuanLyLoaiTour()
        {
            DBTOUREntities DBLoaitour = new DBTOUREntities();
            var loaitourList = DBLoaitour.loaitours.ToList();
            return View(loaitourList);
        }
    }
}