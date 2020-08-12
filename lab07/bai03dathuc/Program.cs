using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            DaThuc A = new DaThuc();
            A.Nhap();
            A.xuat();
            DaThuc B = new DaThuc();
            B.Nhap();
            B.xuat();
            DaThuc C = new DaThuc();
           
            C = A + B;
            Console.WriteLine("Tong da thuc la:{0}", C);
            C = A - B;
            Console.WriteLine("Hieu da thuc la:{0}", C);
            Console.ReadLine();
        }
    }
}
