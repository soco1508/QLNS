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
    public interface IVienChucForm : IView<IVienChucPresenter>
    {
        GridControl GCVienChuc { get; set; }
        GridView GVVienChuc { get; set; }
        SaveFileDialog SaveFileDialog { get; set; }
        PopupMenu PopupMenuVienChuc { get; set; }
    }
    public partial class VienChucForm : XtraForm, IVienChucForm
    {
        public VienChucForm()
        {
            InitializeComponent();
        }
        #region Controls
        public GridControl GCVienChuc { get => gcVienChuc; set => gcVienChuc = value; }
        public GridView GVVienChuc { get => gvVienChuc; set => gvVienChuc = value; }
        public SaveFileDialog SaveFileDialog { get => saveFileDialog1; set => saveFileDialog1 = value; }
        public PopupMenu PopupMenuVienChuc { get => popupMenuView; set => popupMenuView = value; }
        #endregion
        public void Attach(IVienChucPresenter presenter)
        {
            btnExportExcel.ItemClick += (s, e) => presenter.ExportExcel();
            gvVienChuc.CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler(presenter.RowIndicator);
            gvVienChuc.MouseDown += new MouseEventHandler(presenter.RightClickGrid);
            btnOpenThongTinCaNhan.ItemClick += (s, e) => presenter.OpenThongTinCaNhan();
            btnOpenQuaTrinhCongTac.ItemClick += (s, e) => presenter.OpenQuaTrinhCongTac();
            btnOpenHopDong.ItemClick += (s, e) => presenter.OpenHopDong();
            btnOpenQuaTrinhLuong.ItemClick += (s, e) => presenter.OpenQuaTrinhLuong();
            btnOpenHocHamHocVi.ItemClick += (s, e) => presenter.OpenHocHamHocVi();
            btnOpenDangHocNangCao.ItemClick += (s, e) => presenter.OpenDangHocNangCao();
            btnOpenNganh.ItemClick += (s, e) => presenter.OpenNganh();
            btnOpenChungChi.ItemClick += (s, e) => presenter.OpenChungChi();
            btnOpenTrangThai.ItemClick += (s, e) => presenter.OpenTrangThai();
            btnRefresh.ItemClick += (s, e) => presenter.Refresh();
            btnDelete.ItemClick += (s, e) => presenter.Delete();
        }
    }
}