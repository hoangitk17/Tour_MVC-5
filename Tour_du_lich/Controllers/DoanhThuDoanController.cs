using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tour_du_lich.Dao;
using Tour_du_lich.Models;

namespace Tour_du_lich.Controllers
{
    public class DoanhThuDoanController : Controller
    {
        DoanDao doan = new DoanDao();
        LoaiChiPhiDao lcp = new LoaiChiPhiDao();
        ChiPhiDao cp = new ChiPhiDao();

        // GET: Doanh Thu Doan
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult DoanhThuDoan()
        {
            ViewBag.doans = doan.GetAllDoan();
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
        public ActionResult DoanhThuDoan(String id_doan)
        {
            try
            {
                string code;
                List<DoanhThuDoanModel> res = doan.GetDoanhThuDoan(id_doan);
                ViewBag.doanhthudoans = doan.GetDoanhThuDoan(id_doan);
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