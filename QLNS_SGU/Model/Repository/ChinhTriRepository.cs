using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public class ChinhTriRepository : Repository<ChinhTri>
    {
        public ChinhTriRepository(QLNSSGU_1Entities db) : base(db)
        {
        }

        public int GetIdByName(string chinhtri)
        {
            if (chinhtri != string.Empty)
            {
                return 2;
            }
            return 1;
        }

        public List<ChinhTri> GetListChinhTri()
        {
            return _db.ChinhTris.ToList();
        }

        public object SelectIdEmptyValue()
        {
            return _db.ChinhTris.Where(x => x.tenChinhTri == "").Select(y => y.idChinhTri).FirstOrDefault();
        }
    }
}
