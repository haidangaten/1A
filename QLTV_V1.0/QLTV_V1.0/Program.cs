using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTV_V1._0
{
   static class BienDocGia
    {
        //Khởi tạo các thuộc tính của đối tượng Độc giả
        public static string soThe = null;
        public static string hoDG = null;
        public static string tenDG = null;
        public static string gioiTinh = null;
        public static string ngaySinh = null;
        public static string diaChi = null;
        public static string soCMT = null;
        public static string ngayLapThe = null;
        public static string ngayHetHan = null;
        public static string nghe = null;
        public static string loaiDG = null;
        public static string ghiChu = null;
        public static int giatri = 0;//Dựa vào giá trị để hiện thị chức năng tìm kiếm tương ứng
    } 

    static class Program
    {
        public static string strConn = "Data Source=(local);Initial Catalog=QLTV;user=sa;pwd=abc";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
