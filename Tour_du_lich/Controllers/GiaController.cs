using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tour_du_lich.Models;

namespace Tour_du_lich.Controllers
{
    public class GiaController : Controller
    {
        // GET: Gia
        public ActionResult QuanLyGia()
        {
            DBTOUREntities DBGia = new DBTOUREntities();
            var giaList = DBGia.gias.ToList();
            return View(giaList);
        }
    }
}