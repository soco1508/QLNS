using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLyNhanSuSGU_Winforms.Presenter;

namespace QuanLyNhanSuSGU_Winforms.View
{
    public interface IImportDataFromExcelView : IView<IImportDataFromExcelPresenter>
    {

    }
    public partial class ImportDataFromExcelView : DevExpress.XtraBars.Ribbon.RibbonForm,IImportDataFromExcelView
    {
        public ImportDataFromExcelView()
        {
            InitializeComponent();            
        }     

        public void Attach(IImportDataFromExcelPresenter presenter)
        {
            barButtonSplit.ItemClick += (sender, e) => presenter.SeperateExcelFile();
        }

        private void navBarVienChuc_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPageVienChuc;
        }

        private void navBarChucVuDonVi_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPageChucVuDonVi;
        }

        private void navBarHopDong_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPageHopDong;
        }

        private void navBarBangCap_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPageBangCap;
        }

        private void navBarChungChi_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPageChungChi;
        }

        private void navBarNganh_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPageNganh;
        }

        private void navBarQuaTrinhLuong_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPageQuaTrinhLuong;
        }

        private void navBarTrangThai_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPageTrangThai;
        }
    }
}