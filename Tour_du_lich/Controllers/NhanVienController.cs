using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tour_du_lich.Models;

namespace Tour_du_lich.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: NhanVien
        public ActionResult QuanLyNhanVien()
        {
            DBTOUREntities DBNhanvien = new DBTOUREntities();
            var nhanvienList = DBNhanvien.nhanviens.ToList();
            if (Session["login"] != null)
            {
                return View(nhanvienList);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}