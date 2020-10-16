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
        public bool Update(gia g)
        {
            try
            {
                var gia = DBTOUR.gias.Find(g.magia);
                gia.giatien = g.giatien;
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

        public bool Delete(string id)
        {
            try
            {
                var gia = DBTOUR.gias.Find(id);
                DBTOUR.gias.Remove(gia);
                DBTOUR.SaveChanges();
                return true;
            }catch(Exception)
            {
                return false;
            }
        }

    }
}