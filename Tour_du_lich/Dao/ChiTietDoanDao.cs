using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tour_du_lich.Models;

namespace Tour_du_lich.Dao
{
    public class ChiTietDoanDao
    {

        DBTOUREntities DB = new DBTOUREntities();

        public List<ChiTietDoanModel> GetAllChiTietDoan()
        {
            DB.Configuration.ProxyCreationEnabled = false;
            List<ChiTietDoanModel> result = new List<ChiTietDoanModel>();

            foreach (ctdoan temp in DB.ctdoans)
            {
                ChiTietDoanModel ChiTietDoan = new ChiTietDoanModel(temp.madoan, temp.makh, temp.mota);
                result.Add(ChiTietDoan);
            }

            return result;
        }

        public ChiTietDoanModel GetChiTietDoanById(string madoan, string makh)
        {
            ctdoan temp = DB.ctdoans.SingleOrDefault(ChiTietDoan => ChiTietDoan.madoan == madoan && ChiTietDoan.makh == makh);
            ChiTietDoanModel ChiTietDoan1 = new ChiTietDoanModel();
            if (temp != null)
            {
                ChiTietDoan1.madoan = temp.madoan;
                ChiTietDoan1.makh = temp.makh;
                ChiTietDoan1.mota = temp.mota;
            }

            return ChiTietDoan1;
        }
        public void AddChiTietDoan(ChiTietDoanModel ChiTietDoan)
        {
            try
            {
                ctdoan data = new ctdoan();
                data.madoan = ChiTietDoan.madoan;
                data.makh = ChiTietDoan.makh;
                data.mota = ChiTietDoan.mota;
                DB.ctdoans.Add(data);
                DB.SaveChanges();
            }
            catch (Exception e)
            {

            }
        }

        public bool ExistId(string madoan, string makh)
        {
            var dd = DB.ctdoans.SingleOrDefault(x => x.madoan == madoan && x.makh == makh);
            if (dd == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Delete(string madoan, string makh)
        {
            ctdoan d = DB.ctdoans.SingleOrDefault(ChiTietDoan => ChiTietDoan.madoan == madoan && ChiTietDoan.makh == makh);
            if (d != null)
            {
                DB.ctdoans.Remove(d);
            }
            DB.SaveChanges();
        }

        public void Update(ChiTietDoanModel ChiTietDoanupdate)
        {
            ctdoan d = DB.ctdoans.SingleOrDefault(ChiTietDoan => ChiTietDoan.madoan == ChiTietDoanupdate.madoan && ChiTietDoan.makh == ChiTietDoanupdate.makh);
            if (d != null)
            {
                d.mota = ChiTietDoanupdate.mota;
            }
            DB.SaveChanges();
        }
    }
}