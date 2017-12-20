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

namespace QLNS_SGU.View
{
    public interface ILoaiChucVuForm : IView<ILoaiChucVuPresenter>
    {
        GridControl GCLoaiChucVu { get; set; }
        GridView GVLoaiChucVu { get; set; }
        SaveFileDialog SaveFileDialog { get; set; }
    }
    public partial class LoaiChucVuForm : XtraForm
    {
        public LoaiChucVuForm()
        {
            InitializeComponent();
        }

        #region Controls
        public GridControl GCLoaiChucVu { get => gcLoaiChucVu; set => gcLoaiChucVu = value; }
        public GridView GVLoaiChucVu { get => gvLoaiChucVu; set => gvLoaiChucVu = value; }
        public SaveFileDialog SaveFileDialog { get => saveFileDialog1; set => saveFileDialog1 = value; }
        #endregion

        public void Attach(ILoaiChucVuPresenter presenter)
        {
            btnRefresh.ItemClick += (s, e) => presenter.RefreshGrid();
            btnAdd.ItemClick += (s, e) => presenter.AddNewRow();
            btnSave.ItemClick += (s, e) => presenter.SaveData();
            btnDelete.ItemClick += (s, e) => presenter.DeleteRow();
            btnExportExcel.ItemClick += (s, e) => presenter.ExportExcel();
            gcLoaiChucVu.MouseDoubleClick += new MouseEventHandler(presenter.MouseDoubleClick);
            gvLoaiChucVu.HiddenEditor += new EventHandler(presenter.HiddenEditor);
            gvLoaiChucVu.InitNewRow += new InitNewRowEventHandler(presenter.InitNewRow);
            gvLoaiChucVu.KeyDown += new KeyEventHandler(presenter.EnterToCloseEditor);
            gvLoaiChucVu.CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler(presenter.RowIndicator);
        }
    }
}