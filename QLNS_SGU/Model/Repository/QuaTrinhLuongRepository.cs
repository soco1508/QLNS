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

        public List<QuaTrinhLuongForView> GetListQuaTrinhLuong(string mavienchuc)
        {
            int idvienchuc = _db.VienChucs.Where(x => x.maVienChuc == mavienchuc).Select(y => y.idVienChuc).FirstOrDefault();
            List<QuaTrinhLuong> listQuaTrinhLuong = _db.QuaTrinhLuongs.Where(x => x.idVienChuc == idvienchuc).ToList();
            List<QuaTrinhLuongForView> listQuaTrinhLuongForView = new List<QuaTrinhLuongForView>();
            for (int i = listQuaTrinhLuong.Count - 1; i >= 0; i--)
            {
                listQuaTrinhLuongForView.Add(new QuaTrinhLuongForView
                {
                    Id = listQuaTrinhLuong[i].idQuaTrinhLuong,
                    MaNgach = listQuaTrinhLuong[i].Bac.Ngach.maNgach,
                    TenNgach = listQuaTrinhLuong[i].Bac.Ngach.tenNgach,
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

        public QuaTrinhLuong GetObjectByIdVienChucAndTimeline(int idVienChuc, DateTime dtTimeline)
        {
            var rows = _db.QuaTrinhLuongs.Where(x => x.idVienChuc == idVienChuc);
            QuaTrinhLuong obj = null;
            foreach (var row in rows)
            {
                if (row.ngayLenLuong != null)
                {
                    if (row.ngayBatDau <= dtTimeline && row.ngayLenLuong >= dtTimeline)
                    {
                        obj = new QuaTrinhLuong(rows.Where(x => x.idQuaTrinhLuong == row.idQuaTrinhLuong).OrderByDescending(y => y.idQuaTrinhLuong).FirstOrDefault());
                    }
                }
                else
                {
                    if (row.ngayBatDau <= dtTimeline)
                    {
                        obj = new QuaTrinhLuong(rows.Where(x => x.idQuaTrinhLuong == row.idQuaTrinhLuong).OrderByDescending(y => y.idQuaTrinhLuong).FirstOrDefault());
                    }
                }
            }
            return obj;
        }

        public QuaTrinhLuong GetObjectByIdVienChucAndPeriodOfTime(int idVienChuc, DateTime dtFromPeriodOfTime, DateTime dtToPeriodOfTime)
        {
            var rows = _db.QuaTrinhLuongs.Where(x => x.idVienChuc == idVienChuc);
            QuaTrinhLuong obj = null;
            foreach (var row in rows)
            {
                if (row.ngayLenLuong != null)
                {
                    if (row.ngayBatDau >= dtFromPeriodOfTime && row.ngayLenLuong <= dtToPeriodOfTime)
                    {
                        obj = new QuaTrinhLuong(rows.Where(x => x.idQuaTrinhLuong == row.idQuaTrinhLuong).FirstOrDefault());
                    }
                }
                else
                {
                    if (row.ngayBatDau >= dtFromPeriodOfTime)
                    {
                        obj = new QuaTrinhLuong(rows.Where(x => x.idQuaTrinhLuong == row.idQuaTrinhLuong).FirstOrDefault());
                    }
                }
            }
            return obj;
        }

        public List<string> GetListLinkVanBanDinhKem(string maVienChucForGetListLinkAnhQuyetDinh)
        {
            return _db.QuaTrinhLuongs.Where(x => x.VienChuc.maVienChuc == maVienChucForGetListLinkAnhQuyetDinh).Select(y => y.linkVanBanDinhKem).ToList();
        }
    }
}
