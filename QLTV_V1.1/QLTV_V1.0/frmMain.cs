using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTV_V1._0
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //Cho phép hiện thị thời gian: giờ, phút, giây
            timer1.Enabled = true;
            timer1.Interval = 1000;
           
        }
        //Hiện thị thông tin ngày, giờ
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text= DateTime.Now.Hour.ToString() + ":" + String.Format("{0:00}", DateTime.Now.Minute) + ":" + String.Format("{0:00}", DateTime.Now.Second) + ", " + DateTime.Now.DayOfWeek.ToString() + ", " + DateTime.Now.ToLongDateString();
        }
        //Mục chọn LOẠI ĐỘC GIẢ
        private void loaiDGItem_Click(object sender, EventArgs e)
        {
            frmLoaiDG f = new frmLoaiDG();
            f.ShowDialog();
        }
        //Mục chọn NGHỀ
        private void ngheItem_Click(object sender, EventArgs e)
        {
            frmNghe f = new frmNghe();
            f.ShowDialog();
        }
        //Mục chọn tìm kiếm thông tin ĐỘC GIẢ
        private void tìmThôngTinĐộcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDocGia_TimKiem f = new frmDocGia_TimKiem();
            f.ShowDialog();
        }
    }
}
