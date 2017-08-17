using Model.Entities;

namespace Model.Repository
{
    public class LoaiBangCapRepository : Repository<LoaiBangCap>
    {
        public LoaiBangCapRepository(QuanLyNhanSuSGUEntities db) : base(db)
        {
        }
    }
}
