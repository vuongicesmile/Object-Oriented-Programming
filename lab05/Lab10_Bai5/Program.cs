using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10_Bai5
{
    class Program
    {
        static void Main(string[] args)
        {
            string Filename = "D:\\1812790_NguyenKhanhLinh\\Lab10_Bai5\\Data.txt";
            Document doc = new Document("Hoc mon lap trinh huong doi tuong");
            doc.Write(Filename);
            doc.Read(Filename);
            Console.WriteLine("Du lieu trong file: {0}", doc.Data);
            Console.WriteLine("Du lieu sau khi ma hoa:");
            doc.MaHoa();
            Console.WriteLine(doc.Data);
            Console.WriteLine("Du lieu sau khi giai ma:");
            doc.GiaiMa();
            Console.WriteLine(doc.Data);
            doc.SoKyTu();
            doc.SoTu();
            Console.ReadLine();
        }
    }
}
