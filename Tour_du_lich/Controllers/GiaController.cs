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
        GiaDao gDao = new GiaDao();
        TourDao tDao = new TourDao();
        // GET: Gia
        public ActionResult QuanLyGia()
        {
            ViewBag.gias = gDao.GetAllGia();
            ViewBag.tours = tDao.GetAllTour();
            if (Session["login"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public ActionResult Edit(gia gia)
        {
            if(ModelState.IsValid)
            {
                
                var result = gDao.Update(gia);
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

        // POST: Create a dia diem
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult QuanLyGia(GiaModel gia)
        {


            try
            {
                string code;

                if (gDao.ExistId(gia.magia))
                {
                    code = Constants.EXISTS;
                }
                else
                {
                    gDao.AddGia(gia);
                    code = Constants.SUCCESS;
                }

                return Json(new { Code = code, JsonRequestBehavior.AllowGet });
            }
            catch (Exception ex)
            {
                string message = "FAIL";
                return Json(new { Message = message, JsonRequestBehavior.AllowGet });
            }
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(string id)
        {
            try
            {
                gDao.Delete(id);
                string code = Constants.SUCCESS;
                return Json(new { Code = code, JsonRequestBehavior.AllowGet });
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return Json(new { Message = message, JsonRequestBehavior.AllowGet });
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult GetGia(string id)
        {
            try
            {
                GiaModel gia = gDao.GetGia(id);
                string code = Constants.SUCCESS;
                DateTime dtbd = Convert.ToDateTime(gia.tgbd.ToString());
                DateTime dtkt = Convert.ToDateTime(gia.tgkt.ToString());

                return Json(new
                {
                    Code = code,
                    magia = gia.magia,
                    matour = gia.matour,
                    tgbd = dtbd.ToString("yyyy-MM-dd"),
                    tgkt = dtkt.ToString("yyyy-MM-dd"),
                    giatien = gia.giatien
                    ,
                    JsonRequestBehavior.AllowGet
                });
            }
            catch (Exception ex)
            { 
                string message = ex.Message;
                return Json(new { Message = message, JsonRequestBehavior.AllowGet });
            }
        }
    }
}