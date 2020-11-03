using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tour_du_lich.Models;

namespace Tour_du_lich.Dao
{
    public class DoanDao
    {
        DBTOUREntities DB = new DBTOUREntities();
        public List<DoanModel> GetAllDoan()
        {
            DB.Configuration.ProxyCreationEnabled = false;
            List<DoanModel> result = new List<DoanModel>();
            foreach (doan temp in DB.doans)
            {
                DoanModel cost = new DoanModel(temp.madoan, temp.matour, temp.ngaybatdau, temp.ngayketthuc);
                result.Add(cost);
            }

            return result;
        }
        public bool Update(DoanModel g)
        {
            try
            {
                var Doan = DB.doans.Find(g.madoan);
                Doan.matour = g.matour;
                Doan.ngaybatdau = g.ngaybatdau;
                Doan.ngayketthuc = g.ngayketthuc;
                DB.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public DoanModel GetDoan(string id)
        {
            doan temp = DB.doans.SingleOrDefault(d => d.madoan == id);
            List<KhachModel> khachs = (from ct in DB.ctdoans
                                           join kh in DB.khachhangs
                                           on ct.makh equals kh.makh
                                       where ct.madoan == id
                                       select new KhachModel()
                                           {
                                               makh = ct.makh,
                                               tenkh = kh.tenkh
                                           }).ToList();
            DoanModel g = new DoanModel();
            if (temp != null)
            {
                g.madoan = temp.madoan;
                g.matour = temp.matour;
                g.ngaybatdau = temp.ngaybatdau;
                g.ngayketthuc = temp.ngayketthuc;
                g.khachs = khachs;
            }

            return g;
        }

        public bool Delete(string id)
        {
            try
            {
                var Doan = DB.doans.Find(id);
                DB.doans.Remove(Doan);
                DB.SaveChanges();
                return true;
            }catch(Exception)
            {
                return false;
            }
        }

        public bool ExistId(string id)
        {
            var dd = DB.doans.SingleOrDefault(x => x.madoan == id);
            if (dd == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void AddDoan(DoanModel Doan)
        {
            try
            {
                doan data = new doan();
                data.madoan = Doan.madoan;
                data.matour = Doan.matour;
                data.ngaybatdau = Doan.ngaybatdau;
                data.ngayketthuc = Doan.ngayketthuc;

                DB.doans.Add(data);
                DB.SaveChanges();
                if (Doan.khachs != null)
                {
                    foreach (KhachModel khach in Doan.khachs)
                    {
                        ctdoan ct = new ctdoan();
                        ct.makh = khach.makh;
                        ct.madoan = Doan.madoan;

                        DB.ctdoans.Add(ct);
                        DB.SaveChanges();

                    }
                }
               
            }
            catch (Exception e)
            {
                
            }
        }
    }
}