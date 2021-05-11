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
using System.ComponentModel.DataAnnotations;
using System.IO;
using DevExpress.XtraLayout.Helpers;
using DevExpress.XtraLayout;
using Project3_MainWF.Data;
using DevExpress.XtraReports.UI;

namespace Project3_MainWF.Forms
{
    public partial class frmPhieuChi : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private Project3Entities2 db;
        public frmPhieuChi()
        {
            InitializeComponent();
            db = new Project3Entities2();
            fillComboBox();
        }

        void fillComboBox()
        {
            foreach(var x in db.DMKHs.ToList())
            {
                comboBox1.Items.Add(x.MaKH);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int index = Convert.ToInt32(comboBox1.SelectedItem);

            // edit to all other textbox
            DMKH kh = db.DMKHs.FirstOrDefault(p => p.MaKH == index);
            txtName.Text = kh.TenKH;
            txtDiaChi.Text = kh.DiaChi;
            dtCreateDate.Value = DateTime.UtcNow;



        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            // save to database
            PhieuChi newPhieuChi = new PhieuChi();
            newPhieuChi.MaKH = comboBox1.SelectedIndex - 1;
            newPhieuChi.NgayPS = dtCreateDate.Value;
            newPhieuChi.SoPC = db.PhieuChis.Count() + 1;
            newPhieuChi.SoTien = Convert.ToDecimal(txtMoney.Text);
            db.PhieuChis.Add(newPhieuChi);
            //db.SaveChanges();
            // open report form
            FormToView frm = new FormToView();
            frm.Address = txtDiaChi.Text;
            frm.SoTT = txtMoney.Text;
            frm.HoaDonID = newPhieuChi.SoPC;
            frm.CustomerName = txtName.Text;
            
            rp_PhieuChi newRP = new rp_PhieuChi(frm, rtDescription.Text);
            ReportPrintTool tool = new ReportPrintTool(newRP);

            tool.ShowPreviewDialog();

            tool.Report.CreateDocument();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
