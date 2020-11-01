using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tour_du_lich.Models;
using Tour_du_lich.Dao;

namespace Tour_du_lich.Controllers
{
    public class ChiPhiController : Controller
    {
        DoanDao d = new DoanDao();
        LoaiChiPhiDao lcp = new LoaiChiPhiDao();
        ChiPhiDao cp = new ChiPhiDao();

        // GET: ChiPhi
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult QuanLyChiPhi()
        {
            ViewBag.doans = d.GetAllDoan();
            ViewBag.loaichiphis = lcp.GetAllLoaiChiPhi();
            ViewBag.chiphis = cp.GetAllChiPhi();
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
        public ActionResult QuanLyChiPhi(ChiPhiModel ChiPhi)
        {
            ChiPhiDao ChiPhiDao = new ChiPhiDao();
            try
            {
                string code;
                if (ChiPhiDao.ExistId(ChiPhi.maloaichiphi, ChiPhi.madoan))
                {
                    code = Constants.EXISTS;
                }
                else
                {
                    ChiPhiDao.AddChiPhi(ChiPhi);
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
        public ActionResult DeleteChiPhi(string id_chiphi, string id_doan)
        {
            ChiPhiDao ChiPhiDao = new ChiPhiDao();
            try
            {
                ChiPhiDao.Delete(id_chiphi, id_doan);
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
        public ActionResult GetChiPhi(string id_chiphi, string id_doan)
        {
            ChiPhiDao ChiPhiDao = new ChiPhiDao();
            try
            {
                ChiPhiModel ChiPhi = ChiPhiDao.GetChiPhiById(id_chiphi, id_doan);
                string code = Constants.SUCCESS;
                return Json(new { Code = code, machiphi = ChiPhi.machiphi, maloaichiphi = ChiPhi.maloaichiphi, madoan = ChiPhi.madoan, giathanh = ChiPhi.giathanh, ghichu = ChiPhi.ghichu, JsonRequestBehavior.AllowGet });
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return Json(new { Message = message, JsonRequestBehavior.AllowGet });
            }
        }



        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditChiPhi(ChiPhiModel ChiPhi)
        {
            ChiPhiDao ChiPhiDao = new ChiPhiDao();
            try
            {
                string code;
                if (ChiPhiDao.ExistId(ChiPhi.maloaichiphi, ChiPhi.madoan) == false)
                {
                    code = Constants.NOT_EXISTS;
                }
                else
                {
                    ChiPhiDao.Update(ChiPhi);
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