using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tour_du_lich.Models;
using Tour_du_lich.Dao;

namespace Tour_du_lich.Controllers
{
    public class LoaiChiPhiController : Controller
    {
        // GET: LoaiChiPhi
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult QuanLyLoaiChiPhi()
        {
            DBTOUREntities DBLoaiChiPhi = new DBTOUREntities();
            var LoaiChiPhiList = DBLoaiChiPhi.loaichiphis.ToList();
            if (Session["login"] != null)
            {
                return View(LoaiChiPhiList);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult QuanLyLoaiChiPhi(LoaiChiPhiModel LoaiChiPhi)
        {
            LoaiChiPhiDao LoaiChiPhiDao = new LoaiChiPhiDao();
            try
            {
                string code;
                if (LoaiChiPhiDao.ExistId(LoaiChiPhi.maloaichiphi))
                {
                    code = Constants.EXISTS;
                }
                else
                {
                    LoaiChiPhiDao.AddLoaiChiPhi(LoaiChiPhi);
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
        public ActionResult DeleteLoaiChiPhi(string id)
        {
            LoaiChiPhiDao LoaiChiPhiDao = new LoaiChiPhiDao();
            try
            {
                LoaiChiPhiDao.Delete(id);
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
        public ActionResult GetLoaiChiPhi(string id)
        {
            LoaiChiPhiDao LoaiChiPhiDao = new LoaiChiPhiDao();
            try
            {
                LoaiChiPhiModel LoaiChiPhi = LoaiChiPhiDao.GetLoaiChiPhiById(id);
                string code = Constants.SUCCESS;
                return Json(new { Code = code, maloaichiphi = LoaiChiPhi.maloaichiphi, tenloaichiphi = LoaiChiPhi.tenloaichiphi, JsonRequestBehavior.AllowGet });
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return Json(new { Message = message, JsonRequestBehavior.AllowGet });
            }
        }



        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditLoaiChiPhi(LoaiChiPhiModel LoaiChiPhi)
        {
            LoaiChiPhiDao LoaiChiPhiDao = new LoaiChiPhiDao();
            try
            {
                string code;
                if (LoaiChiPhiDao.ExistId(LoaiChiPhi.maloaichiphi) == false)
                {
                    code = Constants.NOT_EXISTS;
                }
                else
                {
                    LoaiChiPhiDao.Update(LoaiChiPhi);
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