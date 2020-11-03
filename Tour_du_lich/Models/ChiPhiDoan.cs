using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tour_du_lich.Models
{
    public class ChiPhiDoanModel
    {
        public String madoan { get; set; }
        public String tenchiphi { get; set; }

        public Nullable<double> gia { get; set; }
        public Nullable<System.DateTime> ngaybatdau { get; set; }
        public Nullable<System.DateTime> ngayketthuc { get; set; }


        public ChiPhiDoanModel()
        {

        }

        public ChiPhiDoanModel(String madoan, String tenchiphi, Nullable<double> gia, Nullable<System.DateTime> ngaybatdau, Nullable<System.DateTime> ngayketthuc )
        {
            this.madoan = madoan;
            this.tenchiphi = tenchiphi;
            this.gia = gia;
            this.ngaybatdau = ngaybatdau;
            this.ngayketthuc = ngayketthuc;
        }
        public ChiPhiDoanModel(ChiPhiDoanModel ChiPhiDoan)
        {
            this.madoan = ChiPhiDoan.madoan;
            this.tenchiphi = ChiPhiDoan.tenchiphi;
            this.gia = ChiPhiDoan.gia;
            this.ngaybatdau = ChiPhiDoan.ngaybatdau;
            this.ngayketthuc = ChiPhiDoan.ngayketthuc;
        }
    }
}