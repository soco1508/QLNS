using Model.Entities;

namespace Model.Repository
{
    public class DonViRepository : Repository<DonVi>
    {
        public DonViRepository(QuanLyNhanSuSGUEntities db) : base(db)
        {
        }
    }
}
