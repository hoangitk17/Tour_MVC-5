using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tour_du_lich.Dao;
using Tour_du_lich.Models;

namespace Tour_du_lich.Controllers
{
    public class KhachController : Controller
    {
        // GET: Khach
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult QuanLyKhach()
        {
            DBTOUREntities DBKhach = new DBTOUREntities();
            var khachList = DBKhach.khachhangs.ToList();
            if (Session["login"] != null)
            {
                return View(khachList);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult QuanLyKhach(KhachModel Khach)
        {
            KhachDao KhachDao = new KhachDao();
            try
            {
                string code;
                if (KhachDao.ExistId(Khach.makh))
                {
                    code = Constants.EXISTS;
                }
                else
                {
                    KhachDao.AddKhach(Khach);
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
        public ActionResult DeleteKhach(string id)
        {
            KhachDao KhachDao = new KhachDao();
            try
            {
                KhachDao.Delete(id);
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
        public ActionResult GetKhach(string id)
        {
            KhachDao KhachDao = new KhachDao();
            try
            {
                KhachModel Khach = KhachDao.GetKhachById(id);
                string code = Constants.SUCCESS;
                return Json(new { Code = code, makh = Khach.makh, tenkh = Khach.tenkh, diachi = Khach.diachi, sdt = Khach.sdt, gioitinh = Khach.gioitinh, cmnd = Khach.cmnd, JsonRequestBehavior.AllowGet });
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return Json(new { Message = message, JsonRequestBehavior.AllowGet });
            }
        }



        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditKhach(KhachModel Khach)
        {
            KhachDao KhachDao = new KhachDao();
            try
            {
                string code;
                if (KhachDao.ExistId(Khach.makh) == false)
                {
                    code = Constants.NOT_EXISTS;
                }
                else
                {
                    KhachDao.Update(Khach);
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