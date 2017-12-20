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
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using QLNS_SGU.Presenter;
using DevExpress.XtraBars;

namespace QLNS_SGU.View
{
    public interface ITabPageTrangThai : IView<ITabPageTrangThaiPresenter>
    {
        OpenFileDialog OpenFileDialog { get; set; }
        SaveFileDialog SaveFileDialog { get; set; }
        GridControl GCTabPageTrangThai { get; set; }
        GridView GVTabPageTrangThai { get; set; }
        LookUpEdit CBXTrangThai { get; set; }
        DateEdit DTNgayBatDau { get; set; }
        DateEdit DTNgayKetThuc { get; set; }
        TextEdit TXTMoTa { get; set; }
        TextEdit TXTDiaDiem { get; set; }
        TextEdit TXTLinkVanBanDinhKem { get; set; }
        BarStaticItem TXTMaVienChuc { get; set; }
        BarStaticItem TXTRownIndex { get; set; }
    }
    public partial class TabPageTrangThai : XtraForm, ITabPageTrangThai
    {
        public TabPageTrangThai()
        {
            InitializeComponent();
        }
        #region Controls
        public OpenFileDialog OpenFileDialog { get => openFileDialog1; set => openFileDialog1 = value; }
        public SaveFileDialog SaveFileDialog { get => saveFileDialog1; set => saveFileDialog1 = value; }
        public GridControl GCTabPageTrangThai { get => gcTrangThai; set => gcTrangThai = value; }
        public GridView GVTabPageTrangThai { get => gvTrangThai; set => gvTrangThai = value; }
        public LookUpEdit CBXTrangThai { get => cbxTrangThai; set => cbxTrangThai = value; }
        public DateEdit DTNgayBatDau { get => dtNgayBatDau; set => dtNgayBatDau = value; }
        public DateEdit DTNgayKetThuc { get => dtNgayKetThuc; set => dtNgayKetThuc = value; }
        public TextEdit TXTMoTa { get => txtMoTa; set => txtMoTa = value; }
        public TextEdit TXTDiaDiem { get => txtDiaDiem; set => txtDiaDiem = value; }
        public TextEdit TXTLinkVanBanDinhKem { get => txtLinkVanBanDinhKem; set => txtLinkVanBanDinhKem = value; }
        public BarStaticItem TXTMaVienChuc { get => txtMaVienChuc; set => txtMaVienChuc = value; }
        public BarStaticItem TXTRownIndex { get => txtRowIndex; set => txtRowIndex = value; }
        #endregion
        public void Attach(ITabPageTrangThaiPresenter presenter)
        {
            Load += (s, e) => presenter.LoadForm();
            gvTrangThai.Click += (s, e) => presenter.ClickRowAndShowInfo();
            btnUpload.ItemClick += (s, e) => presenter.UploadFileToGoogleDrive();
            btnDownload.ItemClick += (s, e) => presenter.DownloadFileToDevice();
            btnEdit.ItemClick += (s, e) => presenter.Edit();
            btnRefresh.ItemClick += (s, e) => presenter.Refresh();
            btnAdd.ItemClick += (s, e) => presenter.Add();
            btnDelete.ItemClick += (s, e) => presenter.Delete();
            btnExportExcel.ItemClick += (s, e) => presenter.ExportExcel();
        }
    }
}