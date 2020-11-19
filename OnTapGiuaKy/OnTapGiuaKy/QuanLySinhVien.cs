using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTapGiuaKy
{
    
    public class QuanLySinhVien
    {
        List<SinhVien> lsv;
        IDataSource idatasource;
        public QuanLySinhVien(IDataSource idatasource)
        {
            this.idatasource = idatasource;
            lsv = idatasource.GetSinhVien();
        }
        
        public List<SinhVien> GetListSinhVien()
        {
            return lsv;
        }
        public void AddOrUpdate(SinhVien sv)
        {
            int index = FindIndex(sv);
            if (index < 0) //ko ton tai
            {
                lsv.Add(sv);
                idatasource.Save(lsv);
            }
            else //da ton tai
            {
                lsv[index] = sv;
                idatasource.Save(lsv);
            }
        }
        public int FindIndex(SinhVien sv)
        {
            for (int i = 0; i < lsv.Count; i++)
            {
                if (lsv[i].Mssv == sv.Mssv)
                {
                    return i;
                }
            }
            return -1;
        }

    }
}
