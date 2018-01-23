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

        public List<ChungChiForView> GetListChungChiVienChuc(string mavienchuc)
        {
            int idvienchuc = _db.VienChucs.Where(x => x.maVienChuc == mavienchuc).Select(y => y.idVienChuc).FirstOrDefault();
            List<ChungChiVienChuc> listChungChiVienChuc = _db.ChungChiVienChucs.Where(x => x.idVienChuc == idvienchuc).ToList();
            List<ChungChiForView> listChungChiForView = new List<ChungChiForView>();
            for(int i = listChungChiVienChuc.Count - 1; i >= 0; i--)
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

        public ChungChiVienChuc GetObjectByIdVienChuc(int idVienChuc)
        {
            return _db.ChungChiVienChucs.Where(x => x.idVienChuc == idVienChuc).OrderByDescending(y => y.idChungChiVienChuc).FirstOrDefault();
        }

        public List<string> GetListLinkVanBanDinhKem(string maVienChucForGetListLinkVanBanDinhKemCC)
        {
            return _db.ChungChiVienChucs.Where(x => x.VienChuc.maVienChuc == maVienChucForGetListLinkVanBanDinhKemCC).Select(y => y.linkVanBanDinhKem).ToList();
        }
    }
}
