using Model.Entities;

namespace Model.Repository
{
    public class TrangThaiRepository : Repository<TrangThai>
    {
        public TrangThaiRepository(QuanLyNhanSuSGUEntities db) : base(db)
        {
        }
    }
}
