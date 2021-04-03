using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;

namespace Server
{
    /*SEND LIST
     * Khi nhấn send List sẽ hiện ra 1 form mới 
     * Chọn file excel or CSDL
     * Đọc danh sách sinh viên ra
     * Gửi về client
     * Chọn thông tin sinh viên tương ứng và updates thông tin cá nhân
     */ 
    public partial class Serve : Form
    {
        IPEndPoint IP;
        Socket server;
        List<Socket> clientList;

        int counter = 0; // dem nguoc theo tung giay
        System.Timers.Timer countdown;

        private const int PORT = 9999;

        public Serve()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            countdown = new System.Timers.Timer();
            countdown.Elapsed += Countdown_Elapsed;
            countdown.Interval = 1000;// cu khoang 1 s ham se duoc goi
            Connect();
        }

    

        void StartServer()
        {
            try
            {
                /*
                 * While : Vong lap vo tan
                 *  server.Listen(100)
                 * Sẽ lắng nghe cùng lúc 100 client kết nối tới
                 */

                while (true)
                {
                    server.Listen(100);// Sẽ lắng nghe cùng lúc 100 client kết nối tới
                    /*
                     * Accept : Dung lai va cho 1 client ket noi de tiep tuc
                     * Lam cho luong bi block,chuong tirnh bi treo
                     * Solve : lap trinh bat dong bo or lap trinh theo luong
                     * Tao them 1 luong de chay doc lap voi luong chinh
                     * va 1 luong khac de lang nghe cung 1 luc
                     */
                    Socket client = server.Accept();//Đợi client, gửi thông tin socket vừa kết nối

                    // dùng socket client để nhắn tin qua lại với máy vưa kết nối
                    //đưa thông tin client lưu trữ vào mảng ClientList

                    clientList.Add(client);

                    //cần 1 luồng khác để nhận tin từ client gửi lên
                    //khai báo 1 luồng mới là recceice

                    Thread receive = new Thread(Receive);

                    receive.IsBackground = true;
                    receive.Start(client);
                    //in thông báo lên listView
                    AddMessage(client.RemoteEndPoint.ToString() + ":" + "Da ket noi ");

                }
            }
            catch
            {
                IP = new IPEndPoint(IPAddress.Any, PORT);
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }
        }


        /// <summary>
        /// ket noi toi server
        /// </summary>
        void Connect()
        {
           
            //IP : dia chi cua server
            IP = new IPEndPoint(IPAddress.Any, PORT);
            /*
             * Tao socket de ket noi
             */ 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            clientList = new List<Socket>();

            server.Bind(IP);
            Thread Listen = new Thread(StartServer);
            /*
             * IsBackGround :
             * Khi lap trinh luong, neu kiem soat luong khong ki,khi tao luong moi, khi tat van chay ngam.
             * Chi chay duoc 1 lan , lan sau chay se khong duoc nua
             * Khi nhan close form , tu dong dong luong de khong bi xung dot
             * Start : De goi luong 
             */ 
            Listen.IsBackground = true;
            Listen.Start();

            AddMessage("Server đã khởi động tại địa chỉ 127.0.0.1" + PORT);
        }
        void Close()
        {
            server.Close();
        }
        /// <summary>
        /// gui tin nhắn cho client
        /// </summary>
        void Send(Socket client)
        {
            if (!string.IsNullOrWhiteSpace(txtInput.Text))
            {

            }
        }
        /// <summary>
        /// Lắng nghe phản hồi từ phía Client
        /// </summary>
        void Receive(object obj)
        {
            Socket client = obj as Socket;


            try
            {
                /*
                 * Vòng lặp vô hạn để lắng nghe sự kiện
                 */ 
                while (true)
                {
                    //data : Bộ để lưu dữ liệu 0101
                    byte[] buffer = new byte[1024 * 1024*20];//20 MB
                    client.Receive(buffer);

                    object data = Deserialize(buffer);
                    ServerResponse container = data as ServerResponse;

                    switch (container.Type)
                    {
                        case ServerResponseType.SendStudent:
                            Student student = container.Data as Student;
                            AddMessage(client.RemoteEndPoint.ToString() + ": Thong tin sinh vien thao tac tren may: " + student.FullNameAndId);
                            break;
                        case ServerResponseType.SendFile:
                            FileResponse flie = container.Data as FileResponse;
                            string fileName = flie.FileInfo.Name;// sẽ có tên và phần mở trong của tập tin đó
                            AddMessage(client.RemoteEndPoint.ToString() + "da nhan bai lam,tap tin co ten " + fileName);
                            // lưu trữ mảng : Tiến hành tạo file
                            using (var fileStream = File.Create(fileName))
                            {//tạo lại file ban đầu và truyền lại nôi dung ban đầu
                                fileStream.Write(flie.fileContent, 0, flie.fileContent.Length);// content và kích thước
                            }


                            break;
                        case ServerResponseType.SendList:
                            break;
                        case ServerResponseType.SendString:
                            string computerName = (string)container.Data;

                            AddMessage(client.RemoteEndPoint.ToString() + "Ten may" + computerName);
                            break;
                        case ServerResponseType.BeginExam:
                            break;
                        case ServerResponseType.FinshExam:
                            break;
                        case ServerResponseType.LockClient:
                            break;
                        default:
                            break;
                    }

                }
            }
            catch
            {
                AddMessage(client.RemoteEndPoint.ToString() + ":" + "Đã đóng kết nối ");
                //xóa client 
                clientList.Remove(client);
                client.Close();// đóng socket giữa server và client
            }
        }
        void AddMessage(string mess)
        {
            lsvMain.Items.Add(new ListViewItem() { Text = mess });
        }
        /// <summary>
        /// phan manh dữ liệu ra
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        byte[] Serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, obj);
            return stream.ToArray();

        }
        /// <summary>
        /// Gom Mảnh dữ liệu, tạo thành đối tượng ban đàu
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(stream);
        }

        private void Serve_Load(object sender, EventArgs e)
        {

        }

        private void Serve_FormClosing(object sender, FormClosingEventArgs e)
        {
            Close();
        }

        private void btnSendStudents_Click(object sender, EventArgs e)
        {
            List<Student> listStudent = new List<Student>();
            listStudent.Add(new Student()
            {
                ID = "1813865",
                FristName= "Vuong",
                LastName = "Nguyen Quoc"
            });
            listStudent.Add(new Student()
            {
                ID = "1813866",
                FristName = "Viet",
                LastName = "Tran Quoc"
            });
            //B2 : gửi list về dưới client
            //b1 đóng gói dữ liệu (dùng hàm deselize)
            //đóng gói vào 2 cái type và data
            ServerResponse container = new ServerResponse();
            container.Type = ServerResponseType.SendList;
            container.Data = listStudent;
            // gửi dữ liệu về chuỗi này
            byte[] buffer = Serialize(container);
            // gửi bài thi cho tất cả mọi ng
            foreach (Socket client in clientList)
            {
                try
                {
                    client.Send(buffer);
                    AddMessage(client.RemoteEndPoint.ToString() + ":" + "Đã gửi danh sách sinh viên thành công ");
                }
                catch (Exception ex)
                {
                    AddMessage(client.RemoteEndPoint.ToString() + ":" + "Đã xảy ra sự cố trong quá trình truyền file.Đã đóng kết nối");
                    clientList.Remove(client);
                    client.Close();
                   
                }
            }

        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = dialog.FileName;// lấy đường dẫn file

                FileResponse fileResponse = new FileResponse(fileName);//lưu vào filename


                ServerResponse container = new ServerResponse();// đóng gói filename vào fileResspone
                container.Type = ServerResponseType.SendFile;
                // đóng gói nội dung file, và info
                container.Data = fileResponse;
              
                byte[] buffer = Serialize(container);  //dùng phtu biến container thành mảng buffer rồi gửi đi
                // gửi bài thi cho tất cả mọi ng
                foreach (Socket client in clientList)
                {
                    try
                    {
                        client.Send(buffer);//gửi dữ liệu đi
                        AddMessage(client.RemoteEndPoint.ToString() + ":" + "Đã gửi đề thi thành công ");
                    }
                    catch (Exception ex)
                    {
                        AddMessage(client.RemoteEndPoint.ToString() + ":" + "Đã xảy ra sự cố trong quá trình truyền file.Đã đóng kết nối");
                        clientList.Remove(client);
                        client.Close();

                    }
                }

            }
        }

        private void btnBegin_Click(object sender, EventArgs e)
        {
            int minute = Convert.ToInt32(txtSetTime.Text);
            counter = minute * 60;//tong cong bao nhieu giay

            countdown.Enabled = true;

            ServerResponse container = new ServerResponse();
            container.Type = ServerResponseType.BeginExam;
            container.Data = minute;


            byte[] buffer = Serialize(container);  //dùng phtu biến container thành mảng buffer rồi gửi đi
                                                   // gửi bài thi cho tất cả mọi ng
            foreach (Socket client in clientList)
            {
                try
                {
                    client.Send(buffer);//gửi dữ liệu đi
                    AddMessage(client.RemoteEndPoint.ToString() + ":" + "Đã bat dau lam bai thi ");
                }
                catch (Exception ex)
                {
                    AddMessage(client.RemoteEndPoint.ToString() + ":" + "Đã xảy ra sự cố trong quá trình truyền file.Đã đóng kết nối");
                    clientList.Remove(client);
                    client.Close();

                }
            }
        }
        private void Countdown_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            counter -= 1;
            int minute = counter / 60;
            int second = counter % 60;
            lblTimeLeft.Text = minute + ":" + second;

            if (counter ==0)
            {
                countdown.Stop();
                AddMessage("Server: Da het thoi gian lam bai");
            }  
        }
    }
}
