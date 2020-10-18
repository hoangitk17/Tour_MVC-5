using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tour_du_lich.Models;

namespace Tour_du_lich.Controllers
{
    public class DoanController : Controller
    {
        // GET: Doan
        public ActionResult QuanLyDoan()
        {
            DBTOUREntities DBDoan = new DBTOUREntities();
            var doanList = DBDoan.doans.ToList();
            if (Session["login"] != null)
            {
                return View(doanList);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}