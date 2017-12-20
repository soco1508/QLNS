using Model.Entities;
using Model.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public class ChungChiVienChucRepository : Repository<ChungChiVienChuc>
    {
        public ChungChiVienChucRepository(QLNSSGU_1Entities db) : base(db)
        {
        }

        public List<ChungChiForExport> GetListChungChiForExport()
        {
            VienChucRepository vienChucRepository = new VienChucRepository(_db);
            List<ChungChiForExport> listChungChiForExport = new List<ChungChiForExport>();
            List<ChungChiVienChuc> listChungChiVienChuc = _db.ChungChiVienChucs.ToList();
            for (int i = 0; i < listChungChiVienChuc.Count; i++)
            {
                listChungChiForExport.Add(new ChungChiForExport
                {
                    MaVienChuc = listChungChiVienChuc[i].VienChuc.maVienChuc,
                    Ho = listChungChiVienChuc[i].VienChuc.ho,
                    Ten = listChungChiVienChuc[i].VienChuc.ten,
                    SoDienThoai = listChungChiVienChuc[i].VienChuc.sDT,
                    GioiTinh = vienChucRepository.ReturnGenderToGrid(listChungChiVienChuc[i].VienChuc.gioiTinh),
                    NgaySinh = listChungChiVienChuc[i].VienChuc.ngaySinh,
                    NoiSinh = listChungChiVienChuc[i].VienChuc.noiSinh,
                    QueQuan = listChungChiVienChuc[i].VienChuc.queQuan,
                    DanToc = listChungChiVienChuc[i].VienChuc.DanToc.tenDanToc,
                    TonGiao = listChungChiVienChuc[i].VienChuc.TonGiao.tenTonGiao,
                    HoKhauThuongTru = listChungChiVienChuc[i].VienChuc.hoKhauThuongTru,
                    NoiOHienNay = listChungChiVienChuc[i].VienChuc.noiOHienNay,
                    LaDangVien = listChungChiVienChuc[i].VienChuc.laDangVien,
                    NgayVaoDang = listChungChiVienChuc[i].VienChuc.ngayVaoDang,
                    NgayThamGiaCongTac = listChungChiVienChuc[i].VienChuc.ngayThamGiaCongTac,
                    NgayVaoNganh = listChungChiVienChuc[i].VienChuc.ngayVaoNganh,
                    NgayVeTruong = listChungChiVienChuc[i].VienChuc.ngayVeTruong,
                    VanHoa = listChungChiVienChuc[i].VienChuc.vanHoa,
                    QuanLyNhaNuoc = listChungChiVienChuc[i].VienChuc.QuanLyNhaNuoc.tenQuanLyNhaNuoc,
                    ChinhTri = listChungChiVienChuc[i].VienChuc.ChinhTri.tenChinhTri,
                    GhiChu = listChungChiVienChuc[i].VienChuc.ghiChu,
                    LoaiChungChi = listChungChiVienChuc[i].LoaiChungChi.tenLoaiChungChi,
                    CapDo = listChungChiVienChuc[i].LoaiChungChi.capDo,
                    NgayCapChungChi = listChungChiVienChuc[i].ngayCapChungChi,
                    LinkVanBanDinhKem = listChungChiVienChuc[i].linkVanBanDinhKem,
                    GhiChuCC = listChungChiVienChuc[i].ghiChu
                });
            }
            return listChungChiForExport;
        }

        public List<ChungChiForView> GetListChungChiVienChuc(string mavienchuc)
        {
            int idvienchuc = _db.VienChucs.Where(x => x.maVienChuc == mavienchuc).Select(y => y.idVienChuc).FirstOrDefault();
            List<ChungChiVienChuc> listChungChiVienChuc = _db.ChungChiVienChucs.Where(x => x.idVienChuc == idvienchuc).ToList();
            List<ChungChiForView> listChungChiForView = new List<ChungChiForView>();
            for(int i = 0; i < listChungChiVienChuc.Count; i++)
            {
                listChungChiForView.Add(new ChungChiForView
                {
                    Id = listChungChiVienChuc[i].idChungChiVienChuc,
                    IdLoaiChungChi = listChungChiVienChuc[i].idLoaiChungChi,
                    LoaiChungChi = listChungChiVienChuc[i].LoaiChungChi.tenLoaiChungChi,
                    CapDo = listChungChiVienChuc[i].LoaiChungChi.capDo,
                    NgayCapChungChi = listChungChiVienChuc[i].ngayCapChungChi,
                    LinkVanBanDinhKem = listChungChiVienChuc[i].linkVanBanDinhKem,
                    GhiChu = listChungChiVienChuc[i].ghiChu
                });
            }
            return listChungChiForView;
        }

        public void DeleteById(int id)
        {
            _db.ChungChiVienChucs.Remove(_db.ChungChiVienChucs.Where(x => x.idChungChiVienChuc == id).FirstOrDefault());
        }

        public ChungChiVienChuc GetObjectById(int idchungchivienchuc)
        {
            return _db.ChungChiVienChucs.Where(x => x.idChungChiVienChuc == idchungchivienchuc).FirstOrDefault();
        }
    }
}
