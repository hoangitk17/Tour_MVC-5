using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tour_du_lich.Models;

namespace Tour_du_lich.Dao
{
    public class ChiTietTourDao
    {
        
        DBTOUREntities DB = new DBTOUREntities();
           
        public List<ChiTietTourModel> GetAllChiTietTour()
        {
            DB.Configuration.ProxyCreationEnabled = false;
            List<ChiTietTourModel> result = new List<ChiTietTourModel>();

            foreach (cttour temp in DB.cttours)
            {
                ChiTietTourModel ChiTietTour = new ChiTietTourModel(temp.matour, temp.madiadiem, temp.thutu);
                result.Add(ChiTietTour);
            }

            return result;
        }

        public ChiTietTourModel GetChiTietTourById(string matour, string madiadiem)
        {
            cttour temp = DB.cttours.SingleOrDefault(ChiTietTour => ChiTietTour.matour == matour && ChiTietTour.madiadiem == madiadiem);
            ChiTietTourModel ChiTietTour1 = new ChiTietTourModel();
            if (temp != null)
            {
                ChiTietTour1.matour = temp.matour;
                ChiTietTour1.madiadiem = temp.madiadiem;
                ChiTietTour1.thutu = temp.thutu;
            }

            return ChiTietTour1;
        }
        public void AddChiTietTour(ChiTietTourModel ChiTietTour)
        {
            try
            {
                cttour data = new cttour();
                data.matour = ChiTietTour.matour;
                data.madiadiem = ChiTietTour.madiadiem;
                data.thutu = ChiTietTour.thutu;
                DB.cttours.Add(data);
                DB.SaveChanges();
            }
            catch (Exception e)
            {

            }
        }

        public bool ExistId(string matour, string madiadiem)
        {
            var dd = DB.cttours.SingleOrDefault(x => x.matour == matour && x.madiadiem == madiadiem);
            if (dd == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Delete(string matour, string madiadiem)
        {
            cttour d = DB.cttours.SingleOrDefault(ChiTietTour => ChiTietTour.matour == matour && ChiTietTour.madiadiem == madiadiem);
            if (d != null)
            {
                DB.cttours.Remove(d);
            }
            DB.SaveChanges();
        }

        public void Update(ChiTietTourModel ChiTietTourupdate)
        {
            cttour d = DB.cttours.SingleOrDefault(ChiTietTour => ChiTietTour.matour == ChiTietTourupdate.matour && ChiTietTour.madiadiem == ChiTietTourupdate.madiadiem);
            if (d != null)
            {
                d.thutu = ChiTietTourupdate.thutu;
            }
            DB.SaveChanges();
        }
    }
}