using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tour_du_lich.Models;

namespace Tour_du_lich.Dao
{
    public class NhanVienDao
    {
        
        DBTOUREntities DB = new DBTOUREntities();
           
        public List<NhanVienModel> GetAllNhanVien()
        {
            DB.Configuration.ProxyCreationEnabled = false;
            List<NhanVienModel> result = new List<NhanVienModel>();

            foreach (nhanvien temp in DB.nhanviens)
            {
                NhanVienModel nhanvien = new NhanVienModel(temp.manv, temp.tennv, temp.diachi);
                result.Add(nhanvien);
            }

            return result;
        }

        public NhanVienModel GetNhanVienById(string id)
        {
            nhanvien temp = DB.nhanviens.SingleOrDefault(nhanvien => nhanvien.manv == id);
            NhanVienModel nhanvien1 = new NhanVienModel();
            if (temp != null)
            {
                nhanvien1.manv = temp.manv;
                nhanvien1.tennv = temp.tennv;
                nhanvien1.diachi = temp.diachi;
            }
           
            return nhanvien1;
        }
        public void AddNhanVien(NhanVienModel nhanvien)
        {
            try
            {
                nhanvien data = new nhanvien();
                data.manv = nhanvien.manv;
                data.tennv = nhanvien.tennv;
                data.diachi = nhanvien.diachi;
                DB.nhanviens.Add(data);
                DB.SaveChanges();
            } catch (Exception e)
            {
                
            }
        }

        public bool ExistId(string id)
        {
            var dd = DB.nhanviens.SingleOrDefault(x => x.manv == id);
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
            nhanvien d = DB.nhanviens.SingleOrDefault(nhanvien => nhanvien.manv == id);
            if (d != null)
            {
                DB.nhanviens.Remove(d);
            }
            DB.SaveChanges();
        }

        public void Update(NhanVienModel nhanvienupdate)
        {
            nhanvien d = DB.nhanviens.SingleOrDefault(nhanvien => nhanvien.manv == nhanvienupdate.manv);
            if (d != null)
            {
                d.tennv = nhanvienupdate.tennv;
                d.diachi = nhanvienupdate.diachi;
            }
            DB.SaveChanges();
        }
    }
}