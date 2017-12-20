using Model.Entities;
using Model.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public class ChucVuDonViVienChucRepository : Repository<ChucVuDonViVienChuc>
    {
        public ChucVuDonViVienChucRepository(QLNSSGU_1Entities db) : base(db)
        {
        }

        public List<QuaTrinhCongTacForView> GetListQuaTrinhCongTac(string mavienchuc)
        {
            int idvienchuc = _db.VienChucs.Where(x => x.maVienChuc == mavienchuc).Select(y => y.idVienChuc).FirstOrDefault();
            List<ChucVuDonViVienChuc> listChucVuDonViVienChuc = _db.ChucVuDonViVienChucs.Where(x => x.idVienChuc == idvienchuc).ToList();
            List<QuaTrinhCongTacForView> listQuaTrinhCongTac = new List<QuaTrinhCongTacForView>();
            for (int i = 0; i < listChucVuDonViVienChuc.Count; i++)
            {
                listQuaTrinhCongTac.Add(new QuaTrinhCongTacForView
                {
                    Id = listChucVuDonViVienChuc[i].idViTriDonViVienChuc,
                    ChucVu = listChucVuDonViVienChuc[i].ChucVu.tenChucVu,
                    DonVi = listChucVuDonViVienChuc[i].DonVi.tenDonVi,
                    ToChuyenMon = listChucVuDonViVienChuc[i].ToChuyenMon.tenToChuyenMon,
                    DiaDiem = listChucVuDonViVienChuc[i].DonVi.diaDiem,
                    NgayBatDau = listChucVuDonViVienChuc[i].ngayBatDau,
                    NgayKetThuc = listChucVuDonViVienChuc[i].ngayKetThuc,
                    PhanLoaiCongTac = listChucVuDonViVienChuc[i].phanLoaiCongTac,
                    HeSoChucVu = listChucVuDonViVienChuc[i].ChucVu.heSoChucVu,
                    CheckPhanLoaiCongTac = HardCheckPhanLoaiCongTacToGrid(listChucVuDonViVienChuc[i].checkPhanLoaiCongTac),
                    LoaiThayDoi = HardLoaiThayDoiToGrid(listChucVuDonViVienChuc[i].loaiThayDoi),
                    KiemNhiem = HardKiemNhiemToGrid(listChucVuDonViVienChuc[i].kiemNhiem),
                    LinkVanBanDinhKem = listChucVuDonViVienChuc[i].linkVanBanDinhKem
                });
            }
            return listQuaTrinhCongTac;
        }

        public void Update(int id, string linkfiledinhkem)
        {
            ChucVuDonViVienChuc chucVuDonViVienChuc = _db.ChucVuDonViVienChucs.Where(x => x.idViTriDonViVienChuc == id).FirstOrDefault();
            chucVuDonViVienChuc.linkVanBanDinhKem = linkfiledinhkem;
        }

        public List<QuaTrinhCongTacForExport> GetListQuaTrinhCongTacForExport()
        {
            VienChucRepository vienChucRepository = new VienChucRepository(_db);
            List<QuaTrinhCongTacForExport> listQuaTrinhCongTacForExport = new List<QuaTrinhCongTacForExport>();
            List<ChucVuDonViVienChuc> listChucVuDonViVienChuc = _db.ChucVuDonViVienChucs.ToList();
            for (int i = 0; i < listChucVuDonViVienChuc.Count; i++)
            {
                listQuaTrinhCongTacForExport.Add(new QuaTrinhCongTacForExport
                {
                    MaVienChuc = listChucVuDonViVienChuc[i].VienChuc.maVienChuc,
                    Ho = listChucVuDonViVienChuc[i].VienChuc.ho,
                    Ten = listChucVuDonViVienChuc[i].VienChuc.ten,
                    SoDienThoai = listChucVuDonViVienChuc[i].VienChuc.sDT,
                    GioiTinh = vienChucRepository.ReturnGenderToGrid(listChucVuDonViVienChuc[i].VienChuc.gioiTinh),
                    NgaySinh = listChucVuDonViVienChuc[i].VienChuc.ngaySinh,
                    NoiSinh = listChucVuDonViVienChuc[i].VienChuc.noiSinh,
                    QueQuan = listChucVuDonViVienChuc[i].VienChuc.queQuan,
                    DanToc = listChucVuDonViVienChuc[i].VienChuc.DanToc.tenDanToc,
                    TonGiao = listChucVuDonViVienChuc[i].VienChuc.TonGiao.tenTonGiao,
                    HoKhauThuongTru = listChucVuDonViVienChuc[i].VienChuc.hoKhauThuongTru,
                    NoiOHienNay = listChucVuDonViVienChuc[i].VienChuc.noiOHienNay,
                    LaDangVien = listChucVuDonViVienChuc[i].VienChuc.laDangVien,
                    NgayVaoDang = listChucVuDonViVienChuc[i].VienChuc.ngayVaoDang,
                    NgayThamGiaCongTac = listChucVuDonViVienChuc[i].VienChuc.ngayThamGiaCongTac,
                    NgayVaoNganh = listChucVuDonViVienChuc[i].VienChuc.ngayVaoNganh,
                    NgayVeTruong = listChucVuDonViVienChuc[i].VienChuc.ngayVeTruong,
                    VanHoa = listChucVuDonViVienChuc[i].VienChuc.vanHoa,
                    QuanLyNhaNuoc = listChucVuDonViVienChuc[i].VienChuc.QuanLyNhaNuoc.tenQuanLyNhaNuoc,
                    ChinhTri = listChucVuDonViVienChuc[i].VienChuc.ChinhTri.tenChinhTri,
                    GhiChu = listChucVuDonViVienChuc[i].VienChuc.ghiChu,
                    LoaiChucVu = listChucVuDonViVienChuc[i].ChucVu.LoaiChucVu.tenLoaiChucVu,
                    ChucVu = listChucVuDonViVienChuc[i].ChucVu.tenChucVu,
                    HeSoChucVu=listChucVuDonViVienChuc[i].ChucVu.heSoChucVu,
                    LoaiDonVi = listChucVuDonViVienChuc[i].DonVi.LoaiDonVi.tenLoaiDonVi,
                    DonVi=listChucVuDonViVienChuc[i].DonVi.tenDonVi,
                    DiaDiem=listChucVuDonViVienChuc[i].DonVi.diaDiem,
                    DiaChi=listChucVuDonViVienChuc[i].DonVi.diaChi,
                    SoDienThoaiDonVi=listChucVuDonViVienChuc[i].DonVi.sDT,
                    ToChuyenMon=listChucVuDonViVienChuc[i].ToChuyenMon.tenToChuyenMon,
                    PhanLoaiCongTac=listChucVuDonViVienChuc[i].phanLoaiCongTac,
                    CheckPhanLoaiCongTac=HardCheckPhanLoaiCongTacToGrid(listChucVuDonViVienChuc[i].checkPhanLoaiCongTac),
                    NgayBatDau = listChucVuDonViVienChuc[i].ngayBatDau,
                    NgayKetThuc = listChucVuDonViVienChuc[i].ngayKetThuc,
                    LoaiThayDoi = HardLoaiThayDoiToGrid(listChucVuDonViVienChuc[i].loaiThayDoi),
                    KiemNhiem = HardKiemNhiemToGrid(listChucVuDonViVienChuc[i].kiemNhiem),
                    LinkVanBanDinhKem = listChucVuDonViVienChuc[i].linkVanBanDinhKem
                });
            }
            return listQuaTrinhCongTacForExport;
        }

        public double? GetHeSoChucVu(string hesochucvu)
        {
            if (hesochucvu != string.Empty)
            {
                double a = Math.Round(Convert.ToDouble(hesochucvu), 2);
                return a;
            }
            return 0;
        }

        private string HardCheckPhanLoaiCongTacToGrid(int? checkphanloaicongtac)
        {
            switch (checkphanloaicongtac)
            {
                case 0:
                    return "Chức vụ quá khứ";
                case 1:
                    return "Một chức vụ hiện tại";
                case 2:
                    return "Nhiều chức vụ hiện tại";
                case 3:
                    return "";
                default:
                    return "";
            }
        }
        private string HardKiemNhiemToGrid(int? kiemnhiem)
        {
            switch (kiemnhiem)
            {
                case 0:
                    return "Có";
                case 1:
                    return "Không";
                case 2:
                    return "";
                default:
                    return "";
            }
        }
        private string HardLoaiThayDoiToGrid(int? loaithaydoi)
        {
            switch (loaithaydoi)
            {
                case 0:
                    return "Chưa thay đổi";
                case 1:
                    return "Thay đổi chức vụ";
                case 2:
                    return "Thay đổi đơn vị";
                case 3:
                    return "Thay đổi tổ bộ môn";
                case 4:
                    return "";
                default:
                    return "";
            }
        }
        public int? HardCheckPhanLoaiCongTacToDatabase(string checkphanloaicongtac)
        {
            switch (checkphanloaicongtac)
            {
                case "Chức vụ quá khứ":
                    return 0;
                case "Một chức vụ hiện tại":
                    return 1;
                case "Nhiều chức vụ hiện tại":
                    return 2;
                case "":
                    return 3;
                default:
                    return 3;
            }
        }

        public int? HardKiemNhiemToDatabase(string kiemnhiem)
        {
            switch (kiemnhiem)
            {
                case "Có":
                    return 0;
                case "Không":
                    return 1;
                case "":
                    return 2;
                default:
                    return 2;
            }
        }

        public int? HardLoaiThayDoiToDatabase(string loaithaydoi)
        {
            switch (loaithaydoi)
            {
                case "Chưa thay đổi":
                    return 0;
                case "Thay đổi chức vụ":
                    return 1;
                case "Thay đổi đơn vị":
                    return 2;
                case "Thay đổi tổ bộ môn":
                    return 3;
                case "":
                    return 4;
                default:
                    return 4;
            }
        }

        public ChucVuDonViVienChuc GetObjectById(int idchucvudonvivienchuc)
        {
            return _db.ChucVuDonViVienChucs.Where(x => x.idVienChuc == idchucvudonvivienchuc).FirstOrDefault();
        }

        public void DeleteById(int id)
        {
            ChucVuDonViVienChuc chucVuDonViVienChuc = _db.ChucVuDonViVienChucs.Where(x => x.idViTriDonViVienChuc == id).FirstOrDefault();
            _db.ChucVuDonViVienChucs.Remove(chucVuDonViVienChuc);
        }
    }
}
