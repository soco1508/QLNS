using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public class LoaiHocHamHocViRepository : Repository<LoaiHocHamHocVi>
    {
        public LoaiHocHamHocViRepository(QLNSSGU_1Entities db) : base(db)
        {
        }

        public int GetIdLoaiHocHamHocVi(string loaihochamhocvi)
        {
            switch (loaihochamhocvi)
            {
                case "PT":
                    return _db.LoaiHocHamHocVis.Where(x => x.tenLoaiHocHamHocVi == "Phổ thông").Select(y => y.idLoaiHocHamHocVi).FirstOrDefault();                    
                case "TC":
                    return _db.LoaiHocHamHocVis.Where(x => x.tenLoaiHocHamHocVi == "Trung cấp").Select(y => y.idLoaiHocHamHocVi).FirstOrDefault();
                case "CĐ":
                    return _db.LoaiHocHamHocVis.Where(x => x.tenLoaiHocHamHocVi == "Cao đẳng").Select(y => y.idLoaiHocHamHocVi).FirstOrDefault();
                case "ĐH":
                    return _db.LoaiHocHamHocVis.Where(x => x.tenLoaiHocHamHocVi == "Đại học").Select(y => y.idLoaiHocHamHocVi).FirstOrDefault();
                case "ThS":
                    return _db.LoaiHocHamHocVis.Where(x => x.tenLoaiHocHamHocVi == "Thạc sĩ").Select(y => y.idLoaiHocHamHocVi).FirstOrDefault();
                case "TS":
                    return _db.LoaiHocHamHocVis.Where(x => x.tenLoaiHocHamHocVi == "Tiến sĩ").Select(y => y.idLoaiHocHamHocVi).FirstOrDefault();
                case "PGS":
                    return _db.LoaiHocHamHocVis.Where(x => x.tenLoaiHocHamHocVi == "Phó giáo sư").Select(y => y.idLoaiHocHamHocVi).FirstOrDefault();
                case "GS":
                    return _db.LoaiHocHamHocVis.Where(x => x.tenLoaiHocHamHocVi == "Giáo sư").Select(y => y.idLoaiHocHamHocVi).FirstOrDefault();
                default:
                    return _db.LoaiHocHamHocVis.Where(x => x.tenLoaiHocHamHocVi == "Khác").Select(y => y.idLoaiHocHamHocVi).FirstOrDefault(); ;
            }
        }

        public IList<LoaiHocHamHocVi> GetListLoaiHocHamHocVi()
        {
            return _db.LoaiHocHamHocVis.ToList();
        }

        public void Update(int id, string loaihochamhocvi)
        {
            LoaiHocHamHocVi _loaihochamhocvi = _db.LoaiHocHamHocVis.Where(x => x.idLoaiHocHamHocVi == id).First();
            _loaihochamhocvi.tenLoaiHocHamHocVi = loaihochamhocvi;
            _db.SaveChanges();
        }

        public void Create(string loaihochamhocvi)
        {
            _db.LoaiHocHamHocVis.Add(new LoaiHocHamHocVi { tenLoaiHocHamHocVi = loaihochamhocvi });
            _db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            LoaiHocHamHocVi _loaihochamhocvi = _db.LoaiHocHamHocVis.Where(x => x.idLoaiHocHamHocVi == id).First();
            _db.LoaiHocHamHocVis.Remove(_loaihochamhocvi);
        }

        public bool CheckExistById(int idRowFocused)
        {
            if (_db.LoaiHocHamHocVis.Any(x => x.idLoaiHocHamHocVi == idRowFocused))
            {
                return true;
            }
            return false;
        }

        public int GetIdLoaiHocHamHocViForDangHocNangCao(string s)
        {
            switch (s)
            {
                case "cao học":
                    return _db.LoaiHocHamHocVis.Where(x => x.tenLoaiHocHamHocVi == "Thạc sĩ").Select(y => y.idLoaiHocHamHocVi).FirstOrDefault();
                case "nghiên cứu sinh":
                    return _db.LoaiHocHamHocVis.Where(x => x.tenLoaiHocHamHocVi == "Tiến sĩ").Select(y => y.idLoaiHocHamHocVi).FirstOrDefault();
                default:
                    return -1;
            }
        }
    }
}
