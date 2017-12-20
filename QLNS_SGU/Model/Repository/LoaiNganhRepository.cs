﻿using Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public class LoaiNganhRepository : Repository<LoaiNganh>
    {
        public LoaiNganhRepository(QLNSSGU_1Entities db) : base(db)
        {
        }

        public int GetIdLoaiNganhByNganhDaoTao(string nganhdaotao)
        {
            return _db.NganhDaoTaos.Where(x => x.tenNganhDaoTao == nganhdaotao).Select(y => y.idLoaiNganh).FirstOrDefault();
        }

        public List<LoaiNganh> GetListLoaiNganh()
        {
            //var list = _db.LoaiNganhs.Select(x => new { x.idLoaiNganh, x.tenLoaiNganh});
            //return list.AsEnumerable().Select(y => new LoaiNganh { idLoaiNganh = y.idLoaiNganh, tenLoaiNganh = y.tenLoaiNganh}).ToList();
            return _db.LoaiNganhs.ToList();
        }

        public void Update(int id, string loainganh)
        {
            LoaiNganh loaiNganh = _db.LoaiNganhs.Where(x => x.idLoaiNganh == id).First();
            loaiNganh.tenLoaiNganh = loainganh;
            _db.SaveChanges();
        }

        public void Create(string loainganh)
        {
            _db.LoaiNganhs.Add(new LoaiNganh { tenLoaiNganh = loainganh });
            _db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            LoaiNganh loaiNganh = _db.LoaiNganhs.Where(x => x.idLoaiNganh == id).First();
            _db.LoaiNganhs.Remove(loaiNganh);
        }

        public bool CheckExistById(int idRowFocused)
        {
            if(_db.LoaiNganhs.Any(x => x.idLoaiNganh == idRowFocused))
            {
                return true;
            }
            return false;
        }

        public int GetIdLoaiNganh(string loainganh)
        {
            return _db.LoaiNganhs.Where(x => x.tenLoaiNganh == loainganh).Select(y => y.idLoaiNganh).FirstOrDefault();
        }
    }
}