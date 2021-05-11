using System;
using System.Collections.Generic;

using System.Linq;

using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;

using Project3_MainWF.Data;

using DevExpress.XtraGrid;
using DevExpress.XtraReports.UI;
using System.Data;
using System.ComponentModel;

namespace Project3_MainWF.Forms
{
    public partial class frmBanHang : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        private Project3Entities2 db;

        //private BindingList<HDBHCT> gridData;
        private int MaHDBH;
        private int MaHDBHCT;
        private List<InfoView> infoViews;
        public frmBanHang()
        {
            InitializeComponent();
            db = new Project3Entities2();
            //gridData = new BindingList<HDBHCT>();
            infoViews = new List<InfoView>();
            MaHDBH = db.HDBHs.Count() + 1;
            MaHDBHCT = db.HDBHCTs.Count() + 1;
            UploadComboBox();
        }
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void UploadComboBox()
        {
            // add value to DMH
            foreach (var x in db.DMHs.ToList())
            {
                comboBoxEdit1.Properties.Items.Add(x.TenHang);
            }

            // add value to DMKH
            foreach (var y in db.DMKHs.ToList())
            {
                comboboxNCC.Properties.Items.Add(y.TenKH);
            }
        }

        private void gridControl_Load(object sender, EventArgs e)
        {
            try
            {
                this.dMHBindingSource.DataSource = db.DMHs.ToList();
            }
            catch(Exception ex)
            {
                string Msg = ex.Message;
                MessageBox.Show(Msg);
            }
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            // check condition to input
            if ((string)comboBoxEdit1.SelectedText == "")
            {
                XtraMessageBox.Show("Vui lòng chọn tên hàng");
                return;
            }

            if (radioGroup1.SelectedIndex == 0)
            {
                MessageBox.Show("Vui lòng chọn một loại giao dịch");
                return;
            }

            // add to grid control
            gridView.AddNewRow();
            //gridView.SetRowCellValue(GridControl.NewItemRowHandle, gridView.Columns["MaHDBHCT"], gridView.RowCount + 1);
            gridView.SetRowCellValue(GridControl.NewItemRowHandle, gridView.Columns["MaHD"], MaHDBH);
            gridView.SetRowCellValue(GridControl.NewItemRowHandle, gridView.Columns["MaHang"], Convert.ToInt32(txtMaHang.Text));
            gridView.SetRowCellValue(GridControl.NewItemRowHandle, gridView.Columns["DonGia"], Convert.ToDecimal(txtDonGia.Text));
            gridView.SetRowCellValue(GridControl.NewItemRowHandle, gridView.Columns["SoLuong"], Convert.ToInt32(txtSoLuong.Text));

            // get ma Hang 
            int maHang = Convert.ToInt32(txtMaHang.Text); // can not call convert in Linq to entities

            infoViews.Add(new InfoView
            {
                DonGiaG = Convert.ToDecimal(txtDonGia.Text),
                DVTinh = 1,
                TenHang = db.DMHs.FirstOrDefault(p => p.MaHang == maHang).TenHang,
                SoLuong = Convert.ToInt32(txtSoLuong.Text)
            });

            
            // recalculate 
            decimal tt = Convert.ToDecimal(Convert.ToDecimal(txtDonGia.Text) * Convert.ToInt32(txtSoLuong.Text));

            // set update to sum up 
            txtTongGiaTien.Text = Convert.ToString(Convert.ToDecimal(txtTongGiaTien.Text) + tt);
            txtThueVAT.Text = Convert.ToString(Convert.ToDecimal(txtTongGiaTien.Text) - Convert.ToDecimal(txtTongGiaTien.Text) * 10 / 100);
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBoxEdit1.SelectedText == "")
            {
                MessageBox.Show("Vui lòng chọn hàng hóa");
                return;
            }

            // get Product from database
            DMH mH = db.DMHs.FirstOrDefault(p => p.TenHang == comboBoxEdit1.SelectedText);

            txtDonGia.Text = Convert.ToString(mH.GiaBan);
            txtMaHang.Text = Convert.ToString(mH.MaHang);


        }
        // function to recalculate 
        private void CalculateTongTien()
        {

        }


        private void gridControl_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Changing...");
        }


        // call function when updating once cell in a row
        private void gridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            //MessageBox.Show("updating...");
            // recalculate 
            //MessageBox.Show(gridView.GetRowCellValue(0, gridView.Columns["TongTien"]).ToString());
            int rCount = gridView.RowCount;
            decimal tt = 0;
            for (int i = 0; i < rCount; i++)
            {
                tt = tt + Convert.ToDecimal(gridView.GetRowCellValue(i, gridView.Columns["TongTien"]));
            }
            // update 
            
            txtTongGiaTien.Text = Convert.ToString(tt);
            txtThueVAT.Text = Convert.ToString(tt - tt * 10 / 100);


            // can not calcualte to 
            //txtSodu.Text = (Convert.ToDecimal(txtThanhToan.Text) - Convert.ToDecimal(txtThueVAT.Text)).ToString();
        }


        // update to HDBHCT
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            // check selected name in combo box
            if (comboboxNCC.SelectedText == "")
            {
                MessageBox.Show("Chọn khách hàng giao dịch");
                return;
            }

            if (MessageBox.Show("Bạn có xác nhận hoàn thành giao dịch", "Chọn", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //try
                //{
                //    //  update to HDBH
                //    HDBH dBH = new HDBH
                //    {
                //        MaHD = MaHDBH,
                //        MaKH = comboboxNCC.SelectedIndex,
                //        NgayPS = DateTime.Now,
                //        SoTT = Convert.ToDecimal(txtThanhToan.Text)
                //    };

                //    db.HDBHs.Add(dBH);

                //    db.SaveChanges();
                //    // update to HDBHCT

                //    int rows = gridView.RowCount;
                //    for (var i = 0; i < rows; i++)
                //    {
                //        HDBHCT a = new HDBHCT
                //        {
                //            MaHD = MaHDBH,
                //            MaHDBHCT = MaHDBHCT + i,
                //            MaHang = Convert.ToInt32(gridView.GetRowCellValue(i, gridView.Columns["MaHang"])),
                //            DonGia = Convert.ToDecimal(gridView.GetRowCellValue(i, gridView.Columns["DonGia"])),
                //            SoLuong = Convert.ToInt32(gridView.GetRowCellValue(i, gridView.Columns["SoLuong"]))
                //        };
                //        db.HDBHCTs.Add(a);
                //        db.SaveChanges();
                //    }
                    
                //}
                //catch(Exception ex)
                //{
                //    throw new Exception(ex.ToString());
                //}
                // after save to database 
                // open report
                OpenRpBanHang();
            }
            return;
        }


        private void OpenRpBanHang()
        {
            if (comboboxNCC.SelectedText == "")
            {
                MessageBox.Show("Chọn khách hàng");
                return;
            }

            FormToView fView = new FormToView();
            int so = comboboxNCC.SelectedIndex + 1;
            fView.CustomerName = comboboxNCC.SelectedText;
            
            fView.Address = db.DMKHs.FirstOrDefault(p => p.MaKH == so).DiaChi ?? "";
            fView.NgayPS = DateTime.Now;
            fView.PostalCode = db.DMKHs.FirstOrDefault(p => p.MaKH == so).MaST ?? "";
            fView.HoaDonID = MaHDBH;
            fView.SoTT = txtThanhToan.Text;

            rp_HoaDon _HoaDon = new rp_HoaDon(infoViews, fView);

            ReportPrintTool reportPrint = new ReportPrintTool(_HoaDon);

            reportPrint.ShowPreviewDialog();

            // Create the report's document.
            reportPrint.Report.CreateDocument();

        }



        private void simpleButton2_Click(object sender, EventArgs e)
        {

            if (gridView.FocusedRowHandle == null)
            {
                return;
            }

            var tt = gridView.GetFocusedRowCellValue("TongTien");
            txtTongGiaTien.Text = Convert.ToString(Convert.ToInt32(txtTongGiaTien.Text) - Convert.ToInt32(tt));
            txtThueVAT.Text = Convert.ToString(Convert.ToInt32(txtTongGiaTien.Text) - (Convert.ToInt32(txtTongGiaTien.Text) * 10 / 100));
            gridView.DeleteRow(gridView.FocusedRowHandle);

        }

        private void txtThanhToan_MouseLeave(object sender, EventArgs e)
        {
            txtSodu.Text = Convert.ToString(Convert.ToDecimal(txtThueVAT.Text) - Convert.ToDecimal(txtThanhToan.Text));
        }
    }
}