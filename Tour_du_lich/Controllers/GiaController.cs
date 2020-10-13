using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tour_du_lich.Models;
using Tour_du_lich.Dao;

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

        [HttpPost]
        public ActionResult Edit(gia gia)
        {
            if(ModelState.IsValid)
            {
                var dao = new GiaDao();
                var result = dao.Update(gia);
                if (result)
                {
                    return RedirectToAction("QuanLyGia","Gia");
                }else
                {
                    ModelState.AddModelError("", "Cập nhật giá thành công");
                }
            }
            return View("QuanLyGia");
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpDelete]
        public ActionResult Delete(string id)
        {
            new GiaDao().Delete(id);
            return RedirectToAction("QuanLyGia");
        }
    }
}