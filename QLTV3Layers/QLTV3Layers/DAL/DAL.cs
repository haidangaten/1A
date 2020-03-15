using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DTO;
namespace DAL
{
    public static class KetNoiCSDL
    {
        public static string strConn = "Data Source=(local);Initial Catalog=QLTV;user=sa;pwd=abc";
        public static SqlConnection _conn;
        public static bool kiemTraKN()
        {
            SqlConnection _conn = new SqlConnection(strConn);
            try
            {
                _conn.Open();
                return true;
            }
            catch
            {
                MessageBox.Show("Không thể kết nối với máy chủ CSDL. Vui lòng kiểm tra lại!", "Hệ thống quản lý thư viện - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    }
    public class NgheDAL
    {
        bool kt = KetNoiCSDL.kiemTraKN();
        public int Insert(Nghe n)
        {

            if (kt == false) return 0;
            KetNoiCSDL._conn = new SqlConnection(KetNoiCSDL.strConn);
            SqlCommand cmd = new SqlCommand("Nghe_Them", KetNoiCSDL._conn);
            KetNoiCSDL._conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenNghe", SqlDbType.NVarChar).Value = n.TenNghe;
            cmd.Parameters.Add("@kq", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@kq"].Value;
        }
    public  DataTable Nghe_DS()
        {
            
            KetNoiCSDL._conn = new SqlConnection(KetNoiCSDL.strConn);
            SqlDataAdapter adap = new SqlDataAdapter("Nghe_DS", KetNoiCSDL._conn);
            DataTable ds = new DataTable();
            adap.Fill(ds);
            return ds;
        }
        //Hàm trả về danh sách nghề khi biết tên nghề, tìm gần đúng
        public DataTable NgheDS_TenNghe(Nghe n)
        {
            
            SqlDataAdapter adap = new SqlDataAdapter("NgheDS_TenNghe", KetNoiCSDL._conn);
            adap.SelectCommand.CommandType = CommandType.StoredProcedure;
            adap.SelectCommand.Parameters.Add("@TenNghe", SqlDbType.NVarChar).Value = n.TenNghe;
            DataTable ds = new DataTable();
            adap.Fill(ds);
            return ds;
        }
        //Hàm lấy mã nghề lớn nhất, có 3 ký tự
        public string layMaNghe()
        {
            int tam = 0;
            string s1 = "00";
            SqlConnection dbConn = new SqlConnection(KetNoiCSDL.strConn);
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
            s1 = s1 + (tam + 1).ToString();//Lấy mã nghề lớn nhất cộng thêm 1
            s1 = s1.Substring(s1.Length - 3, 3);//Lấy 3 ký tự sau cùng
            return s1;
        }
        //Hàm thêm 1 nghề mới, trả về 1 nếu thêm thành công, ngược lại trả về 0
        public int ngheThem(Nghe n)
        {
            SqlConnection dbConn = new SqlConnection(KetNoiCSDL.strConn);
            dbConn.Open();
            SqlCommand dbCmd = new SqlCommand("Nghe_Them", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@TenNghe", SqlDbType.NVarChar).Value = n.TenNghe;
            dbCmd.Parameters.Add("@kq", SqlDbType.Int).Direction = ParameterDirection.Output;
            dbCmd.ExecuteNonQuery();
            return (int)dbCmd.Parameters["@kq"].Value;
        }
        //Hàm xoá 1 nghề, trả về 1 nếu thêm thành công, ngược lại trả về 0
        public int ngheXoa(Nghe n)
        {
            SqlConnection dbConn = new SqlConnection(KetNoiCSDL.strConn);
            dbConn.Open();
            SqlCommand dbCmd = new SqlCommand("Nghe_Xoa", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@MaNghe", SqlDbType.NVarChar).Value = n.MaNghe;
            dbCmd.Parameters.Add("@kq", SqlDbType.Int).Direction = ParameterDirection.Output;
            dbCmd.ExecuteNonQuery();
            return (int)dbCmd.Parameters["@kq"].Value;
        }

    }
}
