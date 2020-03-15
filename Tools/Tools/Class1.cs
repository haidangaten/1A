using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Tools
{
    public class ChuoiKetNoi
    {
        public static string strConn = "Data Source=(local);Initial Catalog=QLTV;user=sa;pwd=abc";
    }
    public class NgheTool
    {
        //Hàm trả về danh sách các nghề có trong CSDL
        public DataTable Nghe_DS()
        {
            SqlDataAdapter adap = new SqlDataAdapter("Nghe_DS", ChuoiKetNoi.strConn);
            DataTable ds = new DataTable();
            adap.Fill(ds);
            return ds;
        }
        //Hàm trả về danh sách nghề khi biết tên nghề, tìm gần đúng
        public DataTable NgheDS_TenNghe(string tenNghe)
        {
            SqlDataAdapter adap = new SqlDataAdapter("NgheDS_TenNghe", ChuoiKetNoi.strConn);
            adap.SelectCommand.CommandType = CommandType.StoredProcedure;
            adap.SelectCommand.Parameters.Add("@TenNghe", SqlDbType.NVarChar).Value = tenNghe;
            DataTable ds = new DataTable();
            adap.Fill(ds);
            return ds;
        }
        //Hàm lấy mã nghề lớn nhất, có 3 ký tự
        public string layMaNghe()
        {
            int tam = 0;
            string s1 = "00";
            SqlConnection dbConn = new SqlConnection(ChuoiKetNoi.strConn);
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
        public int ngheThem(string tenNghe)
        {
            SqlConnection dbConn = new SqlConnection(ChuoiKetNoi.strConn);
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
            SqlConnection dbConn = new SqlConnection(ChuoiKetNoi.strConn);
            dbConn.Open();
            SqlCommand dbCmd = new SqlCommand("Nghe_Xoa", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@TenNghe", SqlDbType.NVarChar).Value = tenNghe;
            dbCmd.Parameters.Add("@kq", SqlDbType.Int).Direction = ParameterDirection.Output;
            dbCmd.ExecuteNonQuery();
            return (int)dbCmd.Parameters["@kq"].Value;
        }

    }
}
