using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tour_du_lich.Models;
using Tour_du_lich.Dao;

namespace Tour_du_lich.Controllers
{
    public class PhanCongController : Controller
    {
        DoanDao d = new DoanDao();
        NhanVienDao nv = new NhanVienDao();
        PhanCongDao pc = new PhanCongDao();

        // GET: PhanCong
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult QuanLyPhanCong()
        {
            ViewBag.doans = d.GetAllDoan();
            ViewBag.phancongs = pc.GetAllPhanCong();
            ViewBag.nhanviens = nv.GetAllNhanVien();
            if (Session["login"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult QuanLyPhanCong(PhanCongModel PhanCong)
        {
            PhanCongDao PhanCongDao = new PhanCongDao();
            try
            {
                string code;
                if (PhanCongDao.ExistId(PhanCong.manv, PhanCong.madoan))
                {
                    code = Constants.EXISTS;
                }
                else
                {
                    PhanCongDao.AddPhanCong(PhanCong);
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

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeletePhanCong(string id_nv, string id_doan)
        {
            PhanCongDao PhanCongDao = new PhanCongDao();
            try
            {
                PhanCongDao.Delete(id_nv, id_doan);
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
        public ActionResult GetPhanCong(string id_nv, string id_doan)
        {
            PhanCongDao PhanCongDao = new PhanCongDao();
            try
            {
                PhanCongModel PhanCong = PhanCongDao.GetPhanCongById(id_nv, id_doan);
                string code = Constants.SUCCESS;
                return Json(new { Code = code, manv = PhanCong.manv, madoan = PhanCong.madoan, nhiemvu = PhanCong.nhiemvu, JsonRequestBehavior.AllowGet });
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return Json(new { Message = message, JsonRequestBehavior.AllowGet });
            }
        }



        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditPhanCong(PhanCongModel PhanCong)
        {
            PhanCongDao PhanCongDao = new PhanCongDao();
            try
            {
                string code;
                if (PhanCongDao.ExistId(PhanCong.manv, PhanCong.madoan) == false)
                {
                    code = Constants.NOT_EXISTS;
                }
                else
                {
                    PhanCongDao.Update(PhanCong);
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