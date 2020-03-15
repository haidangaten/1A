using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using DTO;
namespace BUS
{
    public class NgheBUS
    {
        NgheDAL nDAL;
        Nghe n;
       // private string _error;
        public int Insert(Nghe n)
        {
            nDAL = new NgheDAL();
            if (n.TenNghe != "")
            {
                int kq = nDAL.Insert(n);
                //Nếu hợp lệ thêm thông tin mới
                if (kq == 0)
                {
                    MessageBox.Show("Không thể thêm thông tin này. Vui lòng kiểm tra lại!", "Hệ thống quản lý thư viện - Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
                else
                    return 1;

            }
            else
            {
                MessageBox.Show("Phải nhập tên nghề. Vui lòng kiểm tra lại!", "Thông báo");
                return 0;
            }

        }
        public void hienThi(DataGridView dg,TextBox txt, Label lb)
        {
            nDAL = new NgheDAL();
            dg.DataSource =nDAL.Nghe_DS();
            txt.Text =nDAL.layMaNghe();
            dg.Columns[0].HeaderText = "STT";
            dg.Columns[1].HeaderText = "Mã nghề";
            dg.Columns[2].HeaderText = "Tên nghề";
            dg.Columns[0].Width = 70;
            dg.Columns[1].Width = 100;
            dg.Columns[2].Width = 180;
            lb.Text = "Có " + dg.RowCount.ToString() + " dòng dữ liệu.";

        }
    }
}
