using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tour_du_lich.Dao;
using Tour_du_lich.Models;

namespace Tour_du_lich.Controllers
{
    public class DoanhThuTourController : Controller
    {
        DoanDao doan = new DoanDao();
        TourDao tour = new TourDao();
        LoaiChiPhiDao lcp = new LoaiChiPhiDao();
        ChiPhiDao cp = new ChiPhiDao();

        // GET: Doanh Thu Doan
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult DoanhThuTour()
        {
            ViewBag.tours = tour.GetAllTour();
            if (TempData["doanhthutours"] != null)
            {
                ViewBag.doanhthutours = (List<DoanhThuTourModel>)TempData["doanhthutours"];
                ViewBag.matour = TempData["ma-tour"];
                ViewBag.thoigianbatdau = TempData["thoigianbatdau"];
                ViewBag.thoigianketthuc = TempData["thoigianketthuc"];
                ViewBag.quantity = TempData["quantity"];
            }
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
        public ActionResult DoanhThuTour(String id_tour, DateTime thoigianbatdau, DateTime thoigianketthuc)
        {
            try
            {
                string code;

                List<DoanhThuTourModel> res = tour.GetDoanhThuTour(id_tour, thoigianbatdau, thoigianketthuc);
                ViewBag.doanhthutours = res;
                TempData["quantity"] = res.Count;
                TempData["doanhthutours"] = res;
                TempData["thoigianbatdau"] = thoigianbatdau;
                TempData["thoigianketthuc"] = thoigianketthuc;
                TempData["ma-tour"] = id_tour;
                code = Constants.SUCCESS;
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