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
using DevExpress.XtraBars;
using DevExpress.XtraLayout;
using DevExpress.XtraGrid.Views.Layout;
using DevExpress.XtraGrid.Views.Card;

namespace QLNS_SGU.View
{
    public interface IMainForm : IView<IMainPresenter>
    {
        SaveFileDialog SaveFileDialog { get; set; }
        LayoutControl LayoutControl { get; set; }
        GridControl GCMain { get; set; }
        GridView GVMain { get; set; }
        TextEdit TXTRowIndex { get; set; }
        TextEdit TXTRowIndexRightView { get; set; }
        PopupMenu PopupMenuGVMain { get; set; }
        PopupMenu PopupMenuGVQuaTrinhCongTac { get; set; }
        PopupMenu PopupMenuGVHopDong { get; set; }
        PopupMenu PopupMenuGVQuaTrinhLuong { get; set; }
        PopupMenu PopupMenuGVHocHamHocVi_DangHocNangCao_Nganh { get; set; }
        PopupMenu PopupMenuGVChungChi { get; set; }
        PopupMenu PopupMenuGVTrangThai { get; set; }
        SimpleLabelItem LBThongTinCaNhan { get; set; }
        SimpleLabelItem LBQuaTrinhCongTac { get; set; }
        SimpleLabelItem LBQuaTrinhLuong { get; set; }
        SimpleLabelItem LBChuyenMon { get; set; }
        SimpleLabelItem LBTrangThai { get; set; }
        SimpleLabelItem LBHoVaTen { get; set; }
        SimpleLabelItem LBChucVu { get; set; }
        SimpleLabelItem LBDonVi { get; set; }
        LayoutControlItem LCIThongTinCaNhan { get; set; }
        LayoutControlItem LCIQuaTrinhCongTac { get; set; }
        LayoutControlItem LCIHopDong { get; set; }
        LayoutControlItem LCIQuaTrinhLuong { get; set; }
        LayoutControlItem LCIHocHamHocVi_DangHocNangCao { get; set; }
        LayoutControlItem LCIChungChi { get; set; }
        LayoutControlItem LCITrangThai { get; set; }
        GridControl GCThongTinCaNhan { get; set; }
        LayoutView GVThongTinCaNhan { get; set; }
        GridControl GCQuaTrinhCongTac { get; set; }
        GridView GVQuaTrinhCongTac { get; set; }
        GridControl GCHopDong { get; set; }
        GridView GVHopDong { get; set; }
        GridControl GCQuaTrinhLuong { get; set; }
        GridView GVQuaTrinhLuong { get; set; }
        GridControl GCHocHamHocVi_DangHocNangCao_Nganh { get; set; }
        GridView GVHocHamHocVi_DangHocNangCao_Nganh { get; set; }
        GridControl GCChungChi { get; set; }
        GridView GVChungChi { get; set; }
        GridControl GCTrangThai { get; set; }
        GridView GVTrangThai { get; set; }
        PictureEdit PICVienChuc { get; set; }
    }
    public partial class MainForm : XtraForm, IMainForm
    {
        public MainForm()
        {
            InitializeComponent();
        }
#region Controls
        public SaveFileDialog SaveFileDialog { get => saveFileDialog1; set => saveFileDialog1 = value; }
        public GridControl GCMain { get => gcMain; set => gcMain = value; }
        public GridView GVMain { get => gvMain; set => gvMain = value; }
        public TextEdit TXTRowIndex { get => txtRowIndex; set => txtRowIndex = value; }
        public TextEdit TXTRowIndexRightView { get => txtRowIndexRightView; set => txtRowIndexRightView = value; }        
        public LayoutControl LayoutControl { get => layoutControl1; set => layoutControl1 = value; }
        public SimpleLabelItem LBThongTinCaNhan { get => lbThongTinCaNhan; set => lbThongTinCaNhan = value; }
        public SimpleLabelItem LBQuaTrinhCongTac { get => lbQuaTrinhCongTac; set => lbQuaTrinhCongTac = value; }
        public SimpleLabelItem LBQuaTrinhLuong { get => lbQuaTrinhLuong; set => lbQuaTrinhLuong = value; }
        public SimpleLabelItem LBChuyenMon { get => lbChuyenMon; set => lbChuyenMon = value; }
        public SimpleLabelItem LBTrangThai { get => lbTrangThai; set => lbTrangThai = value; }
        public SimpleLabelItem LBHoVaTen { get => lbHoTenVienChuc; set => lbHoTenVienChuc = value; }
        public SimpleLabelItem LBChucVu { get => lbChucVu; set => lbChucVu = value; }
        public SimpleLabelItem LBDonVi { get => lbDonVi; set => lbDonVi = value; }
        public LayoutControlItem LCIThongTinCaNhan { get => lciThongTinCaNhan; set => lciThongTinCaNhan = value; }
        public LayoutControlItem LCIQuaTrinhCongTac { get => lciQuaTrinhCongTac; set => lciQuaTrinhCongTac = value; }
        public LayoutControlItem LCIHopDong { get => lciHopDong; set => lciHopDong = value; }
        public LayoutControlItem LCIQuaTrinhLuong { get => lciQuaTrinhLuong; set => lciQuaTrinhLuong = value; }
        public LayoutControlItem LCIHocHamHocVi_DangHocNangCao { get => lciHocHamHocVi_DangHocNangCao; set => lciHocHamHocVi_DangHocNangCao = value; }
        public LayoutControlItem LCIChungChi { get => lciChungChi; set => lciChungChi = value; }
        public LayoutControlItem LCITrangThai { get => lciTrangThai; set => lciTrangThai = value; }
        public GridControl GCThongTinCaNhan { get => gcThongTinCaNhan; set => gcThongTinCaNhan = value; }
        public LayoutView GVThongTinCaNhan { get => layoutView1; set => layoutView1 = value; }
        public GridControl GCQuaTrinhCongTac { get => gcQuaTrinhCongTac; set => gcQuaTrinhCongTac = value; }
        public GridView GVQuaTrinhCongTac { get => gvQuaTrinhCongTac; set => gvQuaTrinhCongTac = value; }
        public GridControl GCHopDong { get => gcHopDong; set => gcHopDong = value; }
        public GridView GVHopDong { get => gvHopDong; set => gvHopDong = value; }       
        public GridControl GCQuaTrinhLuong { get => gcQuaTrinhLuong; set => gcQuaTrinhLuong = value; }
        public GridView GVQuaTrinhLuong { get => gvQuaTrinhLuong; set => gvQuaTrinhLuong = value; }
        public GridControl GCHocHamHocVi_DangHocNangCao_Nganh { get => gcHocHamHocVi_DangHocNangCao_Nganh; set => gcHocHamHocVi_DangHocNangCao_Nganh = value; }
        public GridView GVHocHamHocVi_DangHocNangCao_Nganh { get => gvHocHamHocVi_DangHocNangCao_Nganh; set => gvHocHamHocVi_DangHocNangCao_Nganh = value; }
        public GridControl GCChungChi { get => gcChungChi; set => gcChungChi = value; }
        public GridView GVChungChi { get => gvChungChi; set => gvChungChi = value; }
        public GridControl GCTrangThai { get => gcTrangThai; set => gcTrangThai = value; }
        public GridView GVTrangThai { get => gvTrangThai; set => gvTrangThai = value; }
        public PictureEdit PICVienChuc { get => picVienChuc; set => picVienChuc = value; }
        public PopupMenu PopupMenuGVMain { get => popupMenuGVMain; set => popupMenuGVMain = value; }
        public PopupMenu PopupMenuGVQuaTrinhCongTac { get => popupMenuGVQuaTrinhCongTac; set => popupMenuGVQuaTrinhCongTac = value; }
        public PopupMenu PopupMenuGVHopDong { get => popupMenuGVHopDong; set => popupMenuGVHopDong = value; }
        public PopupMenu PopupMenuGVQuaTrinhLuong { get => popupMenuGVQuaTrinhLuong; set => popupMenuGVQuaTrinhLuong = value; }
        public PopupMenu PopupMenuGVHocHamHocVi_DangHocNangCao_Nganh { get => popupMenuGVHocHamHocVi_DangHocNangCao_Nganh; set => popupMenuGVHocHamHocVi_DangHocNangCao_Nganh = value; }
        public PopupMenu PopupMenuGVChungChi { get => popupMenuGVChungChi; set => popupMenuGVChungChi = value; }
        public PopupMenu PopupMenuGVTrangThai { get => popupMenuGVTrangThai; set => popupMenuGVTrangThai = value; }
        #endregion
        public void Attach(IMainPresenter presenter)
        {
            //Load += (s, e) => presenter.LoadDataToMainGrid();
            gvMain.MouseDown += new MouseEventHandler(presenter.RightClickMainGrid);
            gvMain.Click += (s, e) => presenter.ClickRowAndChangeInfoAtRightLayout();
            gvMain.KeyDown += new KeyEventHandler(presenter.EventArrowKeysInGVMain);
            gvQuaTrinhCongTac.MouseDown += new MouseEventHandler(presenter.RightClickQuaTrinhCongTacGrid);
            gvQuaTrinhLuong.MouseDown += new MouseEventHandler(presenter.RightClickQuaTrinhLuongGrid);
            gvHopDong.MouseDown += new MouseEventHandler(presenter.RightClickHopDongGrid);
            gvHocHamHocVi_DangHocNangCao_Nganh.MouseDown += new MouseEventHandler(presenter.RightClickHocHamHocVi_DangHocNangCao_NganhGrid);
            gvChungChi.MouseDown += new MouseEventHandler(presenter.RightClickChungChiGrid);
            gvTrangThai.MouseDown += new MouseEventHandler(presenter.RightClickTrangThaiGrid);
            btnView.ItemClick += (s, e) => presenter.ViewPersonDetails();
            btnDownloadFileQuaTrinhCongTac.ItemClick += (s, e) => presenter.DownloadFileQuaTrinhCongTac();            
            btnDownloadFileHopDong.ItemClick += (s, e) => presenter.DownloadFileHopDong();
            btnDownloadFileQuaTrinhLuong.ItemClick += (s, e) => presenter.DownloadFileQuaTrinhLuong();
            btnDownloadFileHocHamHocVi.ItemClick += (s, e) => presenter.DownloadFileHocHamHocVi();
            btnDownloadFileHocNangCao.ItemClick += (s, e) => presenter.DownloadFileDangHocNangCao();
            btnDownloadFileNganh.ItemClick += (s, e) => presenter.DownloadFileNganh();
            btnDownloadFileChungChi.ItemClick += (s, e) => presenter.DownloadFileChungChi();
            btnDownloadFileTrangThai.ItemClick += (s, e) => presenter.DownloadFileTrangThai();
            lbThongTinCaNhan.Click += (s, e) => presenter.ClickLabelThongTinCaNhan();
            lbQuaTrinhCongTac.Click += (s, e) => presenter.ClickLabelQuaTrinhCongTac();
            lbQuaTrinhLuong.Click += (s, e) => presenter.ClickLabelQuaTrinhLuong();
            lbChuyenMon.Click += (s, e) => presenter.ClickLabelChuyenMon();
            lbTrangThai.Click += (s, e) => presenter.ClickLabelTrangThai();
            btnClosePersonDetails.Click += (s, e) => presenter.ClosePersonDetails();
            layoutView1.MouseWheel += new MouseEventHandler(presenter.MouseWheelGVThongTinCaNhan);
            btnOpenCloudStorage.Click += (s, e) => presenter.OpenStoreImage();
            btnEditInLayout.Click += (s, e) => presenter.OpenEditForm();
            btnEditInGrid.ItemClick += (s, e) => presenter.OpenEditForm();
            gvMain.CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler(presenter.RowIndicator);
            btnExportExcelMainGrid.ItemClick += (s, e) => presenter.ExportExcelMainGrid();
        }
    }
}