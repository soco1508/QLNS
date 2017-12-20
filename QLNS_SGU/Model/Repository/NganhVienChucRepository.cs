﻿using Model.Entities;
using Model.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public class NganhVienChucRepository : Repository<NganhVienChuc>
    {
        public NganhVienChucRepository(QLNSSGU_1Entities db) : base(db)
        {
        }

        public void DeleteById(int id)
        {
            _db.NganhVienChucs.Remove(_db.NganhVienChucs.Where(x => x.idNganhVienChuc == id).FirstOrDefault());
        }

        public List<NganhForView> GetListNganh(string mavienchuc)
        {
            int idvienchuc = _db.VienChucs.Where(x => x.maVienChuc == mavienchuc).Select(y => y.idVienChuc).FirstOrDefault();
            List<NganhVienChuc> listNganhVienChuc = _db.NganhVienChucs.Where(x => x.idVienChuc == idvienchuc).ToList();
            List<NganhForView> listNganhForView = new List<NganhForView>();
            for(int i = 0; i < listNganhVienChuc.Count; i++)
            {
                listNganhForView.Add(new NganhForView
                {
                    Id = listNganhVienChuc[i].idNganhVienChuc,
                    IdHocHamHocViVienChuc = listNganhVienChuc[i].idHocHamHocViVienChuc,
                    NganhDaoTao = listNganhVienChuc[i].NganhDaoTao.tenNganhDaoTao,
                    ChuyenNganh = listNganhVienChuc[i].ChuyenNganh.tenChuyenNganh,
                    TenHocHamHocVi = listNganhVienChuc[i].HocHamHocViVienChuc.tenHocHamHocVi,
                    PhanLoai = HardCodePhanLoaiToGrid(listNganhVienChuc[i].phanLoai),
                    NgayBatDau = listNganhVienChuc[i].ngayBatDau,
                    NgayKetThuc = listNganhVienChuc[i].ngayKetThuc,
                    LinkVanBanDinhKem = listNganhVienChuc[i].linkVanBanDinhKem
                });
            }
            return listNganhForView;
        }

        private string HardCodePhanLoaiToGrid(int? phanLoai)
        {
            switch (phanLoai)
            {
                case 0:
                    return "Vừa học vừa dạy";
                case 1:
                    return "Chỉ học";
                case 2:
                    return "Chỉ dạy";
                default:
                    return "";
            }
        }

        public int? HardCodePhanLoaiToDatabase(string phanloai)
        {
            switch (phanloai)
            {
                case "Vừa học vừa dạy":
                    return 0;
                case "Chỉ học":
                    return 1;
                case "Chỉ dạy":
                    return 2;
                default:
                    return null;
            }
        }

        public NganhVienChuc GetObjectById(int idnganhvienchuc)
        {
            return _db.NganhVienChucs.Where(x => x.idNganhVienChuc == idnganhvienchuc).FirstOrDefault();
        }
    }
}