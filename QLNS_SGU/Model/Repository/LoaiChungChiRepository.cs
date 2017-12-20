using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public class LoaiChungChiRepository : Repository<LoaiChungChi>
    {
        public LoaiChungChiRepository(QLNSSGU_1Entities db) : base(db)
        {
        }

        public IList<LoaiChungChi> GetListLoaiChungChi()
        {
            return _db.LoaiChungChis.ToList();
        }

        public void Update(int id, string loaichungchi, string capdo)
        {
            LoaiChungChi _loaichungchi = _db.LoaiChungChis.Where(x => x.idLoaiChungChi == id).First();
            _loaichungchi.tenLoaiChungChi = loaichungchi;
            _loaichungchi.capDo = capdo;
            _db.SaveChanges();
        }

        public void Create(string loaichungchi, string capdo)
        {
            _db.LoaiChungChis.Add(new LoaiChungChi { tenLoaiChungChi = loaichungchi, capDo = capdo });
            _db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            LoaiChungChi loaichungchi = _db.LoaiChungChis.Where(x => x.idLoaiChungChi == id).First();
            _db.LoaiChungChis.Remove(loaichungchi);
        }

        public bool CheckExistById(int idRowFocused)
        {
            if (_db.LoaiChungChis.Any(x => x.idLoaiChungChi == idRowFocused))
            {
                return true;
            }
            return false;
        }

        public string GetFirstChar(string s)
        {
            if (s.Contains(","))
            {
                string[] words = s.Split(',');
                return words[0];
            }
            else
            {
                return s;
            }
        }

        public int GetIdLoaiChungChi(string loaichungchi, string capdo)
        {
            return _db.LoaiChungChis.Where(x => x.tenLoaiChungChi == loaichungchi && x.capDo == capdo).Select(y => y.idLoaiChungChi).FirstOrDefault();
        }
    }
}
