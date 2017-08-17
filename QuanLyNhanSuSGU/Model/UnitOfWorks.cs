using Model.Entities;
using Model.Repository;

namespace Model
{
    public class UnitOfWorks
    {
        private BacRepository _bacRepository;
        private BangCapVienChucRepository _bangCapVienChucRepository;
        private ChucVuDonViVienChucRepository _chucVuDonViVienChucRepository;
        private ChucVuRepository _chucVuRepository;
        private ChungChiVienChucRepository _chungChiVienChucRepository;
        private ChuyenNganhRepository _chuyenNganhRepository;
        private DonViRepository _donViRepository;
        private HopDongVienChucRepository _hopDongVienChucRepository;
        private LoaiBangCapRepository _loaiBangCapRepository;
        private LoaiChungChiRepository _loaiChungChiRepository;
        private LoaiDonViRepository _loaiDonViRepository;
        private LoaiHopDongRepository _loaiHopDongRepository;
        private LoaiNganhRepository _loaiNganhRepository;
        private NgachRepository _ngachRepository;
        private NganhDaoTaoRepository _nganhDaoTaoRepository;
        private NganhVienChucRepository _nganhVienChucRepository;
        private QuaTrinhLuongRepository _quaTrinhLuongRepository;
        private ToChuyenMonRepository _toChuyenMonRepository;
        private TrangThaiRepository _trangThaiRepository;
        private TrangThaiVienChucRepository _trangThaiVienChucRepository;
        private VienChucRepository _vienChucRepository;

        private QuanLyNhanSuSGUEntities _db;

        public UnitOfWorks(QuanLyNhanSuSGUEntities db)
        {
            _db = db;
        }

        public BacRepository BacRepository
        {
            get
            {
                if (_bacRepository == null)
                {
                    _bacRepository = new BacRepository(_db);
                }
                return _bacRepository;
            }
        }

        public BangCapVienChucRepository BangCapVienChucRepository
        {
            get
            {
                if (_bangCapVienChucRepository == null)
                {
                    _bangCapVienChucRepository = new BangCapVienChucRepository(_db);
                }
                return _bangCapVienChucRepository;
            }
        }

        public ChucVuDonViVienChucRepository ChucVuDonViVienChucRepository
        {
            get
            {
                if (_chucVuDonViVienChucRepository == null)
                {
                    _chucVuDonViVienChucRepository = new ChucVuDonViVienChucRepository(_db);
                }
                return _chucVuDonViVienChucRepository;
            }
        }

        public ChucVuRepository ChucVuRepository
        {
            get
            {
                if (_chucVuRepository == null)
                {
                    _chucVuRepository = new ChucVuRepository(_db);
                }
                return _chucVuRepository;
            }
        }

        public ChungChiVienChucRepository ChungChiVienChucRepository
        {
            get
            {
                if (_chungChiVienChucRepository == null)
                {
                    _chungChiVienChucRepository = new ChungChiVienChucRepository(_db);
                }
                return _chungChiVienChucRepository;
            }
        }

        public ChuyenNganhRepository ChuyenNganhRepository
        {
            get
            {
                if (_chuyenNganhRepository == null)
                {
                    _chuyenNganhRepository = new ChuyenNganhRepository(_db);
                }
                return _chuyenNganhRepository;
            }
        }

        public DonViRepository DonViRepository
        {
            get
            {
                if (_donViRepository == null)
                {
                    _donViRepository = new DonViRepository(_db);
                }
                return _donViRepository;
            }
        }

        public HopDongVienChucRepository HopDongVienChucRepository
        {
            get
            {
                if (_hopDongVienChucRepository == null)
                {
                    _hopDongVienChucRepository = new HopDongVienChucRepository(_db);
                }
                return _hopDongVienChucRepository;
            }
        }

        public LoaiBangCapRepository LoaiBangCapRepository
        {
            get
            {
                if (_loaiBangCapRepository == null)
                {
                    _loaiBangCapRepository = new LoaiBangCapRepository(_db);
                }
                return _loaiBangCapRepository;
            }
        }

        public LoaiChungChiRepository LoaiChungChiRepository
        {
            get
            {
                if (_loaiChungChiRepository == null)
                {
                    _loaiChungChiRepository = new LoaiChungChiRepository(_db);
                }
                return _loaiChungChiRepository;
            }
        }

        public LoaiDonViRepository LoaiDonViRepository
        {
            get
            {
                if (_loaiDonViRepository == null)
                {
                    _loaiDonViRepository = new LoaiDonViRepository(_db);
                }
                return _loaiDonViRepository;
            }
        }

        public LoaiHopDongRepository LoaiHopDongRepository
        {
            get
            {
                if (_loaiHopDongRepository == null)
                {
                    _loaiHopDongRepository = new LoaiHopDongRepository(_db);
                }
                return _loaiHopDongRepository;
            }
        }

        public LoaiNganhRepository LoaiNganhRepository
        {
            get
            {
                if (_loaiNganhRepository == null)
                {
                    _loaiNganhRepository = new LoaiNganhRepository(_db);
                }
                return _loaiNganhRepository;
            }
        }

        public NgachRepository NgachRepository
        {
            get
            {
                if (_ngachRepository == null)
                {
                    _ngachRepository = new NgachRepository(_db);
                }
                return _ngachRepository;
            }
        }

        public NganhDaoTaoRepository NganhDaoTaoRepository
        {
            get
            {
                if (_nganhDaoTaoRepository == null)
                {
                    _nganhDaoTaoRepository = new NganhDaoTaoRepository(_db);
                }
                return _nganhDaoTaoRepository;
            }
        }

        public NganhVienChucRepository NganhVienChucRepository
        {
            get
            {
                if (_nganhVienChucRepository == null)
                {
                    _nganhVienChucRepository = new NganhVienChucRepository(_db);
                }
                return _nganhVienChucRepository;
            }
        }

        public QuaTrinhLuongRepository QuaTrinhLuongRepository
        {
            get
            {
                if (_quaTrinhLuongRepository == null)
                {
                    _quaTrinhLuongRepository = new QuaTrinhLuongRepository(_db);
                }
                return _quaTrinhLuongRepository;
            }
        }

        public ToChuyenMonRepository ToChuyenMonRepository
        {
            get
            {
                if (_toChuyenMonRepository == null)
                {
                    _toChuyenMonRepository = new ToChuyenMonRepository(_db);
                }
                return _toChuyenMonRepository;
            }
        }

        public TrangThaiRepository TrangThaiRepository
        {
            get
            {
                if (_trangThaiRepository == null)
                {
                    _trangThaiRepository = new TrangThaiRepository(_db);
                }
                return _trangThaiRepository;
            }
        }

        public TrangThaiVienChucRepository TrangThaiVienChucRepository
        {
            get
            {
                if (_trangThaiVienChucRepository == null)
                {
                    _trangThaiVienChucRepository = new TrangThaiVienChucRepository(_db);
                }
                return _trangThaiVienChucRepository;
            }
        }

        public VienChucRepository VienChucRepository
        {
            get
            {
                if (_vienChucRepository == null)
                {
                    _vienChucRepository = new VienChucRepository(_db);
                }
                return _vienChucRepository;
            }
        }
        
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
