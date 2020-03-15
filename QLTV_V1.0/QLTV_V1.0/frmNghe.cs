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
namespace QLTV_V1._0
{
    public partial class frmNghe : Form
    {
        public frmNghe()
        {
            InitializeComponent();
        }
        //Hàm trả về danh sách các nghề có trong CSDL
        DataTable Nghe_DS()
        {
            SqlDataAdapter adap = new SqlDataAdapter("Nghe_DS", Program.strConn);
            DataTable ds = new DataTable();
            adap.Fill(ds);
            return ds;
        }
       //Hàm trả về danh sách nghề khi biết tên nghề, tìm gần đúng
        DataTable NgheDS_TenNghe(string tenNghe)
        {
            SqlDataAdapter adap = new SqlDataAdapter("NgheDS_TenNghe", Program.strConn);
            adap.SelectCommand.CommandType = CommandType.StoredProcedure;
            adap.SelectCommand.Parameters.Add("@TenNghe", SqlDbType.NVarChar).Value = tenNghe;
            DataTable ds = new DataTable();
            adap.Fill(ds);
            return ds;
        }
        //Hàm lấy mã nghề lớn nhất, có 3 ký tự
        string layMaNghe()
        {
            int tam = 0;
            string s1 = "00";
            SqlConnection dbConn = new SqlConnection(Program.strConn);
            dbConn.Open();
            SqlCommand dbCmd = new SqlCommand("MaNghe_Max", dbConn);
            try
            {
                tam = int.Parse(dbCmd.ExecuteScalar().ToString());
            }
            catch
            {
                tam = 0;
            }
            dbConn.Close();
            s1 = s1 + (tam+1).ToString();//Lấy mã nghề lớn nhất cộng thêm 1
            s1 = s1.Substring(s1.Length-3, 3);//Lấy 3 ký tự sau cùng
            return s1;
        }
        //Hàm thêm 1 nghề mới, trả về 1 nếu thêm thành công, ngược lại trả về 0
        public int ngheThem(string tenNghe)
        {
            SqlConnection dbConn = new SqlConnection(Program.strConn);
            dbConn.Open();
            SqlCommand dbCmd = new SqlCommand("Nghe_Them", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@TenNghe", SqlDbType.NVarChar).Value = tenNghe;
            dbCmd.Parameters.Add("@kq", SqlDbType.Int).Direction = ParameterDirection.Output;
            dbCmd.ExecuteNonQuery();
            return (int)dbCmd.Parameters["@kq"].Value;
        }
        //Hàm xoá 1 nghề, trả về 1 nếu thêm thành công, ngược lại trả về 0
        public int ngheXoa(string tenNghe)
        {
            SqlConnection dbConn = new SqlConnection(Program.strConn);
            dbConn.Open();
            SqlCommand dbCmd = new SqlCommand("Nghe_Xoa", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@TenNghe", SqlDbType.NVarChar).Value = tenNghe;
            dbCmd.Parameters.Add("@kq", SqlDbType.Int).Direction = ParameterDirection.Output;
            dbCmd.ExecuteNonQuery();
            return (int)dbCmd.Parameters["@kq"].Value;
        }
        //Hàm hiện thị thông tin GridView, lấy mã nghề kế tiếp
        void hienThi()
        {
            txtMaNghe.Text = layMaNghe();
            dataNghe.DataSource = Nghe_DS();
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
            txtMaNghe.Text = layMaNghe();
            txtTenNghe.Text = "";
            txtTenNghe.Focus();
            hienThi();
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (txtTenNghe.Text != "")
            {
                int kq = ngheThem(txtTenNghe.Text);
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
                int kq = ngheXoa(txtTenNghe.Text);
                //Nếu hợp lệ xoá thông tin
                if (kq == 1)
                    hienThi();
                else //Nếu lỗi, hiện thị thông báo
                    MessageBox.Show("Không thể xoá thông tin này. Vui lòng kiểm tra lại!", "Thông báo");
            }

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            dataNghe.DataSource = NgheDS_TenNghe(txtTenNghe.Text);//Tìm gần đúng
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
