using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hinhtron
{
    class Program
    {
        static void Main(string[] args)
        {
            namespacehinhtron.HinhTron ht = new namespacehinhtron.HinhTron();
            ht.Nhap();
            ht.xuat();
            ht.dientich();
            namespacehinhcau.hinhcau hc = new namespacehinhcau.hinhcau();
            hc.Nhap();
            hc.xuat();
            hc.thetich();
            hc.dientich();
            Console.ReadLine();

           
        }
    }
}
