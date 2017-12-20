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
    public interface INganhDaoTaoForm : IView<INganhDaoTaoPresenter>
    {
        GridControl GCNganhDaoTao { get; set; }
        GridView GVNganhDaoTao { get; set; }
        SaveFileDialog SaveFileDialog { get; set; }
    }
    public partial class NganhDaoTaoForm : XtraForm, INganhDaoTaoForm
    {
        public NganhDaoTaoForm()
        {
            InitializeComponent();
        }

        public GridControl GCNganhDaoTao { get => gcNganhDaoTao; set => gcNganhDaoTao = value; }
        public GridView GVNganhDaoTao { get => gvNganhDaoTao; set => gvNganhDaoTao = value; }
        public SaveFileDialog SaveFileDialog { get => saveFileDialog1; set => saveFileDialog1 = value; }

        public void Attach(INganhDaoTaoPresenter presenter)
        {
            btnRefresh.ItemClick += (s, e) => presenter.RefreshGrid();
            btnAdd.ItemClick += (s, e) => presenter.AddNewRow();
            btnSave.ItemClick += (s, e) => presenter.SaveData();
            btnDelete.ItemClick += (s, e) => presenter.DeleteRow();
            btnExportExcel.ItemClick += (s, e) => presenter.ExportExcel();
            gcNganhDaoTao.MouseDoubleClick += new MouseEventHandler(presenter.MouseDoubleClick);
            gvNganhDaoTao.HiddenEditor += new EventHandler(presenter.HiddenEditor);
            gvNganhDaoTao.InitNewRow += new InitNewRowEventHandler(presenter.InitNewRow);
            gvNganhDaoTao.KeyDown += new KeyEventHandler(presenter.EnterToCloseEditor);
            gvNganhDaoTao.CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler(presenter.RowIndicator);
        }
    }
}