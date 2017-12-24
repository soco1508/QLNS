namespace QLNS_SGU.View
{
    partial class VienChucForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VienChucForm));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportExcel = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnOpenThongTinCaNhan = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpenQuaTrinhCongTac = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpenChuyenMon = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpenQuaTrinhLuong = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpenTrangThai = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpenHopDong = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpenHocHamHocVi = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpenDangHocNangCao = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpenChungChi = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpenNganh = new DevExpress.XtraBars.BarButtonItem();
            this.gcVienChuc = new DevExpress.XtraGrid.GridControl();
            this.gvVienChuc = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.popupMenuView = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcVienChuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvVienChuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuView)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnExportExcel,
            this.btnOpenThongTinCaNhan,
            this.btnOpenQuaTrinhCongTac,
            this.btnOpenChuyenMon,
            this.btnOpenQuaTrinhLuong,
            this.btnOpenTrangThai,
            this.btnRefresh,
            this.btnOpenHopDong,
            this.btnOpenHocHamHocVi,
            this.btnOpenDangHocNangCao,
            this.btnOpenChungChi,
            this.btnOpenNganh,
            this.btnDelete});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 16;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefresh),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExportExcel)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Tải lại";
            this.btnRefresh.Id = 9;
            this.btnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.Image")));
            this.btnRefresh.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.LargeImage")));
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Xóa";
            this.btnDelete.Id = 15;
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.LargeImage")));
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Caption = "Xuất Excel";
            this.btnExportExcel.Id = 1;
            this.btnExportExcel.ImageOptions.Image = global::QLNS_SGU.Properties.Resources.excel;
            this.btnExportExcel.ImageOptions.LargeImage = global::QLNS_SGU.Properties.Resources.excel;
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1000, 28);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 466);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1000, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 28);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 438);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1000, 28);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 438);
            // 
            // btnOpenThongTinCaNhan
            // 
            this.btnOpenThongTinCaNhan.Caption = "Quản lý thông tin cá nhân";
            this.btnOpenThongTinCaNhan.Id = 2;
            this.btnOpenThongTinCaNhan.Name = "btnOpenThongTinCaNhan";
            // 
            // btnOpenQuaTrinhCongTac
            // 
            this.btnOpenQuaTrinhCongTac.Caption = "Quản lý quá trình công tác";
            this.btnOpenQuaTrinhCongTac.Id = 3;
            this.btnOpenQuaTrinhCongTac.Name = "btnOpenQuaTrinhCongTac";
            // 
            // btnOpenChuyenMon
            // 
            this.btnOpenChuyenMon.Caption = "Quản lý chuyên môn";
            this.btnOpenChuyenMon.Id = 4;
            this.btnOpenChuyenMon.Name = "btnOpenChuyenMon";
            // 
            // btnOpenQuaTrinhLuong
            // 
            this.btnOpenQuaTrinhLuong.Caption = "Quản lý quá trình lương";
            this.btnOpenQuaTrinhLuong.Id = 5;
            this.btnOpenQuaTrinhLuong.Name = "btnOpenQuaTrinhLuong";
            // 
            // btnOpenTrangThai
            // 
            this.btnOpenTrangThai.Caption = "Quản lý trạng thái";
            this.btnOpenTrangThai.Id = 6;
            this.btnOpenTrangThai.Name = "btnOpenTrangThai";
            // 
            // btnOpenHopDong
            // 
            this.btnOpenHopDong.Caption = "Quản lý hợp đồng";
            this.btnOpenHopDong.Id = 10;
            this.btnOpenHopDong.Name = "btnOpenHopDong";
            // 
            // btnOpenHocHamHocVi
            // 
            this.btnOpenHocHamHocVi.Caption = "Quản lý học hàm học vị";
            this.btnOpenHocHamHocVi.Id = 11;
            this.btnOpenHocHamHocVi.Name = "btnOpenHocHamHocVi";
            // 
            // btnOpenDangHocNangCao
            // 
            this.btnOpenDangHocNangCao.Caption = "Quản lý đang học nâng cao";
            this.btnOpenDangHocNangCao.Id = 12;
            this.btnOpenDangHocNangCao.Name = "btnOpenDangHocNangCao";
            // 
            // btnOpenChungChi
            // 
            this.btnOpenChungChi.Caption = "Quản lý chứng chỉ";
            this.btnOpenChungChi.Id = 13;
            this.btnOpenChungChi.Name = "btnOpenChungChi";
            // 
            // btnOpenNganh
            // 
            this.btnOpenNganh.Caption = "Quản lý ngành";
            this.btnOpenNganh.Id = 14;
            this.btnOpenNganh.Name = "btnOpenNganh";
            // 
            // gcVienChuc
            // 
            this.gcVienChuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcVienChuc.Location = new System.Drawing.Point(0, 28);
            this.gcVienChuc.MainView = this.gvVienChuc;
            this.gcVienChuc.MenuManager = this.barManager1;
            this.gcVienChuc.Name = "gcVienChuc";
            this.gcVienChuc.Size = new System.Drawing.Size(1000, 438);
            this.gcVienChuc.TabIndex = 4;
            this.gcVienChuc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvVienChuc});
            // 
            // gvVienChuc
            // 
            this.gvVienChuc.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19,
            this.gridColumn20,
            this.gridColumn21,
            this.gridColumn22});
            this.gvVienChuc.GridControl = this.gcVienChuc;
            this.gvVienChuc.Name = "gvVienChuc";
            this.gvVienChuc.OptionsBehavior.Editable = false;
            this.gvVienChuc.OptionsView.ColumnAutoWidth = false;
            this.gvVienChuc.OptionsView.RowAutoHeight = true;
            this.gvVienChuc.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Id";
            this.gridColumn1.FieldName = "idVienChuc";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Mã viên chức";
            this.gridColumn2.FieldName = "maVienChuc";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Họ";
            this.gridColumn3.FieldName = "ho";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 110;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Tên";
            this.gridColumn4.FieldName = "ten";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Giới tính";
            this.gridColumn5.FieldName = "gioiTinh";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Ngày sinh";
            this.gridColumn6.FieldName = "ngaySinh";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 100;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Số điện thoại";
            this.gridColumn7.FieldName = "sDT";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            this.gridColumn7.Width = 120;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Nơi sinh";
            this.gridColumn8.FieldName = "noiSinh";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            this.gridColumn8.Width = 150;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Quê quán";
            this.gridColumn9.FieldName = "queQuan";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 7;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Dân tộc";
            this.gridColumn10.FieldName = "danToc";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 8;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Tôn giáo";
            this.gridColumn11.FieldName = "tonGiao";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 9;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Hộ khẩu thường trú";
            this.gridColumn12.FieldName = "hoKhauThuongTru";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 10;
            this.gridColumn12.Width = 150;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Nơi ở hiện nay";
            this.gridColumn13.FieldName = "noiOHienNay";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 11;
            this.gridColumn13.Width = 150;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Là đảng viên";
            this.gridColumn14.FieldName = "laDangVien";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 12;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Ngày vào đảng";
            this.gridColumn15.FieldName = "ngayVaoDang";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 13;
            this.gridColumn15.Width = 100;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Ngày tham gia công tác";
            this.gridColumn16.FieldName = "ngayThamGiaCongTac";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 14;
            this.gridColumn16.Width = 100;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Ngày vào ngành";
            this.gridColumn17.FieldName = "ngayVaoNganh";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 15;
            this.gridColumn17.Width = 100;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Ngày về trường";
            this.gridColumn18.FieldName = "ngayVeTruong";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 16;
            this.gridColumn18.Width = 100;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Văn hóa ";
            this.gridColumn19.FieldName = "vanHoa";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 17;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "Quản lý nhà nước";
            this.gridColumn20.FieldName = "quanLyNhaNuoc";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 18;
            this.gridColumn20.Width = 110;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "Chính trị";
            this.gridColumn21.FieldName = "chinhTri";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 19;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "Ghi chú";
            this.gridColumn22.FieldName = "ghiChu";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 20;
            this.gridColumn22.Width = 150;
            // 
            // popupMenuView
            // 
            this.popupMenuView.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnOpenThongTinCaNhan),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnOpenQuaTrinhCongTac),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnOpenQuaTrinhLuong),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnOpenHopDong),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnOpenHocHamHocVi),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnOpenDangHocNangCao),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnOpenNganh),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnOpenChungChi),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnOpenTrangThai)});
            this.popupMenuView.Manager = this.barManager1;
            this.popupMenuView.Name = "popupMenuView";
            // 
            // VienChucForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 466);
            this.ControlBox = false;
            this.Controls.Add(this.gcVienChuc);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VienChucForm";
            this.ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcVienChuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvVienChuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl gcVienChuc;
        private DevExpress.XtraGrid.Views.Grid.GridView gvVienChuc;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private DevExpress.XtraBars.BarButtonItem btnExportExcel;
        private DevExpress.XtraBars.PopupMenu popupMenuView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraBars.BarButtonItem btnOpenThongTinCaNhan;
        private DevExpress.XtraBars.BarButtonItem btnOpenQuaTrinhCongTac;
        private DevExpress.XtraBars.BarButtonItem btnOpenChuyenMon;
        private DevExpress.XtraBars.BarButtonItem btnOpenQuaTrinhLuong;
        private DevExpress.XtraBars.BarButtonItem btnOpenTrangThai;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarButtonItem btnOpenHopDong;
        private DevExpress.XtraBars.BarButtonItem btnOpenHocHamHocVi;
        private DevExpress.XtraBars.BarButtonItem btnOpenDangHocNangCao;
        private DevExpress.XtraBars.BarButtonItem btnOpenChungChi;
        private DevExpress.XtraBars.BarButtonItem btnOpenNganh;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
    }
}