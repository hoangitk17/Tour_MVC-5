using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tour_du_lich.Models;

namespace Tour_du_lich.Dao
{
    public class TourDao
    {
        DBTOUREntities DB = new DBTOUREntities();

        public List<TourDataModel> GetAllTour()
        {
            DB.Configuration.ProxyCreationEnabled = false;
            List<TourDataModel> result = new List<TourDataModel>();
            foreach (tour temp in DB.tours)
            {
                TourDataModel tourdata = new TourDataModel(temp.matour, temp.tentour, temp.maloai, temp.dacdiem, temp.giamacdinh);
                result.Add(tourdata);
            }

            return result;
        }

      
    }
}