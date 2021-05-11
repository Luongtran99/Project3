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
    public partial class rp_TheKhoHang : DevExpress.XtraReports.UI.XtraReport
    {
        private DataContext db;
        //private Project3Entities2 db2;
        public rp_TheKhoHang()
        {
            InitializeComponent();
        }

        public rp_TheKhoHang(int maHang, DateTime ngayBD, DateTime ngayKT)
        {
            db = new DataContext();
            //db2 = new Project3Entities2();
            InitializeComponent();
            
            // 
            pProductName.Value = db.DMHs.FirstOrDefault(p => p.MaHang == maHang).TenHang;
            pStartDate.Value = ngayBD;
            pEndDate.Value = ngayKT;

            //
            List<thekho_Result> list = db.thekho(maHang, ngayBD, ngayKT).ToList();
            
            for(int i = 0; i < list.Count; i++)
            {
                XRTableRow row = new XRTableRow();

                XRTableCell c1 = new XRTableCell();
                c1.Text = list[i].soph.ToString();
                row.Cells.Add(c1);
                XRTableCell c2 = new XRTableCell();
                c2.Text = list[i].ngayps.ToString();
                row.Cells.Add(c2);
                XRTableCell c3 = new XRTableCell();
                c3.Text = list[i].nhap.ToString();
                row.Cells.Add(c3);
                XRTableCell c4 = new XRTableCell();
                c4.Text = list[i].xuat.ToString();
                row.Cells.Add(c4);
                XRTableCell c5 = new XRTableCell();
                c5.Text = list[i].ton.ToString();
                row.Cells.Add(c5);

                xrTable2.Rows.Add(row);
            }

        }
    }
}
