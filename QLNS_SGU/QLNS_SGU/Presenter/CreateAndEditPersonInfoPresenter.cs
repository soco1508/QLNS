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

namespace QLNS_SGU.Presenter
{
    public interface ICreateAndEditPersonInfoPresenter : IPresenterArgumentForTabPage
    {
        void Close();
        void LoadForm();
    }
    public class CreateAndEditPersonInfoPresenter : ICreateAndEditPersonInfoPresenter
    {
        private CreateAndEditPersonInfoForm _view;
        private string _mavienchuc = "";
        private int _tabOrder = -1;
        public int _rowHandle = -1;
        public bool checkGrid = false;
        public object UI => _view;
        public CreateAndEditPersonInfoPresenter(CreateAndEditPersonInfoForm view) => _view = view;
        public void Close() => _view.Close();
        public void Initialize(string mavienchuc, int tabOrder)
        {
            _view.Attach(this);
            _mavienchuc = mavienchuc;
            _tabOrder = tabOrder;      
        }
        public void LoadForm()
        {
            SplashScreenManager.ShowForm(_view, typeof(WaitForm1), true, true, false, 0);
            var tabPageThongTinCaNhanPresenter = new TabPageThongTinCaNhanPresenter(new TabPageThongTinCaNhan());
            tabPageThongTinCaNhanPresenter.Initialize(_mavienchuc);
            Form form1 = (Form)tabPageThongTinCaNhanPresenter.UI;
            InitForm(form1);
            var tabPageQuaTrinhCongTacPresenter = new TabPageQuaTrinhCongTacPresenter(new TabPageQuaTrinhCongTac());
            tabPageQuaTrinhCongTacPresenter.Initialize(_mavienchuc);
            tabPageQuaTrinhCongTacPresenter._rowHandle = _rowHandle;
            Form form2 = (Form)tabPageQuaTrinhCongTacPresenter.UI;
            InitForm(form2);
            var tabPageQuaTrinhLuongPresenter = new TabPageQuaTrinhLuongPresenter(new TabPageQuaTrinhLuong());
            tabPageQuaTrinhLuongPresenter.Initialize(_mavienchuc);
            tabPageQuaTrinhLuongPresenter._rowHandle = _rowHandle;
            Form form3 = (Form)tabPageQuaTrinhLuongPresenter.UI;
            InitForm(form3);
            var tabPageChuyenMonPresenter = new TabPageChuyenMonPresenter(new TabPageChuyenMon());
            tabPageChuyenMonPresenter.Initialize(_mavienchuc);
            tabPageChuyenMonPresenter._rowHandle = _rowHandle;
            tabPageChuyenMonPresenter.checkGrid = checkGrid;
            Form form4 = (Form)tabPageChuyenMonPresenter.UI;
            InitForm(form4);
            var tabPageTrangThaiPresenter = new TabPageTrangThaiPresenter(new TabPageTrangThai());
            tabPageTrangThaiPresenter.Initialize(_mavienchuc);
            tabPageTrangThaiPresenter._rowHandle = _rowHandle;
            Form form5 = (Form)tabPageTrangThaiPresenter.UI;
            InitForm(form5);
            switch (_tabOrder)
            {
                case 0:                   
                    form1.Activate();
                    break;
                case 1:                    
                    form2.Activate();
                    break;
                case 2:                    
                    form3.Activate();
                    break;
                case 3:                    
                    form4.Activate();
                    break;
                case 4:
                    form5.Activate();                    
                    break;
                case 5:
                    form2.Activate();
                    tabPageQuaTrinhCongTacPresenter.SelectTabHopDong();
                    break;
                case 6:
                    form4.Activate();
                    tabPageChuyenMonPresenter.SelectTabDangHocNangCao();
                    break;
                case 7:
                    form4.Activate();
                    tabPageChuyenMonPresenter.SelectTabNganh();
                    break;
                case 8:
                    form4.Activate();
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
    }
}
