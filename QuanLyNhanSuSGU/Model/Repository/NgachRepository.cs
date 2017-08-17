using Model.Entities;

namespace Model.Repository
{
    public class NgachRepository : Repository<Ngach>
    {
        public NgachRepository(QuanLyNhanSuSGUEntities db) : base(db)
        {
        }
    }
}
