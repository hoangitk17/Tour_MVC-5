using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tour_du_lich.Models
{
    public class ChiTietDoanModel
    {
        public string madoan { get; set; }
        public string makh { get; set; }
        public String mota { get; set; }

        public ChiTietDoanModel()
        {

        }
        public ChiTietDoanModel(string madoan, string makh, String mota)
        {
            this.madoan = madoan;
            this.makh = makh;
            this.mota = mota;
        }
        public ChiTietDoanModel(ChiTietDoanModel ct)
        {
            this.madoan = ct.madoan;
            this.makh = ct.makh;
            this.mota = ct.mota;
        }
    }
}