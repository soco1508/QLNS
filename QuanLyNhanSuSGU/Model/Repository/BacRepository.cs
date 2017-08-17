using Model.Entities;

namespace Model.Repository
{
    public class BacRepository : Repository<Bac>
    {
        public BacRepository(QuanLyNhanSuSGUEntities db) : base(db)
        {
        }
    }
}
