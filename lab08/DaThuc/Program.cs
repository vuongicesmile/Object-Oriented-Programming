using System;

namespace DaThuc
{
    class DaThuc
    {
        int n;
        //int somu;
        double[] dt = new double[20];
        
        public void Nhap()
        {
            bool kt;
            
            do
            {
                Console.WriteLine("Nhap vao bac cua da thuc: ");
                kt = Int32.TryParse(Console.ReadLine(),out n);

                Console.WriteLine("Nhap vao cac he so cua da thuc: ");
                {
                    for (int i = 0; i <= n; i++)
                    {
                        Console.Write("a{0}:", i);
                        dt[i] = Int32.Parse(Console.ReadLine());
                    }

                }
            } while (!kt);
        }
        public void xuat()
        {
            Console.Write("\nDA THUC: \n");
            for (int i = n; i > 0; i--)
            {
                Console.Write("{0}X^{1} + ", dt[i], n--);
            }
            Console.Write(" {0} ", dt[0]);
        }
        //public DaThuc congDaThuc(DaThuc d1)
        //{
        //    DaThuc d;
        //    int i, j;
        //    if (n > d1.n)
        //    {
        //        d = new DaThuc(n);
        //        for (i = 0; i <= d1.n; i++)
        //        {
        //            d.dt[i] = dt[i] + d1.dt[i];
        //        }
        //        for (j = i; j <= n; i++)
        //        {
        //            d.dt[j] = dt[j];
        //        }
        //    }
        //    else
        //    {
        //        d = new DaThuc(d1.n);
        //        for (i = 0; i <= n; i++)
        //            d.dt[i] = a[i] + d1.a[i];
        //        for (j = i; j <= d1.n; j++)
        //            d.a[j] = d1.a[j];
        //    }

        //    return d;

        //}

        public static DaThuc operator +(DaThuc f, DaThuc g)
        {
            DaThuc h = new DaThuc();
            int maxbac = Math.Max(f.n, h.n);
            h.n = maxbac;
            for (int i = 0; i <= h.n; i++)
            {
                h.dt[i] = f.dt[i] + g.dt[i];
            }
            return h;
        }
        public static DaThuc operator -(DaThuc f, DaThuc g)
        {
            DaThuc h = new DaThuc();
            int maxbac = Math.Max(f.n, h.n);
            h.n = maxbac;
            for (int i = 0; i <= h.n; i++)
            {
                h.dt[i] = f.dt[i] - g.dt[i];
            }
            return h;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DaThuc dt1 = new DaThuc();
            DaThuc dt2 = new DaThuc();
            dt1.Nhap();
            dt1.xuat();
            
            dt2.Nhap();
            dt2.xuat();
            
            Console.WriteLine("Toan tu +, - ");
            DaThuc dt3 = new DaThuc();
            dt3 = dt1 + dt2;
            dt3.xuat();
            dt3 = dt1 - dt2;
            dt3.xuat();
        }
    }
}
