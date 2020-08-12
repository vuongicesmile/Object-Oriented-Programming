using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class DaThuc
    {
        //propertier
        private const int maxsize = 101;
        private int degree;
        private int[] coefficient;
        //methods

        #region Contructor
        public DaThuc()
        {
            coefficient = new int[maxsize];
            for (int i = 0; i < maxsize; i++)
                coefficient[i] = 0;
            degree = 0;
        }

        public DaThuc(int deg, int start, int increment)
        {
            coefficient = new int[maxsize];
            for (int i = 0; i < maxsize; i++)
                coefficient[i] = 0;
            degree = 0;
            int current = start;
            for (int i = 0; i <= deg; i++)
            {
                coefficient[i] = current;
                current += increment;
            }
            degree = deg;
        }

        public DaThuc(int[] cof)
        {
            degree = cof.Length - 1;
            for (int i = 0; i <= degree; i++)
                coefficient[i] = cof[i];
            if (cof[cof.Length - 1] == 0)
                coefficient[degree] = 1;

        }
        #endregion
        #region Set/get
        public int Setdegree
        {
            get { return degree; }
            set { degree = value; }

        }
        public int[] Setcof
        {
            get { return coefficient; }
            set { coefficient = value; }
        }
        public DaThuc(int deg, int[] cof)
        {
            this.degree = deg;
            this.coefficient = cof;

        }


        #endregion
        #region Input/output

        public void Nhap()
        {
            //int degree;
            coefficient = new int[maxsize];
            Console.WriteLine("So mu");
            Console.Write("nhap so mu:");
            degree = int.Parse(Console.ReadLine());
            //Nhap he so
            for (int i = degree; i >= 0; i--)
            {
                Console.Write("Nhap he so thu {0}: ", i);
                coefficient[i] = int.Parse(Console.ReadLine());
            }
        }
        public void xuat()
        {
            string Output = "";

            for (int i = degree; i >= 0; i--)
            {
                if (i != 0)
                    Output += coefficient[i] + "x^" + i + "+";
                else
                    Output += coefficient[i];
            }
            //Output += coefficient[degree] + "x^" 
            Output = Output.Replace("x^0", "");
            Output = Output.Replace("x^1", "x");
            Output = Output.Replace("+-", "-");
            Output = Output.Replace("0x", "");
            Output = Output.Replace("x+ ", "");
            Output = Output.Replace("1x", "x");
            Output = Output.Replace("0^", "");
            Output = Output.Replace("++", "+");
            Output.Reverse();
            Console.WriteLine(Output);
        }
        #endregion
        #region Operrator Overloading
        public void TinhGT()
        {
            float n;
        }
        public static DaThuc operator +(DaThuc a, DaThuc b)
        {
            DaThuc c = new DaThuc();
            if (a.degree > b.degree)
            { c.degree = a.degree; }
            else
                c.degree = b.degree;

            for (int i = 0; i <= c.degree; i++)
            {
                c.coefficient[i] = a.coefficient[i] + b.coefficient[i];
            }


            return c;
        }
        public static DaThuc operator -(DaThuc a, DaThuc b)
        {
            DaThuc c = new DaThuc();
            if (a.degree > b.degree)
            {
                c.degree = a.degree;
            }
            else
                c.degree = b.degree;

            for (int i = 0; i <= c.degree; i++)
            {
                c.coefficient[i] = a.coefficient[i] - b.coefficient[i];
            }


            return c;
        }
        public static DaThuc operator *(DaThuc a, DaThuc b)
        {
            DaThuc c = new DaThuc();
            for (int i = 0; i <= a.degree; i++)
            {
                for (int j = 0; j <= b.degree; j++)
                {

                }


            }
            return c;
        }
        public static DaThuc operator /(DaThuc a, DaThuc b)
        {
            DaThuc c = new DaThuc();
            c.degree = 0;
            c.coefficient = new int[maxsize];

            if (a.degree > b.degree)
                for (int i = a.degree; i >= b.degree; i--)
                {
                    c.degree = a.degree - b.degree;
                    c.coefficient[i] = a.coefficient[i] / b.coefficient[b.degree];
                    for (int j = a.degree; j >= 0; j--)
                    {
                        if (a.degree == c.degree + b.degree)
                        {
                            a.degree -= c.degree * b.degree;
                            a.coefficient[i] -= c.coefficient[i] * b.coefficient[i];

                        }
                    }
                    a.degree--;
                }

            else
            {
                Console.Write("Thuong cua 2 da thuc = ");
            }
            return c;
        }
        public static bool operator ==(DaThuc p, DaThuc q)
        {
            if (p.degree == q.degree)
                for (int i = 0; i <= p.degree; i++)
                {
                    for (int j = 0; j <= q.degree; j++)
                    {
                        if (p.coefficient[i] == q.coefficient[j])
                        {
                            return true;
                        }
                    }
                }

            return false;
        }

        public static bool operator !=(DaThuc p, DaThuc q)
        {
            if (p.degree != q.degree)
                for (int i = 0; i <= p.degree; i++)
                {
                    for (int j = 0; j <= q.degree; j++)
                    {
                        if (p.coefficient[i] != q.coefficient[j])
                        {
                            return true;
                        }
                    }
                }
            return false;

            //return !(p == q);
        }
        #endregion
    }
}