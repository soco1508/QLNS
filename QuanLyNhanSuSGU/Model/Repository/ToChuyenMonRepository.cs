using Model.Entities;

namespace Model.Repository
{
    public class ToChuyenMonRepository : Repository<ToChuyenMon>
    {
        public ToChuyenMonRepository(QuanLyNhanSuSGUEntities db) : base(db)
        {
        }
    }
}
