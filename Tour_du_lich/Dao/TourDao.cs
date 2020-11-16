﻿using System;
using System.Collections;
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
                List<DiaDiemModel> diadiems = (from ct in DB.cttours
                                               join d in DB.diadiems
                                               on ct.madiadiem equals d.madiadiem
                                               where ct.matour == temp.matour
                                               orderby ct.thutu ascending
                                               select new DiaDiemModel()
                                               {
                                                   madiadiem = ct.madiadiem,
                                                   tendiadiem = d.tendiadiem,
                                               }).ToList();

                TourDataModel tourdata = new TourDataModel(temp.matour, temp.tentour, temp.maloai, temp.dacdiem, temp.giamacdinh, diadiems);
                result.Add(tourdata);
            }

            return result;
        }

        public ArrayList GetAllMaTour()
        {
            DB.Configuration.ProxyCreationEnabled = false;
            ArrayList result = new ArrayList();
            foreach (tour temp in DB.tours)
            {
                String matour = temp.matour;
                result.Add(matour);
            }
            return result;
        }

        public TourDataModel GetTour(string id)
        {
            tour temp = DB.tours.SingleOrDefault(t => t.matour == id);
            List<DiaDiemModel> diadiems = (from ct in DB.cttours
                                           join d in DB.diadiems
                                           on ct.madiadiem equals d.madiadiem
                                           where ct.matour == id
                                           orderby ct.thutu ascending
                                           select new DiaDiemModel()
                                           {
                                               madiadiem = ct.madiadiem,
                                               tendiadiem = d.tendiadiem,
                                           }).ToList();
            TourDataModel tour = new TourDataModel();
            if (temp != null)
            {
                tour.matour = temp.matour;
                tour.maloai = temp.maloai;
                tour.dacdiem = temp.dacdiem;
                tour.tentour = temp.tentour;
                tour.giamacdinh = temp.giamacdinh;
                tour.diadiems = diadiems;
            }

            return tour;
        }

        public void AddTour(TourDataModel insertTour)
        {
            try
            {
                tour data = new tour();
                data.matour = insertTour.matour;
                data.maloai = insertTour.maloai;
                data.dacdiem = insertTour.dacdiem;
                data.tentour = insertTour.tentour;
                data.giamacdinh = insertTour.giamacdinh;
                DB.tours.Add(data);
                int thutu = 1;
                foreach (DiaDiemModel dd in insertTour.diadiems)
                {
                    cttour ct = new cttour()
                    {
                        matour = data.matour,
                        madiadiem = dd.madiadiem,
                        thutu = thutu,
                    };
                    DB.cttours.Add(ct);
                    thutu++;

                }

                DB.SaveChanges();
            }
            catch (Exception e)
            {

            }
        }


        public void Delete(string id)
        {
            //List<cttour> ct = DB.cttours.Where(c => c.matour == id).ToList();
            //if (ct != null)
            //{
            //    foreach (cttour temp in ct)
            //    {
            //        DB.cttours.Remove(temp);
            //    }
            //}

            tour d = DB.tours.SingleOrDefault(tour => tour.matour == id);
            if (d != null)
            {
                DB.tours.Remove(d);
            }
            DB.SaveChanges();
 
        }

        public void EditTour(TourDataModel tourEdited)
        {
            tour t = DB.tours.SingleOrDefault(tour => tour.matour == tourEdited.matour);
            if (t != null)
            {
                t.tentour = tourEdited.tentour;
                t.maloai = tourEdited.maloai;
                t.dacdiem = tourEdited.dacdiem;
            }
            DB.cttours.RemoveRange(DB.cttours.Where(x => x.matour == tourEdited.matour));

            int thutu = 1;
            foreach (DiaDiemModel dd in tourEdited.diadiems)
            {
                cttour ct = new cttour()
                {
                    matour = tourEdited.matour,
                    madiadiem = dd.madiadiem,
                    thutu = thutu,
                };
                DB.cttours.Add(ct);
                thutu++;

            }
            DB.SaveChanges();
        }

        public bool ExistId(string id)
        {
            var t = DB.tours.SingleOrDefault(x => x.matour == id);
            if (t == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool ExistIdInAnotherTable(string id)
        {
            var gia = DB.gias.SingleOrDefault(x => x.matour == id);
            var doan = DB.doans.SingleOrDefault(x => x.matour == id);
            var exists_ma_tour_ct = DB.cttours.SingleOrDefault(x => x.matour == id);
            if (gia != null || doan != null || exists_ma_tour_ct != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int SLDoanOfTour(List<DoanhThuTourModel> arr)
        {
            int result = 0;
            result = arr.Select(x => x.madoan).Distinct().Count();
            return result;
        }

        public List<DoanhThuTourModel> GetDoanhThuTour(String id_tour, DateTime thoigianbatdau, DateTime thoigianketthuc)
        {
            DB.Configuration.ProxyCreationEnabled = false;
            List<DoanhThuTourModel> doanhthutour = (from d in DB.doans
                                                    join t in DB.tours
                                                    on d.matour equals t.matour
                                                    join ct in DB.ctdoans
                                                    on d.madoan equals ct.madoan
                                                    where t.matour == id_tour && d.ngaybatdau >= thoigianbatdau && d.ngayketthuc <= thoigianketthuc
                                                    orderby t.matour ascending
                                                    select new DoanhThuTourModel()
                                                    {
                                                        madoan = d.madoan,
                                                        matour = t.matour,
                                                        tentour = t.tentour,
                                                        makhach = ct.makh,
                                                        gia = t.giamacdinh,
                                                        ngaybatdau = d.ngaybatdau,
                                                        ngayketthuc = d.ngayketthuc,
                                                    }).ToList();
            return doanhthutour;
        }

        public ArrayList DoanhThuTour6Thang()
        {
            DB.Configuration.ProxyCreationEnabled = false;
            List<DoanhThuTourModel> doanhthutour = (from d in DB.doans
                                                    join t in DB.tours
                                                    on d.matour equals t.matour
                                                    join ct in DB.ctdoans
                                                    on d.madoan equals ct.madoan
                                                    select new DoanhThuTourModel()
                                                    {
                                                        madoan = d.madoan,
                                                        matour = t.matour,
                                                        tentour = t.tentour,
                                                        makhach = ct.makh,
                                                        gia = t.giamacdinh,
                                                        ngaybatdau = d.ngaybatdau,
                                                        ngayketthuc = d.ngayketthuc,
                                                    }).ToList();
            ArrayList arr = new ArrayList();
            double result = 0;
            foreach (DoanhThuTourModel item in doanhthutour)
            {
                if (item.ngaybatdau.Value.Month == new DateTime(2020, 1, 1).Month && item.ngayketthuc.Value.Month == new DateTime(2020, 1, 31).Month)
                {
                    result += Convert.ToDouble(item.gia);
                }
            }
            arr.Add(result); result = 0; 
            foreach (DoanhThuTourModel item in doanhthutour)
            {
                if (item.ngaybatdau.Value.Month == new DateTime(2020, 2, 1).Month && item.ngayketthuc.Value.Month == new DateTime(2020, 2, 29).Month)
                {
                    result += Convert.ToDouble(item.gia);
                }
            }
            arr.Add(result); result = 0; 
            foreach (DoanhThuTourModel item in doanhthutour)
            {
                if (item.ngaybatdau.Value.Month == new DateTime(2020, 3, 1).Month && item.ngayketthuc.Value.Month == new DateTime(2020, 3, 31).Month)
                {
                    result += Convert.ToDouble(item.gia);
                }
            }
            arr.Add(result); result = 0; 
            foreach (DoanhThuTourModel item in doanhthutour)
            {
                if (item.ngaybatdau.Value.Month == new DateTime(2020, 4, 1).Month && item.ngayketthuc.Value.Month == new DateTime(2020, 4, 30).Month)
                {
                    result += Convert.ToDouble(item.gia);
                }
            }
            arr.Add(result); result = 0; 
            foreach (DoanhThuTourModel item in doanhthutour)
            {
                if (item.ngaybatdau.Value.Month == new DateTime(2020, 5, 1).Month && item.ngayketthuc.Value.Month == new DateTime(2020, 5, 31).Month)
                {
                    result += Convert.ToDouble(item.gia);
                }
            }
            arr.Add(result); result = 0; 
            foreach (DoanhThuTourModel item in doanhthutour)
            {
                if (item.ngaybatdau.Value.Month == new DateTime(2020, 6, 1).Month && item.ngayketthuc.Value.Month == new DateTime(2020, 6, 30).Month)
                {
                    result += Convert.ToDouble(item.gia);
                }
            }
            arr.Add(result); result = 0; 
            double max = 0;
            foreach(double a in arr)
            {
                if(a > max)
                {
                    max = a;
                }
            }
            arr.Add(max);
            return arr;
        }

        public ArrayList LoiNhuan6Thang()
        {
            DB.Configuration.ProxyCreationEnabled = false;
            List<DoanhThuTourModel> doanhthutour = (from d in DB.doans
                                                    join t in DB.tours
                                                    on d.matour equals t.matour
                                                    join ct in DB.ctdoans
                                                    on d.madoan equals ct.madoan
                                                    select new DoanhThuTourModel()
                                                    {
                                                        madoan = d.madoan,
                                                        matour = t.matour,
                                                        tentour = t.tentour,
                                                        makhach = ct.makh,
                                                        gia = t.giamacdinh,
                                                        ngaybatdau = d.ngaybatdau,
                                                        ngayketthuc = d.ngayketthuc,
                                                    }).ToList();
            List<ChiPhiTourModel> chiphitour = (from t in DB.tours
                                                join d in DB.doans
                                                on t.matour equals d.matour
                                                join cp in DB.chiphis
                                                on d.madoan equals cp.madoan
                                                select new ChiPhiTourModel()
                                                {
                                                    madoan = d.madoan,
                                                    matour = t.matour,
                                                    machiphi = cp.maloaichiphi,
                                                    gia = t.giamacdinh,
                                                    ngaybatdau = d.ngaybatdau,
                                                    ngayketthuc = d.ngayketthuc,
                                                }).ToList();
            ArrayList arr = new ArrayList();
            double result = 0;
            foreach (DoanhThuTourModel item in doanhthutour)
            {
                if (item.ngaybatdau.Value.Month == new DateTime(2020, 1, 1).Month && item.ngayketthuc.Value.Month == new DateTime(2020, 1, 31).Month)
                {
                    result += Convert.ToDouble(item.gia);
                }
            }
            foreach (ChiPhiTourModel item in chiphitour)
            {
                if (item.ngaybatdau.Value.Month == new DateTime(2020, 1, 1).Month && item.ngayketthuc.Value.Month == new DateTime(2020, 1, 31).Month)
                {
                    result -= Convert.ToDouble(item.gia);
                }
            }
            arr.Add(result); result = 0;
            foreach (DoanhThuTourModel item in doanhthutour)
            {
                if (item.ngaybatdau.Value.Month == new DateTime(2020, 2, 1).Month && item.ngayketthuc.Value.Month == new DateTime(2020, 2, 29).Month)
                {
                    result += Convert.ToDouble(item.gia);
                }
            }
            foreach (ChiPhiTourModel item in chiphitour)
            {
                if (item.ngaybatdau.Value.Month == new DateTime(2020, 2, 1).Month && item.ngayketthuc.Value.Month == new DateTime(2020, 2, 29).Month)
                {
                    result -= Convert.ToDouble(item.gia);
                }
            }
            arr.Add(result); result = 0;
            foreach (DoanhThuTourModel item in doanhthutour)
            {
                if (item.ngaybatdau.Value.Month == new DateTime(2020, 3, 1).Month && item.ngayketthuc.Value.Month == new DateTime(2020, 3, 31).Month)
                {
                    result += Convert.ToDouble(item.gia);
                }
            }
            foreach (ChiPhiTourModel item in chiphitour)
            {
                if (item.ngaybatdau.Value.Month == new DateTime(2020, 3, 1).Month && item.ngayketthuc.Value.Month == new DateTime(2020, 3, 31).Month)
                {
                    result -= Convert.ToDouble(item.gia);
                }
            }
            arr.Add(result); result = 0;
            foreach (DoanhThuTourModel item in doanhthutour)
            {
                if (item.ngaybatdau.Value.Month == new DateTime(2020, 4, 1).Month && item.ngayketthuc.Value.Month == new DateTime(2020, 4, 30).Month)
                {
                    result += Convert.ToDouble(item.gia);
                }
            }
            foreach (ChiPhiTourModel item in chiphitour)
            {
                if (item.ngaybatdau.Value.Month == new DateTime(2020, 4, 1).Month && item.ngayketthuc.Value.Month == new DateTime(2020, 4, 30).Month)
                {
                    result -= Convert.ToDouble(item.gia);
                }
            }
            arr.Add(result); result = 0;
            foreach (DoanhThuTourModel item in doanhthutour)
            {
                if (item.ngaybatdau.Value.Month == new DateTime(2020, 5, 1).Month && item.ngayketthuc.Value.Month == new DateTime(2020, 5, 31).Month)
                {
                    result += Convert.ToDouble(item.gia);
                }
            }
            foreach (ChiPhiTourModel item in chiphitour)
            {
                if (item.ngaybatdau.Value.Month == new DateTime(2020, 5, 1).Month && item.ngayketthuc.Value.Month == new DateTime(2020, 5, 31).Month)
                {
                    result -= Convert.ToDouble(item.gia);
                }
            }
            arr.Add(result); result = 0;
            foreach (DoanhThuTourModel item in doanhthutour)
            {
                if (item.ngaybatdau.Value.Month == new DateTime(2020, 6, 1).Month && item.ngayketthuc.Value.Month == new DateTime(2020, 6, 30).Month)
                {
                    result += Convert.ToDouble(item.gia);
                }
            }
            foreach (ChiPhiTourModel item in chiphitour)
            {
                if (item.ngaybatdau.Value.Month == new DateTime(2020, 6, 1).Month && item.ngayketthuc.Value.Month == new DateTime(2020, 6, 30).Month)
                {
                    result -= Convert.ToDouble(item.gia);
                }
            }
            arr.Add(result); result = 0;
            double max = 0;
            foreach (double a in arr)
            {
                if (a > max)
                {
                    max = a;
                }
            }
            arr.Add(max);
            return arr;
        }

        public double totalChiPhiTour(List<ChiPhiTourModel> arr)
        {
            double result = 0;
            foreach(ChiPhiTourModel item in arr)
            {
                result += Convert.ToDouble(item.gia);
            }
            return result;
        }
        public List<ChiPhiTourModel> GetChiPhiTour(String id_tour, DateTime thoigianbatdau, DateTime thoigianketthuc)
        {
            DB.Configuration.ProxyCreationEnabled = false;
            List<ChiPhiTourModel> chiphitour = (from t in DB.tours
                                                join d in DB.doans
                                                on t.matour equals d.matour
                                                join cp in DB.chiphis
                                                on d.madoan equals cp.madoan
                                                where t.matour == id_tour && d.ngaybatdau >= thoigianbatdau && d.ngayketthuc <= thoigianketthuc
                                                    orderby t.matour ascending
                                                    select new ChiPhiTourModel()
                                                    {
                                                        madoan = d.madoan,
                                                        matour = t.matour,
                                                        machiphi = cp.maloaichiphi,
                                                        gia = t.giamacdinh,
                                                        ngaybatdau = d.ngaybatdau,
                                                        ngayketthuc = d.ngayketthuc,
                                                    }).ToList();
            return chiphitour;
        }

        public double TongChiphi(List<ChiPhiTourModel> arr)
        {
            double result = 0;
            foreach(ChiPhiTourModel item in arr)
            {
                result += Convert.ToDouble(item.gia);
            }
            return result;

        }

        public double MaxLoiNhuanTour(ArrayList arr)
        {
            double max = 0;
            foreach (double a in arr)
            {
                if (a > max)
                {
                    max = a;
                }
            }
            return max;
        }

        public double TotalLoiNhuan(ArrayList arr)
        {
            double result = 0;
            foreach (double a in arr)
            {
                result += a;
            }
            return result;
        }
        public ArrayList LoiNhuanTour(DateTime thoigianbatdau, DateTime thoigianketthuc)
        {
            DB.Configuration.ProxyCreationEnabled = false;
            List<DoanhThuTourModel> doanhthutour = (from d in DB.doans
                                                    join t in DB.tours
                                                    on d.matour equals t.matour
                                                    join ct in DB.ctdoans
                                                    on d.madoan equals ct.madoan
                                                    where d.ngaybatdau >= thoigianbatdau && d.ngayketthuc <= thoigianketthuc
                                                    select new DoanhThuTourModel()
                                                    {
                                                        madoan = d.madoan,
                                                        matour = t.matour,
                                                        tentour = t.tentour,
                                                        makhach = ct.makh,
                                                        gia = t.giamacdinh,
                                                        ngaybatdau = d.ngaybatdau,
                                                        ngayketthuc = d.ngayketthuc,
                                                    }).ToList();
            List<ChiPhiTourModel> chiphitour = (from t in DB.tours
                                                join d in DB.doans
                                                on t.matour equals d.matour
                                                join cp in DB.chiphis
                                                on d.madoan equals cp.madoan
                                                where d.ngaybatdau >= thoigianbatdau && d.ngayketthuc <= thoigianketthuc
                                                select new ChiPhiTourModel()
                                                {
                                                    madoan = d.madoan,
                                                    matour = t.matour,
                                                    machiphi = cp.maloaichiphi,
                                                    gia = t.giamacdinh,
                                                    ngaybatdau = d.ngaybatdau,
                                                    ngayketthuc = d.ngayketthuc,
                                                }).ToList();
            ArrayList arr = new ArrayList();
            double result = 0;
            foreach(tour item in DB.tours)
            {
                foreach (DoanhThuTourModel DT in doanhthutour)
                {
                    if (DT.matour == item.matour)
                    {
                        result += Convert.ToDouble(DT.gia);
                    }
                }
                foreach (ChiPhiTourModel CP in chiphitour)
                {
                    if (CP.matour == item.matour)
                    {
                        result -= Convert.ToDouble(CP.gia);
                    }
                }
                arr.Add(result); result = 0;
            }
           
            return arr;
        }
    }
}