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
    public interface ITrangThaiForm : IView<ITrangThaiPresenter>
    {
        GridControl GCTrangThai { get; set; }
        GridView GVTrangThai { get; set; }
        SaveFileDialog SaveFileDialog { get; set; }
    }
    public partial class TrangThaiForm : XtraForm, ITrangThaiForm
    {
        public TrangThaiForm()
        {
            InitializeComponent();
        }

        #region Controls
        public GridControl GCTrangThai { get => gcTrangThai; set => gcTrangThai = value; }
        public GridView GVTrangThai { get => gvTrangThai; set => gvTrangThai = value; }
        public SaveFileDialog SaveFileDialog { get => saveFileDialog1; set => saveFileDialog1 = value; }
        #endregion
        public void Attach(ITrangThaiPresenter presenter)
        {
            btnRefresh.ItemClick += (s, e) => presenter.RefreshGrid();
            btnAdd.ItemClick += (s, e) => presenter.AddNewRow();
            btnSave.ItemClick += (s, e) => presenter.SaveData();
            btnDelete.ItemClick += (s, e) => presenter.DeleteRow();
            btnExportExcel.ItemClick += (s, e) => presenter.ExportExcel();
            gcTrangThai.MouseDoubleClick += new MouseEventHandler(presenter.MouseDoubleClick);
            gvTrangThai.HiddenEditor += new EventHandler(presenter.HiddenEditor);
            gvTrangThai.InitNewRow += new InitNewRowEventHandler(presenter.InitNewRow);
            gvTrangThai.KeyDown += new KeyEventHandler(presenter.EnterToCloseEditor);
            gvTrangThai.CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler(presenter.RowIndicator);
        }       
    }
}