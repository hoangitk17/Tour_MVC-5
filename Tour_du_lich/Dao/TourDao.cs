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
                DB.tours.Add(data);
                int thutu = 1;
                foreach(DiaDiemModel dd in insertTour.diadiems)
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
            List<cttour> ct = DB.cttours.Where(c => c.matour == id).ToList();
            if(ct != null)
            {
                foreach(cttour temp in ct)
                {
                    DB.cttours.Remove(temp);
                }
            }
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
            if (gia != null || doan != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int CountQuantityCustomer(String id_doan)
        {
            int count = (from x in DB.ctdoans where x.madoan == id_doan select x).Count();
            return count;
        }

        public double TotalTour(List<DoanhThuTourModel> arr)
        {
            double result = 0;
            foreach (DoanhThuTourModel d in arr)
            {
                result = result + Convert.ToDouble(d.gia * d.slkhach);
            }
            return result;

        }

        public List<DoanhThuTourModel> GetDoanhThuTour(String id_tour, DateTime thoigianbatdau, DateTime thoigianketthuc)
        {
            DB.Configuration.ProxyCreationEnabled = false;
            List<DoanhThuTourModel> doanhthutour = (from d in DB.doans
                                                    join t in DB.tours
                                                    on d.matour equals t.matour
                                                    where t.matour == id_tour && d.ngaybatdau >= thoigianbatdau && d.ngayketthuc <= thoigianketthuc
                                                    orderby t.matour ascending
                                                    select new DoanhThuTourModel()
                                                    {
                                                        madoan = d.madoan,
                                                        matour = t.matour,
                                                        tentour = t.tentour,
                                                        slkhach = CountQuantityCustomer(d.madoan),
                                                        gia = t.giamacdinh,
                                                        ngaybatdau = d.ngaybatdau,
                                                        ngayketthuc = d.ngayketthuc,
                                                    }).ToList();
            return doanhthutour;
        }
    }
}