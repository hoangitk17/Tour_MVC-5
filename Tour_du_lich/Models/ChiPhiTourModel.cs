using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tour_du_lich.Models
{
    public class ChiPhiTourModel
    {
        public String matour { get; set; }
        public String madoan { get; set; }
        public String machiphi { get; set; }
        public Nullable<double> gia { get; set; }
        public Nullable<System.DateTime> ngaybatdau { get; set; }
        public Nullable<System.DateTime> ngayketthuc { get; set; }


        public ChiPhiTourModel()
        {

        }

        public ChiPhiTourModel(String matour, String madoan, String machiphi, Nullable<double> gia, Nullable<System.DateTime> ngaybatdau, Nullable<System.DateTime> ngayketthuc )
        {
            this.madoan = madoan;
            this.matour = matour;
            this.machiphi = machiphi;
            this.gia = gia;
            this.ngaybatdau = ngaybatdau;
            this.ngayketthuc = ngayketthuc;
        }
        public ChiPhiTourModel(ChiPhiTourModel ChiPhiTour)
        {
            this.madoan = ChiPhiTour.madoan;
            this.matour = ChiPhiTour.matour;
            this.machiphi = ChiPhiTour.machiphi;
            this.gia = ChiPhiTour.gia;
            this.ngaybatdau = ChiPhiTour.ngaybatdau;
            this.ngayketthuc = ChiPhiTour.ngayketthuc;
        }
    }
}