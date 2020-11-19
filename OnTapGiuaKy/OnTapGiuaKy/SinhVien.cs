using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTapGiuaKy
{
    public class SinhVien
    {
        string mssv;
        string holot;
        string ten;
        string gioitinh;
        DateTime ngaysinh;
        string lop;
        string socmnd;
        string sodt;
        string diachi;
        List<string> monhoc;

        public SinhVien()
        {
            Monhoc = new List<string>();
        }
        public SinhVien(string mssv, string holot, string ten, string gt, DateTime ngaysinh, string lop, string socmnd, string sodt, string diachi, List<string> monhoc)
        {
            this.Mssv = mssv;
            this.Holot = holot;
            this.Ten = ten;
            this.Gioitinh = gt;
            this.Ngaysinh = ngaysinh;
            this.Lop = lop;
            this.Socmnd = socmnd;
            this.Diachi = diachi;
            this.Monhoc = monhoc;
        }

        public string Mssv { get => mssv; set => mssv = value; }
        public string Holot { get => holot; set => holot = value; }
        public string Ten { get => ten; set => ten = value; }
        public string Gioitinh { get => gioitinh; set => gioitinh = value; }
        public DateTime Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
        public string Lop { get => lop; set => lop = value; }
        public string Socmnd { get => socmnd; set => socmnd = value; }
        public string Sodt { get => sodt; set => sodt = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public List<string> Monhoc { get => monhoc; set => monhoc = value; }
    }
}
