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
            return View(tourList);
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

        public ActionResult QuanLyGia()
        {
            DBTOUREntities DBGia = new DBTOUREntities();
            var giaList = DBGia.gias.ToList();
            return View(giaList);
        }


        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult QuanLyDiaDiem()
        {
            ViewBag.name = "GET";
            DBTOUREntities DBDiadiem = new DBTOUREntities();
            var diadiemList = DBDiadiem.diadiems.ToList();
            return View(diadiemList);
        }
        // POST: Home/Create
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult QuanLyDiaDiem(diadiem d)
        {
            ViewBag.name = "POST";
            try
            {
              
                DBTOUREntities DBTour = new DBTOUREntities();
                DBTour.diadiems.Add(d);
                DBTour.SaveChanges();
                DBTOUREntities DBDiadiem = new DBTOUREntities();
                string message = "SUCCESS";
                return Json(new { Message = message, JsonRequestBehavior.AllowGet });
            }
            catch(Exception ex)
            {
                string message = "FAIL";
                return Json(new { Message = message, JsonRequestBehavior.AllowGet });
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult getDiaDiem(string id)
        {
            
            DBTOUREntities DBDiadiem = new DBTOUREntities();
            DBDiadiem.Configuration.ProxyCreationEnabled = false;
            List<diadiem> diadiemList = DBDiadiem.diadiems.ToList();
            return Json(new {
                diadiemList
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult QuanLyLoaiTour()
        {
            DBTOUREntities DBLoaitour = new DBTOUREntities();
            var loaitourList = DBLoaitour.loaitours.ToList();
            return View(loaitourList);
        }

    }
}