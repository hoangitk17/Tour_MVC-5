using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tour_du_lich.Models
{
    public class GiaModel
    {
        public string magia { get; set; }
        public string matour { get; set; }
        public Nullable<double> giatien { get; set; }
        public Nullable<System.DateTime> tgbd { get; set; }
        public Nullable<System.DateTime> tgkt { get; set; }

        public GiaModel()
        {

        }
        public GiaModel(string magia, string matour, Nullable<double> giatien, Nullable<System.DateTime> tgbd, Nullable<System.DateTime> tgkt)
        {
            this.magia = magia;
            this.matour = matour;
            this.giatien = giatien;
            this.tgbd = tgbd;
            this.tgkt = tgkt;
        }
    }
}