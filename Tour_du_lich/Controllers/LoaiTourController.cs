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
    }
}