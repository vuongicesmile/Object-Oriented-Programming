using System;

namespace Bai7
{
    class Program
    {
        static void Main(string[] args)
        {
            phanso ob1 = new phanso();
            phanso ob2 = new phanso(5);
            phanso ob3 = new phanso(6,7);
            ob1.show();
            ob2.show();
            ob3.show();
            Console.ReadLine();

            
        }
    }
}
