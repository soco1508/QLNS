using Model.Entities;

namespace Model.Repository
{
    public class TrangThaiVienChucRepository : Repository<TrangThaiVienChuc>
    {
        public TrangThaiVienChucRepository(QuanLyNhanSuSGUEntities db) : base(db)
        {
        }
    }
}
