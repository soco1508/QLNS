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
    
    public partial class TrangThaiVienChuc
    {
        public TrangThaiVienChuc() { }
        public TrangThaiVienChuc(TrangThaiVienChuc trangThaiVienChuc)
        {
            idTrangThaiVienChuc = trangThaiVienChuc.idTrangThaiVienChuc;
            idVienChuc = trangThaiVienChuc.idVienChuc;
            idTrangThai = trangThaiVienChuc.idTrangThai;
            ngayBatDau = trangThaiVienChuc.ngayBatDau;
            ngayKetThuc = trangThaiVienChuc.ngayKetThuc;
            moTa = trangThaiVienChuc.moTa;
            diaDiem = trangThaiVienChuc.diaDiem;
            linkVanBanDinhKem = trangThaiVienChuc.linkVanBanDinhKem;
            TrangThai = trangThaiVienChuc.TrangThai;
            VienChuc = trangThaiVienChuc.VienChuc;
        }

        public int idTrangThaiVienChuc { get; set; }
        public int idVienChuc { get; set; }
        public int idTrangThai { get; set; }
        public Nullable<System.DateTime> ngayBatDau { get; set; }
        public Nullable<System.DateTime> ngayKetThuc { get; set; }
        public string moTa { get; set; }
        public string diaDiem { get; set; }
        public string linkVanBanDinhKem { get; set; }
    
        public virtual TrangThai TrangThai { get; set; }
        public virtual VienChuc VienChuc { get; set; }
    }
}
