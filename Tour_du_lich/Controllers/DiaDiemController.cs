using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tour_du_lich.Models;
using Tour_du_lich.Dao;

namespace Tour_du_lich.Controllers
{

    public class DiaDiemController : Controller
    {
        DiaDiemDao ddDao = new DiaDiemDao();
        // GET: DiaDiem
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult QuanLyDiaDiem()
        {
            var diadiemList = ddDao.GetAllDiaDiem() ;
            if (Session["login"] != null)
            {
                return View(diadiemList);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        // POST: Create a dia diem
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult QuanLyDiaDiem(DiaDiemModel d)
        {
            
           
            try
            {
                string code;
                
                if(ddDao.ExistId(d.madiadiem))
                {
                    code = Constants.EXISTS;
                } else
                {
                    ddDao.AddDiaDiem(d);
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
                ddDao.Delete(id);
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
        public ActionResult EditDiaDiem(DiaDiemModel diadiem)
        {
            try
            {
                string code;
                if (ddDao.ExistId(diadiem.madiadiem) == false)
                {
                    code = Constants.NOT_EXISTS;
                }
                else
                {
                    ddDao.Edit(diadiem);
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
        public ActionResult GetDiaDiem(string id)
        {
            try
            {
                DiaDiemModel place = ddDao.GetDiaDiem(id);
                string code = Constants.SUCCESS;
                return Json(new { Code = code, madiadiem = place.madiadiem, tendiadiem = place.tendiadiem, JsonRequestBehavior.AllowGet });
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return Json(new { Message = message, JsonRequestBehavior.AllowGet });
            }
        }

    }
}