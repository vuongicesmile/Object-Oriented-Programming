using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using Common;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;

namespace Client
{
    public partial class Client : Form
    {
        private const int serverPort = 9999;
        IPEndPoint IP;// địa chỉ ip của sever
        Socket client;

        System.Timers.Timer countdown;
            int counter = 0;

        public Client()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;
            btnFinishExam.Enabled = true;

            countdown = new System.Timers.Timer();
            countdown.Interval = 1000;// cu moi 1 s goi ham countdown_elapsed 1 lan
            countdown.Elapsed += Countdown_Elapsed;
     
        }

     


        /// <summary>
        /// ket noi toi server
        /// </summary>
        void Connect(string hostname,int port)
        {

            //IP : dia chi cua server
            IP = new IPEndPoint(IPAddress.Parse(hostname), port);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string computerName = System.Environment.MachineName;// lấy về tên máy
            try
            {
                client.Connect(IP);
                this.Text = computerName + " .Kết nối tới server thành công";

                ServerResponse container = new ServerResponse()
                {
                    Type = ServerResponseType.SendString,
                    Data = computerName
                };
                client.Send(Serialize(container));
            }
            catch
            {
                MessageBox.Show("Khong the ket noi server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // tạo thread khác để lắng nghe phản hồi từ server
            Thread listen = new Thread(Receive);
            listen.IsBackground = true;
            listen.Start();

        }
        /// <summary>
        /// dong ket noi hien tai
        /// </summary>
        void Close()
        {
            if (client != null)
            {
                client.Close();
            }
          
        }
        /// <summary>
        /// gui tin
        /// </summary>
     
        /// <summary>
        /// nhan tin
        /// </summary>
        void Receive()
        {
            try
            {
                while (true)
                {


                    byte[] data = new byte[1024 * 1024*20];
                    client.Receive(data);// đợi cho đến khi server phản hồi để chayh tiếp

                    object dat = Deserialize(data);
                    // dùng as để ép kiểu
                    ServerResponse container = dat as ServerResponse;

                    switch (container.Type)
                    {
                        case ServerResponseType.SendFile:

                            FileResponse fileResponse = container.Data as FileResponse;// chuyển đổi kiểu về ban đầu

                            string fileName = fileResponse.FileInfo.Name;// sẽ có tên và phần mở trong của tập tin đó
                            lblDeThi.Text = fileName;//lây s tên file đề kiểm tra
                            // lưu trữ mảng : Tiến hành tạo file
                            using (var fileStream = File.Create(fileName))
                            {//tạo lại file ban đầu và truyền lại nôi dung ban đầu
                                fileStream.Write(fileResponse.fileContent, 0, fileResponse.fileContent.Length);// content và kích thước
                            }

                            // sẽ có tập tin lưu lại client
                            break;
                        case ServerResponseType.SendList:

                            List<Student> listStudent = container.Data as List<Student>;
                            cbDSThi.DataSource = listStudent;
                            cbDSThi.DisplayMember = "FullNameAndId";
                            break;
                        case ServerResponseType.SendString:
                            break;
                        case ServerResponseType.BeginExam:
                            int minute = (int)container.Data;
                            counter = minute * 60;
                            int hour = minute / 60;
                            lblThoiGian.Text = $"{hour} gio, {minute % 60} phut";
                            countdown.Enabled = true;
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
            catch(Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình nhận phản hồi từ server.Đóng kết nối" + ex.Message);
                Close();
            }
        }
       
        /// <summary>
        /// phan manh
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
        /// gom manh lai
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(stream);
        }

        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            Close();
        }

        private void btnConnectToServer_Click(object sender, EventArgs e)
        {
            //lấy địa chỉ ip nhập vào
            string IP = txtServerIP.Text;
            Connect(IP, serverPort);

        }
        // hiển thị thông tin của sinh viên
        private void cbDSThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDSThi.SelectedItem != null)
            {
                Student selectedStudent = cbDSThi.SelectedItem as Student;
                lblHoTen.Text = selectedStudent.FullName;
                lblMaSo.Text = selectedStudent.ID;
            }
        }
        //can ip
        //can socket

        private void Countdown_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            counter -= 1;//tong so giay
            int minute = counter / 60;
            int second = counter % 60;

            lblThoiGianConLai.Text = $"{minute} phut,{second} giay";

            //kiem tra nhac moi 30phut  => 30 *60 = 1800s
            if(counter >= 1800 && counter % 1800 ==0)
            {
                MessageBox.Show($"ban con {minute} phut va {second} de lam bai ");
            }
            if (counter == 300)
            {
                MessageBox.Show("con 5 phut");
            }
            if (counter ==0)
            {
                countdown.Stop();
                MessageBox.Show("da het thoi gian lam bai.Thu bai");
                FileResponse file = new FileResponse("1813865_NguyenQuocVuong.zip");

                ServerResponse container = new ServerResponse()
                {
                    Type = ServerResponseType.SendFile,
                    Data = file
                };
                try
                {
                    client.Send(Serialize(container));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }

            //tim kiem trong thu muc hien tai file.zip
            //yeu cau sinh vien nen folder
            //gui file
        }

        private void btnSendStudentInfo_Click(object sender, EventArgs e)
        {
            if (cbDSThi.SelectedItem != null)
            {
                Student student = cbDSThi.SelectedItem as Student;
                ServerResponse container = new ServerResponse();
                container.Type = ServerResponseType.SendStudent;
                container.Data = student;

                try
                {
                    client.Send(Serialize(container));
                    MessageBox.Show("Thong tin sinh vien da duoc gi nhan");
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Co loi trong qua trinh gui thong tin sinh vien len server");
                    Close();
                }
            }
        }
    }
}
