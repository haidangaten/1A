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
    public partial class frmLoaiDG : Form
    {
        SqlConnection dbConn;
        DataTable ds;
        SqlDataAdapter adap;
        //Hàm trả về danh sách các loại độc giả có trong CSDL, LoaiDG_DS là stored procedure
        DataTable LoaiDG_DS()
        {
            dbConn = new SqlConnection(Program.strConn);
            adap = new SqlDataAdapter();
            dbConn.Open();
            adap.SelectCommand = new SqlCommand("LoaiDG_DS", dbConn);
            adap.SelectCommand.CommandType = CommandType.StoredProcedure;
            ds = new DataTable();
            adap.Fill(ds);
            dbConn.Close();
            return ds;
        }

        public frmLoaiDG()
        {
            InitializeComponent();
        }
        //Hàm hiện thị thông tin của GridView
        void hienThi()
        {
            dataLoaiDG.DataSource = LoaiDG_DS();
            dataLoaiDG.Columns[0].HeaderText = "Mã loại ĐG";
            dataLoaiDG.Columns[1].HeaderText = "Tên loại ĐG";
            dataLoaiDG.Columns[0].Width = 120;
            dataLoaiDG.Columns[1].Width = 200;
            lblDongDL.Text = "Có " + (dataLoaiDG.RowCount-1).ToString() + " dòng dữ liệu.";
            
        }
        private void frmLoaiDG_Load(object sender, EventArgs e)
        {
            hienThi();
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                //Lưu các thông tin đã nhập từ GridView
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adap);
                adap.Update(ds);
                hienThi();
            }
            catch//Hiện thị thông báo lỗi
            {
                MessageBox.Show("Lỗi trong quá trình ghi dữ liệu. Vui lòng kiểm tra lại!", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Cảnh báo nếu người dùng xoá một dòng dữ liệu từ GridView
        private void dataLoaiDG_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn xoá dòng này? Dữ liệu sẽ được cập nhật khi click nút lệnh Ghi.", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1) == DialogResult.No)
                {
                    e.Cancel=true;
                }

        }
    }
}
