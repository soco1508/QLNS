using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNS_SGU.View;
using Model.Models;
using Model;
using Model.Entities;
using DevExpress.XtraSplashScreen;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using DevExpress.XtraEditors;
using System.Net;
using DevExpress.Utils.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.EditForm.Helpers.Controls;
using DevExpress.XtraGrid.Views.Layout.ViewInfo;
using DevExpress.Utils;
using Model.ObjectModels;
using System.IO;
using System.ComponentModel;

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
        void RightClickQuaTrinhCongTacGrid(object sender, MouseEventArgs e);
        void RightClickHopDongGrid(object sender, MouseEventArgs e);
        void RightClickQuaTrinhLuongGrid(object sender, MouseEventArgs e);
        void RightClickHocHamHocVi_DangHocNangCao_NganhGrid(object sender, MouseEventArgs e);
        void RightClickChungChiGrid(object sender, MouseEventArgs e);
        void RightClickTrangThaiGrid(object sender, MouseEventArgs e);
        void DownloadFileQuaTrinhCongTac();
        void DownloadFileHopDong();
        void DownloadFileQuaTrinhLuong();
        void DownloadFileHocHamHocVi();
        void DownloadFileDangHocNangCao();
        void DownloadFileChungChi();
        void DownloadFileTrangThai();
        void RowIndicator(object sender, RowIndicatorCustomDrawEventArgs e);
        void ExportExcelMainGrid();
        void ClickLabelTrangThai();
        void DownloadFileNganh();
    }
    public class MainPresenter : IMainPresenter
    {
        private MainForm _view;
        public MainPresenter(MainForm view) => _view = view;
        public object UI => _view;       
        public void Initialize()
        {
            _view.Attach(this);
            _view.GVMain.IndicatorWidth = 50;
            _view.LayoutControl.AllowCustomization = false;
            _view.LayoutControl.Hide();
            LoadDataToMainGrid();
        }

        private void LoadDataToMainGrid()
        {
            SplashScreenManager.ShowForm(_view, typeof(WaitForm1), true, true, false, 0);
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            BindingList<GridViewMainData> listGridViewMainData = new BindingList<GridViewMainData>(unitOfWorks.GridViewDataRepository.LoadDataToGrid());
            _view.GCMain.DataSource = listGridViewMainData;
            SplashScreenManager.CloseForm(false);
        }              
        private void ChangeInfoAtRightLayout(int row_handle)
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            string mavienchuc = _view.GVMain.GetRowCellValue(row_handle, "MaVienChuc").ToString();
            string ho = _view.GVMain.GetRowCellValue(row_handle, "Ho").ToString();
            string ten = _view.GVMain.GetRowCellValue(row_handle, "Ten").ToString();
            string chucvu = _view.GVMain.GetRowCellValue(row_handle, "ChucVu").ToString();
            string donvi = _view.GVMain.GetRowCellValue(row_handle, "DonVi").ToString();
            _view.LBHoVaTen.Text = ho + " " + ten;
            _view.LBChucVu.Text = chucvu;
            _view.LBDonVi.Text = donvi;
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
        private void ShowThongTinCaNhan(int row_handle)
        {            
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            string mavienchuc = _view.GVMain.GetRowCellValue(row_handle, "MaVienChuc").ToString();
            ThongTinCaNhan thongTinCaNhan = unitOfWorks.ThongTinCaNhanRepository.GetThongTinCaNhan(mavienchuc);
            List<ThongTinCaNhan> list = new List<ThongTinCaNhan>();
            list.Add(thongTinCaNhan);
            _view.GCThongTinCaNhan.DataSource = list;
        }
        private void ShowQuaTrinhCongTac(int row_handle)
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            string mavienchuc = _view.GVMain.GetRowCellValue(row_handle, "MaVienChuc").ToString();
            List<QuaTrinhCongTacForView> listQuaTrinhCongTac = unitOfWorks.ChucVuDonViVienChucRepository.GetListQuaTrinhCongTac(mavienchuc);
            _view.GCQuaTrinhCongTac.DataSource = listQuaTrinhCongTac;
            List<HopDongForView> listHopDong = unitOfWorks.HopDongVienChucRepository.GetListHopDongVienChuc(mavienchuc);
            _view.GCHopDong.DataSource = listHopDong;
        }
        private void ShowQuaTrinhLuong(int row_handle)
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            string mavienchuc = _view.GVMain.GetRowCellValue(row_handle, "MaVienChuc").ToString();
            List<QuaTrinhLuongForView> listQuaTrinhLuongForView = unitOfWorks.QuaTrinhLuongRepository.GetListQuaTrinhLuong(mavienchuc);
            _view.GCQuaTrinhLuong.DataSource = listQuaTrinhLuongForView;
        }
        private void ShowChuyenMon(int row_handle)
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            string mavienchuc = _view.GVMain.GetRowCellValue(row_handle, "MaVienChuc").ToString();
            List<HocHamHocVi_DanghocNangCao_NganhForView> listHocHamHocVi_DanghocNangCao = unitOfWorks.HocHamHocVi_DangHocNangCaoRepository.GetListHocHamHocVi_DanghocNangCao(mavienchuc);
            _view.GCHocHamHocVi_DangHocNangCao_Nganh.DataSource = listHocHamHocVi_DanghocNangCao;
            List<ChungChiForView> listChungChiForView = unitOfWorks.ChungChiVienChucRepository.GetListChungChiVienChuc(mavienchuc);
            _view.GCChungChi.DataSource = listChungChiForView;
        }
        private void ShowTrangThai(int row_handle)
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            string mavienchuc = _view.GVMain.GetRowCellValue(row_handle, "MaVienChuc").ToString();
            List<TrangThaiForView> listTrangThaiForView = unitOfWorks.TrangThaiVienChucRepository.GetListTrangThaiVienChuc(mavienchuc);
            _view.GCTrangThai.DataSource = listTrangThaiForView;
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
                ShowChuyenMon(row_handle);
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
                        ShowChuyenMon(temp_row_handle);
                        ShowTrangThai(temp_row_handle);
                        _view.TXTRowIndex.Text = temp_row_handle.ToString();
                        break;
                    case Keys.Up:
                        int temp_row_handle1 = row_handle - 1;
                        ChangeInfoAtRightLayout(temp_row_handle1);
                        ShowThongTinCaNhan(temp_row_handle1);
                        ShowQuaTrinhCongTac(temp_row_handle1);
                        ShowQuaTrinhLuong(temp_row_handle1);
                        ShowChuyenMon(temp_row_handle1);
                        ShowTrangThai(temp_row_handle1);
                        _view.TXTRowIndex.Text = temp_row_handle1.ToString();
                        break;
                }
            }            
        }

        public void ViewPersonDetails()
        {
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            _view.LCIThongTinCaNhan.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _view.LCIQuaTrinhCongTac.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LCIHopDong.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LCIQuaTrinhLuong.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LCIHocHamHocVi_DangHocNangCao.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LCIChungChi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LCITrangThai.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LBThongTinCaNhan.AppearanceItemCaption.ForeColor = Color.RoyalBlue;
            _view.LayoutControl.Show();
            int row_handle = Convert.ToInt32(_view.TXTRowIndex.Text);
            ChangeInfoAtRightLayout(row_handle);
            ShowThongTinCaNhan(row_handle);
            SplashScreenManager.CloseForm();
        }

        public void ClickLabelThongTinCaNhan()
        {
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            _view.LCIThongTinCaNhan.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _view.LCIQuaTrinhCongTac.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LCIHopDong.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
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
            _view.LCIHopDong.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
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
            _view.LCIHopDong.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LCIQuaTrinhLuong.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LCIHocHamHocVi_DangHocNangCao.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _view.LCIChungChi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _view.LCITrangThai.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LBThongTinCaNhan.AppearanceItemCaption.ForeColor = Color.DimGray;
            _view.LBQuaTrinhCongTac.AppearanceItemCaption.ForeColor = Color.DimGray;
            _view.LBQuaTrinhLuong.AppearanceItemCaption.ForeColor = Color.DimGray;
            _view.LBChuyenMon.AppearanceItemCaption.ForeColor = Color.RoyalBlue;
            _view.LBTrangThai.AppearanceItemCaption.ForeColor = Color.DimGray;
            int row_handle = Convert.ToInt32(_view.TXTRowIndex.Text);
            ShowChuyenMon(row_handle);
            SplashScreenManager.CloseForm();           
        }

        public void ClickLabelQuaTrinhLuong()
        {
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            _view.LCIThongTinCaNhan.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LCIQuaTrinhCongTac.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LCIHopDong.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
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
            _view.LCIHopDong.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
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

        public void OpenEditForm()
        {
            int row_handle = Convert.ToInt32(_view.TXTRowIndex.Text);
            string mavienchuc = _view.GVMain.GetRowCellValue(row_handle, "MaVienChuc").ToString();
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
        public void RightClickHopDongGrid(object sender, MouseEventArgs e)
        {
            GridView gridView = sender as GridView;
            if (e.Button == MouseButtons.Right)
            {
                var hit = gridView.CalcHitInfo(e.Location);
                int row_index = hit.RowHandle;
                _view.TXTRowIndexRightView.Text = row_index.ToString();
                _view.PopupMenuGVHopDong.ShowPopup(Cursor.Position);
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
        public void DownloadFileHopDong()
        {
            string linkvanbandinhkem = _view.GVHopDong.GetFocusedRowCellDisplayText("LinkVanBanDinhKem").ToString().Trim();
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
    }
}
