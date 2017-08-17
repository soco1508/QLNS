using Model.Entities;

namespace Model.Repository
{
    public class VienChucRepository : Repository<VienChuc>
    {
        public VienChucRepository(QuanLyNhanSuSGUEntities db) : base(db)
        {
        }
    }
}
