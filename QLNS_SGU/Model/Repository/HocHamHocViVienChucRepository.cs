using Model.Entities;
using Model.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public class HocHamHocViVienChucRepository : Repository<HocHamHocViVienChuc>
    {
        public HocHamHocViVienChucRepository(QLNSSGU_1Entities db) : base(db)
        {
        }

        public List<HocHamHocViForView> GetListHocHamHocVi(string mavienchuc)
        {
            int idvienchuc = _db.VienChucs.Where(x => x.maVienChuc == mavienchuc).Select(y => y.idVienChuc).FirstOrDefault();
            List<HocHamHocViVienChuc> listHocHamHocViVienChuc = _db.HocHamHocViVienChucs.Where(x => x.idVienChuc == idvienchuc).ToList();
            List<HocHamHocViForView> listHocHamHocViForView = new List<HocHamHocViForView>();
            for (int i = 0; i < listHocHamHocViVienChuc.Count; i++)
            {
                listHocHamHocViForView.Add(new HocHamHocViForView
                {
                    Id = listHocHamHocViVienChuc[i].idHocHamHocViVienChuc,
                    LoaiHocHamHocVi = listHocHamHocViVienChuc[i].LoaiHocHamHocVi.tenLoaiHocHamHocVi,
                    NganhDaoTao = listHocHamHocViVienChuc[i].NganhDaoTao.tenNganhDaoTao,
                    ChuyenNganh = listHocHamHocViVienChuc[i].ChuyenNganh.tenChuyenNganh,
                    TenHocHamHocVi = listHocHamHocViVienChuc[i].tenHocHamHocVi,
                    CoSoDaoTao = listHocHamHocViVienChuc[i].coSoDaoTao,
                    NgonNguDaoTao = listHocHamHocViVienChuc[i].ngonNguDaoTao,
                    HinhThucDaoTao = listHocHamHocViVienChuc[i].hinhThucDaoTao,
                    NuocCapBang = listHocHamHocViVienChuc[i].nuocCapBang,
                    NgayCapBang = listHocHamHocViVienChuc[i].ngayCapBang,
                    LinkVanBanDinhKem = listHocHamHocViVienChuc[i].linkVanBanDinhKem
                });
            }
            return listHocHamHocViForView;
        }

        public int GetIdHocHamHocViVienChuc(int idvienchuc, int idloaihochamhocvi, int idloainganh, int idnganhdaotao, int idchuyennganh)
        {
            return _db.HocHamHocViVienChucs
                   .Where(x => x.idVienChuc == idvienchuc && x.idLoaiHocHamHocVi == idloaihochamhocvi && x.idLoaiNganh == idloainganh && x.idNganhDaoTao == idnganhdaotao && x.idChuyenNganh == idchuyennganh)
                   .Select(y => y.idHocHamHocViVienChuc).First();
        }

        public int? AssignBacHocHamHocVi(string trinhdo)
        {
            switch (trinhdo)
            {
                case "PT":
                    return 1;
                case "TC":
                    return 2;
                case "CĐ":
                    return 3;
                case "ĐH":
                    return 4;
                case "ThS":
                    return 5;
                case "TS":
                    return 6;
                case "PGS":
                    return 7;
                case "GS":
                    return 8;
                default:
                    return 0;
            }
        }

        public string ConcatString(string trinhdo, string nganhdaotao, string chuyennganh)
        {
            return trinhdo + " " + nganhdaotao + " - " + chuyennganh;
        }

        public int? HardCodeBacToDatabase(string loaihochamhocvi)
        {
            switch (loaihochamhocvi)
            {
                case "Phổ thông":
                    return 1;
                case "Trung cấp":
                    return 2;
                case "Cao đẳng":
                    return 3;
                case "Đại học":
                    return 4;
                case "Thạc sĩ":
                    return 5;
                case "Tiến sĩ":
                    return 6;
                case "Phó giáo sư":
                    return 7;
                case "Giáo sư":
                    return 8;
                case "Khác":
                    return 9;
                default:
                    return 9;
            }
        }

        public HocHamHocViVienChuc GetObjectById(int idhochamhocvi)
        {
            return _db.HocHamHocViVienChucs.Where(x => x.idHocHamHocViVienChuc == idhochamhocvi).FirstOrDefault();                
        }

        public void DeleteById(int id)
        {
            var a = _db.HocHamHocViVienChucs.Where(x => x.idHocHamHocViVienChuc == id).FirstOrDefault();
            _db.HocHamHocViVienChucs.Remove(a);
        }

        public List<HocHamHocViVienChuc> GetListTenHocHamHocViVienChuc(string mavienchuc)
        {
            int idvienchuc = _db.VienChucs.Where(x => x.maVienChuc == mavienchuc).Select(y => y.idVienChuc).FirstOrDefault();
            return _db.HocHamHocViVienChucs.Where(x => x.idVienChuc == idvienchuc).ToList();
        }
    }
}
