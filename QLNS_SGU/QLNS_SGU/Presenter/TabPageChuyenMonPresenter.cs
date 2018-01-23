using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using Model;
using Model.Entities;
using Model.ObjectModels;
using QLNS_SGU.View;

namespace QLNS_SGU.Presenter
{
    public interface ITabPageChuyenMonPresenter : IPresenterArgument
    {
        void LoadForm();
        //HHHV
        void ClickRowAndShowInfoHHHV();
        void RefreshHHHV();
        void AddHHHV();
        void EditHHHV();
        void DeleteHHHV();
        void ExportExcelHHHV();
        void UploadFileToGoogleDriveHHHV();
        void DownloadFileToDeviceHHHV();
        void CbxNganhDaoTaoHHHVChanged(object sender, EventArgs e);
        //DHNC 
        void ClickRowAndShowInfoDHNC();
        void RefreshDHNC();
        void AddDHNC();
        void SaveDHNC();
        void DeleteDHNC();
        void ExportExcelDHNC();
        void UploadFileToGoogleDriveDHNC();
        void DownloadFileToDeviceDHNC();
        void SoQuyetDinhChanged(object sender, EventArgs e);
        void LoaiHocHamHocViDangHocNangCaoChanged(object sender, EventArgs e);
        void TenHocHamHocViDangHocNangCaoChanged(object sender, EventArgs e);
        void NgayBatDauDangHocNangCaoChanged(object sender, EventArgs e);
        void NgayKetThucDangHocNangCaoChanged(object sender, EventArgs e);
        void CoSoDaoTaoDangHocNangCaoChanged(object sender, EventArgs e);
        void NgonNguDaoTaoDangHocNangCaoChanged(object sender, EventArgs e);
        void HinhThucDaoTaoDangHocNangCaoChanged(object sender, EventArgs e);
        void NuocCapBangDangHocNangCaoChanged(object sender, EventArgs e);
        void LoaiDangHocNangCaoChanged(object sender, EventArgs e);
        void LinkAnhQuyetDinhChanged(object sender, EventArgs e);
        //Nganh
        void ClickRowAndShowInfoN();
        void RefreshN();
        void AddN();
        void EditN();
        void DeleteN();
        void ExportExcelN();
        void UploadFileToGoogleDriveN();
        void DownloadFileToDeviceN();
        void CbxNganhDaoTaoNChanged(object sender, EventArgs e);
        //ChungChi
        void ClickRowAndShowInfoCC();
        void RefreshCC();
        void AddCC();
        void SaveCC();
        void DeleteCC();
        void ExportExcelCC();
        void UploadFileToGoogleDriveCC();
        void DownloadFileToDeviceCC();
        void LoaiChungChiChanged(object sender, EventArgs e);
        void CapDoChungChiChanged(object sender, EventArgs e);
        void NgayCapChungChiChanged(object sender, EventArgs e);
        void GhiChuChungChiChanged(object sender, EventArgs e);
        void LinkVanBanDinhKemChungChiChanged(object sender, EventArgs e);        
    }
    public class TabPageChuyenMonPresenter : ITabPageChuyenMonPresenter
    {
        public static string maVienChucFromTabPageThongTinCaNhan = string.Empty;
        public int rowFocusFromCreateAndEditPersonalInfoForm = -1;
        public bool checkClickGridForLoadForm = false;
        private static CreateAndEditPersonInfoForm _createAndEditPersonInfoForm = new CreateAndEditPersonInfoForm();
        private TabPageChuyenMon _view;
        public object UI => _view;
        public TabPageChuyenMonPresenter(TabPageChuyenMon view) => _view = view;
        public void Initialize(string mavienchuc)
        {
            _view.Attach(this);
            _view.TXTMaVienChuc.Text = mavienchuc;
        }                      
        private string GenerateCode() => Guid.NewGuid().ToString("N");                             
        private void Download(string linkvanbandinhkem)
        {
            if (linkvanbandinhkem != string.Empty)
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

        public void LoadForm()
        {
            LoadCbxDataHHHV();
            LoadCbxDataDHNC();
            LoadCbxDataN();
            LoadCbxDataCC();
            _view.XtraTabControl.SelectedTabPageIndex = 0;
            string mavienchuc = _view.TXTMaVienChuc.Text;
            if (mavienchuc != string.Empty)
            {
                LoadGridTabPageHocHamHocVi(mavienchuc);
                LoadGridTabPageDangHocNangCao(mavienchuc);
                LoadGridTabPageNganh(mavienchuc);
                LoadGridTabPageChungChi(mavienchuc);
                if(rowFocusFromCreateAndEditPersonalInfoForm >= 0)
                {
                    if(checkClickGridForLoadForm == false)
                    {
                        _view.GVHocHamHocVi.FocusedRowHandle = rowFocusFromCreateAndEditPersonalInfoForm;
                        ClickRowAndShowInfoHHHV();
                    }
                    else
                    {
                        _view.GVChungChi.FocusedRowHandle = rowFocusFromCreateAndEditPersonalInfoForm;
                        ClickRowAndShowInfoCC();
                    }
                }
            }
        }
        #region HHHV        
        private void LoadCbxDataHHHV()
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            List<NganhDaoTao> listNganhDaoTao = unitOfWorks.NganhDaoTaoRepository.GetListNganhDaoTao().ToList();
            _view.CBXNganhDaoTaoHHHV.Properties.DataSource = listNganhDaoTao;
            _view.CBXNganhDaoTaoHHHV.Properties.DisplayMember = "tenNganhDaoTao";
            _view.CBXNganhDaoTaoHHHV.Properties.ValueMember = "idNganhDaoTao";
            _view.CBXNganhDaoTaoHHHV.Properties.DropDownRows = listNganhDaoTao.Count;
            _view.CBXNganhDaoTaoHHHV.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("idNganhDaoTao", string.Empty));
            _view.CBXNganhDaoTaoHHHV.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tenNganhDaoTao", string.Empty));
            _view.CBXNganhDaoTaoHHHV.Properties.Columns[0].Visible = false;
            List<ChuyenNganh> listChuyenNganh = unitOfWorks.ChuyenNganhRepository.GetListChuyenNganh().ToList();
            _view.CBXChuyenNganhHHHV.Properties.DataSource = listChuyenNganh;
            _view.CBXChuyenNganhHHHV.Properties.DisplayMember = "tenChuyenNganh";
            _view.CBXChuyenNganhHHHV.Properties.ValueMember = "idChuyenNganh";
            _view.CBXChuyenNganhHHHV.Properties.DropDownRows = listChuyenNganh.Count;
            _view.CBXChuyenNganhHHHV.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("idChuyenNganh", string.Empty));
            _view.CBXChuyenNganhHHHV.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tenChuyenNganh", string.Empty));
            _view.CBXChuyenNganhHHHV.Properties.Columns[0].Visible = false;
            List<LoaiHocHamHocVi> listLoaiHocHamHocVi = unitOfWorks.LoaiHocHamHocViRepository.GetListLoaiHocHamHocVi().ToList();
            _view.CBXLoaiHocHamHocViHHHV.Properties.DataSource = listLoaiHocHamHocVi;
            _view.CBXLoaiHocHamHocViHHHV.Properties.DisplayMember = "tenLoaiHocHamHocVi";
            _view.CBXLoaiHocHamHocViHHHV.Properties.ValueMember = "idLoaiHocHamHocVi";
            _view.CBXLoaiHocHamHocViHHHV.Properties.DropDownRows = listLoaiHocHamHocVi.Count;
            _view.CBXLoaiHocHamHocViHHHV.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("idLoaiHocHamHocVi", string.Empty));
            _view.CBXLoaiHocHamHocViHHHV.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tenLoaiHocHamHocVi", string.Empty));
            _view.CBXLoaiHocHamHocViHHHV.Properties.Columns[0].Visible = false;
        }
        private void SetDefaultValueControlHHHV()
        {
            _view.CBXLoaiHocHamHocViHHHV.ErrorText = string.Empty;
            _view.CBXNganhDaoTaoHHHV.ErrorText = string.Empty;
            _view.CBXChuyenNganhHHHV.ErrorText = string.Empty;
            _view.CBXLoaiHocHamHocViHHHV.Text = string.Empty;
            _view.CBXNganhDaoTaoHHHV.Text = string.Empty;
            _view.CBXChuyenNganhHHHV.Text = string.Empty;
            _view.TXTTenHocHamHocViHHHV.Text = string.Empty;
            _view.TXTCoSoDaoTaoHHHV.Text = string.Empty;
            _view.TXTNgonNguDaoTaoHHHV.Text = string.Empty;
            _view.TXTHinhThucDaoTaoHHHV.Text = string.Empty;
            _view.TXTNuocCapBangHHHV.Text = string.Empty;
            _view.DTNgayCapBang.Text = string.Empty;
            _view.TXTLinkVanBanDinhKemHHHV.Text = string.Empty;
        }
        private void LoadGridTabPageHocHamHocVi(string mavienchuc)
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            List<HocHamHocViForTabPageChuyenMon> listHocHamHocViForTabPageChuyenMon = unitOfWorks.HocHamHocViVienChucRepository.GetListHocHamHocViForTabPageChuyenMon(mavienchuc);
            _view.GCHocHamHocVi.DataSource = listHocHamHocViForTabPageChuyenMon;
        }
        private void InsertDataHHHV()
        {
            string mavienchuc = _view.TXTMaVienChuc.Text;
            int nganhdaotao = Convert.ToInt32(_view.CBXNganhDaoTaoHHHV.EditValue);
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            unitOfWorks.HocHamHocViVienChucRepository.Insert(new HocHamHocViVienChuc
            {
                idVienChuc = unitOfWorks.VienChucRepository.GetIdVienChuc(mavienchuc),
                idLoaiNganh = unitOfWorks.NganhDaoTaoRepository.GetIdLoaiNganhByIdNganhDaoTao(nganhdaotao),
                idLoaiHocHamHocVi = Convert.ToInt32(_view.CBXLoaiHocHamHocViHHHV.EditValue),
                idNganhDaoTao = nganhdaotao,
                idChuyenNganh = Convert.ToInt32(_view.CBXChuyenNganhHHHV.EditValue),
                bacHocHamHocVi = unitOfWorks.HocHamHocViVienChucRepository.HardCodeBacToDatabase(_view.CBXLoaiHocHamHocViHHHV.Text),
                tenHocHamHocVi = _view.TXTTenHocHamHocViHHHV.Text,
                coSoDaoTao = _view.TXTCoSoDaoTaoHHHV.Text,
                ngonNguDaoTao = _view.TXTNgonNguDaoTaoHHHV.Text,
                hinhThucDaoTao = _view.TXTHinhThucDaoTaoHHHV.Text,
                nuocCapBang = _view.TXTNuocCapBangHHHV.Text,
                ngayCapBang = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayCapBang.Text),
                linkVanBanDinhKem = _view.TXTLinkVanBanDinhKemHHHV.Text
            });
            unitOfWorks.Save();
            LoadGridTabPageHocHamHocVi(_view.TXTMaVienChuc.Text);
            XtraMessageBox.Show("Thêm dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MainPresenter.LoadGridHocHamHocViAtRightViewInMainForm();
        }
        private void UpdateDataHHHV()
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            int idhochamhocvi = Convert.ToInt32(_view.GVHocHamHocVi.GetFocusedRowCellDisplayText("Id"));
            HocHamHocViVienChuc hocHamHocViVienChuc = unitOfWorks.HocHamHocViVienChucRepository.GetObjectById(idhochamhocvi);
            hocHamHocViVienChuc.tenHocHamHocVi = _view.TXTTenHocHamHocViHHHV.Text;
            hocHamHocViVienChuc.coSoDaoTao = _view.TXTCoSoDaoTaoHHHV.Text;
            hocHamHocViVienChuc.ngonNguDaoTao = _view.TXTNgonNguDaoTaoHHHV.Text;
            hocHamHocViVienChuc.hinhThucDaoTao = _view.TXTHinhThucDaoTaoHHHV.Text;
            hocHamHocViVienChuc.nuocCapBang = _view.TXTNuocCapBangHHHV.Text;
            hocHamHocViVienChuc.ngayCapBang = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayCapBang.Text);
            hocHamHocViVienChuc.linkVanBanDinhKem = _view.TXTLinkVanBanDinhKemHHHV.Text;
            unitOfWorks.Save();
            LoadGridTabPageHocHamHocVi(_view.TXTMaVienChuc.Text);
            XtraMessageBox.Show("Sửa dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MainPresenter.LoadGridHocHamHocViAtRightViewInMainForm();
        }

        public void SelectTabHocHamHocVi() => _view.XtraTabControl.SelectedTabPageIndex = 0;

        public void ClickRowAndShowInfoHHHV()
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            int row_handle = _view.GVHocHamHocVi.FocusedRowHandle;
            if(row_handle >= 0)
            {
                string loaihochamhocvi = _view.GVHocHamHocVi.GetFocusedRowCellDisplayText("LoaiHocHamHocVi");
                string nganhdaotao = _view.GVHocHamHocVi.GetFocusedRowCellDisplayText("NganhDaoTao");
                string chuyennganh = _view.GVHocHamHocVi.GetFocusedRowCellDisplayText("ChuyenNganh");
                _view.CBXLoaiHocHamHocViHHHV.EditValue = unitOfWorks.LoaiHocHamHocViRepository.GetIdLoaiHocHamHocVi(loaihochamhocvi);
                _view.CBXNganhDaoTaoHHHV.EditValue = unitOfWorks.NganhDaoTaoRepository.GetIdNganhDaoTao(nganhdaotao);
                _view.CBXChuyenNganhHHHV.EditValue = unitOfWorks.ChuyenNganhRepository.GetIdChuyenNganh(chuyennganh);
                _view.TXTTenHocHamHocViHHHV.Text = _view.GVHocHamHocVi.GetFocusedRowCellDisplayText("TenHocHamHocVi");
                _view.TXTCoSoDaoTaoHHHV.Text = _view.GVHocHamHocVi.GetFocusedRowCellDisplayText("CoSoDaoTao");
                _view.TXTNgonNguDaoTaoHHHV.Text = _view.GVHocHamHocVi.GetFocusedRowCellDisplayText("NgonNguDaoTao");
                _view.TXTHinhThucDaoTaoHHHV.Text = _view.GVHocHamHocVi.GetFocusedRowCellDisplayText("HinhThucDaoTao");
                _view.TXTNuocCapBangHHHV.Text = _view.GVHocHamHocVi.GetFocusedRowCellDisplayText("NuocCapBang");
                _view.DTNgayCapBang.EditValue = _view.GVHocHamHocVi.GetFocusedRowCellDisplayText("NgayCapBang");
                _view.TXTLinkVanBanDinhKemHHHV.Text = _view.GVHocHamHocVi.GetFocusedRowCellDisplayText("LinkVanBanDinhKem");
            }
        }

        public void RefreshHHHV()
        {
            SetDefaultValueControlHHHV();
        }

        public void AddHHHV()
        {
            if (_view.TXTMaVienChuc.Text != string.Empty && maVienChucFromTabPageThongTinCaNhan == string.Empty)
            {
                if (_view.CBXLoaiHocHamHocViHHHV.Text != string.Empty && _view.CBXNganhDaoTaoHHHV.Text != string.Empty && _view.CBXChuyenNganhHHHV.Text != string.Empty)
                {
                    InsertDataHHHV();
                }
                if(_view.CBXLoaiHocHamHocViHHHV.Text == string.Empty)
                {
                    _view.CBXLoaiHocHamHocViHHHV.ErrorText = "Vui lòng chọn trình độ.";
                    _view.CBXLoaiHocHamHocViHHHV.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
                if (_view.CBXNganhDaoTaoHHHV.Text == string.Empty)
                {
                    _view.CBXNganhDaoTaoHHHV.ErrorText = "Vui lòng chọn ngành đào tạo.";
                    _view.CBXNganhDaoTaoHHHV.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
                if (_view.CBXChuyenNganhHHHV.Text == string.Empty)
                {
                    _view.CBXChuyenNganhHHHV.ErrorText = "Vui lòng chọn chuyên ngành.";
                    _view.CBXChuyenNganhHHHV.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
            }
            else if (_view.TXTMaVienChuc.Text == string.Empty && maVienChucFromTabPageThongTinCaNhan != string.Empty)
            {
                _view.TXTMaVienChuc.Text = maVienChucFromTabPageThongTinCaNhan;
                if (_view.CBXLoaiHocHamHocViHHHV.Text != string.Empty && _view.CBXNganhDaoTaoHHHV.Text != string.Empty && _view.CBXChuyenNganhHHHV.Text != string.Empty)
                {
                    InsertDataHHHV();
                }
                if (_view.CBXLoaiHocHamHocViHHHV.Text == string.Empty)
                {
                    _view.CBXLoaiHocHamHocViHHHV.ErrorText = "Vui lòng chọn trình độ.";
                    _view.CBXLoaiHocHamHocViHHHV.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
                if (_view.CBXNganhDaoTaoHHHV.Text == string.Empty)
                {
                    _view.CBXNganhDaoTaoHHHV.ErrorText = "Vui lòng chọn ngành đào tạo.";
                    _view.CBXNganhDaoTaoHHHV.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
                if (_view.CBXChuyenNganhHHHV.Text == string.Empty)
                {
                    _view.CBXChuyenNganhHHHV.ErrorText = "Vui lòng chọn chuyên ngành.";
                    _view.CBXChuyenNganhHHHV.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
            }
            else XtraMessageBox.Show("Vui lòng thêm thông tin viên chức trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void EditHHHV()
        {
            int row_handle = _view.GVHocHamHocVi.FocusedRowHandle;
            if (row_handle >= 0)
            {
                UpdateDataHHHV();
            }
        }

        public void DeleteHHHV()
        {
            try
            {
                UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
                int row_handle = _view.GVHocHamHocVi.FocusedRowHandle;
                if(row_handle >= 0)
                {
                    int id = Convert.ToInt32(_view.GVHocHamHocVi.GetFocusedRowCellDisplayText("Id"));
                    DialogResult dialogResult = XtraMessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        unitOfWorks.HocHamHocViVienChucRepository.DeleteById(id);
                        unitOfWorks.Save();
                        _view.GVHocHamHocVi.DeleteRow(row_handle);
                        RefreshHHHV();
                        MainPresenter.LoadGridHocHamHocViAtRightViewInMainForm();
                    }
                }
                else XtraMessageBox.Show("Vui lòng chọn dòng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                XtraMessageBox.Show("Không thể xóa. Công tác này đang được sử dụng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExportExcelHHHV() => ExportExcel(_view.GVHocHamHocVi);

        public void UploadFileToGoogleDriveHHHV()
        {
            if (_view.GVHocHamHocVi.FocusedRowHandle >= 0)
            {
                string mavienchuc = _view.TXTMaVienChuc.Text;
                _view.OpenFileDialog.FileName = string.Empty;
                _view.OpenFileDialog.Filter = "Pdf Files|*.pdf";
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
                            _view.TXTLinkVanBanDinhKemHHHV.Text = "https://drive.google.com/open?id=" + id + "";
                        }
                        else
                        {
                            string[] split_filename = filename.Split('.');
                            string new_filename = split_filename[0] + "-" + mavienchuc + "-" + code + "." + split_filename[1];
                            FileInfo fileInfo = new FileInfo(filename);
                            fileInfo.MoveTo(new_filename);
                            unitOfWorks.GoogleDriveFileRepository.UploadFile(new_filename);
                            string id = unitOfWorks.GoogleDriveFileRepository.GetIdDriveFile(mavienchuc, code);
                            _view.TXTLinkVanBanDinhKemHHHV.Text = "https://drive.google.com/open?id=" + id + "";
                        }
                        SplashScreenManager.CloseForm();
                        LoadGridTabPageHocHamHocVi(mavienchuc);
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

        public void DownloadFileToDeviceHHHV()
        {
            string linkvanbandinhkem = _view.GVHocHamHocVi.GetFocusedRowCellDisplayText("LinkVanBanDinhKem").ToString().Trim();
            Download(linkvanbandinhkem);
        }

        public void CbxNganhDaoTaoHHHVChanged(object sender, EventArgs e)
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            int idnganhdaotao = Convert.ToInt32(_view.CBXNganhDaoTaoHHHV.EditValue);
            List<ChuyenNganh> list = unitOfWorks.ChuyenNganhRepository.GetListChuyenNganhByIdNganhDaoTao(idnganhdaotao);
            _view.CBXChuyenNganhHHHV.Properties.DataSource = list;
            _view.CBXChuyenNganhHHHV.Properties.DisplayMember = "tenChuyenNganh";
            _view.CBXChuyenNganhHHHV.Properties.ValueMember = "idChuyenNganh";
            _view.CBXChuyenNganhHHHV.Properties.DropDownRows = list.Count;
            _view.CBXChuyenNganhHHHV.Properties.Columns[0].Visible = false;
        }
        #endregion
        #region DHNC
        public static string idFileUploadDHNC = string.Empty;
        private static string maVienChucForGetListLinkAnhQuyetDinh = string.Empty;
        private bool checkAddNewDHNC = true;
        private bool soQuyetDinhChanged = false;
        private bool loaiHocHamHocViDangHocNangCaoChanged = false;
        private bool tenHocHamHocViDangHocNangCaoChanged = false;
        private bool ngayBatDauDangHocNangCaoChanged = false;
        private bool ngayKetThucDangHocNangCaoChanged = false;
        private bool coSoDaoTaoDangHocNangCaoChanged = false;
        private bool ngonNguDaoTaoDangHocNangCaoChanged = false;
        private bool hinhThucDaoTaoDangHocNangCaoChanged = false;
        private bool nuocCapBangDangHocNangCaoChanged = false;
        private bool loaiDangHocNangCaoChanged = false;
        private bool linkAnhQuyetDinhChanged = false;
        private void LoadGridTabPageDangHocNangCao(string mavienchuc)
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            List<DangHocNangCaoForView> listDangHocNangCaoForView = unitOfWorks.DangHocNangCaoRepository.GetListDangHocNangCao(mavienchuc);
            _view.GCDangHocNangCao.DataSource = listDangHocNangCaoForView;
        }
        private void LoadCbxDataDHNC()
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            List<LoaiHocHamHocVi> listLoaiHocHamHocVi = unitOfWorks.LoaiHocHamHocViRepository.GetListLoaiHocHamHocVi().ToList();
            _view.CBXLoaiHocHamHocViDHNC.Properties.DataSource = listLoaiHocHamHocVi;
            _view.CBXLoaiHocHamHocViDHNC.Properties.DisplayMember = "tenLoaiHocHamHocVi";
            _view.CBXLoaiHocHamHocViDHNC.Properties.ValueMember = "idLoaiHocHamHocVi";
            _view.CBXLoaiHocHamHocViDHNC.Properties.DropDownRows = listLoaiHocHamHocVi.Count;
            _view.CBXLoaiHocHamHocViDHNC.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("idLoaiHocHamHocVi", string.Empty));
            _view.CBXLoaiHocHamHocViDHNC.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tenLoaiHocHamHocVi", string.Empty));
            _view.CBXLoaiHocHamHocViDHNC.Properties.Columns[0].Visible = false;
            List<string> listLoai = new List<string>() { "Đang học", "Đã xong", "Gia hạn", "Hết hạn" };
            _view.CBXLoai.Properties.DataSource = listLoai;
            _view.CBXLoai.Properties.DropDownRows = listLoai.Count;
            List<string> listCoSoDaoTao = unitOfWorks.DangHocNangCaoRepository.GetListCoSoDaoTao();
            AutoCompleteStringCollection coSoDaoTaoSource = new AutoCompleteStringCollection();
            listCoSoDaoTao.ForEach(x => coSoDaoTaoSource.Add(x)); // autocompleteStringCollection if add null value app will be crashed
            _view.TXTCoSoDaoTaoDHNC.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            _view.TXTCoSoDaoTaoDHNC.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            _view.TXTCoSoDaoTaoDHNC.MaskBox.AutoCompleteCustomSource = coSoDaoTaoSource;

            List<string> listHinhThucDaoTao = unitOfWorks.DangHocNangCaoRepository.GetListHinhThucDaoTao();
            AutoCompleteStringCollection hinhThucDaoTaoSource = new AutoCompleteStringCollection();
            listHinhThucDaoTao.ForEach(x => hinhThucDaoTaoSource.Add(x)); // autocompleteStringCollection if add null value app will be crashed
            _view.TXTHinhThucDaoTaoDHNC.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            _view.TXTHinhThucDaoTaoDHNC.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            _view.TXTHinhThucDaoTaoDHNC.MaskBox.AutoCompleteCustomSource = hinhThucDaoTaoSource;

            List<string> listNgonNguDaoTao = unitOfWorks.DangHocNangCaoRepository.GetListNgonNguDaoTao();
            AutoCompleteStringCollection ngonNguDaoTaoSource = new AutoCompleteStringCollection();
            listNgonNguDaoTao.ForEach(x => ngonNguDaoTaoSource.Add(x)); // autocompleteStringCollection if add null value app will be crashed
            _view.TXTNgonNguDaoTaoDHNC.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            _view.TXTNgonNguDaoTaoDHNC.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            _view.TXTNgonNguDaoTaoDHNC.MaskBox.AutoCompleteCustomSource = ngonNguDaoTaoSource;

            List<string> listNuocCapBang = unitOfWorks.DangHocNangCaoRepository.GetListNuocCapBang();
            AutoCompleteStringCollection nuocCapBangSource = new AutoCompleteStringCollection();
            listNuocCapBang.ForEach(x => nuocCapBangSource.Add(x)); // autocompleteStringCollection if add null value app will be crashed
            _view.TXTNuocCapBangDHNC.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            _view.TXTNuocCapBangDHNC.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            _view.TXTNuocCapBangDHNC.MaskBox.AutoCompleteCustomSource = nuocCapBangSource;
        }
        private void SetDefaultValueControlDHNC()
        {
            checkAddNewDHNC = true;
            _view.CBXLoaiHocHamHocViDHNC.ErrorText = string.Empty;
            _view.CBXLoai.ErrorText = string.Empty;
            _view.CBXLoaiHocHamHocViDHNC.Text = string.Empty;
            _view.CBXLoai.Text = string.Empty;
            _view.TXTTenHocHamHocViDHNC.Text = string.Empty;
            _view.TXTCoSoDaoTaoDHNC.Text = string.Empty;
            _view.TXTNgonNguDaoTaoDHNC.Text = string.Empty;
            _view.TXTHinhThucDaoTaoDHNC.Text = string.Empty;
            _view.TXTNuocCapBangDHNC.Text = string.Empty;
            _view.DTNgayBatDauDHNC.Text = string.Empty;
            _view.DTNgayKetThucDHNC.Text = string.Empty;
            _view.TXTSoQuyetDinh.Text = string.Empty;
            _view.TXTLinkAnhQuyetDinh.Text = string.Empty;
        }
        private void InsertDataDHNC()
        {
            string mavienchuc = _view.TXTMaVienChuc.Text;
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            unitOfWorks.DangHocNangCaoRepository.Insert(new DangHocNangCao
            {
                idVienChuc = unitOfWorks.VienChucRepository.GetIdVienChuc(mavienchuc),
                idLoaiHocHamHocVi = Convert.ToInt32(_view.CBXLoaiHocHamHocViDHNC.EditValue),
                ngayBatDau = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayBatDauDHNC.Text),
                ngayKetThuc = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayKetThucDHNC.Text),
                tenHocHamHocVi = _view.TXTTenHocHamHocViDHNC.Text,
                loai = unitOfWorks.DangHocNangCaoRepository.HardCodeLoaiToDatabase(_view.CBXLoai.EditValue.ToString()),
                coSoDaoTao = _view.TXTCoSoDaoTaoDHNC.Text,
                ngonNguDaoTao = _view.TXTNgonNguDaoTaoDHNC.Text,
                hinhThucDaoTao = _view.TXTHinhThucDaoTaoDHNC.Text,
                nuocCapBang = _view.TXTNuocCapBangDHNC.Text,
                soQuyetDinh = _view.TXTSoQuyetDinh.Text,
                linkAnhQuyetDinh = _view.TXTLinkAnhQuyetDinh.Text
            });
            unitOfWorks.Save();
            LoadGridTabPageDangHocNangCao(_view.TXTMaVienChuc.Text);
            XtraMessageBox.Show("Thêm dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SetDefaultValueControlDHNC();
        }
        private void UpdateDataDHNC()
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            int iddanghocnangcao = Convert.ToInt32(_view.GVDangHocNangCao.GetFocusedRowCellDisplayText("Id"));
            DangHocNangCao dangHocNangCao = unitOfWorks.DangHocNangCaoRepository.GetObjectById(iddanghocnangcao);
            if (loaiHocHamHocViDangHocNangCaoChanged)
            {
                dangHocNangCao.idLoaiHocHamHocVi = Convert.ToInt32(_view.CBXLoaiHocHamHocViDHNC.EditValue);
                loaiHocHamHocViDangHocNangCaoChanged = false;
            }
            if (loaiDangHocNangCaoChanged)
            {
                dangHocNangCao.loai = unitOfWorks.HocHamHocViVienChucRepository.HardCodeBacToDatabase(_view.CBXLoai.EditValue.ToString());
                loaiDangHocNangCaoChanged = false;
            }
            if (tenHocHamHocViDangHocNangCaoChanged)
            {
                dangHocNangCao.tenHocHamHocVi = _view.TXTTenHocHamHocViDHNC.Text;
                tenHocHamHocViDangHocNangCaoChanged = false;
            }
            if (coSoDaoTaoDangHocNangCaoChanged)
            {
                dangHocNangCao.coSoDaoTao = _view.TXTCoSoDaoTaoDHNC.Text;
                coSoDaoTaoDangHocNangCaoChanged = false;
            }
            if (ngonNguDaoTaoDangHocNangCaoChanged)
            {
                dangHocNangCao.ngonNguDaoTao = _view.TXTNgonNguDaoTaoDHNC.Text;
                ngonNguDaoTaoDangHocNangCaoChanged = false;
            }
            if (hinhThucDaoTaoDangHocNangCaoChanged)
            {
                dangHocNangCao.hinhThucDaoTao = _view.TXTHinhThucDaoTaoDHNC.Text;
                hinhThucDaoTaoDangHocNangCaoChanged = false;
            }
            if (nuocCapBangDangHocNangCaoChanged)
            {
                dangHocNangCao.nuocCapBang = _view.TXTNuocCapBangDHNC.Text;
                nuocCapBangDangHocNangCaoChanged = false;
            }
            if (ngayBatDauDangHocNangCaoChanged)
            {
                dangHocNangCao.ngayBatDau = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayBatDauDHNC.Text);
                ngayBatDauDangHocNangCaoChanged = false;
            }
            if (ngayKetThucDangHocNangCaoChanged)
            {
                dangHocNangCao.ngayKetThuc = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayKetThucDHNC.Text);
                ngayKetThucDangHocNangCaoChanged = false;
            }
            if (soQuyetDinhChanged)
            {
                dangHocNangCao.soQuyetDinh = _view.TXTSoQuyetDinh.Text;
                soQuyetDinhChanged = false;
            }
            if (linkAnhQuyetDinhChanged)
            {
                dangHocNangCao.linkAnhQuyetDinh = _view.TXTLinkAnhQuyetDinh.Text;
                linkAnhQuyetDinhChanged = false;
            }
            unitOfWorks.Save();
            LoadGridTabPageDangHocNangCao(_view.TXTMaVienChuc.Text);
            XtraMessageBox.Show("Sửa dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void SelectTabDangHocNangCao() => _view.XtraTabControl.SelectedTabPageIndex = 1;

        public void ClickRowAndShowInfoDHNC()
        {
            checkAddNewDHNC = false;
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            int row_handle = _view.GVDangHocNangCao.FocusedRowHandle;
            if (row_handle >= 0)
            {
                string loaihochamhocvi = _view.GVDangHocNangCao.GetFocusedRowCellDisplayText("LoaiHocHamHocVi");
                _view.CBXLoaiHocHamHocViDHNC.EditValue = unitOfWorks.LoaiHocHamHocViRepository.GetIdLoaiHocHamHocVi(loaihochamhocvi);
                _view.CBXLoai.EditValue = _view.GVDangHocNangCao.GetFocusedRowCellDisplayText("Loai");
                _view.TXTTenHocHamHocViDHNC.Text = _view.GVDangHocNangCao.GetFocusedRowCellDisplayText("TenHocHamHocVi");
                _view.TXTCoSoDaoTaoDHNC.Text = _view.GVDangHocNangCao.GetFocusedRowCellDisplayText("CoSoDaoTao");
                _view.TXTNgonNguDaoTaoDHNC.Text = _view.GVDangHocNangCao.GetFocusedRowCellDisplayText("NgonNguDaoTao");
                _view.TXTHinhThucDaoTaoDHNC.Text = _view.GVDangHocNangCao.GetFocusedRowCellDisplayText("HinhThucDaoTao");
                _view.TXTNuocCapBangDHNC.Text = _view.GVDangHocNangCao.GetFocusedRowCellDisplayText("NuocCapBang");
                _view.DTNgayBatDauDHNC.EditValue = unitOfWorks.HopDongVienChucRepository.ReturnNullIfDateTimeNull(_view.GVDangHocNangCao.GetFocusedRowCellDisplayText("NgayBatDau"));
                _view.DTNgayKetThucDHNC.EditValue = unitOfWorks.HopDongVienChucRepository.ReturnNullIfDateTimeNull(_view.GVDangHocNangCao.GetFocusedRowCellDisplayText("NgayKetThuc"));
                _view.TXTSoQuyetDinh.Text = _view.GVDangHocNangCao.GetFocusedRowCellDisplayText("SoQuyetDinh");
                _view.TXTLinkAnhQuyetDinh.Text = _view.GVDangHocNangCao.GetFocusedRowCellDisplayText("LinkAnhQuyetDinh");
            }
        }

        public void RefreshDHNC() => SetDefaultValueControlDHNC();

        public void AddDHNC() => SetDefaultValueControlDHNC();

        public void SaveDHNC()
        {
            if (checkAddNewDHNC)
            {
                if (_view.TXTMaVienChuc.Text != string.Empty && maVienChucFromTabPageThongTinCaNhan == string.Empty)
                {
                    if (_view.CBXLoaiHocHamHocViDHNC.Text != string.Empty)
                    {
                        InsertDataDHNC();
                    }
                    else
                    {
                        _view.CBXLoaiHocHamHocViDHNC.ErrorText = "Vui lòng chọn trình độ.";
                        _view.CBXLoaiHocHamHocViDHNC.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                    }
                }
                else if (_view.TXTMaVienChuc.Text == string.Empty && maVienChucFromTabPageThongTinCaNhan != string.Empty)
                {
                    _view.TXTMaVienChuc.Text = maVienChucFromTabPageThongTinCaNhan;
                    if (_view.CBXLoaiHocHamHocViDHNC.Text != string.Empty)
                    {
                        InsertDataDHNC();
                    }
                    else
                    {
                        _view.CBXLoaiHocHamHocViDHNC.ErrorText = "Vui lòng chọn trình độ.";
                        _view.CBXLoaiHocHamHocViDHNC.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                    }
                }
                else XtraMessageBox.Show("Vui lòng thêm thông tin viên chức trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int row_handle = _view.GVDangHocNangCao.FocusedRowHandle;
                if (row_handle >= 0)
                {
                    UpdateDataDHNC();
                }
            }
        }

        public void DeleteDHNC()
        {
            try
            {
                UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
                int row_handle = _view.GVDangHocNangCao.FocusedRowHandle;
                if (row_handle >= 0)
                {
                    int id = Convert.ToInt32(_view.GVDangHocNangCao.GetFocusedRowCellDisplayText("Id"));
                    DialogResult dialogResult = XtraMessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        unitOfWorks.DangHocNangCaoRepository.DeleteById(id);
                        unitOfWorks.Save();
                        _view.GVDangHocNangCao.DeleteRow(row_handle);
                        RefreshDHNC();
                        MainPresenter.LoadGridHocHamHocViAtRightViewInMainForm();
                    }
                }
                else XtraMessageBox.Show("Vui lòng chọn dòng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                XtraMessageBox.Show("Không thể xóa. Công tác này đang được sử dụng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExportExcelDHNC() => ExportExcel(_view.GVDangHocNangCao);

        public static void RemoveFileIfNotSaveDHNC(string id)
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            List<string> listLinkAnhQuyetDinh = unitOfWorks.DangHocNangCaoRepository.GetListLinkAnhQuyetDinh(maVienChucForGetListLinkAnhQuyetDinh);
            if (listLinkAnhQuyetDinh.Any(x => x.Equals("https://drive.google.com/open?id=" + id + "")) == false)
            {
                unitOfWorks.GoogleDriveFileRepository.DeleteFile(id);
            }
        }

        public void UploadFileToGoogleDriveDHNC()
        {
            if (_view.GVDangHocNangCao.FocusedRowHandle >= 0)
            {
                string mavienchuc = _view.TXTMaVienChuc.Text;
                _view.OpenFileDialog.FileName = string.Empty;
                _view.OpenFileDialog.Filter = "Pdf Files|*.pdf";
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
                        string[] split_filename = filename.Split('.');
                        string new_filename = split_filename[0] + "-" + mavienchuc + "-" + code + "." + split_filename[1];
                        FileInfo fileInfo = new FileInfo(filename);
                        fileInfo.MoveTo(new_filename);
                        unitOfWorks.GoogleDriveFileRepository.UploadFile(new_filename);
                        FileInfo fileInfo1 = new FileInfo(new_filename); //doi lai filename cu~
                        fileInfo1.MoveTo(filename);
                        string id = unitOfWorks.GoogleDriveFileRepository.GetIdDriveFile(mavienchuc, code);
                        idFileUploadDHNC = id;
                        maVienChucForGetListLinkAnhQuyetDinh = mavienchuc;
                        _view.TXTLinkAnhQuyetDinh.Text = string.Empty;
                        _view.TXTLinkAnhQuyetDinh.Text = "https://drive.google.com/open?id=" + id + "";
                        SplashScreenManager.CloseForm();
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

        public void DownloadFileToDeviceDHNC()
        {
            string linkvanbandinhkem = _view.TXTLinkAnhQuyetDinh.Text.Trim();
            Download(linkvanbandinhkem);
        }

        public void SoQuyetDinhChanged(object sender, EventArgs e)
        {
            soQuyetDinhChanged = true;
        }

        public void LoaiHocHamHocViDangHocNangCaoChanged(object sender, EventArgs e)
        {
            loaiHocHamHocViDangHocNangCaoChanged = true;
        }

        public void TenHocHamHocViDangHocNangCaoChanged(object sender, EventArgs e)
        {
            tenHocHamHocViDangHocNangCaoChanged = true;
        }

        public void NgayBatDauDangHocNangCaoChanged(object sender, EventArgs e)
        {
            ngayBatDauDangHocNangCaoChanged = true;
        }

        public void NgayKetThucDangHocNangCaoChanged(object sender, EventArgs e)
        {
            ngayKetThucDangHocNangCaoChanged = true;
        }

        public void CoSoDaoTaoDangHocNangCaoChanged(object sender, EventArgs e)
        {
            coSoDaoTaoDangHocNangCaoChanged = true;
        }
        
        public void NgonNguDaoTaoDangHocNangCaoChanged(object sender, EventArgs e)
        {
            ngonNguDaoTaoDangHocNangCaoChanged = true;
        }

        public void HinhThucDaoTaoDangHocNangCaoChanged(object sender, EventArgs e)
        {
            hinhThucDaoTaoDangHocNangCaoChanged = true;
        }

        public void NuocCapBangDangHocNangCaoChanged(object sender, EventArgs e)
        {
            nuocCapBangDangHocNangCaoChanged = true;
        }

        public void LoaiDangHocNangCaoChanged(object sender, EventArgs e)
        {
            loaiDangHocNangCaoChanged = true;
        }

        public void LinkAnhQuyetDinhChanged(object sender, EventArgs e)
        {
            linkAnhQuyetDinhChanged = true;
        }
        #endregion
        #region Nganh
        private void LoadCbxDataN()
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            List<NganhDaoTao> listNganhDaoTao = unitOfWorks.NganhDaoTaoRepository.GetListNganhDaoTao().ToList();
            _view.CBXNganhDaoTaoN.Properties.DataSource = listNganhDaoTao;
            _view.CBXNganhDaoTaoN.Properties.DisplayMember = "tenNganhDaoTao";
            _view.CBXNganhDaoTaoN.Properties.ValueMember = "idNganhDaoTao";
            _view.CBXNganhDaoTaoN.Properties.DropDownRows = listNganhDaoTao.Count;
            _view.CBXNganhDaoTaoN.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("idNganhDaoTao", string.Empty));
            _view.CBXNganhDaoTaoN.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tenNganhDaoTao", string.Empty));
            _view.CBXNganhDaoTaoN.Properties.Columns[0].Visible = false;
            List<ChuyenNganh> listChuyenNganh = unitOfWorks.ChuyenNganhRepository.GetListChuyenNganh().ToList();
            _view.CBXChuyenNganhN.Properties.DataSource = listChuyenNganh;
            _view.CBXChuyenNganhN.Properties.DisplayMember = "tenChuyenNganh";
            _view.CBXChuyenNganhN.Properties.ValueMember = "idChuyenNganh";
            _view.CBXChuyenNganhN.Properties.DropDownRows = listChuyenNganh.Count;
            _view.CBXChuyenNganhN.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("idChuyenNganh", string.Empty));
            _view.CBXChuyenNganhN.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tenChuyenNganh", string.Empty));
            _view.CBXChuyenNganhN.Properties.Columns[0].Visible = false;
            String mavienchuc = _view.TXTMaVienChuc.Text;
            List<HocHamHocViVienChuc> listTenHocHamHocViVienChuc = unitOfWorks.HocHamHocViVienChucRepository.GetListTenHocHamHocViVienChuc(mavienchuc);
            _view.CBXTenHocHamHocViN.Properties.DataSource = listTenHocHamHocViVienChuc;
            _view.CBXTenHocHamHocViN.Properties.DisplayMember = "tenHocHamHocVi";
            _view.CBXTenHocHamHocViN.Properties.ValueMember = "idHocHamHocViVienChuc";
            _view.CBXTenHocHamHocViN.Properties.DropDownRows = listTenHocHamHocViVienChuc.Count;
            _view.CBXTenHocHamHocViN.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("idHocHamHocViVienChuc", string.Empty));
            _view.CBXTenHocHamHocViN.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tenHocHamHocVi", string.Empty));
            _view.CBXTenHocHamHocViN.Properties.Columns[0].Visible = false;
            List<string> listPhanLoai = new List<string>() { "Vừa học vừa dạy", "Chỉ học", "Chỉ dạy" };
            _view.CBXPhanLoaiN.Properties.DataSource = listPhanLoai;
            _view.CBXPhanLoaiN.Properties.DropDownRows = listPhanLoai.Count;
        }
        private void SetDefaultValueControlN()
        {
            _view.CBXTenHocHamHocViN.ErrorText = string.Empty;
            _view.CBXNganhDaoTaoN.ErrorText = string.Empty;
            _view.CBXChuyenNganhN.ErrorText = string.Empty;
            _view.CBXPhanLoaiN.ErrorText = string.Empty;
            _view.CBXTenHocHamHocViN.Text = string.Empty;
            _view.CBXNganhDaoTaoN.Text = string.Empty;
            _view.CBXChuyenNganhN.Text = string.Empty;
            _view.CBXPhanLoaiN.Text = string.Empty;
            _view.DTNgayBatDauN.Text = string.Empty;
            _view.DTNgayKetThucN.Text = string.Empty;
            _view.TXTLinkVanBanDinhKemN.Text = string.Empty;
        }
        private void InsertDataN()
        {
            string mavienchuc = _view.TXTMaVienChuc.Text;
            int nganhdaotao = Convert.ToInt32(_view.CBXNganhDaoTaoN.EditValue);
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            unitOfWorks.NganhVienChucRepository.Insert(new NganhVienChuc
            {
                idVienChuc = unitOfWorks.VienChucRepository.GetIdVienChuc(mavienchuc),
                idLoaiNganh = unitOfWorks.NganhDaoTaoRepository.GetIdLoaiNganhByIdNganhDaoTao(nganhdaotao),
                idHocHamHocViVienChuc = Convert.ToInt32(_view.CBXTenHocHamHocViN.EditValue),
                idNganhDaoTao = nganhdaotao,
                idChuyenNganh = Convert.ToInt32(_view.CBXChuyenNganhN.EditValue),
                phanLoai = unitOfWorks.NganhVienChucRepository.HardCodePhanLoaiToDatabase(_view.CBXPhanLoaiN.EditValue.ToString()),
                ngayBatDau = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayBatDauN.Text),
                ngayKetThuc = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayKetThucN.Text),
                linkVanBanDinhKem = _view.TXTLinkVanBanDinhKemN.Text
            });
            unitOfWorks.Save();
            LoadGridTabPageNganh(_view.TXTMaVienChuc.Text);
            XtraMessageBox.Show("Thêm dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MainPresenter.LoadGridHocHamHocViAtRightViewInMainForm();
        }
        private void UpdateDataN()
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            int idnganhvienchuc = Convert.ToInt32(_view.GVNganh.GetFocusedRowCellDisplayText("Id"));
            NganhVienChuc nganhVienChuc = unitOfWorks.NganhVienChucRepository.GetObjectById(idnganhvienchuc);
            nganhVienChuc.phanLoai = unitOfWorks.NganhVienChucRepository.HardCodePhanLoaiToDatabase(_view.CBXPhanLoaiN.EditValue.ToString());
            nganhVienChuc.ngayBatDau = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayBatDauN.Text);
            nganhVienChuc.ngayKetThuc = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayKetThucN.Text);
            nganhVienChuc.linkVanBanDinhKem = _view.TXTLinkVanBanDinhKemN.Text;
            unitOfWorks.Save();
            LoadGridTabPageNganh(_view.TXTMaVienChuc.Text);
            XtraMessageBox.Show("Sửa dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MainPresenter.LoadGridHocHamHocViAtRightViewInMainForm();
        }
        private void LoadGridTabPageNganh(string mavienchuc)
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            List<NganhForView> listNganhForView = unitOfWorks.NganhVienChucRepository.GetListNganh(mavienchuc);
            _view.GCNganh.DataSource = listNganhForView;
        }

        public void SelectTabNganh() => _view.XtraTabControl.SelectedTabPageIndex = 2;

        public void ClickRowAndShowInfoN()
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            int row_handle = _view.GVNganh.FocusedRowHandle;
            if (row_handle >= 0)
            {
                string nganhdaotao = _view.GVNganh.GetFocusedRowCellDisplayText("NganhDaoTao");
                string chuyennganh = _view.GVNganh.GetFocusedRowCellDisplayText("ChuyenNganh");
                _view.CBXTenHocHamHocViN.EditValue = Convert.ToInt32(_view.GVNganh.GetFocusedRowCellDisplayText("IdHocHamHocViVienChuc"));
                _view.CBXNganhDaoTaoN.EditValue = unitOfWorks.NganhDaoTaoRepository.GetIdNganhDaoTao(nganhdaotao);
                _view.CBXChuyenNganhN.EditValue = unitOfWorks.ChuyenNganhRepository.GetIdChuyenNganh(chuyennganh);
                _view.CBXPhanLoaiN.EditValue = _view.GVNganh.GetFocusedRowCellDisplayText("PhanLoai");
                _view.DTNgayBatDauN.EditValue = _view.GVNganh.GetFocusedRowCellDisplayText("NgayBatDau");
                _view.DTNgayKetThucN.EditValue = _view.GVNganh.GetFocusedRowCellDisplayText("NgayKetThuc");
                _view.TXTLinkVanBanDinhKemN.Text = _view.GVNganh.GetFocusedRowCellDisplayText("LinkVanBanDinhKem");
            }
        }

        public void RefreshN()
        {
            SetDefaultValueControlN();
        }

        public void AddN()
        {
            if (_view.TXTMaVienChuc.Text != string.Empty && maVienChucFromTabPageThongTinCaNhan == string.Empty)
            {
                if (_view.CBXNganhDaoTaoN.Text != string.Empty && _view.CBXChuyenNganhN.Text != string.Empty && _view.CBXTenHocHamHocViN.Text != string.Empty)
                {
                    InsertDataN();
                }
                if(_view.CBXNganhDaoTaoN.Text == string.Empty)
                {
                    _view.CBXNganhDaoTaoN.ErrorText = "Vui lòng chọn ngành đào tạo.";
                    _view.CBXNganhDaoTaoN.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
                if (_view.CBXChuyenNganhN.Text == string.Empty)
                {
                    _view.CBXChuyenNganhN.ErrorText = "Vui lòng chọn chuyên ngành.";
                    _view.CBXChuyenNganhN.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
                if (_view.CBXTenHocHamHocViN.Text == string.Empty)
                {
                    _view.CBXTenHocHamHocViN.ErrorText = "Vui lòng chọn tên Học hàm/Học vị.";
                    _view.CBXTenHocHamHocViN.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
                if (_view.CBXPhanLoaiN.Text == string.Empty)
                {
                    _view.CBXTenHocHamHocViN.ErrorText = "Vui lòng chọn phân loại.";
                    _view.CBXTenHocHamHocViN.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
            }
            else if (_view.TXTMaVienChuc.Text == string.Empty && maVienChucFromTabPageThongTinCaNhan != string.Empty)
            {
                _view.TXTMaVienChuc.Text = maVienChucFromTabPageThongTinCaNhan;
                if (_view.CBXNganhDaoTaoN.Text != string.Empty && _view.CBXChuyenNganhN.Text != string.Empty && _view.CBXTenHocHamHocViN.Text != string.Empty)
                {
                    InsertDataN();
                }
                if (_view.CBXNganhDaoTaoN.Text == string.Empty)
                {
                    _view.CBXNganhDaoTaoN.ErrorText = "Vui lòng chọn ngành đào tạo.";
                    _view.CBXNganhDaoTaoN.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
                if (_view.CBXChuyenNganhN.Text == string.Empty)
                {
                    _view.CBXChuyenNganhN.ErrorText = "Vui lòng chọn chuyên ngành.";
                    _view.CBXChuyenNganhN.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
                if (_view.CBXTenHocHamHocViN.Text == string.Empty)
                {
                    _view.CBXTenHocHamHocViN.ErrorText = "Vui lòng chọn tên Học hàm/Học vị.";
                    _view.CBXTenHocHamHocViN.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
                if (_view.CBXPhanLoaiN.Text == string.Empty)
                {
                    _view.CBXTenHocHamHocViN.ErrorText = "Vui lòng chọn phân loại.";
                    _view.CBXTenHocHamHocViN.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
            }
            else XtraMessageBox.Show("Vui lòng thêm thông tin viên chức trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void EditN()
        {
            int row_handle = _view.GVNganh.FocusedRowHandle;
            if (row_handle >= 0)
            {
                UpdateDataN();
            }
        }

        public void DeleteN()
        {
            try
            {
                UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
                int row_handle = _view.GVNganh.FocusedRowHandle;
                if (row_handle >= 0)
                {
                    int id = Convert.ToInt32(_view.GVNganh.GetFocusedRowCellDisplayText("Id"));
                    DialogResult dialogResult = XtraMessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        unitOfWorks.NganhVienChucRepository.DeleteById(id);
                        unitOfWorks.Save();
                        _view.GVNganh.DeleteRow(row_handle);
                        RefreshN();
                        MainPresenter.LoadGridHocHamHocViAtRightViewInMainForm();
                    }
                }
                else XtraMessageBox.Show("Vui lòng chọn dòng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                XtraMessageBox.Show("Không thể xóa. Công tác này đang được sử dụng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExportExcelN() => ExportExcel(_view.GVNganh);

        public void UploadFileToGoogleDriveN()
        {
            if (_view.GVNganh.FocusedRowHandle >= 0)
            {
                string mavienchuc = _view.TXTMaVienChuc.Text;
                _view.OpenFileDialog.FileName = string.Empty;
                _view.OpenFileDialog.Filter = "Pdf Files|*.pdf";
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
                            _view.TXTLinkVanBanDinhKemN.Text = "https://drive.google.com/open?id=" + id + "";
                        }
                        else
                        {
                            string[] split_filename = filename.Split('.');
                            string new_filename = split_filename[0] + "-" + mavienchuc + "-" + code + "." + split_filename[1];
                            FileInfo fileInfo = new FileInfo(filename);
                            fileInfo.MoveTo(new_filename);
                            unitOfWorks.GoogleDriveFileRepository.UploadFile(new_filename);
                            string id = unitOfWorks.GoogleDriveFileRepository.GetIdDriveFile(mavienchuc, code);
                            _view.TXTLinkVanBanDinhKemN.Text = "https://drive.google.com/open?id=" + id + "";
                        }
                        SplashScreenManager.CloseForm();
                        LoadGridTabPageNganh(mavienchuc);
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

        public void DownloadFileToDeviceN()
        {
            string linkvanbandinhkem = _view.GVNganh.GetFocusedRowCellDisplayText("LinkVanBanDinhKem").ToString().Trim();
            Download(linkvanbandinhkem);
        }

        public void CbxNganhDaoTaoNChanged(object sender, EventArgs e)
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            int idnganhdaotao = Convert.ToInt32(_view.CBXNganhDaoTaoN.EditValue);
            List<ChuyenNganh> list = unitOfWorks.ChuyenNganhRepository.GetListChuyenNganhByIdNganhDaoTao(idnganhdaotao);
            _view.CBXChuyenNganhN.Properties.DataSource = list;
            _view.CBXChuyenNganhN.Properties.DisplayMember = "tenChuyenNganh";
            _view.CBXChuyenNganhN.Properties.ValueMember = "idChuyenNganh";
            _view.CBXChuyenNganhN.Properties.DropDownRows = list.Count;
            _view.CBXChuyenNganhN.Properties.Columns[0].Visible = false;
        }
        #endregion
        #region ChungChi
        private bool loaiChungChiOrCapDoChanged = false;
        private bool ngayCapChungChiChanged = false;
        private bool ghiChuChungChiChanged = false;
        private bool linkVanBanDinhKemChungChiChanged = false;
        private bool checkAddNewCC = true;
        private static string maVienChucForGetListLinkVanBanDinhKemCC = string.Empty;
        public static string idFileUploadCC = string.Empty;
        private void LoadGridTabPageChungChi(string mavienchuc)
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            List<ChungChiForView> listChungChiForView = unitOfWorks.ChungChiVienChucRepository.GetListChungChiVienChuc(mavienchuc);
            _view.GCChungChi.DataSource = listChungChiForView;
        }
        private void LoadCbxDataCC()
        {
            _view.CBXLoaiChungChi.Properties.DataSource = null;
            _view.CBXLoaiChungChi.Properties.Columns.Clear();
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            List<string> listTenLoaiChungChi = unitOfWorks.LoaiChungChiRepository.GetListTenLoaiChungChi();
            _view.CBXLoaiChungChi.Properties.DataSource = listTenLoaiChungChi;
            _view.CBXLoaiChungChi.Properties.DropDownRows = listTenLoaiChungChi.Count;

            List<string> listCapDoChungChi = unitOfWorks.LoaiChungChiRepository.GetListCapDoChungChi();
            AutoCompleteStringCollection capdoSource = new AutoCompleteStringCollection();
            listCapDoChungChi.ForEach(x => capdoSource.Add(x)); // autocompleteStringCollection if add null value app will be crashed
            _view.TXTCapDoChungChi.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            _view.TXTCapDoChungChi.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            _view.TXTCapDoChungChi.MaskBox.AutoCompleteCustomSource = capdoSource;
        }
        private void SetDefaultValueControlCC()
        {
            checkAddNewCC = true;
            _view.CBXLoaiChungChi.ErrorText = string.Empty;
            _view.TXTCapDoChungChi.ErrorText = string.Empty;
            _view.CBXLoaiChungChi.Text = string.Empty;
            _view.TXTCapDoChungChi.Text = string.Empty;
            _view.TXTGhiChuCC.Text = string.Empty;
            _view.DTNgayCapChungChi.Text = string.Empty;
            _view.TXTLinkVanBanDinhKemCC.Text = string.Empty;
        }
        private void InsertDataCC()
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            string mavienchuc = _view.TXTMaVienChuc.Text;
            string loaichungchi = _view.CBXLoaiChungChi.Text;
            string capdo = _view.TXTCapDoChungChi.Text;
            int idloaichungchi = unitOfWorks.LoaiChungChiRepository.GetIdLoaiChungChi(loaichungchi, capdo);
            if (idloaichungchi > 0)
            {
                unitOfWorks.ChungChiVienChucRepository.Insert(new ChungChiVienChuc
                {
                    idVienChuc = unitOfWorks.VienChucRepository.GetIdVienChuc(mavienchuc),
                    idLoaiChungChi = idloaichungchi,
                    ngayCapChungChi = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayCapChungChi.Text),
                    ghiChu = _view.TXTGhiChuCC.Text,
                    linkVanBanDinhKem = _view.TXTGhiChuCC.Text
                });
                unitOfWorks.Save();
                LoadGridTabPageChungChi(_view.TXTMaVienChuc.Text);
                XtraMessageBox.Show("Thêm dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainPresenter.LoadGridChungChi();
                SetDefaultValueControlCC();
            }
            else XtraMessageBox.Show("Bạn chọn sai chứng chỉ hoặc cấp độ. Vui lòng chọn lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void UpdateDataCC()
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            int idchungchivienchuc = Convert.ToInt32(_view.GVChungChi.GetFocusedRowCellDisplayText("Id"));
            string tenloaichungchi = _view.CBXLoaiChungChi.EditValue.ToString();
            string capdo = _view.TXTCapDoChungChi.Text;
            ChungChiVienChuc chungChiVienChuc = unitOfWorks.ChungChiVienChucRepository.GetObjectById(idchungchivienchuc);
            if (loaiChungChiOrCapDoChanged)
            {
                chungChiVienChuc.idLoaiChungChi = unitOfWorks.LoaiChungChiRepository.GetIdLoaiChungChiByTenAndCapDo(tenloaichungchi, capdo);
                loaiChungChiOrCapDoChanged = false;
            }
            if (ngayCapChungChiChanged)
            {
                chungChiVienChuc.ngayCapChungChi = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayCapChungChi.Text);
                ngayCapChungChiChanged = false;
            }
            if (ghiChuChungChiChanged)
            {
                chungChiVienChuc.ghiChu = _view.TXTGhiChuCC.Text;
                ghiChuChungChiChanged = false;
            }
            if (linkVanBanDinhKemChungChiChanged)
            {
                chungChiVienChuc.linkVanBanDinhKem = _view.TXTLinkVanBanDinhKemCC.Text;
                linkVanBanDinhKemChungChiChanged = false;
            }
            unitOfWorks.Save();
            LoadGridTabPageChungChi(_view.TXTMaVienChuc.Text);
            XtraMessageBox.Show("Sửa dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MainPresenter.LoadGridChungChi();       
        }

        public void SelectTabChungChi() => _view.XtraTabControl.SelectedTabPageIndex = 3;
        
        public void ClickRowAndShowInfoCC()
        {
            checkAddNewCC = false;
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            int row_handle = _view.GVChungChi.FocusedRowHandle;
            if (row_handle >= 0)
            {
                _view.CBXLoaiChungChi.EditValue = _view.GVChungChi.GetFocusedRowCellDisplayText("LoaiChungChi");
                _view.TXTCapDoChungChi.Text = _view.GVChungChi.GetFocusedRowCellDisplayText("CapDo");
                _view.DTNgayCapChungChi.EditValue = unitOfWorks.HopDongVienChucRepository.ReturnNullIfDateTimeNull(_view.GVChungChi.GetFocusedRowCellDisplayText("NgayCapChungChi"));
                _view.TXTGhiChuCC.Text = _view.GVChungChi.GetFocusedRowCellDisplayText("GhiChu");
                _view.TXTLinkVanBanDinhKemCC.Text = _view.GVChungChi.GetFocusedRowCellDisplayText("LinkVanBanDinhKem");
            }
        }

        public void RefreshCC() => SetDefaultValueControlCC();

        public void AddCC() => SetDefaultValueControlCC();

        public void SaveCC()
        {
            if (checkAddNewCC)
            {
                if (_view.TXTMaVienChuc.Text != string.Empty && maVienChucFromTabPageThongTinCaNhan == string.Empty)
                {
                    if (_view.CBXLoaiChungChi.Text != string.Empty && _view.TXTCapDoChungChi.Text != string.Empty)
                    {
                        InsertDataCC();
                    }
                    if (_view.CBXLoaiChungChi.Text == string.Empty)
                    {
                        _view.CBXLoaiChungChi.ErrorText = "Vui lòng chọn chứng chỉ.";
                        _view.CBXLoaiChungChi.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                    }
                    if (_view.TXTCapDoChungChi.Text == string.Empty)
                    {
                        _view.TXTCapDoChungChi.ErrorText = "Vui lòng chọn cấp độ.";
                        _view.TXTCapDoChungChi.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                    }
                }
                else if (_view.TXTMaVienChuc.Text == string.Empty && maVienChucFromTabPageThongTinCaNhan != string.Empty)
                {
                    _view.TXTMaVienChuc.Text = maVienChucFromTabPageThongTinCaNhan;
                    if (_view.CBXLoaiChungChi.Text != string.Empty && _view.TXTCapDoChungChi.Text != string.Empty)
                    {
                        InsertDataCC();
                    }
                    if (_view.CBXLoaiChungChi.Text == string.Empty)
                    {
                        _view.CBXLoaiChungChi.ErrorText = "Vui lòng chọn chứng chỉ.";
                        _view.CBXLoaiChungChi.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                    }
                    if (_view.TXTCapDoChungChi.Text == string.Empty)
                    {
                        _view.TXTCapDoChungChi.ErrorText = "Vui lòng chọn cấp độ.";
                        _view.TXTCapDoChungChi.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                    }
                }
                else XtraMessageBox.Show("Vui lòng thêm thông tin viên chức trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int row_handle = _view.GVChungChi.FocusedRowHandle;
                if (row_handle >= 0)
                {
                    UpdateDataCC();
                }
            }            
        }

        public void DeleteCC()
        {
            try
            {
                UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
                int row_handle = _view.GVChungChi.FocusedRowHandle;
                if (row_handle >= 0)
                {
                    int id = Convert.ToInt32(_view.GVChungChi.GetFocusedRowCellDisplayText("Id"));
                    DialogResult dialogResult = XtraMessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        unitOfWorks.ChungChiVienChucRepository.DeleteById(id);
                        unitOfWorks.Save();
                        _view.GVChungChi.DeleteRow(row_handle);
                        RefreshCC();
                        MainPresenter.LoadGridChungChi();
                    }
                }
                else XtraMessageBox.Show("Vui lòng chọn dòng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                XtraMessageBox.Show("Không thể xóa. Công tác này đang được sử dụng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExportExcelCC() => ExportExcel(_view.GVChungChi);

        public static void RemoveFileIfNotSaveCC(string id)
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            List<string> listLinkVanBanDinhKem = unitOfWorks.ChungChiVienChucRepository.GetListLinkVanBanDinhKem(maVienChucForGetListLinkVanBanDinhKemCC);
            if (listLinkVanBanDinhKem.Any(x => x.Equals("https://drive.google.com/open?id=" + id + "")) == false)
            {
                unitOfWorks.GoogleDriveFileRepository.DeleteFile(id);
            }
        }

        public void UploadFileToGoogleDriveCC()
        {
            if (_view.GVChungChi.FocusedRowHandle >= 0)
            {
                string mavienchuc = _view.TXTMaVienChuc.Text;
                _view.OpenFileDialog.FileName = string.Empty;
                _view.OpenFileDialog.Filter = "Pdf Files|*.pdf|All files (*.*)|*.*";
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
                        string[] split_filename = filename.Split('.');
                        string new_filename = split_filename[0] + "-" + mavienchuc + "-" + code + "." + split_filename[1];
                        FileInfo fileInfo = new FileInfo(filename);
                        fileInfo.MoveTo(new_filename);
                        unitOfWorks.GoogleDriveFileRepository.UploadFile(new_filename);
                        FileInfo fileInfo1 = new FileInfo(new_filename); //doi lai filename cu~
                        fileInfo1.MoveTo(filename);
                        string id = unitOfWorks.GoogleDriveFileRepository.GetIdDriveFile(mavienchuc, code);
                        idFileUploadCC = id;//
                        maVienChucForGetListLinkVanBanDinhKemCC = mavienchuc;//
                        _view.TXTLinkVanBanDinhKemCC.Text = string.Empty;//
                        _view.TXTLinkVanBanDinhKemCC.Text = "https://drive.google.com/open?id=" + id + "";
                        SplashScreenManager.CloseForm();
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

        public void DownloadFileToDeviceCC()
        {
            string linkvanbandinhkem = _view.TXTLinkVanBanDinhKemCC.Text.Trim();
            Download(linkvanbandinhkem);
        }

        public void LoaiChungChiChanged(object sender, EventArgs e)
        {
            loaiChungChiOrCapDoChanged = true;
            string tenloaichungchi = _view.CBXLoaiChungChi.Properties.DisplayMember;
            if(tenloaichungchi != string.Empty)
            {
                UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
                List<string> listCapDoChungChi = unitOfWorks.LoaiChungChiRepository.GetListCapDoChungChiByTenLoaiChungChi(tenloaichungchi);
                AutoCompleteStringCollection capdoSource = new AutoCompleteStringCollection();
                listCapDoChungChi.ForEach(x => capdoSource.Add(x));
                _view.TXTCapDoChungChi.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                _view.TXTCapDoChungChi.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                _view.TXTCapDoChungChi.MaskBox.AutoCompleteCustomSource = capdoSource;
            }
            else
            {
                LoadCbxDataCC();
            }
        }

        public void CapDoChungChiChanged(object sender, EventArgs e)
        {
            loaiChungChiOrCapDoChanged = true;
            string capdo = _view.TXTCapDoChungChi.Text;
            if(capdo != string.Empty)
            {
                _view.CBXLoaiChungChi.Properties.DataSource = null;
                _view.CBXLoaiChungChi.Properties.Columns.Clear();
                UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
                List<string> listTenLoaiChungChi = unitOfWorks.LoaiChungChiRepository.GetListTenLoaiChungChiByCapDo(capdo);
                _view.CBXLoaiChungChi.Properties.DataSource = listTenLoaiChungChi;
                _view.CBXLoaiChungChi.Properties.DropDownRows = listTenLoaiChungChi.Count;
            }
            else
            {
                LoadCbxDataCC();
            }
        }

        public void NgayCapChungChiChanged(object sender, EventArgs e)
        {
            ngayCapChungChiChanged = true;
        }

        public void GhiChuChungChiChanged(object sender, EventArgs e)
        {
            ghiChuChungChiChanged = true;
        }

        public void LinkVanBanDinhKemChungChiChanged(object sender, EventArgs e)
        {
            linkVanBanDinhKemChungChiChanged = true;
        }        
        #endregion
    }
}
