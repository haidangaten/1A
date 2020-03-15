using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
//using MyTools;
using Tools;
namespace QLTV_V1._0
{
    public partial class frmNghe : Form
    {
        Tools.NgheTool n = new NgheTool();
        public frmNghe()
        {
            InitializeComponent();
        }
        //Hàm hiện thị thông tin GridView, lấy mã nghề kế tiếp
        void hienThi()
        {
            txtMaNghe.Text =n.layMaNghe();
            dataNghe.DataSource = n.Nghe_DS();
            dataNghe.Columns[0].HeaderText = "STT";
            dataNghe.Columns[1].HeaderText = "Mã nghề";
            dataNghe.Columns[2].HeaderText = "Tên nghề";
            dataNghe.Columns[0].Width = 70;
            dataNghe.Columns[1].Width = 100;
            dataNghe.Columns[2].Width = 180;
            lblDongDL.Text = "Có " + dataNghe.RowCount.ToString() + " dòng dữ liệu.";

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmNghe_Load(object sender, EventArgs e)
        {
            
            hienThi();
            txtTenNghe.Focus();
        }

        private void dataNghe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNghe.Text = dataNghe.CurrentRow.Cells[1].Value.ToString();
            txtTenNghe.Text = dataNghe.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaNghe.Text = n.layMaNghe();
            txtTenNghe.Text = "";
            txtTenNghe.Focus();
            hienThi();
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (txtTenNghe.Text != "")
            {
                int kq = n.ngheThem(txtTenNghe.Text);
                //Nếu hợp lệ thêm thông tin mới
                if (kq == 1)
                    hienThi();
                else //Nếu lỗi trùng khoá, hiện thị thông báo
                    MessageBox.Show("Không thể thêm thông tin này. Vui lòng kiểm tra lại!", "Thông báo");
            }
            else
            {
                MessageBox.Show("Phải nhập tên nghề. Vui lòng kiểm tra lại!", "Thông báo");
                txtTenNghe.Focus();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn xoá dòng thông tin này?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                int kq = n.ngheXoa(txtTenNghe.Text);
                //Nếu hợp lệ xoá thông tin
                if (kq == 1)
                    hienThi();
                else //Nếu lỗi, hiện thị thông báo
                    MessageBox.Show("Không thể xoá thông tin này. Vui lòng kiểm tra lại!", "Thông báo");
            }

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            dataNghe.DataSource = n.NgheDS_TenNghe(txtTenNghe.Text);//Tìm gần đúng
            dataNghe.Columns[0].HeaderText = "STT";
            dataNghe.Columns[1].HeaderText = "Mã nghề";
            dataNghe.Columns[2].HeaderText = "Tên nghề";
            dataNghe.Columns[0].Width = 70;
            dataNghe.Columns[1].Width = 100;
            dataNghe.Columns[2].Width = 180;
            lblDongDL.Text = "Có " + dataNghe.RowCount.ToString() + " dòng dữ liệu.";//Hiện thị số dòng dữ liệu của GridView

        }
    }
}
