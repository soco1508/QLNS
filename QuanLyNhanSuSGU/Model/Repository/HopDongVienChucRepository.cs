using Model.Entities;

namespace Model.Repository
{
    public class HopDongVienChucRepository : Repository<HopDongVienChuc>
    {
        public HopDongVienChucRepository(QuanLyNhanSuSGUEntities db) : base(db)
        {
        }
    }
}
