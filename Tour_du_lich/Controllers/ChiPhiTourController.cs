using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tour_du_lich.Dao;
using Tour_du_lich.Models;

namespace Tour_du_lich.Controllers
{
    public class ChiPhiTourController : Controller
    {
        DoanDao doan = new DoanDao();
        TourDao tour = new TourDao();
        LoaiChiPhiDao lcp = new LoaiChiPhiDao();
        ChiPhiDao cp = new ChiPhiDao();

        // GET: Doanh Thu Doan
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ChiPhiTour()
        {
            ViewBag.tours = tour.GetAllTour();
            if (TempData["ChiPhiTours"] != null)
            {
                ViewBag.ChiPhiTours = (List<ChiPhiTourModel>)TempData["ChiPhiTours"];
                ViewBag.matour = TempData["ma-tour"];
                ViewBag.thoigianbatdau = TempData["thoigianbatdau"];
                ViewBag.thoigianketthuc = TempData["thoigianketthuc"];
                ViewBag.quantity = TempData["quantity"];
                ViewBag.total = TempData["allchiphi"];
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
        public ActionResult ChiPhiTour(String id_tour, DateTime thoigianbatdau, DateTime thoigianketthuc)
        {
            try
            {
                string code;
                List<ChiPhiTourModel> res = tour.GetChiPhiTour(id_tour, thoigianbatdau, thoigianketthuc);
                ViewBag.ChiPhiTours = res;
                TempData["quantity"] = res.Count;
                TempData["ChiPhiTours"] = res;
                TempData["thoigianbatdau"] = thoigianbatdau;
                TempData["thoigianketthuc"] = thoigianketthuc;
                TempData["ma-tour"] = id_tour;
                TempData["allchiphi"] = tour.TongChiphi(res);
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