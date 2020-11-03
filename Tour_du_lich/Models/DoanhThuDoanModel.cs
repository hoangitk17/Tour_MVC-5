using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tour_du_lich.Models
{
    public class DoanhThuDoanModel
    {
        public String madoan { get; set; }
        public String makh { get; set; }
        public String matour { get; set; }

        public Nullable<double> gia { get; set; }
        public Nullable<System.DateTime> ngaybatdau { get; set; }
        public Nullable<System.DateTime> ngayketthuc { get; set; }

        public int quantity_khach { get; set; }

        public DoanhThuDoanModel()
        {

        }

        public DoanhThuDoanModel(String madoan, String makh, String matour, Nullable<double> gia, Nullable<System.DateTime> ngaybatdau, Nullable<System.DateTime> ngayketthuc )
        {
            this.madoan = madoan;
            this.matour = matour;
            this.makh = makh;
            this.gia = gia;
            this.ngaybatdau = ngaybatdau;
            this.ngayketthuc = ngayketthuc;
        }
        public DoanhThuDoanModel(DoanhThuDoanModel DoanhThuDoan)
        {
            this.madoan = DoanhThuDoan.madoan;
            this.matour = DoanhThuDoan.matour;
            this.makh = DoanhThuDoan.makh;
            this.gia = DoanhThuDoan.gia;
            this.ngaybatdau = DoanhThuDoan.ngaybatdau;
            this.ngayketthuc = DoanhThuDoan.ngayketthuc;
        }
    }
}