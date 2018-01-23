using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNS_SGU.View;
using System.Windows.Forms;
using DevExpress.XtraTab;
using DevExpress.XtraTabbedMdi;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraEditors;

namespace QLNS_SGU.Presenter
{
    public interface ICreateAndEditPersonInfoPresenter : IPresenterArgumentForTabPage
    {
        void LoadForm();
        void FormClosing(object sender, FormClosingEventArgs e);
    }
    public class CreateAndEditPersonInfoPresenter : ICreateAndEditPersonInfoPresenter
    {
        private static CreateAndEditPersonInfoForm _view;
        private string maVienChucInMainForm = "";
        private int tabOrderInRightViewMainForm = -1;
        public int rowFocusFormMainForm = -1;
        public bool checkClickGrid = false;
        public object UI => _view;
        public CreateAndEditPersonInfoPresenter(CreateAndEditPersonInfoForm view) => _view = view;
        public static void CloseForm()
        {
            _view.Close();
        }
        public void Initialize(string mavienchucInMainForm, int taborderInRightViewMainForm)
        {
            _view.Attach(this);
            maVienChucInMainForm = mavienchucInMainForm;
            tabOrderInRightViewMainForm = taborderInRightViewMainForm;      
        }
        public void LoadForm()
        {
            SplashScreenManager.ShowForm(_view, typeof(WaitForm1), true, true, false, 0);
            var tabPageThongTinCaNhanPresenter = new TabPageThongTinCaNhanPresenter(new TabPageThongTinCaNhan());
            tabPageThongTinCaNhanPresenter.Initialize(maVienChucInMainForm);
            Form frmThongTinCaNhan = (Form)tabPageThongTinCaNhanPresenter.UI;
            InitForm(frmThongTinCaNhan);
            var tabPageQuaTrinhCongTacPresenter = new TabPageQuaTrinhCongTacPresenter(new TabPageQuaTrinhCongTac1());
            tabPageQuaTrinhCongTacPresenter.Initialize(maVienChucInMainForm);
            tabPageQuaTrinhCongTacPresenter.rowFocusFromCreateAndEditPersonalInfoForm = rowFocusFormMainForm;
            Form frmQuaTrinhCongTac = (Form)tabPageQuaTrinhCongTacPresenter.UI;
            InitForm(frmQuaTrinhCongTac);
            var tabPageQuaTrinhLuongPresenter = new TabPageQuaTrinhLuongPresenter(new TabPageQuaTrinhLuong());
            tabPageQuaTrinhLuongPresenter.Initialize(maVienChucInMainForm);
            tabPageQuaTrinhLuongPresenter.rowFocusFromCreateAndEditPersonalInfoForm = rowFocusFormMainForm;
            Form frmQuaTrinhLuong = (Form)tabPageQuaTrinhLuongPresenter.UI;
            InitForm(frmQuaTrinhLuong);
            var tabPageChuyenMonPresenter = new TabPageChuyenMonPresenter(new TabPageChuyenMon());
            tabPageChuyenMonPresenter.Initialize(maVienChucInMainForm);
            tabPageChuyenMonPresenter.rowFocusFromCreateAndEditPersonalInfoForm = rowFocusFormMainForm;
            tabPageChuyenMonPresenter.checkClickGridForLoadForm = checkClickGrid;
            Form frmChuyenMon = (Form)tabPageChuyenMonPresenter.UI;
            InitForm(frmChuyenMon);
            var tabPageTrangThaiPresenter = new TabPageTrangThaiPresenter(new TabPageTrangThai());
            tabPageTrangThaiPresenter.Initialize(maVienChucInMainForm);
            tabPageTrangThaiPresenter.rowFocusFromCreateAndEditPersonalInfoForm = rowFocusFormMainForm;
            Form frmTrangThai = (Form)tabPageTrangThaiPresenter.UI;
            InitForm(frmTrangThai);
            switch (tabOrderInRightViewMainForm)
            {
                case 0:
                    frmThongTinCaNhan.Activate();
                    break;
                case 1:
                    frmQuaTrinhCongTac.Activate();
                    break;
                case 2:
                    frmQuaTrinhLuong.Activate();
                    break;
                case 3:
                    frmChuyenMon.Activate();
                    break;
                case 4:
                    frmTrangThai.Activate();                    
                    break;
                case 5:
                    frmChuyenMon.Activate();
                    tabPageChuyenMonPresenter.SelectTabChungChi();
                    break;                    
            }
            SplashScreenManager.CloseForm(false);
        }
        private void InitForm(Form f)
        {
            f.TopLevel = false;
            f.MdiParent = _view;
            f.Dock = DockStyle.Fill;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        public void FormClosing(object sender, FormClosingEventArgs e)
        {
            if (TabPageQuaTrinhCongTacPresenter.idFileUploadQTCT != string.Empty)
            {
                TabPageQuaTrinhCongTacPresenter.RemoveFileIfNotSaveQTCT(TabPageQuaTrinhCongTacPresenter.idFileUploadQTCT);
            }
            if (TabPageQuaTrinhCongTacPresenter.idFileUploadHD != string.Empty)
            {
                TabPageQuaTrinhCongTacPresenter.RemoveFileIfNotSaveHD(TabPageQuaTrinhCongTacPresenter.idFileUploadHD);
            }
            if (TabPageQuaTrinhLuongPresenter.idFileUpload != string.Empty)
            {
                TabPageQuaTrinhLuongPresenter.RemoveFileIfNotSave(TabPageQuaTrinhLuongPresenter.idFileUpload);
            }
            if(TabPageChuyenMonPresenter.idFileUploadCC != string.Empty)
            {
                TabPageChuyenMonPresenter.RemoveFileIfNotSaveCC(TabPageChuyenMonPresenter.idFileUploadCC);
            }
            if(TabPageChuyenMonPresenter.idFileUploadDHNC != string.Empty)
            {
                TabPageChuyenMonPresenter.RemoveFileIfNotSaveDHNC(TabPageChuyenMonPresenter.idFileUploadDHNC);
            }
            if(TabPageTrangThaiPresenter.idFileUpload != string.Empty)
            {
                TabPageTrangThaiPresenter.RemoveFileIfNotSave(TabPageTrangThaiPresenter.idFileUpload);
            }            
        }
    }
}
