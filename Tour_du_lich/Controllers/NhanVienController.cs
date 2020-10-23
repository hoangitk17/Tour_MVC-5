using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tour_du_lich.Models;
using Tour_du_lich.Dao;

namespace Tour_du_lich.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: NhanVien
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult QuanLyNhanVien()
        {
            DBTOUREntities DBNhanvien = new DBTOUREntities();
            var nhanvienList = DBNhanvien.nhanviens.ToList();
            if (Session["login"] != null)
            {
                return View(nhanvienList);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult QuanLyNhanVien(NhanVienModel nhanvien)
        {
            NhanVienDao nhanVienDao = new NhanVienDao();
            try
            {
                string code;
                if (nhanVienDao.ExistId(nhanvien.manv))
                {
                    code = Constants.EXISTS;
                }
                else
                {
                    nhanVienDao.AddNhanVien(nhanvien);
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
        public ActionResult DeleteNhanVien(string id)
        {
            NhanVienDao nhanVienDao = new NhanVienDao();
            try
            {
                nhanVienDao.Delete(id);
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
        public ActionResult GetNhanVien(string id)
        {
            NhanVienDao nhanVienDao = new NhanVienDao();
            try
            {
                NhanVienModel nhanvien = nhanVienDao.GetNhanVienById(id);
                string code = Constants.SUCCESS;
                return Json(new { Code = code, manv = nhanvien.manv, tennv = nhanvien.tennv, diachi = nhanvien.diachi, JsonRequestBehavior.AllowGet });
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return Json(new { Message = message, JsonRequestBehavior.AllowGet });
            }
        }



        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditNhanVien(NhanVienModel nhanvien)
        {
            NhanVienDao nhanVienDao = new NhanVienDao();
            try
            {
                string code;
                if (nhanVienDao.ExistId(nhanvien.manv) == false)
                {
                    code = Constants.NOT_EXISTS;
                }
                else
                {
                    nhanVienDao.Update(nhanvien);
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