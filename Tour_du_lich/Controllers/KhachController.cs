using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tour_du_lich.Models;

namespace Tour_du_lich.Controllers
{
    public class KhachController : Controller
    {
        // GET: Khach
        public ActionResult QuanLyKhach()
        {
            DBTOUREntities DBKhach = new DBTOUREntities();
            var khachList = DBKhach.khachhangs.ToList();
            if (Session["login"] != null)
            {
                return View(khachList);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}