using Model.Entities;

namespace Model.Repository
{
    public class NganhVienChucRepository : Repository<NganhVienChuc>
    {
        public NganhVienChucRepository(QuanLyNhanSuSGUEntities db) : base(db)
        {
        }
    }
}
