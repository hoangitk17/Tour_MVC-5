using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Tour_du_lich.Models;

namespace Tour_du_lich.Dao
{
    public class DiaDiemDAO
    {
        DBTOUREntities DB = new DBTOUREntities();
        public void AddDiaDiem(diadiem d)
        {
            DB.diadiems.Add(d);
            DB.SaveChanges();
        }

        public bool ExistId(String id)
        {
           var dd =  DB.diadiems.SingleOrDefault(x => x.madiadiem == id);
            if(dd == null)
            {
                return false;
            } else
            {
                return true;
            }
        }

        public List<diadiem> GetDiaDiem()
        {
            DB.Configuration.ProxyCreationEnabled = false;
            return DB.diadiems.ToList();
        }

        public void Delete(String id)
        {
            diadiem d = DB.diadiems.SingleOrDefault(diadiem => diadiem.madiadiem == id);
            if(d != null)
            {
                DB.diadiems.Remove(d);
            }
            DB.SaveChanges();
        }

    }
}