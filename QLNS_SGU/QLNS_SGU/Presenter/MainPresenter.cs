using System;
using System.Collections.Generic;
using QLNS_SGU.View;
using Model.Models;
using Model;
using Model.Entities;
using DevExpress.XtraSplashScreen;
using System.Windows.Forms;
using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Layout.ViewInfo;
using DevExpress.Utils;
using Model.ObjectModels;
using System.IO;
using System.ComponentModel;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace QLNS_SGU.Presenter
{
    public interface IMainPresenter : IPresenter
    {
        //void LoadDataToMainGrid();
        void ClickLabelChuyenMon();
        void ClickLabelQuaTrinhLuong();
        void ClickLabelQuaTrinhCongTac();
        void ClickLabelThongTinCaNhan();
        void RightClickMainGrid(object sender, MouseEventArgs e);
        void ViewPersonDetails();
        void ClosePersonDetails();
        void MouseWheelGVThongTinCaNhan(object sender, MouseEventArgs e);
        void ClickRowAndChangeInfoAtRightLayout();
        void OpenStoreImage();
        void EventArrowKeysInGVMain(object sender, KeyEventArgs e);
        void OpenEditForm();
        void OpenEditFormHasId();
        void RightClickQuaTrinhCongTacGrid(object sender, MouseEventArgs e);
        void RightClickQuaTrinhLuongGrid(object sender, MouseEventArgs e);
        void RightClickHocHamHocVi_DangHocNangCao_NganhGrid(object sender, MouseEventArgs e);
        void RightClickChungChiGrid(object sender, MouseEventArgs e);
        void RightClickTrangThaiGrid(object sender, MouseEventArgs e);
        void DownloadFileQuaTrinhCongTac();
        void DownloadFileQuaTrinhLuong();
        void DownloadFileHocHamHocVi();
        void DownloadFileDangHocNangCao();
        void DownloadFileChungChi();
        void DownloadFileTrangThai();
        void RowIndicator(object sender, RowIndicatorCustomDrawEventArgs e);
        void ExportExcelMainGrid();
        void ClickLabelTrangThai();
        void DownloadFileNganh();
        void LoadForm(object sender, EventArgs e);
        void ClosingForm(object sender, FormClosingEventArgs e);
        void ClickRowGVQuaTrinhCongTac();
        void ClickRowGVQuaTrinhLuong();
        void ClickRowGVHocHamHocVi_DangHocNangCao_Nganh();
        void ClickRowGVChungChi();
        void ClickRowGVTrangThai();
    }
    public class MainPresenter : IMainPresenter
    {
        bool clickGVQuaTrinhCongTac = false;
        bool clickGVQuaTrinhLuong = false;
        bool clickGVHocHamHocVi_DangHocNangCao_Nganh = false;
        bool clickGVChungChi = false;
        bool clickGVTrangThai = false;
        string filename = "c:\\layoutmainform.xml";
        private static MainForm _view;
        public MainPresenter(MainForm view) => _view = view;
        public object UI => _view;      
        public static void RefreshMainGridAndRightViewQuaTrinhCongTac()
        {
            LoadDataToMainGrid();
            int row_handle = Convert.ToInt32(_view.TXTRowIndex.Text);
            if (_view.LCIQuaTrinhCongTac.IsHidden == false)
            {
                ShowQuaTrinhCongTac(row_handle);
                SetValueLbChucVuAndLbDonVi(row_handle);
            }            
            _view.GVMain.FocusedRowHandle = row_handle;
        }
        public static void RefreshRightViewQuaTrinhLuong()
        {
            if(_view.LCIQuaTrinhLuong.IsHidden == false)
            {
                int row_handle = Convert.ToInt32(_view.TXTRowIndex.Text);
                ShowQuaTrinhLuong(row_handle);
            }
        }
        public static void RefreshRightViewTrangThai()
        {
            if (_view.LCITrangThai.IsHidden == false)
            {
                int row_handle = Convert.ToInt32(_view.TXTRowIndex.Text);
                ShowTrangThai(row_handle);
            }
        }
        public void Initialize()
        {
            _view.Attach(this);
            _view.GVMain.IndicatorWidth = 50;
            _view.LayoutControl.AllowCustomization = false;
            _view.LayoutControl.Hide();
            LoadDataToMainGrid();
        }
        public void LoadForm(object sender, EventArgs e)
        {
            _view.GCMain.ForceInitialize();
            _view.GCMain.MainView.RestoreLayoutFromXml(filename);
        }
        public void ClosingForm(object sender, FormClosingEventArgs e)
        {
            _view.GCMain.MainView.SaveLayoutToXml(filename);
        }
        public static void LoadDataToMainGrid()
        {
            SplashScreenManager.ShowForm(_view, typeof(WaitForm1), true, true, false, 0);
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            BindingList<GridViewMainData> listGridViewMainData = new BindingList<GridViewMainData>(unitOfWorks.GridViewDataRepository.LoadDataToGrid());
            _view.GCMain.DataSource = listGridViewMainData;
            SplashScreenManager.CloseForm(false);
        }       
        public static void SetValueLbHopDong()
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            int row_handle = Convert.ToInt32(_view.TXTRowIndex.Text);
            string mavienchuc = _view.GVMain.GetRowCellValue(row_handle, "MaVienChuc").ToString();
            string hopdong = unitOfWorks.HopDongVienChucRepository.GetLoaiHopDongVienChucForLbHopDong(mavienchuc);
            _view.LBHopDong.Text = "Hợp đồng " + hopdong + "   ";
        }
        private static void SetValueLbChucVuAndLbDonVi(int row_handle)
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            string chucvu = _view.GVMain.GetRowCellValue(row_handle, "ChucVu").ToString();
            string donvi = _view.GVMain.GetRowCellValue(row_handle, "DonVi").ToString();
            _view.LBChucVu.Text = chucvu;
            _view.LBDonVi.Text = donvi;
        }
        private void ChangeInfoAtRightLayout(int row_handle)
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            try
            {
                string mavienchuc = _view.GVMain.GetRowCellValue(row_handle, "MaVienChuc").ToString();
                string ho = _view.GVMain.GetRowCellValue(row_handle, "Ho").ToString();
                string ten = _view.GVMain.GetRowCellValue(row_handle, "Ten").ToString();             
                _view.LBHoVaTen.Text = ho + " " + ten;
                SetValueLbChucVuAndLbDonVi(row_handle);
                SetValueLbHopDong();
                byte[] img = unitOfWorks.ThongTinCaNhanRepository.GetImage(mavienchuc);
                if (img == null)
                {
                    _view.PICVienChuc.Image = null;
                }
                else
                {
                    MemoryStream ms = new MemoryStream(img);
                    _view.PICVienChuc.Image = Image.FromStream(ms);
                }
            }
            catch { }
        }
        private void ShowThongTinCaNhan(int row_handle)
        {            
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            try
            {
                string mavienchuc = _view.GVMain.GetRowCellValue(row_handle, "MaVienChuc").ToString();
                ThongTinCaNhan thongTinCaNhan = unitOfWorks.ThongTinCaNhanRepository.GetThongTinCaNhan(mavienchuc);
                List<ThongTinCaNhan> list = new List<ThongTinCaNhan>();
                list.Add(thongTinCaNhan);
                _view.GCThongTinCaNhan.DataSource = list;
            }
            catch { }          
        }
        private static void ShowQuaTrinhCongTac(int row_handle)
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            try
            {
                string mavienchuc = _view.GVMain.GetRowCellValue(row_handle, "MaVienChuc").ToString();
                List<QuaTrinhCongTacForView> listQuaTrinhCongTac = unitOfWorks.ChucVuDonViVienChucRepository.GetListQuaTrinhCongTacForView(mavienchuc);
                _view.GCQuaTrinhCongTac.DataSource = listQuaTrinhCongTac;
            }
            catch { }
        }
        private static void ShowQuaTrinhLuong(int row_handle)
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            try
            {
                string mavienchuc = _view.GVMain.GetRowCellValue(row_handle, "MaVienChuc").ToString();
                List<QuaTrinhLuongForView> listQuaTrinhLuongForView = unitOfWorks.QuaTrinhLuongRepository.GetListQuaTrinhLuong(mavienchuc);
                _view.GCQuaTrinhLuong.DataSource = listQuaTrinhLuongForView;
            }
            catch { }
        }
        public static void LoadGridHocHamHocVi_DangHocNangCao_Nganh()
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            int row_handle = Convert.ToInt32(_view.TXTRowIndex.Text);
            string mavienchuc = _view.GVMain.GetRowCellValue(row_handle, "MaVienChuc").ToString();
            List<HocHamHocVi_DanghocNangCao_NganhForView> listHocHamHocVi_DanghocNangCao = unitOfWorks.HocHamHocVi_DangHocNangCaoRepository.GetListHocHamHocVi_DanghocNangCao(mavienchuc);
            _view.GCHocHamHocVi_DangHocNangCao_Nganh.DataSource = listHocHamHocVi_DanghocNangCao;
        }
        public static void LoadGridChungChi()
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            int row_handle = Convert.ToInt32(_view.TXTRowIndex.Text);
            string mavienchuc = _view.GVMain.GetRowCellValue(row_handle, "MaVienChuc").ToString();
            List<ChungChiForView> listChungChiForView = unitOfWorks.ChungChiVienChucRepository.GetListChungChiVienChuc(mavienchuc);
            _view.GCChungChi.DataSource = listChungChiForView;
        }
        private void ShowChuyenMon()
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            try
            {               
                LoadGridHocHamHocVi_DangHocNangCao_Nganh();
                LoadGridChungChi();
            }
            catch { }
        }
        private static void ShowTrangThai(int row_handle)
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            try
            {
                string mavienchuc = _view.GVMain.GetRowCellValue(row_handle, "MaVienChuc").ToString();
                List<TrangThaiForView> listTrangThaiForView = unitOfWorks.TrangThaiVienChucRepository.GetListTrangThaiVienChuc(mavienchuc);
                _view.GCTrangThai.DataSource = listTrangThaiForView;
            }
            catch { }
        }
        private void Download(string linkvanbandinhkem)
        {
            if(linkvanbandinhkem != "")
            {
                string[] arr_linkvanbandinhkem = linkvanbandinhkem.Split('=');
                string idvanbandinhkem = arr_linkvanbandinhkem[1];
                UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
                if (unitOfWorks.GoogleDriveFileRepository.InternetAvailable() == true)
                {
                    try
                    {
                        SplashScreenManager.ShowForm(_view, typeof(WaitForm1), true, true, false);
                        SplashScreenManager.Default.SetWaitFormCaption("Vui lòng chờ");
                        SplashScreenManager.Default.SetWaitFormDescription("Đang tải tập tin xuống thiết bị....");
                        unitOfWorks.GoogleDriveFileRepository.DownloadFile(idvanbandinhkem);
                        SplashScreenManager.CloseForm();
                    }
                    catch
                    {
                        XtraMessageBox.Show("Tải xuống thất bại. Vui lòng kiểm tra lại đường truyền hoặc làm mới dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Tải xuống thất bại. Vui lòng kiểm tra lại đường truyền hoặc làm mới dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else XtraMessageBox.Show("Không có văn bản đính kèm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ExportExcelMainGrid()
        {
            _view.SaveFileDialog.Filter = "Excel |*.xlsx;*.xls";
            if (_view.SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                _view.GCMain.ExportToXlsx(_view.SaveFileDialog.FileName);
            }
        }

        public void OpenStoreImage()
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            int row_handle = Convert.ToInt32(_view.TXTRowIndex.Text);
            string mavienchuc = _view.GVMain.GetRowCellValue(row_handle, "MaVienChuc").ToString();
            var storeImagePresenter = new StoreImagePresenter(new StoreImageForm());
            storeImagePresenter.Initialize(mavienchuc);
            Form f = (Form)storeImagePresenter.UI;
            bool checkInternet = unitOfWorks.GoogleDriveFileRepository.InternetAvailable();
            if (checkInternet == true)
            {
                f.Show();
            }
            else
            {
                XtraMessageBox.Show("Kết nối đến Google Drive thất bại. Vui lòng kiểm tra lại đường truyền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        public void ClickRowAndChangeInfoAtRightLayout()
        {
            int row_handle = _view.GVMain.FocusedRowHandle;
            if(row_handle >= 0)
            {
                ChangeInfoAtRightLayout(row_handle);
                ShowThongTinCaNhan(row_handle);
                ShowQuaTrinhCongTac(row_handle);
                ShowQuaTrinhLuong(row_handle);
                ShowChuyenMon();
                ShowTrangThai(row_handle);
                _view.TXTRowIndex.Text = row_handle.ToString();
            }           
        }

        public void EventArrowKeysInGVMain(object sender, KeyEventArgs e)
        {
            int row_handle = _view.GVMain.FocusedRowHandle;
            if(row_handle >= 0)
            {
                switch (e.KeyCode)
                {
                    case Keys.Down:
                        int temp_row_handle = row_handle + 1;
                        ChangeInfoAtRightLayout(temp_row_handle);
                        ShowThongTinCaNhan(temp_row_handle);
                        ShowQuaTrinhCongTac(temp_row_handle);
                        ShowQuaTrinhLuong(temp_row_handle);
                        ShowChuyenMon();
                        ShowTrangThai(temp_row_handle);
                        _view.TXTRowIndex.Text = temp_row_handle.ToString();
                        break;
                    case Keys.Up:
                        int temp_row_handle1 = row_handle - 1;
                        ChangeInfoAtRightLayout(temp_row_handle1);
                        ShowThongTinCaNhan(temp_row_handle1);
                        ShowQuaTrinhCongTac(temp_row_handle1);
                        ShowQuaTrinhLuong(temp_row_handle1);
                        ShowChuyenMon();
                        ShowTrangThai(temp_row_handle1);
                        _view.TXTRowIndex.Text = temp_row_handle1.ToString();
                        break;
                }
            }            
        }

        public void ViewPersonDetails()
        {
            int row_handle = Convert.ToInt32(_view.TXTRowIndex.Text);
            if (row_handle >= 0)
            {
                SplashScreenManager.ShowForm(typeof(WaitForm1));
                _view.LCIThongTinCaNhan.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                _view.LCIQuaTrinhCongTac.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                _view.LCIQuaTrinhLuong.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                _view.LCIHocHamHocVi_DangHocNangCao.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                _view.LCIChungChi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                _view.LCITrangThai.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                _view.LBThongTinCaNhan.AppearanceItemCaption.ForeColor = Color.RoyalBlue;
                _view.LBQuaTrinhCongTac.AppearanceItemCaption.ForeColor = Color.DimGray;
                _view.LBQuaTrinhLuong.AppearanceItemCaption.ForeColor = Color.DimGray;
                _view.LBChuyenMon.AppearanceItemCaption.ForeColor = Color.DimGray;
                _view.LBTrangThai.AppearanceItemCaption.ForeColor = Color.DimGray;
                _view.LayoutControl.Show();
                ChangeInfoAtRightLayout(row_handle);
                ShowThongTinCaNhan(row_handle);
                SplashScreenManager.CloseForm();
            }
            else XtraMessageBox.Show("Vui lòng chọn dòng khác. Dòng này không có dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void ClickLabelThongTinCaNhan()
        {
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            _view.LCIThongTinCaNhan.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _view.LCIQuaTrinhCongTac.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LCIQuaTrinhLuong.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LCIHocHamHocVi_DangHocNangCao.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LCIChungChi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LCITrangThai.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LBThongTinCaNhan.AppearanceItemCaption.ForeColor = Color.RoyalBlue;
            _view.LBQuaTrinhCongTac.AppearanceItemCaption.ForeColor = Color.DimGray;
            _view.LBQuaTrinhLuong.AppearanceItemCaption.ForeColor = Color.DimGray;
            _view.LBChuyenMon.AppearanceItemCaption.ForeColor = Color.DimGray;
            _view.LBTrangThai.AppearanceItemCaption.ForeColor = Color.DimGray;
            SplashScreenManager.CloseForm();
        }

        public void ClickLabelQuaTrinhCongTac()
        {            
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            _view.LCIThongTinCaNhan.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LCIQuaTrinhCongTac.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _view.LCIQuaTrinhLuong.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LCIHocHamHocVi_DangHocNangCao.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LCIChungChi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LCITrangThai.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LBThongTinCaNhan.AppearanceItemCaption.ForeColor = Color.DimGray;
            _view.LBQuaTrinhCongTac.AppearanceItemCaption.ForeColor = Color.RoyalBlue;
            _view.LBQuaTrinhLuong.AppearanceItemCaption.ForeColor = Color.DimGray;
            _view.LBChuyenMon.AppearanceItemCaption.ForeColor = Color.DimGray;
            _view.LBTrangThai.AppearanceItemCaption.ForeColor = Color.DimGray;
            int row_handle = Convert.ToInt32(_view.TXTRowIndex.Text);
            ShowQuaTrinhCongTac(row_handle);
            SplashScreenManager.CloseForm();            
        }

        public void ClickLabelChuyenMon()
        {
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            _view.LCIThongTinCaNhan.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LCIQuaTrinhCongTac.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LCIQuaTrinhLuong.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LCIHocHamHocVi_DangHocNangCao.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _view.LCIChungChi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _view.LCITrangThai.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LBThongTinCaNhan.AppearanceItemCaption.ForeColor = Color.DimGray;
            _view.LBQuaTrinhCongTac.AppearanceItemCaption.ForeColor = Color.DimGray;
            _view.LBQuaTrinhLuong.AppearanceItemCaption.ForeColor = Color.DimGray;
            _view.LBChuyenMon.AppearanceItemCaption.ForeColor = Color.RoyalBlue;
            _view.LBTrangThai.AppearanceItemCaption.ForeColor = Color.DimGray;
            ShowChuyenMon();
            SplashScreenManager.CloseForm();           
        }

        public void ClickLabelQuaTrinhLuong()
        {
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            _view.LCIThongTinCaNhan.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LCIQuaTrinhCongTac.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LCIQuaTrinhLuong.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _view.LCIHocHamHocVi_DangHocNangCao.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LCIChungChi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LCITrangThai.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LBThongTinCaNhan.AppearanceItemCaption.ForeColor = Color.DimGray;
            _view.LBQuaTrinhCongTac.AppearanceItemCaption.ForeColor = Color.DimGray;
            _view.LBQuaTrinhLuong.AppearanceItemCaption.ForeColor = Color.RoyalBlue;
            _view.LBChuyenMon.AppearanceItemCaption.ForeColor = Color.DimGray;
            _view.LBTrangThai.AppearanceItemCaption.ForeColor = Color.DimGray;
            int row_handle = Convert.ToInt32(_view.TXTRowIndex.Text);
            ShowQuaTrinhLuong(row_handle);
            SplashScreenManager.CloseForm();
        }

        public void ClickLabelTrangThai()
        {
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            _view.LCIThongTinCaNhan.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LCIQuaTrinhCongTac.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LCIQuaTrinhLuong.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LCIHocHamHocVi_DangHocNangCao.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LCIChungChi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LCITrangThai.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _view.LBThongTinCaNhan.AppearanceItemCaption.ForeColor = Color.DimGray;
            _view.LBQuaTrinhCongTac.AppearanceItemCaption.ForeColor = Color.DimGray;
            _view.LBQuaTrinhLuong.AppearanceItemCaption.ForeColor = Color.DimGray;
            _view.LBChuyenMon.AppearanceItemCaption.ForeColor = Color.DimGray;
            _view.LBTrangThai.AppearanceItemCaption.ForeColor = Color.RoyalBlue;
            int row_handle = Convert.ToInt32(_view.TXTRowIndex.Text);
            ShowTrangThai(row_handle);
            SplashScreenManager.CloseForm();
        }

        public void RightClickMainGrid(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = _view.GVMain.CalcHitInfo(e.Location);
                int row_index = hit.RowHandle;
                _view.TXTRowIndex.Text = row_index.ToString();
                _view.PopupMenuGVMain.ShowPopup(Cursor.Position);
            }
        }

        public void ClosePersonDetails()
        {
            _view.LayoutControl.Hide();
        }        

        public void MouseWheelGVThongTinCaNhan(object sender, MouseEventArgs e)
        {
            if (!_view.GVThongTinCaNhan.PanModeActive) _view.GVThongTinCaNhan.PanModeSwitch();
            (_view.GVThongTinCaNhan.GetViewInfo() as LayoutViewInfo).PanCardArea(0, e.Delta);
            (e as DXMouseEventArgs).Handled = true;
            _view.GVThongTinCaNhan.Refresh();
            if (_view.GVThongTinCaNhan.PanModeActive) _view.GVThongTinCaNhan.PanModeSwitch();
        }
                
        private void OpenEditFormByOrder(string mavienchuc, int order, int row_handle, bool checkgrid)
        {
            var createAndEditPersonInfoPresenter = new CreateAndEditPersonInfoPresenter(new CreateAndEditPersonInfoForm());
            createAndEditPersonInfoPresenter.Initialize(mavienchuc, order);
            createAndEditPersonInfoPresenter._rowHandle = row_handle;
            createAndEditPersonInfoPresenter.checkGrid = checkgrid;
            Form f = (Form)createAndEditPersonInfoPresenter.UI;
            f.Height = Screen.PrimaryScreen.WorkingArea.Height;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
        }

        public void OpenEditFormHasId()
        {
            string mavienchuc = _view.GVMain.GetFocusedRowCellDisplayText("MaVienChuc").ToString();      
            if(_view.LBThongTinCaNhan.AppearanceItemCaption.ForeColor == Color.RoyalBlue)
            {
                OpenEditFormByOrder(mavienchuc, 0, -1, false);
            }
            if(_view.LBQuaTrinhCongTac.AppearanceItemCaption.ForeColor == Color.RoyalBlue)
            {
                if (clickGVQuaTrinhCongTac)
                {
                    int row_handle_grid = _view.GVQuaTrinhCongTac.FocusedRowHandle;
                    if (row_handle_grid >= 0)
                    {
                        OpenEditFormByOrder(mavienchuc, 1, row_handle_grid, false);
                        clickGVQuaTrinhCongTac = false;
                    }
                    else OpenEditFormByOrder(mavienchuc, 1, -1, false);
                }
                else OpenEditFormByOrder(mavienchuc, 1, -1, false);
            }
            if(_view.LBQuaTrinhLuong.AppearanceItemCaption.ForeColor == Color.RoyalBlue)
            {
                if (clickGVQuaTrinhLuong)
                {
                    int row_handle_grid = _view.GVQuaTrinhLuong.FocusedRowHandle;
                    if (row_handle_grid >= 0)
                    {
                        OpenEditFormByOrder(mavienchuc, 2, row_handle_grid, false);
                        clickGVQuaTrinhLuong = false;
                    }
                    else OpenEditFormByOrder(mavienchuc, 2, -1, false);
                }
                else OpenEditFormByOrder(mavienchuc, 2, -1, false);
            }
            if(_view.LBChuyenMon.AppearanceItemCaption.ForeColor == Color.RoyalBlue)
            {
                if (clickGVHocHamHocVi_DangHocNangCao_Nganh && clickGVChungChi == false)
                {
                    int row_handle_grid_HHHV = _view.GVHocHamHocVi_DangHocNangCao_Nganh.FocusedRowHandle;
                    if(row_handle_grid_HHHV >= 0)
                    {
                        OpenEditFormByOrder(mavienchuc, 3, row_handle_grid_HHHV, false);
                        clickGVHocHamHocVi_DangHocNangCao_Nganh = false;
                    }
                    else OpenEditFormByOrder(mavienchuc, 3, -1, false);
                }
                else if(clickGVHocHamHocVi_DangHocNangCao_Nganh == false && clickGVChungChi)
                {
                    int row_handle_grid_CC = _view.GVChungChi.FocusedRowHandle;
                    if(row_handle_grid_CC >= 0)
                    {
                        OpenEditFormByOrder(mavienchuc, 8, row_handle_grid_CC, true);
                        clickGVChungChi = false;
                    }
                    else OpenEditFormByOrder(mavienchuc, 3, -1, false);
                }
                else OpenEditFormByOrder(mavienchuc, 3, -1, false);
            }
            if(_view.LBTrangThai.AppearanceItemCaption.ForeColor == Color.RoyalBlue)
            {
                if (clickGVTrangThai)
                {
                    int row_handle_grid = _view.GVTrangThai.FocusedRowHandle;
                    if (row_handle_grid >= 0)
                    {
                        OpenEditFormByOrder(mavienchuc, 4, row_handle_grid, false);
                        clickGVTrangThai = false;
                    }
                    else OpenEditFormByOrder(mavienchuc, 4, -1, false);
                }
                else OpenEditFormByOrder(mavienchuc, 4, -1, false);
            }         
        }

        public void OpenEditForm()
        {           
            string mavienchuc = _view.GVMain.GetFocusedRowCellDisplayText("MaVienChuc").ToString();
            var createAndEditPersonInfoPresenter = new CreateAndEditPersonInfoPresenter(new CreateAndEditPersonInfoForm());
            createAndEditPersonInfoPresenter.Initialize(mavienchuc, 0);
            Form f = (Form)createAndEditPersonInfoPresenter.UI;
            f.Height = Screen.PrimaryScreen.WorkingArea.Height;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();           
        }

        public void RightClickQuaTrinhCongTacGrid(object sender, MouseEventArgs e)
        {
            GridView gridView = sender as GridView;
            if (e.Button == MouseButtons.Right)
            {
                var hit = gridView.CalcHitInfo(e.Location);
                int row_index = hit.RowHandle;
                _view.TXTRowIndexRightView.Text = row_index.ToString();
                _view.PopupMenuGVQuaTrinhCongTac.ShowPopup(Cursor.Position);
            }
        }
        public void RightClickQuaTrinhLuongGrid(object sender, MouseEventArgs e)
        {
            GridView gridView = sender as GridView;
            if (e.Button == MouseButtons.Right)
            {
                var hit = gridView.CalcHitInfo(e.Location);
                int row_index = hit.RowHandle;
                _view.TXTRowIndexRightView.Text = row_index.ToString();
                _view.PopupMenuGVQuaTrinhLuong.ShowPopup(Cursor.Position);
            }
        }
        public void RightClickHocHamHocVi_DangHocNangCao_NganhGrid(object sender, MouseEventArgs e)
        {
            GridView gridView = sender as GridView;
            if (e.Button == MouseButtons.Right)
            {
                var hit = gridView.CalcHitInfo(e.Location);
                int row_index = hit.RowHandle;
                _view.TXTRowIndexRightView.Text = row_index.ToString();
                _view.PopupMenuGVHocHamHocVi_DangHocNangCao_Nganh.ShowPopup(Cursor.Position);
            }
        }
        public void RightClickChungChiGrid(object sender, MouseEventArgs e)
        {
            GridView gridView = sender as GridView;
            if (e.Button == MouseButtons.Right)
            {
                var hit = gridView.CalcHitInfo(e.Location);
                int row_index = hit.RowHandle;
                _view.TXTRowIndexRightView.Text = row_index.ToString();
                _view.PopupMenuGVChungChi.ShowPopup(Cursor.Position);
            }
        }
        public void RightClickTrangThaiGrid(object sender, MouseEventArgs e)
        {
            GridView gridView = sender as GridView;
            if (e.Button == MouseButtons.Right)
            {
                var hit = gridView.CalcHitInfo(e.Location);
                int row_index = hit.RowHandle;
                _view.TXTRowIndexRightView.Text = row_index.ToString();
                _view.PopupMenuGVTrangThai.ShowPopup(Cursor.Position);
            }
        }

        public void DownloadFileQuaTrinhCongTac()
        {
            string linkvanbandinhkem = _view.GVQuaTrinhCongTac.GetFocusedRowCellDisplayText("LinkVanBanDinhKem").ToString().Trim();
            Download(linkvanbandinhkem);
        }        
        public void DownloadFileQuaTrinhLuong()
        {
            string linkvanbandinhkem = _view.GVQuaTrinhLuong.GetFocusedRowCellDisplayText("LinkVanBanDinhKem").ToString().Trim();
            Download(linkvanbandinhkem);
        }
        public void DownloadFileHocHamHocVi()
        {
            string linkvanbandinhkem = _view.GVHocHamHocVi_DangHocNangCao_Nganh.GetFocusedRowCellDisplayText("LinkVanBanDinhKem").ToString().Trim();
            Download(linkvanbandinhkem);
        }
        public void DownloadFileDangHocNangCao()
        {
            string linkvanbandinhkem = _view.GVHocHamHocVi_DangHocNangCao_Nganh.GetFocusedRowCellDisplayText("LinkAnhQuyetDinh").ToString().Trim();
            Download(linkvanbandinhkem);
        }
        public void DownloadFileNganh()
        {
            string linkvanbandinhkem = _view.GVHocHamHocVi_DangHocNangCao_Nganh.GetFocusedRowCellDisplayText("LinkQuyetDinhGiangDay").ToString().Trim();
            Download(linkvanbandinhkem);
        }
        public void DownloadFileChungChi()
        {
            string linkvanbandinhkem = _view.GVChungChi.GetFocusedRowCellDisplayText("LinkVanBanDinhKem").ToString().Trim();
            Download(linkvanbandinhkem);
        }
        public void DownloadFileTrangThai()
        {
            string linkvanbandinhkem = _view.GVTrangThai.GetFocusedRowCellDisplayText("LinkVanBanDinhKem").ToString().Trim();
            Download(linkvanbandinhkem);
        }

        public void ClickRowGVQuaTrinhCongTac() => clickGVQuaTrinhCongTac = true;
        public void ClickRowGVQuaTrinhLuong() => clickGVQuaTrinhLuong = true;
        public void ClickRowGVTrangThai() => clickGVTrangThai = true;
        public void ClickRowGVHocHamHocVi_DangHocNangCao_Nganh()
        {
            clickGVHocHamHocVi_DangHocNangCao_Nganh = true;
            clickGVChungChi = false;
        }
        public void ClickRowGVChungChi()
        {
            clickGVHocHamHocVi_DangHocNangCao_Nganh = false;
            clickGVChungChi = true;
        }
    }
}
