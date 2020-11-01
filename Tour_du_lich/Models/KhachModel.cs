using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tour_du_lich.Models
{
    public class KhachModel
    {
        public string makh { get; set; }
        public string tenkh { get; set; }
        public string diachi { get; set; }
        public string sdt { get; set; }
        public string gioitinh { get; set; }
        public string cmnd { get; set; }


        public KhachModel()
        {

        }

        public KhachModel(String makh, String tenkh, String diachi, String sdt, String gioitinh, String cmnd)
        {
            this.makh = makh;
            this.tenkh = tenkh;
            this.diachi = diachi;
            this.sdt = sdt;
            this.gioitinh = gioitinh;
            this.cmnd = cmnd;
        }
        public KhachModel(KhachModel Khach)
        {
            this.makh = Khach.makh;
            this.tenkh = Khach.tenkh;
            this.diachi = Khach.diachi;
            this.sdt = Khach.sdt;
            this.gioitinh = Khach.gioitinh;
            this.cmnd = Khach.cmnd;
        }
    }
}