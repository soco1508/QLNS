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
        public List<GridViewMainData> LoadDataToMainGrid()
        {
            List<GridViewMainData> listGridViewMainData = new List<GridViewMainData>();           
            List<VienChuc> listIdVienChuc = _db.VienChucs.ToList();
            foreach(var item in listIdVienChuc)
            {
                List<ChucVuDonViVienChuc> listChucVuDonViVienChucToAdd = new List<ChucVuDonViVienChuc>();
                List<ChucVuDonViVienChuc> listChucVuDonViVienChuc = _db.ChucVuDonViVienChucs.Where(x => x.idVienChuc == item.idVienChuc).ToList();
                if (listChucVuDonViVienChuc.Count == 0)
                {
                    listGridViewMainData.Add(new GridViewMainData
                    {
                        MaVienChuc = item.maVienChuc,
                        Ho = item.ho,
                        Ten = item.ten,
                        GioiTinh = CheckGioiTinh(item.gioiTinh),
                        NgaySinh = item.ngaySinh,
                        ChucVu = string.Empty,
                        DonVi = string.Empty,
                        TrinhDo = GetMaxLoaiHocHamHocVi(item.idVienChuc),
                        HeSo = 0
                    });
                }
                if (listChucVuDonViVienChuc.Count == 1)
                {
                    listGridViewMainData.Add(new GridViewMainData
                    {
                        MaVienChuc = item.maVienChuc,
                        Ho = item.ho,
                        Ten = item.ten,
                        GioiTinh = CheckGioiTinh(item.gioiTinh),
                        NgaySinh = item.ngaySinh,
                        ChucVu = listChucVuDonViVienChuc[0].ChucVu.tenChucVu,
                        DonVi = listChucVuDonViVienChuc[0].DonVi.tenDonVi,
                        TrinhDo = GetMaxLoaiHocHamHocVi(item.idVienChuc),
                        HeSo = listChucVuDonViVienChuc[0].ChucVu.heSoChucVu
                    });
                }
                if (listChucVuDonViVienChuc.Count > 1)
                {
                    for (int i = 0; i < listChucVuDonViVienChuc.Count; i++)
                    {
                        if(listChucVuDonViVienChuc[i].ngayKetThuc != null)
                        {
                            if(listChucVuDonViVienChuc[i].ngayBatDau <= DateTime.Now && listChucVuDonViVienChuc[i].ngayKetThuc >= DateTime.Now)
                            {
                                listChucVuDonViVienChucToAdd.Add(listChucVuDonViVienChuc[i]);
                            }
                        }
                        else
                        {
                            if (listChucVuDonViVienChuc[i].ngayBatDau <= DateTime.Now)
                            {
                                listChucVuDonViVienChucToAdd.Add(listChucVuDonViVienChuc[i]);
                            }
                        }
                    }
                    if (listChucVuDonViVienChucToAdd.Count > 0)
                    {
                        var chucVuDonViVienChuc = listChucVuDonViVienChucToAdd.OrderByDescending(x => x.ChucVu.heSoChucVu).FirstOrDefault();
                        listGridViewMainData.Add(new GridViewMainData
                        {
                            MaVienChuc = item.maVienChuc,
                            Ho = item.ho,
                            Ten = item.ten,
                            GioiTinh = CheckGioiTinh(item.gioiTinh),
                            NgaySinh = item.ngaySinh,
                            ChucVu = chucVuDonViVienChuc.ChucVu.tenChucVu,
                            DonVi = chucVuDonViVienChuc.DonVi.tenDonVi,
                            TrinhDo = GetMaxLoaiHocHamHocVi(item.idVienChuc),
                            HeSo = chucVuDonViVienChuc.ChucVu.heSoChucVu
                        });
                    }
                    else
                    {
                        var chucVuDonViVienChuc = listChucVuDonViVienChuc.OrderByDescending(x => x.ChucVu.heSoChucVu).FirstOrDefault();
                        listGridViewMainData.Add(new GridViewMainData
                        {
                            MaVienChuc = item.maVienChuc,
                            Ho = item.ho,
                            Ten = item.ten,
                            GioiTinh = CheckGioiTinh(item.gioiTinh),
                            NgaySinh = item.ngaySinh,
                            ChucVu = chucVuDonViVienChuc.ChucVu.tenChucVu,
                            DonVi = chucVuDonViVienChuc.DonVi.tenDonVi,
                            TrinhDo = GetMaxLoaiHocHamHocVi(item.idVienChuc),
                            HeSo = chucVuDonViVienChuc.ChucVu.heSoChucVu
                        });
                    }
                }
            }
            return listGridViewMainData;
        }

        private string CheckGioiTinh(bool? t)
        {
            if (t == true)
            {
                return "Nam";
            }
            return "Nữ";
        }

        private string GetMaxLoaiHocHamHocVi(int idvienchuc)
        {
            var listHocHamHocVi = _db.HocHamHocViVienChucs.Where(x => x.idVienChuc == idvienchuc).ToList();
            if (listHocHamHocVi.Count > 0)
                return listHocHamHocVi.OrderByDescending(x => x.bacHocHamHocVi).Select(y => y.LoaiHocHamHocVi.tenLoaiHocHamHocVi).FirstOrDefault();
            return string.Empty;
        }
    }
}
