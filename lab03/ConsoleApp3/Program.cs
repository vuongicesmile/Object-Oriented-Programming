using System;

public class cosonhiphan
{
    private int[] _ar = new int[8];
    public int[] ar { get { return _ar; } set { _ar = value; } }
    public cosonhiphan(int x)
    {
        int c = 7;
        if (x > 0)
        {
            ar[0] = 1;
        }
        else
        {
            ar[0] = 0;
        }
        while (c != 1)
        {
            ar[c] = Math.Abs(x % 2);
            x = x / 2;
            c--;
        }

    }
    public void input()
    {
        int kq;
        Console.WriteLine("nhap vao mot so nguyen: ");
        kq = Int32.Parse(Console.ReadLine());
        int c = 7;
        if (kq > 0)
        {
            ar[0] = 1;
        }
        else
        {
            ar[0] = 0;
        }
        while (c != 1)
        {
            ar[c] = Math.Abs(kq % 2);
            kq = kq / 2;
            c--;
        }
    }
    public void output()
    {
        Console.Write("day nhi phan : ");
        for (int i = 0; i < 8; i++)
        {
            Console.Write("{0} ", ar[i]);
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        var test = new cosonhiphan(20);
        test.output();
        Console.ReadLine();
    }
}