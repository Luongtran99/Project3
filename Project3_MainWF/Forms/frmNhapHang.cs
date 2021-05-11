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
using DevExpress.XtraBars;
using System.ComponentModel.DataAnnotations;
using Project3_MainWF.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;

namespace Project3_MainWF.Forms
{
    public partial class frmNhapHang : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Project3Entities2 db;
        private List<decimal> total = new List<decimal>();
        private List<InfoView> infoViews;

        public frmNhapHang()
        {
            InitializeComponent();
            gridView.ExpandAllGroups();
            db = new Project3Entities2();
            infoViews = new List<InfoView>();
            fillComboBox();
        }
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            grid_DetailInvoice.ShowRibbonPrintPreview();
        }

        private void frmNhapHang_Load(object sender, EventArgs e)
        {
            //this.hDNhapCTBindingSource.DataSource = db.HDNhapCTs.ToList();
            this.dMHBindingSource.DataSource = db.DMHs.ToList();
        }

        void fillComboBox()
        {
            foreach( var c in db.DMHs.ToList())
            {
                comboBoxEdit1.Properties.Items.Add(c.TenHang);
            }

            foreach(var c in db.DMKHs.ToList())
            {
                comboboxNCC.Properties.Items.Add(c.TenKH);
            }
        }

        private void gridView_FocusedColumnChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            
        }

        /*private void gridView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;
            decimal dongia = Convert.ToDecimal(gridView.GetListSourceRowCellValue(rowIndex, "DonGia"));
            decimal soluong = Convert.ToDecimal(gridView.GetListSourceRowCellValue(rowIndex, "SoLuong"));
            if (e.Column.FieldName != "TongTien") return;
            if (e.IsGetData)
            {
                e.Value = dongia * soluong;
            }
        }*/
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxEdit cb = (ComboBoxEdit)sender;
            int selectedIndex = cb.SelectedIndex;
            string selectedValue = (string)cb.SelectedText;
            /*
             * thêm thông tin vào Mục thông tin hàng hóa
             */
            DMH mH = db.DMHs.FirstOrDefault(p => p.TenHang == selectedValue);

            if(mH != null)
            {
                this.txtDonGia.Text = mH.GiaBan.ToString();
                this.txtMaHang.Text = mH.MaHang.ToString();
            }
            
        }

        // insert excel to grid view
        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            // get excel file
            OpenFileDialog chooseFile = new OpenFileDialog();
            chooseFile.ShowDialog();
            MessageBox.Show(String.Format("File Name" + chooseFile.FileName));

            // insert to grid view
            
        }

        // add product to grid view
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if(comboBoxEdit1.SelectedText == null)
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm");
                return;
            }


            // check if it exited on grid control

            gridView.AddNewRow();
            int a = db.HDNhaps.Select(p => p.MaHDNhap).Count();
            gridView.SetRowCellValue(GridControl.NewItemRowHandle, gridView.Columns["MaHDNhap"], a + 1);
            gridView.SetRowCellValue(GridControl.NewItemRowHandle, gridView.Columns["MaHang"], Convert.ToInt32(txtMaHang.Text)); 
            gridView.SetRowCellValue(GridControl.NewItemRowHandle, gridView.Columns["DonGia"], txtDonGia.Text);
            gridView.SetRowCellValue(GridControl.NewItemRowHandle, gridView.Columns["SoLuong"], txtSoLuong.Text);

            // calculate 
            int cProduct = Convert.ToInt32(txtDonGia.Text) * Convert.ToInt32(txtSoLuong.Text);
            txtTongGiaTien.Text = Convert.ToString(Convert.ToInt32(txtTongGiaTien.Text) + cProduct);
            txtThueVAT.Text = Convert.ToString(Convert.ToInt32(txtTongGiaTien.Text) - (Convert.ToInt32(txtTongGiaTien.Text) * 10 / 100));

            // in some case they add what has existed in grid, give some condition check in here
            // add to Infor List
            int maHang = Convert.ToInt32(txtMaHang.Text);

            infoViews.Add(new InfoView
            {
                TenHang = comboBoxEdit1.SelectedText,
                DVTinh = 1,
                DonGiaG = Convert.ToDecimal(txtDonGia.Text),
                SoLuong = Convert.ToInt32(txtSoLuong.Text)
            });
        }

        // delete form grid view
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if(gridView.FocusedRowHandle == null)
            {
                return;
            }

            var tt = gridView.GetFocusedRowCellValue("TongTien");
            txtTongGiaTien.Text = Convert.ToString(Convert.ToInt32(txtTongGiaTien.Text) - Convert.ToInt32(tt));
            txtThueVAT.Text = Convert.ToString(Convert.ToInt32(txtTongGiaTien.Text) - (Convert.ToInt32(txtTongGiaTien.Text) * 10 / 100));
            gridView.DeleteRow(gridView.FocusedRowHandle);
        }

        private void txtThanhToan_Leave(object sender, EventArgs e)
        {
            txtSoConNo.Text = Convert.ToString(Convert.ToInt32(txtThueVAT.Text) - Convert.ToInt32(txtThanhToan.Text));
        }

        // hoàn thành giao dịch
        private void simpleButton3_Click(object sender, EventArgs e)
        {

            if(comboboxNCC.SelectedText == "")
            {
                return;
            }

            int maHDNhap = 0;
            int makh = comboboxNCC.SelectedIndex + 1;
            // save to HDNhap 
            // MaKH is Mart ID
            //HDNhap bufHDNhap = new HDNhap();
            //bufHDNhap.MaHDNhap = db.HDNhaps.Select(p => p.MaHDNhap).Count() + 1;
            //bufHDNhap.MaKH = makh;
            //bufHDNhap.NgayNhap = dateTimePicker1.Value;
            //bufHDNhap.SoThanhToan = Convert.ToDecimal(txtThanhToan.Text);
            //db.HDNhaps.Add(bufHDNhap);
            //db.SaveChanges();
            
            //// save to HDNhap Chi tiet
            //maHDNhap = db.HDNhaps.Select(p => p.MaHDNhap).Count();

            //int x = gridView.RowCount;
            //gridView.AddNewRow();
            //for(int i = 0; i < x; i++)
            //{
            //    HDNhapCT ct = new HDNhapCT();
            //    ct.MaHDNhap = maHDNhap;
            //    ct.MaHang = Convert.ToInt32(gridView.GetRowCellValue(i, gridView.Columns["MaHang"]));
            //    ct.DonGia = Convert.ToDecimal(gridView.GetRowCellValue(i, gridView.Columns["DonGia"]));
            //    ct.SoLuong = Convert.ToInt32(gridView.GetRowCellValue(i, gridView.Columns["SoLuong"]));
            //    db.HDNhapCTs.Add(ct);
            //    db.SaveChanges();
            //}

            //MessageBox.Show("Đang thực thi ...");

            // open report Nhap Hang
            FormToView fView = new FormToView();
            fView.CustomerName = comboboxNCC.Text;
            fView.HoaDonID = db.HDNhaps.Select(p => p.MaHDNhap).Count() + 1;
            fView.NgayPS = DateTime.Now;
            fView.TongTien = txtTongGiaTien.Text;
            fView.SoTT = txtThanhToan.Text;
            fView.ThueVAT = txtThueVAT.Text;
            fView.ConDu = txtSoConNo.Text;
            

            rp_NhapHang _HoaDon = new rp_NhapHang(infoViews, fView);

            ReportPrintTool reportPrint = new ReportPrintTool(_HoaDon);

            reportPrint.ShowPreviewDialog();

            // Create the report's document.
            reportPrint.Report.CreateDocument();
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //int x = gridView.RowCount;
            //gridView.AddNewRow();
            //MessageBox.Show(gridView.GetRowCellValue(2, "MaHang").ToString());

            //for (int i = 0; i < x; i++)
            //{
            //    HDNhapCT ct = new HDNhapCT
            //    {
            //        MaHDNhap = 10,
            //        MaHang = Convert.ToInt32(gridView.GetRowCellValue(1, gridView.Columns["MaHang"])),
            //        DonGia = Convert.ToDecimal(gridView.GetRowCellValue(1, gridView.Columns["DonGia"])),
            //        SoLuong = Convert.ToInt32(gridView.GetRowCellValue(1, gridView.Columns["SoLuong"]))

            //    };
            //}
            DMH newHang = new DMH();
            newHang.MaHang = db.DMHs.Count() + 1;
            newHang.TenHang = comboboxNCC.SelectedText;
            decimal buff = Convert.ToDecimal(txtDonGia.Text);
            newHang.GiaChuan = buff;
            newHang.GiaBan = buff + (buff * 10 / 100);
            try
            {
                db.DMHs.Add(newHang);
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error ", ex.Message);
            }
            
            // check 
            comboboxNCC.DeselectAll();
            comboBoxEdit1.DeselectAll();

            fillComboBox();

        }
    }
}