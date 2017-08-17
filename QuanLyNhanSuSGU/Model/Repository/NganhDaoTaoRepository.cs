using Model.Entities;

namespace Model.Repository
{
    public class NganhDaoTaoRepository : Repository<NganhDaoTao>
    {
        public NganhDaoTaoRepository(QuanLyNhanSuSGUEntities db) : base(db)
        {
        }
    }
}
