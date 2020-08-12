using nguyenquocvuong_1813865;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection.PortableExecutable;

namespace KT_CuoiCung
{
    public class Nguoi
    {
        protected string hoDem;
        protected string ten;
        protected string maSo;

        public Nguoi()
        {

        }
        public Nguoi(string hoDem, string ten, string ms)
        {
            this.hoDem = hoDem;
            this.ten = ten;
            this.maSo = ms;
        }

        public string HoDem
        {
            get
            {
                return hoDem;
            }
            set
            {
                hoDem = value;
            }
        }
        public string Ten
        {
            get
            {
                return ten;
            }
            set
            {
                ten = value;
            }
        }
        public string MaSo
        {
            get
            {
                return maSo;
            }
            set
            {
                maSo = value;
            }
        }
    }
    public class GiaoVien : Nguoi
    {
        private string id;
        private string tenBoMon;

        public GiaoVien()
        {

        }
        public GiaoVien(string hoDem, string ten, string ms, string id, string tenMonHoc)
            : base(hoDem, ten, ms)
        {
            this.id = id;
            this.tenBoMon = tenMonHoc;
        }

        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public string TenBoMon
        {
            get
            {
                return tenBoMon;
            }
            set
            {
                tenBoMon = value;
            }
        }
    }
    public interface IODatabase
    {
        void Write(string filename);
        void Read(string filename);
        string Data { get; set; }
    }
    public interface IBaoMat
    {
        string MaHoa(string data);
        string GiaiMa(string data);
    }
    public class QLGV : IODatabase, IBaoMat
    {
        String S;
        private GiaoVien[] dsGiaoVien;
        private int tongSo;
        private int MAX = 100;

        public QLGV()
        {
            dsGiaoVien = new GiaoVien[MAX];
        }
        public QLGV(string str)
        {
            S = str;
        }


        public void NhapDSGiaoVien()
        {
            while (true)
            {
                Console.Write("Nhap vao so luong giao vien: ");
                bool isValid = int.TryParse(Console.ReadLine(), out tongSo);
                if (isValid) break;
            }

            for (int i = 0; i < tongSo; i++)
            {
                Console.WriteLine("Nhap thong tin cho giao vien thu: {0}", i + 1);
                Console.Write("Nhap vao ho va ten dem: "); var hoDem = Console.ReadLine();
                Console.Write("Nhap vao ten giao vien: "); var ten = Console.ReadLine();
                Console.Write("Nhap vao chung minh nhan dan: "); var cmnd = Console.ReadLine();
                Console.Write("Nhap vao ma so giao vien: "); var msgv = Console.ReadLine();
                Console.Write("Nhap vao ten bo mon giang day: "); var tenBM = Console.ReadLine();

                dsGiaoVien[i] = new GiaoVien(hoDem, ten, cmnd, msgv, tenBM);
            }
        }

        public void XuatDSGiaoVien()
        {
            Console.WriteLine("Tong so giao vien hien tai trong danh sach: {0}", tongSo);
            Console.WriteLine("CMND     HoDem       Ten     ID      TenBoMon");
            for (int i = 0; i < tongSo; i++)
            {
                GiaoVien gv = dsGiaoVien[i];
                Console.WriteLine("{0} {1} {2} {3} {4}", gv.MaSo, gv.HoDem, gv.Ten, gv.ID, gv.TenBoMon);
            }
            Console.WriteLine();
        }
        public GiaoVien TK_Ten(string hoDem, string ten)
        {
            for (int i = 0; i < tongSo; i++)
                if (dsGiaoVien[i].HoDem == hoDem && dsGiaoVien[i].Ten == ten)
                    return dsGiaoVien[i];
            return null;
        }
        public void TK_TatCa_Ten(string ten)
        {
            Console.WriteLine("Ket qua: ");
            int dem = 0;
            for (int i = 0; i < tongSo; i++)
            {
                GiaoVien gv = dsGiaoVien[i];
                if (gv.Ten == ten)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4}", gv.MaSo, gv.HoDem, gv.Ten, gv.ID, gv.TenBoMon);
                    dem++;
                }
            }

            if (dem == 0)
                Console.WriteLine("Khong tim thay giao vien co ten: '{0}'", ten);
        }
        public GiaoVien TK_MSGV(string msgv)
        {
            for (int i = 0; i < tongSo; i++)
                if (dsGiaoVien[i].MaSo == msgv)
                    return dsGiaoVien[i];
            return null;
        }
        public string GiaiMa(string data)
        {
            string chuoiGiaiMa = "";
            for (int i = 0; i < data.Length; i++)
            {
                chuoiGiaiMa += (char)((int)data[i] - 100);
            }
            return chuoiGiaiMa;
        }

        public string MaHoa(string data)
        {
            string chuoiMaHoa = "";
            for (int i = 0; i < data.Length; i++)
            {
                chuoiMaHoa += (char)((int)data[i] + 100);
            }
            return chuoiMaHoa;
        }

        public void Read(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open);
            StreamReader reader = new StreamReader(fs);

            tongSo = int.Parse(GiaiMa(reader.ReadLine()));

            for (int i = 0; i < tongSo; i++)
            {
                var cmnd = GiaiMa(reader.ReadLine());
                var hodem = GiaiMa(reader.ReadLine());
                var ten = GiaiMa(reader.ReadLine());
                var msgv = GiaiMa(reader.ReadLine());
                var tenBM = GiaiMa(reader.ReadLine());

                dsGiaoVien[i] = new GiaoVien(hodem, ten, cmnd, msgv, tenBM);
            }

            reader.Close();
            fs.Close();
        }

        public void Write(string filename)
        {
            FileStream fs;
            fs = new FileStream(filename, FileMode.OpenOrCreate);

            StreamWriter writer = new StreamWriter(fs);
            writer.WriteLine(MaHoa(tongSo.ToString()));

            for (int i = 0; i < tongSo; i++)
            {
                GiaoVien gv = dsGiaoVien[i];
                writer.WriteLine(MaHoa(gv.MaSo));
                writer.WriteLine(MaHoa(gv.HoDem));
                writer.WriteLine(MaHoa(gv.Ten));
                writer.WriteLine(MaHoa(gv.ID));
                writer.WriteLine(MaHoa(gv.TenBoMon));
            }

            writer.Close();
            fs.Close();
        }
        public string Data
        {
            get
            { return S; }
            set { S = value; }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\data\dulieu.txt";
            QLGV s = new QLGV();
            s.NhapDSGiaoVien();
            s.XuatDSGiaoVien();
            s.Write(path);
            s.Read(path);
            s.TK_MSGV("1");
            Console.WriteLine("Tim kiem tat ca ma so giao vien {0}", s.TK_MSGV("1"));
            s.TK_TatCa_Ten("A");
            Console.WriteLine("Tim kiem tat ca ten giao vien co ten la A{0}", s.TK_MSGV("A"));
           
            
            Console.WriteLine("Du lieu trong file : {0}", s.Data);
            Console.WriteLine("du lieu sau khi ma hoa:");
            // s.MaHoa(Data);
            Console.WriteLine("du lieu sau khi giai hoa:");
            //s.GiaiMa(data);
            Console.WriteLine();
            Console.ReadLine();

        }
    }
}