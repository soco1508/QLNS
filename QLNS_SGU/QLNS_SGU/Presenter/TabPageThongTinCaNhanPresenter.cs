using Model;
using QLNS_SGU.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;
using System.Globalization;

namespace QLNS_SGU.Presenter
{
    public interface ITabPageThongTinCaNhanPresenter : IPresenterArgument
    {
        void LoadForm();
        void Save();
        void SaveAndClose();
        void CheckedLaDangVienChanged(object sender, EventArgs e);
    }
    public class TabPageThongTinCaNhanPresenter : ITabPageThongTinCaNhanPresenter
    {
        private TabPageThongTinCaNhan _view;
        private bool checkAddNew = false;
        public object UI => _view;
        public TabPageThongTinCaNhanPresenter(TabPageThongTinCaNhan view) => _view = view;
        public void Initialize(string mavienchuc)
        {
            _view.Attach(this);
            if(mavienchuc == string.Empty)
            {
                checkAddNew = true;
                _view.TXTMaVienChuc.Enabled = true;
            }
            else
            {
                _view.TXTMaVienChuc.Text = mavienchuc;
                _view.TXTMaVienChuc.Enabled = false;
            }
        }
        private void LoadCbxData()
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            List<DanToc> listDanToc = unitOfWorks.DanTocRepository.GetListDanToc();
            _view.CBXDanToc.Properties.DataSource = listDanToc;
            _view.CBXDanToc.Properties.DisplayMember = "tenDanToc";
            _view.CBXDanToc.Properties.ValueMember = "idDanToc";
            _view.CBXDanToc.Properties.DropDownRows = listDanToc.Count;
            _view.CBXDanToc.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("idDanToc", string.Empty));
            _view.CBXDanToc.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tenDanToc", string.Empty));
            _view.CBXDanToc.Properties.Columns[0].Visible = false;
            List<TonGiao> listTonGiao = unitOfWorks.TonGiaoRepository.GetListTonGiao();
            _view.CBXTonGiao.Properties.DataSource = listTonGiao;
            _view.CBXTonGiao.Properties.DisplayMember = "tenTonGiao";
            _view.CBXTonGiao.Properties.ValueMember = "idTonGiao";
            _view.CBXTonGiao.Properties.DropDownRows = listTonGiao.Count;
            _view.CBXTonGiao.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("idTonGiao", string.Empty));
            _view.CBXTonGiao.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tenTonGiao", string.Empty));
            _view.CBXTonGiao.Properties.Columns[0].Visible = false;
            List<ChinhTri> listChinhTri = unitOfWorks.ChinhTriRepository.GetListChinhTri();
            _view.CBXChinhTri.Properties.DataSource = listChinhTri;
            _view.CBXChinhTri.Properties.DisplayMember = "tenChinhTri";
            _view.CBXChinhTri.Properties.ValueMember = "idChinhTri";
            _view.CBXChinhTri.Properties.DropDownRows = listChinhTri.Count;
            _view.CBXChinhTri.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("idChinhTri", string.Empty));
            _view.CBXChinhTri.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tenChinhTri", string.Empty));
            _view.CBXChinhTri.Properties.Columns[0].Visible = false;
            List<QuanLyNhaNuoc> listQuanLyNhaNuoc = unitOfWorks.QuanLyNhaNuocRepository.GetListQuanLyNhaNuoc();
            _view.CBXQuanLyNhaNuoc.Properties.DataSource = listQuanLyNhaNuoc;
            _view.CBXQuanLyNhaNuoc.Properties.DisplayMember = "tenQuanLyNhaNuoc";
            _view.CBXQuanLyNhaNuoc.Properties.ValueMember = "idQuanLyNhaNuoc";
            _view.CBXQuanLyNhaNuoc.Properties.DropDownRows = listQuanLyNhaNuoc.Count;
            _view.CBXQuanLyNhaNuoc.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("idQuanLyNhaNuoc", string.Empty));
            _view.CBXQuanLyNhaNuoc.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tenQuanLyNhaNuoc", string.Empty));
            _view.CBXQuanLyNhaNuoc.Properties.Columns[0].Visible = false;
        }
        private void SelectEmptyValueCbx()
        {            
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            _view.CBXDanToc.EditValue = unitOfWorks.DanTocRepository.SelectIdEmptyValue();
            _view.CBXTonGiao.EditValue = unitOfWorks.TonGiaoRepository.SelectIdEmptyValue(x => x.tenTonGiao == string.Empty);
            _view.CBXQuanLyNhaNuoc.EditValue = unitOfWorks.QuanLyNhaNuocRepository.SelectIdEmptyValue();
            _view.CBXChinhTri.EditValue = unitOfWorks.ChinhTriRepository.SelectIdEmptyValue();
        }
        private byte[] ConvertImageToBinary(string filename)
        {
            byte[] img = null;
            if (filename == string.Empty)
            {
                return img;
            }
            else
            {
                FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);
                return img;
            }
        }
        private System.Drawing.Image ConvertBinaryToImage(byte[] img)
        {
            if (img == null) return null;
            else
            {
                MemoryStream ms = new MemoryStream(img);
                return System.Drawing.Image.FromStream(ms);
            }
        }
        private void InsertData()
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            List<string> listMaVienChuc = unitOfWorks.VienChucRepository.GetListMaVienChuc();
            string mavienchuc = _view.TXTMaVienChuc.Text.Trim();
            if (listMaVienChuc.Any(x => x == mavienchuc) == false)
            {
                unitOfWorks.VienChucRepository.Insert(new VienChuc
                {
                    maVienChuc = mavienchuc,
                    gioiTinh = unitOfWorks.VienChucRepository.ReturnGenderToDatabase(_view.RADGioiTinh.SelectedIndex),
                    ho = _view.TXTHo.Text.Trim(),
                    ten = _view.TXTTen.Text.Trim(),
                    ngaySinh = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgaySinh.Text),
                    ngayThamGiaCongTac = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayThamGiaCongTac.Text),
                    ngayVeTruong = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayVeTruong.Text),
                    ngayVaoNganh = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayVaoNganh.Text),
                    ngayVaoDang = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayVaoDang.Text),
                    laDangVien = _view.CHKLaDangVien.Checked,
                    sDT = _view.TXTSoDienThoai.Text,
                    noiSinh = _view.TXTNoiSinh.Text,
                    queQuan = _view.TXTQueQuan.Text,
                    idDanToc = Convert.ToInt32(_view.CBXDanToc.EditValue),
                    idTonGiao = Convert.ToInt32(_view.CBXTonGiao.EditValue),
                    vanHoa = _view.TXTVanHoa.Text,
                    idChinhTri = Convert.ToInt32(_view.CBXChinhTri.EditValue),
                    idQuanLyNhaNuoc = Convert.ToInt32(_view.CBXQuanLyNhaNuoc.EditValue),
                    hoKhauThuongTru = _view.TXTHoKhauThuongTru.Text,
                    noiOHienNay = _view.TXTNoiOHienNay.Text,
                    ghiChu = _view.TXTGhiChu.Text,
                    anh = ConvertImageToBinary(_view.PICVienChuc.GetLoadedImageLocation())
                });
                unitOfWorks.ChucVuDonViVienChucRepository.Insert(new ChucVuDonViVienChuc
                {
                    idVienChuc = unitOfWorks.VienChucRepository.GetIdVienChuc(mavienchuc),
                    idChucVu = unitOfWorks.ChucVuRepository.GetIdChucVu(string.Empty),
                    idDonVi = unitOfWorks.DonViRepository.GetIdDonVi(string.Empty),
                    idToChuyenMon = unitOfWorks.ToChuyenMonRepository.GetIdToChuyenMon(string.Empty, string.Empty),
                    ngayBatDau = Convert.ToDateTime("01/01/2000")
                });
                unitOfWorks.Save();
                MainPresenter.LoadDataToMainGrid();
                MainPresenter.MoveRowManaging(mavienchuc);
                XtraMessageBox.Show("Lưu dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TabPageQuaTrinhCongTacPresenter.maVienChucFromTabPageThongTinCaNhan = _view.TXTMaVienChuc.Text;
                TabPageQuaTrinhLuongPresenter.maVienChucFromTabPageThongTinCaNhan = _view.TXTMaVienChuc.Text;
                TabPageChuyenMonPresenter.maVienChucFromTabPageThongTinCaNhan = _view.TXTMaVienChuc.Text;
                TabPageTrangThaiPresenter.maVienChucFromTabPageThongTinCaNhan = _view.TXTMaVienChuc.Text;           
                _view.TXTMaVienChuc.Enabled = false;                
            }
            else
            {
                XtraMessageBox.Show("Mã viên chức đã tồn tại. Vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateData()
        {
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            string mavienchuc = _view.TXTMaVienChuc.Text.Trim();
            VienChuc vienChuc = unitOfWorks.VienChucRepository.GetVienChucByMaVienChuc(mavienchuc);
            vienChuc.ho = _view.TXTHo.Text;
            vienChuc.ten = _view.TXTTen.Text;
            vienChuc.gioiTinh = unitOfWorks.VienChucRepository.ReturnGenderToDatabase(_view.RADGioiTinh.SelectedIndex);
            vienChuc.ngaySinh = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgaySinh.Text);
            vienChuc.ngayThamGiaCongTac = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayThamGiaCongTac.Text);
            vienChuc.ngayVeTruong = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayVeTruong.Text);
            vienChuc.ngayVaoNganh = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayVaoNganh.Text);
            vienChuc.laDangVien = _view.CHKLaDangVien.Checked;
            vienChuc.ngayVaoDang = unitOfWorks.HopDongVienChucRepository.ReturnDateTimeToDatabase(_view.DTNgayVaoDang.Text);
            vienChuc.sDT = _view.TXTSoDienThoai.Text;
            vienChuc.noiSinh = _view.TXTNoiSinh.Text;
            vienChuc.queQuan = _view.TXTQueQuan.Text;
            vienChuc.idDanToc = Convert.ToInt32(_view.CBXDanToc.EditValue);
            vienChuc.idTonGiao = Convert.ToInt32(_view.CBXTonGiao.EditValue);
            vienChuc.vanHoa = _view.TXTVanHoa.Text;
            vienChuc.idChinhTri = Convert.ToInt32(_view.CBXChinhTri.EditValue);
            vienChuc.idQuanLyNhaNuoc = Convert.ToInt32(_view.CBXQuanLyNhaNuoc.EditValue);
            vienChuc.hoKhauThuongTru = _view.TXTHoKhauThuongTru.Text;
            vienChuc.noiOHienNay = _view.TXTNoiOHienNay.Text;
            vienChuc.ghiChu = _view.TXTGhiChu.Text;
            vienChuc.anh = ConvertImageToBinary(_view.PICVienChuc.GetLoadedImageLocation());
            unitOfWorks.Save();
            MainPresenter.LoadDataToMainGrid();
            MainPresenter.MoveRowManaging(mavienchuc);
            XtraMessageBox.Show("Cập nhật dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);            
        }

        public void LoadForm()
        {
            LoadCbxData();
            string mavienchuc = _view.TXTMaVienChuc.Text;
            UnitOfWorks unitOfWorks = new UnitOfWorks(new QLNSSGU_1Entities());
            if (mavienchuc != string.Empty)
            {
                VienChuc vienChuc = unitOfWorks.VienChucRepository.GetVienChucByMaVienChuc(mavienchuc);
                _view.PICVienChuc.Image = ConvertBinaryToImage(vienChuc.anh);
                _view.RADGioiTinh.SelectedIndex = unitOfWorks.VienChucRepository.ReturnGenderToTabThongTinCaNhan(vienChuc.gioiTinh);
                _view.TXTHo.Text = vienChuc.ho;
                _view.TXTTen.Text = vienChuc.ten;
                _view.DTNgaySinh.EditValue = vienChuc.ngaySinh;
                _view.DTNgayThamGiaCongTac.EditValue = vienChuc.ngayThamGiaCongTac;
                _view.DTNgayVeTruong.EditValue = vienChuc.ngayVeTruong;
                _view.DTNgayVaoNganh.EditValue = vienChuc.ngayVaoNganh;
                _view.TXTSoDienThoai.Text = vienChuc.sDT;
                _view.TXTNoiSinh.Text = vienChuc.noiSinh;
                _view.TXTQueQuan.Text = vienChuc.queQuan;
                _view.TXTHoKhauThuongTru.Text = vienChuc.hoKhauThuongTru;
                _view.TXTNoiOHienNay.Text = vienChuc.noiOHienNay;
                _view.CHKLaDangVien.Checked = (bool)vienChuc.laDangVien;
                _view.DTNgayVaoDang.EditValue = vienChuc.ngayVaoDang;
                _view.TXTVanHoa.Text = vienChuc.vanHoa;
                _view.CBXDanToc.EditValue = vienChuc.idDanToc;
                _view.CBXTonGiao.EditValue = vienChuc.idTonGiao;
                _view.CBXQuanLyNhaNuoc.EditValue = vienChuc.idQuanLyNhaNuoc;
                _view.CBXChinhTri.EditValue = vienChuc.idChinhTri;
                _view.TXTGhiChu.Text = vienChuc.ghiChu;
            }
            else
            {
                SelectEmptyValueCbx();
            }
        }

        public void Save()
        {
            string mavienchuc = _view.TXTMaVienChuc.Text;
            string ho = _view.TXTHo.Text;
            string ten = _view.TXTTen.Text;
            if(checkAddNew == true)
            {
                if(mavienchuc == string.Empty)
                {
                    _view.TXTMaVienChuc.ErrorText = "Vui lòng nhập Mã Viên Chức.";
                    _view.TXTMaVienChuc.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
                if (ho == string.Empty)
                {
                    _view.TXTHo.ErrorText = "Vui lòng nhập Họ.";
                    _view.TXTHo.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
                if (ten == string.Empty)
                {
                    _view.TXTTen.ErrorText = "Vui lòng nhập Tên.";
                    _view.TXTTen.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
                if(mavienchuc != string.Empty && ho != string.Empty && ten != string.Empty)
                {
                    InsertData();
                    checkAddNew = false;
                }                
            }
            else
            {
                if (mavienchuc == string.Empty)
                {
                    _view.TXTMaVienChuc.ErrorText = "Vui lòng nhập Mã Viên Chức.";
                    _view.TXTMaVienChuc.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
                if (ho == string.Empty)
                {
                    _view.TXTHo.ErrorText = "Vui lòng nhập Họ.";
                    _view.TXTHo.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
                if (ten == string.Empty)
                {
                    _view.TXTTen.ErrorText = "Vui lòng nhập Tên.";
                    _view.TXTTen.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
                if (mavienchuc != string.Empty && ho != string.Empty && ten != string.Empty)
                {
                    UpdateData();
                }
            }
        }
        
        public void SaveAndClose()
        {
            string mavienchuc = _view.TXTMaVienChuc.Text;
            string ho = _view.TXTHo.Text;
            string ten = _view.TXTTen.Text;
            if (checkAddNew == true)
            {
                if (mavienchuc == string.Empty)
                {
                    _view.TXTMaVienChuc.ErrorText = "Vui lòng nhập Mã Viên Chức.";
                    _view.TXTMaVienChuc.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
                if (ho == string.Empty)
                {
                    _view.TXTHo.ErrorText = "Vui lòng nhập Họ.";
                    _view.TXTHo.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
                if (ten == string.Empty)
                {
                    _view.TXTTen.ErrorText = "Vui lòng nhập Tên.";
                    _view.TXTTen.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
                if (mavienchuc != string.Empty && ho != string.Empty && ten != string.Empty)
                {
                    InsertData();
                    checkAddNew = false;
                    CreateAndEditPersonInfoPresenter.CloseForm();
                }
            }
            else
            {
                if (mavienchuc == string.Empty)
                {
                    _view.TXTMaVienChuc.ErrorText = "Vui lòng nhập Mã Viên Chức.";
                    _view.TXTMaVienChuc.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
                if (ho == string.Empty)
                {
                    _view.TXTHo.ErrorText = "Vui lòng nhập Họ.";
                    _view.TXTHo.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
                if (ten == string.Empty)
                {
                    _view.TXTTen.ErrorText = "Vui lòng nhập Tên.";
                    _view.TXTTen.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
                }
                if (mavienchuc != string.Empty && ho != string.Empty && ten != string.Empty)
                {
                    UpdateData();
                    CreateAndEditPersonInfoPresenter.CloseForm();
                }
            }
        }

        public void CheckedLaDangVienChanged(object sender, EventArgs e)
        {
            if(_view.CHKLaDangVien.Checked == false)
            {
                _view.DTNgayVaoDang.Text = string.Empty;
            }
        }
    }
}
