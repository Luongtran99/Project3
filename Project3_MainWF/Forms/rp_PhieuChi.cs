using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Project3_MainWF.Data;

namespace Project3_MainWF.Forms
{
    public partial class rp_PhieuChi : DevExpress.XtraReports.UI.XtraReport
    {
        public rp_PhieuChi()
        {
            InitializeComponent();
        }

        public rp_PhieuChi(FormToView form, string txt)
        {
            InitializeComponent();
            pDate.Value = DateTime.Now;
            pName.Value = form.CustomerName;
            pSo.Value = form.HoaDonID;
            pMoney.Value = form.SoTT;
            pDescription.Value = txt;

        }
    }
}
