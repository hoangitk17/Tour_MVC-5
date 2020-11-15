using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tour_du_lich.Dao;
using Tour_du_lich.Models;

namespace Tour_du_lich.Controllers
{
    public class LoiNhuanTourController : Controller
    {
        TourDao tour = new TourDao();
        // GET: Doanh Thu Doan
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult LoiNhuanTour()
        {
            //ViewBag.tours = tour.GetAllTour();
            //if(TempData["loinhuantours"] != null)
            //{
            //    ViewBag.thoigianbatdau = TempData["thoigianbatdau"];
            //    ViewBag.thoigianketthuc = TempData["thoigianketthuc"];
            //    ViewBag.total = TempData["total"];
            //    ViewBag.loinhuantours = TempData["loinhuantours"];
            //}
            
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
        public ActionResult LoiNhuanTour(DateTime thoigianbatdau, DateTime thoigianketthuc)
        {
            try
            {
                ArrayList result = tour.GetAllMaTour();
                string code;
                ArrayList res = tour.LoiNhuanTour(thoigianbatdau, thoigianketthuc);
                double max_tour = tour.MaxLoiNhuanTour(res);
                double total = tour.TotalLoiNhuan(res);
                ViewBag.loinhuantours = res;
                ViewBag.total = total;
                TempData["loinhuantours"] = res;
                TempData["thoigianbatdau"] = thoigianbatdau;
                TempData["thoigianketthuc"] = thoigianketthuc;
                TempData["total"] = total;
                code = Constants.SUCCESS;
                return Json(new { Code = code, max = max_tour, data = res, tours = result, total_price = total, JsonRequestBehavior.AllowGet });
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return Json(new { Message = message, JsonRequestBehavior.AllowGet });
            }
        }
    }
}