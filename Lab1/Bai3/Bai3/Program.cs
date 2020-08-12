using System;

namespace Bai3
{
    class Program
    {
        class HCN
        {
            int chieudai, chieurong, s, c;
            public void SetHCN(int cd, int cr)
            {
                chieudai = cd;
                chieurong = cr;

            }
            public int chuvi()
            {
                return c = (chieudai + chieurong) * 2;
            }
            public int dientich()
            {
               return s = (chieudai * chieurong);
            }
        }
        
        static void Main(string[] args)
        {
           
            Console.WriteLine("Nhap vao chieu dai:");
            cd = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap vao chieu rong:");
            cr = int.Parse(Console.ReadLine());
             HCN hcn1  = new HCN();
            hcn1.SetHCN(cd, cr);
            Console.WriteLine("Chu vi hcn la:{0}",hcn1.chuvi());
            Console.WriteLine("Dien tich hcn la:{0}", hcn1.dientich());
            Console.ReadLine();

        }
    }
}
