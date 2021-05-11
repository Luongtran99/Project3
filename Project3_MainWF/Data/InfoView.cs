using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3_MainWF.Data
{
    public class InfoView
    {
        
        public string TenHang { get; set; }
        public decimal DVTinh { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGiaG { get; set; }
        public decimal TongTien
        {
            get
            {
                return SoLuong * DonGiaG;
            }
        }
    }
}
