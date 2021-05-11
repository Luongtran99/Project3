using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Project3_MainWF.Data;
using System.Collections.Generic;
using System.Linq;

namespace Project3_MainWF.Forms
{
    public partial class rp_TongHopNhapTon : DevExpress.XtraReports.UI.XtraReport
    {
        private DataContext db;
        public rp_TongHopNhapTon()
        {
            db = new DataContext();
            InitializeComponent();
            
        }

        public void addToCell(XRTableRow row, string value)
        {
            
            XRTableCell newCell = new XRTableCell();
            newCell.Text = value;
            row.Cells.Add(newCell);
        }

        public rp_TongHopNhapTon(DateTime ngayBD, DateTime ngayKT)
        {
            InitializeComponent();
            db = new DataContext();

            this.ngayBD.Value = ngayBD;
            this.pNgayKT.Value = ngayKT;

            List<TongHopXuatNhapTon_Result> rs = db.TongHopXuatNhapTon(ngayBD, ngayKT).ToList();

            for (int i = 0; i < rs.Count; i++)
            {

                XRTableRow newR = new XRTableRow();

                XRTableCell cell1 = new XRTableCell();
                cell1.Text = rs[i].tenhang;
                newR.Cells.Add(cell1);

                XRTableCell cell2 = new XRTableCell();
                cell2.Text = rs[i].tondau.ToString();
                newR.Cells.Add(cell2);

                XRTableCell cell3 = new XRTableCell();
                cell3.Text = rs[i].nhap.ToString();
                newR.Cells.Add(cell3);

                XRTableCell cell4 = new XRTableCell();
                cell4.Text = rs[i].xuat.ToString();
                newR.Cells.Add(cell4);

                XRTableCell cell5 = new XRTableCell();
                cell5.Text = rs[i].toncuoi.ToString();
                newR.Cells.Add(cell5);

                xrTable1.Rows.Add(newR);

            }


        }


        public rp_TongHopNhapTon(List<TongHopXuatNhapTon_Result> rs)
        {
            InitializeComponent();
            //db = new DataContext();
            //var x = db.TongHopXuatNhapTon(ngayBD, ngayKT);

            for(int i = 0; i < rs.Count; i++)
            {

                XRTableRow newR = new XRTableRow();

                XRTableCell cell1 = new XRTableCell();
                cell1.Text = rs[i].tenhang;
                newR.Cells.Add(cell1);

                XRTableCell cell2 = new XRTableCell();
                cell2.Text = rs[i].tondau.ToString();
                newR.Cells.Add(cell2);

                XRTableCell cell3 = new XRTableCell();
                cell3.Text = rs[i].nhap.ToString();
                newR.Cells.Add(cell3);

                XRTableCell cell4 = new XRTableCell();
                cell4.Text = rs[i].xuat.ToString();
                newR.Cells.Add(cell4);

                XRTableCell cell5 = new XRTableCell();
                cell5.Text = rs[i].toncuoi.ToString();
                newR.Cells.Add(cell5);

                xrTable1.Rows.Add(newR);

            }

        }
    }
}
