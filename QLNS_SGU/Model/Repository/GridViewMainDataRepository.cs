using Model.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace Model.Repository
{
    public class GridViewMainDataRepository : Repository<GridViewMainData>
    {
        public GridViewMainDataRepository(QLNSSGU_1Entities db) : base(db)
        {
        }

        public List<GridViewMainData> LoadDataToGrid()
        {
            var list = new List<GridViewMainData>();
            var rows = (from b in _db.VienChucs
                        from c in _db.DonVis
                        from d in _db.ChucVus
                        from e in _db.ChucVuDonViVienChucs
                        where b.idVienChuc == e.idVienChuc && e.idDonVi == c.idDonVi && e.idChucVu == d.idChucVu
                        select new { b.idVienChuc, b.maVienChuc, b.ngaySinh, b.ho, b.ten, b.gioiTinh, c.tenDonVi, d.tenChucVu });
            foreach (var row in rows)
            {
                list.Add(new GridViewMainData
                {
                    ChucVu = row.tenChucVu,
                    MaVienChuc = row.maVienChuc,
                    DonVi = row.tenDonVi,
                    Ho = row.ho,
                    Ten = row.ten,
                    NgaySinh = row.ngaySinh,
                    GioiTinh = CheckGioiTinh(row.gioiTinh),
                    TrinhDo = GetTrinhDoByBacHocHamHocVi(row.idVienChuc)
                });
            }
            return list;
        }

        private string CheckGioiTinh(bool? t)
        {
            if (t == true)
            {
                return "Nam";
            }
            return "Nữ";
        }

        private string GetTrinhDoByBacHocHamHocVi(int idvienchuc)
        {
            var list = _db.HocHamHocViVienChucs.Where(x => x.idVienChuc == idvienchuc).Select(y => y.bacHocHamHocVi).ToList();
            switch (list.Max())
            {
                case 1:
                    return "PT";
                case 2:
                    return "TC";
                case 3:
                    return "CĐ";
                case 4:
                    return "ĐH";
                case 5:
                    return "ThS";
                case 6:
                    return "TS";
                case 7:
                    return "PGS";
                case 8:
                    return "TS";
                default:
                    return "";
            }
        }
    }
}
