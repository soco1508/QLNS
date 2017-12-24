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
        //1
        void ClickRowAndShowInfoHHHV();
        void RefreshHHHV();
        void AddHHHV();
        void EditHHHV();
        void DeleteHHHV();
        void ExportExcelHHHV();
        void UploadFileToGoogleDriveHHHV();
        void DownloadFileToDeviceHHHV();
        void CbxNganhDaoTaoHHHVChanged(object sender, EventArgs e);
        //2     
        void ClickRowAndShowInfoDHNC();
        void RefreshDHNC();
        void AddDHNC();
        void EditDHNC();
        void DeleteDHNC();
        void ExportExcelDHNC();
        void UploadFileToGoogleDriveDHNC();
        void DownloadFileToDeviceDHNC();
        //tab3
        void ClickRowAndShowInfoN();
        void RefreshN();
        void AddN();
        void EditN();
        void DeleteN();
        void ExportExcelN();
        void UploadFileToGoogleDriveN();
        void DownloadFileToDeviceN();
        void CbxNganhDaoTaoNChanged(object sender, EventArgs e);
        //tab4
        void ClickRowAndShowInfoCC();
        void RefreshCC();
        void AddCC();
        void EditCC();
        void DeleteCC();
        void ExportExcelCC();
        void UploadFileToGoogleDriveCC();
        void DownloadFileToDeviceCC();
    }
    public class TabPageChuyenMonPresenter : ITabPageChuyenMonPresenter
    {
        public static string _mavienchuc = "";
        public int _rowHandle = -1;
        public bool checkGrid = false;
        private static CreateAndEditPersonInfoForm _createAndEditPersonInfoForm = new CreateAndEditPersonInfoForm();
        private TabPageChuyenMon _view;
        public object UI => _view;
        public TabPageChuyenMonPresenter(TabPageChuyenMon view) => _view = view;
        public void Initialize(string mavienchuc)
        {
            _view.Attach(this);
            _view.TXTMaVienChuc.Text = mavienchuc;
        }
        public void SelectTabHocHamHocVi() => _view.XtraTabControl.SelectedTabPageIndex = 0;
        public void SelectTabDangHocNangCao() => _view.XtraTabControl.SelectedTabPageIndex = 1;
        public void SelectTabNganh() => _view.XtraTabControl.SelectedTabPageIndex = 2;
        public void SelectTabChungChi() => _view.XtraTabControl.SelectedTabPageIndex = 3;
        private string GenerateCode() => Guid.NewGuid().ToString("N");
        private void LoadGridTabPageHocHamHocVi(string mavienchuc)
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            List<HocHamHocViForView> listHocHamHocViForView = unitOfWorks.HocHamHocViVienChucRepository.GetListHocHamHocVi(mavienchuc);
            _view.GCHocHamHocVi.DataSource = listHocHamHocViForView;
        }
        private void LoadGridTabPageDangHocNangCao(string mavienchuc)
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            List<DangHocNangCaoForView> listDangHocNangCaoForView = unitOfWorks.DangHocNangCaoRepository.GetListDangHocNangCao(mavienchuc);
            _view.GCDangHocNangCao.DataSource = listDangHocNangCaoForView;
        }
        private void LoadGridTabPageNganh(string mavienchuc)
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            List<NganhForView> listNganhForView = unitOfWorks.NganhVienChucRepository.GetListNganh(mavienchuc);
            _view.GCNganh.DataSource = listNganhForView;
        }
        private void LoadGridTabPageChungChi(string mavienchuc)
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            List<ChungChiForView> listChungChiForView = unitOfWorks.ChungChiVienChucRepository.GetListChungChiVienChuc(mavienchuc);
            _view.GCChungChi.DataSource = listChungChiForView;
        }
        private void LoadCbxDataHHHV()
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            List<NganhDaoTao> listNganhDaoTao = unitOfWorks.NganhDaoTaoRepository.GetListNganhDaoTao().ToList();
            _view.CBXNganhDaoTaoHHHV.Properties.DataSource = listNganhDaoTao;
            _view.CBXNganhDaoTaoHHHV.Properties.DisplayMember = "tenNganhDaoTao";
            _view.CBXNganhDaoTaoHHHV.Properties.ValueMember = "idNganhDaoTao";
            _view.CBXNganhDaoTaoHHHV.Properties.DropDownRows = listNganhDaoTao.Count;
            _view.CBXNganhDaoTaoHHHV.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("idNganhDaoTao", ""));
            _view.CBXNganhDaoTaoHHHV.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tenNganhDaoTao", ""));
            _view.CBXNganhDaoTaoHHHV.Properties.Columns[0].Visible = false;
            List<ChuyenNganh> listChuyenNganh = unitOfWorks.ChuyenNganhRepository.GetListChuyenNganh().ToList();
            _view.CBXChuyenNganhHHHV.Properties.DataSource = listChuyenNganh;
            _view.CBXChuyenNganhHHHV.Properties.DisplayMember = "tenChuyenNganh";
            _view.CBXChuyenNganhHHHV.Properties.ValueMember = "idChuyenNganh";
            _view.CBXChuyenNganhHHHV.Properties.DropDownRows = listChuyenNganh.Count;
            _view.CBXChuyenNganhHHHV.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("idChuyenNganh", ""));
            _view.CBXChuyenNganhHHHV.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tenChuyenNganh", ""));
            _view.CBXChuyenNganhHHHV.Properties.Columns[0].Visible = false;
            List<LoaiHocHamHocVi> listLoaiHocHamHocVi = unitOfWorks.LoaiHocHamHocViRepository.GetListLoaiHocHamHocVi().ToList();
            _view.CBXLoaiHocHamHocViHHHV.Properties.DataSource = listLoaiHocHamHocVi;
            _view.CBXLoaiHocHamHocViHHHV.Properties.DisplayMember = "tenLoaiHocHamHocVi";
            _view.CBXLoaiHocHamHocViHHHV.Properties.ValueMember = "idLoaiHocHamHocVi";
            _view.CBXLoaiHocHamHocViHHHV.Properties.DropDownRows = listLoaiHocHamHocVi.Count;
            _view.CBXLoaiHocHamHocViHHHV.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("idLoaiHocHamHocVi", ""));
            _view.CBXLoaiHocHamHocViHHHV.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tenLoaiHocHamHocVi", ""));
            _view.CBXLoaiHocHamHocViHHHV.Properties.Columns[0].Visible = false;
        }
        private void LoadCbxDataDHNC()
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            List<LoaiHocHamHocVi> listLoaiHocHamHocVi = unitOfWorks.LoaiHocHamHocViRepository.GetListLoaiHocHamHocVi().ToList();
            _view.CBXLoaiHocHamHocViDHNC.Properties.DataSource = listLoaiHocHamHocVi;
            _view.CBXLoaiHocHamHocViDHNC.Properties.DisplayMember = "tenLoaiHocHamHocVi";
            _view.CBXLoaiHocHamHocViDHNC.Properties.ValueMember = "idLoaiHocHamHocVi";
            _view.CBXLoaiHocHamHocViDHNC.Properties.DropDownRows = listLoaiHocHamHocVi.Count;
            _view.CBXLoaiHocHamHocViDHNC.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("idLoaiHocHamHocVi", ""));
            _view.CBXLoaiHocHamHocViDHNC.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tenLoaiHocHamHocVi", ""));
            _view.CBXLoaiHocHamHocViDHNC.Properties.Columns[0].Visible = false;
            List<string> listLoai = new List<string>() { "Đang học", "Đã xong", "Gia hạn", "Hết hạn" };
            _view.CBXLoai.Properties.DataSource = listLoai;
            _view.CBXLoai.Properties.DropDownRows = listLoai.Count;
        }
        private void LoadCbxDataN()
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            List<NganhDaoTao> listNganhDaoTao = unitOfWorks.NganhDaoTaoRepository.GetListNganhDaoTao().ToList();
            _view.CBXNganhDaoTaoN.Properties.DataSource = listNganhDaoTao;
            _view.CBXNganhDaoTaoN.Properties.DisplayMember = "tenNganhDaoTao";
            _view.CBXNganhDaoTaoN.Properties.ValueMember = "idNganhDaoTao";
            _view.CBXNganhDaoTaoN.Properties.DropDownRows = listNganhDaoTao.Count;
            _view.CBXNganhDaoTaoN.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("idNganhDaoTao", ""));
            _view.CBXNganhDaoTaoN.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tenNganhDaoTao", ""));
            _view.CBXNganhDaoTaoN.Properties.Columns[0].Visible = false;
            List<ChuyenNganh> listChuyenNganh = unitOfWorks.ChuyenNganhRepository.GetListChuyenNganh().ToList();
            _view.CBXChuyenNganhN.Properties.DataSource = listChuyenNganh;
            _view.CBXChuyenNganhN.Properties.DisplayMember = "tenChuyenNganh";
            _view.CBXChuyenNganhN.Properties.ValueMember = "idChuyenNganh";
            _view.CBXChuyenNganhN.Properties.DropDownRows = listChuyenNganh.Count;
            _view.CBXChuyenNganhN.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("idChuyenNganh", ""));
            _view.CBXChuyenNganhN.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tenChuyenNganh", ""));
            _view.CBXChuyenNganhN.Properties.Columns[0].Visible = false;
            String mavienchuc = _view.TXTMaVienChuc.Text;
            List<HocHamHocViVienChuc> listTenHocHamHocViVienChuc = unitOfWorks.HocHamHocViVienChucRepository.GetListTenHocHamHocViVienChuc(mavienchuc);
            _view.CBXTenHocHamHocViN.Properties.DataSource = listTenHocHamHocViVienChuc;
            _view.CBXTenHocHamHocViN.Properties.DisplayMember = "tenHocHamHocVi";
            _view.CBXTenHocHamHocViN.Properties.ValueMember = "idHocHamHocViVienChuc";
            _view.CBXTenHocHamHocViN.Properties.DropDownRows = listTenHocHamHocViVienChuc.Count;
            _view.CBXTenHocHamHocViN.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("idHocHamHocViVienChuc", ""));
            _view.CBXTenHocHamHocViN.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tenHocHamHocVi", ""));
            _view.CBXTenHocHamHocViN.Properties.Columns[0].Visible = false;
            List<string> listPhanLoai = new List<string>() { "Vừa học vừa dạy", "Chỉ học", "Chỉ dạy" };
            _view.CBXPhanLoaiN.Properties.DataSource = listPhanLoai;
            _view.CBXPhanLoaiN.Properties.DropDownRows = listPhanLoai.Count;
        }
        private void LoadCbxDataCC()
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            List<LoaiChungChi> listLoaiChungChi = unitOfWorks.LoaiChungChiRepository.GetListLoaiChungChi().ToList();
            _view.CBXLoaiChungChi.Properties.DataSource = listLoaiChungChi;
            _view.CBXLoaiChungChi.Properties.DisplayMember = "tenLoaiChungChi";
            _view.CBXLoaiChungChi.Properties.ValueMember = "idLoaiChungChi";
            _view.CBXLoaiChungChi.Properties.DropDownRows = listLoaiChungChi.Count;
            _view.CBXLoaiChungChi.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("idLoaiChungChi", ""));
            _view.CBXLoaiChungChi.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tenLoaiChungChi", ""));
            _view.CBXLoaiChungChi.Properties.Columns[0].Visible = false;

            _view.CBXCapDoChungChi.Properties.DataSource = listLoaiChungChi;
            _view.CBXCapDoChungChi.Properties.DisplayMember = "capDo";
            _view.CBXCapDoChungChi.Properties.ValueMember = "idLoaiChungChi";
            _view.CBXCapDoChungChi.Properties.DropDownRows = listLoaiChungChi.Count;
            _view.CBXCapDoChungChi.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("idLoaiChungChi", ""));
            _view.CBXCapDoChungChi.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("capDo", ""));
            _view.CBXCapDoChungChi.Properties.Columns[0].Visible = false;
        }
        private void SetDefaultValueControlHHHV()
        {
            _view.CBXLoaiHocHamHocViHHHV.ErrorText = null;
            _view.CBXNganhDaoTaoHHHV.ErrorText = null;
            _view.CBXChuyenNganhHHHV.ErrorText = null;
            _view.CBXLoaiHocHamHocViHHHV.EditValue = null;
            _view.CBXNganhDaoTaoHHHV.EditValue = null;
            _view.CBXChuyenNganhHHHV.EditValue = null;
            _view.TXTTenHocHamHocViHHHV.Text = "";
            _view.TXTCoSoDaoTaoHHHV.Text = "";
            _view.TXTNgonNguDaoTaoHHHV.Text = "";
            _view.TXTHinhThucDaoTaoHHHV.Text = "";           
            _view.TXTNuocCapBangHHHV.Text = "";
            _view.DTNgayCapBang.EditValue = null;
            _view.TXTLinkVanBanDinhKemHHHV.Text = "";
        }
        private void SetDefaultValueControlDHNC()
        {
            _view.CBXLoaiHocHamHocViDHNC.ErrorText = null;
            _view.CBXLoai.ErrorText = null;
            _view.CBXLoaiHocHamHocViDHNC.EditValue = null;
            _view.CBXLoai.EditValue = null;
            _view.TXTTenHocHamHocViDHNC.Text = "";
            _view.TXTCoSoDaoTaoDHNC.Text = "";
            _view.TXTNgonNguDaoTaoDHNC.Text = "";
            _view.TXTHinhThucDaoTaoDHNC.Text = "";
            _view.TXTNuocCapBangDHNC.Text = "";
            _view.DTNgayBatDauDHNC.EditValue = null;
            _view.DTNgayKetThucDHNC.EditValue = null;
            _view.TXTSoQuyetDinh.Text = "";
            _view.TXTLinkAnhQuyetDinh.Text = "";
        }
        private void SetDefaultValueControlN()
        {
            _view.CBXTenHocHamHocViN.ErrorText = null;
            _view.CBXNganhDaoTaoN.ErrorText = null;
            _view.CBXChuyenNganhN.ErrorText = null;
            _view.CBXPhanLoaiN.ErrorText = null;
            _view.CBXTenHocHamHocViN.EditValue = null;
            _view.CBXNganhDaoTaoN.EditValue = null;
            _view.CBXChuyenNganhN.EditValue = null;
            _view.CBXPhanLoaiN.EditValue = null;
            _view.DTNgayBatDauN.EditValue = null;
            _view.DTNgayKetThucN.EditValue = null;
            _view.TXTLinkVanBanDinhKemN.Text = "";
        }
        private void SetDefaultValueControlCC()
        {
            _view.CBXLoaiChungChi.ErrorText = null;
            _view.CBXCapDoChungChi.ErrorText = null;
            _view.CBXLoaiChungChi.EditValue = null;
            _view.CBXCapDoChungChi.EditValue = null;
            _view.TXTGhiChuCC.Text = "";
            _view.DTNgayCapChungChi.EditValue = null;
            _view.TXTLinkVanBanDinhKemCC.Text = "";
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
            XtraMessageBox.Show("Thêm dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadGridTabPageHocHamHocVi(_view.TXTMaVienChuc.Text);
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
            XtraMessageBox.Show("Thêm dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadGridTabPageDangHocNangCao(_view.TXTMaVienChuc.Text);
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
            XtraMessageBox.Show("Thêm dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadGridTabPageNganh(_view.TXTMaVienChuc.Text);
        }
        private void InsertDataCC()
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            string mavienchuc = _view.TXTMaVienChuc.Text;
            string loaichungchi = _view.CBXLoaiChungChi.Text;
            string capdo = _view.CBXCapDoChungChi.Text;
            int idloaichungchi = unitOfWorks.LoaiChungChiRepository.GetIdLoaiChungChi(loaichungchi, capdo);
            if(idloaichungchi > 0)
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
                XtraMessageBox.Show("Thêm dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGridTabPageChungChi(_view.TXTMaVienChuc.Text);
            }
            else XtraMessageBox.Show("Bạn chọn sai chứng chỉ hoặc cấp độ. Vui lòng chọn lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            XtraMessageBox.Show("Sửa dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadGridTabPageHocHamHocVi(_view.TXTMaVienChuc.Text);
        }
        private void UpdateDataDHNC()
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            int iddanghocnangcao = Convert.ToInt32(_view.GVDangHocNangCao.GetFocusedRowCellDisplayText("Id"));
            DangHocNangCao dangHocNangCao = unitOfWorks.DangHocNangCaoRepository.GetObjectById(iddanghocnangcao);
            dangHocNangCao.loai = unitOfWorks.HocHamHocViVienChucRepository.HardCodeBacToDatabase(_view.CBXLoai.EditValue.ToString());
            dangHocNangCao.tenHocHamHocVi = _view.TXTTenHocHamHocViDHNC.Text;
            dangHocNangCao.coSoDaoTao = _view.TXTCoSoDaoTaoDHNC.Text;
            dangHocNangCao.ngonNguDaoTao = _view.TXTNgonNguDaoTaoDHNC.Text;
            dangHocNangCao.hinhThucDaoTao = _view.TXTHinhThucDaoTaoDHNC.Text;
            dangHocNangCao.nuocCapBang = _view.TXTNuocCapBangDHNC.Text;
            dangHocNangCao.ngayBatDau = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayBatDauDHNC.Text);
            dangHocNangCao.ngayKetThuc = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayKetThucDHNC.Text);
            dangHocNangCao.soQuyetDinh = _view.TXTSoQuyetDinh.Text;
            dangHocNangCao.linkAnhQuyetDinh = _view.TXTLinkAnhQuyetDinh.Text;
            unitOfWorks.Save();
            XtraMessageBox.Show("Sửa dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadGridTabPageDangHocNangCao(_view.TXTMaVienChuc.Text);
        }
        private void UpdateDataN()
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            int idnganhvienchuc = Convert.ToInt32(_view.GVNganh.GetFocusedRowCellDisplayText("Id"));
            NganhVienChuc nganhVienChuc = unitOfWorks.NganhVienChucRepository.GetObjectById(idnganhvienchuc);
            nganhVienChuc.phanLoai = unitOfWorks.NganhVienChucRepository.HardCodePhanLoaiToDatabase(_view.CBXPhanLoaiN.EditValue.ToString());
            nganhVienChuc.ngayBatDau= unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayBatDauN.Text);
            nganhVienChuc.ngayKetThuc = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayKetThucN.Text);
            nganhVienChuc.linkVanBanDinhKem = _view.TXTLinkVanBanDinhKemN.Text;
            unitOfWorks.Save();
            XtraMessageBox.Show("Sửa dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadGridTabPageNganh(_view.TXTMaVienChuc.Text);
        }
        private void UpdateDataCC()
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            int idchungchivienchuc = Convert.ToInt32(_view.GVChungChi.GetFocusedRowCellDisplayText("Id"));
            ChungChiVienChuc chungChiVienChuc = unitOfWorks.ChungChiVienChucRepository.GetObjectById(idchungchivienchuc);
            chungChiVienChuc.ngayCapChungChi = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayCapChungChi.Text);
            chungChiVienChuc.ghiChu = _view.TXTGhiChuCC.Text;
            chungChiVienChuc.linkVanBanDinhKem = _view.TXTLinkVanBanDinhKemCC.Text;
        }
        private void Download(string linkvanbandinhkem)
        {
            if (linkvanbandinhkem != "")
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
            if (mavienchuc != "")
            {
                LoadGridTabPageHocHamHocVi(mavienchuc);
                LoadGridTabPageDangHocNangCao(mavienchuc);
                LoadGridTabPageNganh(mavienchuc);
                LoadGridTabPageChungChi(mavienchuc);
                if(_rowHandle >= 0)
                {
                    if(checkGrid == false)
                    {
                        _view.GVHocHamHocVi.FocusedRowHandle = _rowHandle;
                        ClickRowAndShowInfoHHHV();
                    }
                    else
                    {
                        _view.GVChungChi.FocusedRowHandle = _rowHandle;
                        ClickRowAndShowInfoCC();
                    }
                }
            }
        }
        //1
        public void ClickRowAndShowInfoHHHV()
        {
            _view.CBXLoaiHocHamHocViHHHV.ReadOnly = true;
            _view.CBXNganhDaoTaoHHHV.ReadOnly = true;
            _view.CBXChuyenNganhHHHV.ReadOnly = true;
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
            _view.CBXLoaiHocHamHocViHHHV.ReadOnly = false;
            _view.CBXNganhDaoTaoHHHV.ReadOnly = false;
            _view.CBXChuyenNganhHHHV.ReadOnly = false;
        }

        public void AddHHHV()
        {
            if (_view.TXTMaVienChuc.Text != "" && _mavienchuc == "")
            {
                if (_view.CBXLoaiHocHamHocViHHHV.Text != "" && _view.CBXNganhDaoTaoHHHV.Text != "" && _view.CBXChuyenNganhHHHV.Text != "")
                {
                    InsertDataHHHV();
                }
                if(_view.CBXLoaiHocHamHocViHHHV.Text == "")
                {
                    _view.CBXLoaiHocHamHocViHHHV.ErrorText = "Vui lòng chọn trình độ.";
                    _view.CBXLoaiHocHamHocViHHHV.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
                if (_view.CBXNganhDaoTaoHHHV.Text == "")
                {
                    _view.CBXNganhDaoTaoHHHV.ErrorText = "Vui lòng chọn ngành đào tạo.";
                    _view.CBXNganhDaoTaoHHHV.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
                if (_view.CBXChuyenNganhHHHV.Text == "")
                {
                    _view.CBXChuyenNganhHHHV.ErrorText = "Vui lòng chọn chuyên ngành.";
                    _view.CBXChuyenNganhHHHV.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
            }
            else if (_view.TXTMaVienChuc.Text == "" && _mavienchuc != "")
            {
                _view.TXTMaVienChuc.Text = _mavienchuc;
                if (_view.CBXLoaiHocHamHocViHHHV.Text != "" && _view.CBXNganhDaoTaoHHHV.Text != "" && _view.CBXChuyenNganhHHHV.Text != "")
                {
                    InsertDataHHHV();
                }
                if (_view.CBXLoaiHocHamHocViHHHV.Text == "")
                {
                    _view.CBXLoaiHocHamHocViHHHV.ErrorText = "Vui lòng chọn trình độ.";
                    _view.CBXLoaiHocHamHocViHHHV.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
                if (_view.CBXNganhDaoTaoHHHV.Text == "")
                {
                    _view.CBXNganhDaoTaoHHHV.ErrorText = "Vui lòng chọn ngành đào tạo.";
                    _view.CBXNganhDaoTaoHHHV.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
                if (_view.CBXChuyenNganhHHHV.Text == "")
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
        //2
        public void ClickRowAndShowInfoDHNC()
        {
            _view.CBXLoaiHocHamHocViDHNC.ReadOnly = true;
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
                _view.DTNgayBatDauDHNC.EditValue = _view.GVDangHocNangCao.GetFocusedRowCellDisplayText("NgayBatDau");
                _view.DTNgayKetThucDHNC.EditValue = _view.GVDangHocNangCao.GetFocusedRowCellDisplayText("NgayKetThuc");
                _view.TXTSoQuyetDinh.Text = _view.GVDangHocNangCao.GetFocusedRowCellDisplayText("SoQuyetDinh");
                _view.TXTLinkAnhQuyetDinh.Text = _view.GVDangHocNangCao.GetFocusedRowCellDisplayText("LinkAnhQuyetDinh");
            }
        }

        public void RefreshDHNC()
        {
            SetDefaultValueControlDHNC();
            _view.CBXLoaiHocHamHocViDHNC.ReadOnly = false;
        }

        public void AddDHNC()
        {
            if (_view.TXTMaVienChuc.Text != "" && _mavienchuc == "")
            {
                if (_view.CBXLoaiHocHamHocViDHNC.Text != "")
                {
                    InsertDataDHNC();
                }                
                else
                {
                    _view.CBXLoaiHocHamHocViDHNC.ErrorText = "Vui lòng chọn trình độ.";
                    _view.CBXLoaiHocHamHocViDHNC.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
            }
            else if (_view.TXTMaVienChuc.Text == "" && _mavienchuc != "")
            {
                _view.TXTMaVienChuc.Text = _mavienchuc;
                if (_view.CBXLoaiHocHamHocViDHNC.Text != "")
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

        public void EditDHNC()
        {
            int row_handle = _view.GVDangHocNangCao.FocusedRowHandle;
            if (row_handle >= 0)
            {
                UpdateDataDHNC();
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

        public void UploadFileToGoogleDriveDHNC()
        {
            if (_view.GVDangHocNangCao.FocusedRowHandle >= 0)
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
                            _view.TXTLinkAnhQuyetDinh.Text = "https://drive.google.com/open?id=" + id + "";
                        }
                        else
                        {
                            string[] split_filename = filename.Split('.');
                            string new_filename = split_filename[0] + "-" + mavienchuc + "-" + code + "." + split_filename[1];
                            FileInfo fileInfo = new FileInfo(filename);
                            fileInfo.MoveTo(new_filename);
                            unitOfWorks.GoogleDriveFileRepository.UploadFile(new_filename);
                            string id = unitOfWorks.GoogleDriveFileRepository.GetIdDriveFile(mavienchuc, code);
                            _view.TXTLinkAnhQuyetDinh.Text = "https://drive.google.com/open?id=" + id + "";
                        }
                        SplashScreenManager.CloseForm();
                        LoadGridTabPageDangHocNangCao(mavienchuc);
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
            string linkvanbandinhkem = _view.GVDangHocNangCao.GetFocusedRowCellDisplayText("LinkAnhQuyetDinh").ToString().Trim();
            Download(linkvanbandinhkem);
        }
        //3
        public void ClickRowAndShowInfoN()
        {
            _view.CBXNganhDaoTaoN.ReadOnly = true;
            _view.CBXChuyenNganhN.ReadOnly = true;
            _view.CBXTenHocHamHocViN.ReadOnly = true;
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
            _view.CBXNganhDaoTaoN.ReadOnly = false;
            _view.CBXChuyenNganhN.ReadOnly = false;
            _view.CBXTenHocHamHocViN.ReadOnly = false;
        }

        public void AddN()
        {
            if (_view.TXTMaVienChuc.Text != "" && _mavienchuc == "")
            {
                if (_view.CBXNganhDaoTaoN.Text != "" && _view.CBXChuyenNganhN.Text != "" && _view.CBXTenHocHamHocViN.Text != "")
                {
                    InsertDataN();
                }
                if(_view.CBXNganhDaoTaoN.Text == "")
                {
                    _view.CBXNganhDaoTaoN.ErrorText = "Vui lòng chọn ngành đào tạo.";
                    _view.CBXNganhDaoTaoN.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
                if (_view.CBXChuyenNganhN.Text == "")
                {
                    _view.CBXChuyenNganhN.ErrorText = "Vui lòng chọn chuyên ngành.";
                    _view.CBXChuyenNganhN.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
                if (_view.CBXTenHocHamHocViN.Text == "")
                {
                    _view.CBXTenHocHamHocViN.ErrorText = "Vui lòng chọn tên Học hàm/Học vị.";
                    _view.CBXTenHocHamHocViN.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
                if (_view.CBXPhanLoaiN.Text == "")
                {
                    _view.CBXTenHocHamHocViN.ErrorText = "Vui lòng chọn phân loại.";
                    _view.CBXTenHocHamHocViN.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
            }
            else if (_view.TXTMaVienChuc.Text == "" && _mavienchuc != "")
            {
                _view.TXTMaVienChuc.Text = _mavienchuc;
                if (_view.CBXNganhDaoTaoN.Text != "" && _view.CBXChuyenNganhN.Text != "" && _view.CBXTenHocHamHocViN.Text != "")
                {
                    InsertDataN();
                }
                if (_view.CBXNganhDaoTaoN.Text == "")
                {
                    _view.CBXNganhDaoTaoN.ErrorText = "Vui lòng chọn ngành đào tạo.";
                    _view.CBXNganhDaoTaoN.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
                if (_view.CBXChuyenNganhN.Text == "")
                {
                    _view.CBXChuyenNganhN.ErrorText = "Vui lòng chọn chuyên ngành.";
                    _view.CBXChuyenNganhN.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
                if (_view.CBXTenHocHamHocViN.Text == "")
                {
                    _view.CBXTenHocHamHocViN.ErrorText = "Vui lòng chọn tên Học hàm/Học vị.";
                    _view.CBXTenHocHamHocViN.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
                if (_view.CBXPhanLoaiN.Text == "")
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
        //4
        public void DownloadFileToDeviceCC()
        {
            string linkvanbandinhkem = _view.GVChungChi.GetFocusedRowCellDisplayText("LinkVanBanDinhKem").ToString().Trim();
            Download(linkvanbandinhkem);
        }
        
        public void ClickRowAndShowInfoCC()
        {
            _view.CBXLoaiChungChi.ReadOnly = true;
            _view.CBXCapDoChungChi.ReadOnly = true;
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            int row_handle = _view.GVChungChi.FocusedRowHandle;
            if (row_handle >= 0)
            {
                _view.CBXLoaiChungChi.EditValue = Convert.ToInt32(_view.GVChungChi.GetFocusedRowCellDisplayText("IdLoaiChungChi"));
                _view.CBXCapDoChungChi.EditValue = Convert.ToInt32(_view.GVChungChi.GetFocusedRowCellDisplayText("IdLoaiChungChi"));
                _view.DTNgayCapChungChi.EditValue = _view.GVChungChi.GetFocusedRowCellDisplayText("NgayCapChungChi");
                _view.TXTGhiChuCC.Text = _view.GVChungChi.GetFocusedRowCellDisplayText("GhiChu");
                _view.TXTLinkVanBanDinhKemCC.Text = _view.GVChungChi.GetFocusedRowCellDisplayText("LinkVanBanDinhKem");
            }
        }

        public void RefreshCC()
        {
            SetDefaultValueControlCC();
            _view.CBXCapDoChungChi.ReadOnly = false;
            _view.CBXLoaiChungChi.ReadOnly = false;
        }

        public void AddCC()
        {
            if (_view.TXTMaVienChuc.Text != "" && _mavienchuc == "")
            {
                if (_view.CBXLoaiChungChi.Text != "" && _view.CBXCapDoChungChi.Text != "")
                {
                    InsertDataCC();
                }
                if (_view.CBXLoaiChungChi.Text == "")
                {
                    _view.CBXLoaiChungChi.ErrorText = "Vui lòng chọn chứng chỉ.";
                    _view.CBXLoaiChungChi.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
                if (_view.CBXCapDoChungChi.Text == "")
                {
                    _view.CBXCapDoChungChi.ErrorText = "Vui lòng chọn cấp độ.";
                    _view.CBXCapDoChungChi.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
            }
            else if (_view.TXTMaVienChuc.Text == "" && _mavienchuc != "")
            {
                _view.TXTMaVienChuc.Text = _mavienchuc;
                if (_view.CBXLoaiChungChi.Text != "" && _view.CBXCapDoChungChi.Text != "")
                {
                    InsertDataCC();
                }
                if (_view.CBXLoaiChungChi.Text == "")
                {
                    _view.CBXLoaiChungChi.ErrorText = "Vui lòng chọn chứng chỉ.";
                    _view.CBXLoaiChungChi.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
                if (_view.CBXCapDoChungChi.Text == "")
                {
                    _view.CBXCapDoChungChi.ErrorText = "Vui lòng chọn cấp độ.";
                    _view.CBXCapDoChungChi.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
            }
            else XtraMessageBox.Show("Vui lòng thêm thông tin viên chức trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void EditCC()
        {
            int row_handle = _view.GVChungChi.FocusedRowHandle;
            if (row_handle >= 0)
            {
                UpdateDataCC();
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

        public void UploadFileToGoogleDriveCC()
        {
            if (_view.GVChungChi.FocusedRowHandle >= 0)
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
                            _view.TXTLinkVanBanDinhKemCC.Text = "https://drive.google.com/open?id=" + id + "";
                        }
                        else
                        {
                            string[] split_filename = filename.Split('.');
                            string new_filename = split_filename[0] + "-" + mavienchuc + "-" + code + "." + split_filename[1];
                            FileInfo fileInfo = new FileInfo(filename);
                            fileInfo.MoveTo(new_filename);
                            unitOfWorks.GoogleDriveFileRepository.UploadFile(new_filename);
                            string id = unitOfWorks.GoogleDriveFileRepository.GetIdDriveFile(mavienchuc, code);
                            _view.TXTLinkVanBanDinhKemCC.Text = "https://drive.google.com/open?id=" + id + "";
                        }
                        SplashScreenManager.CloseForm();
                        LoadGridTabPageChungChi(mavienchuc);
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
    }
}
