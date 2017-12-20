using Model.Entities;
using Model.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public class HopDongVienChucRepository : Repository<HopDongVienChuc>
    {
        public HopDongVienChucRepository(QLNSSGU_1Entities db) : base(db)
        {
        }

        public List<HopDongForExport> GetListHopDongForExport()
        {
            VienChucRepository vienChucRepository = new VienChucRepository(_db);
            List<HopDongForExport> listHopDongForExport = new List<HopDongForExport>();
            List<HopDongVienChuc> listHopDongVienChuc = _db.HopDongVienChucs.ToList();
            for(int i = 0; i < listHopDongVienChuc.Count; i++)
            {
                listHopDongForExport.Add(new HopDongForExport
                {
                    MaVienChuc = listHopDongVienChuc[i].VienChuc.maVienChuc,
                    Ho = listHopDongVienChuc[i].VienChuc.ho,
                    Ten = listHopDongVienChuc[i].VienChuc.ten,
                    SoDienThoai = listHopDongVienChuc[i].VienChuc.sDT,
                    GioiTinh = vienChucRepository.ReturnGenderToGrid(listHopDongVienChuc[i].VienChuc.gioiTinh),
                    NgaySinh = listHopDongVienChuc[i].VienChuc.ngaySinh,
                    NoiSinh = listHopDongVienChuc[i].VienChuc.noiSinh,
                    QueQuan = listHopDongVienChuc[i].VienChuc.queQuan,
                    DanToc = listHopDongVienChuc[i].VienChuc.DanToc.tenDanToc,
                    TonGiao = listHopDongVienChuc[i].VienChuc.TonGiao.tenTonGiao,
                    HoKhauThuongTru = listHopDongVienChuc[i].VienChuc.hoKhauThuongTru,
                    NoiOHienNay = listHopDongVienChuc[i].VienChuc.noiOHienNay,
                    LaDangVien = listHopDongVienChuc[i].VienChuc.laDangVien,
                    NgayVaoDang = listHopDongVienChuc[i].VienChuc.ngayVaoDang,
                    NgayThamGiaCongTac = listHopDongVienChuc[i].VienChuc.ngayThamGiaCongTac,
                    NgayVaoNganh = listHopDongVienChuc[i].VienChuc.ngayVaoNganh,
                    NgayVeTruong = listHopDongVienChuc[i].VienChuc.ngayVeTruong,
                    VanHoa = listHopDongVienChuc[i].VienChuc.vanHoa,
                    QuanLyNhaNuoc = listHopDongVienChuc[i].VienChuc.QuanLyNhaNuoc.tenQuanLyNhaNuoc,
                    ChinhTri = listHopDongVienChuc[i].VienChuc.ChinhTri.tenChinhTri,
                    GhiChu = listHopDongVienChuc[i].VienChuc.ghiChu,
                    MaHopDong = listHopDongVienChuc[i].LoaiHopDong.maLoaiHopDong,
                    TenHopDong = listHopDongVienChuc[i].LoaiHopDong.tenLoaiHopDong,
                    NgayBatDau = listHopDongVienChuc[i].ngayBatDau,
                    NgayKetThuc = listHopDongVienChuc[i].ngayKetThuc,
                    MoTa = listHopDongVienChuc[i].moTa,
                    LinkVanBanDinhKem = listHopDongVienChuc[i].linkVanBanDinhKem
                });
            }
            return listHopDongForExport;
        }

        public List<HopDongForView> GetListHopDongVienChuc(string mavienchuc)
        {
            int idvienchuc = _db.VienChucs.Where(x => x.maVienChuc == mavienchuc).Select(y => y.idVienChuc).FirstOrDefault();
            List<HopDongVienChuc> listHopDongVienChuc = _db.HopDongVienChucs.Where(x => x.idVienChuc == idvienchuc).ToList();
            List<HopDongForView> listHopDong = new List<HopDongForView>();
            for(int i = 0; i < listHopDongVienChuc.Count; i++)
            {
                listHopDong.Add(new HopDongForView
                {
                    Id = listHopDongVienChuc[i].idHopDongVienChuc,
                    LoaiHopDong = listHopDongVienChuc[i].LoaiHopDong.tenLoaiHopDong,
                    NgayBatDau = listHopDongVienChuc[i].ngayBatDau,
                    NgayKetThuc = listHopDongVienChuc[i].ngayKetThuc,
                    LinkVanBanDinhKem = listHopDongVienChuc[i].linkVanBanDinhKem,
                    GhiChu = listHopDongVienChuc[i].moTa
                });
            }
            return listHopDong;
        }

        public DateTime? ReturnDateTimeToDatabase(string datetime)
        {
            if (datetime == "")
            {
                return null;
            }
            else
            {
                return Convert.ToDateTime(datetime);
            }
        }

        public HopDongVienChuc GetObjectById(int idhopdongvienchuc)
        {
            return _db.HopDongVienChucs.Where(x => x.idHopDongVienChuc == idhopdongvienchuc).FirstOrDefault();
        }

        public void DeleteById(int id)
        {
            var a = _db.HopDongVienChucs.Where(x => x.idHopDongVienChuc == id).FirstOrDefault();
            _db.HopDongVienChucs.Remove(a);
        }
    }
}
