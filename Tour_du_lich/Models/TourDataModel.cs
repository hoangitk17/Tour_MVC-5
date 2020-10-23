using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tour_du_lich.Models
{
    public class TourDataModel
    {
        public string matour { get; set; }
        public string tentour { get; set; }
        public string maloai { get; set; }
        public string dacdiem { get; set; }
        public Nullable<double> giamacdinh { get; set; }

        public TourDataModel()
        {

        }
        public TourDataModel(string matour, String tentour, String maloai, string dacdiem, Nullable<double> giamacdinh)
        {
            this.matour = matour;
            this.maloai = maloai;
            this.tentour = tentour;
            this.dacdiem = dacdiem;
            this.giamacdinh = giamacdinh;
        }
    }
}