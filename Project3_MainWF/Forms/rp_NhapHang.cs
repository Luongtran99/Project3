using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Project3_MainWF.Data;
using System.Collections.Generic;
using DevExpress.XtraRichEdit.API.Native;

namespace Project3_MainWF.Forms
{
    public partial class rp_NhapHang : DevExpress.XtraReports.UI.XtraReport
    {
        private List<InfoView> infoViews;
        private FormToView fView;
        public rp_NhapHang()
        {
            InitializeComponent();
        }

        public rp_NhapHang(List<InfoView> list, FormToView fmToView)
        {
            InitializeComponent();
            infoViews = new List<InfoView>();
            infoViews = list;
            fView = fmToView;
            pCustomerName.Value = fmToView.CustomerName;
            pHDNhapID.Value = fmToView.HoaDonID;
            pHDDate.Value = DateTime.Now;
            pTongTien.Value = fmToView.TongTien;
            pThueVAT.Value = fmToView.ThueVAT;
            pThanhToan.Value = fmToView.SoTT;
            pConDu.Value = fmToView.ConDu;
            Init();
        }

        private void AddToRow(int index, XRTableRow row, InfoView info)
        {
            // add cell STT
            XRTableCell xr = new XRTableCell();
            xr.WidthF = 44.17F;
            xr.Text = (index + 1).ToString();
            row.Cells.Add(xr);

            // add cell TenHang
            XRTableCell xr2 = new XRTableCell();
            xr2.WidthF = 189.17F;
            xr2.Text = infoViews[index].TenHang;
            row.Cells.Add(xr2);
            
            // add cell DVTinh
            XRTableCell xr3 = new XRTableCell();
            xr3.WidthF = 83.33F;
            xr3.Text = infoViews[index].DVTinh.ToString();
            row.Cells.Add(xr3);

            // add cell SoLuong
            XRTableCell xr4 = new XRTableCell();
            xr4.WidthF = 79.17F;
            xr4.Text = infoViews[index].SoLuong.ToString();
            row.Cells.Add(xr4);

            // add cell DonGia
            XRTableCell xr5 = new XRTableCell();
            xr5.WidthF = 119.17F;
            xr5.Text = infoViews[index].DonGiaG.ToString();
            row.Cells.Add(xr5);

            // add Cell TongTien
            XRTableCell xr6 = new XRTableCell();
            xr6.WidthF = 172F;
            xr6.Text = infoViews[index].TongTien.ToString();
            row.Cells.Add(xr6);

        }

        public void Init()
        {
            // add paramarter
            //pCustomerName.Value = fView.CustomerName;
            //pHDNhapID.Value = fView.HoaDonID;
            //pHDDate.Value = DateTime.Now;
            // create table
            int lCount = infoViews.Count;
            for(int index = 0; index < lCount; index++)
            {

                XRTableRow row = new XRTableRow();
                
                // add cell STT
                XRTableCell xr = new XRTableCell();
                xr.WidthF = 44.17F;
                xr.Text = (index + 1).ToString();
                row.Cells.Add(xr);

                // add cell TenHang
                XRTableCell xr2 = new XRTableCell();
                xr2.WidthF = 189.17F;
                xr2.Text = infoViews[index].TenHang;
                row.Cells.Add(xr2);

                // add cell DVTinh
                XRTableCell xr3 = new XRTableCell();
                xr3.WidthF = 83.33F;
                xr3.Text = infoViews[index].DVTinh.ToString();
                row.Cells.Add(xr3);

                // add cell SoLuong
                XRTableCell xr4 = new XRTableCell();
                xr4.WidthF = 79.17F;
                xr4.Text = infoViews[index].SoLuong.ToString();
                row.Cells.Add(xr4);

                // add cell DonGia
                XRTableCell xr5 = new XRTableCell();
                xr5.WidthF = 119.17F;
                xr5.Text = infoViews[index].DonGiaG.ToString();
                row.Cells.Add(xr5);

                // add Cell TongTien
                XRTableCell xr6 = new XRTableCell();
                xr6.WidthF = 172F;
                xr6.Text = infoViews[index].TongTien.ToString();
                row.Cells.Add(xr6);

                xrTable2.Rows.Add(row);
                
            }

            xrCount.Text = Convert.ToString(xrTable2.Rows.Count - 1);
            

            // add payment
            

            // set value to repay
        }
        
    }
}
