using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Serializable]
    /* 
     * To chuc luu cac kieu cua goi tin
     */
    public enum ServerResponseType
    {
        SendFile,
        SendList,
        SendStudent,
        SendString,
        BeginExam,
        FinshExam,
        LockClient
    }

    [Serializable]
    public class ServerResponse
    {
        /*
         * Luu tru cac the loai cua goi tin.
         */
        public ServerResponseType Type { get; set; }

        /*
         * object la cha cua tat ca doi tuong trong C#
         * Chua duoc tat ca cac kieu (string,file,..)
         */
        public object Data { get; set; }
    }

}
