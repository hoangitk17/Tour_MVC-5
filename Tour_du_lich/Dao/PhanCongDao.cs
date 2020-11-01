using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tour_du_lich.Models;

namespace Tour_du_lich.Dao
{
    public class PhanCongDao
    {
        
        DBTOUREntities DB = new DBTOUREntities();
           
        public List<PhanCongModel> GetAllPhanCong()
        {
            DB.Configuration.ProxyCreationEnabled = false;
            List<PhanCongModel> result = new List<PhanCongModel>();

            foreach (phancong temp in DB.phancongs)
            {
                PhanCongModel PhanCong = new PhanCongModel(temp.madoan, temp.manv, temp.nhiemvu);
                result.Add(PhanCong);
            }

            return result;
        }

        public PhanCongModel GetPhanCongById(string id_nv, string id_doan)
        {
            phancong temp = DB.phancongs.SingleOrDefault(PhanCong => PhanCong.manv == id_nv && PhanCong.madoan == id_doan);
            PhanCongModel PhanCong1 = new PhanCongModel();
            if (temp != null)
            {
                PhanCong1.manv = temp.manv;
                PhanCong1.madoan = temp.madoan;
                PhanCong1.nhiemvu = temp.nhiemvu;
            }
           
            return PhanCong1;
        }
        public void AddPhanCong(PhanCongModel PhanCong)
        {
            try
            {
                phancong data = new phancong();
                data.manv = PhanCong.manv;
                data.madoan = PhanCong.madoan;
                data.nhiemvu = PhanCong.nhiemvu;
                DB.phancongs.Add(data);
                DB.SaveChanges();
            } catch (Exception e)
            {
                
            }
        }

        public bool ExistId(string id_nv, string id_doan)
        {
            var dd = DB.phancongs.SingleOrDefault(x => x.manv == id_nv && x.madoan == id_doan);
            if (dd == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Delete(string id_nv, string id_doan)
        {
            phancong d = DB.phancongs.SingleOrDefault(PhanCong => PhanCong.manv == id_nv && PhanCong.madoan == id_doan);
            if (d != null)
            {
                DB.phancongs.Remove(d);
            }
            DB.SaveChanges();
        }

        public void Update(PhanCongModel PhanCongupdate)
        {
            phancong d = DB.phancongs.SingleOrDefault(PhanCong => PhanCong.manv == PhanCongupdate.manv && PhanCong.madoan == PhanCongupdate.madoan);
            if (d != null)
            {
                d.nhiemvu = PhanCongupdate.nhiemvu;
            }
            DB.SaveChanges();
        }
    }
}