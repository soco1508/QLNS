using System;
using System.Windows.Forms;
using LinqToExcel;
using DevExpress.Spreadsheet;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Diagnostics;
using QuanLyNhanSuSGU_Winforms.View;

namespace QuanLyNhanSuSGU_Winforms.Presenter
{
    public interface IImportDataFromExcelPresenter : IPresenter
    {
        void SeperateExcelFile();
        void ImportData();
    }
    public class ImportDataFromExcelPresenter : IImportDataFromExcelPresenter
    {
        private ImportDataFromExcelView _view;

        public object UI
        {
            get
            {
                return _view;
            }
        }

        public void Initialize()
        {
            _view.Attach(this);
        }

        public ImportDataFromExcelPresenter(ImportDataFromExcelView view)
        {
            _view = view;
        }

        public void ImportData()
        {
            
        }      

        public void SeperateExcelFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Files|*.xls*;*.xlsx*;*.xlsm*";
            if (ofd.ShowDialog() == DialogResult.Cancel) return;
            string path = ofd.FileName;
            string sheetName = "Toantruong";
            var excel = new ExcelQueryFactory(path);
            var rows = from a in excel.Worksheet(sheetName).AsEnumerable()
                       select a;
            Workbook wb = new Workbook();
            wb.Worksheets.Insert(1, "ChucVuDonVi");
            wb.Worksheets.Insert(2, "HopDong");
            wb.Worksheets.Insert(3, "BangCap");
            wb.Worksheets.Insert(4, "ChungChi");
            wb.Worksheets.Insert(5, "Nganh");
            wb.Worksheets.Insert(6, "QuaTrinhLuong");
            wb.Worksheets.Insert(7, "TrangThai");
            #region ---VienChuc---
            wb.Worksheets[0].Name = "VienChuc";
            Worksheet wsVienChuc = wb.Worksheets[0];
            wsVienChuc.Cells["A1"].Value = "TT";
            wsVienChuc.Cells["B1"].Value = "Mã thẻ VC";
            wsVienChuc.Cells["C1"].Value = "Họ";
            wsVienChuc.Cells["D1"].Value = "Tên";
            wsVienChuc.Cells["E1"].Value = "Giới tính";
            wsVienChuc.Cells["F1"].Value = "Ngày sinh";
            wsVienChuc.Cells["G1"].Value = "Nơi sinh";
            wsVienChuc.Cells["H1"].Value = "Quê quán";
            wsVienChuc.Cells["I1"].Value = "Dân tộc";
            wsVienChuc.Cells["J1"].Value = "Tôn giáo";
            wsVienChuc.Cells["K1"].Value = "Đảng viên (DB)";
            wsVienChuc.Cells["L1"].Value = "Hộ khẩu thường trú";
            wsVienChuc.Cells["M1"].Value = "Nơi ở hiện nay (Tạm trú)";
            wsVienChuc.Cells["N1"].Value = "Ngày tham gia công tác";
            wsVienChuc.Cells["O1"].Value = "Năm vào ngành";
            wsVienChuc.Cells["P1"].Value = "Ngày về trường";
            wsVienChuc.Cells["Q1"].Value = "Văn hóa";
            wsVienChuc.Cells["R1"].Value = "QLNN";
            wsVienChuc.Cells["S1"].Value = "Chính trị";
            wsVienChuc.Cells["T1"].Value = "Ghi chú";

            List<string>[] listVienChuc = new List<string>[20];
            for(int i = 0; i < listVienChuc.Length; i++)
            {
                listVienChuc[i] = new List<string>();
            }
            foreach (var row in rows)
            {           
                listVienChuc[0].Add(row["TT"]);
                listVienChuc[1].Add(row["Mã thẻ VC"]);
                listVienChuc[2].Add(row["Họ"]);
                listVienChuc[3].Add(row["Tên"]);
                listVienChuc[4].Add(row["Giới tính"]);
                listVienChuc[5].Add(row["Ngày sinh"]);
                listVienChuc[6].Add(row["Nơi sinh"]);
                listVienChuc[7].Add(row["Quê quán"]);
                listVienChuc[8].Add(row["Dân tộc"]);
                listVienChuc[9].Add(row["Tôn giáo"]);
                listVienChuc[10].Add(row["Đảng viên (DB)"]);
                listVienChuc[11].Add(row["Hộ khẩu thường trú"]);
                listVienChuc[12].Add(row["Nơi ở hiện nay (Tạm trú)"]);
                listVienChuc[13].Add(row["Ngày tham gia công tác"]);
                listVienChuc[14].Add(row["Năm vào ngành"]);
                listVienChuc[15].Add(row["Ngày về trường"]);
                listVienChuc[16].Add(row["Văn hóa"]);
                listVienChuc[17].Add(row["QLNN"]);
                listVienChuc[18].Add(row["Chính trị"]);
                listVienChuc[19].Add(row["Ghi chú"]);
            }
            for(int i = 0; i < 20; i++)
            {
                wsVienChuc.Import(listVienChuc[i], 1, i, true);
            }
            wsVienChuc.Columns["A"].WidthInCharacters = 5;
            wsVienChuc.Columns["B"].WidthInCharacters = 8;
            wsVienChuc.Range["C:T"].ColumnWidthInCharacters = 25;

            Range rangeVienChuc = wsVienChuc.GetUsedRange();
            Formatting rangeFormattingVienChuc = rangeVienChuc.BeginUpdateFormatting(); // Begin format
            rangeFormattingVienChuc.Font.Name = "Times New Roman";
            rangeFormattingVienChuc.Font.Size = 12;
            rangeFormattingVienChuc.Borders.SetAllBorders(Color.Empty, BorderLineStyle.Dotted);
            rangeVienChuc.EndUpdateFormatting(rangeFormattingVienChuc); // End format  
            wsVienChuc.DefaultRowHeight = 150;
            for (int i = 1; i < rangeVienChuc.RowCount; i++)
            {
                for (int j = 0; j < rangeVienChuc.ColumnCount; j++)
                {
                    if (wsVienChuc.Cells[i, 3].Value.TextValue == string.Empty)
                    {

                        wsVienChuc.Cells[i, j].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Left;
                        wsVienChuc.Cells[i, j].Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
                        Formatting f = wsVienChuc.Rows[i].BeginUpdateFormatting();
                        f.Alignment.WrapText = false;
                        f.Font.Bold = true;
                        f.Font.Color = Color.Red;
                        wsVienChuc.Rows[i].EndUpdateFormatting(f);
                    }
                    else
                    {
                        wsVienChuc.Rows[i].Alignment.WrapText = true;
                        wsVienChuc.Cells[i, j].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Left;
                        wsVienChuc.Cells[i, j].Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
                    }
                }
            }
            wsVienChuc.Range["A1:T1"].Fill.BackgroundColor = Color.FromArgb(153, 204, 255);
            wsVienChuc.Range["A1:T1"].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
            wsVienChuc.Range["A1:T1"].Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
            wsVienChuc.Range["A1:T1"].Alignment.WrapText = true;
            wsVienChuc.Range["A1:T1"].Font.Bold = true;
            #endregion
            #region ---ChucVuDonVi---            
            Worksheet wsChucVuDonVi = wb.Worksheets[1];                     
            wsChucVuDonVi.Cells["A1"].Value = "TT";
            wsChucVuDonVi.Cells["B1"].Value = "Mã thẻ VC";
            wsChucVuDonVi.Cells["C1"].Value = "Họ";
            wsChucVuDonVi.Cells["D1"].Value = "Tên";
            wsChucVuDonVi.Cells["E1"].Value = "Chức vụ";
            wsChucVuDonVi.Cells["F1"].Value = "Đơn vị";
            wsChucVuDonVi.Cells["G1"].Value = "Địa điểm";
            wsChucVuDonVi.Cells["H1"].Value = "Tổ chuyên môn";
            wsChucVuDonVi.Cells["I1"].Value = "Phân loại";
            wsChucVuDonVi.Cells["J1"].Value = "Kiêm nhiệm";
            wsChucVuDonVi.Cells["K1"].Value = "Hệ số CV";

            List<string>[] listChucVuDonVi = new List<string>[11];
            for (int i = 0; i < listChucVuDonVi.Length; i++)
            {
                listChucVuDonVi[i] = new List<string>();
            }
            foreach(var row in rows)
            {
                listChucVuDonVi[0].Add(row["TT"]);
                listChucVuDonVi[1].Add(row["Mã thẻ VC"]);
                listChucVuDonVi[2].Add(row["Họ"]);
                listChucVuDonVi[3].Add(row["Tên"]);
                listChucVuDonVi[4].Add(row["Chức vụ"]);
                listChucVuDonVi[5].Add(row["Đơn vị"]);
                listChucVuDonVi[6].Add(row["Địa điểm"]);
                listChucVuDonVi[7].Add(row["Tổ chuyên môn"]);
                listChucVuDonVi[8].Add(row["Phân loại"]);
                listChucVuDonVi[9].Add(row["Kiêm nhiệm"]);
                listChucVuDonVi[10].Add(row["Hệ số CV"]);                
            }
            for (int i = 0; i < 11; i++)
            {
                wsChucVuDonVi.Import(listChucVuDonVi[i], 1, i, true);
            }
            wsChucVuDonVi.Columns["A"].WidthInCharacters = 5;
            wsChucVuDonVi.Columns["B"].WidthInCharacters = 8;
            wsChucVuDonVi.Range["C:K"].ColumnWidthInCharacters = 25;

            Range rangeChucVuDonVi = wsChucVuDonVi.GetUsedRange();
            Formatting rangeFormattingChucVuDonVi = rangeChucVuDonVi.BeginUpdateFormatting(); // Begin format
            rangeFormattingChucVuDonVi.Font.Name = "Times New Roman";
            rangeFormattingChucVuDonVi.Font.Size = 12;
            rangeFormattingChucVuDonVi.Borders.SetAllBorders(Color.Empty, BorderLineStyle.Dotted);
            rangeChucVuDonVi.EndUpdateFormatting(rangeFormattingChucVuDonVi); // End format  
            wsChucVuDonVi.DefaultRowHeight = 150;
            for (int i = 1; i < rangeChucVuDonVi.RowCount; i++)
            {
                for (int j = 0; j < rangeChucVuDonVi.ColumnCount; j++)
                {
                    if (wsChucVuDonVi.Cells[i, 3].Value.TextValue == string.Empty)
                    {

                        wsChucVuDonVi.Cells[i, j].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Left;
                        wsChucVuDonVi.Cells[i, j].Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
                        Formatting f = wsChucVuDonVi.Rows[i].BeginUpdateFormatting();
                        f.Alignment.WrapText = false;
                        f.Font.Bold = true;
                        f.Font.Color = Color.Red;
                        wsChucVuDonVi.Rows[i].EndUpdateFormatting(f);
                    }
                    else
                    {
                        wsChucVuDonVi.Rows[i].Alignment.WrapText = true;
                        wsChucVuDonVi.Cells[i, j].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Left;
                        wsChucVuDonVi.Cells[i, j].Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
                    }
                }
            }
            wsChucVuDonVi.Range["A1:K1"].Fill.BackgroundColor = Color.FromArgb(153, 204, 255);
            wsChucVuDonVi.Range["A1:K1"].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
            wsChucVuDonVi.Range["A1:K1"].Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
            wsChucVuDonVi.Range["A1:K1"].Alignment.WrapText = true;
            wsChucVuDonVi.Range["A1:K1"].Font.Bold = true;
            #endregion
            #region ---HopDong---
            Worksheet wsHopDong = wb.Worksheets[2];
            wsHopDong.Cells["A1"].Value = "Loại HĐ";
            wsHopDong.Cells["B1"].Value = "TT";
            wsHopDong.Cells["C1"].Value = "Mã thẻ VC";
            wsHopDong.Cells["D1"].Value = "Họ";
            wsHopDong.Cells["E1"].Value = "Tên";

            List<string>[] listHopDong = new List<string>[5];
            for (int i = 0; i < listHopDong.Length; i++)
            {
                listHopDong[i] = new List<string>();
            }
            foreach (var row in rows)
            {
                listHopDong[0].Add(row["Loại HĐ"]);
                listHopDong[1].Add(row["TT"]);
                listHopDong[2].Add(row["Mã thẻ VC"]);
                listHopDong[3].Add(row["Họ"]);
                listHopDong[4].Add(row["Tên"]);
            }
            for (int i = 0; i < 5; i++)
            {
                wsHopDong.Import(listHopDong[i], 1, i, true);
            }
            wsHopDong.Columns["A"].WidthInCharacters = 5;
            wsHopDong.Columns["B"].WidthInCharacters = 8;
            wsHopDong.Range["C:E"].ColumnWidthInCharacters = 25;

            Range rangeHopDong = wsHopDong.GetUsedRange();
            Formatting rangeFormattingHopDong = rangeHopDong.BeginUpdateFormatting(); // Begin format
            rangeFormattingHopDong.Font.Name = "Times New Roman";
            rangeFormattingHopDong.Font.Size = 12;
            rangeFormattingHopDong.Borders.SetAllBorders(Color.Empty, BorderLineStyle.Dotted);
            rangeHopDong.EndUpdateFormatting(rangeFormattingHopDong); // End format  
            wsHopDong.DefaultRowHeight = 150;
            for (int i = 1; i < rangeHopDong.RowCount; i++)
            {
                for (int j = 0; j < rangeHopDong.ColumnCount; j++)
                {
                    if (wsHopDong.Cells[i, 0].Value.TextValue == string.Empty)
                    {

                        wsHopDong.Cells[i, j].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Left;
                        wsHopDong.Cells[i, j].Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
                        Formatting f = wsHopDong.Rows[i].BeginUpdateFormatting();
                        f.Alignment.WrapText = false;
                        f.Font.Bold = true;
                        f.Font.Color = Color.Red;
                        wsHopDong.Rows[i].EndUpdateFormatting(f);
                    }
                    else
                    {
                        wsHopDong.Rows[i].Alignment.WrapText = true;
                        wsHopDong.Cells[i, j].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Left;
                        wsHopDong.Cells[i, j].Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
                    }
                }
            }
            wsHopDong.Range["A1:E1"].Fill.BackgroundColor = Color.FromArgb(153, 204, 255);
            wsHopDong.Range["A1:E1"].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
            wsHopDong.Range["A1:E1"].Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
            wsHopDong.Range["A1:E1"].Alignment.WrapText = true;
            wsHopDong.Range["A1:E1"].Font.Bold = true;
            #endregion
            #region ---BangCap---
            //Worksheet wsBangCap = wb.Worksheets[3];
            //wsBangCap.Cells["A1"].Value = "TT";
            //wsBangCap.Cells["B1"].Value = "Mã thẻ VC";
            //wsBangCap.Cells["C1"].Value = "Họ";
            //wsBangCap.Cells["D1"].Value = "Tên";
            #endregion
            #region ---ChungChi---
            //Worksheet wsChungChi = wb.Worksheets[4];
            //wsChungChi.Cells["A1"].Value = "TT";
            //wsChungChi.Cells["B1"].Value = "Mã thẻ VC";
            //wsChungChi.Cells["C1"].Value = "Họ";
            //wsChungChi.Cells["D1"].Value = "Tên";
            #endregion
            #region ---Nganh---
            Worksheet wsNganh = wb.Worksheets[5];
            wsNganh.Cells["A1"].Value = "TT";
            wsNganh.Cells["B1"].Value = "Mã thẻ VC";
            wsNganh.Cells["C1"].Value = "Họ";
            wsNganh.Cells["D1"].Value = "Tên";
            wsNganh.Cells["E1"].Value = "Chuyên ngành";
            wsNganh.Cells["F1"].Value = "Phân loại ngành";
            wsNganh.Cells["G1"].Value = "Ngành tham gia giảng dạy";

            List<string>[] listNganh = new List<string>[7];
            for (int i = 0; i < listNganh.Length; i++)
            {
                listNganh[i] = new List<string>();
            }
            foreach (var row in rows)
            {
                listNganh[0].Add(row["TT"]);
                listNganh[1].Add(row["Mã thẻ VC"]);
                listNganh[2].Add(row["Họ"]);
                listNganh[3].Add(row["Tên"]);
                listNganh[4].Add(row["Chuyên ngành"]);
                listNganh[5].Add(row["Phân loại ngành"]);
                listNganh[6].Add(row["Ngành tham gia giảng dạy"]);
            }
            for (int i = 0; i < 7; i++)
            {
                wsNganh.Import(listNganh[i], 1, i, true);
            }
            wsNganh.Columns["A"].WidthInCharacters = 5;
            wsNganh.Columns["B"].WidthInCharacters = 8;
            wsNganh.Range["C:G"].ColumnWidthInCharacters = 25;

            Range rangeNganh = wsNganh.GetUsedRange();
            Formatting rangeFormattingNganh = rangeNganh.BeginUpdateFormatting(); // Begin format
            rangeFormattingNganh.Font.Name = "Times New Roman";
            rangeFormattingNganh.Font.Size = 12;
            rangeFormattingNganh.Borders.SetAllBorders(Color.Empty, BorderLineStyle.Dotted);
            rangeNganh.EndUpdateFormatting(rangeFormattingNganh); // End format  
            wsNganh.DefaultRowHeight = 150;
            for (int i = 1; i < rangeNganh.RowCount; i++)
            {
                for (int j = 0; j < rangeNganh.ColumnCount; j++)
                {
                    if (wsNganh.Cells[i, 3].Value.TextValue == string.Empty)
                    {
                        wsNganh.Cells[i, j].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Left;
                        wsNganh.Cells[i, j].Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
                        Formatting f = wsNganh.Rows[i].BeginUpdateFormatting();
                        f.Alignment.WrapText = false;
                        f.Font.Bold = true;
                        f.Font.Color = Color.Red;
                        wsNganh.Rows[i].EndUpdateFormatting(f);
                    }
                    else
                    {
                        wsNganh.Rows[i].Alignment.WrapText = true;
                        wsNganh.Cells[i, j].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Left;
                        wsNganh.Cells[i, j].Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
                    }
                }
            }
            wsNganh.Range["A1:G1"].Fill.BackgroundColor = Color.FromArgb(153, 204, 255);
            wsNganh.Range["A1:G1"].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
            wsNganh.Range["A1:G1"].Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
            wsNganh.Range["A1:G1"].Alignment.WrapText = true;
            wsNganh.Range["A1:G1"].Font.Bold = true;
            #endregion
            #region ---QuaTrinhLuong---
            Worksheet wsQuaTrinhLuong = wb.Worksheets[6];
            wsQuaTrinhLuong.Cells["A1"].Value = "TT";
            wsQuaTrinhLuong.Cells["B1"].Value = "Mã thẻ VC";
            wsQuaTrinhLuong.Cells["C1"].Value = "Họ";
            wsQuaTrinhLuong.Cells["D1"].Value = "Tên";
            wsQuaTrinhLuong.Cells["E1"].Value = "Mã số chức danh";
            wsQuaTrinhLuong.Cells["F1"].Value = "Ngày HĐ ngạch, bậc";
            wsQuaTrinhLuong.Cells["G1"].Value = "Loại ngạch";

            List<string>[] listQuaTrinhLuong = new List<string>[7];
            for (int i = 0; i < listQuaTrinhLuong.Length; i++)
            {
                listQuaTrinhLuong[i] = new List<string>();
            }
            foreach (var row in rows)
            {
                listQuaTrinhLuong[0].Add(row["TT"]);
                listQuaTrinhLuong[1].Add(row["Mã thẻ VC"]);
                listQuaTrinhLuong[2].Add(row["Họ"]);
                listQuaTrinhLuong[3].Add(row["Tên"]);
                listQuaTrinhLuong[4].Add(row["Mã số chức danh"]);
                listQuaTrinhLuong[5].Add(row["Ngày HĐ ngạch, bậc"]);
                listQuaTrinhLuong[6].Add(row["Loại ngạch"]);
            }
            for (int i = 0; i < 7; i++)
            {
                wsQuaTrinhLuong.Import(listQuaTrinhLuong[i], 1, i, true);
            }
            wsQuaTrinhLuong.Columns["A"].WidthInCharacters = 5;
            wsQuaTrinhLuong.Columns["B"].WidthInCharacters = 8;
            wsQuaTrinhLuong.Range["C:G"].ColumnWidthInCharacters = 25;

            Range rangeQuaTrinhLuong = wsQuaTrinhLuong.GetUsedRange();
            Formatting rangeFormattingQuaTrinhLuong = rangeQuaTrinhLuong.BeginUpdateFormatting(); // Begin format
            rangeFormattingQuaTrinhLuong.Font.Name = "Times New Roman";
            rangeFormattingQuaTrinhLuong.Font.Size = 12;
            rangeFormattingQuaTrinhLuong.Borders.SetAllBorders(Color.Empty, BorderLineStyle.Dotted);
            rangeQuaTrinhLuong.EndUpdateFormatting(rangeFormattingQuaTrinhLuong); // End format  
            wsQuaTrinhLuong.DefaultRowHeight = 150;
            for (int i = 1; i < rangeQuaTrinhLuong.RowCount; i++)
            {
                for (int j = 0; j < rangeQuaTrinhLuong.ColumnCount; j++)
                {
                    if (wsQuaTrinhLuong.Cells[i, 3].Value.TextValue == string.Empty)
                    {
                        wsQuaTrinhLuong.Cells[i, j].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Left;
                        wsQuaTrinhLuong.Cells[i, j].Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
                        Formatting f = wsQuaTrinhLuong.Rows[i].BeginUpdateFormatting();
                        f.Alignment.WrapText = false;
                        f.Font.Bold = true;
                        f.Font.Color = Color.Red;
                        wsQuaTrinhLuong.Rows[i].EndUpdateFormatting(f);
                    }
                    else
                    {
                        wsQuaTrinhLuong.Rows[i].Alignment.WrapText = true;
                        wsQuaTrinhLuong.Cells[i, j].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Left;
                        wsQuaTrinhLuong.Cells[i, j].Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
                    }
                }
            }
            wsQuaTrinhLuong.Range["A1:G1"].Fill.BackgroundColor = Color.FromArgb(153, 204, 255);
            wsQuaTrinhLuong.Range["A1:G1"].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
            wsQuaTrinhLuong.Range["A1:G1"].Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
            wsQuaTrinhLuong.Range["A1:G1"].Alignment.WrapText = true;
            wsQuaTrinhLuong.Range["A1:G1"].Font.Bold = true;
            #endregion
            #region ---TrangThai---

#endregion
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Files|*.xls*;*.xlsx*;*.xlsm*";
            if (sfd.ShowDialog() == DialogResult.Cancel) return;
            string path1 = sfd.FileName + ".xlsx";
            wb.SaveDocument(path1, DocumentFormat.OpenXml);
            MessageBox.Show("Saved", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start(path1);
        }       
    }
}
