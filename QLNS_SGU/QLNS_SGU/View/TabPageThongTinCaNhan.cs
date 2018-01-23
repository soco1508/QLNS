using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLNS_SGU.Presenter;
using DevExpress.XtraBars;

namespace QLNS_SGU.View
{
    public interface ITabPageThongTinCaNhan : IView<ITabPageThongTinCaNhanPresenter>
    {
        PictureEdit PICVienChuc { get; set; }
        TextEdit TXTMaVienChuc { get; set; }
        RadioGroup RADGioiTinh { get; set; }
        TextEdit TXTHo { get; set; }
        TextEdit TXTTen { get; set; }
        DateEdit DTNgaySinh { get; set; }
        DateEdit DTNgayThamGiaCongTac { get; set; }
        DateEdit DTNgayVaoNganh { get; set; }
        DateEdit DTNgayVeTruong { get; set; }
        TextEdit TXTSoDienThoai { get; set; }
        TextEdit TXTNoiSinh { get; set; }
        TextEdit TXTQueQuan { get; set; }
        LookUpEdit CBXDanToc { get; set; }
        LookUpEdit CBXTonGiao { get; set; }
        TextEdit TXTHoKhauThuongTru { get; set; }
        TextEdit TXTNoiOHienNay { get; set; }
        CheckEdit CHKLaDangVien { get; set; }
        DateEdit DTNgayVaoDang { get; set; }
        TextEdit TXTVanHoa { get; set; }
        LookUpEdit CBXQuanLyNhaNuoc { get; set; }
        LookUpEdit CBXChinhTri { get; set; }
        MemoEdit TXTGhiChu { get; set; }
    }
    public partial class TabPageThongTinCaNhan : XtraForm, ITabPageThongTinCaNhan
    {
        public TabPageThongTinCaNhan()
        {
            InitializeComponent();
        }
        #region Controls
        public PictureEdit PICVienChuc { get => picVienChuc; set => picVienChuc = value; }
        public TextEdit TXTMaVienChuc { get => txtMaVienChuc; set => txtMaVienChuc = value; }
        public RadioGroup RADGioiTinh { get => radGioiTinh; set => radGioiTinh = value; }
        public TextEdit TXTHo { get => txtHo; set => txtHo = value; }
        public TextEdit TXTTen { get => txtTen; set => txtTen = value; }
        public DateEdit DTNgaySinh { get => dtNgaySinh; set => dtNgaySinh = value; }
        public DateEdit DTNgayThamGiaCongTac { get => dtNgayThamGiaCongTac; set => dtNgayThamGiaCongTac = value; }
        public DateEdit DTNgayVaoNganh { get => dtNgayVaoNganh; set => dtNgayVaoNganh = value; }
        public DateEdit DTNgayVeTruong { get => dtNgayVeTruong; set => dtNgayVeTruong = value; }
        public TextEdit TXTSoDienThoai { get => txtSoDienThoai; set => txtSoDienThoai = value; }
        public TextEdit TXTNoiSinh { get => txtNoiSinh; set => txtNoiSinh = value; }
        public TextEdit TXTQueQuan { get => txtQueQuan; set => txtQueQuan = value; }
        public LookUpEdit CBXDanToc { get => cbxDanToc; set => cbxDanToc = value; }
        public LookUpEdit CBXTonGiao { get => cbxTonGiao; set => cbxTonGiao = value; }
        public TextEdit TXTHoKhauThuongTru { get => txtHoKhauThuongTru; set => txtHoKhauThuongTru = value; }
        public TextEdit TXTNoiOHienNay { get => txtNoiOHienNay; set => txtNoiOHienNay = value; }
        public CheckEdit CHKLaDangVien { get => chkLaDangVien; set => chkLaDangVien = value; }
        public DateEdit DTNgayVaoDang { get => dtNgayVaoDang; set => dtNgayVaoDang = value; }
        public TextEdit TXTVanHoa { get => txtVanHoa; set => txtVanHoa = value; }
        public LookUpEdit CBXQuanLyNhaNuoc { get => cbxQuanLyNhaNuoc; set => cbxQuanLyNhaNuoc = value; }
        public LookUpEdit CBXChinhTri { get => cbxChinhTri; set => cbxChinhTri = value; }
        public MemoEdit TXTGhiChu { get => txtGhiChu; set => txtGhiChu = value; }
        #endregion
        public void Attach(ITabPageThongTinCaNhanPresenter presenter)
        {
            Load += (s, e) => presenter.LoadForm();
            //btnAddNew.ItemClick += (s, e) => presenter.AddNew();
            btnSave.ItemClick += (s, e) => presenter.Save();
            btnSaveAndClose.ItemClick += (s, e) => presenter.SaveAndClose();
            chkLaDangVien.CheckedChanged += new EventHandler(presenter.CheckedLaDangVienChanged);
        }
    }
}