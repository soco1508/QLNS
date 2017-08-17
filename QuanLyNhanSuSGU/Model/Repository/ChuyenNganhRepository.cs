using Model.Entities;

namespace Model.Repository
{
    public class ChuyenNganhRepository : Repository<ChuyenNganh>
    {
        public ChuyenNganhRepository(QuanLyNhanSuSGUEntities db) : base(db)
        {
        }
    }
}
