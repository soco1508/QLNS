//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChuyenNganh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChuyenNganh()
        {
            this.NganhVienChucs = new HashSet<NganhVienChuc>();
        }
    
        public int idChuyenNganh { get; set; }
        public string tenChuyenNganh { get; set; }
        public int idNganhDaoTao { get; set; }
    
        public virtual NganhDaoTao NganhDaoTao { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NganhVienChuc> NganhVienChucs { get; set; }
    }
}