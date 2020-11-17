using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tour_du_lich.Models;
using Tour_du_lich.Dao;

namespace Tour_du_lich.Controllers
{
    public class ChiTietDoanController : Controller
    {
        DoanDao d = new DoanDao();
        NhanVienDao nv = new NhanVienDao();
        ChiTietDoanDao pc = new ChiTietDoanDao();
        TourDao t = new TourDao();
        DiaDiemDao dd = new DiaDiemDao();
        KhachDao k = new KhachDao();

        // GET: ChiTietDoan
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult QuanLyChiTietDoan()
        {
            ViewBag.doans = d.GetAllDoan();
            ViewBag.chitietdoans = pc.GetAllChiTietDoan();
            ViewBag.nhanviens = nv.GetAllNhanVien();
            ViewBag.tours = t.GetAllTour();
            ViewBag.diadiems = dd.GetAllDiaDiem();
            ViewBag.khachhangs = k.GetAllKhach();

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
        public ActionResult QuanLyChiTietDoan(ChiTietDoanModel ChiTietDoan)
        {
            ChiTietDoanDao ChiTietDoanDao = new ChiTietDoanDao();
            try
            {
                string code;
                if (ChiTietDoanDao.ExistId(ChiTietDoan.madoan, ChiTietDoan.makh))
                {
                    code = Constants.EXISTS;
                }
                else
                {
                    ChiTietDoanDao.AddChiTietDoan(ChiTietDoan);
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
        public ActionResult DeleteChiTietDoan(string madoan, string makh)
        {
            ChiTietDoanDao ChiTietDoanDao = new ChiTietDoanDao();
            try
            {
                ChiTietDoanDao.Delete(madoan, makh);
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
        public ActionResult GetChiTietDoan(string madoan, string makh)
        {
            ChiTietDoanDao ChiTietDoanDao = new ChiTietDoanDao();
            try
            {
                ChiTietDoanModel ChiTietDoan = ChiTietDoanDao.GetChiTietDoanById(madoan, makh);
                string code = Constants.SUCCESS;
                return Json(new { Code = code, madoan = ChiTietDoan.madoan, makh = ChiTietDoan.makh, mota = ChiTietDoan.mota, JsonRequestBehavior.AllowGet });
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return Json(new { Message = message, JsonRequestBehavior.AllowGet });
            }
        }



        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditChiTietDoan(ChiTietDoanModel ChiTietDoan)
        {
            ChiTietDoanDao ChiTietDoanDao = new ChiTietDoanDao();
            try
            {
                string code;
                if (ChiTietDoanDao.ExistId(ChiTietDoan.madoan, ChiTietDoan.makh) == false)
                {
                    code = Constants.NOT_EXISTS;
                }
                else
                {
                    ChiTietDoanDao.Update(ChiTietDoan);
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