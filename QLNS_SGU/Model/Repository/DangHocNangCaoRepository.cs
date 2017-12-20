using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;
using Model.ObjectModels;

namespace Model.Repository
{
    public class DangHocNangCaoRepository : Repository<DangHocNangCao>
    {
        public DangHocNangCaoRepository(QLNSSGU_1Entities db) : base(db)
        {
        }

        public List<DangHocNangCaoForView> GetListDangHocNangCao(string mavienchuc)
        {
            int idvienchuc = _db.VienChucs.Where(x => x.maVienChuc == mavienchuc).Select(y => y.idVienChuc).FirstOrDefault();
            HocHamHocVi_DangHocNangCao_NganhRepository repo = new HocHamHocVi_DangHocNangCao_NganhRepository(_db);
            List<DangHocNangCao> listDangHocNangCao = _db.DangHocNangCaos.Where(x => x.idVienChuc == idvienchuc).ToList();
            List<DangHocNangCaoForView> listDangHocNangCaoForView = new List<DangHocNangCaoForView>();
            for (int i = 0; i < listDangHocNangCao.Count; i++)
            {
                listDangHocNangCaoForView.Add(new DangHocNangCaoForView
                {
                    Id = listDangHocNangCao[i].idDangHocNangCao,
                    LoaiHocHamHocVi = HardCodeLoaiHocHamHocViToGrid(listDangHocNangCao[i].LoaiHocHamHocVi.tenLoaiHocHamHocVi),
                    SoQuyetDinh = listDangHocNangCao[i].soQuyetDinh,
                    LinkAnhQuyetDinh = listDangHocNangCao[i].linkAnhQuyetDinh,
                    TenHocHamHocVi = repo.HardCodeHocNangCao(listDangHocNangCao[i].tenHocHamHocVi),
                    CoSoDaoTao = listDangHocNangCao[i].coSoDaoTao,
                    NgonNguDaoTao = listDangHocNangCao[i].ngonNguDaoTao,
                    HinhThucDaoTao = listDangHocNangCao[i].hinhThucDaoTao,
                    NuocCapBang = listDangHocNangCao[i].nuocCapBang,
                    NgayBatDau = listDangHocNangCao[i].ngayBatDau,
                    NgayKetThuc = listDangHocNangCao[i].ngayKetThuc,
                    Loai = HardCodeLoaiToGrid(listDangHocNangCao[i].loai)
                });
            }
            return listDangHocNangCaoForView;
        }

        private string HardCodeLoaiHocHamHocViToGrid(string tenLoaiHocHamHocVi)
        {
            switch (tenLoaiHocHamHocVi)
            {
                case "Thạc sĩ":
                    return "Cao học";
                case "Tiến sĩ":
                    return "Nghiên cứu sinh";
                default:
                    return "";
            }
        }

        private string HardCodeLoaiToGrid(int? loai)
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

        public DateTime? ParseDatetimeMatchDatetimeDatabase(string s)
        {
            if(s != string.Empty)
            {
                if (s.Contains("/"))
                {
                    return Convert.ToDateTime(s);
                }
                else
                {
                    return Convert.ToDateTime("01/01/" + s); // s = 2017
                }
            }
            return null;
        }

        public string ConcatString(string trinhdo, string chuyennganh)
        {
            switch (trinhdo)
            {
                case "cao học":
                    return "ThS " + chuyennganh;
                case "nghiên cứu sinh":
                    return "TS " + chuyennganh;
                default:
                    return "";
            }
        }

        public int? HardCodeLoaiToDatabase(string loai)
        {
            switch (loai)
            {
                case "Đang học":
                    return 0;
                case "Đã xong":
                    return 1;
                case "Gia hạn":
                    return 2;
                case "Hết hạn":
                    return 3;
                default:
                    return 0;
            }
        }

        public List<DangHocNangCaoForExport> GetListDangHocNangCaoForExport()
        {
            VienChucRepository vienChucRepository = new VienChucRepository(_db);
            HocHamHocVi_DangHocNangCao_NganhRepository repo = new HocHamHocVi_DangHocNangCao_NganhRepository(_db);
            List<DangHocNangCaoForExport> listDangHocNangCaoForExport = new List<DangHocNangCaoForExport>();
            List<DangHocNangCao> listDangHocNangCao = _db.DangHocNangCaos.ToList();
            for (int i = 0; i < listDangHocNangCao.Count; i++)
            {
                listDangHocNangCaoForExport.Add(new DangHocNangCaoForExport
                {
                    MaVienChuc = listDangHocNangCao[i].VienChuc.maVienChuc,
                    Ho = listDangHocNangCao[i].VienChuc.ho,
                    Ten = listDangHocNangCao[i].VienChuc.ten,
                    SoDienThoai = listDangHocNangCao[i].VienChuc.sDT,
                    GioiTinh = vienChucRepository.ReturnGenderToGrid(listDangHocNangCao[i].VienChuc.gioiTinh),
                    NgaySinh = listDangHocNangCao[i].VienChuc.ngaySinh,
                    NoiSinh = listDangHocNangCao[i].VienChuc.noiSinh,
                    QueQuan = listDangHocNangCao[i].VienChuc.queQuan,
                    DanToc = listDangHocNangCao[i].VienChuc.DanToc.tenDanToc,
                    TonGiao = listDangHocNangCao[i].VienChuc.TonGiao.tenTonGiao,
                    HoKhauThuongTru = listDangHocNangCao[i].VienChuc.hoKhauThuongTru,
                    NoiOHienNay = listDangHocNangCao[i].VienChuc.noiOHienNay,
                    LaDangVien = listDangHocNangCao[i].VienChuc.laDangVien,
                    NgayVaoDang = listDangHocNangCao[i].VienChuc.ngayVaoDang,
                    NgayThamGiaCongTac = listDangHocNangCao[i].VienChuc.ngayThamGiaCongTac,
                    NgayVaoNganh = listDangHocNangCao[i].VienChuc.ngayVaoNganh,
                    NgayVeTruong = listDangHocNangCao[i].VienChuc.ngayVeTruong,
                    VanHoa = listDangHocNangCao[i].VienChuc.vanHoa,
                    QuanLyNhaNuoc = listDangHocNangCao[i].VienChuc.QuanLyNhaNuoc.tenQuanLyNhaNuoc,
                    ChinhTri = listDangHocNangCao[i].VienChuc.ChinhTri.tenChinhTri,
                    GhiChu = listDangHocNangCao[i].VienChuc.ghiChu,
                    LoaiHocHamHocVi = HardCodeLoaiHocHamHocViToGrid(listDangHocNangCao[i].LoaiHocHamHocVi.tenLoaiHocHamHocVi),
                    SoQuyetDinh = listDangHocNangCao[i].soQuyetDinh,
                    LinkAnhQuyetDinh = listDangHocNangCao[i].linkAnhQuyetDinh,
                    TenHocHamHocVi = repo.HardCodeHocNangCao(listDangHocNangCao[i].tenHocHamHocVi),
                    CoSoDaoTao = listDangHocNangCao[i].coSoDaoTao,
                    NgonNguDaoTao = listDangHocNangCao[i].ngonNguDaoTao,
                    HinhThucDaoTao = listDangHocNangCao[i].hinhThucDaoTao,
                    NuocCapBang = listDangHocNangCao[i].nuocCapBang,
                    NgayBatDau = listDangHocNangCao[i].ngayBatDau,
                    NgayKetThuc = listDangHocNangCao[i].ngayKetThuc,
                    Loai = HardCodeLoaiToGrid(listDangHocNangCao[i].loai)
                });
            }
            return listDangHocNangCaoForExport;
        }

        public DangHocNangCao GetObjectById(int iddanghocnangcao)
        {
            return _db.DangHocNangCaos.Where(x => x.idDangHocNangCao == iddanghocnangcao).FirstOrDefault();
        }

        public void DeleteById(int id)
        {
            var a = _db.DangHocNangCaos.Where(x => x.idDangHocNangCao == id).FirstOrDefault();
            _db.DangHocNangCaos.Remove(a);
        }
    }
}
