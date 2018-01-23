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
using DevExpress.XtraEditors;

namespace QLNS_SGU.Presenter
{
    public interface IExportDataPresenter : IPresenter
    {
        void ExportExcel();
        void CheckAllAndUncheckAll();
        void EnableFilterDatetime(object sender, EventArgs e);
        void Cancel();
        void ExportData();
        void RowIndicator(object sender, RowIndicatorCustomDrawEventArgs e);
        void CHKCongTacChanged(object sender, EventArgs e);
        void CHKQuaTrinhLuongChanged(object sender, EventArgs e);
        void CHKHopDongChanged(object sender, EventArgs e);
        void CHKTrangThaiChanged(object sender, EventArgs e);
        void CHKNganhHocChanged(object sender, EventArgs e);
        void CHKNganhDayChanged(object sender, EventArgs e);
        void CHKChungChiChanged(object sender, EventArgs e);
        void CHKDangHocNangCaoChanged(object sender, EventArgs e);
        void CHKThongTinCaNhanChanged(object sender, EventArgs e);
    }
    public class ExportDataPresenter : IExportDataPresenter
    {
        private ExportDataForm _view;
        private bool checkAllState = false;
        private string FilterCurrent = "";
        private List<bool> listCheckBoxValue = new List<bool> { false, false, false, false, false, false, false, false, false };
        public object UI => _view;
        public ExportDataPresenter(ExportDataForm view) => _view = view;
        public void Initialize()
        {
            _view.Attach(this);
            _view.GVCustom.IndicatorWidth = 50;
        }  
        private void UncheckAll()
        {
            _view.CHKThongTinCaNhan.Checked = false;
            _view.CHKCongTac.Checked = false;
            _view.CHKQuaTrinhLuong.Checked = false;
            _view.CHKHopDong.Checked = false;
            _view.CHKTrangThai.Checked = false;
            _view.CHKNganhHoc.Checked = false;
            _view.CHKNganhDay.Checked = false;
            _view.CHKChungChi.Checked = false;
            _view.CHKDangHocNangCao.Checked = false;
            checkAllState = false;
        }
        private void FormatDate(string fieldname)
        {
            _view.GVCustom.Columns[fieldname].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            _view.GVCustom.Columns[fieldname].DisplayFormat.FormatString = "dd/MM/yyyy";
        }
        private void SetCaptionColumn()
        {
            //Default
            _view.GVCustom.Columns["MaVienChuc"].Caption = "Mã viên chức";
            _view.GVCustom.Columns["Ho"].Caption = "Họ";
            _view.GVCustom.Columns["Ten"].Caption = "Tên";
            _view.GVCustom.Columns["GioiTinh"].Caption = "Giới tính";
            _view.GVCustom.Columns["DonVi"].Caption = "Đơn vị";
            _view.GVCustom.Columns["TrangThai"].Caption = "Trạng thái";
            //Vien chuc
            _view.GVCustom.Columns["SoDienThoai"].Caption = "Số điện thoại";           
            _view.GVCustom.Columns["NgaySinh"].Caption = "Ngày sinh";
            FormatDate("NgaySinh");
            _view.GVCustom.Columns["NoiSinh"].Caption = "Nơi sinh";
            _view.GVCustom.Columns["QueQuan"].Caption = "Quê quán";
            _view.GVCustom.Columns["DanToc"].Caption = "Dân tộc";
            _view.GVCustom.Columns["TonGiao"].Caption = "Tôn giáo";
            _view.GVCustom.Columns["HoKhauThuongTru"].Caption = "Hộ khẩu thường trú";
            _view.GVCustom.Columns["NoiOHienNay"].Caption = "Nơi ở hiện nay";
            _view.GVCustom.Columns["LaDangVien"].Caption = "Là đảng viên";
            _view.GVCustom.Columns["NgayVaoDang"].Caption = "Ngày vào đảng";
            FormatDate("NgayVaoDang");
            _view.GVCustom.Columns["NgayThamGiaCongTac"].Caption = "Ngày tham gia công tác";
            FormatDate("NgayThamGiaCongTac");
            _view.GVCustom.Columns["NgayVaoNganh"].Caption = "Ngày vào ngành";
            FormatDate("NgayVaoNganh");
            _view.GVCustom.Columns["NgayVeTruong"].Caption = "Ngày về trường";
            FormatDate("NgayVeTruong");
            _view.GVCustom.Columns["VanHoa"].Caption = "Văn hóa";
            _view.GVCustom.Columns["QuanLyNhaNuoc"].Caption = "Quản lý nhà nước";
            _view.GVCustom.Columns["ChinhTri"].Caption = "Chính trị";
            //Cong tac
            _view.GVCustom.Columns["LoaiChucVu"].Caption = "Loại chức vụ";
            _view.GVCustom.Columns["ChucVu"].Caption = "Chức vụ";
            _view.GVCustom.Columns["HeSoChucVu"].Caption = "Hệ số chức vụ";
            _view.GVCustom.Columns["LoaiDonVi"].Caption = "Loại đơn vị";            
            _view.GVCustom.Columns["DiaDiemCT"].Caption = "Địa điểm (Công tác)";
            _view.GVCustom.Columns["DiaChi"].Caption = "Địa chỉ";
            _view.GVCustom.Columns["SoDienThoaiDonVi"].Caption = "Số điện thoại đơn vị";
            _view.GVCustom.Columns["ToChuyenMon"].Caption = "Tổ chuyên môn";
            _view.GVCustom.Columns["PhanLoaiCongTac"].Caption = "Phân loại công tác";
            _view.GVCustom.Columns["CheckPhanLoaiCongTac"].Caption = "Phân loại (Công tác)";
            _view.GVCustom.Columns["NgayBatDauCT"].Caption = "Ngày bắt đầu (Công tác)";
            FormatDate("NgayBatDauCT");
            _view.GVCustom.Columns["NgayKetThucCT"].Caption = "Ngày kết thúc (Công tác)";
            FormatDate("NgayKetThucCT");
            _view.GVCustom.Columns["LoaiThayDoi"].Caption = "Loại thay đổi";
            _view.GVCustom.Columns["KiemNhiem"].Caption = "Kiêm nhiệm";
            _view.GVCustom.Columns["LinkVanBanDinhKemCT"].Caption = "Link văn bản đính kèm (Công tác)";
            //Qua trinh luong
            _view.GVCustom.Columns["MaNgach"].Caption = "Mã ngạch";
            _view.GVCustom.Columns["TenNgach"].Caption = "Tên ngạch";
            _view.GVCustom.Columns["HeSoVuotKhungBaNamDau"].Caption = "Hệ số vượt khung ba năm đầu";
            _view.GVCustom.Columns["HeSoVuotKhungTrenBaNam"].Caption = "Hệ số vượt khung trên ba năm";
            _view.GVCustom.Columns["ThoiHanNangBac"].Caption = "Thời hạn nâng bậc";
            _view.GVCustom.Columns["Bac"].Caption = "Bậc";
            _view.GVCustom.Columns["HeSoBac"].Caption = "Hệ số";
            _view.GVCustom.Columns["NgayBatDauQTL"].Caption = "Ngày bắt đầu (Quá trình lương)";
            FormatDate("NgayBatDauQTL");
            _view.GVCustom.Columns["NgayLenLuong"].Caption = "Ngày lên lương";
            FormatDate("NgayLenLuong");
            _view.GVCustom.Columns["LinkVanBanDinhKemQTL"].Caption = "Link văn bản đính kèm (Quá trình lương)";
            //Hop dong
            _view.GVCustom.Columns["MaHopDong"].Caption = "Mã hợp đồng";
            _view.GVCustom.Columns["TenHopDong"].Caption = "Hợp đồng";
            _view.GVCustom.Columns["NgayBatDauHD"].Caption = "Ngày bắt đầu (Hợp đồng)";
            FormatDate("NgayBatDauHD");
            _view.GVCustom.Columns["NgayKetThucHD"].Caption = "Ngày kết thúc (Hợp đồng)";
            FormatDate("NgayKetThucHD");
            _view.GVCustom.Columns["MoTaHD"].Caption = "Mô tả (Hợp đồng)";
            _view.GVCustom.Columns["LinkVanBanDinhKemHD"].Caption = "Link văn bản đính kèm (Hợp đồng)";
            //Trang thai            
            _view.GVCustom.Columns["MoTaTT"].Caption = "Mô tả (Trạng thái)";
            _view.GVCustom.Columns["DiaDiemTT"].Caption = "Địa điểm (Trạng thái)";
            _view.GVCustom.Columns["NgayBatDauTT"].Caption = "Ngày bắt đầu (Trạng thái)";
            FormatDate("NgayBatDauTT");
            _view.GVCustom.Columns["NgayKetThucTT"].Caption = "Ngày kết thúc (Trạng thái)";
            FormatDate("NgayKetThucTT");
            _view.GVCustom.Columns["LinkVanBanDinhKemTT"].Caption = "Link văn bản đính kèm (Trạng thái)";
            //Nganh hoc
            _view.GVCustom.Columns["NganhDaoTaoNH"].Caption = "Ngành đào tạo (Ngành học)";
            _view.GVCustom.Columns["ChuyenNganhNH"].Caption = "Chuyên ngành (Ngành học)";
            _view.GVCustom.Columns["LoaiHocHamHocViNH"].Caption = "Trình độ (Ngành học)";
            _view.GVCustom.Columns["TenHocHamHocViNH"].Caption = "Học hàm/Học vị (Ngành học)";
            _view.GVCustom.Columns["CoSoDaoTaoNH"].Caption = "Cơ sở đào tạo (Ngành học)";
            _view.GVCustom.Columns["NgonNguDaoTaoNH"].Caption = "Ngôn ngữ đào tạo (Ngành học)";
            _view.GVCustom.Columns["HinhThucDaoTaoNH"].Caption = "Hình thức đào tạo";
            _view.GVCustom.Columns["NuocCapBangNH"].Caption = "Nước cấp bằng (Ngành học)";
            _view.GVCustom.Columns["NgayCapBangNH"].Caption = "Ngày cấp bằng (Ngành học)";
            FormatDate("NgayCapBangNH");
            _view.GVCustom.Columns["LinkVanBanDinhKemHHHV_NH"].Caption = "Link văn bản đính kèm (Ngành học - Học hàm/Học vị)";
            _view.GVCustom.Columns["PhanLoaiNH"].Caption = "Phân loại (Ngành học)";
            _view.GVCustom.Columns["LinkVanBanDinhKemNH"].Caption = "Link văn bản đính kèm (Ngành học)";
            //Nganh day
            _view.GVCustom.Columns["NganhDaoTaoND"].Caption = "Ngành đào tạo (Ngành dạy)";
            _view.GVCustom.Columns["ChuyenNganhND"].Caption = "Chuyên ngành  (Ngành dạy)";
            _view.GVCustom.Columns["LoaiHocHamHocViND"].Caption = "Trình độ  (Ngành dạy)";
            _view.GVCustom.Columns["TenHocHamHocViND"].Caption = "Học hàm/Học vị (Ngành dạy)";
            _view.GVCustom.Columns["CoSoDaoTaoND"].Caption = "Cơ sở đào tạo (Ngành dạy)";
            _view.GVCustom.Columns["NgonNguDaoTaoND"].Caption = "Ngôn ngữ đào tạo (Ngành dạy)";
            _view.GVCustom.Columns["HinhThucDaoTaoND"].Caption = "Hình thức đào tạo (Ngành dạy)";
            _view.GVCustom.Columns["NuocCapBangND"].Caption = "Nước cấp bằng (Ngành dạy)";
            _view.GVCustom.Columns["NgayCapBangND"].Caption = "Ngày cấp bằng (Ngành dạy)";
            FormatDate("NgayCapBangND");
            _view.GVCustom.Columns["LinkVanBanDinhKemHHHV_ND"].Caption = "Link văn bản đính kèm (Ngành dạy - Học hàm/Học vị)";
            _view.GVCustom.Columns["PhanLoaiND"].Caption = "Phân loại (Ngành dạy)";
            _view.GVCustom.Columns["NgayBatDauND"].Caption = "Ngày bắt đầu (Ngành dạy)";
            FormatDate("NgayBatDauND");
            _view.GVCustom.Columns["NgayKetThucND"].Caption = "Ngày kết thúc (Ngành dạy)";
            FormatDate("NgayKetThucND");
            _view.GVCustom.Columns["LinkVanBanDinhKemND"].Caption = "Link văn bản đính kèm (Ngành dạy)";
            //Chung chi
            _view.GVCustom.Columns["NgoaiNgu"].Caption = "Ngoại ngữ";
            _view.GVCustom.Columns["CapDo"].Caption = "Cấp độ";
            _view.GVCustom.Columns["TinHoc"].Caption = "Tin học";
            _view.GVCustom.Columns["NVSP"].Caption = "NVSP";
            //Dang hoc nang cao
            _view.GVCustom.Columns["SoQuyetDinh"].Caption = "Số quyết định";
            _view.GVCustom.Columns["LinkAnhQuyetDinh"].Caption = "Link ảnh quyết định";
            _view.GVCustom.Columns["LoaiHocHamHocViDHNC"].Caption = "Trình độ (Đang học nâng cao)";
            _view.GVCustom.Columns["Loai"].Caption = "Loại (Đang học nâng cao)";
            _view.GVCustom.Columns["TenHocHamHocViDHNC"].Caption = "Học hàm/Học vị (Đang học nâng cao)";
            _view.GVCustom.Columns["CoSoDaoTaoDHNC"].Caption = "Cơ sở đào tạo (Đang học nâng cao)";
            _view.GVCustom.Columns["NgonNguDaoTaoDHNC"].Caption = "Ngôn ngữ đào tạo (Đang học nâng cao)";
            _view.GVCustom.Columns["HinhThucDaoTaoDHNC"].Caption = "Hình thức đào tạo (Đang học nâng cao)";
            _view.GVCustom.Columns["NuocCapBangDHNC"].Caption = "Nước cấp bằng (Đang học nâng cao)";
            _view.GVCustom.Columns["NgayBatDauDHNC"].Caption = "Ngày bắt đầu (Đang học nâng cao)";
            FormatDate("NgayBatDauDHNC");
            _view.GVCustom.Columns["NgayKetThucDHNC"].Caption = "Ngày kết thúc (Đang học nâng cao)";
            FormatDate("NgayKetThucDHNC");
        }
        private void GetDataPeriodOfTime()
        {
            FilterCurrent = _view.GVCustom.ActiveFilterString;
            SplashScreenManager.ShowForm(_view, typeof(WaitForm1), true, true, false, 0);
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            List<ExportObjects> list = new List<ExportObjects>();
            var listVienChuc = unitOfWorks.VienChucRepository.GetListVienChuc();
            DateTime dtFromPeriodOfTime = _view.DTFromPeriodOfTime.DateTime;
            DateTime dtToPeriodOfTime = _view.DTToPeriodOfTime.DateTime;
            foreach (var row in listVienChuc)
            {
                list.Add(new ExportObjects
                {
                    IdVienChuc = row.idVienChuc,
                    MaVienChuc = row.maVienChuc,
                    Ho = row.ho,
                    Ten = row.ten,
                    SoDienThoai = row.sDT,
                    GioiTinh = unitOfWorks.VienChucRepository.ReturnGenderToGrid(row.gioiTinh),
                    NgaySinh = row.ngaySinh,
                    NoiSinh = row.noiSinh,
                    QueQuan = row.queQuan,
                    DanToc = row.DanToc.tenDanToc,
                    TonGiao = row.TonGiao.tenTonGiao,
                    HoKhauThuongTru = row.hoKhauThuongTru,
                    NoiOHienNay = row.noiOHienNay,
                    LaDangVien = unitOfWorks.VienChucRepository.ReturnLaDangVienToGrid(row.laDangVien),
                    NgayVaoDang = row.ngayVaoDang,
                    NgayThamGiaCongTac = row.ngayThamGiaCongTac,
                    NgayVaoNganh = row.ngayVaoNganh,
                    NgayVeTruong = row.ngayVeTruong,
                    VanHoa = row.vanHoa,
                    QuanLyNhaNuoc = row.QuanLyNhaNuoc.tenQuanLyNhaNuoc,
                    ChinhTri = row.ChinhTri.tenChinhTri,
                    GhiChu = row.ghiChu
                });
            }
            if (_view.CHKCongTac.Checked)
            {
                foreach (var row in list)
                {
                    ChucVuDonViVienChuc chucVuDonViVienChuc = unitOfWorks.ChucVuDonViVienChucRepository.GetObjectByIdVienChucAndPeriodOfTime(row.IdVienChuc, dtFromPeriodOfTime, dtToPeriodOfTime);
                    if (chucVuDonViVienChuc != null)
                    {
                        ExportObjects exportObjects = list.Where(x => x.IdVienChuc == row.IdVienChuc).FirstOrDefault();
                        exportObjects.LoaiChucVu = chucVuDonViVienChuc.ChucVu.LoaiChucVu.tenLoaiChucVu;
                        exportObjects.ChucVu = chucVuDonViVienChuc.ChucVu.tenChucVu;
                        exportObjects.HeSoChucVu = chucVuDonViVienChuc.ChucVu.heSoChucVu;
                        exportObjects.LoaiDonVi = chucVuDonViVienChuc.DonVi.LoaiDonVi.tenLoaiDonVi;
                        exportObjects.DonVi = chucVuDonViVienChuc.DonVi.tenDonVi;
                        exportObjects.DiaDiemCT = chucVuDonViVienChuc.DonVi.diaDiem;
                        exportObjects.DiaChi = chucVuDonViVienChuc.DonVi.diaChi;
                        exportObjects.SoDienThoaiDonVi = chucVuDonViVienChuc.DonVi.sDT;
                        exportObjects.ToChuyenMon = chucVuDonViVienChuc.ToChuyenMon.tenToChuyenMon;
                        exportObjects.PhanLoaiCongTac = chucVuDonViVienChuc.phanLoaiCongTac;
                        exportObjects.CheckPhanLoaiCongTac = unitOfWorks.ChucVuDonViVienChucRepository.HardCheckPhanLoaiCongTacToGrid(chucVuDonViVienChuc.checkPhanLoaiCongTac);
                        exportObjects.NgayBatDauCT = chucVuDonViVienChuc.ngayBatDau;
                        exportObjects.NgayKetThucCT = chucVuDonViVienChuc.ngayKetThuc;
                        exportObjects.LoaiThayDoi = unitOfWorks.ChucVuDonViVienChucRepository.HardLoaiThayDoiToGrid(chucVuDonViVienChuc.loaiThayDoi);
                        exportObjects.KiemNhiem = unitOfWorks.ChucVuDonViVienChucRepository.HardKiemNhiemToGrid(chucVuDonViVienChuc.kiemNhiem);
                        exportObjects.LinkVanBanDinhKemCT = chucVuDonViVienChuc.linkVanBanDinhKem;
                    }
                }
            }
            if (_view.CHKQuaTrinhLuong.Checked)
            {
                foreach (var row in list)
                {
                    QuaTrinhLuong quaTrinhLuong = unitOfWorks.QuaTrinhLuongRepository.GetObjectByIdVienChucAndPeriodOfTime(row.IdVienChuc, dtFromPeriodOfTime, dtToPeriodOfTime);
                    if (quaTrinhLuong != null)
                    {
                        ExportObjects exportObjects = list.Where(x => x.IdVienChuc == row.IdVienChuc).FirstOrDefault();
                        exportObjects.MaNgach = quaTrinhLuong.Bac.Ngach.maNgach;
                        exportObjects.TenNgach = quaTrinhLuong.Bac.Ngach.tenNgach;
                        exportObjects.HeSoVuotKhungBaNamDau = quaTrinhLuong.Bac.Ngach.heSoVuotKhungBaNamDau;
                        exportObjects.HeSoVuotKhungTrenBaNam = quaTrinhLuong.Bac.Ngach.heSoVuotKhungTrenBaNam;
                        exportObjects.ThoiHanNangBac = quaTrinhLuong.Bac.Ngach.thoiHanNangBac;
                        exportObjects.Bac = quaTrinhLuong.Bac.bac1;
                        exportObjects.HeSoBac = quaTrinhLuong.Bac.heSoBac;
                        exportObjects.NgayBatDauQTL = quaTrinhLuong.ngayBatDau;
                        exportObjects.NgayLenLuong = quaTrinhLuong.ngayLenLuong;
                        exportObjects.LinkVanBanDinhKemQTL = quaTrinhLuong.linkVanBanDinhKem;
                    }
                }
            }
            if (_view.CHKHopDong.Checked)
            {
                foreach (var row in list)
                {
                    HopDongVienChuc hopDong = unitOfWorks.HopDongVienChucRepository.GetObjectByIdVienChucAndPeriodOfTime(row.IdVienChuc, dtFromPeriodOfTime, dtToPeriodOfTime);
                    if (hopDong != null)
                    {
                        ExportObjects exportObjects = list.Where(x => x.IdVienChuc == row.IdVienChuc).FirstOrDefault();
                        exportObjects.MaHopDong = hopDong.LoaiHopDong.maLoaiHopDong;
                        exportObjects.TenHopDong = hopDong.LoaiHopDong.tenLoaiHopDong;
                        exportObjects.NgayBatDauHD = hopDong.ngayBatDau;
                        exportObjects.NgayKetThucHD = hopDong.ngayKetThuc;
                        exportObjects.MoTaHD = hopDong.moTa;
                        exportObjects.LinkVanBanDinhKemHD = hopDong.linkVanBanDinhKem;
                    }
                }
            }
            if (_view.CHKTrangThai.Checked)
            {
                foreach (var row in list)
                {
                    TrangThaiVienChuc trangThai = unitOfWorks.TrangThaiVienChucRepository.GetObjectByIdVienChucAndPeriodOfTime(row.IdVienChuc, dtFromPeriodOfTime, dtToPeriodOfTime);
                    if (trangThai != null)
                    {
                        ExportObjects exportObjects = list.Where(x => x.IdVienChuc == row.IdVienChuc).FirstOrDefault();
                        exportObjects.TrangThai = trangThai.TrangThai.tenTrangThai;
                        exportObjects.MoTaTT = trangThai.moTa;
                        exportObjects.DiaDiemTT = trangThai.diaDiem;
                        exportObjects.NgayBatDauTT = trangThai.ngayBatDau;
                        exportObjects.NgayKetThucTT = trangThai.ngayKetThuc;
                        exportObjects.LinkVanBanDinhKemTT = trangThai.linkVanBanDinhKem;
                    }
                }
            }
            if (_view.CHKNganhHoc.Checked)
            {
                foreach (var row in list)
                {
                    NganhVienChuc nganhHoc = unitOfWorks.NganhVienChucRepository.GetObjectNganhHocByIdVienChuc(row.IdVienChuc);
                    if (nganhHoc != null)
                    {
                        ExportObjects exportObjects = list.Where(x => x.IdVienChuc == row.IdVienChuc).FirstOrDefault();
                        exportObjects.NganhDaoTaoNH = nganhHoc.NganhDaoTao.tenNganhDaoTao;
                        exportObjects.ChuyenNganhNH = nganhHoc.ChuyenNganh.tenChuyenNganh;
                        exportObjects.LoaiHocHamHocViNH = nganhHoc.HocHamHocViVienChuc.LoaiHocHamHocVi.tenLoaiHocHamHocVi;
                        exportObjects.TenHocHamHocViNH = nganhHoc.HocHamHocViVienChuc.tenHocHamHocVi;
                        exportObjects.CoSoDaoTaoNH = nganhHoc.HocHamHocViVienChuc.coSoDaoTao;
                        exportObjects.NgonNguDaoTaoNH = nganhHoc.HocHamHocViVienChuc.ngonNguDaoTao;
                        exportObjects.HinhThucDaoTaoNH = nganhHoc.HocHamHocViVienChuc.hinhThucDaoTao;
                        exportObjects.NuocCapBangNH = nganhHoc.HocHamHocViVienChuc.nuocCapBang;
                        exportObjects.NgayCapBangNH = nganhHoc.HocHamHocViVienChuc.ngayCapBang;
                        exportObjects.LinkVanBanDinhKemHHHV_NH = nganhHoc.HocHamHocViVienChuc.linkVanBanDinhKem;
                        exportObjects.PhanLoaiNH = unitOfWorks.NganhVienChucRepository.HardCodePhanLoaiToGrid(nganhHoc.phanLoai);
                        exportObjects.LinkVanBanDinhKemNH = nganhHoc.linkVanBanDinhKem;
                    }
                }
            }
            if (_view.CHKNganhDay.Checked)
            {
                foreach (var row in list)
                {
                    NganhVienChuc nganhDay = unitOfWorks.NganhVienChucRepository.GetObjectByIdVienChucAndPeriodOfTime(row.IdVienChuc, dtFromPeriodOfTime, dtToPeriodOfTime);
                    if (nganhDay != null)
                    {
                        ExportObjects exportObjects = list.Where(x => x.IdVienChuc == row.IdVienChuc).FirstOrDefault();
                        exportObjects.NganhDaoTaoND = nganhDay.NganhDaoTao.tenNganhDaoTao;
                        exportObjects.ChuyenNganhND = nganhDay.ChuyenNganh.tenChuyenNganh;
                        exportObjects.LoaiHocHamHocViND = nganhDay.HocHamHocViVienChuc.LoaiHocHamHocVi.tenLoaiHocHamHocVi;
                        exportObjects.TenHocHamHocViND = nganhDay.HocHamHocViVienChuc.tenHocHamHocVi;
                        exportObjects.CoSoDaoTaoND = nganhDay.HocHamHocViVienChuc.coSoDaoTao;
                        exportObjects.NgonNguDaoTaoND = nganhDay.HocHamHocViVienChuc.ngonNguDaoTao;
                        exportObjects.HinhThucDaoTaoND = nganhDay.HocHamHocViVienChuc.hinhThucDaoTao;
                        exportObjects.NuocCapBangND = nganhDay.HocHamHocViVienChuc.nuocCapBang;
                        exportObjects.NgayCapBangND = nganhDay.HocHamHocViVienChuc.ngayCapBang;
                        exportObjects.LinkVanBanDinhKemHHHV_ND = nganhDay.HocHamHocViVienChuc.linkVanBanDinhKem;
                        exportObjects.PhanLoaiND = unitOfWorks.NganhVienChucRepository.HardCodePhanLoaiToGrid(nganhDay.phanLoai);
                        exportObjects.NgayBatDauND = nganhDay.ngayBatDau;
                        exportObjects.NgayKetThucND = nganhDay.ngayKetThuc;
                        exportObjects.LinkVanBanDinhKemND = nganhDay.linkVanBanDinhKem;
                    }
                }
            }
            if (_view.CHKChungChi.Checked)
            {
                foreach (var row in list)
                {
                    ChungChiVienChuc chungChi = unitOfWorks.ChungChiVienChucRepository.GetObjectByIdVienChuc(row.IdVienChuc);
                    if (chungChi != null)
                    {
                        ExportObjects exportObjects = list.Where(x => x.IdVienChuc == row.IdVienChuc).FirstOrDefault();
                        if (chungChi.LoaiChungChi.tenLoaiChungChi.Contains("Nghiệp vụ sư phạm"))
                        {
                            if (chungChi.ngayCapChungChi != null)
                            {
                                exportObjects.NVSP = chungChi.LoaiChungChi.capDo + ", " + chungChi.ngayCapChungChi.Value.ToShortDateString();
                            }
                            else exportObjects.NVSP = chungChi.LoaiChungChi.capDo;
                        }
                        if (chungChi.LoaiChungChi.tenLoaiChungChi.Contains("Tin học"))
                        {
                            if (chungChi.ngayCapChungChi != null)
                            {
                                exportObjects.TinHoc = chungChi.LoaiChungChi.capDo + ", " + chungChi.ngayCapChungChi.Value.ToShortDateString();
                            }
                            else exportObjects.TinHoc = chungChi.LoaiChungChi.capDo;
                        }
                        if (!chungChi.LoaiChungChi.tenLoaiChungChi.Contains("Nghiệp vụ sư phạm") && !chungChi.LoaiChungChi.tenLoaiChungChi.Contains("Tin học"))
                        {
                            if (chungChi.ngayCapChungChi != null)
                            {
                                exportObjects.NgoaiNgu = chungChi.LoaiChungChi.tenLoaiChungChi;
                                exportObjects.CapDo = chungChi.LoaiChungChi.capDo + ", " + chungChi.ngayCapChungChi.Value.ToShortDateString();
                            }
                            else
                            {
                                exportObjects.NgoaiNgu = chungChi.LoaiChungChi.tenLoaiChungChi;
                                exportObjects.CapDo = chungChi.LoaiChungChi.capDo;
                            }
                        }
                    }
                }
            }
            if (_view.CHKDangHocNangCao.Checked)
            {
                foreach (var row in list)
                {
                    DangHocNangCao dangHocNangCao = unitOfWorks.DangHocNangCaoRepository.GetObjectByIdVienChucAndPeriodOfTime(row.IdVienChuc, dtFromPeriodOfTime, dtToPeriodOfTime);
                    if (dangHocNangCao != null)
                    {
                        ExportObjects exportObjects = list.Where(x => x.IdVienChuc == row.IdVienChuc).FirstOrDefault();
                        exportObjects.LoaiHocHamHocViDHNC = unitOfWorks.DangHocNangCaoRepository.HardCodeLoaiHocHamHocViToGrid(dangHocNangCao.LoaiHocHamHocVi.tenLoaiHocHamHocVi);
                        exportObjects.SoQuyetDinh = dangHocNangCao.soQuyetDinh;
                        exportObjects.LinkAnhQuyetDinh = dangHocNangCao.linkAnhQuyetDinh;
                        exportObjects.TenHocHamHocViDHNC = dangHocNangCao.tenHocHamHocVi;
                        exportObjects.CoSoDaoTaoDHNC = dangHocNangCao.coSoDaoTao;
                        exportObjects.NgonNguDaoTaoDHNC = dangHocNangCao.ngonNguDaoTao;
                        exportObjects.HinhThucDaoTaoDHNC = dangHocNangCao.hinhThucDaoTao;
                        exportObjects.NuocCapBangDHNC = dangHocNangCao.nuocCapBang;
                        exportObjects.NgayBatDauTT = dangHocNangCao.ngayBatDau;
                        exportObjects.NgayKetThucTT = dangHocNangCao.ngayKetThuc;
                        exportObjects.Loai = unitOfWorks.DangHocNangCaoRepository.HardCodeLoaiToGrid(dangHocNangCao.loai);
                    }
                }
            }
            _view.GCCustom.DataSource = null;
            _view.GCCustom.DataSource = list;
            _view.GVCustom.PopulateColumns();
            _view.GVCustom.Columns[0].Visible = false;
            SplashScreenManager.CloseForm(false);
            for (int i = 2; i < _view.GVCustom.Columns.Count; i++)
            {
                for (int j = 0; j < _view.GVCustom.RowCount; j++)
                {
                    if (_view.GVCustom.GetRowCellDisplayText(j, _view.GVCustom.Columns[i]) != "")
                    {
                        _view.GVCustom.Columns[i].Visible = true;
                        break;
                    }
                    else { _view.GVCustom.Columns[i].Visible = false; }
                }
            }
            SetCaptionColumn();
            if (_view.CHKSaveFilter.Checked)
                _view.GVCustom.ActiveFilterString = FilterCurrent;
        }
        private void GetDataTimeline()
        {
            FilterCurrent = _view.GVCustom.ActiveFilterString;
            SplashScreenManager.ShowForm(_view, typeof(WaitForm1), true, true, false, 0);
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            DateTime dtTimeline = _view.DTTimeline.DateTime;
            List<ExportObjects> listFieldsDefault = unitOfWorks.VienChucRepository.GetListFieldsDefaultByTimeline(dtTimeline);
            int tempIdVienChuc = -1;
            if (_view.CHKThongTinCaNhan.Checked)
            {
                foreach(var row in listFieldsDefault)
                {
                    VienChuc vienChuc = unitOfWorks.VienChucRepository.GetVienChucByIdVienChuc(row.IdVienChuc);
                    if (vienChuc != null)
                    {
                        ExportObjects exportObjects = listFieldsDefault.Where(x => x.IdVienChuc == row.IdVienChuc).FirstOrDefault();
                        exportObjects.SoDienThoai = vienChuc.sDT;
                        exportObjects.NgaySinh = vienChuc.ngaySinh;
                        exportObjects.NoiSinh = vienChuc.noiSinh;
                        exportObjects.QueQuan = vienChuc.queQuan;
                        exportObjects.DanToc = vienChuc.DanToc.tenDanToc;
                        exportObjects.TonGiao = vienChuc.TonGiao.tenTonGiao;
                        exportObjects.HoKhauThuongTru = vienChuc.hoKhauThuongTru;
                        exportObjects.NoiOHienNay = vienChuc.noiOHienNay;
                        exportObjects.LaDangVien = unitOfWorks.VienChucRepository.ReturnLaDangVienToGrid(vienChuc.laDangVien);
                        exportObjects.NgayVaoDang = vienChuc.ngayVaoDang;
                        exportObjects.NgayThamGiaCongTac = vienChuc.ngayThamGiaCongTac;
                        exportObjects.NgayVaoNganh = vienChuc.ngayVaoNganh;
                        exportObjects.NgayVeTruong = vienChuc.ngayVeTruong;
                        exportObjects.VanHoa = vienChuc.vanHoa;
                        exportObjects.QuanLyNhaNuoc = vienChuc.QuanLyNhaNuoc.tenQuanLyNhaNuoc;
                        exportObjects.ChinhTri = vienChuc.ChinhTri.tenChinhTri;
                        exportObjects.GhiChu = vienChuc.ghiChu;
                    }
                }
            }
            if (_view.CHKCongTac.Checked)
            {
                foreach (var row in listFieldsDefault.ToList())
                {
                    if(row.IdVienChuc != tempIdVienChuc)
                    {
                        tempIdVienChuc = row.IdVienChuc;
                        ExportObjects exportObjects = listFieldsDefault.Where(x => x.IdVienChuc == row.IdVienChuc && x.Index == row.Index).FirstOrDefault();
                        List<ChucVuDonViVienChuc> listCongTac = unitOfWorks.ChucVuDonViVienChucRepository.GetListCongTacByIdVienChucAndTimeline(row.IdVienChuc, dtTimeline);
                        if(listCongTac.Count > 1)
                        {
                            exportObjects.LoaiChucVu = listCongTac[0].ChucVu.LoaiChucVu.tenLoaiChucVu;
                            exportObjects.ChucVu = listCongTac[0].ChucVu.tenChucVu;
                            exportObjects.HeSoChucVu = listCongTac[0].ChucVu.heSoChucVu;
                            exportObjects.LoaiDonVi = listCongTac[0].DonVi.LoaiDonVi.tenLoaiDonVi;
                            //exportObjects.DonVi = listCongTac[0].DonVi.tenDonVi;
                            exportObjects.DiaDiemCT = listCongTac[0].DonVi.diaDiem;
                            exportObjects.DiaChi = listCongTac[0].DonVi.diaChi;
                            exportObjects.SoDienThoaiDonVi = listCongTac[0].DonVi.sDT;
                            exportObjects.ToChuyenMon = listCongTac[0].ToChuyenMon.tenToChuyenMon;
                            exportObjects.PhanLoaiCongTac = listCongTac[0].phanLoaiCongTac;
                            exportObjects.CheckPhanLoaiCongTac = unitOfWorks.ChucVuDonViVienChucRepository.HardCheckPhanLoaiCongTacToGrid(listCongTac[0].checkPhanLoaiCongTac);
                            exportObjects.NgayBatDauCT = listCongTac[0].ngayBatDau;
                            exportObjects.NgayKetThucCT = listCongTac[0].ngayKetThuc;
                            exportObjects.LoaiThayDoi = unitOfWorks.ChucVuDonViVienChucRepository.HardLoaiThayDoiToGrid(listCongTac[0].loaiThayDoi);
                            exportObjects.KiemNhiem = unitOfWorks.ChucVuDonViVienChucRepository.HardKiemNhiemToGrid(listCongTac[0].kiemNhiem);
                            exportObjects.LinkVanBanDinhKemCT = listCongTac[0].linkVanBanDinhKem;
                            for (int i = 1; i < listCongTac.Count; i++)
                            {
                                listFieldsDefault.Insert(row.Index + 1, new ExportObjects
                                {
                                    Index = row.Index + 1,
                                    IdVienChuc = row.IdVienChuc,
                                    MaVienChuc = row.MaVienChuc,
                                    Ho = row.Ho,
                                    Ten = row.Ten,
                                    GioiTinh = row.GioiTinh,
                                    DonVi = listCongTac[i].DonVi.tenDonVi,
                                    TrangThai = row.TrangThai,
                                    LoaiChucVu = listCongTac[i].ChucVu.LoaiChucVu.tenLoaiChucVu,
                                    ChucVu = listCongTac[i].ChucVu.tenChucVu,
                                    HeSoChucVu = listCongTac[i].ChucVu.heSoChucVu,
                                    LoaiDonVi = listCongTac[i].DonVi.LoaiDonVi.tenLoaiDonVi,
                                    DiaDiemCT = listCongTac[i].DonVi.diaDiem,
                                    DiaChi = listCongTac[i].DonVi.diaChi,
                                    SoDienThoaiDonVi = listCongTac[i].DonVi.sDT,
                                    ToChuyenMon = listCongTac[i].ToChuyenMon.tenToChuyenMon,
                                    PhanLoaiCongTac = listCongTac[i].phanLoaiCongTac,
                                    CheckPhanLoaiCongTac = unitOfWorks.ChucVuDonViVienChucRepository.HardCheckPhanLoaiCongTacToGrid(listCongTac[i].checkPhanLoaiCongTac),
                                    NgayBatDauCT = listCongTac[i].ngayBatDau,
                                    NgayKetThucCT = listCongTac[i].ngayKetThuc,
                                    LoaiThayDoi = unitOfWorks.ChucVuDonViVienChucRepository.HardLoaiThayDoiToGrid(listCongTac[i].loaiThayDoi),
                                    KiemNhiem = unitOfWorks.ChucVuDonViVienChucRepository.HardKiemNhiemToGrid(listCongTac[i].kiemNhiem),
                                    LinkVanBanDinhKemCT = listCongTac[i].linkVanBanDinhKem
                                });
                            }
                        }
                        if(listCongTac.Count == 1)
                        {
                            exportObjects.LoaiChucVu = listCongTac[0].ChucVu.LoaiChucVu.tenLoaiChucVu;
                            exportObjects.ChucVu = listCongTac[0].ChucVu.tenChucVu;
                            exportObjects.HeSoChucVu = listCongTac[0].ChucVu.heSoChucVu;
                            exportObjects.LoaiDonVi = listCongTac[0].DonVi.LoaiDonVi.tenLoaiDonVi;
                            //exportObjects.DonVi = listCongTac[0].DonVi.tenDonVi;
                            exportObjects.DiaDiemCT = listCongTac[0].DonVi.diaDiem;
                            exportObjects.DiaChi = listCongTac[0].DonVi.diaChi;
                            exportObjects.SoDienThoaiDonVi = listCongTac[0].DonVi.sDT;
                            exportObjects.ToChuyenMon = listCongTac[0].ToChuyenMon.tenToChuyenMon;
                            exportObjects.PhanLoaiCongTac = listCongTac[0].phanLoaiCongTac;
                            exportObjects.CheckPhanLoaiCongTac = unitOfWorks.ChucVuDonViVienChucRepository.HardCheckPhanLoaiCongTacToGrid(listCongTac[0].checkPhanLoaiCongTac);
                            exportObjects.NgayBatDauCT = listCongTac[0].ngayBatDau;
                            exportObjects.NgayKetThucCT = listCongTac[0].ngayKetThuc;
                            exportObjects.LoaiThayDoi = unitOfWorks.ChucVuDonViVienChucRepository.HardLoaiThayDoiToGrid(listCongTac[0].loaiThayDoi);
                            exportObjects.KiemNhiem = unitOfWorks.ChucVuDonViVienChucRepository.HardKiemNhiemToGrid(listCongTac[0].kiemNhiem);
                            exportObjects.LinkVanBanDinhKemCT = listCongTac[0].linkVanBanDinhKem;
                        }                        
                    } 
                    if(row.IdVienChuc == tempIdVienChuc)
                    {

                    }
                }
                tempIdVienChuc = -1; // tra ve gia tri mac dinh de su dung cho checkbox tiep theo
            }
            if (_view.CHKTrangThai.Checked)
            {
                foreach (var row in listFieldsDefault.ToList())
                {
                    ExportObjects exportObjects = listFieldsDefault.Where(x => x.IdVienChuc == row.IdVienChuc && x.Index == row.Index).FirstOrDefault();
                    List<TrangThaiVienChuc> listTrangThai = unitOfWorks.TrangThaiVienChucRepository.GetListTrangThaiByIdVienChucAndTimeline(row.IdVienChuc, dtTimeline);
                    if (row.IdVienChuc != tempIdVienChuc)
                    {
                        tempIdVienChuc = row.IdVienChuc;                        
                        if (listTrangThai.Count > 1)
                        {
                            exportObjects.MoTaTT = listTrangThai[0].moTa;
                            exportObjects.DiaDiemTT = listTrangThai[0].diaDiem;
                            exportObjects.NgayBatDauTT = listTrangThai[0].ngayBatDau;
                            exportObjects.NgayKetThucTT = listTrangThai[0].ngayKetThuc;
                            exportObjects.LinkVanBanDinhKemTT = listTrangThai[0].linkVanBanDinhKem;
                            for (int i = 1; i < listTrangThai.Count; i++)
                            {
                                
                                listFieldsDefault.Insert(row.Index + 1, new ExportObjects
                                {
                                    Index = row.Index + 1,
                                    IdVienChuc = row.IdVienChuc,
                                    MaVienChuc = row.MaVienChuc,
                                    Ho = row.Ho,
                                    Ten = row.Ten,
                                    GioiTinh = row.GioiTinh,
                                    DonVi = row.DonVi,
                                    TrangThai = listTrangThai[i].TrangThai.tenTrangThai,
                                    MoTaTT = listTrangThai[i].moTa,
                                    DiaDiemTT = listTrangThai[i].diaDiem,
                                    NgayBatDauTT = listTrangThai[i].ngayBatDau,
                                    NgayKetThucTT = listTrangThai[i].ngayKetThuc,
                                    LinkVanBanDinhKemTT = listTrangThai[i].linkVanBanDinhKem
                                });
                            }
                        }
                        if (listTrangThai.Count == 1)
                        {
                            exportObjects.MoTaTT = listTrangThai[0].moTa;
                            exportObjects.DiaDiemTT = listTrangThai[0].diaDiem;
                            exportObjects.NgayBatDauTT = listTrangThai[0].ngayBatDau;
                            exportObjects.NgayKetThucTT = listTrangThai[0].ngayKetThuc;
                            exportObjects.LinkVanBanDinhKemTT = listTrangThai[0].linkVanBanDinhKem;
                        }
                    }
                }
                tempIdVienChuc = -1;
            }
            //if (_view.CHKQuaTrinhLuong.Checked)
            //{
            //    foreach (var row in list)
            //    {
            //        QuaTrinhLuong quaTrinhLuong = unitOfWorks.QuaTrinhLuongRepository.GetObjectByIdVienChucAndTimeline(row.IdVienChuc, dtTimeline);
            //        if (quaTrinhLuong != null)
            //        {
            //            ExportObjects exportObjects = list.Where(x => x.IdVienChuc == row.IdVienChuc).FirstOrDefault();
            //            exportObjects.MaNgach = quaTrinhLuong.Bac.Ngach.maNgach;
            //            exportObjects.TenNgach = quaTrinhLuong.Bac.Ngach.tenNgach;
            //            exportObjects.HeSoVuotKhungBaNamDau = quaTrinhLuong.Bac.Ngach.heSoVuotKhungBaNamDau;
            //            exportObjects.HeSoVuotKhungTrenBaNam = quaTrinhLuong.Bac.Ngach.heSoVuotKhungTrenBaNam;
            //            exportObjects.ThoiHanNangBac = quaTrinhLuong.Bac.Ngach.thoiHanNangBac;
            //            exportObjects.Bac = quaTrinhLuong.Bac.bac1;
            //            exportObjects.HeSoBac = quaTrinhLuong.Bac.heSoBac;
            //            exportObjects.NgayBatDauQTL = quaTrinhLuong.ngayBatDau;
            //            exportObjects.NgayLenLuong = quaTrinhLuong.ngayLenLuong;
            //            exportObjects.LinkVanBanDinhKemQTL = quaTrinhLuong.linkVanBanDinhKem;
            //        }
            //    }
            //}
            //if (_view.CHKHopDong.Checked)
            //{
            //    foreach (var row in list)
            //    {
            //        HopDongVienChuc hopDong = unitOfWorks.HopDongVienChucRepository.GetObjectByIdVienChucAndTimeline(row.IdVienChuc, dtTimeline);
            //        if (hopDong != null)
            //        {
            //            ExportObjects exportObjects = list.Where(x => x.IdVienChuc == row.IdVienChuc).FirstOrDefault();
            //            exportObjects.MaHopDong = hopDong.LoaiHopDong.maLoaiHopDong;
            //            exportObjects.TenHopDong = hopDong.LoaiHopDong.tenLoaiHopDong;
            //            exportObjects.NgayBatDauHD = hopDong.ngayBatDau;
            //            exportObjects.NgayKetThucHD = hopDong.ngayKetThuc;
            //            exportObjects.MoTaHD = hopDong.moTa;
            //            exportObjects.LinkVanBanDinhKemHD = hopDong.linkVanBanDinhKem;
            //        }
            //    }
            //}



            //if (_view.CHKNganhHoc.Checked)
            //{
            //    foreach (var row in list)
            //    {
            //        NganhVienChuc nganhHoc = unitOfWorks.NganhVienChucRepository.GetObjectNganhHocByIdVienChuc(row.IdVienChuc);
            //        if (nganhHoc != null)
            //        {
            //            ExportObjects exportObjects = list.Where(x => x.IdVienChuc == row.IdVienChuc).FirstOrDefault();
            //            exportObjects.NganhDaoTaoNH = nganhHoc.NganhDaoTao.tenNganhDaoTao;
            //            exportObjects.ChuyenNganhNH = nganhHoc.ChuyenNganh.tenChuyenNganh;
            //            exportObjects.LoaiHocHamHocViNH = nganhHoc.HocHamHocViVienChuc.LoaiHocHamHocVi.tenLoaiHocHamHocVi;
            //            exportObjects.TenHocHamHocViNH = nganhHoc.HocHamHocViVienChuc.tenHocHamHocVi;
            //            exportObjects.CoSoDaoTaoNH = nganhHoc.HocHamHocViVienChuc.coSoDaoTao;
            //            exportObjects.NgonNguDaoTaoNH = nganhHoc.HocHamHocViVienChuc.ngonNguDaoTao;
            //            exportObjects.HinhThucDaoTaoNH = nganhHoc.HocHamHocViVienChuc.hinhThucDaoTao;
            //            exportObjects.NuocCapBangNH = nganhHoc.HocHamHocViVienChuc.nuocCapBang;
            //            exportObjects.NgayCapBangNH = nganhHoc.HocHamHocViVienChuc.ngayCapBang;
            //            exportObjects.LinkVanBanDinhKemHHHV_NH = nganhHoc.HocHamHocViVienChuc.linkVanBanDinhKem;
            //            exportObjects.PhanLoaiNH = unitOfWorks.NganhVienChucRepository.HardCodePhanLoaiToGrid(nganhHoc.phanLoai);
            //            exportObjects.LinkVanBanDinhKemNH = nganhHoc.linkVanBanDinhKem;
            //        }
            //    }
            //}
            //if (_view.CHKNganhDay.Checked)
            //{
            //    foreach (var row in list)
            //    {
            //        NganhVienChuc nganhDay = unitOfWorks.NganhVienChucRepository.GetObjectNganhDayByIdVienChucAndTimeline(row.IdVienChuc, dtTimeline);
            //        if (nganhDay != null)
            //        {
            //            ExportObjects exportObjects = list.Where(x => x.IdVienChuc == row.IdVienChuc).FirstOrDefault();
            //            exportObjects.NganhDaoTaoND = nganhDay.NganhDaoTao.tenNganhDaoTao;
            //            exportObjects.ChuyenNganhND = nganhDay.ChuyenNganh.tenChuyenNganh;
            //            exportObjects.LoaiHocHamHocViND = nganhDay.HocHamHocViVienChuc.LoaiHocHamHocVi.tenLoaiHocHamHocVi;
            //            exportObjects.TenHocHamHocViND = nganhDay.HocHamHocViVienChuc.tenHocHamHocVi;
            //            exportObjects.CoSoDaoTaoND = nganhDay.HocHamHocViVienChuc.coSoDaoTao;
            //            exportObjects.NgonNguDaoTaoND = nganhDay.HocHamHocViVienChuc.ngonNguDaoTao;
            //            exportObjects.HinhThucDaoTaoND = nganhDay.HocHamHocViVienChuc.hinhThucDaoTao;
            //            exportObjects.NuocCapBangND = nganhDay.HocHamHocViVienChuc.nuocCapBang;
            //            exportObjects.NgayCapBangND = nganhDay.HocHamHocViVienChuc.ngayCapBang;
            //            exportObjects.LinkVanBanDinhKemHHHV_ND = nganhDay.HocHamHocViVienChuc.linkVanBanDinhKem;
            //            exportObjects.PhanLoaiND = unitOfWorks.NganhVienChucRepository.HardCodePhanLoaiToGrid(nganhDay.phanLoai);
            //            exportObjects.NgayBatDauND = nganhDay.ngayBatDau;
            //            exportObjects.NgayKetThucND = nganhDay.ngayKetThuc;
            //            exportObjects.LinkVanBanDinhKemND = nganhDay.linkVanBanDinhKem;
            //        }
            //    }
            //}
            //if (_view.CHKChungChi.Checked)
            //{
            //    foreach (var row in list)
            //    {
            //        ChungChiVienChuc chungChi = unitOfWorks.ChungChiVienChucRepository.GetObjectByIdVienChuc(row.IdVienChuc);
            //        if (chungChi != null)
            //        {
            //            ExportObjects exportObjects = list.Where(x => x.IdVienChuc == row.IdVienChuc).FirstOrDefault();
            //            if (chungChi.LoaiChungChi.tenLoaiChungChi.Contains("Nghiệp vụ sư phạm"))
            //            {
            //                if (chungChi.ngayCapChungChi != null)
            //                {
            //                    exportObjects.NVSP = chungChi.LoaiChungChi.capDo + ", " + chungChi.ngayCapChungChi.Value.ToShortDateString();
            //                }
            //                else exportObjects.NVSP = chungChi.LoaiChungChi.capDo;
            //            }
            //            if (chungChi.LoaiChungChi.tenLoaiChungChi.Contains("Tin học"))
            //            {
            //                if (chungChi.ngayCapChungChi != null)
            //                {
            //                    exportObjects.TinHoc = chungChi.LoaiChungChi.capDo + ", " + chungChi.ngayCapChungChi.Value.ToShortDateString();
            //                }
            //                else exportObjects.TinHoc = chungChi.LoaiChungChi.capDo;
            //            }
            //            if (!chungChi.LoaiChungChi.tenLoaiChungChi.Contains("Nghiệp vụ sư phạm") && !chungChi.LoaiChungChi.tenLoaiChungChi.Contains("Tin học"))
            //            {
            //                if (chungChi.ngayCapChungChi != null)
            //                {
            //                    exportObjects.NgoaiNgu = chungChi.LoaiChungChi.tenLoaiChungChi;
            //                    exportObjects.CapDo = chungChi.LoaiChungChi.capDo + ", " + chungChi.ngayCapChungChi.Value.ToShortDateString();
            //                }
            //                else
            //                {
            //                    exportObjects.NgoaiNgu = chungChi.LoaiChungChi.tenLoaiChungChi;
            //                    exportObjects.CapDo = chungChi.LoaiChungChi.capDo;
            //                }
            //            }
            //        }
            //    }
            //}
            //if (_view.CHKDangHocNangCao.Checked)
            //{
            //    foreach (var row in list)
            //    {
            //        DangHocNangCao dangHocNangCao = unitOfWorks.DangHocNangCaoRepository.GetObjectByIdVienChucAndTimeline(row.IdVienChuc, dtTimeline);
            //        if (dangHocNangCao != null)
            //        {
            //            ExportObjects exportObjects = list.Where(x => x.IdVienChuc == row.IdVienChuc).FirstOrDefault();
            //            exportObjects.LoaiHocHamHocViDHNC = unitOfWorks.DangHocNangCaoRepository.HardCodeLoaiHocHamHocViToGrid(dangHocNangCao.LoaiHocHamHocVi.tenLoaiHocHamHocVi);
            //            exportObjects.SoQuyetDinh = dangHocNangCao.soQuyetDinh;
            //            exportObjects.LinkAnhQuyetDinh = dangHocNangCao.linkAnhQuyetDinh;
            //            exportObjects.TenHocHamHocViDHNC = dangHocNangCao.tenHocHamHocVi;
            //            exportObjects.CoSoDaoTaoDHNC = dangHocNangCao.coSoDaoTao;
            //            exportObjects.NgonNguDaoTaoDHNC = dangHocNangCao.ngonNguDaoTao;
            //            exportObjects.HinhThucDaoTaoDHNC = dangHocNangCao.hinhThucDaoTao;
            //            exportObjects.NuocCapBangDHNC = dangHocNangCao.nuocCapBang;
            //            exportObjects.NgayBatDauTT = dangHocNangCao.ngayBatDau;
            //            exportObjects.NgayKetThucTT = dangHocNangCao.ngayKetThuc;
            //            exportObjects.Loai = unitOfWorks.DangHocNangCaoRepository.HardCodeLoaiToGrid(dangHocNangCao.loai);
            //        }
            //    }
            //}
            _view.GCCustom.DataSource = null;
            _view.GCCustom.DataSource = listFieldsDefault;
            _view.GVCustom.PopulateColumns();
            _view.GVCustom.Columns[0].Visible = false;
            _view.GVCustom.Columns[1].Visible = false;
            _view.GVCustom.Columns[2].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            SplashScreenManager.CloseForm(false);
            for (int i = 2; i < _view.GVCustom.Columns.Count; i++)
            {
                for (int j = 0; j < _view.GVCustom.RowCount; j++)
                {
                    if (_view.GVCustom.GetRowCellDisplayText(j, _view.GVCustom.Columns[i]) != "")
                    {
                        _view.GVCustom.Columns[i].Visible = true;
                        break;
                    }
                    else _view.GVCustom.Columns[i].Visible = false;
                }
            }
            SetCaptionColumn();
            if (_view.CHKSaveFilter.Checked)
                _view.GVCustom.ActiveFilterString = FilterCurrent;
        }

        public void ExportExcel()
        {
            _view.SaveFileDialog.FileName = string.Empty;
            _view.SaveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (_view.SaveFileDialog.ShowDialog() == DialogResult.Cancel) return;
            _view.GVCustom.ExportToXlsx(_view.SaveFileDialog.FileName);
        }

        public void CheckAllAndUncheckAll()
        {            
            if(_view.CHKThongTinCaNhan.Checked == false && _view.CHKCongTac.Checked == false && 
               _view.CHKQuaTrinhLuong.Checked == false && _view.CHKHopDong.Checked == false &&
               _view.CHKTrangThai.Checked == false && _view.CHKNganhHoc.Checked == false &&
               _view.CHKNganhDay.Checked == false && _view.CHKChungChi.Checked == false && _view.CHKDangHocNangCao.Checked == false)
            {
                checkAllState = false;
            }
            if (checkAllState == false)
            {
                _view.CHKThongTinCaNhan.Checked = true;
                _view.CHKCongTac.Checked = true;
                _view.CHKQuaTrinhLuong.Checked = true;
                _view.CHKHopDong.Checked = true;
                _view.CHKTrangThai.Checked = true;
                _view.CHKNganhHoc.Checked = true;
                _view.CHKNganhDay.Checked = true;
                _view.CHKChungChi.Checked = true;
                _view.CHKDangHocNangCao.Checked = true;
                checkAllState = true;
            }
            else
            {
                UncheckAll();
            }
        }
        
        public void EnableFilterDatetime(object sender, EventArgs e)
        {
            if(_view.RADSelectTimeToFilter.SelectedIndex == 0)
            {
                _view.DTTimeline.Enabled = true;
                _view.DTFromPeriodOfTime.Enabled = false;
                _view.DTToPeriodOfTime.Enabled = false;
                _view.DTFromPeriodOfTime.EditValue = null;
                _view.DTToPeriodOfTime.EditValue = null;
            }
            else
            {
                _view.DTTimeline.Enabled = false;
                _view.DTFromPeriodOfTime.Enabled = true;
                _view.DTToPeriodOfTime.Enabled = true;
                _view.DTTimeline.EditValue = null;
            }
        }

        public void Cancel()
        {
            UncheckAll();
            _view.RADSelectTimeToFilter.SelectedIndex = 0;
            _view.DTTimeline.Enabled = true;
            _view.DTFromPeriodOfTime.Enabled = false;
            _view.DTToPeriodOfTime.Enabled = false;
            _view.DTTimeline.EditValue = null;
            _view.DTFromPeriodOfTime.EditValue = null;
            _view.DTToPeriodOfTime.EditValue = null;
            _view.DTTimeline.ErrorText = null;
            _view.DTFromPeriodOfTime.ErrorText = null;
            _view.DTToPeriodOfTime.ErrorText = null;
            _view.GCCustom.DataSource = null;
        }

        public void ExportData()
        {
            if (_view.RADSelectTimeToFilter.SelectedIndex == 0) //moc thoi gian
            {
                if (listCheckBoxValue.Any(x => x == true))
                {
                    if (_view.DTTimeline.Text != "")
                    {
                        GetDataTimeline();
                    }
                    else
                    {
                        _view.DTTimeline.ErrorText = "Vui lòng chọn thời gian.";
                        _view.DTTimeline.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                    }
                }
                else
                {
                    XtraMessageBox.Show("Vui lòng chọn Lĩnh vực.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else                                            //khoang thoi gian
            {
                if (listCheckBoxValue.Any(x => x == true))
                {
                    if (_view.DTFromPeriodOfTime.Text != "")
                    {
                        GetDataPeriodOfTime();
                    }
                    else
                    {
                        _view.DTFromPeriodOfTime.ErrorText = "Vui lòng chọn thời gian bắt đầu.";
                        _view.DTFromPeriodOfTime.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                    }
                }
                else
                {
                    XtraMessageBox.Show("Vui lòng chọn Lĩnh vực.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }  

        public void RowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        public void CHKThongTinCaNhanChanged(object sender, EventArgs e)
        {
            if (_view.CHKThongTinCaNhan.Checked)
            {
                listCheckBoxValue[0] = _view.CHKThongTinCaNhan.Checked;
            }
            else
            {
                listCheckBoxValue[0] = _view.CHKThongTinCaNhan.Checked;
            }
        }

        public void CHKCongTacChanged(object sender, EventArgs e)
        {
            if (_view.CHKCongTac.Checked)
            {
                listCheckBoxValue[1] = _view.CHKCongTac.Checked;
            }
            else
            {
                listCheckBoxValue[1] = _view.CHKCongTac.Checked;
            }
        }

        public void CHKQuaTrinhLuongChanged(object sender, EventArgs e)
        {
            if (_view.CHKQuaTrinhLuong.Checked)
            {
                listCheckBoxValue[2] = _view.CHKQuaTrinhLuong.Checked;
            }
            else
            {
                listCheckBoxValue[2] = _view.CHKQuaTrinhLuong.Checked;
            }
        }

        public void CHKHopDongChanged(object sender, EventArgs e)
        {
            if (_view.CHKHopDong.Checked)
            {
                listCheckBoxValue[3] = _view.CHKHopDong.Checked;
            }
            else
            {
                listCheckBoxValue[3] = _view.CHKHopDong.Checked;
            }
        }

        public void CHKTrangThaiChanged(object sender, EventArgs e)
        {
            if (_view.CHKTrangThai.Checked)
            {
                listCheckBoxValue[4] = _view.CHKTrangThai.Checked;
            }
            else
            {
                listCheckBoxValue[4] = _view.CHKTrangThai.Checked;
            }
        }

        public void CHKNganhHocChanged(object sender, EventArgs e)
        {
            if (_view.CHKNganhHoc.Checked)
            {
                listCheckBoxValue[5] = _view.CHKNganhHoc.Checked;
            }
            else
            {
                listCheckBoxValue[5] = _view.CHKNganhHoc.Checked;
            }
        }

        public void CHKNganhDayChanged(object sender, EventArgs e)
        {
            if (_view.CHKNganhDay.Checked)
            {
                listCheckBoxValue[6] = _view.CHKNganhDay.Checked;
            }
            else
            {
                listCheckBoxValue[6] = _view.CHKNganhDay.Checked;
            }
        }

        public void CHKChungChiChanged(object sender, EventArgs e)
        {
            if (_view.CHKChungChi.Checked)
            {
                listCheckBoxValue[7] = _view.CHKChungChi.Checked;
            }
            else
            {
                listCheckBoxValue[7] = _view.CHKChungChi.Checked;
            }
        }

        public void CHKDangHocNangCaoChanged(object sender, EventArgs e)
        {
            if (_view.CHKDangHocNangCao.Checked)
            {
                listCheckBoxValue[8] = _view.CHKDangHocNangCao.Checked;
            }
            else
            {
                listCheckBoxValue[8] = _view.CHKDangHocNangCao.Checked;
            }
        }
    }
}
