using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DevExpress.XtraReports;
using DevExpress.XtraReports.UI;
using Project3_MainWF.Data;


namespace Project3_MainWF.Forms
{
    public partial class frmPhieuThu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private Project3Entities2 db;
        public frmPhieuThu()
        {
            InitializeComponent();
            db = new Project3Entities2();


            Init();
        }

        public void Init()
        {
            foreach(var x in db.DMKHs)
            {
                comboBox1.Items.Add(x.MaKH);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int a = Convert.ToInt32(comboBox1.SelectedItem);

            DMKH kh = db.DMKHs.FirstOrDefault(p => p.MaKH == a);
            txtName.Text = kh.TenKH;
            txtAddress.Text = kh.DiaChi;
            dtCreateDate.Value = DateTime.Now;

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            // save to database
            PhieuThu pt = new PhieuThu();
            pt.MaKH = Convert.ToInt32(comboBox1.SelectedItem);
            pt.NgayPS = DateTime.Now;
            pt.SoPT = db.PhieuThus.Count() + 1;
            pt.SoTien = Convert.ToDecimal(txtMoney.Text);

            db.PhieuThus.Add(pt);



            // open report dialog

            FormToView form = new FormToView();
            form.Address = txtAddress.Text;
            form.HoaDonID = pt.SoPT;
            form.NgayPS = pt.NgayPS;
            form.CustomerName = txtName.Text;
            form.PostalCode = db.DMKHs.FirstOrDefault(p => p.MaKH == pt.MaKH).MaST;
            form.SoTT = pt.SoTien.ToString();
            rp_PhieuThu newPT = new rp_PhieuThu(form, rtDescription.Text);

            ReportPrintTool rp = new ReportPrintTool(newPT);
            rp.ShowPreviewDialog();
            rp.Report.CreateDocument();

        }
    }
}
