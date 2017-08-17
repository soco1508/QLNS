using Model.Entities;

namespace Model.Repository
{
    public class ChucVuDonViVienChucRepository : Repository<ChucVuDonViVienChuc>
    {
        public ChucVuDonViVienChucRepository(QuanLyNhanSuSGUEntities db) : base(db)
        {
        }
    }
}
