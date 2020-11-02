using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tour_du_lich.Models;

namespace Tour_du_lich.Dao
{
    public class GiaDao
    {
        DBTOUREntities DB = new DBTOUREntities();
        public List<GiaModel> GetAllGia()
        {
            DB.Configuration.ProxyCreationEnabled = false;
            List<GiaModel> result = new List<GiaModel>();
            foreach (gia temp in DB.gias)
            {
                GiaModel cost = new GiaModel(temp.magia, temp.matour, temp.giatien, temp.tgbd, temp.tgkt);
                result.Add(cost);
            }

            return result;
        }
        public bool Update(gia g)
        {
            try
            {
                var gia = DB.gias.Find(g.magia);
                gia.giatien = g.giatien;
                gia.tgbd = g.tgbd;
                gia.tgkt = g.tgkt;
                DB.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public GiaModel GetGia(string id)
        {
            gia temp = DB.gias.SingleOrDefault(d => d.magia == id);
            GiaModel g = new GiaModel();
            if (temp != null)
            {
                g.magia = temp.magia;
                g.matour = temp.matour;
                g.tgbd = temp.tgbd;
                g.tgkt = temp.tgkt;
                g.giatien = temp.giatien;
            }

            return g;
        }

        public bool Delete(string id)
        {
            try
            {
                var gia = DB.gias.Find(id);
                DB.gias.Remove(gia);
                DB.SaveChanges();
                return true;
            }catch(Exception)
            {
                return false;
            }
        }

        public bool ExistId(string id)
        {
            var dd = DB.gias.SingleOrDefault(x => x.magia == id);
            if (dd == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void AddGia(GiaModel gia)
        {
            try
            {
                gia data = new gia();
                data.magia = gia.magia;
                data.matour = gia.matour;
                data.giatien = gia.giatien;
                data.tgbd = gia.tgbd;
                data.tgkt = gia.tgkt;

                DB.gias.Add(data);
                DB.SaveChanges();
            }
            catch (Exception e)
            {

            }
        }
    }
}