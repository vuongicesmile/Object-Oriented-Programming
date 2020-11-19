using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTapGiuaKy
{
    public class TXTDataStorage : IDataSource
    {
        string filename { get; set; }
        public TXTDataStorage(string filename)
        {
            this.filename = filename;
        }
        public List<SinhVien> GetSinhVien()
        {
            List<SinhVien> lsv = new List<SinhVien>();
            if (!File.Exists(filename))
            {
                FileStream fs = File.Create(filename);
                fs.Close();
            }
            string line;
            using (StreamReader r = new StreamReader(filename))
            {
                while ((line = r.ReadLine()) != null)
                {
                    lsv.Add(Parseline(line));
                }
            }
            return lsv;
        }

        public void Save(List<SinhVien> listsv)
        {
            using (StreamWriter w = new StreamWriter(filename))
            {
                foreach (var item in listsv)
                {
                    w.WriteLine(FormatSV(item));
                }
            }
        }
        public string FormatSV(SinhVien sv)
        {
            return string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|",
                sv.Mssv,
                sv.Holot,
                sv.Ten,
                sv.Gioitinh,
                sv.Ngaysinh,
                sv.Lop,
                sv.Socmnd,
                sv.Sodt,
                sv.Diachi,
                string.Join("^", sv.Monhoc));
        }
        public SinhVien Parseline(string line)
        {
            var parts = line.Split('|');
            var monhoc = parts[(int)ColumIndex.monhoc].Split('^').ToList();
            return new SinhVien()
            {
                Mssv = parts[(int)ColumIndex.mssv],
                Holot = parts[(int)ColumIndex.holot],
                Ten = parts[(int)ColumIndex.ten],
                Gioitinh = parts[(int)ColumIndex.gioitinh],
                Ngaysinh = DateTime.Parse(parts[(int)ColumIndex.ngaysinh]),
                Lop = parts[(int)ColumIndex.lop],
                Socmnd = parts[(int)ColumIndex.socmnd],
                Sodt = parts[(int)ColumIndex.sodt],
                Diachi = parts[(int)ColumIndex.diachi],
                Monhoc = monhoc
            };
        }

        

        public enum ColumIndex
        {
            mssv,
            holot,
            ten,
            gioitinh,
            ngaysinh,
            lop,
            socmnd,
            sodt,
            diachi,
            monhoc,
        }
    }
}
