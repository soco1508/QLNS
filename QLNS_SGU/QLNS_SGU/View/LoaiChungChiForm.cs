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
    public interface ILoaiChungChiForm : IView<ILoaiChungChiPresenter>
    {
        GridControl GCLoaiChungChi { get; set; }
        GridView GVLoaiChungChi { get; set; }
        SaveFileDialog SaveFileDialog { get; set; }
    }
    public partial class LoaiChungChiForm : XtraForm
    {
        public LoaiChungChiForm()
        {
            InitializeComponent();
        }

        #region Controls
        public GridControl GCLoaiChungChi { get => gcLoaiChungChi; set => gcLoaiChungChi = value; }
        public GridView GVLoaiChungChi { get => gvLoaiChungChi; set => gvLoaiChungChi = value; }
        public SaveFileDialog SaveFileDialog { get => saveFileDialog1; set => saveFileDialog1 = value; }
        #endregion

        public void Attach(ILoaiChungChiPresenter presenter)
        {
            btnRefresh.ItemClick += (s, e) => presenter.RefreshGrid();
            btnAdd.ItemClick += (s, e) => presenter.AddNewRow();
            btnSave.ItemClick += (s, e) => presenter.SaveData();
            btnDelete.ItemClick += (s, e) => presenter.DeleteRow();
            btnExportExcel.ItemClick += (s, e) => presenter.ExportExcel();
            gcLoaiChungChi.MouseDoubleClick += new MouseEventHandler(presenter.MouseDoubleClick);
            gvLoaiChungChi.HiddenEditor += new EventHandler(presenter.HiddenEditor);
            gvLoaiChungChi.InitNewRow += new InitNewRowEventHandler(presenter.InitNewRow);
            gvLoaiChungChi.KeyDown += new KeyEventHandler(presenter.EnterToCloseEditor);
            gvLoaiChungChi.CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler(presenter.RowIndicator);
        }
    }
}