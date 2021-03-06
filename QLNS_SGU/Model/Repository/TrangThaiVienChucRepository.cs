﻿using Model.Entities;
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
        
        public void InsertFirstRowDefault(string mavienchuc)
        {
            VienChucRepository vienChucRepository = new VienChucRepository(_db);
            int idvienchuc = vienChucRepository.GetIdVienChuc(mavienchuc);
            TrangThaiVienChuc trangThaiVienChuc = new TrangThaiVienChuc();
            trangThaiVienChuc.idVienChuc = idvienchuc;
            trangThaiVienChuc.TrangThai.tenTrangThai = "Đang làm";
            _db.TrangThaiVienChucs.Add(trangThaiVienChuc);
        }

        public bool CheckExistsAnyRow(string mavienchuc)
        {
            VienChucRepository vienChucRepository = new VienChucRepository(_db);
            int idvienchuc = vienChucRepository.GetIdVienChuc(mavienchuc);
            int idTrangThaiVienChuc = _db.TrangThaiVienChucs.Where(x => x.idVienChuc == idvienchuc).Select(y => y.idTrangThaiVienChuc).FirstOrDefault();
            if (idTrangThaiVienChuc > 0)
                return true;
            return false;
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

        public TrangThaiVienChuc GetTrangThaiHienTai(string mavienchuc)
        {
            VienChucRepository vienChucRepository = new VienChucRepository(_db);           
            int idvienchuc = vienChucRepository.GetIdVienChuc(mavienchuc);
            TrangThaiVienChuc trangThaiHienTai = _db.TrangThaiVienChucs.Where(x => x.idVienChuc == idvienchuc && !x.TrangThai.tenTrangThai.Contains("Đang làm")).OrderByDescending(y => y.idTrangThaiVienChuc).FirstOrDefault();
            return trangThaiHienTai;
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

        public TrangThaiVienChuc GetTrangThaiByIdVienChucAndDuration(int idVienChuc, DateTime dtFromDuration, DateTime dtToDuration)
        {
            var rows = _db.TrangThaiVienChucs.Where(x => x.idVienChuc == idVienChuc);
            List<TrangThaiVienChuc> listTrangThaiVienChuc = new List<TrangThaiVienChuc>();
            foreach (var row in rows)
            {
                if (row.ngayKetThuc != null)
                {
                    if (row.ngayBatDau >= dtFromDuration && row.ngayKetThuc <= dtToDuration)
                    {
                        listTrangThaiVienChuc.Add(row);
                    }
                }
                else
                {
                    if (row.ngayBatDau >= dtFromDuration)
                    {
                        listTrangThaiVienChuc.Add(row);
                    }
                }
            }
            if (listTrangThaiVienChuc.Count > 0)
                return listTrangThaiVienChuc.OrderByDescending(x => x.ngayBatDau).FirstOrDefault();
            return null;
        }

        public TrangThaiVienChuc GetTrangThaiByIdVienChucAndTimeline(int idVienChuc, DateTime dtTimeline)
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
            if(listTrangThaiVienChuc.Count > 0)
                return listTrangThaiVienChuc.OrderByDescending(x => x.ngayBatDau).FirstOrDefault();
            return null;
        }

        public List<TrangThaiVienChuc> GetListTrangThaiByIdVienChucAndDuration(int idVienChuc, DateTime dtFromDuration, DateTime dtToDuration)
        {
            var rows = _db.TrangThaiVienChucs.Where(x => x.idVienChuc == idVienChuc);
            List<TrangThaiVienChuc> listTrangThaiVienChuc = new List<TrangThaiVienChuc>();
            foreach (var row in rows)
            {
                if (row.ngayKetThuc != null)
                {
                    if (row.ngayBatDau >= dtFromDuration && row.ngayKetThuc <= dtToDuration)
                    {
                        listTrangThaiVienChuc.Add(row);
                    }
                }
                else
                {
                    if (row.ngayBatDau >= dtFromDuration)
                    {
                        listTrangThaiVienChuc.Add(row);
                    }
                }
            }
            return listTrangThaiVienChuc;
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

        public List<string> GetListLinkVanBanDinhKem(string maVienChucForGetListLinkVanBanDinhKem)
        {
            return _db.TrangThaiVienChucs.Where(x => x.VienChuc.maVienChuc == maVienChucForGetListLinkVanBanDinhKem).Select(y => y.linkVanBanDinhKem).ToList();
        }
    }
}
