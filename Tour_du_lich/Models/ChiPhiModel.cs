using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tour_du_lich.Models
{
    public class ChiPhiModel
    {
        public String machiphi { get; set; }
        public String maloaichiphi { get; set; }
        public String madoan { get; set; }
        public Nullable<double> giathanh { get; set; }

        public String ghichu { get; set; }

        public ChiPhiModel()
        {

        }

        public ChiPhiModel(String machiphi, String maloaichiphi, String madoan, Nullable<double> giathanh, String ghichu)
        {
            this.maloaichiphi = maloaichiphi;
            this.giathanh = giathanh;
            this.machiphi = machiphi;
            this.madoan = madoan;
            this.ghichu = ghichu;
        }
        public ChiPhiModel(ChiPhiModel ChiPhi)
        {
            this.maloaichiphi = ChiPhi.maloaichiphi;
            this.giathanh = ChiPhi.giathanh;
            this.machiphi = ChiPhi.machiphi;
            this.madoan = ChiPhi.madoan;
            this.ghichu = ChiPhi.ghichu;
        }
    }
}