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

        public ActionResult QuanLyTour()
        {
            DBTOUREntities DBTour = new DBTOUREntities();
            var tourList = DBTour.tours.ToList();
            return View(tourList);
        }

        public ActionResult QuanLyDoan()
        {
            DBTOUREntities DBDoan = new DBTOUREntities();
            var doanList = DBDoan.doans.ToList();
            return View(doanList);
        }

        public ActionResult QuanLyKhach()
        {
            DBTOUREntities DBKhach = new DBTOUREntities();
            var khachList = DBKhach.khachhangs.ToList();
            return View(khachList);
        }

        public ActionResult QuanLyNhanVien()
        {
            DBTOUREntities DBNhanvien = new DBTOUREntities();
            var nhanvienList = DBNhanvien.nhanviens.ToList();
            return View(nhanvienList);
        }



        
        public ActionResult QuanLyLoaiTour()
        {
            DBTOUREntities DBLoaitour = new DBTOUREntities();
            var loaitourList = DBLoaitour.loaitours.ToList();
            return View(loaitourList);
        }

    }
}