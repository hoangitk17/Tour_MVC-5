using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tour_du_lich.Dao;
using Tour_du_lich.Models;

namespace Tour_du_lich.Controllers
{
    public class LoaiTourController : Controller
    {
        // GET: LoaiTour
        LoaiTourDao loaiTourDao = new LoaiTourDao();
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult QuanLyLoaiTour()
        {
            List<LoaiTourModel> loaiTours = loaiTourDao.GetAllLoaiTour();
            if (Session["login"] != null)
            {
                return View(loaiTours);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }



        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult QuanLyLoaiTour(LoaiTourModel loaitour)
        {
            try
            {
                string code;
                if (loaiTourDao.ExistId(loaitour.maloai))
                {
                    code = Constants.EXISTS;
                }
                else
                {
                    loaiTourDao.AddLoaiTour(loaitour);
                    code = Constants.SUCCESS;
                }

                return Json(new { Code = code , JsonRequestBehavior.AllowGet });
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return Json(new { Message = message, JsonRequestBehavior.AllowGet });
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteTour(string id)
        {
            try
            {
                loaiTourDao.Delete(id);
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
        public ActionResult GetLoaiTour(string id)
        {
            try
            {
                LoaiTourModel loaitour = loaiTourDao.GetLoaiTour(id);
                string code = Constants.SUCCESS;
                return Json(new { Code = code, maloai = loaitour.maloai, tenloai = loaitour.tenloai, JsonRequestBehavior.AllowGet });
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return Json(new { Message = message, JsonRequestBehavior.AllowGet });
            }
        }



        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditLoaiTour(LoaiTourModel loaitour)
        {
            try
            {
                string code;
                if (loaiTourDao.ExistId(loaitour.maloai) == false)
                {
                    code = Constants.NOT_EXISTS;
                }
                else
                {
                    loaiTourDao.Update(loaitour);
                    code = Constants.SUCCESS;
                }

                return Json(new { Code = code, JsonRequestBehavior.AllowGet });
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return Json(new { Message = message, JsonRequestBehavior.AllowGet });
            }
        }
    }
}