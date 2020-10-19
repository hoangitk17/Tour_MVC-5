using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tour_du_lich.Models
{
    public class LoaiTourModel
    {
        public string maloai { get; set; }
        public string tenloai { get; set; }

        public LoaiTourModel()
        {

        }

        public LoaiTourModel(String maloai, String tenloai)
        {
            this.maloai = maloai;
            this.tenloai = tenloai;
        }
        public LoaiTourModel(LoaiTourModel loaiTour)
        {
            this.maloai = loaiTour.maloai;
            this.tenloai = loaiTour.tenloai;
        }
    }
}