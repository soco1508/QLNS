using Model.Entities;
using Model.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public class QuaTrinhLuongRepository : Repository<QuaTrinhLuong>
    {
        public QuaTrinhLuongRepository(QLNSSGU_1Entities db) : base(db)
        {
        }

        public List<QuaTrinhLuongForExport> GetListQuaTrinhLuongForExport()
        {
            VienChucRepository vienChucRepository = new VienChucRepository(_db);
            List<QuaTrinhLuongForExport> listQuaTrinhLuongForExport = new List<QuaTrinhLuongForExport>();
            List<QuaTrinhLuong> listQuaTrinhLuong = _db.QuaTrinhLuongs.ToList();
            for(int i = 0; i < listQuaTrinhLuong.Count; i++)
            {
                listQuaTrinhLuongForExport.Add(new QuaTrinhLuongForExport
                {
                    MaVienChuc = listQuaTrinhLuong[i].VienChuc.maVienChuc,
                    Ho = listQuaTrinhLuong[i].VienChuc.ho,
                    Ten = listQuaTrinhLuong[i].VienChuc.ten,
                    SoDienThoai = listQuaTrinhLuong[i].VienChuc.sDT,
                    GioiTinh = vienChucRepository.ReturnGenderToGrid(listQuaTrinhLuong[i].VienChuc.gioiTinh),
                    NgaySinh = listQuaTrinhLuong[i].VienChuc.ngaySinh,
                    NoiSinh = listQuaTrinhLuong[i].VienChuc.noiSinh,
                    QueQuan = listQuaTrinhLuong[i].VienChuc.queQuan,
                    DanToc = listQuaTrinhLuong[i].VienChuc.DanToc.tenDanToc,
                    TonGiao = listQuaTrinhLuong[i].VienChuc.TonGiao.tenTonGiao,
                    HoKhauThuongTru = listQuaTrinhLuong[i].VienChuc.hoKhauThuongTru,
                    NoiOHienNay = listQuaTrinhLuong[i].VienChuc.noiOHienNay,
                    LaDangVien = listQuaTrinhLuong[i].VienChuc.laDangVien,
                    NgayVaoDang = listQuaTrinhLuong[i].VienChuc.ngayVaoDang,
                    NgayThamGiaCongTac = listQuaTrinhLuong[i].VienChuc.ngayThamGiaCongTac,
                    NgayVaoNganh = listQuaTrinhLuong[i].VienChuc.ngayVaoNganh,
                    NgayVeTruong = listQuaTrinhLuong[i].VienChuc.ngayVeTruong,
                    VanHoa = listQuaTrinhLuong[i].VienChuc.vanHoa,
                    QuanLyNhaNuoc = listQuaTrinhLuong[i].VienChuc.QuanLyNhaNuoc.tenQuanLyNhaNuoc,
                    ChinhTri = listQuaTrinhLuong[i].VienChuc.ChinhTri.tenChinhTri,
                    GhiChu = listQuaTrinhLuong[i].VienChuc.ghiChu,
                    MaNgach = listQuaTrinhLuong[i].Bac.Ngach.maNgach,
                    TenNgach = listQuaTrinhLuong[i].Bac.Ngach.tenNgach,
                    HeSoVuotKhungBaNamDau = listQuaTrinhLuong[i].Bac.Ngach.heSoVuotKhungBaNamDau,
                    HeSoVuotKhungTrenBaNam = listQuaTrinhLuong[i].Bac.Ngach.heSoVuotKhungTrenBaNam,
                    ThoiHanNangBac = listQuaTrinhLuong[i].Bac.Ngach.thoiHanNangBac,
                    Bac = listQuaTrinhLuong[i].Bac.bac1,
                    HeSoBac = listQuaTrinhLuong[i].Bac.heSoBac,
                    NgayBatDau = listQuaTrinhLuong[i].ngayBatDau,
                    NgayLenLuong = listQuaTrinhLuong[i].ngayLenLuong,
                    DangHuongLuong = listQuaTrinhLuong[i].dangHuongLuong,
                    LinkVanBanDinhKem = listQuaTrinhLuong[i].linkVanBanDinhKem
                });
            }
            return listQuaTrinhLuongForExport;
        }

        public List<QuaTrinhLuongForView> GetListQuaTrinhLuong(string mavienchuc)
        {
            int idvienchuc = _db.VienChucs.Where(x => x.maVienChuc == mavienchuc).Select(y => y.idVienChuc).FirstOrDefault();
            List<QuaTrinhLuong> listQuaTrinhLuong = _db.QuaTrinhLuongs.Where(x => x.idVienChuc == idvienchuc).ToList();
            List<QuaTrinhLuongForView> listQuaTrinhLuongForView = new List<QuaTrinhLuongForView>();
            for (int i = 0; i < listQuaTrinhLuong.Count; i++)
            {
                listQuaTrinhLuongForView.Add(new QuaTrinhLuongForView
                {
                    Id = listQuaTrinhLuong[i].idQuaTrinhLuong,
                    MaNgach = listQuaTrinhLuong[i].Bac.Ngach.maNgach,
                    Bac = listQuaTrinhLuong[i].Bac.bac1,
                    HeSoBac = listQuaTrinhLuong[i].Bac.heSoBac,
                    NgayBatDau = listQuaTrinhLuong[i].ngayBatDau,
                    NgayLenLuong = listQuaTrinhLuong[i].ngayLenLuong,
                    DangHuongLuong = listQuaTrinhLuong[i].dangHuongLuong,
                    LinkVanBanDinhKem = listQuaTrinhLuong[i].linkVanBanDinhKem
                });
            }
            return listQuaTrinhLuongForView;
        }

        private string SplitString(string s)
        {
            string[] words = s.Split('/');
            return words[1] + "/" + words[0] + "/" + words[2];
        }

        public DateTime? ParseDatetimeMatchDatetimeDatabase(string s)
        {
            string temp = SplitString(s);
            return Convert.ToDateTime(temp);
        }

        public QuaTrinhLuong GetObjectById(int idquatrinhluong)
        {
            return _db.QuaTrinhLuongs.Where(x => x.idQuaTrinhLuong == idquatrinhluong).FirstOrDefault();
        }

        public void DeleteById(int id)
        {
            var a = _db.QuaTrinhLuongs.Where(x => x.idQuaTrinhLuong == id).FirstOrDefault();
            _db.QuaTrinhLuongs.Remove(a);
        }
    }
}
