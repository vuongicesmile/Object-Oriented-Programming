using System;

namespace Bai4
{
    class Program
    {
        public class Phanso
        {
            int ts, ms;

            
            public void show()
            {
                Console.WriteLine("Phan So:{0}/{1}", ts, ms);
            }
            public void nhap()
            {
                Console.WriteLine("Nhap vao tu so:");
                ts = int.Parse(Console.ReadLine());
                
                Console.WriteLine("NHap vao mau so:"); ;
                ms = int.Parse(Console.ReadLine());
            }
            //public Phanso(int x, int y)
            //{
            //    ts = x;
            //    ms = y;

            //}

        }

        static void Main(string[] args)
        {
            
            
            Phanso ob1 = new Phanso();

            ob1.nhap();
            ob1.show();

        }
    }
}
