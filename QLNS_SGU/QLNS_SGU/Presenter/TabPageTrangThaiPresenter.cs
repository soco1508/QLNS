using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Model;
using Model.Entities;
using Model.ObjectModels;
using QLNS_SGU.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNS_SGU.Presenter
{
    public interface ITabPageTrangThaiPresenter : IPresenterArgument
    {
        void ClickRowAndShowInfo();
        void UploadFileToGoogleDrive();
        void DownloadFileToDevice();
        void Edit();
        void Refresh();
        void Add();
        void Delete();
        void LoadForm();
        void ExportExcel();
    }
    public class TabPageTrangThaiPresenter : ITabPageTrangThaiPresenter
    {
        public static string _mavienchuc = "";
        public int _rowHandle = -1;
        private static CreateAndEditPersonInfoForm _createAndEditPersonInfoForm = new CreateAndEditPersonInfoForm();
        private TabPageTrangThai _view;
        public object UI => _view;
        public TabPageTrangThaiPresenter(TabPageTrangThai view) => _view = view;
        private string GenerateCode() => Guid.NewGuid().ToString("N");
        public void Initialize(string mavienchuc)
        {
            _view.Attach(this);
            _view.TXTMaVienChuc.Text = mavienchuc;
        }
        private void LoadGridTabPageTrangThai(string mavienchuc)
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            List<TrangThaiForView> listTrangThai = unitOfWorks.TrangThaiVienChucRepository.GetListTrangThaiVienChuc(mavienchuc);
            _view.GCTabPageTrangThai.DataSource = listTrangThai;
        }
        private void LoadCbxData()
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            List<TrangThai> listTrangThai = unitOfWorks.TrangThaiRepository.GetListTrangThai().ToList();
            _view.CBXTrangThai.Properties.DataSource = listTrangThai;
            _view.CBXTrangThai.Properties.DisplayMember = "tenTrangThai";
            _view.CBXTrangThai.Properties.ValueMember = "idTrangThai";
            _view.CBXTrangThai.Properties.DropDownRows = listTrangThai.Count;
            _view.CBXTrangThai.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("idTrangThai", ""));
            _view.CBXTrangThai.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tenTrangThai", ""));
            _view.CBXTrangThai.Properties.Columns[0].Visible = false;
        }
        private void SetDefaultValueControl()
        {
            _view.CBXTrangThai.ErrorText = null;
            _view.CBXTrangThai.EditValue = null;
            _view.DTNgayBatDau.EditValue = null;
            _view.DTNgayKetThuc.EditValue = null;
            _view.TXTMoTa.Text = "";
            _view.TXTDiaDiem.Text = "";
            _view.TXTLinkVanBanDinhKem.Text = "";
        }
        private void InsertData()
        {
            string mavienchuc = _view.TXTMaVienChuc.Text;
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            unitOfWorks.TrangThaiVienChucRepository.Insert(new TrangThaiVienChuc
            {
                idVienChuc = unitOfWorks.VienChucRepository.GetIdVienChuc(mavienchuc),
                idTrangThai = Convert.ToInt32(_view.CBXTrangThai.EditValue),
                ngayBatDau = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayBatDau.Text),
                ngayKetThuc = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayKetThuc.Text),
                moTa = _view.TXTMoTa.Text,
                diaDiem = _view.TXTDiaDiem.Text,
                linkVanBanDinhKem = _view.TXTLinkVanBanDinhKem.Text
            });
            unitOfWorks.Save();
            XtraMessageBox.Show("Thêm dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadGridTabPageTrangThai(_view.TXTMaVienChuc.Text);
        }
        private void UpdateData()
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            int idtrangthaivienchuc = Convert.ToInt32(_view.GVTabPageTrangThai.GetFocusedRowCellDisplayText("Id"));
            DateTime? ngaybatdau = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayBatDau.Text);
            DateTime? ngayketthuc = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayKetThuc.Text);
            TrangThaiVienChuc trangThaiVienChuc = unitOfWorks.TrangThaiVienChucRepository.GetObjectById(idtrangthaivienchuc);
            trangThaiVienChuc.moTa = _view.TXTMoTa.Text;
            trangThaiVienChuc.diaDiem = _view.TXTDiaDiem.Text;
            trangThaiVienChuc.ngayBatDau = ngaybatdau;
            trangThaiVienChuc.ngayKetThuc = ngayketthuc;
            trangThaiVienChuc.linkVanBanDinhKem = _view.TXTLinkVanBanDinhKem.Text;
            unitOfWorks.Save();
            XtraMessageBox.Show("Sửa dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadGridTabPageTrangThai(_view.TXTMaVienChuc.Text);
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
                if (_view.CBXTrangThai.Text != "")
                {
                    InsertData();
                }
                else
                {
                    _view.CBXTrangThai.ErrorText = "Vui lòng chọn trạng thái.";
                    _view.CBXTrangThai.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
            }
            else if(_view.TXTMaVienChuc.Text == "" && _mavienchuc != "")
            {
                _view.TXTMaVienChuc.Text = _mavienchuc;
                if (_view.CBXTrangThai.Text != "")
                {
                    InsertData();
                }
                else
                {
                    _view.CBXTrangThai.ErrorText = "Vui lòng chọn trạng thái.";
                    _view.CBXTrangThai.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
            }
            else XtraMessageBox.Show("Vui lòng thêm thông tin viên chức trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ClickRowAndShowInfo()
        {
            _view.CBXTrangThai.ReadOnly = true;
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            int row_handle = _view.GVTabPageTrangThai.FocusedRowHandle;
            if (row_handle >= 0)
            {
                string trangthai = _view.GVTabPageTrangThai.GetFocusedRowCellDisplayText("TrangThai").ToString();
                string ngaybatdau = _view.GVTabPageTrangThai.GetFocusedRowCellDisplayText("NgayBatDau");
                string ngayketthuc = _view.GVTabPageTrangThai.GetFocusedRowCellDisplayText("NgayKetThuc");
                string mota = _view.GVTabPageTrangThai.GetFocusedRowCellDisplayText("MoTa").ToString();
                string diadiem = _view.GVTabPageTrangThai.GetFocusedRowCellDisplayText("DiaDiem").ToString();
                string linkvanbandinhkem = _view.GVTabPageTrangThai.GetFocusedRowCellDisplayText("LinkVanBanDinhKem").ToString();
                _view.CBXTrangThai.EditValue = unitOfWorks.TrangThaiRepository.GetIdTrangThai(trangthai);
                _view.DTNgayBatDau.EditValue = _view.GVTabPageTrangThai.GetFocusedRowCellDisplayText("NgayBatDau");
                _view.DTNgayKetThuc.EditValue = _view.GVTabPageTrangThai.GetFocusedRowCellDisplayText("NgayKetThuc");
                _view.TXTMoTa.Text = mota;
                _view.TXTDiaDiem.Text = diadiem;
                _view.TXTLinkVanBanDinhKem.Text = linkvanbandinhkem;
            }
        }

        public void Delete()
        {
            try
            {
                UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
                int row_handle = _view.GVTabPageTrangThai.FocusedRowHandle;
                if(row_handle >= 0)
                {
                    int id = Convert.ToInt32(_view.GVTabPageTrangThai.GetFocusedRowCellDisplayText("Id"));
                    DialogResult dialogResult = XtraMessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        unitOfWorks.TrangThaiVienChucRepository.DeleteById(id);
                        unitOfWorks.Save();
                        _view.GVTabPageTrangThai.DeleteRow(row_handle);
                        Refresh();
                    }
                }
                else XtraMessageBox.Show("Vui lòng chọn dòng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
            catch
            {
                XtraMessageBox.Show("Không thể xóa. Trạng thái này đang được sử dụng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DownloadFileToDevice()
        {
            string linkvanbandinhkem = _view.GVTabPageTrangThai.GetFocusedRowCellDisplayText("LinkVanBanDinhKem").ToString().Trim();
            Download(linkvanbandinhkem);
        }

        public void Edit()
        {
            int row_handle = _view.GVTabPageTrangThai.FocusedRowHandle;
            if (row_handle >= 0)
            {
                UpdateData();
            }
        }     

        public void Refresh()
        {
            SetDefaultValueControl();
            _view.CBXTrangThai.ReadOnly = false;
        }

        public void UploadFileToGoogleDrive()
        {
            if (_view.GVTabPageTrangThai.FocusedRowHandle >= 0)
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
                        LoadGridTabPageTrangThai(mavienchuc);
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
                LoadGridTabPageTrangThai(mavienchuc);
                if(_rowHandle >= 0)
                {
                    _view.GVTabPageTrangThai.FocusedRowHandle = _rowHandle;
                    ClickRowAndShowInfo();
                }
            }
        }

        public void ExportExcel()
        {
            _view.SaveFileDialog.FileName = string.Empty;
            _view.SaveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (_view.SaveFileDialog.ShowDialog() == DialogResult.Cancel) return;
            _view.GVTabPageTrangThai.ExportToXlsx(_view.SaveFileDialog.FileName);
            XtraMessageBox.Show("Xuất Excel thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
