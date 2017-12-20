using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ObjectModels
{
    public class HocHamHocVi_DanghocNangCao_NganhForView
    {
        public string NganhDaoTao { get; set; }
        public string ChuyenNganh { get; set; }
        public string PhanLoai { get; set; }
        public DateTime? NgayBatDauGiangDay { get; set; }
        public DateTime? NgayKetThucGiangDay { get; set; }
        public string LinkQuyetDinhGiangDay { get; set; }
        public string HocHamHocVi { get; set; }
        public string TrinhDoHocHamHocVi { get; set; }
        public string CoSoDaoTaoHocHamHocVi { get; set; }
        public string NuocCapBangHocHamHocVi { get; set; }
        public string NgonNguDaoTaoHocHamHocVi { get; set; }
        public string HinhThucDaoTaoHocHamHocVi { get; set; }
        public DateTime? NgayCapBangHocHamHocVi { get; set; }
        public string LinkVanBanDinhKem { get; set; }
        public string HocNangCao { get; set; }
        public string TrinhDoHocNangCao { get; set; }
        public string SoQuyetDinh { get; set; } 
        public string LinkAnhQuyetDinh { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string TinhTrang { get; set; }
        public string CoSoDaoTaoHocNangCao { get; set; }
        public string NuocCapBangHocNangCao { get; set; }
        public string NgonNguDaoTaoHocNangCao { get; set; }
        public string HinhThucDaoTaoHocNangCao { get; set; }
        public HocHamHocVi_DanghocNangCao_NganhForView()
        {
            NganhDaoTao = "";
            ChuyenNganh = "";
            PhanLoai = "";
            NgayBatDauGiangDay = Convert.ToDateTime("01/01/1900");
            NgayKetThucGiangDay = Convert.ToDateTime("01/01/1900");
            LinkQuyetDinhGiangDay = "";
            HocHamHocVi = "";
            TrinhDoHocHamHocVi = "";
            CoSoDaoTaoHocHamHocVi = "";
            NuocCapBangHocHamHocVi = "";
            NgonNguDaoTaoHocHamHocVi = "";
            HinhThucDaoTaoHocHamHocVi = "";
            NgayCapBangHocHamHocVi = Convert.ToDateTime("01/01/1900");
            LinkVanBanDinhKem = "";
            HocNangCao = "";
            TrinhDoHocNangCao = "";
            SoQuyetDinh = "";
            LinkAnhQuyetDinh = "";
            NgayBatDau = Convert.ToDateTime("01/01/1900");
            NgayKetThuc = Convert.ToDateTime("01/01/3000");
            TinhTrang = "";
            CoSoDaoTaoHocNangCao = "";
            NuocCapBangHocNangCao = "";
            NgonNguDaoTaoHocNangCao = "";
            HinhThucDaoTaoHocNangCao = "";
        }
    }
}
