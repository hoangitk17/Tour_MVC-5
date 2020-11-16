using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tour_du_lich.Models
{
    public class DoanModel
    {
        public String madoan { get; set; }
        public String tendoan { get; set; }
        public String matour { get; set; }
        public Nullable<System.DateTime> ngaybatdau { get; set; }
        public Nullable<System.DateTime> ngayketthuc { get; set; }
        public List<KhachModel> khachs { get; set; }


        public DoanModel()
        {

        }

        public DoanModel(String madoan, String tendoan, String matour, Nullable<System.DateTime> ngaybatdau, Nullable<System.DateTime> ngayketthuc )
        {
            this.madoan = madoan;
            this.tendoan = tendoan;
            this.matour = matour;
            this.matour = matour;
            this.ngaybatdau = ngaybatdau;
            this.ngayketthuc = ngayketthuc;
        }

        public DoanModel(String madoan, String tendoan, String matour, Nullable<System.DateTime> ngaybatdau, Nullable<System.DateTime> ngayketthuc, List<KhachModel> khachs)
        {
            this.madoan = madoan;
            this.tendoan = tendoan;
            this.matour = matour;
            this.ngaybatdau = ngaybatdau;
            this.ngayketthuc = ngayketthuc;
            this.khachs = khachs;
        }
        public DoanModel(DoanModel Doan)
        {
            this.madoan = Doan.madoan;
            this.tendoan = Doan.tendoan;
            this.matour = Doan.matour;
            this.ngaybatdau = Doan.ngaybatdau;
            this.ngayketthuc = Doan.ngayketthuc;
        }
    }
}