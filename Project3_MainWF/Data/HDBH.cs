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
    
    public partial class HDBH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HDBH()
        {
            this.HDBHCTs = new HashSet<HDBHCT>();
        }
    
        public int MaHD { get; set; }
        public System.DateTime NgayPS { get; set; }
        public int MaKH { get; set; }
        public Nullable<decimal> SoTT { get; set; }
    
        public virtual DMKH DMKH { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HDBHCT> HDBHCTs { get; set; }
    }
}