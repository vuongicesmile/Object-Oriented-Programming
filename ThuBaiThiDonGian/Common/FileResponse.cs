using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    // để gửi chuyển đổi dạng 001
    [Serializable]
    public class FileResponse// đóng gói nội dung file vào 2 nội dung
    {
        public byte[] fileContent { get; private set; }

        // chứa nội dung thông tin, đường dẫn
        public FileInfo FileInfo { get; private set; }
            
        public FileResponse(string fileName)//truyền đường dẫn tuyệt đối URL
        {
            FileInfo = new FileInfo(fileName);
            using (FileStream file = new FileStream(fileName, FileMode.Open))// đọc file ra
            {
                //conver 01 01
                // chuyển về memorry
                MemoryStream stream = new MemoryStream();
                file.CopyTo(stream); // đã chứa dữ liệu của mảng
                //copy vào file content
                fileContent = stream.ToArray();

            }
        }
    }
}
