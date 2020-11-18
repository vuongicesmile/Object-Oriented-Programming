using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class SinhVien
    {
        private string mssv;
        private bool gioitinh;
        private string holot;
        private string ten;
        private DateTime ngaysinh;
        private string lop;
        private string socmnd;
        private string sodt;
        private string diachi;
        private List<String> chuyennganh;

        public string Mssv
        {
            get
            {
                return mssv;
            }

            set
            {
                mssv = value;
            }
        }

        public bool Gioitinh
        {
            get
            {
                return gioitinh;
            }

            set
            {
                gioitinh = value;
            }
        }

        public string Holot
        {
            get
            {
                return holot;
            }

            set
            {
                holot = value;
            }
        }

        public string Ten
        {
            get
            {
                return ten;
            }

            set
            {
                ten = value;
            }
        }

        public DateTime Ngaysinh
        {
            get
            {
                return ngaysinh;
            }

            set
            {
                ngaysinh = value;
            }
        }

        public string Lop
        {
            get
            {
                return lop;
            }

            set
            {
                lop = value;
            }
        }

        public string Socmnd
        {
            get
            {
                return socmnd;
            }

            set
            {
                socmnd = value;
            }
        }

        public string Sodt
        {
            get
            {
                return sodt;
            }

            set
            {
                sodt = value;
            }
        }

        public string Diachi
        {
            get
            {
                return diachi;
            }

            set
            {
                diachi = value;
            }
        }

        public List<string> Chuyennganh
        {
            get
            {
                return chuyennganh;
            }

            set
            {
                chuyennganh = value;
            }
        }

        public SinhVien()
        {
            Chuyennganh = new List<string>();
        }
        public SinhVien(string ms, string ho,string ten, bool gt, DateTime ngaysinh, string lop, string socmnd, string sodt, string diachi, List<String> cn)
        {
            this.Mssv = ms;
            this.Gioitinh = gt;
            this.Holot = ho;
            this.Ten = ten;
            this.Ngaysinh = ngaysinh;
            this.Lop = lop;
            this.Socmnd = socmnd;
            this.Sodt = sodt;
            this.Diachi = diachi;
            this.Chuyennganh = cn;
        }


        
    }

