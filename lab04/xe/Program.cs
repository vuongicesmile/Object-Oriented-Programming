using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xe
{
    class XeHoi
    {
        protected int TocDo;
        protected string BienSo;
        protected string HangSX;

        public XeHoi(int td, string BS, string HSX)
        {
            TocDo = td;
            BienSo = BS;
            HangSX = HSX;
        }

        public void Xuat()
        {
            Console.Write("Xe: {0},bien so:{1}, toc do:{2}kmh", HangSX, BienSo, TocDo);

        }
    }
    class Xekhanh : XeHoi
    {
        int SoHanhKhach;
        public Xekhanh(int td, string BS, string HSX, int SHK) : base(td, BS, HSX)
        {
            SoHanhKhach = SHK;
        }
        public new void Xuat()
        {
            base.Xuat();
            Console.WriteLine(",{0} cho ngoi", SoHanhKhach);

        }
    }
    class XeTai : XeHoi
    {
        double TrongTai;
        public XeTai(int td, string BS, string HSX, double TT) : base(td, BS, HSX)
        {
            TrongTai = TT;
        }
        public new void Xuat()
        {
            base.Xuat();
            Console.WriteLine(",{0} kilogam", TrongTai);

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Thong tin xe khach");
            Xekhanh c = new Xekhanh(150, "49A-4444", "Toyota", 24);
            c.Xuat();
            Console.WriteLine("Thong tin xe tai");
            XeTai d = new XeTai(150, "49A-4554", "Yamaha", 1200);
            d.Xuat();

            Console.ReadLine();

        }
    }
}

