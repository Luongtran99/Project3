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
    public partial class frm_TheKhoHang : DevExpress.XtraEditors.XtraForm
    {
        private DataContext db; 
        public frm_TheKhoHang()
        {
            db = new DataContext();
            InitializeComponent();
            fillCombo();
        }


        public void fillCombo()
        {
            foreach(var x in db.DMHs)
            {
                comboBoxEdit1.Properties.Items.Add(x.MaHang);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rp_TheKhoHang rp = new rp_TheKhoHang(Convert.ToInt32(comboBoxEdit1.SelectedText), DateTime.Parse(dtStartPicker.Text), DateTime.Parse(dtEndPicker.Text));
            ReportPrintTool tool = new ReportPrintTool(rp);
            tool.ShowPreviewDialog();
            tool.Report.CreateDocument();
        }
    }
}