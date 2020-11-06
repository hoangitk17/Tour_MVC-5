﻿using System;
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

        public List<DoanhThuDoanModel> GetDoanhThuDoan(String madoan)
        {
            DB.Configuration.ProxyCreationEnabled = false;
            List<DoanhThuDoanModel> result = new List<DoanhThuDoanModel>();
            var quantity_khach_hang = (from ct in DB.ctdoans where ct.madoan == madoan
                                       select madoan).Count();
                List<DoanhThuDoanModel> doanhthudoan = (from ct in DB.ctdoans
                                               join d in DB.doans
                                               on ct.madoan equals d.madoan
                                               join t in DB.tours
                                               on d.matour equals t.matour
                                               where d.madoan == madoan
                                               orderby d.madoan ascending
                                               select new DoanhThuDoanModel()
                                               {
                                                   madoan = ct.madoan,
                                                   matour = t.matour,
                                                   makh = ct.makh,
                                                   gia = t.giamacdinh,
                                                   ngaybatdau = d.ngaybatdau,
                                                   ngayketthuc = d.ngayketthuc,
                                               }).ToList();

                //DoanhThuDoanModel DoanhThuDoan = new DoanhThuDoanModel(temp.madoan, temp.tenchiphi, temp.gia, temp.ngaybatdau, temp.ngayketthuc);
                //result.Add(doanhthudoan);
                //return result;
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
                //ctdoan ct = new ctdoan();
                //ct.makh = "KH003";
                //ct.madoan = "MD054";

                //DB.ctdoans.Add(ct);
                //DB.SaveChanges();
               



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