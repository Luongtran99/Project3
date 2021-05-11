using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Project3_MainWF.Forms
{
    public partial class rp_PhieuThu : DevExpress.XtraReports.UI.XtraReport
    {
        public rp_PhieuThu()
        {

        }
        public rp_PhieuThu(Data.FormToView form, string txt)
        {
            InitializeComponent();
            pCustomerName.Value = form.CustomerName;
            pDate.Value = form.NgayPS;
            pCustomerAddress.Value = form.Address;
            pPTID.Value = form.HoaDonID;
            pPayment.Value = form.SoTT;
            pTaxCode.Value = form.PostalCode;
            pDescription.Value = txt;
        }

    }
}
