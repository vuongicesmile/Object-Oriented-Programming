using System;
using System.Collections.Generic;
using System.Text;

namespace Bai7
{
    class phanso
    {
        int tuso, mauso;

        public void show()
        {
            Console.WriteLine("phan so:{0}/{1}", tuso, mauso);
        }
        public  phanso()
        {
            tuso = 0;
            mauso = 1;
        }
        public  phanso(int x)
        {
            tuso = x;
            mauso = 1;
        }
        public  phanso(int x, int y)
        {
            tuso = x;
            mauso = y;
        }
        
    }
}
