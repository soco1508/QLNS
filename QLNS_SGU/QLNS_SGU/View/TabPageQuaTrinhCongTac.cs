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
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraBars;
using DevExpress.XtraLayout;
using DevExpress.XtraRichEdit;
using DevExpress.XtraTab;

namespace QLNS_SGU.View
{
    public interface ITabPageQuaTrinhCongTac : IView<ITabPageQuaTrinhCongTacPresenter>
    {
        XtraTabControl XtraTabControl { get; set; }
        OpenFileDialog OpenFileDialog { get; set; }
        SaveFileDialog SaveFileDialog { get; set; }
        //tab1
        GridControl GCTabPageQuaTrinhCongTac { get; set; }
        GridView GVTabPageQuaTrinhCongTac { get; set; }
        TextEdit TXTMaVienChuc { get; set; }
        TextEdit TXTRowIndex { get; set; }        
        TextEdit TXTPhanLoaiCongTac { get; set; }
        TextEdit TXTLinkVanBanDinhKem { get; set; }
        TextEdit TXTHeSoChucVu { get; set; }
        LookUpEdit CBXChucVu { get; set; }
        LookUpEdit CBXDonVi { get; set; }
        LookUpEdit CBXToChuyenMon { get; set; }
        LookUpEdit CBXPhanLoai { get; set; }
        LookUpEdit CBXKiemNhiem { get; set; }
        LookUpEdit CBXLoaiThayDoi { get; set; }
        DateEdit DTNgayBatDau { get; set; }
        DateEdit DTNgayKetThuc { get; set; }
        //tab2
        GridControl GCTabPageHopDong { get; set; }
        GridView GVTabPageHopDong { get; set; }
        LookUpEdit CBXLoaiHopDong { get; set; }
        DateEdit DTNgayBatDauHD { get; set; }
        DateEdit DTNgayKetThucHD { get; set; }
        TextEdit TXTGhiChuHD { get; set; }
        TextEdit TXTLinkVanBanDinhKemHD { get; set; }
    }
    public partial class TabPageQuaTrinhCongTac : XtraForm, ITabPageQuaTrinhCongTac
    {
        public TabPageQuaTrinhCongTac()
        {
            InitializeComponent();
        }
        #region Controls
        public XtraTabControl XtraTabControl { get => xtraTabControl1; set => xtraTabControl1 = value; }
        public OpenFileDialog OpenFileDialog { get => openFileDialog1; set => openFileDialog1 = value; }
        public SaveFileDialog SaveFileDialog { get => saveFileDialog1; set => saveFileDialog1 = value; }
        //tab1
        public GridControl GCTabPageQuaTrinhCongTac { get => gcTabPageQuaTrinhCongTac; set => gcTabPageQuaTrinhCongTac = value; }
        public GridView GVTabPageQuaTrinhCongTac { get => gvTabPageQuaTrinhCongTac; set => gvTabPageQuaTrinhCongTac = value; }
        public TextEdit TXTMaVienChuc { get => txtMaVienChuc; set => txtMaVienChuc = value; }        
        public TextEdit TXTLinkVanBanDinhKem { get => txtLinkVanBanDinhKem; set => txtLinkVanBanDinhKem = value; }
        public TextEdit TXTRowIndex { get => txtRowIndex; set => txtRowIndex = value; }
        public TextEdit TXTHeSoChucVu { get => txtHeSoChucVu; set => txtHeSoChucVu = value; }
        public TextEdit TXTPhanLoaiCongTac { get => txtPhanLoaiCongTac; set => txtPhanLoaiCongTac = value; }
        public LookUpEdit CBXChucVu { get => cbxChucVu; set => cbxChucVu = value; }
        public LookUpEdit CBXDonVi { get => cbxDonVi; set => cbxDonVi = value; }
        public LookUpEdit CBXToChuyenMon { get => cbxToChuyenMon; set => cbxToChuyenMon = value; }
        public LookUpEdit CBXPhanLoai { get => cbxCheckPhanLoaiCongTac; set => cbxCheckPhanLoaiCongTac = value; }
        public LookUpEdit CBXKiemNhiem { get => cbxKiemNhiem; set => cbxKiemNhiem = value; }
        public LookUpEdit CBXLoaiThayDoi { get => cbxLoaiThayDoi; set => cbxLoaiThayDoi = value; }
        public DateEdit DTNgayBatDau { get => dtNgayBatDau; set => dtNgayBatDau = value; }
        public DateEdit DTNgayKetThuc { get => dtNgayKetThuc; set => dtNgayKetThuc = value; }
        //tab2
        public GridControl GCTabPageHopDong { get => gcHopDong; set => gcHopDong = value; }
        public GridView GVTabPageHopDong { get => gvHopDong; set => gvHopDong = value; }
        public LookUpEdit CBXLoaiHopDong { get => cbxLoaiHopDong; set => cbxLoaiHopDong = value; }
        public DateEdit DTNgayBatDauHD { get => dtNgayBatDauHD; set => dtNgayBatDauHD = value; }
        public DateEdit DTNgayKetThucHD { get => dtNgayKetThucHD; set => dtNgayKetThucHD = value; }
        public TextEdit TXTGhiChuHD { get => txtGhiChuHD; set => txtGhiChuHD = value; }
        public TextEdit TXTLinkVanBanDinhKemHD { get => txtLinkVanBanDinhKemHD; set => txtLinkVanBanDinhKemHD = value; }
        #endregion
        public void Attach(ITabPageQuaTrinhCongTacPresenter presenter)
        {
            Load += (s, e) => presenter.LoadForm();
            //tab1           
            gvTabPageQuaTrinhCongTac.Click += (s, e) => presenter.ClickRowAndShowInfoCV();
            btnUploadCV.Click += (s, e) => presenter.UploadFileToGoogleDriveCV();
            btnDownloadCV.Click += (s, e) => presenter.DownloadFileToDeviceCV();
            btnEditCV.Click += (s, e) => presenter.EditCV();
            btnRefreshCV.Click += (s, e) => presenter.RefreshCV();
            btnAddCV.Click += (s, e) => presenter.AddCV();
            btnDeleteCV.Click += (s, e) => presenter.DeleteCV();
            btnExportExcelCV.Click += (s, e) => presenter.ExportExcelCV();
            cbxChucVu.EditValueChanged += new EventHandler(presenter.ChucVuChanged);
            cbxDonVi.EditValueChanged += new EventHandler(presenter.DonViChanged);
            //tab2
            gvHopDong.Click += (s, e) => presenter.ClickRowAndShowInfoHD();
            btnUploadHD.Click += (s, e) => presenter.UploadFileToGoogleDriveHD();
            btnDownloadHD.Click += (s, e) => presenter.DownloadFileToDeviceHD();
            btnEditHD.Click += (s, e) => presenter.EditHD();
            btnRefreshHD.Click += (s, e) => presenter.RefreshHD();
            btnAddHD.Click += (s, e) => presenter.AddHD();
            btnDeleteHD.Click += (s, e) => presenter.DeleteHD();
            btnExportExcelHD.Click += (s, e) => presenter.ExportExcelHD();
        }
    }
}