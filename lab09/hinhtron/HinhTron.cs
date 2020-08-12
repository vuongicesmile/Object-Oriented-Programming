using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace namespacehinhtron
{
    class HinhTron
    {
        protected double r;
        protected double Pi = 3.14;

        
        public HinhTron()
        {
            r = 0;
        }
        public HinhTron(double R)
        {
            this.r = R;
        }
        public void Nhap()
        {
            bool kiemtra = false;
            do
            {
                Console.Write("Nhap ban kinh: ");
                kiemtra = double.TryParse(Console.ReadLine(), out r);
            }
            while (!kiemtra);
        }
        public void xuat()
        {
            Console.WriteLine("Ban kinh vua nhap la {0}", r);
        }
        public double  dientich()
        {
            double S= r * r * Pi;
            Console.WriteLine("Dien tich hinh tron la :{0}",S );
            return S;
        }
    }
    
        
    
       
}
