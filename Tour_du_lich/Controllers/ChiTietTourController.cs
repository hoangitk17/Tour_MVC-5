using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tour_du_lich.Models;
using Tour_du_lich.Dao;

namespace Tour_du_lich.Controllers
{
    public class ChiTietTourController : Controller
    {
        DoanDao d = new DoanDao();
        NhanVienDao nv = new NhanVienDao();
        ChiTietTourDao pc = new ChiTietTourDao();
        TourDao t = new TourDao();
        DiaDiemDao dd = new DiaDiemDao();

        // GET: ChiTietTour
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult QuanLyChiTietTour()
        {
            ViewBag.doans = d.GetAllDoan();
            ViewBag.chitiettours = pc.GetAllChiTietTour();
            ViewBag.nhanviens = nv.GetAllNhanVien();
            ViewBag.tours = t.GetAllTour();
            ViewBag.diadiems = dd.GetAllDiaDiem();

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
        public ActionResult QuanLyChiTietTour(ChiTietTourModel ChiTietTour)
        {
            ChiTietTourDao ChiTietTourDao = new ChiTietTourDao();
            try
            {
                string code;
                if (ChiTietTourDao.ExistId(ChiTietTour.matour, ChiTietTour.madiadiem))
                {
                    code = Constants.EXISTS;
                }
                else
                {
                    ChiTietTourDao.AddChiTietTour(ChiTietTour);
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
        public ActionResult DeleteChiTietTour(string matour, string madiadiem)
        {
            ChiTietTourDao ChiTietTourDao = new ChiTietTourDao();
            try
            {
                ChiTietTourDao.Delete(matour, madiadiem);
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
        public ActionResult GetChiTietTour(string matour, string madiadiem)
        {
            ChiTietTourDao ChiTietTourDao = new ChiTietTourDao();
            try
            {
                ChiTietTourModel ChiTietTour = ChiTietTourDao.GetChiTietTourById(matour, madiadiem);
                string code = Constants.SUCCESS;
                return Json(new { Code = code, matour = ChiTietTour.matour, madiadiem = ChiTietTour.madiadiem, thutu = ChiTietTour.thutu, JsonRequestBehavior.AllowGet });
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return Json(new { Message = message, JsonRequestBehavior.AllowGet });
            }
        }



        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditChiTietTour(ChiTietTourModel ChiTietTour)
        {
            ChiTietTourDao ChiTietTourDao = new ChiTietTourDao();
            try
            {
                string code;
                if (ChiTietTourDao.ExistId(ChiTietTour.matour, ChiTietTour.madiadiem) == false)
                {
                    code = Constants.NOT_EXISTS;
                }
                else
                {
                    ChiTietTourDao.Update(ChiTietTour);
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