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
    public partial class frmDocGia_TimKiem : Form
    {
        public frmDocGia_TimKiem()
        {
            InitializeComponent();
        }
        //Hàm trả về danh sách các nghề có trong CSDL, Nghe_DS là một stored procedure
        DataTable Nghe_DS()
        {
            SqlDataAdapter adap = new SqlDataAdapter("Nghe_DS", Program.strConn);
            DataTable ds = new DataTable();
            adap.Fill(ds);
            return ds;
        }
        //Hàm trả về danh sách các loại độc giả có trong CSDL, LoaiDG_DS là một stored procedure
        DataTable LoaiDG_DS()
        {
            SqlDataAdapter adap = new SqlDataAdapter("LoaiDG_DS", Program.strConn);
            DataTable ds = new DataTable();
            adap.Fill(ds);
            return ds;
        }
        //Hàm kiểm tra kết quả tìm kiếm chính xác, trả về true nếu có, ngược lại trả về false
        bool kiemTraDocGiaDS_TimChinhXac(string soThe, string hoDG, string tenDG, string ngaySinh,string gioiTinh,string diaChi, string soCMT, string ngayLapThe, string ngayHetHan, string nghe, string loaiDG, string ghiChu)
        {
            SqlDataAdapter adap = new SqlDataAdapter("DocGia_TimKiemChinhXac", Program.strConn);
            adap.SelectCommand.CommandType = CommandType.StoredProcedure;
            adap.SelectCommand.Parameters.Add("@SoThe", SqlDbType.Char).Value = soThe;
            adap.SelectCommand.Parameters.Add("@HoDG", SqlDbType.NVarChar).Value =hoDG ;
            adap.SelectCommand.Parameters.Add("@TenDG", SqlDbType.NVarChar).Value = tenDG;
            adap.SelectCommand.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = ngaySinh;
            adap.SelectCommand.Parameters.Add("@GioiTinh", SqlDbType.Char).Value =gioiTinh ;
            adap.SelectCommand.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = diaChi;
            adap.SelectCommand.Parameters.Add("@SoCMT", SqlDbType.NVarChar).Value = soCMT;
            adap.SelectCommand.Parameters.Add("@NgayLapThe", SqlDbType.Date).Value =ngayLapThe ;
            adap.SelectCommand.Parameters.Add("@NgayHetHan", SqlDbType.Date).Value = ngayHetHan;
            adap.SelectCommand.Parameters.Add("@GhiChu", SqlDbType.NVarChar).Value = ghiChu;
            adap.SelectCommand.Parameters.Add("@MaNghe", SqlDbType.Char).Value = nghe;
            adap.SelectCommand.Parameters.Add("@MaLDG", SqlDbType.Char).Value =loaiDG ;
            DataTable ds = new DataTable();
            adap.Fill(ds);
            if (ds.Rows.Count > 0)
                return true;
            else
                return false;
        }
        //Hàm kiểm tra kết quả tìm kiếm gần đúng, trả về true nếu có, ngược lại trả về false
        bool kiemTraDocGiaDS_TimTuongDoi(string soThe, string hoDG, string tenDG, string ngaySinh, string gioiTinh, string diaChi, string soCMT, string ngayLapThe, string ngayHetHan, string nghe, string loaiDG, string ghiChu)
        {
            SqlDataAdapter adap = new SqlDataAdapter("DocGia_TimKiemTuongDoi", Program.strConn);
            adap.SelectCommand.CommandType = CommandType.StoredProcedure;
            adap.SelectCommand.Parameters.Add("@SoThe", SqlDbType.Char).Value = soThe;
            adap.SelectCommand.Parameters.Add("@HoDG", SqlDbType.NVarChar).Value = hoDG;
            adap.SelectCommand.Parameters.Add("@TenDG", SqlDbType.NVarChar).Value = tenDG;
            adap.SelectCommand.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = ngaySinh;
            adap.SelectCommand.Parameters.Add("@GioiTinh", SqlDbType.Char).Value = gioiTinh;
            adap.SelectCommand.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = diaChi;
            adap.SelectCommand.Parameters.Add("@SoCMT", SqlDbType.NVarChar).Value = soCMT;
            adap.SelectCommand.Parameters.Add("@NgayLapThe", SqlDbType.Date).Value = ngayLapThe;
            adap.SelectCommand.Parameters.Add("@NgayHetHan", SqlDbType.Date).Value = ngayHetHan;
            adap.SelectCommand.Parameters.Add("@GhiChu", SqlDbType.NVarChar).Value = ghiChu;
            adap.SelectCommand.Parameters.Add("@MaNghe", SqlDbType.Char).Value = nghe;
            adap.SelectCommand.Parameters.Add("@MaLDG", SqlDbType.Char).Value = loaiDG;
            DataTable ds = new DataTable();
            adap.Fill(ds);
            if (ds.Rows.Count > 0)
                return true;
            else
                return false;
        }

        private void frmDocGia_TimKiem_Load(object sender, EventArgs e)
        {
            comboNghe.DataSource = Nghe_DS();
            comboNghe.DisplayMember = "TenNghe";
            comboNghe.ValueMember = "MaNghe";
            comboLoaiDG.DataSource = LoaiDG_DS();
            comboLoaiDG.DisplayMember = "TenLDG";
            comboLoaiDG.ValueMember = "MaLDG";
            comboNghe.Text = "-- Chọn nghề --";
            comboLoaiDG.Text = "-- Chọn loại độc giả --";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            //Gán các giá trị tương ứng
            if (txtSoThe.Text != "")
                BienDocGia.soThe = txtSoThe.Text;
            if (txtHoDG.Text != "")
                BienDocGia.hoDG = txtHoDG.Text;
            if (txtTenDG.Text != "")
                BienDocGia.tenDG = txtTenDG.Text;
            if (raNam.Checked)
                BienDocGia.gioiTinh = "1";
            else if (raNu.Checked)
                BienDocGia.gioiTinh = "0";
            if (txtNgaySinh.Text != "")
                BienDocGia.ngaySinh = txtNgaySinh.Text;
            if (txtDiaChi.Text != "")
                BienDocGia.diaChi = txtDiaChi.Text;
            if (txtCMT.Text != "")
                BienDocGia.soCMT = txtCMT.Text;
            if (txtNgayLapThe.Text != "")
                BienDocGia.ngayLapThe = txtNgayLapThe.Text;
            if (txtNgayHetHan.Text != "")
                BienDocGia.ngayHetHan = txtNgayHetHan.Text;
            if (comboNghe.Text != "-- Chọn nghề --")
                BienDocGia.nghe = comboNghe.SelectedValue.ToString();
            if (comboLoaiDG.Text != "-- Chọn loại độc giả --")
                BienDocGia.loaiDG = comboLoaiDG.SelectedValue.ToString();
            if (txtGhiChu.Text != "")
                BienDocGia.ghiChu = txtGhiChu.Text;
            bool kt = false;//Kiểm tra có dữ liệu tìm kiếm hay không?
            if ((raChinhXac.Checked) && (raTatCa.Checked))
            {
                BienDocGia.giatri = 1;
                kt = kiemTraDocGiaDS_TimChinhXac(BienDocGia.soThe, BienDocGia.hoDG, BienDocGia.tenDG, BienDocGia.ngaySinh, BienDocGia.gioiTinh, BienDocGia.diaChi, BienDocGia.soCMT, BienDocGia.ngayLapThe, BienDocGia.ngayHetHan, BienDocGia.nghe, BienDocGia.loaiDG, BienDocGia.ghiChu);

            }
            else if ((raTuongDoi.Checked) && (raTatCa.Checked))
            { 
                BienDocGia.giatri = 2;
                kt = kiemTraDocGiaDS_TimTuongDoi(BienDocGia.soThe, BienDocGia.hoDG, BienDocGia.tenDG, BienDocGia.ngaySinh, BienDocGia.gioiTinh, BienDocGia.diaChi, BienDocGia.soCMT, BienDocGia.ngayLapThe, BienDocGia.ngayHetHan, BienDocGia.nghe, BienDocGia.loaiDG, BienDocGia.ghiChu);
            }
            if (kt == false)
                MessageBox.Show("Không có thông tin độc giả cần tìm. Vui lòng kiểm tra lại!","Thông báo");
            else
            {
                frmThongTinDocGia f = new frmThongTinDocGia();
                f.ShowDialog();
            }

        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            //Khởi tạo lại các giá trị ban đầu
            frmDocGia_TimKiem_Load(sender, e);
            raNam.Checked = false;
            raNu.Checked = false;
            txtSoThe.Text = null;
            txtHoDG.Text = null;
            txtTenDG.Text = null;
            txtNgaySinh.Text = null;
            txtDiaChi.Text = null;
            txtCMT.Text = null;
            txtNgayHetHan.Text = null;
            txtNgayLapThe.Text = null;
            txtGhiChu.Text = null;
            //BienDocGia.soThe = null;
            //BienDocGia.hoDG = null;
            //BienDocGia.tenDG = null;
            //BienDocGia.ngaySinh = null;
            //BienDocGia.gioiTinh = null;
            //BienDocGia.diaChi = null;
            //BienDocGia.soCMT = null;
            //BienDocGia.ngayLapThe = null;
            //BienDocGia.ngayHetHan = null;
            //BienDocGia.nghe = null;
            //BienDocGia.loaiDG = null;
            //BienDocGia.ghiChu = null;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
