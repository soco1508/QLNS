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
using DevExpress.XtraTab;

namespace QLNS_SGU.View
{
    public interface ITabPageChuyenMon : IView<ITabPageChuyenMonPresenter>
    {
        XtraTabControl XtraTabControl { get; set; }
        SaveFileDialog SaveFileDialog { get; set; }
        OpenFileDialog OpenFileDialog { get; set; }
        TextEdit TXTMaVienChuc { get; set; }
        TextEdit TXTRowIndex { get; set; }
        //tab1
        GridControl GCHocHamHocVi { get; set; }
        GridView GVHocHamHocVi { get; set; }
        LookUpEdit CBXLoaiHocHamHocViHHHV { get; set; }
        LookUpEdit CBXNganhDaoTaoHHHV { get; set; }
        LookUpEdit CBXChuyenNganhHHHV { get; set; }
        TextEdit TXTTenHocHamHocViHHHV { get; set; }
        TextEdit TXTCoSoDaoTaoHHHV { get; set; }
        TextEdit TXTNgonNguDaoTaoHHHV { get; set; }
        TextEdit TXTHinhThucDaoTaoHHHV { get; set; }
        TextEdit TXTNuocCapBangHHHV { get; set; }
        DateEdit DTNgayCapBang { get; set; }
        TextEdit TXTLinkVanBanDinhKemHHHV { get; set; }
        //tab2
        GridControl GCDangHocNangCao { get; set; }
        GridView GVDangHocNangCao { get; set; }
        LookUpEdit CBXLoaiHocHamHocViDHNC { get; set; }
        LookUpEdit CBXLoai { get; set; }
        TextEdit TXTTenHocHamHocViDHNC { get; set; }
        TextEdit TXTCoSoDaoTaoDHNC { get; set; }
        TextEdit TXTNgonNguDaoTaoDHNC { get; set; }
        TextEdit TXTHinhThucDaoTaoDHNC { get; set; }
        TextEdit TXTNuocCapBangDHNC { get; set; }
        DateEdit DTNgayBatDauDHNC { get; set; }
        DateEdit DTNgayKetThucDHNC { get; set; }
        TextEdit TXTSoQuyetDinh { get; set; }
        TextEdit TXTLinkAnhQuyetDinh { get; set; }
        //tab3
        GridControl GCNganh { get; set; }
        GridView GVNganh { get; set; }
        LookUpEdit CBXNganhDaoTaoN { get; set; }
        LookUpEdit CBXChuyenNganhN { get; set; }
        LookUpEdit CBXPhanLoaiN { get; set; }
        LookUpEdit CBXTenHocHamHocViN { get; set; }
        DateEdit DTNgayBatDauN { get; set; }
        DateEdit DTNgayKetThucN { get; set; }
        TextEdit TXTLinkVanBanDinhKemN { get; set; }
        //tab4
        GridControl GCChungChi { get; set; }
        GridView GVChungChi { get; set; }
        LookUpEdit CBXLoaiChungChi { get; set; }
        TextEdit TXTCapDoChungChi { get; set; }
        DateEdit DTNgayCapChungChi { get; set; }
        TextEdit TXTGhiChuCC { get; set; }
        TextEdit TXTLinkVanBanDinhKemCC { get; set; }
    }
    public partial class TabPageChuyenMon : XtraForm, ITabPageChuyenMon
    {
        public TabPageChuyenMon()
        {
            InitializeComponent();
        }
        #region Controls
        public XtraTabControl XtraTabControl { get => xtraTabControl1; set => xtraTabControl1 = value; }
        public SaveFileDialog SaveFileDialog { get => saveFileDialog1; set => saveFileDialog1 = value; }
        public OpenFileDialog OpenFileDialog { get => openFileDialog1; set => openFileDialog1 = value; }
        //tab1
        public TextEdit TXTMaVienChuc { get => txtMaVienChuc; set => txtMaVienChuc = value; }
        public TextEdit TXTRowIndex { get => txtRowIndex; set => txtRowIndex = value; }
        public GridControl GCHocHamHocVi { get => gcHocHamHocVi; set => gcHocHamHocVi = value; }
        public GridView GVHocHamHocVi { get => gvHocHamHocVi; set => gvHocHamHocVi = value; }
        public LookUpEdit CBXLoaiHocHamHocViHHHV { get => cbxLoaiHocHamHocViHHHV; set => cbxLoaiHocHamHocViHHHV = value; }
        public LookUpEdit CBXNganhDaoTaoHHHV { get => cbxNganhDaoTaoHHHV; set => cbxNganhDaoTaoHHHV = value; }
        public LookUpEdit CBXChuyenNganhHHHV { get => cbxChuyenNganhHHHV; set => cbxChuyenNganhHHHV = value; }
        public TextEdit TXTTenHocHamHocViHHHV { get => txtTenHocHamHocViHHHV; set => txtTenHocHamHocViHHHV = value; }
        public TextEdit TXTCoSoDaoTaoHHHV { get => txtCoSoDaoTaoHHHV; set => txtCoSoDaoTaoHHHV = value; }
        public TextEdit TXTNgonNguDaoTaoHHHV { get => txtNgonNguDaoTaoHHHV; set => txtNgonNguDaoTaoHHHV = value; }
        public TextEdit TXTHinhThucDaoTaoHHHV { get => txtHinhThucDaoTaoHHHV; set => txtHinhThucDaoTaoHHHV = value; }
        public TextEdit TXTNuocCapBangHHHV { get => txtNuocCapBangHHHV; set => txtNuocCapBangHHHV = value; }
        public DateEdit DTNgayCapBang { get => dtNgayCapBangHHHV; set => dtNgayCapBangHHHV = value; }
        public TextEdit TXTLinkVanBanDinhKemHHHV { get => txtLinkVanBanDinhKemHHHV; set => txtLinkVanBanDinhKemHHHV = value; }
        //tab2
        public GridControl GCDangHocNangCao { get => gcDangHocNangCao; set => gcDangHocNangCao = value; }
        public GridView GVDangHocNangCao { get => gvDangHocNangCao; set => gvDangHocNangCao = value; }
        public LookUpEdit CBXLoaiHocHamHocViDHNC { get => cbxLoaiHocHamHocViDHNC; set => cbxLoaiHocHamHocViDHNC = value; }
        public LookUpEdit CBXLoai { get => cbxLoai; set => cbxLoai = value; }
        public TextEdit TXTTenHocHamHocViDHNC { get => txtTenHocHamHocViDHNC; set => txtTenHocHamHocViDHNC = value; }
        public TextEdit TXTCoSoDaoTaoDHNC { get => txtCoSoDaoTaoDHNC; set => txtCoSoDaoTaoDHNC = value; }
        public TextEdit TXTNgonNguDaoTaoDHNC { get => txtNgonNguDaoTaoDHNC; set => txtNgonNguDaoTaoDHNC = value; }
        public TextEdit TXTHinhThucDaoTaoDHNC { get => txtHinhThucDaoTaoDHNC; set => txtHinhThucDaoTaoDHNC = value; }
        public TextEdit TXTNuocCapBangDHNC { get => txtNuocCapBangDHNC; set => txtNuocCapBangDHNC = value; }
        public DateEdit DTNgayBatDauDHNC { get => dtNgayBatDauDHNC; set => dtNgayBatDauDHNC = value; }
        public DateEdit DTNgayKetThucDHNC { get => dtNgayKetThucDHNC; set => dtNgayKetThucDHNC = value; }
        public TextEdit TXTSoQuyetDinh { get => txtSoQuyetDinh; set => txtSoQuyetDinh = value; }
        public TextEdit TXTLinkAnhQuyetDinh { get => txtLinkAnhQuyetDinh; set => txtLinkAnhQuyetDinh = value; }
        //tab3
        public GridControl GCNganh { get => gcNganh; set => gcNganh = value; }
        public GridView GVNganh { get => gvNganh; set => gvNganh = value; }
        public LookUpEdit CBXNganhDaoTaoN { get => cbxNganhDaoTaoN; set => cbxNganhDaoTaoN = value; }
        public LookUpEdit CBXChuyenNganhN { get => cbxChuyenNganhN; set => cbxChuyenNganhN = value; }
        public LookUpEdit CBXPhanLoaiN { get => cbxPhanLoaiN; set => cbxPhanLoaiN = value; }
        public LookUpEdit CBXTenHocHamHocViN { get => cbxLoaiHocHamHocViN; set => cbxLoaiHocHamHocViN = value; }
        public DateEdit DTNgayBatDauN { get => dtNgayBatDauN; set => dtNgayBatDauN = value; }
        public DateEdit DTNgayKetThucN { get => dtNgayKetThucN; set => dtNgayKetThucN = value; }
        public TextEdit TXTLinkVanBanDinhKemN { get => txtLinkVanBanDinhKemN; set => txtLinkVanBanDinhKemN = value; }
        //tab4
        public GridControl GCChungChi { get => gcChungChi; set => gcChungChi = value; }
        public GridView GVChungChi { get => gvChungChi; set => gvChungChi = value; }
        public LookUpEdit CBXLoaiChungChi { get => cbxLoaiChungChi; set => cbxLoaiChungChi = value; }
        public TextEdit TXTCapDoChungChi { get => txtCapDoChungChi; set => txtCapDoChungChi = value; }
        public DateEdit DTNgayCapChungChi { get => dtNgayCapChungChi; set => dtNgayCapChungChi = value; }
        public TextEdit TXTGhiChuCC { get => txtGhiChuCC; set => txtGhiChuCC = value; }
        public TextEdit TXTLinkVanBanDinhKemCC { get => txtLinkVanBanDinhKemCC; set => txtLinkVanBanDinhKemCC = value; }

        #endregion
        public void Attach(ITabPageChuyenMonPresenter presenter)
        {
            Load += (s, e) => presenter.LoadForm();
            //HHHV
            cbxNganhDaoTaoHHHV.EditValueChanged += new EventHandler(presenter.CbxNganhDaoTaoHHHVChanged);
            gvHocHamHocVi.Click += (s, e) => presenter.ClickRowAndShowInfoHHHV();                                  
            btnRefreshHHHV.Click += (s, e) => presenter.RefreshHHHV();
            btnAddHHHV.Click += (s, e) => presenter.AddHHHV();
            btnSaveHHHV.Click += (s, e) => presenter.EditHHHV();
            btnDeleteHHHV.Click += (s, e) => presenter.DeleteHHHV();
            btnExportExcelHHHV.Click += (s, e) => presenter.ExportExcelHHHV();
            btnUploadHHHV.Click += (s, e) => presenter.UploadFileToGoogleDriveHHHV();
            btnDownloadHHHV.Click += (s, e) => presenter.DownloadFileToDeviceHHHV();
            //DHNC
            gvDangHocNangCao.Click += (s, e) => presenter.ClickRowAndShowInfoDHNC();
            btnRefreshDHNC.Click += (s, e) => presenter.RefreshDHNC();
            btnAddDHNC.Click += (s, e) => presenter.AddDHNC();
            btnSaveDHNC.Click += (s, e) => presenter.SaveDHNC();
            btnDeleteDHNC.Click += (s, e) => presenter.DeleteDHNC();
            btnExportExcelDHNC.Click += (s, e) => presenter.ExportExcelDHNC();
            btnUploadDHNC.Click += (s, e) => presenter.UploadFileToGoogleDriveDHNC();
            btnDownloadDHNC.Click += (s, e) => presenter.DownloadFileToDeviceDHNC();
            txtSoQuyetDinh.TextChanged += new EventHandler(presenter.SoQuyetDinhChanged);
            cbxLoaiHocHamHocViDHNC.EditValueChanged += new EventHandler(presenter.LoaiHocHamHocViDangHocNangCaoChanged);
            txtTenHocHamHocViDHNC.TextChanged += new EventHandler(presenter.TenHocHamHocViDangHocNangCaoChanged);
            dtNgayBatDauDHNC.EditValueChanged += new EventHandler(presenter.NgayBatDauDangHocNangCaoChanged);
            dtNgayKetThucDHNC.EditValueChanged += new EventHandler(presenter.NgayKetThucDangHocNangCaoChanged);
            txtCoSoDaoTaoDHNC.TextChanged += new EventHandler(presenter.CoSoDaoTaoDangHocNangCaoChanged);
            txtNgonNguDaoTaoDHNC.TextChanged += new EventHandler(presenter.NgonNguDaoTaoDangHocNangCaoChanged);
            txtHinhThucDaoTaoDHNC.TextChanged += new EventHandler(presenter.HinhThucDaoTaoDangHocNangCaoChanged);
            txtNuocCapBangDHNC.TextChanged += new EventHandler(presenter.NuocCapBangDangHocNangCaoChanged);
            cbxLoai.EditValueChanged += new EventHandler(presenter.LoaiDangHocNangCaoChanged);
            txtLinkAnhQuyetDinh.TextChanged += new EventHandler(presenter.LinkAnhQuyetDinhChanged);
            //Nganh
            cbxNganhDaoTaoN.EditValueChanged += new EventHandler(presenter.CbxNganhDaoTaoNChanged);
            gvNganh.Click += (s, e) => presenter.ClickRowAndShowInfoN();
            btnRefreshN.Click += (s, e) => presenter.RefreshN();
            btnAddN.Click += (s, e) => presenter.AddN();
            btnSaveN.Click += (s, e) => presenter.EditN();
            btnDeleteN.Click += (s, e) => presenter.DeleteN();
            btnExportExcelN.Click += (s, e) => presenter.ExportExcelN();
            btnUploadN.Click += (s, e) => presenter.UploadFileToGoogleDriveN();
            btnDownloadN.Click += (s, e) => presenter.DownloadFileToDeviceN();
            //ChungChi
            gvChungChi.Click += (s, e) => presenter.ClickRowAndShowInfoCC();
            btnRefreshCC.Click += (s, e) => presenter.RefreshCC();
            btnAddCC.Click += (s, e) => presenter.AddCC();
            btnSaveCC.Click += (s, e) => presenter.SaveCC();
            btnDeleteCC.Click += (s, e) => presenter.DeleteCC();
            btnExportExcelCC.Click += (s, e) => presenter.ExportExcelCC();
            btnUploadCC.Click += (s, e) => presenter.UploadFileToGoogleDriveCC();
            btnDownloadCC.Click += (s, e) => presenter.DownloadFileToDeviceCC();
            cbxLoaiChungChi.EditValueChanged += new EventHandler(presenter.LoaiChungChiChanged);
            txtCapDoChungChi.EditValueChanged += new EventHandler(presenter.CapDoChungChiChanged);
            dtNgayCapChungChi.EditValueChanged += new EventHandler(presenter.NgayCapChungChiChanged);
            txtGhiChuCC.TextChanged += new EventHandler(presenter.GhiChuChungChiChanged);
            txtLinkVanBanDinhKemCC.TextChanged += new EventHandler(presenter.LinkVanBanDinhKemChungChiChanged);
        }
    }
}