using DevExpress.XtraReports.UI;
using Project3_MainWF.Data;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Project3_MainWF.Forms
{
    public partial class rp_HoaDon : DevExpress.XtraReports.UI.XtraReport
    {
        
        public rp_HoaDon()
        {

            InitializeComponent();
        }

        public rp_HoaDon(List<InfoView> list, FormToView formToView)
        {
            InitializeComponent();
            // init at the same form

            pCustomerName.Value = formToView.CustomerName;
            pAddress.Value = formToView.Address;
            pPostalCode.Value = formToView.PostalCode;
            pOrderID.Value = formToView.HoaDonID;
            pOrderDate.Value = DateTime.Now;
            
            xrThanhToan.Text = formToView.SoTT;

            initTable(list);   

        }

        public void initTable(List<InfoView> list)
        {
            int value = list.Count;
            decimal tongTien = 0;
            // add value to cell row
            for (int i = 0; i < value; i++)
            {
                XRTableRow xR = new XRTableRow();
                xR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                XRTableCell cell = new XRTableCell();
                cell.WidthF = 44.17F;
                cell.Text = (i + 1).ToString();
                xR.Cells.Add(cell);

                XRTableCell cell1 = new XRTableCell();
                cell1.WidthF = 189.17F;
                cell1.Text = list[i].TenHang.ToString();
                xR.Cells.Add(cell1);

                XRTableCell cell2 = new XRTableCell();
                cell2.WidthF = 83.33F;
                cell2.Text = list[i].DVTinh.ToString();
                xR.Cells.Add(cell2);

                XRTableCell cell3 = new XRTableCell();
                cell3.WidthF = 79.17F;
                cell3.Text = list[i].SoLuong.ToString();
                xR.Cells.Add(cell3);

                XRTableCell cell4 = new XRTableCell();
                cell4.WidthF = 119.17F;
                cell4.Text = list[i].DonGiaG.ToString();
                xR.Cells.Add(cell4);

                XRTableCell cell5 = new XRTableCell();
                cell5.WidthF = 172F;
                tongTien = tongTien + list[i].DonGiaG * list[i].SoLuong;
                cell5.Text = (list[i].DonGiaG * list[i].SoLuong).ToString();
                xR.Cells.Add(cell5);

                if (i % 2 == 0)
                {
                    xR.BackColor = Color.FromArgb(204, 204, 255);
                }
                else
                {
                    xR.BackColor = Color.FromArgb(138, 237, 231);
                }
                xrTable2.Rows.Add(xR);


            }
            xrCount.Text = Convert.ToString(xrTable2.Rows.Count - 1);
            //XRBinding xR = new XRBinding();
            xrTongTien.Text = tongTien.ToString();
            
        }
    }
}
