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
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Repository;
using QLNS_SGU.Presenter;
using DevExpress.XtraLayout;

namespace QLNS_SGU.View
{
    public interface IExportDataForm : IView<IExportDataPresenter>
    {
        SaveFileDialog SaveFileDialog { get; set; }
        BarEditItem CBXNhanh { get; set; }

        GridControl GCQuaTrinhCongTac { get; set; }
        GridView GVQuaTrinhCongTac { get; set; }
        LayoutControlItem LCIQuaTrinhCongTac { get; set; }
        GridControl GCHopDong { get; set; }
        GridView GVHopDong { get; set; }
        LayoutControlItem LCIHopDong { get; set; }
        GridControl GCQuaTrinhLuong { get; set; }
        GridView GVQuaTrinhLuong { get; set; }
        LayoutControlItem LCIQuaTrinhLuong { get; set; }
        GridControl GCDangHocNangCao { get; set; }
        GridView GVDangHocNangCao { get; set; }
        LayoutControlItem LCIDangHocNangCao { get; set; }
        GridControl GCChungChi { get; set; }
        GridView GVChungChi { get; set; }
        LayoutControlItem LCIChungChi { get; set; }
        GridControl GCTrangThai { get; set; }
        GridView GVTrangThai { get; set; }
        LayoutControlItem LCITrangThai { get; set; }                        
    }
    public partial class ExportDataForm : XtraForm, IExportDataForm
    {
        public ExportDataForm()
        {
            InitializeComponent();
        }
        #region Controls
        public BarEditItem CBXNhanh { get => cbxNhanh1; set => cbxNhanh1 = value; }
        public SaveFileDialog SaveFileDialog { get => saveFileDialog1; set => saveFileDialog1 = value; }

        public GridControl GCQuaTrinhCongTac { get => gcQuaTrinhCongTac; set => gcQuaTrinhCongTac = value; }
        public GridView GVQuaTrinhCongTac { get => gvQuaTrinhCongTac; set => gvQuaTrinhCongTac = value; }
        public LayoutControlItem LCIQuaTrinhCongTac { get => lciQuaTrinhCongTac; set => lciQuaTrinhCongTac = value; }
        public GridControl GCHopDong { get => gcHopDong; set => gcHopDong = value; }
        public GridView GVHopDong { get => gvHopDong; set => gvHopDong = value; }       
        public LayoutControlItem LCIHopDong { get => lciHopDong; set => lciHopDong = value; }      
        public GridControl GCQuaTrinhLuong { get => gcQuaTrinhLuong; set => gcQuaTrinhLuong = value; }
        public GridView GVQuaTrinhLuong { get => gvQuaTrinhLuong; set => gvQuaTrinhLuong = value; }
        public LayoutControlItem LCIQuaTrinhLuong { get => lciQuaTrinhLuong; set => lciQuaTrinhLuong = value; }
        public GridControl GCTrangThai { get => gcTrangThai; set => gcTrangThai = value; }
        public GridView GVTrangThai { get => gvTrangThai; set => gvTrangThai = value; }
        public LayoutControlItem LCITrangThai { get => lciTrangThai; set => lciTrangThai = value; }
        public GridControl GCDangHocNangCao { get => gcDangHocNangCao; set => gcDangHocNangCao = value; }
        public GridView GVDangHocNangCao { get => gvDangHocNangCao; set => gvDangHocNangCao = value; }
        public LayoutControlItem LCIDangHocNangCao { get => lciDangHocNangCao; set => lciDangHocNangCao = value; }
        public GridControl GCChungChi { get => gcChungChi; set => gcChungChi = value; }
        public GridView GVChungChi { get => gvChungChi; set => gvChungChi = value; }
        public LayoutControlItem LCIChungChi { get => lciChungChi; set => lciChungChi = value; }
        #endregion
        public void Attach(IExportDataPresenter presenter)
        {
            btnExportExcel.ItemClick += (s, e) => presenter.ExportExcel();
            cbxNhanh1.EditValueChanged += new EventHandler(presenter.CBXChanged);
            gvHopDong.CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler(presenter.RowIndicatorHopDong);
            gvQuaTrinhCongTac.CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler(presenter.RowIndicatorQuaTrinhCongTac);
            gvQuaTrinhLuong.CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler(presenter.RowIndicatorQuaTrinhLuong);
            gvDangHocNangCao.CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler(presenter.RowIndicatorDangHocNangCao);
            gvChungChi.CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler(presenter.RowIndicatorChungChi);
            gvTrangThai.CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler(presenter.RowIndicatorTrangThai);
        }
    }
}