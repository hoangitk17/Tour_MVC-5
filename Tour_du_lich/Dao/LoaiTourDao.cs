using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tour_du_lich.Models;

namespace Tour_du_lich.Dao
{
    public class LoaiTourDao
    {
        
            DBTOUREntities DB = new DBTOUREntities();
           
            public List<LoaiTourModel> GetAllLoaiTour()
            {
                DB.Configuration.ProxyCreationEnabled = false;
                List<LoaiTourModel> result = new List<LoaiTourModel>();

                foreach (loaitour temp in DB.loaitours)
                {
                    LoaiTourModel loaiTour = new LoaiTourModel(temp.maloai, temp.tenloai);
                    result.Add(loaiTour);
                }

                return result;
            }

        public String AddLoaiTour(LoaiTourModel loaitourins)
        {
            try
            {
                loaitour data = new loaitour();
                data.maloai = loaitourins.maloai;
                data.tenloai = loaitourins.tenloai;
                DB.loaitours.Add(data);
                DB.SaveChanges();
                return "Success";
            } catch (Exception e)
            {
                return e.Message;
            }
        }

        public bool ExistId(String id)
        {
            var dd = DB.loaitours.SingleOrDefault(x => x.maloai == id);
            if (dd == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


    }
}