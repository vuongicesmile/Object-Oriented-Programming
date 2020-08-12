using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace namespacehinhcau
{
    class hinhcau:namespacehinhtron.HinhTron
    {
        public double thetich()
        {
            double tt;
            tt = 4 / 3 * Pi * r * r * r;
            Console.WriteLine("The tich hinh cau la : {0} ",tt);
            return tt;
        }
        public new double dientich()
        {
            double S = r * r * 4*Pi;
            Console.WriteLine("Dien tich hinh cau la : {0}", S);
            return S;
        }
    }
}
