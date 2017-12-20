using Model;
using QLNS_SGU.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;
using Model.ObjectModels;
using DevExpress.XtraGrid.Views.Grid;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraSplashScreen;

namespace QLNS_SGU.Presenter
{
    public interface IExportDataPresenter : IPresenter
    {
        void ExportExcel();
        void CBXChanged(object sender, EventArgs e);
        void RowIndicatorQuaTrinhCongTac(object sender, RowIndicatorCustomDrawEventArgs e);
        void RowIndicatorHopDong(object sender, RowIndicatorCustomDrawEventArgs e);
        void RowIndicatorQuaTrinhLuong(object sender, RowIndicatorCustomDrawEventArgs e);
        void RowIndicatorTrangThai(object sender, RowIndicatorCustomDrawEventArgs e);
        void RowIndicatorDangHocNangCao(object sender, RowIndicatorCustomDrawEventArgs e);
        void RowIndicatorChungChi(object sender, RowIndicatorCustomDrawEventArgs e);
    }
    public class ExportDataPresenter : IExportDataPresenter
    {
        private ExportDataForm _view;
        public object UI => _view;
        public ExportDataPresenter(ExportDataForm view) => _view = view;
        public void Initialize()
        {
            _view.Attach(this);
            LoadCBXNhanh();
            _view.CBXNhanh.EditValue = null;
            _view.LCIQuaTrinhCongTac.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LCIHopDong.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LCIQuaTrinhLuong.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LCIDangHocNangCao.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LCIChungChi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _view.LCITrangThai.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }
        private void LoadCBXNhanh()
        {
            List<string> list = new List<string>() { "Quá trình công tác", "Hợp đồng", "Quá trình lương", "Học hàm - Học vị", "Đang học nâng cao", "Ngành", "Chứng chỉ", "Trạng thái" };
            RepositoryItemComboBox repositoryItem = _view.CBXNhanh.Edit as RepositoryItemComboBox;
            foreach(var row in list)
            {
                repositoryItem.Items.Add(row);
            }
        }
        private void LoadGridHopDong()
        {
            SplashScreenManager.ShowForm(_view, typeof(WaitForm1), true, true, false, 0);
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            List<HopDongForExport> list = unitOfWorks.HopDongVienChucRepository.GetListHopDongForExport();
            _view.GCHopDong.DataSource = list;
            _view.GVHopDong.IndicatorWidth = 50;
            SplashScreenManager.CloseForm(false);
        }
        private void LoadGridQuaTrinhCongTac()
        {
            SplashScreenManager.ShowForm(_view, typeof(WaitForm1), true, true, false, 0);
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            List<QuaTrinhCongTacForExport> list = unitOfWorks.ChucVuDonViVienChucRepository.GetListQuaTrinhCongTacForExport();
            _view.GCQuaTrinhCongTac.DataSource = list;
            _view.GVQuaTrinhCongTac.IndicatorWidth = 50;
            SplashScreenManager.CloseForm(false);
        }
        private void LoadGridQuaTrinhLuong()
        {
            SplashScreenManager.ShowForm(_view, typeof(WaitForm1), true, true, false, 0);
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            List<QuaTrinhLuongForExport> list = unitOfWorks.QuaTrinhLuongRepository.GetListQuaTrinhLuongForExport();
            _view.GCQuaTrinhLuong.DataSource = list;
            _view.GVQuaTrinhLuong.IndicatorWidth = 50;
            SplashScreenManager.CloseForm(false);
        }
        private void LoadGridDangHocNangCao()
        {
            SplashScreenManager.ShowForm(_view, typeof(WaitForm1), true, true, false, 0);
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            List<DangHocNangCaoForExport> list = unitOfWorks.DangHocNangCaoRepository.GetListDangHocNangCaoForExport();
            _view.GCDangHocNangCao.DataSource = list;
            _view.GVDangHocNangCao.IndicatorWidth = 50;
            SplashScreenManager.CloseForm(false);
        }
        private void LoadGridChungChi()
        {
            SplashScreenManager.ShowForm(_view, typeof(WaitForm1), true, true, false, 0);
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            List<ChungChiForExport> list = unitOfWorks.ChungChiVienChucRepository.GetListChungChiForExport();
            _view.GCChungChi.DataSource = list;
            _view.GVChungChi.IndicatorWidth = 50;
            SplashScreenManager.CloseForm(false);
        }
        private void LoadGridTrangThai()
        {
            SplashScreenManager.ShowForm(_view, typeof(WaitForm1), true, true, false, 0);
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            List<TrangThaiForExport> list = unitOfWorks.TrangThaiVienChucRepository.GetListTrangThaiForExport();
            _view.GCTrangThai.DataSource = list;
            _view.GVTrangThai.IndicatorWidth = 50;
            SplashScreenManager.CloseForm(false);
        }
        private void Export(GridView gv)
        {
            _view.SaveFileDialog.FileName = string.Empty;
            _view.SaveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (_view.SaveFileDialog.ShowDialog() == DialogResult.Cancel) return;
            gv.ExportToXlsx(_view.SaveFileDialog.FileName);
        }

        public void ExportExcel()
        {
            switch (_view.CBXNhanh.EditValue.ToString())
            {
                case "Quá trình công tác":
                    Export(_view.GVQuaTrinhCongTac);
                    break;
                case "Hợp đồng":
                    Export(_view.GVHopDong);
                    break;
                case "Quá trình lương":
                    Export(_view.GVQuaTrinhLuong);
                    break;
                case "Đang học nâng cao":
                    Export(_view.GVDangHocNangCao);
                    break;
                case "Chứng chỉ":
                    Export(_view.GVChungChi);
                    break;
                case "Trạng thái":
                    Export(_view.GVTrangThai);
                    break;
            }            
        }

        public void CBXChanged(object sender, EventArgs e)
        {
            switch (_view.CBXNhanh.EditValue.ToString())
            {
                case "Quá trình công tác":
                    _view.LCIQuaTrinhCongTac.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    _view.LCIHopDong.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    _view.LCIQuaTrinhLuong.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    _view.LCIDangHocNangCao.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    _view.LCIChungChi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    _view.LCITrangThai.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    if(_view.GCQuaTrinhCongTac.DataSource == null) { LoadGridQuaTrinhCongTac(); }                    
                    break;
                case "Hợp đồng":
                    _view.LCIQuaTrinhCongTac.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    _view.LCIHopDong.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    _view.LCIQuaTrinhLuong.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    _view.LCIDangHocNangCao.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    _view.LCIChungChi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    _view.LCITrangThai.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    if (_view.GCHopDong.DataSource == null) { LoadGridHopDong(); }                    
                    break;
                case "Quá trình lương":
                    _view.LCIQuaTrinhCongTac.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    _view.LCIHopDong.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    _view.LCIQuaTrinhLuong.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    _view.LCIDangHocNangCao.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    _view.LCIChungChi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    _view.LCITrangThai.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    if (_view.GCQuaTrinhLuong.DataSource == null) { LoadGridQuaTrinhLuong(); }
                    break;
                case "Đang học nâng cao":
                    _view.LCIQuaTrinhCongTac.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    _view.LCIHopDong.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    _view.LCIQuaTrinhLuong.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    _view.LCIDangHocNangCao.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    _view.LCIChungChi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    _view.LCITrangThai.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    if (_view.GCDangHocNangCao.DataSource == null) { LoadGridDangHocNangCao(); }
                    break;
                case "Chứng chỉ":
                    _view.LCIQuaTrinhCongTac.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    _view.LCIHopDong.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    _view.LCIQuaTrinhLuong.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    _view.LCIDangHocNangCao.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    _view.LCIChungChi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    _view.LCITrangThai.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    if (_view.GCChungChi.DataSource == null) { LoadGridChungChi(); }
                    break;
                case "Trạng thái":
                    _view.LCIQuaTrinhCongTac.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    _view.LCIHopDong.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    _view.LCIQuaTrinhLuong.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    _view.LCIDangHocNangCao.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    _view.LCIChungChi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    _view.LCITrangThai.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    if (_view.GCTrangThai.DataSource == null) { LoadGridTrangThai(); }
                    break;
            }
        }

        public void RowIndicatorHopDong(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }
        public void RowIndicatorQuaTrinhCongTac(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }
        public void RowIndicatorQuaTrinhLuong(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }
        public void RowIndicatorTrangThai(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }
        public void RowIndicatorDangHocNangCao(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }
        public void RowIndicatorChungChi(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }
    }
}
