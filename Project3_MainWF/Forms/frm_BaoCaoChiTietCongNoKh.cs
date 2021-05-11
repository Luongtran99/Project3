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
    public partial class frm_BaoCaoChiTietCongNoKh : DevExpress.XtraEditors.XtraForm
    {
        private DataContext db;
        public frm_BaoCaoChiTietCongNoKh()
        {
            db = new DataContext();
            InitializeComponent();
            fillComboBox();
        }


        public void fillComboBox()
        {
            foreach( var x in db.DMKHs)
            {
                comboBox1.Items.Add(x.MaKH);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // get infor 
            
            rp_BaoCaoChiTietCongNoKH rp = new rp_BaoCaoChiTietCongNoKH(Convert.ToInt32(comboBox1.SelectedItem), DateTime.Parse(dateTimePicker1.Text), DateTime.Parse(dateTimePicker2.Text));
            ReportPrintTool tool = new ReportPrintTool(rp);
            tool.ShowPreviewDialog();
            tool.Report.CreateDocument();

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}