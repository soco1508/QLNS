using Model.Entities;

namespace Model.Repository
{
    public class ChucVuRepository : Repository<ChucVu>
    {
        public ChucVuRepository(QuanLyNhanSuSGUEntities db) : base(db)
        {
        }
    }
}
