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
    
    public partial class NganhDaoTao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NganhDaoTao()
        {
            this.ChuyenNganhs = new HashSet<ChuyenNganh>();
            this.NganhVienChucs = new HashSet<NganhVienChuc>();
        }
    
        public int idNganhDaoTao { get; set; }
        public string tenNganhDaoTao { get; set; }
        public int idLoaiNganh { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChuyenNganh> ChuyenNganhs { get; set; }
        public virtual LoaiNganh LoaiNganh { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NganhVienChuc> NganhVienChucs { get; set; }
    }
}
