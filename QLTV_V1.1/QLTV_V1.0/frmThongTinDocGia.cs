using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTV_V1._0
{
    public partial class frmThongTinDocGia : Form
    {
        //Hàm trả về thông tin độc giả, kết quả tìm chính xác
        DataTable DocGiaDS_TimChinhXac(string soThe, string hoDG, string tenDG, string ngaySinh, string gioiTinh, string diaChi, string soCMT, string ngayLapThe, string ngayHetHan, string nghe, string loaiDG, string ghiChu)
        {
            SqlDataAdapter adap = new SqlDataAdapter("DocGia_TimKiemChinhXac", Program.strConn);
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
            return ds;
        }
        //Hàm trả về thông tin độc giả, kết quả tìm gần đúng
        DataTable DocGiaDS_TimTuongDoi(string soThe, string hoDG, string tenDG, string ngaySinh, string gioiTinh, string diaChi, string soCMT, string ngayLapThe, string ngayHetHan, string nghe, string loaiDG, string ghiChu)
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
            return ds;
        }
        //Hàm hiện thị thông tin của GridView
        void hienThi()
        {
            dataDG.Columns[0].HeaderText = "STT";
            dataDG.Columns[1].HeaderText = "Số thẻ";
            dataDG.Columns[2].HeaderText = "Họ độc giả";
            dataDG.Columns[3].HeaderText = "Tên";
            dataDG.Columns[4].HeaderText = "Ngày sinh";
            dataDG.Columns[5].HeaderText = "Giới tính";
            dataDG.Columns[6].HeaderText = "Địa chỉ";
            dataDG.Columns[7].HeaderText = "Số chứng minh";
            dataDG.Columns[8].HeaderText = "Ngày lập thẻ";
            dataDG.Columns[9].HeaderText = "Ngày hết hạn";
            dataDG.Columns[10].HeaderText = "Ghi chú";
            dataDG.Columns[11].HeaderText = "Nghề";
            dataDG.Columns[12].HeaderText = "Loại độc giả";
            dataDG.Columns[0].Width = 40;
            dataDG.Columns[1].Width = 90;
            dataDG.Columns[2].Width = 120;
            dataDG.Columns[3].Width = 70;
            dataDG.Columns[4].Width = 110;
            dataDG.Columns[5].Width = 90;
            dataDG.Columns[6].Width = 150;
            dataDG.Columns[7].Width = 130;
            dataDG.Columns[8].Width = 120;
            dataDG.Columns[9].Width = 120;
            dataDG.Columns[10].Width = 120;
            dataDG.Columns[11].Width = 100;
            dataDG.Columns[12].Width = 120;
            toolStripStatusLabel1.Text = "Có " + (dataDG.RowCount).ToString() + " dòng dữ liệu.";
        }

        public frmThongTinDocGia()
        {
            InitializeComponent();
        }

        private void frmThongTinDocGia_Load(object sender, EventArgs e)
        {
            if(BienDocGia.giatri==1)//Tìm kiếm chính xác, phạm vi tất cả
            {
                dataDG.DataSource = DocGiaDS_TimChinhXac(BienDocGia.soThe, BienDocGia.hoDG, BienDocGia.tenDG, BienDocGia.ngaySinh, BienDocGia.gioiTinh, BienDocGia.diaChi, BienDocGia.soCMT, BienDocGia.ngayLapThe, BienDocGia.ngayHetHan, BienDocGia.nghe, BienDocGia.loaiDG, BienDocGia.ghiChu);
                hienThi();
            }
            else if(BienDocGia.giatri == 2)//Tìm kiếm tương đối, phạm vi tất cả
            {
                dataDG.DataSource = DocGiaDS_TimTuongDoi(BienDocGia.soThe, BienDocGia.hoDG, BienDocGia.tenDG, BienDocGia.ngaySinh, BienDocGia.gioiTinh, BienDocGia.diaChi, BienDocGia.soCMT, BienDocGia.ngayLapThe, BienDocGia.ngayHetHan, BienDocGia.nghe, BienDocGia.loaiDG, BienDocGia.ghiChu);
                hienThi();
            }

        }
    }
}
