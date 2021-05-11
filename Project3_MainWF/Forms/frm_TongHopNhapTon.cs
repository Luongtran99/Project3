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
using Project3_MainWF.Data;
using DevExpress.XtraReports.UI;

namespace Project3_MainWF.Forms
{
    public partial class frm_TongHopNhapTon : DevExpress.XtraEditors.XtraForm
    {
        private DataContext db;
        public frm_TongHopNhapTon()
        {
            db = new DataContext();
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //List<TongHopXuatNhapTon_Result> u = db.TongHopXuatNhapTon(DateTime.Parse(dtPicker1.Text), DateTime.Parse(dtPicker2.Text)).ToList();
            rp_TongHopNhapTon rp = new rp_TongHopNhapTon(DateTime.Parse(dtPicker1.Text), DateTime.Parse(dtPicker2.Text));
            //rp_TongHopNhapTon rp = new rp_TongHopNhapTon(u);
            ReportPrintTool tool = new ReportPrintTool(rp);
            tool.ShowPreviewDialog();
            tool.Report.CreateDocument();
        }
    }
}