using Model.Entities;

namespace Model.Repository
{
    public class LoaiHopDongRepository : Repository<LoaiHopDong>
    {
        public LoaiHopDongRepository(QuanLyNhanSuSGUEntities db) : base(db)
        {
        }
    }
}
