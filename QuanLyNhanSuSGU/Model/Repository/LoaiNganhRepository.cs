using Model.Entities;

namespace Model.Repository
{
    public class LoaiNganhRepository : Repository<LoaiNganh>
    {
        public LoaiNganhRepository(QuanLyNhanSuSGUEntities db) : base(db)
        {
        }
    }
}
