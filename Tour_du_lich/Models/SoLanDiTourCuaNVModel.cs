using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tour_du_lich.Models
{
    public class SoLanDiTourCuaNVModel
    {
        public String matour { get; set; }
        public String madoan { get; set; }
        public String tennv { get; set; }
        public String nhiemvu { get; set; }

        public Nullable<System.DateTime> ngaybatdau { get; set; }
        public Nullable<System.DateTime> ngayketthuc { get; set; }

        public SoLanDiTourCuaNVModel()
        {

        }

        public SoLanDiTourCuaNVModel(String matour,String madoan, String tennv, String nhiemvu, Nullable<System.DateTime> ngaybatdau, Nullable<System.DateTime> ngayketthuc )
        {
            this.madoan = madoan;
            this.matour = matour;
            this.tennv = tennv;
            this.nhiemvu = nhiemvu;
            this.ngaybatdau = ngaybatdau;
            this.ngayketthuc = ngayketthuc;
        }
        public SoLanDiTourCuaNVModel(SoLanDiTourCuaNVModel SoLanDiTourCuaNV)
        {
            this.madoan = SoLanDiTourCuaNV.madoan;
            this.matour = SoLanDiTourCuaNV.matour;
            this.tennv = SoLanDiTourCuaNV.tennv;
            this.nhiemvu = SoLanDiTourCuaNV.nhiemvu;
            this.ngaybatdau = SoLanDiTourCuaNV.ngaybatdau;
            this.ngayketthuc = SoLanDiTourCuaNV.ngayketthuc;
        }
    }
}