using Model.Entities;
using Model.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public class TrangThaiVienChucRepository : Repository<TrangThaiVienChuc>
    {
        public TrangThaiVienChucRepository(QLNSSGU_1Entities db) : base(db)
        {
        }

        public List<TrangThaiForExport> GetListTrangThaiForExport()
        {
            VienChucRepository vienChucRepository = new VienChucRepository(_db);
            List<TrangThaiForExport> listTrangThaiForExport = new List<TrangThaiForExport>();
            List<TrangThaiVienChuc> listTrangThaiVienChuc = _db.TrangThaiVienChucs.ToList();
            for (int i = 0; i < listTrangThaiVienChuc.Count; i++)
            {
                listTrangThaiForExport.Add(new TrangThaiForExport
                {
                    MaVienChuc = listTrangThaiVienChuc[i].VienChuc.maVienChuc,
                    Ho = listTrangThaiVienChuc[i].VienChuc.ho,
                    Ten = listTrangThaiVienChuc[i].VienChuc.ten,
                    SoDienThoai = listTrangThaiVienChuc[i].VienChuc.sDT,
                    GioiTinh = vienChucRepository.ReturnGenderToGrid(listTrangThaiVienChuc[i].VienChuc.gioiTinh),
                    NgaySinh = listTrangThaiVienChuc[i].VienChuc.ngaySinh,
                    NoiSinh = listTrangThaiVienChuc[i].VienChuc.noiSinh,
                    QueQuan = listTrangThaiVienChuc[i].VienChuc.queQuan,
                    DanToc = listTrangThaiVienChuc[i].VienChuc.DanToc.tenDanToc,
                    TonGiao = listTrangThaiVienChuc[i].VienChuc.TonGiao.tenTonGiao,
                    HoKhauThuongTru = listTrangThaiVienChuc[i].VienChuc.hoKhauThuongTru,
                    NoiOHienNay = listTrangThaiVienChuc[i].VienChuc.noiOHienNay,
                    LaDangVien = listTrangThaiVienChuc[i].VienChuc.laDangVien,
                    NgayVaoDang = listTrangThaiVienChuc[i].VienChuc.ngayVaoDang,
                    NgayThamGiaCongTac = listTrangThaiVienChuc[i].VienChuc.ngayThamGiaCongTac,
                    NgayVaoNganh = listTrangThaiVienChuc[i].VienChuc.ngayVaoNganh,
                    NgayVeTruong = listTrangThaiVienChuc[i].VienChuc.ngayVeTruong,
                    VanHoa = listTrangThaiVienChuc[i].VienChuc.vanHoa,
                    QuanLyNhaNuoc = listTrangThaiVienChuc[i].VienChuc.QuanLyNhaNuoc.tenQuanLyNhaNuoc,
                    ChinhTri = listTrangThaiVienChuc[i].VienChuc.ChinhTri.tenChinhTri,
                    GhiChu = listTrangThaiVienChuc[i].VienChuc.ghiChu,
                    TrangThai = listTrangThaiVienChuc[i].TrangThai.tenTrangThai,
                    DiaDiem = listTrangThaiVienChuc[i].diaDiem,
                    NgayBatDau = listTrangThaiVienChuc[i].ngayBatDau,
                    NgayKetThuc = listTrangThaiVienChuc[i].ngayKetThuc,
                    MoTa = listTrangThaiVienChuc[i].moTa,
                    LinkVanBanDinhKem = listTrangThaiVienChuc[i].linkVanBanDinhKem
                });
            }
            return listTrangThaiForExport;
        }

        public void Update(string mavienchuc, DateTime ngaybatdau, DateTime ngayketthuc, string mota, string diadiem)
        {
            int idvienchuc = _db.VienChucs.Where(x => x.maVienChuc == mavienchuc).Select(y => y.idVienChuc).FirstOrDefault();
            TrangThaiVienChuc trangThaiVienChuc = _db.TrangThaiVienChucs.Where(x => x.idVienChuc == idvienchuc).FirstOrDefault();
            trangThaiVienChuc.idTrangThai = 2;
            trangThaiVienChuc.ngayBatDau = ngaybatdau;
            trangThaiVienChuc.ngayKetThuc = ngayketthuc;
            trangThaiVienChuc.moTa = mota;
            trangThaiVienChuc.diaDiem = diadiem;
            _db.SaveChanges();
        }

        public List<TrangThaiForView> GetListTrangThaiVienChuc(string mavienchuc)
        {
            int idvienchuc = _db.VienChucs.Where(x => x.maVienChuc == mavienchuc).Select(y => y.idVienChuc).FirstOrDefault();
            List<TrangThaiVienChuc> listTrangThaiVienChuc = _db.TrangThaiVienChucs.Where(x => x.idVienChuc == idvienchuc).ToList();
            List<TrangThaiForView> listTrangThaiForView = new List<TrangThaiForView>();
            for(int i = listTrangThaiVienChuc.Count - 1; i >= 0; i--)
            {
                listTrangThaiForView.Add(new TrangThaiForView
                {
                    Id = listTrangThaiVienChuc[i].idTrangThaiVienChuc,
                    TrangThai = listTrangThaiVienChuc[i].TrangThai.tenTrangThai,
                    MoTa = listTrangThaiVienChuc[i].moTa,
                    DiaDiem = listTrangThaiVienChuc[i].diaDiem,
                    NgayBatDau = listTrangThaiVienChuc[i].ngayBatDau,
                    NgayKetThuc = listTrangThaiVienChuc[i].ngayKetThuc,
                    LinkVanBanDinhKem = listTrangThaiVienChuc[i].linkVanBanDinhKem
                });
            }
            return listTrangThaiForView;
        }

        public TrangThaiVienChuc GetObjectById(int idtrangthaivienchuc)
        {
            return _db.TrangThaiVienChucs.Where(x => x.idTrangThaiVienChuc == idtrangthaivienchuc).FirstOrDefault();
        }

        public void DeleteById(int id)
        {
            var a = _db.TrangThaiVienChucs.Where(x => x.idTrangThaiVienChuc == id).FirstOrDefault();
            _db.TrangThaiVienChucs.Remove(a);
        }
    }
}
