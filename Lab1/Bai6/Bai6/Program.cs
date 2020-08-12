using System;

namespace Bai6
{
    class Program
    {
        public class myclass
        {
            int a;
            public myclass(int x)
            {
                a = x;
            }
            public void show()
            {
                Console.WriteLine("Gia tri cua a la:{0}", a);

            }
        }
        static void Main(string[] args)
        {
            //Console.WriteLine("Nhapvao:");
           // int a = int.Parse(Console.ReadLine());

            myclass ob1 = new myclass(4); //thay 4 = a ta se nhap duoc du lieu
            ob1.show();
            Console.ReadLine();
            return;
        }
    }
}
