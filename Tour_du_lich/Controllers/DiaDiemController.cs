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
        // GET: DiaDiem
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult QuanLyDiaDiem()
        {
            var diadiemList = new DiaDiemDAO().GetDiaDiem() ;
            if (Session["login"] != null)
            {
                return View(diadiemList);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        // POST: Home/Create
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult QuanLyDiaDiem(diadiem d)
        {
            
           
            try
            {
                string code;
                DiaDiemDAO diadiems = new DiaDiemDAO();
                if(diadiems.ExistId(d.madiadiem))
                {
                    code = "400";
                } else
                {
                    diadiems.AddDiaDiem(d);
                    code = "201";
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
        public JsonResult getDiaDiem(string id)
        {
            List<diadiem> diadiemList = new DiaDiemDAO().GetDiaDiem();
            return Json(new
            {
                diadiemList
            }, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Delete(string id)
        {
            new DiaDiemDAO().Delete(id);
            List<diadiem> diadiemList = new DiaDiemDAO().GetDiaDiem();
            return RedirectToAction("QuanLyDiaDiem", "DiaDiem", diadiemList);
        }
    }
}