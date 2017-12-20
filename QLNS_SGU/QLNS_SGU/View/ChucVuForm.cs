﻿using System;
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
    public interface IChucVuForm : IView<IChucVuPresenter>
    {
        SaveFileDialog SaveFileDialog { get; set; }
        GridControl GCChucVu { get; set; }
        GridView GVChucVu { get; set; }
    }
    public partial class ChucVuForm : XtraForm
    {
        public ChucVuForm()
        {
            InitializeComponent();
        }

        #region Controls
        public SaveFileDialog SaveFileDialog { get => saveFileDialog1; set => saveFileDialog1 = value; }
        public GridControl GCChucVu { get => gcChucVu; set => gcChucVu = value; }
        public GridView GVChucVu { get => gvChucVu; set => gvChucVu = value; }
        #endregion

        public void Attach(IChucVuPresenter presenter)
        {
            btnRefresh.ItemClick += (s, e) => presenter.RefreshGrid();
            btnAdd.ItemClick += (s, e) => presenter.AddNewRow();
            btnSave.ItemClick += (s, e) => presenter.SaveData();
            btnDelete.ItemClick += (s, e) => presenter.DeleteRow();
            btnExportExcel.ItemClick += (s, e) => presenter.ExportExcel();
            gcChucVu.MouseDoubleClick += new MouseEventHandler(presenter.MouseDoubleClick);
            gvChucVu.HiddenEditor += new EventHandler(presenter.HiddenEditor);
            gvChucVu.InitNewRow += new InitNewRowEventHandler(presenter.InitNewRow);
            gvChucVu.KeyDown += new KeyEventHandler(presenter.EnterToCloseEditor);
            gvChucVu.CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler(presenter.RowIndicator);
        }
    }
}