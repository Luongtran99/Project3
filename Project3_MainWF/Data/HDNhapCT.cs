//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project3_MainWF.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class HDNhapCT
    {
        public int MaHDNhapCT { get; set; }
        public int MaHDNhap { get; set; }
        public int MaHang { get; set; }
        public Nullable<decimal> DonGia { get; set; }
        public Nullable<int> SoLuong { get; set; }
    
        public virtual DMH DMH { get; set; }
        public virtual HDNhap HDNhap { get; set; }
    }
}
