using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tour_du_lich.Models;
using Tour_du_lich.Dao;

namespace Tour_du_lich.Controllers
{
    public class DoanController : Controller
    {
        DoanDao gDao = new DoanDao();
        TourDao tDao = new TourDao();
        KhachDao kDao = new KhachDao();
        // GET: Doan
        public ActionResult QuanLyDoan()
        {
            ViewBag.doans = gDao.GetAllDoan();
            ViewBag.tours = tDao.GetAllTour();
            ViewBag.khachs = kDao.GetAllKhach();
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
        public ActionResult EditDoan(DoanModel doan)
        {
            DoanDao doanDao = new DoanDao();
            try
            {
                string code;
                if (doanDao.ExistId(doan.madoan) == false)
                {
                    code = Constants.NOT_EXISTS;
                }
                else
                {
                    doanDao.Update(doan);
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

        // POST: Create a đoàn
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult QuanLyDoan(DoanModel Doan)
        {

            try
            {
                string code;

                if (gDao.ExistId(Doan.madoan))
                {
                    code = Constants.EXISTS;
                }
                else
                {
                    gDao.AddDoan(Doan);
                    gDao.addKhachChoDoan(Doan.khachs, Doan.madoan);
                    code = Constants.SUCCESS;
                }

                return Json(new { Code = code, JsonRequestBehavior.AllowGet });
            }
            catch (Exception ex)
            {
                string message = "FAIL";
                return Json(new { Message = message, JsonRequestBehavior.AllowGet });
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteDoan(string id)
        {
            try
            {
                gDao.Delete(id);
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
        public ActionResult GetDoan(string id)
        {
            try
            {
                DoanModel Doan = gDao.GetDoan(id);
                string code = Constants.SUCCESS;
                DateTime ngaybatdau = Convert.ToDateTime(Doan.ngaybatdau.ToString());
                DateTime ngayketthuc = Convert.ToDateTime(Doan.ngayketthuc.ToString());

                return Json(new
                {
                    Code = code,
                    madoan = Doan.madoan,
                    matour = Doan.matour,
                    khachs = Doan.khachs,
                    ngaybatdau = ngaybatdau.ToString("yyyy-MM-dd"),
                    ngayketthuc = ngayketthuc.ToString("yyyy-MM-dd"),
                    JsonRequestBehavior.AllowGet
                });
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return Json(new { Message = message, JsonRequestBehavior.AllowGet });
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult GetCustomer(string id)
        {
            try
            {
                List<KhachModel> khachs = gDao.GetCustomer(id);
                string code = Constants.SUCCESS;
                return Json(new
                {
                    Code = code,
                    khachs = khachs,
                    JsonRequestBehavior.AllowGet
                });
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return Json(new { Message = message, JsonRequestBehavior.AllowGet });
            }
        }
    }
}