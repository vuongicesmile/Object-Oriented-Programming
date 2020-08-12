using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace nguyenquocvuong_1813865
{
    class giaovien
    {

        public class Nguoi
        {
            string hotendem;
            string ten;
            string maso;

            public string HOTENDEM { get => hotendem; set => hotendem = value; }
            public string TEN { get => ten; set => ten = value; }
            public string MASO { get => maso; set => maso = value; }
        }
        public class Giaovien : Nguoi
        {
            string id;//("xac dinh la giao vien")
            string bomon;

            public string ID { get => id; set => id = value; }
            public string BOMON { get => bomon; set => bomon = value; }
            
            public Giaovien()
            {

            }
            public Giaovien(string x)
            {
                HOTENDEM = "Nguyen Van";
                TEN = "A";
                MASO = "####";
                ID = "###";
                BOMON = "Test";
            }
            public Giaovien(string x,string y)
            {
                HOTENDEM = "Nguyen Van";
                TEN = "A";
                MASO = "####";
                ID = "###";
                BOMON = "Test";
            }
            public Giaovien(string x, string y,string z)
            {
                HOTENDEM = "Nguyen Van";
                TEN = "A";
                MASO = "####";
                ID = "###";
                BOMON = "Test";
            }
            public Giaovien(string x, string y, string z,string t)
            {
                HOTENDEM = "Nguyen Van";
                TEN = "A";
                MASO = "####";
                ID = "###";
                BOMON = "Test";
            }
            public override string ToString()
            {
                return string.Format("hotendem{0} ten {1} ma so {2} id {3} bomon {4}",HOTENDEM,TEN,MASO, id, bomon);
            }

        }
        interface IODatabase
        {
            void Read(string Filename);

            void Write(string Filename);
            string Data { get; set; }
        }
        interface BaoMat
        {
            void Mahoa();
            void GiaiMa();
        }
       
        public class Document :IODatabase
        {
            string s;
            public Document(string str)
            {
                s = str;
            }
            public void Read(string filename)
            {
                FileStream fs = new FileStream(filename, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                string text;
                s = "";
                while(( text=sr.ReadLine()) !=null)
                {
                    s = s + text;
                }
                sr.Close();
                fs.Close();

            }
            public void Write(string filename)
            {
                FileStream fs;
                fs = new FileStream(filename, FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(s);
                
                sw.Close();
                fs.Close();

            }
            public string Data
            {
                get 
                { return s; }
                set { s = value; }
            }
            public void MaHoa()
            {
                string KQ = "";
                for (int i = 0; i < s.Length; i++)
                    KQ = KQ + (char)((int)s[i] + 5);
                s = KQ;
            }
            public void GiaiMa()
            {
                string KQ = "";
                for (int i=0;i<s.Length;i++)
                    KQ = KQ + (char)((int)s[i] + 5);
                s = KQ;
            }
        }

        public class QLGV : giaovien
        {
            int siso;
            int max;
            giaovien[] s;


            public QLGV()
            {

            }
            public void Nhap()
            {

                Console.WriteLine("Nhap ho ten:");
                Console.ReadLine();
            }
            public void Xuat()
            {

            }

        }
    }
    
}
