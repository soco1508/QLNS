using Model.Entities;

namespace Model.Repository
{
    public class QuaTrinhLuongRepository : Repository<QuaTrinhLuong>
    {
        public QuaTrinhLuongRepository(QuanLyNhanSuSGUEntities db) : base(db)
        {
        }
    }
}
