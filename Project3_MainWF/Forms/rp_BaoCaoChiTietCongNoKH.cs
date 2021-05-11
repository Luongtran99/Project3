using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Project3_MainWF.Data;
using System.Linq;
using System.Collections.Generic;

namespace Project3_MainWF.Forms
{
    public partial class rp_BaoCaoChiTietCongNoKH : DevExpress.XtraReports.UI.XtraReport
    {
        private DataContext db;
        public rp_BaoCaoChiTietCongNoKH()
        {
            InitializeComponent();
        }

        public rp_BaoCaoChiTietCongNoKH(int maKh, DateTime startTime, DateTime endTime)
        {
            db = new DataContext();
            InitializeComponent();

            // set to paramaater
            pCustomer.Value = db.DMKHs.FirstOrDefault(p => p.MaKH == maKh).TenKH;
            pStartDate.Value = startTime;
            pEndDate.Value = endTime;


            // run and get from procedure
            List<BaoCaoChiTietCongNo_Result> x = db.BaoCaoChiTietCongNo(maKh, startTime, endTime).ToList();

            for (int i = 0; i < x.Count; i++)
            {
                XRTableRow newR = new XRTableRow();

                XRTableCell cell1 = new XRTableCell();
                cell1.Text = x[i].ngay.ToString();
                newR.Cells.Add(cell1);
                XRTableCell cell2 = new XRTableCell();
                cell2.Text = x[i].soCt.ToString();
                newR.Cells.Add(cell2);
                XRTableCell cell3 = new XRTableCell();
                cell3.Text = x[i].loai;
                newR.Cells.Add(cell3);
                XRTableCell cell4 = new XRTableCell();
                cell4.Text = x[i].sono.ToString();
                newR.Cells.Add(cell4);
                XRTableCell cell5 = new XRTableCell();
                cell5.Text = x[i].sott.ToString();
                newR.Cells.Add(cell5);
                XRTableCell cell6 = new XRTableCell();
                cell6.Text = x[i].sodu.ToString();
                newR.Cells.Add(cell6);

                xrTable2.Rows.Add(newR);
            }

        }

    }
}
