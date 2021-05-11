using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Project3_MainWF.Forms
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        public MainForm()
        {
            InitializeComponent();
            date.Text = DateTime.Now.ToShortDateString();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private Form FormIsOpened()
        {
            FormCollection fc = Application.OpenForms;

            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmNhapHang frm = new frmNhapHang();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmBanHang frm = new frmBanHang();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmPhieuThu frm = new frmPhieuThu();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmPhieuChi frm = new frmPhieuChi();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frm_BaoCaoChiTietCongNoKh frm = new frm_BaoCaoChiTietCongNoKh();
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frm_TheKhoHang frm = new frm_TheKhoHang();
            frm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frm_TongHopNhapTon frm = new frm_TongHopNhapTon();
            frm.Show();
        }
    }
}