using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tour_du_lich.Models
{
    public class DiaDiemModel
    {
        public string madiadiem { get; set; }
        public string tendiadiem { get; set; }

        public DiaDiemModel()
        {

        }

        public DiaDiemModel(String madiadiem, String tendiadiem)
        {
            this.madiadiem = madiadiem;
            this.tendiadiem = tendiadiem;
        }
        public DiaDiemModel(DiaDiemModel diadiem)
        {
            this.madiadiem = diadiem.madiadiem;
            this.tendiadiem = diadiem.tendiadiem;
        }
    }
}