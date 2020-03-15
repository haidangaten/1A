using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;

namespace QLTV3Layers
{
    public partial class frmNghe : Form
    {
        NgheBUS nBus=new NgheBUS (); Nghe n;
        public frmNghe()
        {
            InitializeComponent();
        }
        private void frmNghe_Load(object sender, EventArgs e)
        {
            nBus.hienThi(dataNghe,txtMaNghe,lblDongDL);
            txtTenNghe.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
           

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            n = new Nghe();
            nBus = new NgheBUS();
            n.MaNghe = txtMaNghe.Text;
            n.TenNghe = txtTenNghe.Text;
            int kq = nBus.Insert(n);
            nBus.hienThi(dataNghe, txtMaNghe, lblDongDL);
        }
    }
}
