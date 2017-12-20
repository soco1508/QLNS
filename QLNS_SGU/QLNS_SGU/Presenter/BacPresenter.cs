using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraSplashScreen;
using Model;
using Model.Entities;
using QLNS_SGU.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNS_SGU.Presenter
{
    public interface IBacPresenter : IPresenter
    {
        void AddNewRow();
        void RefreshGrid();
        void SaveData();
        void DeleteRow();
        void ExportExcel();
        void MouseDoubleClick(object sender, MouseEventArgs e);
        void HiddenEditor(object sender, EventArgs e);
        void InitNewRow(object sender, InitNewRowEventArgs e);
        void EnterToCloseEditor(object sender, KeyEventArgs e);
        void RowIndicator(object sender, RowIndicatorCustomDrawEventArgs e);
    }
    public class BacPresenter : IBacPresenter
    {
        private BacForm _view;
        private bool checkNewRowExist = true;
        public object UI => _view;
        public BacPresenter(BacForm view) => _view = view;
        public void Initialize()
        {
            _view.Attach(this);
            _view.GVBac.IndicatorWidth = 50;
            LoadDataToGrid();
        }

        private void LoadDataToGrid()
        {
            SplashScreenManager.ShowForm(_view, typeof(WaitForm1), true, true, false, 0);
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            BindingList<Bac> listBac = new BindingList<Bac>(unitOfWorks.BacRepository.GetListBac());
            _view.GCBac.DataSource = listBac;
            RepositoryItemLookUpEdit mylookup = new RepositoryItemLookUpEdit();
            mylookup.DataSource = unitOfWorks.NgachRepository.GetListNgach();
            mylookup.ValueMember = "idNgach";
            mylookup.DisplayMember = "tenNgach";
            mylookup.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            mylookup.DropDownRows = unitOfWorks.NgachRepository.GetListNgach().Count;
            mylookup.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
            mylookup.ShowHeader = false;
            mylookup.ShowFooter = false;
            mylookup.AutoSearchColumnIndex = 1;
            mylookup.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.DoubleClick;
            _view.GVBac.Columns[3].ColumnEdit = mylookup;
            mylookup.PopulateColumns();
            mylookup.Columns[0].Visible = false;
            mylookup.Columns[2].Visible = false;
            mylookup.Columns[3].Visible = false;
            mylookup.Columns[4].Visible = false;
            mylookup.Columns[5].Visible = false;
            mylookup.Columns[6].Visible = false;
            SplashScreenManager.CloseForm(false);
            
        }

        public void AddNewRow()
        {
            if (checkNewRowExist == true)
            {
                _view.GVBac.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
                _view.GVBac.AddNewRow();
                checkNewRowExist = false;
            }
            else
            {
                _view.GVBac.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                LoadDataToGrid();
                checkNewRowExist = true;
            }
        }

        public void RefreshGrid()
        {
            LoadDataToGrid();
        }

        public void SaveData()
        {
            _view.GVBac.CloseEditor();
            _view.GVBac.UpdateCurrentRow();
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            int row_handle = _view.GVBac.FocusedRowHandle;
            int idRowFocused = Convert.ToInt32(_view.GVBac.GetFocusedRowCellDisplayText("idBac"));
            if (idRowFocused == 0)
            {
                int bac = Convert.ToInt32(_view.GVBac.GetFocusedRowCellDisplayText("tenBac"));
                double hesobac = Convert.ToDouble(_view.GVBac.GetFocusedRowCellDisplayText("heSoBac"));
                int idngach = Convert.ToInt32(_view.GVBac.GetRowCellValue(row_handle, "idNgach"));
                if (bac > 0 && idngach > 0)
                {
                    unitOfWorks.BacRepository.Create(bac, hesobac, idngach);
                    LoadDataToGrid();
                    XtraMessageBox.Show("Lưu dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _view.GVBac.MoveLast();
                }
                else if (bac == 0 && idngach > 0)
                {
                    _view.GVBac.DeleteRow(row_handle);
                    XtraMessageBox.Show("Bạn chưa chọn Bậc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    _view.GVBac.DeleteRow(row_handle);
                    XtraMessageBox.Show("Bạn chưa chọn Ngạch.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                int id = Convert.ToInt32(_view.GVBac.GetRowCellValue(row_handle, "idBac"));
                int bac = Convert.ToInt32(_view.GVBac.GetFocusedRowCellDisplayText("tenBac"));
                double hesobac = Convert.ToDouble(_view.GVBac.GetFocusedRowCellDisplayText("heSoBac"));
                int idngach = Convert.ToInt32(_view.GVBac.GetRowCellValue(row_handle, "idNgach"));
                if (bac > 0)
                {
                    unitOfWorks.BacRepository.Update(id, bac, hesobac,  idngach);
                    XtraMessageBox.Show("Lưu dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Bạn chưa chọn Bậc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoadDataToGrid();
                    _view.GVBac.SelectRow(row_handle);
                }
            }
        }

        public void DeleteRow()
        {
            try
            {
                UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
                int row_handle = _view.GVBac.FocusedRowHandle;
                if (row_handle >= 0)
                {
                    int id = Convert.ToInt32(_view.GVBac.GetFocusedRowCellDisplayText("idBac"));
                    DialogResult dialogResult = XtraMessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        unitOfWorks.BacRepository.DeleteById(id);
                        unitOfWorks.Save();
                        _view.GVBac.DeleteRow(row_handle);
                    }
                }
                else XtraMessageBox.Show("Vui lòng chọn dòng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            catch
            {
                XtraMessageBox.Show("Không thể xóa. Bậc này đang được sử dụng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExportExcel()
        {
            _view.SaveFileDialog.FileName = string.Empty;
            _view.SaveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (_view.SaveFileDialog.ShowDialog() == DialogResult.Cancel) return;
            _view.GVBac.ExportToXlsx(_view.SaveFileDialog.FileName);
        }

        public void MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GridHitInfo hinfo = _view.GVBac.CalcHitInfo(e.Location);
            if (hinfo.Column == _view.GVBac.Columns[1])
            {
                _view.GVBac.Columns[1].OptionsColumn.AllowEdit = true;
                _view.GVBac.ShowEditor();
            }
            else if (hinfo.Column == _view.GVBac.Columns[2])
            {
                _view.GVBac.Columns[2].OptionsColumn.AllowEdit = true;
                _view.GVBac.ShowEditor();
            }
        }

        public void HiddenEditor(object sender, EventArgs e)
        {
            _view.GVBac.Columns[1].OptionsColumn.AllowEdit = false;
            _view.GVBac.Columns[2].OptionsColumn.AllowEdit = false;
        }

        public void InitNewRow(object sender, InitNewRowEventArgs e)
        {
            GridView gridView = sender as GridView;
            gridView.SetRowCellValue(e.RowHandle, gridView.Columns[1], 1);
        }

        public void EnterToCloseEditor(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _view.GVBac.CloseEditor();
                _view.GVBac.UpdateCurrentRow();
                e.Handled = true;
            }
        }

        public void RowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }
    }
}
