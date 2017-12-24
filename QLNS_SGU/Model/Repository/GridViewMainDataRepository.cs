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
            var rows = from a in _db.ChucVuDonViVienChucs
                       group a by a.idVienChuc into g
                       from p in g
                       where p.ngayKetThuc != null && p.ngayBatDau <= DateTime.Now && p.ngayKetThuc >= DateTime.Now
                       orderby p.VienChuc.maVienChuc
                       select new { p.ChucVu.tenChucVu, p.ChucVu.heSoChucVu, p.DonVi.tenDonVi, p.VienChuc.maVienChuc, p.VienChuc.ho, p.VienChuc.ten, p.VienChuc.ngaySinh, p.VienChuc.gioiTinh, p.idVienChuc };
            var temp_rows = from a in rows
                            group a by a.idVienChuc into g
                            from p in g
                            where p.heSoChucVu == g.Max(x => x.heSoChucVu)
                            orderby p.maVienChuc
                            select p;
            var rows1 = from a in _db.ChucVuDonViVienChucs
                        group a by a.idVienChuc into g
                        from p in g
                        where p.ngayKetThuc == null && p.ngayBatDau == g.Max(t => t.ngayBatDau)
                        select new { p.ChucVu.tenChucVu, p.ChucVu.heSoChucVu, p.DonVi.tenDonVi, p.VienChuc.maVienChuc, p.VienChuc.ho, p.VienChuc.ten, p.VienChuc.ngaySinh, p.VienChuc.gioiTinh, p.idVienChuc };
            var temp_rows1 = from a in rows1
                            group a by a.idVienChuc into g
                            from p in g
                            where p.heSoChucVu == g.Max(x => x.heSoChucVu)
                            orderby p.maVienChuc
                            select p;
            string tempMaVienChuc = "";
            double? tempHeSoCV = -1;
            foreach (var row in temp_rows)
            {
                if(row.maVienChuc.Equals(tempMaVienChuc) == true)
                {
                    if(tempHeSoCV < row.heSoChucVu)
                    {
                        list.Add(new GridViewMainData
                        {
                            MaVienChuc = row.maVienChuc,
                            Ho = row.ho,
                            Ten = row.ten,
                            GioiTinh = CheckGioiTinh(row.gioiTinh),
                            NgaySinh = row.ngaySinh,
                            ChucVu = row.tenChucVu,
                            DonVi = row.tenDonVi,
                            TrinhDo = GetTrinhDoByBacHocHamHocVi(row.idVienChuc),
                            HeSo = row.heSoChucVu,
                        });
                        tempMaVienChuc = row.maVienChuc;
                        tempHeSoCV = row.heSoChucVu;
                    }
                }
                else
                {
                    list.Add(new GridViewMainData
                    {
                        MaVienChuc = row.maVienChuc,
                        Ho = row.ho,
                        Ten = row.ten,
                        GioiTinh = CheckGioiTinh(row.gioiTinh),
                        NgaySinh = row.ngaySinh,
                        ChucVu = row.tenChucVu,
                        DonVi = row.tenDonVi,
                        TrinhDo = GetTrinhDoByBacHocHamHocVi(row.idVienChuc),
                        HeSo = row.heSoChucVu,
                    });
                    tempMaVienChuc = row.maVienChuc;
                    tempHeSoCV = row.heSoChucVu;
                }              
            }
            foreach (var row in temp_rows1)
            {
                if (row.maVienChuc.Equals(tempMaVienChuc) == true)
                {
                    if (tempHeSoCV < row.heSoChucVu)
                    {
                        list.Add(new GridViewMainData
                        {
                            MaVienChuc = row.maVienChuc,
                            Ho = row.ho,
                            Ten = row.ten,
                            GioiTinh = CheckGioiTinh(row.gioiTinh),
                            NgaySinh = row.ngaySinh,
                            ChucVu = row.tenChucVu,
                            DonVi = row.tenDonVi,
                            TrinhDo = GetTrinhDoByBacHocHamHocVi(row.idVienChuc),
                            HeSo = row.heSoChucVu,
                        });
                        tempMaVienChuc = row.maVienChuc;
                        tempHeSoCV = row.heSoChucVu;
                    }
                }
                else
                {
                    list.Add(new GridViewMainData
                    {
                        MaVienChuc = row.maVienChuc,
                        Ho = row.ho,
                        Ten = row.ten,
                        GioiTinh = CheckGioiTinh(row.gioiTinh),
                        NgaySinh = row.ngaySinh,
                        ChucVu = row.tenChucVu,
                        DonVi = row.tenDonVi,
                        TrinhDo = GetTrinhDoByBacHocHamHocVi(row.idVienChuc),
                        HeSo = row.heSoChucVu,
                    });
                    tempMaVienChuc = row.maVienChuc;
                    tempHeSoCV = row.heSoChucVu;
                }
            }
            var rows2 = list.OrderBy(x => x.MaVienChuc);
            List<GridViewMainData> list1 = new List<GridViewMainData>();
            string tempMaVienChuc1 = "";
            double? tempHeSoCV1 = -1;
            foreach(var row in rows2)
            {
                if (row.MaVienChuc.Equals(tempMaVienChuc1) == true)
                {
                    if (tempHeSoCV1 < row.HeSo)
                    {
                        list1.RemoveAt(list1.Count - 1);
                        list1.Add(new GridViewMainData
                        {
                            MaVienChuc = row.MaVienChuc,
                            Ho = row.Ho,
                            Ten = row.Ten,
                            GioiTinh = row.GioiTinh,
                            NgaySinh = row.NgaySinh,
                            ChucVu = row.ChucVu,
                            DonVi = row.DonVi,
                            TrinhDo = row.TrinhDo,
                            HeSo = row.HeSo,
                        });
                        tempMaVienChuc1 = row.MaVienChuc;
                        tempHeSoCV1 = row.HeSo;
                    }
                }
                else
                {
                    list1.Add(new GridViewMainData
                    {
                        MaVienChuc = row.MaVienChuc,
                        Ho = row.Ho,
                        Ten = row.Ten,
                        GioiTinh = row.GioiTinh,
                        NgaySinh = row.NgaySinh,
                        ChucVu = row.ChucVu,
                        DonVi = row.DonVi,
                        TrinhDo = row.TrinhDo,
                        HeSo = row.HeSo,
                    });
                    tempMaVienChuc1 = row.MaVienChuc;
                    tempHeSoCV1 = row.HeSo;
                }               
            }
            return list1;
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
