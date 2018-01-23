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

        public List<TrangThaiVienChuc> GetListTrangThaiByIdVienChucAndTimeline(int idVienChuc, DateTime dtTimeline)
        {
            var rows = _db.TrangThaiVienChucs.Where(x => x.idVienChuc == idVienChuc);
            List<TrangThaiVienChuc> listTrangThaiVienChuc = new List<TrangThaiVienChuc>();
            foreach (var row in rows)
            {
                if (row.ngayKetThuc != null)
                {
                    if (row.ngayBatDau <= dtTimeline && row.ngayKetThuc >= dtTimeline)
                    {
                        listTrangThaiVienChuc.Add(new TrangThaiVienChuc(row));
                    }
                }
                if (row.ngayKetThuc == null)
                {
                    if (row.ngayBatDau <= dtTimeline)
                    {
                        listTrangThaiVienChuc.Add(new TrangThaiVienChuc(row));
                    }
                }
            }
            return listTrangThaiVienChuc;
        }

        public TrangThaiVienChuc GetObjectByIdVienChucAndPeriodOfTime(int idVienChuc, DateTime dtFromPeriodOfTime, DateTime dtToPeriodOfTime)
        {
            var rows = _db.TrangThaiVienChucs.Where(x => x.idVienChuc == idVienChuc);
            TrangThaiVienChuc obj = null;
            foreach (var row in rows)
            {
                if (row.ngayKetThuc != null)
                {
                    if (row.ngayBatDau >= dtFromPeriodOfTime && row.ngayKetThuc <= dtToPeriodOfTime)
                    {
                        obj = new TrangThaiVienChuc(rows.Where(x => x.idTrangThaiVienChuc == row.idTrangThaiVienChuc).OrderByDescending(y => y.idTrangThaiVienChuc).FirstOrDefault());
                    }
                }
                else
                {
                    if (row.ngayBatDau >= dtFromPeriodOfTime)
                    {
                        obj = new TrangThaiVienChuc(rows.Where(x => x.idTrangThaiVienChuc == row.idTrangThaiVienChuc).OrderByDescending(y => y.idTrangThaiVienChuc).FirstOrDefault());
                    }
                }
            }
            return obj;
        }

        public List<string> GetListLinkVanBanDinhKem(string maVienChucForGetListLinkVanBanDinhKem)
        {
            return _db.TrangThaiVienChucs.Where(x => x.VienChuc.maVienChuc == maVienChucForGetListLinkVanBanDinhKem).Select(y => y.linkVanBanDinhKem).ToList();
        }
    }
}
