using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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

        public List<DoanhThuDoanModel> GetDoanhThuDoan(String id_doan, DateTime thoigianbatdau, DateTime thoigianketthuc)
        {
            DB.Configuration.ProxyCreationEnabled = false;
            List<DoanhThuDoanModel> doanhthudoan = (from ct in DB.ctdoans
                                            join d in DB.doans
                                            on ct.madoan equals d.madoan
                                            join t in DB.tours
                                            on d.matour equals t.matour
                                            where d.madoan == id_doan && d.ngaybatdau >= thoigianbatdau && d.ngayketthuc <= thoigianketthuc
                                            orderby d.madoan ascending
                                            select new DoanhThuDoanModel()
                                            {
                                                madoan = d.madoan,
                                                matour = t.matour,
                                                makh = ct.makh,
                                                gia = t.giamacdinh,
                                                ngaybatdau = d.ngaybatdau,
                                                ngayketthuc = d.ngayketthuc,
                                            }).ToList();
            return doanhthudoan;
        }
        public bool Update(DoanModel g)
        {
            try
            {
                var Doan = DB.doans.Find(g.madoan);
                Doan.matour = g.matour;
                Doan.ngaybatdau = g.ngaybatdau;
                Doan.ngayketthuc = g.ngayketthuc;

                DB.ctdoans.RemoveRange(DB.ctdoans.Where(x => x.madoan == Doan.madoan));
                foreach (KhachModel k in g.khachs)
                {
                    ctdoan ct = new ctdoan()
                    {
                        madoan = Doan.madoan,
                        makh = k.makh,
                    };
                    DB.ctdoans.Add(ct);
      

                }
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

        public List<KhachModel> GetCustomer(string id)
        {
            List<KhachModel> khachs = (from ct in DB.ctdoans
                                       join kh in DB.khachhangs
                                       on ct.makh equals kh.makh
                                       where ct.madoan == id
                                       select new KhachModel()
                                       {
                                           makh = ct.makh,
                                           tenkh = kh.tenkh
                                       }).ToList();
           
            return khachs;
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
            }
            catch (Exception e)
            {
                
            }
        }

        public void addKhachChoDoan(List<KhachModel> arrayKhachs, string madoan)
        {
            try
            {
                var doanForInsert = DB.doans.SingleOrDefault(x => x.madoan == madoan);
                if (arrayKhachs != null)
                {
                    foreach (KhachModel k in arrayKhachs)
                    {
                        ctdoan ct = new ctdoan();
                        ct.makh = k.makh.ToString();
                        ct.madoan = madoan.ToString();

                        DB.ctdoans.AddOrUpdate(ct);
                        

                    }
                }
                DB.SaveChanges();

            }
            catch (Exception e)
            {

            }

        }
    }
}