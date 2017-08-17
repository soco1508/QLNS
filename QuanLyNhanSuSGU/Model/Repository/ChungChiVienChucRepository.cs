using Model.Entities;

namespace Model.Repository
{
    public class ChungChiVienChucRepository : Repository<ChungChiVienChuc>
    {
        public ChungChiVienChucRepository(QuanLyNhanSuSGUEntities db) : base(db)
        {
        }
    }
}
