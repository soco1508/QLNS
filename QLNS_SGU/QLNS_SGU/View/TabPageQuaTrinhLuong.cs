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
        TextEdit TXTTenNgach { get; set; }
        LookUpEdit CBXBac { get; set; }
        DateEdit DTNgayBatDau { get; set; }
        DateEdit DTNgayLenLuong { get; set; }
        SpinEdit TXTHeSoBac { get; set; }
        CheckEdit CHKDangHuongLuong { get; set; }
        TextEdit TXTMaVienChuc { get; set; }
        TextEdit TXTRownIndex { get; set; }
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
        public TextEdit TXTTenNgach { get => txtTenNgach; set => txtTenNgach = value; }
        public LookUpEdit CBXBac { get => cbxBac; set => cbxBac = value; }
        public DateEdit DTNgayBatDau { get => dtNgayBatDau; set => dtNgayBatDau = value; }
        public DateEdit DTNgayLenLuong { get => dtNgayLenLuong; set => dtNgayLenLuong = value; }
        public TextEdit TXTLinkVanBanDinhKem { get => txtLinkVanBanDinhKem; set => txtLinkVanBanDinhKem = value; }
        public TextEdit TXTMaVienChuc { get => txtMaVienChuc; set => txtMaVienChuc = value; }
        public TextEdit TXTRownIndex { get => txtRowIndex; set => txtRowIndex = value; }
        public SpinEdit TXTHeSoBac { get => txtHeSoBac; set => txtHeSoBac = value; }
        public CheckEdit CHKDangHuongLuong { get => chkDangHuongLuong; set => chkDangHuongLuong = value; }
        #endregion
        public void Attach(ITabPageQuaTrinhLuongPresenter presenter)
        {
            Load += (s, e) => presenter.LoadForm();
            cbxMaNgach.EditValueChanged += new EventHandler(presenter.MaNgachChanged);
            txtTenNgach.TextChanged += new EventHandler(presenter.TenNgachChanged);
            cbxBac.EditValueChanged += new EventHandler(presenter.BacChanged);
            dtNgayBatDau.DateTimeChanged += new EventHandler(presenter.NgayBatDauChanged);
            dtNgayLenLuong.DateTimeChanged += new EventHandler(presenter.NgayLenLuongChanged);
            chkDangHuongLuong.CheckedChanged += new EventHandler(presenter.DangHuongLuongChanged);
            txtLinkVanBanDinhKem.TextChanged += new EventHandler(presenter.LinkVanBanDinhKemChanged);
            gvQuaTrinhLuong.Click += (s, e) => presenter.ClickRowAndShowInfo();
            btnUpload.Click += (s, e) => presenter.UploadFileToGoogleDrive();
            btnDownload.Click += (s, e) => presenter.DownloadFileToDevice();
            btnSave.Click += (s, e) => presenter.Save();
            btnRefresh.Click += (s, e) => presenter.Refresh();
            btnAdd.Click += (s, e) => presenter.Add();
            btnDelete.Click += (s, e) => presenter.Delete();
            btnExportExcel.Click += (s, e) => presenter.ExportExcel();            
        }
    }
}