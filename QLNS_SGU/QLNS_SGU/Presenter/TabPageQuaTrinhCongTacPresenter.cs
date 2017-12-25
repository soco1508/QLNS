using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNS_SGU.View;
using Model;
using Model.Entities;
using Model.ObjectModels;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using System.IO;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace QLNS_SGU.Presenter
{
    public interface ITabPageQuaTrinhCongTacPresenter : IPresenterArgument
    {
        void UploadFileToGoogleDriveHD();
        void DownloadFileToDeviceHD();
        void ClickRowAndShowInfoHD();
        void EditHD();
        void RefreshHD();
        void AddHD();
        void DeleteHD();
        void UploadFileToGoogleDriveCV();
        void DownloadFileToDeviceCV();
        void ClickRowAndShowInfoCV();
        void EditCV();
        void RefreshCV();
        void AddCV();
        void DeleteCV();
        void LoadForm();
        void ChucVuChanged(object sender, EventArgs e);
        void DonViChanged(object sender, EventArgs e);
        void ExportExcelCV();
        void ExportExcelHD();     
    }
    public class TabPageQuaTrinhCongTacPresenter : ITabPageQuaTrinhCongTacPresenter
    {
        public static string _mavienchuc = "";
        public int _rowHandle = -1;
        private TabPageQuaTrinhCongTac _view;
        private static CreateAndEditPersonInfoForm _createAndEditPersonInfoForm = new CreateAndEditPersonInfoForm();
        public object UI => _view;
        public TabPageQuaTrinhCongTacPresenter(TabPageQuaTrinhCongTac view) => _view = view;
        public void SelectTabHopDong() => _view.XtraTabControl.SelectedTabPageIndex = 1;
        public void SelectTabCongTac() => _view.XtraTabControl.SelectedTabPageIndex = 0;
        private string GenerateCode() => Guid.NewGuid().ToString("N");
        public void Initialize(string mavienchuc)
        {
            _view.Attach(this);
            _view.TXTMaVienChuc.Text = mavienchuc;
        }

        private void LoadGridTabPageQuaTrinhCongTac(string mavienchuc)
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            List<QuaTrinhCongTacForView> listQuaTrinhCongTac = unitOfWorks.ChucVuDonViVienChucRepository.GetListQuaTrinhCongTacForEdit(mavienchuc);
            _view.GCTabPageQuaTrinhCongTac.DataSource = listQuaTrinhCongTac;
        } 
        private void LoadGridTabPageHopDong(string mavienchuc)
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            List<HopDongForView> listHopDong = unitOfWorks.HopDongVienChucRepository.GetListHopDongVienChuc(mavienchuc);
            _view.GCTabPageHopDong.DataSource = listHopDong;
        }
        private void LoadCbxDataCV()
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            List<ChucVu> listChucVu = unitOfWorks.ChucVuRepository.GetListChucVu().ToList();
            _view.CBXChucVu.Properties.DataSource = listChucVu;
            _view.CBXChucVu.Properties.DisplayMember = "tenChucVu";
            _view.CBXChucVu.Properties.ValueMember = "idChucVu";
            _view.CBXChucVu.Properties.DropDownRows = listChucVu.Count;
            _view.CBXChucVu.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("idChucVu", ""));
            _view.CBXChucVu.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tenChucVu", ""));
            _view.CBXChucVu.Properties.Columns[0].Visible = false;
            List<DonVi> listDonVi = unitOfWorks.DonViRepository.GetListDonVi().ToList();
            _view.CBXDonVi.Properties.DataSource = listDonVi;
            _view.CBXDonVi.Properties.DisplayMember = "tenDonVi";
            _view.CBXDonVi.Properties.ValueMember = "idDonVi";
            _view.CBXDonVi.Properties.DropDownRows = listDonVi.Count;
            _view.CBXDonVi.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("idDonVi", ""));
            _view.CBXDonVi.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tenDonVi", ""));
            _view.CBXDonVi.Properties.Columns[0].Visible = false;
            List<ToChuyenMon> listToChuyenMon = unitOfWorks.ToChuyenMonRepository.GetListToChuyenMon().ToList();
            _view.CBXToChuyenMon.Properties.DataSource = listToChuyenMon;
            _view.CBXToChuyenMon.Properties.DisplayMember = "tenToChuyenMon";
            _view.CBXToChuyenMon.Properties.ValueMember = "idToChuyenMon";
            _view.CBXToChuyenMon.Properties.DropDownRows = listToChuyenMon.Count;
            _view.CBXToChuyenMon.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("idToChuyenMon", ""));
            _view.CBXToChuyenMon.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tenToChuyenMon", ""));
            _view.CBXToChuyenMon.Properties.Columns[0].Visible = false;
            _view.CBXToChuyenMon.EditValue = unitOfWorks.ToChuyenMonRepository.GetIdToChuyenMon("", "");
            _view.CBXToChuyenMon.ReadOnly = true;
            List<string> listPhanLoai = new List<string>() { "Chức vụ quá khứ", "Một chức vụ hiện tại", "Nhiều chức vụ hiện tại", "" };
            _view.CBXPhanLoai.Properties.DataSource = listPhanLoai;
            _view.CBXPhanLoai.Properties.DropDownRows = listPhanLoai.Count;
            List<string> listKiemNhiem = new List<string>() { "Có", "Không", "" };
            _view.CBXKiemNhiem.Properties.DataSource = listKiemNhiem;
            _view.CBXKiemNhiem.Properties.DropDownRows = listKiemNhiem.Count;
            List<string> listLoaiThayDoi = new List<string>() { "Chưa thay đổi", "Thay đổi chức vụ", "Thay đổi đơn vị", "Thay đổi tổ bộ môn", "" };
            _view.CBXLoaiThayDoi.Properties.DataSource = listLoaiThayDoi;
            _view.CBXLoaiThayDoi.Properties.DropDownRows = listLoaiThayDoi.Count;
            _view.CBXDonVi.EditValue = unitOfWorks.DonViRepository.GetIdDonVi("");           
        }
        private void LoadCbxDataHD()
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            List<LoaiHopDong> listLoaiHopDong = unitOfWorks.LoaiHopDongRepository.GetListLoaiHopDong().ToList();
            _view.CBXLoaiHopDong.Properties.DataSource = listLoaiHopDong;
            _view.CBXLoaiHopDong.Properties.DisplayMember = "tenLoaiHopDong";
            _view.CBXLoaiHopDong.Properties.ValueMember = "idLoaiHopDong";
            _view.CBXLoaiHopDong.Properties.DropDownRows = listLoaiHopDong.Count;
            _view.CBXLoaiHopDong.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("idLoaiHopDong", ""));
            _view.CBXLoaiHopDong.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tenLoaiHopDong", ""));
            _view.CBXLoaiHopDong.Properties.Columns[0].Visible = false;
        }
        private void SetDefaultValueControlCV()
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            _view.CBXChucVu.ErrorText = null;
            _view.DTNgayBatDau.ErrorText = null;
            _view.CBXChucVu.EditValue = null;
            _view.CBXDonVi.EditValue = unitOfWorks.DonViRepository.GetIdDonVi("");
            _view.CBXToChuyenMon.EditValue = unitOfWorks.ToChuyenMonRepository.GetIdToChuyenMon("", "");
            _view.CBXToChuyenMon.ReadOnly = true;
            _view.CBXPhanLoai.EditValue = "";
            _view.TXTHeSoChucVu.Text = "";
            _view.CBXKiemNhiem.EditValue = "";
            _view.TXTPhanLoaiCongTac.Text = "";
            _view.CBXLoaiThayDoi.EditValue = "";
            _view.DTNgayBatDau.EditValue = null;
            _view.DTNgayKetThuc.EditValue = null;
            _view.TXTLinkVanBanDinhKem.Text = "";
        }
        private void SetDefaultValueControlHD()
        {
            _view.CBXLoaiHopDong.ErrorText = null;
            _view.CBXLoaiHopDong.EditValue = null;
            _view.DTNgayBatDauHD.EditValue = null;
            _view.DTNgayKetThucHD.EditValue = null;
            _view.TXTGhiChuHD.Text = "";
            _view.TXTLinkVanBanDinhKemHD.Text = "";
        }
        private void InsertDataCV()
        {
            string mavienchuc = _view.TXTMaVienChuc.Text;
            string checkphanloaicongtac = _view.CBXPhanLoai.Text;
            string kiemnhiem = _view.CBXKiemNhiem.Text;
            string loaithaydoi = _view.CBXLoaiThayDoi.Text;
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            unitOfWorks.ChucVuDonViVienChucRepository.Insert(new ChucVuDonViVienChuc
            {
                idVienChuc = unitOfWorks.VienChucRepository.GetIdVienChuc(mavienchuc),
                idChucVu = Convert.ToInt32(_view.CBXChucVu.EditValue),
                idDonVi = Convert.ToInt32(_view.CBXDonVi.EditValue),
                idToChuyenMon = Convert.ToInt32(_view.CBXToChuyenMon.EditValue),
                checkPhanLoaiCongTac = unitOfWorks.ChucVuDonViVienChucRepository.HardCheckPhanLoaiCongTacToDatabase(checkphanloaicongtac),
                kiemNhiem = unitOfWorks.ChucVuDonViVienChucRepository.HardKiemNhiemToDatabase(kiemnhiem),
                loaiThayDoi = unitOfWorks.ChucVuDonViVienChucRepository.HardLoaiThayDoiToDatabase(loaithaydoi),
                linkVanBanDinhKem = _view.TXTLinkVanBanDinhKem.Text,
                ngayBatDau = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayBatDau.Text),
                ngayKetThuc = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayKetThuc.Text),
                phanLoaiCongTac = _view.TXTPhanLoaiCongTac.Text
            });
            unitOfWorks.Save();
            LoadGridTabPageQuaTrinhCongTac(_view.TXTMaVienChuc.Text);
            XtraMessageBox.Show("Thêm dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);          
            MainPresenter.RefreshMainGridAndRightViewQuaTrinhCongTac();
        }
        private void InsertDataHD()
        {
            string mavienchuc = _view.TXTMaVienChuc.Text;
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            unitOfWorks.HopDongVienChucRepository.Insert(new HopDongVienChuc
            {
                idVienChuc = unitOfWorks.VienChucRepository.GetIdVienChuc(mavienchuc),
                idLoaiHopDong = Convert.ToInt32(_view.CBXLoaiHopDong.EditValue),
                ngayBatDau = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayBatDauHD.Text),
                ngayKetThuc = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayKetThucHD.Text),
                moTa = _view.TXTGhiChuHD.Text,
                linkVanBanDinhKem = _view.TXTLinkVanBanDinhKemHD.Text
            });
            unitOfWorks.Save();
            LoadGridTabPageHopDong(_view.TXTMaVienChuc.Text);
            XtraMessageBox.Show("Thêm dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MainPresenter.SetValueLbHopDong();
        }
        private void UpdateDataCV()
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            string checkphanloaicongtac = _view.CBXPhanLoai.EditValue.ToString();
            string kiemnhiem = _view.CBXKiemNhiem.EditValue.ToString();
            string loaithaydoi = _view.CBXLoaiThayDoi.EditValue.ToString();
            int idchucvudonvivienchuc = Convert.ToInt32(_view.GVTabPageQuaTrinhCongTac.GetFocusedRowCellDisplayText("Id"));
            ChucVuDonViVienChuc chucVuDonViVienChuc = unitOfWorks.ChucVuDonViVienChucRepository.GetObjectById(idchucvudonvivienchuc);
            chucVuDonViVienChuc.idDonVi = Convert.ToInt32(_view.CBXDonVi.EditValue);
            chucVuDonViVienChuc.idToChuyenMon = Convert.ToInt32(_view.CBXToChuyenMon.EditValue);
            chucVuDonViVienChuc.checkPhanLoaiCongTac = unitOfWorks.ChucVuDonViVienChucRepository.HardCheckPhanLoaiCongTacToDatabase(checkphanloaicongtac);
            chucVuDonViVienChuc.kiemNhiem = unitOfWorks.ChucVuDonViVienChucRepository.HardKiemNhiemToDatabase(kiemnhiem);
            chucVuDonViVienChuc.phanLoaiCongTac = _view.TXTPhanLoaiCongTac.Text;
            chucVuDonViVienChuc.loaiThayDoi = unitOfWorks.ChucVuDonViVienChucRepository.HardLoaiThayDoiToDatabase(loaithaydoi);
            chucVuDonViVienChuc.ngayBatDau = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayBatDau.Text);
            chucVuDonViVienChuc.ngayKetThuc = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayKetThuc.Text);
            chucVuDonViVienChuc.linkVanBanDinhKem = _view.TXTLinkVanBanDinhKem.Text;
            unitOfWorks.Save();
            LoadGridTabPageQuaTrinhCongTac(_view.TXTMaVienChuc.Text);
            XtraMessageBox.Show("Sửa dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);            
            MainPresenter.RefreshMainGridAndRightViewQuaTrinhCongTac();
        }
        private void UpdateDataHD()
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            int idhopdongvienchuc = Convert.ToInt32(_view.GVTabPageHopDong.GetFocusedRowCellDisplayText("Id"));
            DateTime? ngaybatdau = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayBatDauHD.Text);
            DateTime? ngayketthuc = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayKetThucHD.Text);
            HopDongVienChuc hopDongVienChuc = unitOfWorks.HopDongVienChucRepository.GetObjectById(idhopdongvienchuc);
            hopDongVienChuc.ngayBatDau = ngaybatdau;
            hopDongVienChuc.ngayKetThuc = ngayketthuc;
            hopDongVienChuc.moTa = _view.TXTGhiChuHD.Text;
            hopDongVienChuc.linkVanBanDinhKem = _view.TXTLinkVanBanDinhKemHD.Text;
            unitOfWorks.Save();
            XtraMessageBox.Show("Sửa dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadGridTabPageHopDong(_view.TXTMaVienChuc.Text);
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
        private void ExportExcel(GridView gv)
        {
            _view.SaveFileDialog.FileName = string.Empty;
            _view.SaveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (_view.SaveFileDialog.ShowDialog() == DialogResult.Cancel) return;
            gv.ExportToXlsx(_view.SaveFileDialog.FileName);
            XtraMessageBox.Show("Xuất Excel thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void UploadFileToGoogleDriveCV()
        {
            if(_view.GVTabPageQuaTrinhCongTac.FocusedRowHandle >= 0)
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
                        LoadGridTabPageQuaTrinhCongTac(mavienchuc);
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

        public void DownloadFileToDeviceCV()
        {
            string linkvanbandinhkem = _view.GVTabPageQuaTrinhCongTac.GetFocusedRowCellDisplayText("LinkVanBanDinhKem").ToString().Trim();
            Download(linkvanbandinhkem);
        }

        public void ClickRowAndShowInfoCV()
        {
            _view.CBXChucVu.ReadOnly = true;
            _view.CBXToChuyenMon.ReadOnly = true;
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            int row_handle = _view.GVTabPageQuaTrinhCongTac.FocusedRowHandle;
            if (row_handle >= 0)
            {
                string chucvu = _view.GVTabPageQuaTrinhCongTac.GetFocusedRowCellDisplayText("ChucVu").ToString();
                string donvi = _view.GVTabPageQuaTrinhCongTac.GetFocusedRowCellDisplayText("DonVi").ToString();
                string tochuyenmon = _view.GVTabPageQuaTrinhCongTac.GetFocusedRowCellDisplayText("ToChuyenMon").ToString();
                string checkphanloaicongtac = _view.GVTabPageQuaTrinhCongTac.GetFocusedRowCellDisplayText("CheckPhanLoaiCongTac").ToString();
                string hesochucvu = _view.GVTabPageQuaTrinhCongTac.GetFocusedRowCellDisplayText("HeSoChucVu").ToString();
                string kiemnhiem = _view.GVTabPageQuaTrinhCongTac.GetFocusedRowCellDisplayText("KiemNhiem").ToString();
                string phanloaicongtac = _view.GVTabPageQuaTrinhCongTac.GetFocusedRowCellDisplayText("PhanLoaiCongTac").ToString();
                string loaithaydoi = _view.GVTabPageQuaTrinhCongTac.GetFocusedRowCellDisplayText("LoaiThayDoi").ToString();
                string linkvanbandinhkem = _view.GVTabPageQuaTrinhCongTac.GetFocusedRowCellDisplayText("LinkVanBanDinhKem").ToString();
                _view.CBXChucVu.EditValue = unitOfWorks.ChucVuRepository.GetIdChucVu(chucvu);
                _view.CBXDonVi.EditValue = unitOfWorks.DonViRepository.GetIdDonVi(donvi);
                _view.CBXToChuyenMon.EditValue = unitOfWorks.ToChuyenMonRepository.GetIdToChuyenMon(donvi, tochuyenmon);
                _view.CBXPhanLoai.EditValue = checkphanloaicongtac;
                _view.CBXKiemNhiem.EditValue = kiemnhiem;
                _view.CBXLoaiThayDoi.EditValue = loaithaydoi;
                _view.TXTHeSoChucVu.Text = hesochucvu;
                _view.TXTPhanLoaiCongTac.Text = phanloaicongtac;
                _view.DTNgayBatDau.EditValue = _view.GVTabPageQuaTrinhCongTac.GetFocusedRowCellDisplayText("NgayBatDau");
                _view.DTNgayKetThuc.EditValue = _view.GVTabPageQuaTrinhCongTac.GetFocusedRowCellDisplayText("NgayKetThuc");
                _view.TXTLinkVanBanDinhKem.Text = linkvanbandinhkem;                
            }
        }

        public void EditCV()
        {
            int row_handle = _view.GVTabPageQuaTrinhCongTac.FocusedRowHandle;
            if(row_handle >= 0)
            {
                if(_view.DTNgayBatDau.Text != "")
                {
                    UpdateDataCV();
                }
                else
                {
                    _view.DTNgayBatDau.ErrorText = "Vui lòng chọn ngày bắt đầu.";
                    _view.DTNgayBatDau.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
            }           
        }

        public void RefreshCV()
        {
            SetDefaultValueControlCV();
            _view.CBXChucVu.ReadOnly = false;
        }

        public void AddCV()
        {
            if(_view.TXTMaVienChuc.Text != "" && _mavienchuc == "")
            {
                if (_view.CBXChucVu.Text != "" && _view.DTNgayBatDau.Text != "")
                {
                    InsertDataCV();
                }
                if (_view.CBXChucVu.Text == "")
                {
                    _view.CBXChucVu.ErrorText = "Vui lòng chọn chức vụ.";
                    _view.CBXChucVu.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
                if(_view.DTNgayBatDau.Text == "")
                {
                    _view.DTNgayBatDau.ErrorText = "Vui lòng chọn ngày bắt đầu.";
                    _view.DTNgayBatDau.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
            }
            else if (_view.TXTMaVienChuc.Text == "" && _mavienchuc != "")
            {
                _view.TXTMaVienChuc.Text = _mavienchuc;
                if (_view.CBXChucVu.Text != "" && _view.DTNgayBatDau.Text != "")
                {
                    InsertDataCV();
                }
                if (_view.CBXChucVu.Text == "")
                {
                    _view.CBXChucVu.ErrorText = "Vui lòng chọn chức vụ.";
                    _view.CBXChucVu.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
                if (_view.DTNgayBatDau.Text == "")
                {
                    _view.DTNgayBatDau.ErrorText = "Vui lòng chọn ngày bắt đầu.";
                    _view.DTNgayBatDau.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
            }
            else XtraMessageBox.Show("Vui lòng thêm thông tin viên chức trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void DeleteCV()
        {
            try
            {
                UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
                int row_handle = _view.GVTabPageQuaTrinhCongTac.FocusedRowHandle;
                if(row_handle >= 0)
                {
                    int id = Convert.ToInt32(_view.GVTabPageQuaTrinhCongTac.GetFocusedRowCellDisplayText("Id"));
                    DialogResult dialogResult = XtraMessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        unitOfWorks.ChucVuDonViVienChucRepository.DeleteById(id);
                        unitOfWorks.Save();
                        _view.GVTabPageQuaTrinhCongTac.DeleteRow(row_handle);
                        RefreshCV();
                        MainPresenter.RefreshMainGridAndRightViewQuaTrinhCongTac();
                    }
                }
                else XtraMessageBox.Show("Vui lòng chọn dòng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
            catch
            {
                XtraMessageBox.Show("Không thể xóa. Công tác này đang được sử dụng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadForm()
        {
            LoadCbxDataCV();
            LoadCbxDataHD();
            _view.XtraTabControl.SelectedTabPageIndex = 0;
            string mavienchuc = _view.TXTMaVienChuc.Text;
            if(mavienchuc != "")
            {
                LoadGridTabPageQuaTrinhCongTac(mavienchuc);
                LoadGridTabPageHopDong(mavienchuc);
                if(_rowHandle >= 0)
                {
                    _view.GVTabPageQuaTrinhCongTac.FocusedRowHandle = _rowHandle;
                    ClickRowAndShowInfoCV();
                }                
            }
        }

        public void ChucVuChanged(object sender, EventArgs e)
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            int idchucvu = Convert.ToInt32(_view.CBXChucVu.EditValue);
            string hesochucvu = unitOfWorks.ChucVuRepository.GetHeSoChucVuByIdChucVu(idchucvu);
            _view.TXTHeSoChucVu.Text = hesochucvu;
        }

        public void DonViChanged(object sender, EventArgs e)
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            int iddonvi = Convert.ToInt32(_view.CBXDonVi.EditValue);
            _view.CBXToChuyenMon.Properties.DataSource = null;
            List<ToChuyenMon> listToChuyenMon = unitOfWorks.ToChuyenMonRepository.GetListToChuyenMonByDonVi(iddonvi);
            _view.CBXToChuyenMon.Properties.DataSource = listToChuyenMon;
            _view.CBXToChuyenMon.Properties.DisplayMember = "tenToChuyenMon";
            _view.CBXToChuyenMon.Properties.ValueMember = "idToChuyenMon";
            _view.CBXToChuyenMon.Properties.DropDownRows = listToChuyenMon.Count;
            _view.CBXToChuyenMon.Properties.Columns[0].Visible = false;
            _view.CBXToChuyenMon.ReadOnly = false;
        }

        public void ClickRowAndShowInfoHD()
        {
            _view.CBXLoaiHopDong.ReadOnly = true;
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            int row_handle = _view.GVTabPageHopDong.FocusedRowHandle;
            if (row_handle >= 0)
            {
                string loaihopdong = _view.GVTabPageHopDong.GetFocusedRowCellDisplayText("LoaiHopDong").ToString();
                string ghichu = _view.GVTabPageHopDong.GetFocusedRowCellDisplayText("GhiChu").ToString();
                string linkvanbandinhkem = _view.GVTabPageHopDong.GetFocusedRowCellDisplayText("LinkVanBanDinhKem").ToString();
                _view.CBXLoaiHopDong.EditValue = unitOfWorks.LoaiHopDongRepository.GetIdLoaiHopDong(loaihopdong);
                _view.DTNgayBatDauHD.EditValue = _view.GVTabPageHopDong.GetFocusedRowCellDisplayText("NgayBatDau");
                _view.DTNgayKetThucHD.EditValue = _view.GVTabPageHopDong.GetFocusedRowCellDisplayText("NgayKetThuc");
                _view.TXTGhiChuHD.Text = ghichu;
                _view.TXTLinkVanBanDinhKemHD.Text = linkvanbandinhkem;
            }
        }

        public void EditHD()
        {
            int row_handle = _view.GVTabPageHopDong.FocusedRowHandle;
            if (row_handle >= 0)
            {
                UpdateDataHD();
            }
        }

        public void RefreshHD()
        {
            SetDefaultValueControlHD();
            _view.CBXLoaiHopDong.ReadOnly = false;
        }

        public void AddHD()
        {
            if(_view.TXTMaVienChuc.Text != "" && _mavienchuc == "")
            {
                if (_view.CBXLoaiHopDong.Text != "")
                {
                    InsertDataHD();
                }
                else
                {
                    _view.CBXLoaiHopDong.ErrorText = "Vui lòng chọn hợp đồng.";
                    _view.CBXLoaiHopDong.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
            }
            else if (_view.TXTMaVienChuc.Text == "" && _mavienchuc != "")
            {
                _view.TXTMaVienChuc.Text = _mavienchuc;
                if (_view.CBXLoaiHopDong.Text != "")
                {
                    InsertDataHD();
                }
                else
                {
                    _view.CBXLoaiHopDong.ErrorText = "Vui lòng chọn hợp đồng.";
                    _view.CBXLoaiHopDong.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
            }
            else XtraMessageBox.Show("Vui lòng thêm thông tin viên chức trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void DeleteHD()
        {
            try
            {
                UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
                int row_handle = _view.GVTabPageHopDong.FocusedRowHandle;
                if(row_handle >= 0)
                {
                    int id = Convert.ToInt32(_view.GVTabPageHopDong.GetFocusedRowCellDisplayText("Id"));
                    DialogResult dialogResult = XtraMessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        unitOfWorks.HopDongVienChucRepository.DeleteById(id);
                        unitOfWorks.Save();
                        _view.GVTabPageHopDong.DeleteRow(row_handle);
                        RefreshHD();
                    }
                }
                else XtraMessageBox.Show("Vui lòng chọn dòng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
            catch
            {
                XtraMessageBox.Show("Không thể xóa. Hợp đồng này đang được sử dụng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UploadFileToGoogleDriveHD()
        {
            if (_view.GVTabPageHopDong.FocusedRowHandle >= 0)
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
                            _view.TXTLinkVanBanDinhKemHD.Text = "https://drive.google.com/open?id=" + id + "";
                        }
                        else
                        {
                            string[] split_filename = filename.Split('.');
                            string new_filename = split_filename[0] + "-" + mavienchuc + "-" + code + "." + split_filename[1];
                            FileInfo fileInfo = new FileInfo(filename);
                            fileInfo.MoveTo(new_filename);
                            unitOfWorks.GoogleDriveFileRepository.UploadFile(new_filename);
                            string id = unitOfWorks.GoogleDriveFileRepository.GetIdDriveFile(mavienchuc, code);
                            _view.TXTLinkVanBanDinhKemHD.Text = "https://drive.google.com/open?id=" + id + "";
                        }
                        SplashScreenManager.CloseForm();
                        LoadGridTabPageHopDong(mavienchuc);
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

        public void DownloadFileToDeviceHD()
        {
            string linkvanbandinhkem = _view.GVTabPageHopDong.GetFocusedRowCellDisplayText("LinkVanBanDinhKem").ToString().Trim();
            Download(linkvanbandinhkem);
        }

        public void ExportExcelCV() => ExportExcel(_view.GVTabPageQuaTrinhCongTac);

        public void ExportExcelHD() => ExportExcel(_view.GVTabPageHopDong);
    }
}
