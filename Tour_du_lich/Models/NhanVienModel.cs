using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tour_du_lich.Models
{
    public class NhanVienModel
    {
        public string manv { get; set; }
        public string tennv { get; set; }

        public string diachi { get; set; }

        public NhanVienModel()
        {

        }

        public NhanVienModel(String manv, String tennv, String diachi)
        {
            this.manv = manv;
            this.tennv = tennv;
            this.diachi = diachi;
        }
        public NhanVienModel(NhanVienModel nhanvien)
        {
            this.manv = nhanvien.manv;
            this.tennv = nhanvien.tennv;
            this.diachi = nhanvien.diachi;
        }
    }
}