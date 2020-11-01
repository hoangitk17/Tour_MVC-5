using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tour_du_lich.Dao;
using Tour_du_lich.Models;
namespace Tour_du_lich.Controllers
{
    public class TourController : Controller
    {
        TourDao tDao = new TourDao();
        LoaiTourDao ltDao = new LoaiTourDao();
        DiaDiemDao ddDao = new DiaDiemDao();

     
        // GET: Tour
        public ActionResult QuanLyTour()
        {

  
            ViewBag.tours = tDao.GetAllTour();
            ViewBag.loaitours = ltDao.GetAllLoaiTour();
            ViewBag.diadiems = ddDao.GetAllDiaDiem();
            if (Session["login"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // POST: Create a Tour
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult QuanLyTour(TourDataModel insertTour)
        {


            try
            {
                string code;

                if (tDao.ExistId(insertTour.matour))
                {
                    code = Constants.EXISTS;
                }
                else
                {
                    tDao.AddTour(insertTour);
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
        public ActionResult Delete(string id)
        {
            try
            {
                string code;

                if (tDao.ExistIdInAnotherTable(id))
                {
                    code = Constants.EXISTS_FOREIGN_KEY;
                }
                else
                {
                    tDao.Delete(id);
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
        public ActionResult EditTour(TourDataModel tour)
        {
            try
            {
                string code;
                if (tDao.ExistId(tour.matour) == false)
                {
                    code = Constants.NOT_EXISTS;
                }
                else
                {
                    tDao.EditTour(tour);
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
        public ActionResult GetTour(string id)
        {
            try
            {
                TourDataModel receivedTour = tDao.GetTour(id);
                string code = Constants.SUCCESS;
                return Json(new { Code = code, tour = receivedTour, JsonRequestBehavior.AllowGet });
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return Json(new { Message = message, JsonRequestBehavior.AllowGet });
            }
        }
    }
}