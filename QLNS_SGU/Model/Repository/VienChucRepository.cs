using Model.Entities;
using Model.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public class VienChucRepository : Repository<VienChuc>
    {
        public VienChucRepository(QLNSSGU_1Entities db) : base(db)
        {
        }

        public List<VienChucForGrid> GetListVienChucForGrid()
        {
            var listVienChuc = _db.VienChucs.ToList();
            var listVienChucForGrid = new List<VienChucForGrid>();
            for(int i = 0; i < listVienChuc.Count; i++)
            {
                listVienChucForGrid.Add(new VienChucForGrid
                {
                    idVienChuc = listVienChuc[i].idVienChuc,
                    maVienChuc = listVienChuc[i].maVienChuc,
                    ho = listVienChuc[i].ho,
                    ten = listVienChuc[i].ten,
                    sDT = listVienChuc[i].sDT,
                    gioiTinh = ReturnGenderToGrid(listVienChuc[i].gioiTinh),
                    anh = listVienChuc[i].anh,
                    chinhTri = listVienChuc[i].ChinhTri.tenChinhTri,
                    danToc = listVienChuc[i].DanToc.tenDanToc,
                    ghiChu = listVienChuc[i].ghiChu,
                    hoKhauThuongTru = listVienChuc[i].hoKhauThuongTru,
                    laDangVien = listVienChuc[i].laDangVien,
                    ngaySinh = listVienChuc[i].ngaySinh,
                    ngayThamGiaCongTac = listVienChuc[i].ngayThamGiaCongTac,
                    ngayVaoDang = listVienChuc[i].ngayVaoDang,
                    ngayVaoNganh = listVienChuc[i].ngayVaoNganh,
                    ngayVeTruong = listVienChuc[i].ngayVeTruong,
                    noiOHienNay = listVienChuc[i].noiOHienNay,
                    noiSinh = listVienChuc[i].noiSinh,
                    quanLyNhaNuoc = listVienChuc[i].QuanLyNhaNuoc.tenQuanLyNhaNuoc,
                    queQuan = listVienChuc[i].queQuan,
                    tonGiao = listVienChuc[i].TonGiao.tenTonGiao,
                    vanHoa = listVienChuc[i].vanHoa
                });
            }
            return listVienChucForGrid;
        }

        public bool ReturnGenderToDatabase(string s)
        {
            if (s == "Nam")
            {
                return true;
            }
            return false;
        }

        public string ReturnGenderToGrid(bool? gioitinh)
        {
            if(gioitinh == true)
            {
                return "Nam";
            }
            return "Nữ";
        }

        public DateTime? CheckDateTime(DateTime? datetime)
        {
            if(datetime != null)
            {
                return datetime;
            }
            return null;
        }

        private string SplitString(string s)
        {
            string[] words = s.Split('.');
            return words[1] + "/" + words[0] + "/" + words[2];
        }

        public List<VienChuc> GetListVienChuc()
        {
            return _db.VienChucs.ToList();
        }

        public DateTime? ParseDatetimeMatchDatetimeDatabase(string s)
        {
            if(s != string.Empty)
            {
                if (s.Contains(","))
                {
                    string[] words = s.Split(',');
                    string temp = "01/01/" + words[0];
                    return Convert.ToDateTime(temp);
                }
                else if (s.Contains(".") == true && s.Contains("x") == false && s.Contains(",") == false)
                {
                    string temp = SplitString(s);
                    return Convert.ToDateTime(temp);
                }
                else if (s.Contains(".") == false && s.Contains("x") == false && s.Contains(",") == false)
                {
                    string temp = "01/01/" + s;
                    return Convert.ToDateTime(temp);
                }
                else if (s.Contains("x") && s.Contains(",") == false)
                {
                    return null;
                }
            }            
            return null;
        }

        public void DeleteById(int idvienchuc)
        {
            var a = _db.VienChucs.Where(x => x.idVienChuc == idvienchuc).FirstOrDefault();
            _db.VienChucs.Remove(a);
        }

        public bool ReturnBoolDangVien(string s)
        {
            if (s != string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetIdVienChuc(string mavienchuc)
        {
            return _db.VienChucs.Where(x => x.maVienChuc == mavienchuc).Select(y => y.idVienChuc).FirstOrDefault();
        }

        public List<string> GetListMaVienChuc()
        {
            var list = from a in _db.VienChucs
                       select a.maVienChuc;
            return list.ToList();
        }

        public VienChuc GetVienChucByMaVienChuc(string mavienchuc)
        {
            return _db.VienChucs.Where(x => x.maVienChuc == mavienchuc).FirstOrDefault();
        }
    }
}
