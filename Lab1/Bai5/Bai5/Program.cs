using System;

namespace Bai5
{
    class Program
    {
        public class myclass
        {
            int a;
            public myclass()
            {
                a = 10;

            }
            public void show()
            {
                Console.WriteLine("Gia tri cua a la:{0}", a);
            }
        }
        static void Main(string[] args)
        {
            myclass ob1 = new myclass();
            ob1.show();
            Console.ReadLine();
            return;
        }
    }
}
