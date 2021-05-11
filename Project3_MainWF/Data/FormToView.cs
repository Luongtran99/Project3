using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3_MainWF.Data
{
    public class FormToView
    {
        public string CustomerName { get; set; }
        public string PostalCode { get; set; } = "";
        public string Address { get; set; } = "";
        public int HoaDonID { get; set; }
        public DateTime NgayPS { get; set; }
        public string SoTT { get; set; }
        public string TongTien { get; set; }
        public string ThueVAT { get; set; }
        public string ConDu { get; set; }
    }
}
