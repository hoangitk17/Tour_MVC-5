using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tour_du_lich.Models
{
    public class PhanCongModel
    {
        public string madoan { get; set; }
        public string manv { get; set; }

        public string nhiemvu { get; set; }

        public PhanCongModel()
        {

        }

        public PhanCongModel(String madoan, String manv, String nhiemvu)
        {
            this.manv = manv;
            this.madoan = madoan;
            this.nhiemvu = nhiemvu;
        }
        public PhanCongModel(PhanCongModel PhanCong)
        {
            this.manv = PhanCong.manv;
            this.madoan = PhanCong.madoan;
            this.nhiemvu = PhanCong.nhiemvu;
        }
    }
}