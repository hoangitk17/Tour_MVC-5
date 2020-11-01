using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tour_du_lich.Models;

namespace Tour_du_lich.Dao
{
    public class LoaiChiPhiDao
    {
        
        DBTOUREntities DB = new DBTOUREntities();
           
        public List<LoaiChiPhiModel> GetAllLoaiChiPhi()
        {
            DB.Configuration.ProxyCreationEnabled = false;
            List<LoaiChiPhiModel> result = new List<LoaiChiPhiModel>();

            foreach (loaichiphi temp in DB.loaichiphis)
            {
                LoaiChiPhiModel LoaiChiPhi = new LoaiChiPhiModel(temp.maloaichiphi, temp.tenloaichiphi);
                result.Add(LoaiChiPhi);
            }

            return result;
        }

        public LoaiChiPhiModel GetLoaiChiPhiById(string id)
        {
            loaichiphi temp = DB.loaichiphis.SingleOrDefault(LoaiChiPhi => LoaiChiPhi.maloaichiphi == id);
            LoaiChiPhiModel LoaiChiPhi1 = new LoaiChiPhiModel();
            if (temp != null)
            {
                LoaiChiPhi1.maloaichiphi = temp.maloaichiphi;
                LoaiChiPhi1.tenloaichiphi = temp.tenloaichiphi;
            }
           
            return LoaiChiPhi1;
        }
        public void AddLoaiChiPhi(LoaiChiPhiModel LoaiChiPhi)
        {
            try
            {
                loaichiphi data = new loaichiphi();
                data.maloaichiphi = LoaiChiPhi.maloaichiphi;
                data.tenloaichiphi = LoaiChiPhi.tenloaichiphi;
                DB.loaichiphis.Add(data);
                DB.SaveChanges();
            } catch (Exception e)
            {
                
            }
        }

        public bool ExistId(string id)
        {
            var dd = DB.loaichiphis.SingleOrDefault(x => x.maloaichiphi == id);
            if (dd == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Delete(string id)
        {
            loaichiphi d = DB.loaichiphis.SingleOrDefault(LoaiChiPhi => LoaiChiPhi.maloaichiphi == id);
            if (d != null)
            {
                DB.loaichiphis.Remove(d);
            }
            DB.SaveChanges();
        }

        public void Update(LoaiChiPhiModel LoaiChiPhiupdate)
        {
            loaichiphi d = DB.loaichiphis.SingleOrDefault(LoaiChiPhi => LoaiChiPhi.maloaichiphi == LoaiChiPhiupdate.maloaichiphi);
            if (d != null)
            {
                d.tenloaichiphi = LoaiChiPhiupdate.tenloaichiphi;
            }
            DB.SaveChanges();
        }
    }
}