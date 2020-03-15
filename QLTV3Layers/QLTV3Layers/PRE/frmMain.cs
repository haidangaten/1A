using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTV3Layers
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void nghềToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNghe frm = new frmNghe();
            frm.ShowDialog();
        }

        private void traCứuThôngTinĐộcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDocGia_TimKiem frm = new frmDocGia_TimKiem();
            frm.ShowDialog();
        }
    }
}
