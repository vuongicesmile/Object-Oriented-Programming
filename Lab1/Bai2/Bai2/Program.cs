using System;

namespace Bai1
{
    class Program
    {
        class myclass
        {
           public int a;
            public void set_a(int num)
            {
                a = num;
            }
            public int get_a()
            {
                return a;
            }
        }

        static void Main(string[] args)
        {
            myclass ob1 = new myclass();
            myclass ob2 = new myclass();
            ob1.a = 10;
            ob2.set_a(99);
            Console.WriteLine("Gia tri a cua doi tuong ob1: {0}", ob1.a);
            Console.WriteLine("Gia tri a cua doi tuong ob2: {0}", ob2.get_a());
            Console.ReadLine();
        }
    }
}
