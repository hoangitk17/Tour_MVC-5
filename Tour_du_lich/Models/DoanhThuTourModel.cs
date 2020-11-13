using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tour_du_lich.Models
{
    public class DoanhThuTourModel
    {
        public String matour { get; set; }
        public String tentour { get; set; }
        public String madoan { get; set; }
        public String makhach { get; set; }

        public Nullable<double> gia { get; set; }
        public Nullable<System.DateTime> ngaybatdau { get; set; }
        public Nullable<System.DateTime> ngayketthuc { get; set; }


        public DoanhThuTourModel()
        {

        }

        public DoanhThuTourModel(String matour, String tentour, String madoan, String makhach, Nullable<double> gia, Nullable<System.DateTime> ngaybatdau, Nullable<System.DateTime> ngayketthuc )
        {
            this.madoan = madoan;
            this.matour = matour;
            this.tentour = tentour;
            this.makhach = makhach;
            this.gia = gia;
            this.ngaybatdau = ngaybatdau;
            this.ngayketthuc = ngayketthuc;
        }
        public DoanhThuTourModel(DoanhThuTourModel DoanhThuTour)
        {
            this.madoan = DoanhThuTour.madoan;
            this.matour = DoanhThuTour.matour;
            this.tentour = DoanhThuTour.tentour;
            this.makhach = DoanhThuTour.makhach;
            this.gia = DoanhThuTour.gia;
            this.ngaybatdau = DoanhThuTour.ngaybatdau;
            this.ngayketthuc = DoanhThuTour.ngayketthuc;
        }
    }
}