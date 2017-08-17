using Model.Entities;

namespace Model.Repository
{
    public class LoaiDonViRepository : Repository<LoaiDonVi>
    {
        public LoaiDonViRepository(QuanLyNhanSuSGUEntities db) : base(db)
        {
        }
    }
}
