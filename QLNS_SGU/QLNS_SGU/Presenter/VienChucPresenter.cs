using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using Model;
using Model.Entities;
using Model.ObjectModels;
using QLNS_SGU.View;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace QLNS_SGU.Presenter
{
    public interface IVienChucPresenter : IPresenter
    {
        void Refresh();
        void ExportExcel();
        void RowIndicator(object sender, RowIndicatorCustomDrawEventArgs e);
        void RightClickGrid(object sender, MouseEventArgs e);
        void OpenThongTinCaNhan();
        void OpenQuaTrinhCongTac();
        void OpenQuaTrinhLuong();
        void OpenHocHamHocVi();
        void OpenTrangThai();        
        void OpenHopDong();
        void OpenDangHocNangCao();
        void OpenNganh();
        void OpenChungChi();
        void Delete();
    }
    public class VienChucPresenter : IVienChucPresenter
    {
        private VienChucForm _view;
        private static int _rowIndex = -1;
        public object UI => _view;
        public VienChucPresenter(VienChucForm view) => _view = view;
        public void Initialize()
        {
            _view.Attach(this);
            _view.GVVienChuc.IndicatorWidth = 50;
            GetListVienChuc();
        }
        private void GetListVienChuc()
        {
            SplashScreenManager.ShowForm(_view, typeof(WaitForm1), true, true, false, 0);
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            BindingList<VienChucForGrid> list = new BindingList<VienChucForGrid>(unitOfWorks.VienChucRepository.GetListVienChucForGrid());
            _view.GCVienChuc.DataSource = list;
            SplashScreenManager.CloseForm(false);
        }
        public void ExportExcel()
        {
            _view.SaveFileDialog.FileName = string.Empty;
            _view.SaveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (_view.SaveFileDialog.ShowDialog() == DialogResult.Cancel) return;
            _view.GVVienChuc.ExportToXlsx(_view.SaveFileDialog.FileName);
        }
                
        public void LoadGridVienChuc()
        {
            GetListVienChuc();
        }

        public void Refresh() => GetListVienChuc();

        public void Delete()
        {         
            try
            {
                UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
                int row_handle = _view.GVVienChuc.FocusedRowHandle;
                if (row_handle >= 0)
                {
                    DialogResult dialogResult = XtraMessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int idvienchuc = Convert.ToInt32(_view.GVVienChuc.GetFocusedRowCellDisplayText("idVienChuc"));
                        unitOfWorks.VienChucRepository.DeleteById(idvienchuc);
                        unitOfWorks.Save();
                        _view.GVVienChuc.DeleteRow(row_handle);
                    }
                }
                else XtraMessageBox.Show("Vui lòng chọn dòng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                XtraMessageBox.Show("Không thể xóa. Tổ Chuyên Môn này đang được sử dụng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        public void RightClickGrid(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = _view.GVVienChuc.CalcHitInfo(e.Location);
                _rowIndex = hit.RowHandle;
                _view.PopupMenuVienChuc.ShowPopup(Cursor.Position);
            }
        }

        public void OpenThongTinCaNhan()
        {
            string mavienchuc = _view.GVVienChuc.GetRowCellValue(_rowIndex, "maVienChuc").ToString();
            var createAndEditPersonInfoPresenter = new CreateAndEditPersonInfoPresenter(new CreateAndEditPersonInfoForm());
            createAndEditPersonInfoPresenter.Initialize(mavienchuc, 0);
            Form f = (Form)createAndEditPersonInfoPresenter.UI;
            f.Height = Screen.PrimaryScreen.WorkingArea.Height;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
        }

        public void OpenQuaTrinhCongTac()
        {
            string mavienchuc = _view.GVVienChuc.GetRowCellValue(_rowIndex, "maVienChuc").ToString();
            var createAndEditPersonInfoPresenter = new CreateAndEditPersonInfoPresenter(new CreateAndEditPersonInfoForm());
            createAndEditPersonInfoPresenter.Initialize(mavienchuc, 1);
            Form f = (Form)createAndEditPersonInfoPresenter.UI;
            f.Height = Screen.PrimaryScreen.WorkingArea.Height;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
        }

        public void OpenQuaTrinhLuong()
        {
            string mavienchuc = _view.GVVienChuc.GetRowCellValue(_rowIndex, "maVienChuc").ToString();
            var createAndEditPersonInfoPresenter = new CreateAndEditPersonInfoPresenter(new CreateAndEditPersonInfoForm());
            createAndEditPersonInfoPresenter.Initialize(mavienchuc, 2);
            Form f = (Form)createAndEditPersonInfoPresenter.UI;
            f.Height = Screen.PrimaryScreen.WorkingArea.Height;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
        }

        public void OpenHocHamHocVi()
        {
            string mavienchuc = _view.GVVienChuc.GetRowCellValue(_rowIndex, "maVienChuc").ToString();
            var createAndEditPersonInfoPresenter = new CreateAndEditPersonInfoPresenter(new CreateAndEditPersonInfoForm());
            createAndEditPersonInfoPresenter.Initialize(mavienchuc, 3);
            Form f = (Form)createAndEditPersonInfoPresenter.UI;
            f.Height = Screen.PrimaryScreen.WorkingArea.Height;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
        }

        public void OpenTrangThai()
        {
            string mavienchuc = _view.GVVienChuc.GetRowCellValue(_rowIndex, "maVienChuc").ToString();
            var createAndEditPersonInfoPresenter = new CreateAndEditPersonInfoPresenter(new CreateAndEditPersonInfoForm());
            createAndEditPersonInfoPresenter.Initialize(mavienchuc, 4);
            Form f = (Form)createAndEditPersonInfoPresenter.UI;
            f.Height = Screen.PrimaryScreen.WorkingArea.Height;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
        }

        public void OpenHopDong()
        {
            string mavienchuc = _view.GVVienChuc.GetRowCellValue(_rowIndex, "maVienChuc").ToString();
            var createAndEditPersonInfoPresenter = new CreateAndEditPersonInfoPresenter(new CreateAndEditPersonInfoForm());
            createAndEditPersonInfoPresenter.Initialize(mavienchuc, 5);
            Form f = (Form)createAndEditPersonInfoPresenter.UI;
            f.Height = Screen.PrimaryScreen.WorkingArea.Height;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
        }

        public void OpenDangHocNangCao()
        {
            string mavienchuc = _view.GVVienChuc.GetRowCellValue(_rowIndex, "maVienChuc").ToString();
            var createAndEditPersonInfoPresenter = new CreateAndEditPersonInfoPresenter(new CreateAndEditPersonInfoForm());
            createAndEditPersonInfoPresenter.Initialize(mavienchuc, 6);
            Form f = (Form)createAndEditPersonInfoPresenter.UI;
            f.Height = Screen.PrimaryScreen.WorkingArea.Height;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
        }

        public void OpenNganh()
        {
            string mavienchuc = _view.GVVienChuc.GetRowCellValue(_rowIndex, "maVienChuc").ToString();
            var createAndEditPersonInfoPresenter = new CreateAndEditPersonInfoPresenter(new CreateAndEditPersonInfoForm());
            createAndEditPersonInfoPresenter.Initialize(mavienchuc, 7);
            Form f = (Form)createAndEditPersonInfoPresenter.UI;
            f.Height = Screen.PrimaryScreen.WorkingArea.Height;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
        }

        public void OpenChungChi()
        {
            string mavienchuc = _view.GVVienChuc.GetRowCellValue(_rowIndex, "maVienChuc").ToString();
            var createAndEditPersonInfoPresenter = new CreateAndEditPersonInfoPresenter(new CreateAndEditPersonInfoForm());
            createAndEditPersonInfoPresenter.Initialize(mavienchuc, 8);
            Form f = (Form)createAndEditPersonInfoPresenter.UI;
            f.Height = Screen.PrimaryScreen.WorkingArea.Height;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
        }        
    }
}
