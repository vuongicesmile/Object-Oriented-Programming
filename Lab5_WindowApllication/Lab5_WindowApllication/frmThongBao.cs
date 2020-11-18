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
    public partial class frmThongBao : Form
    {
        public frmThongBao()
        {
            InitializeComponent();
        }

        public void SetText(string text)
        {
            lbThongBao.Text = text;
        }
    }
}
