using Model.Entities;

namespace Model.Repository
{
    public class BangCapVienChucRepository : Repository<BangCapVienChuc>
    {
        public BangCapVienChucRepository(QuanLyNhanSuSGUEntities db) : base(db)
        {
        }
    }
}
