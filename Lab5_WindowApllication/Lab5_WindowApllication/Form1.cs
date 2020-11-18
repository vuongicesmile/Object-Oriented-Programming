using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5_WindowApllication
{
    public partial class Form1 : Form
    {
        QuanLySinhVien qlsv;
        public Form1()
        {
            InitializeComponent(); 
        }

        public void LoadListView()
        {
            lvSinhVien.Items.Clear();
            foreach (SinhVien sv in qlsv.danhsachsv)
            {
                ThemSVvaoLV(sv);
            }
        }

        #region Methods

        //lay thong tin sv tu controls them vao danhsachsv
        public SinhVien GetSVConTrols()
        {
            //public SinhVien(string ms, string ho, string ten, bool gt,
            //    DateTime ngaysinh, string lop, string socmnd,
            //    string sodt, string diachi, List<String> cn)
            SinhVien sv = new SinhVien();

            sv.Mssv = txbMSSV.Text;
            sv.Holot = txbHoLot.Text;
            sv.Ten = txbTen.Text;
            sv.Gioitinh = false;
            if (rdNam.Checked)
                sv.Gioitinh = true;
            sv.Ngaysinh = dtpNgaySinh.Value;
            sv.Lop = txbLop.Text;
            sv.Socmnd = txbCMND.Text;
            sv.Sodt = txbSoDT.Text;
            sv.Diachi = txbDiaChi.Text;

            for (int i = 0; i < clbChuyenNganh.Items.Count; i++)
            {
                if (clbChuyenNganh.GetItemChecked(i))
                {
                    sv.Chuyennganh.Add(clbChuyenNganh.Items[i].ToString());
                }
            }

            return sv;
        }
        
        //lay sinh vien tu listview
        public SinhVien GetSinhVienLV(ListViewItem lvitem)
        {
            SinhVien sv = new SinhVien();
            sv.Mssv = lvitem.SubItems[0].Text;
            sv.Holot = lvitem.SubItems[1].Text;
            sv.Ten = lvitem.SubItems[2].Text;
            bool gt = false;
            if (lvitem.SubItems[3].Text == "Nam")
                gt = true;
            sv.Gioitinh = gt;
            sv.Ngaysinh = DateTime.Parse(lvitem.SubItems[4].Text);
            sv.Lop = lvitem.SubItems[5].Text;
            sv.Socmnd = lvitem.SubItems[6].Text;
            sv.Sodt = lvitem.SubItems[7].Text;
            sv.Diachi = lvitem.SubItems[8].Text;
            string[] cn = lvitem.SubItems[9].Text.Split(',');
            foreach (string item in cn)
            {
                sv.Chuyennganh.Add(item);
            }
            return sv;
        }

        //them sv trong danhsachsv vao controls
        public void ThemSVcontrols(SinhVien sv)
        {
            txbMSSV.Text = sv.Mssv;
            txbHoLot.Text = sv.Holot;
            txbTen.Text = sv.Ten;
            if (sv.Gioitinh)
                rdNam.Checked = true;
            else
                rdNu.Checked = true;
            dtpNgaySinh.Value = sv.Ngaysinh;
            txbLop.Text = sv.Lop;
            txbCMND.Text = sv.Socmnd;
            txbSoDT.Text = sv.Sodt;
            txbDiaChi.Text = sv.Diachi;

            for (int i = 0; i < clbChuyenNganh.Items.Count; i++)
                this.clbChuyenNganh.SetItemChecked(i, false);

            foreach (string cn in sv.Chuyennganh)
            {
                for (int i = 0; i < clbChuyenNganh.Items.Count; i++)
                {
                    if (cn.CompareTo(clbChuyenNganh.Items[i]) == 0)
                        this.clbChuyenNganh.SetItemChecked(i, true);
                }
                
            }
        }

        //Them sv trong danhsachsv vao listview
        public void ThemSVvaoLV(SinhVien sv)
        {
            ListViewItem lvitem = new ListViewItem(sv.Mssv);
            lvitem.SubItems.Add(sv.Holot);
            lvitem.SubItems.Add(sv.Ten);
            string gt = "Nữ";
            if (sv.Gioitinh)
                gt = "Nam";
            lvitem.SubItems.Add(gt);
            lvitem.SubItems.Add(sv.Ngaysinh.ToShortDateString());
            lvitem.SubItems.Add(sv.Lop);
            lvitem.SubItems.Add(sv.Socmnd);
            lvitem.SubItems.Add(sv.Sodt);
            lvitem.SubItems.Add(sv.Diachi);
            string chuyennganh ="";
            foreach (string cn in sv.Chuyennganh)
            {
                chuyennganh += cn + ",";
            }
            chuyennganh = chuyennganh.Substring(0, chuyennganh.Length - 1);
            lvitem.SubItems.Add(chuyennganh);

            lvSinhVien.Items.Add(lvitem);
        }
        #endregion

        #region Events

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            SinhVien sv = GetSVConTrols();
            bool kq = qlsv.Sua(sv);
            if (kq)
            {
                MessageBox.Show("Sửa thành công !", "Thông Báo");
                LoadListView();
                qlsv.GhiFile();
            }
            else
                MessageBox.Show("Mã số SV không hợp lệ !", "Thông Báo");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int count = lvSinhVien.SelectedItems.Count;
            if(count > 0)
            {
                ListViewItem lvitem = lvSinhVien.SelectedItems[0];
                SinhVien sv = GetSinhVienLV(lvitem);
                SinhVien sv2 = null;
                bool kt = false;
                if ((MessageBox.Show("Bạn có thực sự muốn xóa sinh viên ms: " + sv.Mssv, "Thông báo", MessageBoxButtons.OKCancel)) == System.Windows.Forms.DialogResult.OK)
                {
                    foreach (SinhVien item in qlsv.danhsachsv)
                    {
                        if (sv.Mssv == item.Mssv)
                            kt = true;
                            sv2 = item;
                    }
                    if (kt)
                    {
                        qlsv.danhsachsv.Remove(sv2);
                        LoadListView();
                        qlsv.GhiFile();
                    }   
                }
            }
            else
                MessageBox.Show("Bạn chưa chọn Sinh Viên để xóa !");
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            frmTimKiem frmTK = new frmTimKiem();
            frmTK.ShowDialog();
        }

        private void btnThemSV_Click(object sender, EventArgs e)
        {
            if (txbMSSV.Text != "")
            {
                SinhVien sv = GetSVConTrols();
                bool kt = true;
                foreach (SinhVien item in qlsv.danhsachsv)
                {
                    if (sv.Mssv == item.Mssv)
                        kt = false;
                }
                if (kt)
                {
                    qlsv.danhsachsv.Add(sv);
                    qlsv.GhiFile();
                    MessageBox.Show("Thêm SV thành công", "Thông Báo");
                }
                else
                    MessageBox.Show("Mã số SV bị trùng", "Thông Báo");

                LoadListView();
            }
            else
                MessageBox.Show("Phải nhập đầy đủ thông tin, không bị lỗi ấy", "Thông Báo");
        }

        private void lvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = this.lvSinhVien.SelectedItems.Count;
            if (count > 0)
            {
                ListViewItem lvitem = lvSinhVien.SelectedItems[0];
                SinhVien sv = GetSinhVienLV(lvitem);
                ThemSVcontrols(sv);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            qlsv = new QuanLySinhVien();
            qlsv.DocTuFile();
            LoadListView();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

    }
}
