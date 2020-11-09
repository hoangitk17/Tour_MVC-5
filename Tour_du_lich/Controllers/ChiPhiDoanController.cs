using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tour_du_lich.Dao;
using Tour_du_lich.Models;

namespace Tour_du_lich.Controllers
{
    public class ChiPhiDoanController : Controller
    {
        DoanDao doan = new DoanDao();
        LoaiChiPhiDao lcp = new LoaiChiPhiDao();
        ChiPhiDao cp = new ChiPhiDao();

        // GET: Doanh Thu Doan
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ChiPhiDoan()
        {
            ViewBag.doans = doan.GetAllDoan();
            if (TempData["chiphidoans"] != null)
            {
                ViewBag.ChiPhidoans = (List<ChiPhiDoanModel>)TempData["chiphidoans"];
                ViewBag.madoan = TempData["ma-doan"];
                ViewBag.thoigianbatdau = TempData["thoigianbatdau"];
                ViewBag.thoigianketthuc = TempData["thoigianketthuc"];
                ViewBag.chiphi = TempData["chi-phi"];
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
        public ActionResult ChiPhiDoan(String id_doan, DateTime thoigianbatdau, DateTime thoigianketthuc)
        {
            try
            {
                string code;
                List<ChiPhiDoanModel> res = doan.GetChiPhiDoan(id_doan, thoigianbatdau, thoigianketthuc);
                ViewBag.ChiPhidoans = res;
                TempData["chiphidoans"] = res;
                TempData["thoigianbatdau"] = thoigianbatdau;
                TempData["thoigianketthuc"] = thoigianketthuc;
                TempData["ma-doan"] = id_doan;
                TempData["chi-phi"] = doan.totalChiPhiDoan(res);
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