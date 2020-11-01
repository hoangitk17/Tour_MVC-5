using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tour_du_lich.Models;

namespace Tour_du_lich.Dao
{
    public class KhachDao
    {
        
        DBTOUREntities DB = new DBTOUREntities();
           
        public List<KhachModel> GetAllKhach()
        {
            DB.Configuration.ProxyCreationEnabled = false;
            List<KhachModel> result = new List<KhachModel>();

            foreach (khachhang temp in DB.khachhangs)
            {
                KhachModel Khach = new KhachModel(temp.makh, temp.tenkh, temp.diachi, temp.sdt, temp.giotinh, temp.cmnd);
                result.Add(Khach);
            }

            return result;
        }

        public KhachModel GetKhachById(string id)
        {
            khachhang temp = DB.khachhangs.SingleOrDefault(Khach => Khach.makh == id);
            KhachModel Khach1 = new KhachModel();
            if (temp != null)
            {
                Khach1.makh = temp.makh;
                Khach1.tenkh = temp.tenkh;
                Khach1.diachi = temp.diachi;
                Khach1.sdt = temp.sdt;
                Khach1.gioitinh = temp.giotinh;
                Khach1.cmnd = temp.cmnd;
            }
           
            return Khach1;
        }
        public void AddKhach(KhachModel Khach)
        {
            try
            {
                khachhang data = new khachhang();
                data.makh = Khach.makh;
                data.tenkh = Khach.tenkh;
                data.diachi = Khach.diachi;
                data.sdt = Khach.sdt;
                data.giotinh = Khach.gioitinh;
                data.cmnd = Khach.cmnd;
                DB.khachhangs.Add(data);
                DB.SaveChanges();
            } catch (Exception e)
            {
                
            }
        }

        public bool ExistId(string id)
        {
            var dd = DB.khachhangs.SingleOrDefault(x => x.makh == id);
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
            khachhang d = DB.khachhangs.SingleOrDefault(Khach => Khach.makh == id);
            if (d != null)
            {
                DB.khachhangs.Remove(d);
            }
            DB.SaveChanges();
        }

        public void Update(KhachModel Khachupdate)
        {
            khachhang d = DB.khachhangs.SingleOrDefault(Khach => Khach.makh == Khachupdate.makh);
            if (d != null)
            {
                d.tenkh = Khachupdate.tenkh;
                d.diachi = Khachupdate.diachi;
                d.sdt = Khachupdate.sdt;
                d.giotinh = Khachupdate.gioitinh;
                d.cmnd = Khachupdate.cmnd;
            }
            DB.SaveChanges();
        }
    }
}