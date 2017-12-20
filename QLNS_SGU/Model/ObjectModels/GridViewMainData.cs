using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ObjectModels
{
    public class GridViewMainData
    {
        public string MaVienChuc { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public string GioiTinh { get; set; }
        public string ChucVu { get; set; }
        public string DonVi { get; set; }
        public string TrinhDo { get; set; }

        public GridViewMainData()
        {
            MaVienChuc = "";
            NgaySinh = Convert.ToDateTime("01/01/1900");
            Ho = "";
            Ten = "";
            GioiTinh = "";
            ChucVu = "";
            DonVi = "";
            TrinhDo = "";
        }
    }
}
