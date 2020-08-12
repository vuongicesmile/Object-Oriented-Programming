using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10_Bai5
{
    class Document
    {
        string S;
        public Document(string str)
        {
            S = str;
        }
        public void Read(string Filename)
        {
            FileStream fs = new FileStream(Filename, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string text;
            S = "";
            while ((text = sr.ReadLine()) != null)
            {
                S = S + text;
            }
            sr.Close();
            fs.Close();
        }
        public void Write(string Filename)
        {
            FileStream fs = new FileStream(Filename, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(S);
            sw.Close();
            fs.Close();
        }
        public string Data
        {
            get { return S; }
            set { S = value; }
        }
        public void MaHoa()
        {
            string KQ = "";
            for (int i = 0; i < S.Length; i++)
            {
                KQ = KQ + (char)((int)S[i] + 5);
            }
            S = KQ;
        }
        public void GiaiMa()
        {
            string KQ = "";
            for (int i = 0; i < S.Length; i++)
            {
                KQ = KQ + (char)((int)S[i] - 5);
            }
            S = KQ;
        }
        public void SoKyTu()
        {
            Console.WriteLine("So ky tu: {0}", S.Length);
        }
        public void SoTu()
        {
            int d = 1;
            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] == ' ')
                    d = d + 1;
            }
            Console.WriteLine("So tu: {0}", d);
        }
    }
}
