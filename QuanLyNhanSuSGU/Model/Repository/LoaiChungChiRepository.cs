using Model.Entities;

namespace Model.Repository
{
    public class LoaiChungChiRepository : Repository<LoaiChungChi>
    {
        public LoaiChungChiRepository(QuanLyNhanSuSGUEntities db) : base(db)
        {
        }
    }
}
