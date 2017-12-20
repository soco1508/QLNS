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

namespace QLNS_SGU.View
{
    public interface IBacForm : IView<IBacPresenter>
    {
        SaveFileDialog SaveFileDialog { get; set; }
        GridControl GCBac { get; set; }
        GridView GVBac { get; set; }
    }
    public partial class BacForm : XtraForm
    {
        public BacForm()
        {
            InitializeComponent();
        }

        #region Controls
        public SaveFileDialog SaveFileDialog { get => saveFileDialog1; set => saveFileDialog1 = value; }
        public GridControl GCBac { get => gcBac; set => gcBac = value; }
        public GridView GVBac { get => gvBac; set => gvBac = value; }
        #endregion

        public void Attach(IBacPresenter presenter)
        {
            btnRefresh.ItemClick += (s, e) => presenter.RefreshGrid();
            btnAdd.ItemClick += (s, e) => presenter.AddNewRow();
            btnSave.ItemClick += (s, e) => presenter.SaveData();
            btnDelete.ItemClick += (s, e) => presenter.DeleteRow();
            btnExportExcel.ItemClick += (s, e) => presenter.ExportExcel();
            gcBac.MouseDoubleClick += new MouseEventHandler(presenter.MouseDoubleClick);
            gvBac.HiddenEditor += new EventHandler(presenter.HiddenEditor);
            gvBac.InitNewRow += new InitNewRowEventHandler(presenter.InitNewRow);
            gvBac.KeyDown += new KeyEventHandler(presenter.EnterToCloseEditor);
            gvBac.CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler(presenter.RowIndicator);
        }
    }
}