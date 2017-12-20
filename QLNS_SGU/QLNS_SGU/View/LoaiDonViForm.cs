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
    public interface ILoaiDonViForm : IView<ILoaiDonViPresenter>
    {
        GridControl GCLoaiDonVi { get; set; }
        GridView GVLoaiDonVi { get; set; }
        SaveFileDialog SaveFileDialog { get; set; }
    }
    public partial class LoaiDonViForm : XtraForm, ILoaiDonViForm
    {
        public LoaiDonViForm()
        {
            InitializeComponent();
        }

        #region Controls
        public GridControl GCLoaiDonVi { get => gcLoaiDonVi; set => gcLoaiDonVi = value; }
        public GridView GVLoaiDonVi { get => gvLoaiDonVi; set => gvLoaiDonVi = value; }
        public SaveFileDialog SaveFileDialog { get => saveFileDialog1; set => saveFileDialog1 = value; }
        #endregion

        public void Attach(ILoaiDonViPresenter presenter)
        {
            btnRefresh.ItemClick += (s, e) => presenter.RefreshGrid();
            btnAdd.ItemClick += (s, e) => presenter.AddNewRow();
            btnSave.ItemClick += (s, e) => presenter.SaveData();
            btnDelete.ItemClick += (s, e) => presenter.DeleteRow();
            btnExportExcel.ItemClick += (s, e) => presenter.ExportExcel();
            gcLoaiDonVi.MouseDoubleClick += new MouseEventHandler(presenter.MouseDoubleClick);
            gvLoaiDonVi.HiddenEditor += new EventHandler(presenter.HiddenEditor);
            gvLoaiDonVi.InitNewRow += new InitNewRowEventHandler(presenter.InitNewRow);
            gvLoaiDonVi.KeyDown += new KeyEventHandler(presenter.EnterToCloseEditor);
            gvLoaiDonVi.CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler(presenter.RowIndicator);
        }
    }
}