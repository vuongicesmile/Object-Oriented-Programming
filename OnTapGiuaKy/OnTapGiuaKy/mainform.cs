using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnTapGiuaKy
{
    public partial class MainForm : Form
    {
        QuanLySinhVien qlsv;
        public MainForm()
        {
            InitializeComponent();
        }

        

        private void MainForm_Load(object sender, EventArgs e)
        {
            qlsv = new QuanLySinhVien(new TXTDataStorage("DanhSach.txt"));
          
            LoadListViewItem(qlsv.GetListSinhVien());
        }
        public SinhVien GetSvControls()
        {
            var sv = new SinhVien();

            sv.Mssv = txbMSSV.Text;
            sv.Holot = txbHoLot.Text;
            sv.Ten = txbTen.Text;
            sv.Gioitinh = "Nam";
            if (rdNu.Checked)
                sv.Gioitinh = "Nữ";
            sv.Ngaysinh = dtpNgaySinh.Value;
            sv.Lop = txbLop.Text;
            sv.Socmnd = txbCMND.Text;
            sv.Sodt = txbSoDT.Text;
            sv.Diachi = txbDiaChi.Text;

            for (int i = 0; i < clbChuyenNganh.Items.Count; i++)
            {
                if (clbChuyenNganh.GetItemChecked(i))
                {
                    sv.Monhoc.Add(clbChuyenNganh.Items[i].ToString());
                }
            }

            return sv;
        }
       

        public void LoadListViewItem(List<SinhVien> lsv)
        {
            lvSinhVien.Items.Clear();

            foreach (var sv in lsv)
            {
                ListViewItem lvitem = new ListViewItem(sv.Mssv);
                lvitem.SubItems.Add(sv.Holot);
                lvitem.SubItems.Add(sv.Ten);
                lvitem.SubItems.Add(sv.Gioitinh);
                lvitem.SubItems.Add(sv.Ngaysinh.ToString());
                lvitem.SubItems.Add(sv.Lop);
                lvitem.SubItems.Add(sv.Socmnd);
                lvitem.SubItems.Add(sv.Sodt);
                lvitem.SubItems.Add(sv.Diachi);
                lvitem.SubItems.Add(string.Join(",", sv.Monhoc));

                lvSinhVien.Items.Add(lvitem);
            }
        }

        private void btnThemSV_Click(object sender, EventArgs e)
        {
            var sv = GetSvControls();
            qlsv.AddOrUpdate(sv);
            LoadListViewItem(qlsv.GetListSinhVien());
        }

        
    }
}