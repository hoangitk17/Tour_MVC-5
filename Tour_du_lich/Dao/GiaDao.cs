using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tour_du_lich.Models;

namespace Tour_du_lich.Dao
{
    public class GiaDao
    {
        DBTOUREntities DBTOUR = new DBTOUREntities();
        public bool Update(string id, double giatien)
        {
            try
            {
                var gia = DBTOUR.gias.Find(id);
                gia.giatien = giatien;
                DBTOUR.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public gia GetById(string id)
        {
            return DBTOUR.gias.SingleOrDefault(x => x.magia == id);
        }
    }
}