using Microsoft.VisualBasic.CompilerServices;
using System;

namespace Lab08_Bai01
{
    class Program
    {
        public class cosothaplucphan
        {
            public static string DoiHe(int inputNumber)
            {
                int[] ThapLucPhan = new int[100];
                int k = 0;
                do
                {
                    int du = inputNumber % 16;
                    ThapLucPhan[k] = du;
                    k++;
                    inputNumber = inputNumber / 16;
                } while (inputNumber > 0);
                string kq = string.Empty;
                for (int i = k - 1; i >= 0; i--)
                {
                    kq = ThapLucPhan[i].ToString();
                }
                return kq;
            }
            public void nhap()
            {
                Console.WriteLine("Nhap so nguyen he 10");
                int n = Int32.Parse(Console.ReadLine());

            }
            public void Xuat()
            {
                int n = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Ket qua la " + DoiHe(n));
            }
            //public static cosothaplucphan +(cosothaplucphan x, cosothaplucphan y)
            //    {
            //    private static String HexString;
            //public void k()
            //{
            //    SetHex("0A0B0C");
            //    String Hex = TinhTongHex();
            //    Console.WriteLine(Hex);
            //    Console.ReadLine();
            //}
            //private static void SetHex(String rHexStr)
            //{
            //    if (rHexStr.Length % 2 != 0)
            //    {

            //        HexString = rHexStr.Substring(0, rHexStr.Length - 1);
            //    }
            //    else
            //    {
            //        HexString = rHexStr;
            //    }
            //}
            //private static int HexToInt(String rHex)
            //{
            //    return Convert.ToInt32(rHex, 16);
            //}
            //private static String IntToHex(int rNum)
            //{
            //    return rNum.ToString("X");
            //}
            //private static String TinhTongHex()
            //{
            //    int Tong = 0;
            //    string Hex2;
            //    for (int i = 0; i < HexString.Length / 2; i++)
            //    {
            //        Hex2 = HexString.Substring(i * 2, 2);//tách ra 2 kí tự
            //        Tong += HexToInt(Hex2);//chuyển sang int và cộng vào tổng
            //    }
            //    return IntToHex(Tong);//chuyển tổng sang hex
            //}


        }


        static void Main(string[] args)
        {
            var x = new cosothaplucphan();
            x.nhap();
            x.Xuat();
            var y = new cosothaplucphan();
            y.nhap();
            y.Xuat();

            Console.ReadLine();
        }
    }
}
