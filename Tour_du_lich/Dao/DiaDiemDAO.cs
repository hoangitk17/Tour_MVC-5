using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Tour_du_lich.Models;

namespace Tour_du_lich.Dao
{
    public class DiaDiemDao
    {
        DBTOUREntities DB = new DBTOUREntities();

        public List<DiaDiemModel> GetAllDiaDiem()
        {
            DB.Configuration.ProxyCreationEnabled = false;
            List<DiaDiemModel> result = new List<DiaDiemModel>();
            foreach (diadiem temp in DB.diadiems)
            {
                DiaDiemModel dd = new DiaDiemModel(temp.madiadiem, temp.tendiadiem);
                result.Add(dd);
            }

            return result;
        }

        public DiaDiemModel GetDiaDiem(string id)
        {
            diadiem temp = DB.diadiems.SingleOrDefault(dd => dd.madiadiem == id);
            DiaDiemModel diadiem = new DiaDiemModel();
            if (temp != null)
            {
                diadiem.madiadiem = temp.madiadiem;
                diadiem.tendiadiem = temp.tendiadiem;
            }

            return diadiem;
        }
        public void AddDiaDiem(DiaDiemModel diadiem)
        {
            try
            {
                diadiem data = new diadiem() ;
                data.madiadiem = diadiem.madiadiem;
                data.tendiadiem = diadiem.tendiadiem;
                DB.diadiems.Add(data);
                DB.SaveChanges();
            }
            catch (Exception e)
            {
                
            }
        }

        public bool ExistId(string id)
        {
            var dd = DB.diadiems.SingleOrDefault(x => x.madiadiem == id);
            if (dd == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Delete(string id)
        {
            diadiem d = DB.diadiems.SingleOrDefault(loaitour => loaitour.madiadiem == id);
            if (d != null)
            {
                DB.diadiems.Remove(d);
            }
            DB.SaveChanges();
        }

        public bool ExistIdInAnotherTable(string id)
        {
            DB.Configuration.ProxyCreationEnabled = false;
            var cttour = DB.cttours.FirstOrDefault(x => x.madiadiem == id);
            if (cttour != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Edit(DiaDiemModel editedDiaDiem)
        {
            diadiem d = DB.diadiems.SingleOrDefault(diadiem => diadiem.madiadiem == editedDiaDiem.madiadiem);
            if (d != null)
            {
                d.tendiadiem = editedDiaDiem.tendiadiem;
            }
            DB.SaveChanges();
        }

    }
}