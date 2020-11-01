using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tour_du_lich.Models
{
    public class LoaiChiPhiModel
    {
        public string maloaichiphi { get; set; }
        public string tenloaichiphi { get; set; }

        public LoaiChiPhiModel()
        {

        }

        public LoaiChiPhiModel(String maloaichiphi, String tenloaichiphi)
        {
            this.maloaichiphi = maloaichiphi;
            this.tenloaichiphi = tenloaichiphi;
        }
        public LoaiChiPhiModel(LoaiChiPhiModel LoaiChiPhi)
        {
            this.maloaichiphi = LoaiChiPhi.maloaichiphi;
            this.tenloaichiphi = LoaiChiPhi.tenloaichiphi;
        }
    }
}