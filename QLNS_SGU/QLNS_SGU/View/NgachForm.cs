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
    public interface INgachForm : IView<INgachPresenter>
    {
        GridControl GCNgach { get; set; }
        GridView GVNgach { get; set; }
        SaveFileDialog SaveFileDialog { get; set; }
    }
    public partial class NgachForm : XtraForm, INgachForm
    {
        public NgachForm()
        {
            InitializeComponent();
        }

        #region Controls
        public GridControl GCNgach { get => gcNgach; set => gcNgach = value; }
        public GridView GVNgach { get => gvNgach; set => gvNgach = value; }
        public SaveFileDialog SaveFileDialog { get => saveFileDialog1; set => saveFileDialog1 = value; }
        #endregion

        public void Attach(INgachPresenter presenter)
        {
            btnRefresh.ItemClick += (s, e) => presenter.RefreshGrid();
            btnAdd.ItemClick += (s, e) => presenter.AddNewRow();
            btnSave.ItemClick += (s, e) => presenter.SaveData();
            btnDelete.ItemClick += (s, e) => presenter.DeleteRow();
            btnExportExcel.ItemClick += (s, e) => presenter.ExportExcel();
            gcNgach.MouseDoubleClick += new MouseEventHandler(presenter.MouseDoubleClick);
            gvNgach.HiddenEditor += new EventHandler(presenter.HiddenEditor);
            gvNgach.InitNewRow += new InitNewRowEventHandler(presenter.InitNewRow);
            gvNgach.KeyDown += new KeyEventHandler(presenter.EnterToCloseEditor);
            gvNgach.CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler(presenter.RowIndicator);
        }
    }
}