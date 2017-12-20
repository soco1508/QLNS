using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;
using Model.ObjectModels;

namespace Model.Repository
{
    public class HocHamHocVi_DangHocNangCao_NganhRepository : Repository<HocHamHocVi_DanghocNangCao_NganhForView>
    {
        public HocHamHocVi_DangHocNangCao_NganhRepository(QLNSSGU_1Entities db) : base(db)
        {
        }

        public List<HocHamHocVi_DanghocNangCao_NganhForView> GetListHocHamHocVi_DanghocNangCao(string mavienchuc)
        {
            List<HocHamHocVi_DanghocNangCao_NganhForView> listHocHamHocVi_DanghocNangCaoForView = new List<HocHamHocVi_DanghocNangCao_NganhForView>();
            int idvienchuc = _db.VienChucs.Where(x => x.maVienChuc == mavienchuc).Select(y => y.idVienChuc).FirstOrDefault();
            List<HocHamHocViVienChuc> listHocHamHocVi = _db.HocHamHocViVienChucs.Where(x => x.idVienChuc == idvienchuc).ToList();
            List<DangHocNangCao> listDangHocNangCao = _db.DangHocNangCaos.Where(x => x.idVienChuc == idvienchuc).ToList();
            var listHocHamHocVi_DangHocNangCao = from c in listHocHamHocVi
                                                 from d in listDangHocNangCao
                                                 from e in _db.NganhVienChucs
                                                 where c.idVienChuc == d.idVienChuc && c.idHocHamHocViVienChuc == e.idHocHamHocViVienChuc
                                                 select new { c, d, e };
            foreach(var row in listHocHamHocVi_DangHocNangCao)
            {
                listHocHamHocVi_DanghocNangCaoForView.Add(new HocHamHocVi_DanghocNangCao_NganhForView
                {
                    NganhDaoTao = row.e.NganhDaoTao.tenNganhDaoTao,
                    ChuyenNganh = row.e.ChuyenNganh.tenChuyenNganh,
                    PhanLoai = HardCodePhanLoaiNganhHocVaGiangDay(row.e.phanLoai),
                    NgayBatDauGiangDay = row.e.ngayBatDau,
                    NgayKetThucGiangDay = row.e.ngayKetThuc,
                    LinkQuyetDinhGiangDay = row.e.linkVanBanDinhKem,
                    HocHamHocVi = row.c.tenHocHamHocVi,
                    TrinhDoHocHamHocVi = row.c.LoaiHocHamHocVi.tenLoaiHocHamHocVi,
                    CoSoDaoTaoHocHamHocVi = row.c.coSoDaoTao,
                    NuocCapBangHocHamHocVi = row.c.nuocCapBang,
                    NgonNguDaoTaoHocHamHocVi = row.c.ngonNguDaoTao,
                    NgayCapBangHocHamHocVi = row.c.ngayCapBang,
                    HinhThucDaoTaoHocHamHocVi = row.c.hinhThucDaoTao,
                    LinkVanBanDinhKem = row.c.linkVanBanDinhKem,
                    HocNangCao = HardCodeHocNangCao(row.d.tenHocHamHocVi),
                    SoQuyetDinh = row.d.soQuyetDinh,
                    LinkAnhQuyetDinh = row.d.linkAnhQuyetDinh,
                    NgayBatDau = row.d.ngayBatDau,
                    NgayKetThuc = row.d.ngayKetThuc,
                    TinhTrang = HardCodeTinhTrang(row.d.loai),
                    CoSoDaoTaoHocNangCao = row.d.coSoDaoTao,
                    HinhThucDaoTaoHocNangCao = row.d.hinhThucDaoTao,
                    NgonNguDaoTaoHocNangCao = row.d.ngonNguDaoTao,
                    NuocCapBangHocNangCao = row.d.nuocCapBang,
                    TrinhDoHocNangCao = HardCodeTrinhDoHocNangCao(row.d.tenHocHamHocVi)
                });
            }
            return listHocHamHocVi_DanghocNangCaoForView;
        }

        private string HardCodePhanLoaiNganhHocVaGiangDay(int? phanloai)
        {
            switch (phanloai)
            {
                case 0:
                    return "Vừa học vừa dạy";
                case 1:
                    return "Chỉ học";
                case 2:
                    return "Chỉ dạy";
                default:
                    return "";
            }
        }

        private string HardCodeTrinhDoHocNangCao(string tenHocHamHocVi)
        {
            if (tenHocHamHocVi.Contains("TS "))
            {
                return "Nghiên cứu sinh ";
            }
            else if (tenHocHamHocVi.Contains("ThS "))
            {
                return "Cao học";
            }
            else return "";
        }

        private string HardCodeTinhTrang(int? loai)
        {
            switch (loai)
            {
                case 0:
                    return "Đang học";
                case 1:
                    return "Đã xong";
                case 2:
                    return "Gia hạn";
                case 3:
                    return "Hết hạn";
                default:
                    return "";
            }
        }

        public string HardCodeHocNangCao(string hocnangcao)
        {
            string rs = "";
            if(hocnangcao.Contains("TS ") && hocnangcao.Contains("ThS ") == false)
            {
                rs = hocnangcao.Replace("TS ", "Nghiên cứu sinh ");
            }
            else if(hocnangcao.Contains("TS ") == false && hocnangcao.Contains("ThS "))
            {
                rs = hocnangcao.Replace("ThS ", "Cao học ");
            }
            return rs;
        }
    }
}
