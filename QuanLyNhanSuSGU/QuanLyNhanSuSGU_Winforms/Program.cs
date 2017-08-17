using System;
using System.Windows.Forms;
using QuanLyNhanSuSGU_Winforms.Presenter;
using QuanLyNhanSuSGU_Winforms.View;

namespace QuanLyNhanSuSGU_Winforms
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var presenter = new ImportDataFromExcelPresenter(new ImportDataFromExcelView());
            presenter.Initialize();
            Application.Run((Form)presenter.UI);
        }
    }
}
