using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10_Bai5
{
    interface IODatabase
    {
        void Read(string Filename);
        void Write(string Filename);
        string Data { get; set; }
    }
    interface BaoMat
    {
        void MaHoa();
        void GiaiMa();
    }
}
