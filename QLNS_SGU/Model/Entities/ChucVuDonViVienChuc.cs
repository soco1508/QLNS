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
    
    public partial class ChucVuDonViVienChuc
    {
        public int idViTriDonViVienChuc { get; set; }
        public int idVienChuc { get; set; }
        public int idChucVu { get; set; }
        public int idDonVi { get; set; }
        public int idToChuyenMon { get; set; }
        public string phanLoaiCongTac { get; set; }
        public Nullable<int> checkPhanLoaiCongTac { get; set; }
        public Nullable<System.DateTime> ngayBatDau { get; set; }
        public Nullable<System.DateTime> ngayKetThuc { get; set; }
        public string linkVanBanDinhKem { get; set; }
        public Nullable<int> loaiThayDoi { get; set; }
        public Nullable<int> kiemNhiem { get; set; }
    
        public virtual ChucVu ChucVu { get; set; }
        public virtual DonVi DonVi { get; set; }
        public virtual ToChuyenMon ToChuyenMon { get; set; }
        public virtual VienChuc VienChuc { get; set; }
    }
}