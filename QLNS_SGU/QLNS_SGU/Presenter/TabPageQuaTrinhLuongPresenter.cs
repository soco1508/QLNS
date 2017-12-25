using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNS_SGU.View;
using DevExpress.XtraEditors;
using Model;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using System.IO;
using Model.Entities;
using Model.ObjectModels;

namespace QLNS_SGU.Presenter
{
    public interface ITabPageQuaTrinhLuongPresenter : IPresenterArgument
    {
        void LoadForm();
        void ClickRowAndShowInfo();
        void UploadFileToGoogleDrive();
        void DownloadFileToDevice();
        void Edit();
        void Refresh();
        void Add();
        void Delete();
        void BacChanged(object sender, EventArgs e);
        void ExportExcel();
    }
    public class TabPageQuaTrinhLuongPresenter : ITabPageQuaTrinhLuongPresenter
    {
        public static string _mavienchuc = "";
        public int _rowHandle = -1;
        private static CreateAndEditPersonInfoForm _createAndEditPersonInfoForm = new CreateAndEditPersonInfoForm();
        private TabPageQuaTrinhLuong _view;
        public object UI => _view;
        public TabPageQuaTrinhLuongPresenter(TabPageQuaTrinhLuong view) => _view = view;
        private string GenerateCode() => Guid.NewGuid().ToString("N");
        public void Initialize(string mavienchuc)
        {
            _view.Attach(this);
            _view.TXTMaVienChuc.Text = mavienchuc;
        }
        private void LoadGridTabPageQuaTrinhLuong(string mavienchuc)
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            List<QuaTrinhLuongForView> listQuaTrinhLuong = unitOfWorks.QuaTrinhLuongRepository.GetListQuaTrinhLuong(mavienchuc);
            _view.GCTabPageQuaTrinhLuong.DataSource = listQuaTrinhLuong;
        }
        private void LoadCbxData()
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            List<Ngach> listNgach = unitOfWorks.NgachRepository.GetListNgach().ToList();
            _view.CBXMaNgach.Properties.DataSource = listNgach;
            _view.CBXMaNgach.Properties.DisplayMember = "maNgach";
            _view.CBXMaNgach.Properties.ValueMember = "idNgach";
            _view.CBXMaNgach.Properties.DropDownRows = listNgach.Count;
            _view.CBXMaNgach.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("idNgach", ""));
            _view.CBXMaNgach.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("maNgach", ""));
            _view.CBXMaNgach.Properties.Columns[0].Visible = false;
            List<int> listBac = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            _view.CBXBac.Properties.DataSource = listBac;
            _view.CBXBac.Properties.DropDownRows = listBac.Count;
        }
        private void SetDefaultValueControl()
        {
            _view.CBXMaNgach.ErrorText = null;
            _view.CBXBac.ErrorText = null;
            _view.CBXMaNgach.EditValue = null;
            _view.CBXBac.EditValue = null;
            _view.DTNgayBatDau.EditValue = null;
            _view.DTNgayLenLuong.EditValue = null;
            _view.CHKDangHuongLuong.Checked = false;
            _view.TXTHeSoBac.EditValue = 0;
            _view.TXTLinkVanBanDinhKem.Text = "";
        }
        private void InsertData()
        {
            string mavienchuc = _view.TXTMaVienChuc.Text;
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            int idngach = Convert.ToInt32(_view.CBXMaNgach.EditValue);
            double hesobac = Convert.ToDouble(_view.TXTHeSoBac.EditValue);
            unitOfWorks.QuaTrinhLuongRepository.Insert(new QuaTrinhLuong
            {
                idVienChuc = unitOfWorks.VienChucRepository.GetIdVienChuc(mavienchuc),
                idBac = unitOfWorks.BacRepository.GetIdBac(hesobac, idngach),
                ngayBatDau = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayBatDau.Text),
                ngayLenLuong = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayLenLuong.Text),                
                dangHuongLuong = _view.CHKDangHuongLuong.Checked,
                linkVanBanDinhKem = _view.TXTLinkVanBanDinhKem.Text
            });
            unitOfWorks.Save();
            LoadGridTabPageQuaTrinhLuong(_view.TXTMaVienChuc.Text);
            XtraMessageBox.Show("Thêm dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MainPresenter.RefreshRightViewQuaTrinhLuong();
        }
        private void UpdateData()
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            int idquatrinhluong = Convert.ToInt32(_view.GVTabPageQuaTrinhLuong.GetFocusedRowCellDisplayText("Id"));
            DateTime? ngaybatdau = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayBatDau.Text);
            DateTime? ngaylenluong = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayLenLuong.Text);
            QuaTrinhLuong quaTrinhLuong = unitOfWorks.QuaTrinhLuongRepository.GetObjectById(idquatrinhluong);
            quaTrinhLuong.ngayBatDau = ngaybatdau;
            quaTrinhLuong.ngayLenLuong = ngaylenluong;
            quaTrinhLuong.dangHuongLuong = _view.CHKDangHuongLuong.Checked;
            quaTrinhLuong.linkVanBanDinhKem = _view.TXTLinkVanBanDinhKem.Text;
            unitOfWorks.Save();
            LoadGridTabPageQuaTrinhLuong(_view.TXTMaVienChuc.Text);
            XtraMessageBox.Show("Sửa dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MainPresenter.RefreshRightViewQuaTrinhLuong();
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
                        SplashScreenManager.ShowForm(_createAndEditPersonInfoForm, typeof(WaitForm1), true, true, false);
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

        public void Add()
        {
            if(_view.TXTMaVienChuc.Text != "" && _mavienchuc == "")
            {
                if (_view.CBXMaNgach.Text != "" && _view.CBXBac.Text != "")
                {
                    InsertData();
                }
                else
                {
                    _view.CBXMaNgach.ErrorText = "Vui lòng chọn ngạch.";
                    _view.CBXMaNgach.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                    _view.CBXBac.ErrorText = "Vui lòng chọn bậc.";
                    _view.CBXBac.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
            }
            else if (_view.TXTMaVienChuc.Text == "" && _mavienchuc != "")
            {
                _view.TXTMaVienChuc.Text = _mavienchuc;
                if (_view.CBXMaNgach.Text != "" && _view.CBXBac.Text != "")
                {
                    InsertData();
                }
                else
                {
                    _view.CBXMaNgach.ErrorText = "Vui lòng chọn ngạch.";
                    _view.CBXMaNgach.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                    _view.CBXBac.ErrorText = "Vui lòng chọn bậc.";
                    _view.CBXBac.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
            }
            else XtraMessageBox.Show("Vui lòng thêm thông tin viên chức trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ClickRowAndShowInfo()
        {
            _view.CBXMaNgach.ReadOnly = true;
            _view.CBXBac.ReadOnly = true;
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            int row_handle = _view.GVTabPageQuaTrinhLuong.FocusedRowHandle;
            if (row_handle >= 0)
            {
                string mangach = _view.GVTabPageQuaTrinhLuong.GetFocusedRowCellDisplayText("MaNgach").ToString();
                string hesobac = _view.GVTabPageQuaTrinhLuong.GetFocusedRowCellDisplayText("HeSoBac").ToString();
                bool danghuongluong = Convert.ToBoolean(_view.GVTabPageQuaTrinhLuong.GetRowCellValue(row_handle, "DangHuongLuong"));
                string linkvanbandinhkem = _view.GVTabPageQuaTrinhLuong.GetFocusedRowCellDisplayText("LinkVanBanDinhKem").ToString();
                _view.CBXMaNgach.EditValue = unitOfWorks.NgachRepository.GetIdNgach(mangach);
                _view.CBXBac.EditValue = Convert.ToInt32(_view.GVTabPageQuaTrinhLuong.GetFocusedRowCellDisplayText("Bac"));
                _view.DTNgayBatDau.EditValue = _view.GVTabPageQuaTrinhLuong.GetFocusedRowCellDisplayText("NgayBatDau");
                _view.DTNgayLenLuong.EditValue = _view.GVTabPageQuaTrinhLuong.GetFocusedRowCellDisplayText("NgayLenLuong");
                _view.TXTHeSoBac.EditValue = hesobac;
                _view.CHKDangHuongLuong.Checked = danghuongluong;
                _view.TXTLinkVanBanDinhKem.Text = linkvanbandinhkem;
            }
        }

        public void Delete()
        {
            try
            {
                UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
                int row_handle = _view.GVTabPageQuaTrinhLuong.FocusedRowHandle;
                if(row_handle >= 0)
                {
                    int id = Convert.ToInt32(_view.GVTabPageQuaTrinhLuong.GetFocusedRowCellDisplayText("Id"));
                    DialogResult dialogResult = XtraMessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        unitOfWorks.QuaTrinhLuongRepository.DeleteById(id);
                        unitOfWorks.Save();
                        _view.GVTabPageQuaTrinhLuong.DeleteRow(row_handle);
                        Refresh();
                        MainPresenter.RefreshRightViewQuaTrinhLuong();
                    }
                }
                else XtraMessageBox.Show("Vui lòng chọn dòng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
            catch
            {
                XtraMessageBox.Show("Không thể xóa. Quá trình lương này đang được sử dụng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DownloadFileToDevice()
        {
            string linkvanbandinhkem = _view.GVTabPageQuaTrinhLuong.GetFocusedRowCellDisplayText("LinkVanBanDinhKem").ToString().Trim();
            Download(linkvanbandinhkem);
        }

        public void Edit()
        {
            int row_handle = _view.GVTabPageQuaTrinhLuong.FocusedRowHandle;
            if (row_handle >= 0)
            {
                UpdateData();
            }
        }

        public void Refresh()
        {
            SetDefaultValueControl();
            _view.CBXMaNgach.ReadOnly = false;
            _view.CBXBac.ReadOnly = false;
        }

        public void UploadFileToGoogleDrive()
        {
            if (_view.GVTabPageQuaTrinhLuong.FocusedRowHandle >= 0)
            {
                string mavienchuc = _view.TXTMaVienChuc.Text;
                _view.OpenFileDialog.FileName = string.Empty;
                _view.OpenFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                if (_view.OpenFileDialog.ShowDialog() == DialogResult.Cancel) return;
                UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
                if (unitOfWorks.GoogleDriveFileRepository.InternetAvailable() == true)
                {
                    try
                    {
                        SplashScreenManager.ShowForm(_createAndEditPersonInfoForm, typeof(WaitForm1), false, false, true);
                        SplashScreenManager.Default.SetWaitFormCaption("Vui lòng chờ");
                        SplashScreenManager.Default.SetWaitFormDescription("Đang tải tập tin lên Google Drive....");
                        string code = GenerateCode(); // code xac dinh file duy nhat
                        string filename = _view.OpenFileDialog.FileName;
                        string[] temp = filename.Split('\\');
                        if (temp[temp.Length - 1].Contains(mavienchuc))
                        {
                            unitOfWorks.GoogleDriveFileRepository.UploadFile(filename);
                            string id = unitOfWorks.GoogleDriveFileRepository.GetIdDriveFile(mavienchuc, code);
                            _view.TXTLinkVanBanDinhKem.Text = "https://drive.google.com/open?id=" + id + "";
                        }
                        else
                        {
                            string[] split_filename = filename.Split('.');
                            string new_filename = split_filename[0] + "-" + mavienchuc + "-" + code + "." + split_filename[1];
                            FileInfo fileInfo = new FileInfo(filename);
                            fileInfo.MoveTo(new_filename);
                            unitOfWorks.GoogleDriveFileRepository.UploadFile(new_filename);
                            string id = unitOfWorks.GoogleDriveFileRepository.GetIdDriveFile(mavienchuc, code);
                            _view.TXTLinkVanBanDinhKem.Text = "https://drive.google.com/open?id=" + id + "";
                        }
                        SplashScreenManager.CloseForm();
                        LoadGridTabPageQuaTrinhLuong(mavienchuc);
                    }
                    catch
                    {
                        XtraMessageBox.Show("Tải lên thất bại. Vui lòng kiểm tra lại đường truyền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Tải lên thất bại. Vui lòng kiểm tra lại đường truyền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                XtraMessageBox.Show("Bạn chưa chọn dòng cần upload!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadForm()
        {
            LoadCbxData();
            string mavienchuc = _view.TXTMaVienChuc.Text;
            if (mavienchuc != "")
            {
                LoadGridTabPageQuaTrinhLuong(mavienchuc);
                if(_rowHandle >= 0)
                {
                    _view.GVTabPageQuaTrinhLuong.FocusedRowHandle = _rowHandle;
                    ClickRowAndShowInfo();
                }
            }
        }

        public void BacChanged(object sender, EventArgs e)
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            int bac = Convert.ToInt32(_view.CBXBac.EditValue);
            int idngach = Convert.ToInt32(_view.CBXMaNgach.EditValue);
            _view.TXTHeSoBac.EditValue = unitOfWorks.BacRepository.GetHeSoBac(idngach, bac);
        }

        public void ExportExcel()
        {
            _view.SaveFileDialog.FileName = string.Empty;
            _view.SaveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (_view.SaveFileDialog.ShowDialog() == DialogResult.Cancel) return;
            _view.GVTabPageQuaTrinhLuong.ExportToXlsx(_view.SaveFileDialog.FileName);
            XtraMessageBox.Show("Xuất Excel thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
