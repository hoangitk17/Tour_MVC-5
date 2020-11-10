using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tour_du_lich.Dao;
using Tour_du_lich.Models;

namespace Tour_du_lich.Controllers
{
    public class SoLanDiTourCuaNVController : Controller
    {
        DoanDao doan = new DoanDao();
        NhanVienDao nv = new NhanVienDao();
        LoaiChiPhiDao lcp = new LoaiChiPhiDao();
        ChiPhiDao cp = new ChiPhiDao();

        // GET: Doanh Thu Doan
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult SoLanDiTourCuaNV()
        {
            ViewBag.nhanviens = nv.GetAllNhanVien();
            if (TempData["solanditourcuanvs"] != null)
            {
                ViewBag.solanditourcuanvs = (List<SoLanDiTourCuaNVModel>)TempData["solanditourcuanvs"];
                ViewBag.manv = TempData["ma-nhanvien"];
                ViewBag.quantity = TempData["quantity"];
                ViewBag.thoigianbatdau = TempData["thoigianbatdau"];
                ViewBag.thoigianketthuc = TempData["thoigianketthuc"];
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
        public ActionResult SoLanDiTourCuaNV(String id_nhanvien, DateTime thoigianbatdau, DateTime thoigianketthuc)
        {
            try
            {
                string code;
                List<SoLanDiTourCuaNVModel> res = nv.SoLanDiTourCuaNV(id_nhanvien, thoigianbatdau, thoigianketthuc);
                ViewBag.solanditourcuanvs = res;
                TempData["quantity"] = res.Count;
                TempData["solanditourcuanvs"] = res;
                TempData["thoigianbatdau"] = thoigianbatdau;
                TempData["thoigianketthuc"] = thoigianketthuc;
                TempData["ma-nhanvien"] = id_nhanvien;
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