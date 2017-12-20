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
using QLNS_SGU.Presenter;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace QLNS_SGU.View
{
    public interface ILoaiNganhForm : IView<ILoaiNganhPresenter>
    {
        GridControl GCLoaiNganh { get; set; }
        GridView GVLoaiNganh { get; set; }
        SaveFileDialog SaveFileDialog { get; set; }
    }
    public partial class LoaiNganhForm : XtraForm, ILoaiNganhForm
    {
        public LoaiNganhForm()
        {
            InitializeComponent();
        }
#region Controls
        public GridControl GCLoaiNganh { get => gcLoaiNganh; set => gcLoaiNganh = value; }
        public GridView GVLoaiNganh { get => gvLoaiNganh; set => gvLoaiNganh = value; }
        public SaveFileDialog SaveFileDialog { get => saveFileDialog1; set => saveFileDialog1 = value; }
        #endregion
        public void Attach(ILoaiNganhPresenter presenter)
        {
            btnRefresh.ItemClick += (s, e) => presenter.RefreshGrid();
            btnAdd.ItemClick += (s, e) => presenter.AddNewRow();
            btnSave.ItemClick += (s, e) => presenter.SaveData();
            btnDelete.ItemClick += (s, e) => presenter.DeleteRow();
            btnExportExcel.ItemClick += (s, e) => presenter.ExportExcel();
            gcLoaiNganh.MouseDoubleClick += new MouseEventHandler(presenter.MouseDoubleClick);
            gvLoaiNganh.HiddenEditor += new EventHandler(presenter.HiddenEditor);
            gvLoaiNganh.InitNewRow += new InitNewRowEventHandler(presenter.InitNewRow);
            gvLoaiNganh.KeyDown += new KeyEventHandler(presenter.EnterToCloseEditor);
            gvLoaiNganh.CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler(presenter.RowIndicator);
        }
    }
}