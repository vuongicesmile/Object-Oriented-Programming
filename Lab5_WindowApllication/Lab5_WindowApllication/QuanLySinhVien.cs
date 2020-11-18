using Lab5_WindowApllication;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class QuanLySinhVien
    {
        public List<SinhVien> danhsachsv;

        public QuanLySinhVien()
        {
            danhsachsv = new List<SinhVien>();
        }

        public SinhVien this[int index]
        {
            get { return danhsachsv[index]; }
            set { danhsachsv[index] = value; }
        }


        public bool Sua(SinhVien sv)
        {
            bool kq = false;
            int count = danhsachsv.Count;
            for (int i = 0; i < count; i++)
            {
                if (sv.Mssv == danhsachsv[i].Mssv)
                {
                    danhsachsv[i] = sv;
                    kq = true;
                }
            }
            return kq;
        }
        public SinhVien TimKiem(string value, KieuTim kieutim)
        {
            SinhVien sv = new SinhVien();
            switch (kieutim)
            {
                case KieuTim.TheoMa:
                    foreach (SinhVien item in danhsachsv)
                    {
                        if (item.Mssv == value)
                            sv = item;
                    }
                    break;
                case KieuTim.TheoLop:
                    foreach (SinhVien item in danhsachsv)
                    {
                        if (item.Lop == value)
                            sv = item;
                    }
                    break;
                case KieuTim.TheoTen:
                    foreach (SinhVien item in danhsachsv)
                    {
                        if (item.Ten == value)
                            sv = item;
                    }
                    break;
                default:
                    break;
            }

            return sv;
        }

        public void ThemSV(SinhVien sv)
        {
            danhsachsv.Add(sv);
        }

        public void GhiFile()
        {
            string filename = "DanhSach.txt";
            // Delete the file if it exists.
            //if (File.Exists(filename))
            //{
            //    File.Delete(filename);
            //}
            StreamWriter sw = new StreamWriter(new FileStream(filename, FileMode.Create, FileAccess.Write));
            foreach (SinhVien item in danhsachsv)
            {
                string mssv = item.Mssv;
                string gt = "Nữ";
                if (item.Gioitinh)
                    gt = "Nam";
                string holot = item.Holot;
                string ten = item.Ten;
                string ngaysinh = item.Ngaysinh.ToString("m/D/yyyy");
                string lop = item.Lop;
                string socmnd = item.Socmnd;
                string sodt = item.Sodt;
                string diachi = item.Diachi;
                string cntotal = "";
                foreach (string cn in item.Chuyennganh)
                {
                    cntotal += cn + ",";
                }
                cntotal = cntotal.Substring(0, cntotal.Length - 1);
                string sinhvien = mssv + "*" + holot + "*" + ten + "*" + gt + "*" + ngaysinh + "*" + lop + "*" + socmnd + "*" + sodt + "*" + diachi + "*" + cntotal;
                sw.WriteLine(sinhvien);
            }
            sw.Close();
        }

        public void DocTuFile()
        {
            string filename = "DanhSach.txt", t;
            string[] s;
            SinhVien sv;
            StreamReader sr = new StreamReader(new FileStream(filename, FileMode.Open));
            while ((t = sr.ReadLine()) != null)
            {
                s = t.Split('*');
                sv = new SinhVien();
                sv.Mssv = s[0];
                sv.Holot = s[1];
                sv.Ten = s[2];
                bool gt = false;
                if (s[3] == "Nam")
                    gt = true;
                sv.Gioitinh = gt;
                sv.Ngaysinh = DateTime.ParseExact(s[4], "M/d/yyyy", CultureInfo.InvariantCulture);
                sv.Lop = s[5];
                sv.Socmnd = s[6];
                sv.Sodt = s[7];
                sv.Diachi = s[8];
                string[] cn = s[9].Split(',');
                foreach (string item in cn)
                {
                    sv.Chuyennganh.Add(item);
                }
                ThemSV(sv);
            }
            sr.Close();
        }

    }

