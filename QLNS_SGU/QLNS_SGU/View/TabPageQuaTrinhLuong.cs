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

namespace QLNS_SGU.View
{
    public interface ITabPageQuaTrinhLuong : IView<ITabPageQuaTrinhLuongPresenter>
    {
        OpenFileDialog OpenFileDialog { get; set; }
        SaveFileDialog SaveFileDialog { get; set; }
        GridControl GCTabPageQuaTrinhLuong { get; set; }
        GridView GVTabPageQuaTrinhLuong { get; set; }
        LookUpEdit CBXMaNgach { get; set; }
        LookUpEdit CBXBac { get; set; }
        DateEdit DTNgayBatDau { get; set; }
        DateEdit DTNgayLenLuong { get; set; }
        SpinEdit TXTHeSoBac { get; set; }
        CheckEdit CHKDangHuongLuong { get; set; }
        BarStaticItem TXTMaVienChuc { get; set; }
        BarStaticItem TXTRownIndex { get; set; }
    }
    public partial class TabPageQuaTrinhLuong : XtraForm, ITabPageQuaTrinhLuong
    {
        public TabPageQuaTrinhLuong()
        {
            InitializeComponent();
        }
        #region Controls
        public OpenFileDialog OpenFileDialog { get => openFileDialog1; set => openFileDialog1 = value; }
        public SaveFileDialog SaveFileDialog { get => saveFileDialog1; set => saveFileDialog1 = value; }
        public GridControl GCTabPageQuaTrinhLuong { get => gcQuaTrinhLuong; set => gcQuaTrinhLuong = value; }
        public GridView GVTabPageQuaTrinhLuong { get => gvQuaTrinhLuong; set => gvQuaTrinhLuong = value; }
        public LookUpEdit CBXMaNgach { get => cbxMaNgach; set => cbxMaNgach = value; }
        public LookUpEdit CBXBac { get => cbxBac; set => cbxBac = value; }
        public DateEdit DTNgayBatDau { get => dtNgayBatDau; set => dtNgayBatDau = value; }
        public DateEdit DTNgayLenLuong { get => dtNgayLenLuong; set => dtNgayLenLuong = value; }
        public TextEdit TXTLinkVanBanDinhKem { get => txtLinkVanBanDinhKem; set => txtLinkVanBanDinhKem = value; }
        public BarStaticItem TXTMaVienChuc { get => txtMaVienChuc; set => txtMaVienChuc = value; }
        public BarStaticItem TXTRownIndex { get => txtRowIndex; set => txtRowIndex = value; }
        public SpinEdit TXTHeSoBac { get => txtHeSoBac; set => txtHeSoBac = value; }
        public CheckEdit CHKDangHuongLuong { get => chkDangHuongLuong; set => chkDangHuongLuong = value; }
        #endregion
        public void Attach(ITabPageQuaTrinhLuongPresenter presenter)
        {
            Load += (s, e) => presenter.LoadForm();
            cbxBac.EditValueChanged += new EventHandler(presenter.BacChanged);
            gvQuaTrinhLuong.Click += (s, e) => presenter.ClickRowAndShowInfo();
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