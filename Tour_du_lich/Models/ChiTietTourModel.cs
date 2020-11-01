using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tour_du_lich.Models
{
    public class ChiTietTourModel
    {
        public string matour { get; set; }
        public string madiadiem { get; set; }
        public Nullable<int> thutu { get; set; }

        public ChiTietTourModel()
        {

        }
        public ChiTietTourModel(string matour, string madiadiem, int thutu)
        {
            this.matour = matour;
            this.madiadiem = madiadiem;
            this.thutu = thutu;
        }
        public ChiTietTourModel(cttour ct)
        {
            this.matour = ct.matour;
            this.madiadiem = ct.madiadiem;
            this.thutu = ct.thutu;
        }
    }
}