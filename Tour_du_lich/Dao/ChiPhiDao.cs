using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tour_du_lich.Models;

namespace Tour_du_lich.Dao
{
    public class ChiPhiDao
    {
        
        DBTOUREntities DB = new DBTOUREntities();
           
        public List<ChiPhiModel> GetAllChiPhi()
        {
            DB.Configuration.ProxyCreationEnabled = false;
            List<ChiPhiModel> result = new List<ChiPhiModel>();

            foreach (chiphi temp in DB.chiphis)
            {
                ChiPhiModel ChiPhi = new ChiPhiModel(temp.machiphi, temp.maloaichiphi, temp.madoan, temp.giathanh, temp.ghichu);
                result.Add(ChiPhi);
            }

            return result;
        }

        public ChiPhiModel GetChiPhiById(string id_chiphi, string id_doan)
        {
            chiphi temp = DB.chiphis.SingleOrDefault(ChiPhi => ChiPhi.maloaichiphi == id_chiphi && ChiPhi.madoan == id_doan);
            ChiPhiModel ChiPhi1 = new ChiPhiModel();
            if (temp != null)
            {
                ChiPhi1.machiphi = temp.machiphi;
                ChiPhi1.maloaichiphi = temp.maloaichiphi;
                ChiPhi1.madoan = temp.madoan;
                ChiPhi1.ghichu = temp.ghichu;
                ChiPhi1.giathanh = temp.giathanh;
            }
           
            return ChiPhi1;
        }
        public void AddChiPhi(ChiPhiModel ChiPhi)
        {
            try
            {
                chiphi data = new chiphi();
                data.machiphi = ChiPhi.machiphi;
                data.maloaichiphi = ChiPhi.maloaichiphi;
                data.madoan = ChiPhi.madoan;
                data.giathanh = ChiPhi.giathanh;
                data.ghichu = ChiPhi.ghichu;
                DB.chiphis.Add(data);
                DB.SaveChanges();
            } catch (Exception e)
            {
                
            }
        }

        public bool ExistId(string id_chiphi, string id_doan)
        {
            var dd = DB.chiphis.SingleOrDefault(x => x.maloaichiphi == id_chiphi && x.madoan == id_doan);
            if (dd == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Delete(string id_chiphi, string id_doan)
        {
            chiphi d = DB.chiphis.SingleOrDefault(ChiPhi => ChiPhi.maloaichiphi == id_chiphi && ChiPhi.madoan == id_doan);
            if (d != null)
            {
                DB.chiphis.Remove(d);
            }
            DB.SaveChanges();
        }

        public void Update(ChiPhiModel ChiPhiupdate)
        {
            chiphi d = DB.chiphis.SingleOrDefault(ChiPhi => ChiPhi.maloaichiphi == ChiPhiupdate.maloaichiphi && ChiPhi.madoan == ChiPhiupdate.madoan);
            if (d != null)
            {
                d.ghichu = ChiPhiupdate.ghichu;
                d.giathanh = ChiPhiupdate.giathanh;
            }
            DB.SaveChanges();
        }
    }
}