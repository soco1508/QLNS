﻿namespace QLNS_SGU.View
{
    partial class ContainerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContainerForm));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnOpenImportData = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpenCreateAndEditPersonInfoForm = new DevExpress.XtraBars.BarButtonItem();
            this.btnNaviNganh = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenuNganh = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnNaviLoaiNganh = new DevExpress.XtraBars.BarButtonItem();
            this.btnNaviNganhDaoTao = new DevExpress.XtraBars.BarButtonItem();
            this.btnNaviChuyenNganh = new DevExpress.XtraBars.BarButtonItem();
            this.btnNaviLoaiChungChi = new DevExpress.XtraBars.BarButtonItem();
            this.btnNaviLoaiHopDong = new DevExpress.XtraBars.BarButtonItem();
            this.btnDangXuat = new DevExpress.XtraBars.BarButtonItem();
            this.txtXinChao = new DevExpress.XtraBars.BarStaticItem();
            this.btnNaviMain = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenuDonVi = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnNaviLoaiDonVi = new DevExpress.XtraBars.BarButtonItem();
            this.btnNaviDonVi = new DevExpress.XtraBars.BarButtonItem();
            this.btnNaviToChuyenMon = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenuNgachBac = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnNaviNgach = new DevExpress.XtraBars.BarButtonItem();
            this.btnNaviBac = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenuChucVu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnNaviLoaiChucVu = new DevExpress.XtraBars.BarButtonItem();
            this.btnNaviChucVu = new DevExpress.XtraBars.BarButtonItem();
            this.btnNaviLoaiHocHamHocVi = new DevExpress.XtraBars.BarButtonItem();
            this.btnNaviTrangThai = new DevExpress.XtraBars.BarButtonItem();
            this.btnNaviVienChuc = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::QLNS_SGU.View.WaitForm1), true, true);
            this.btnNaviExportData = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuNganh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuDonVi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuNgachBac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuChucVu)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnOpenImportData,
            this.btnOpenCreateAndEditPersonInfoForm,
            this.btnNaviNganh,
            this.btnNaviLoaiChungChi,
            this.btnNaviLoaiHopDong,
            this.btnDangXuat,
            this.txtXinChao,
            this.btnNaviMain,
            this.barButtonItem3,
            this.btnNaviLoaiNganh,
            this.btnNaviNganhDaoTao,
            this.btnNaviChuyenNganh,
            this.barButtonItem1,
            this.btnNaviLoaiDonVi,
            this.btnNaviDonVi,
            this.btnNaviToChuyenMon,
            this.barButtonItem2,
            this.btnNaviNgach,
            this.btnNaviBac,
            this.barButtonItem6,
            this.btnNaviLoaiChucVu,
            this.btnNaviChucVu,
            this.btnNaviLoaiHocHamHocVi,
            this.btnNaviTrangThai,
            this.btnNaviVienChuc,
            this.btnNaviExportData});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 42;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2007;
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.Size = new System.Drawing.Size(996, 150);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // btnOpenImportData
            // 
            this.btnOpenImportData.Caption = "Nhập dữ liệu";
            this.btnOpenImportData.Id = 1;
            this.btnOpenImportData.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenImportData.ImageOptions.Image")));
            this.btnOpenImportData.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnOpenImportData.ImageOptions.LargeImage")));
            this.btnOpenImportData.Name = "btnOpenImportData";
            this.btnOpenImportData.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // btnOpenCreateAndEditPersonInfoForm
            // 
            this.btnOpenCreateAndEditPersonInfoForm.Caption = "Thêm hồ sơ người mới";
            this.btnOpenCreateAndEditPersonInfoForm.Id = 3;
            this.btnOpenCreateAndEditPersonInfoForm.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenCreateAndEditPersonInfoForm.ImageOptions.Image")));
            this.btnOpenCreateAndEditPersonInfoForm.ImageOptions.LargeImage = global::QLNS_SGU.Properties.Resources.record;
            this.btnOpenCreateAndEditPersonInfoForm.Name = "btnOpenCreateAndEditPersonInfoForm";
            this.btnOpenCreateAndEditPersonInfoForm.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // btnNaviNganh
            // 
            this.btnNaviNganh.ActAsDropDown = true;
            this.btnNaviNganh.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnNaviNganh.Caption = "Ngành";
            this.btnNaviNganh.DropDownControl = this.popupMenuNganh;
            this.btnNaviNganh.Id = 4;
            this.btnNaviNganh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNaviNganh.ImageOptions.Image")));
            this.btnNaviNganh.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnNaviNganh.ImageOptions.LargeImage")));
            this.btnNaviNganh.Name = "btnNaviNganh";
            this.btnNaviNganh.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // popupMenuNganh
            // 
            this.popupMenuNganh.ItemLinks.Add(this.btnNaviLoaiNganh);
            this.popupMenuNganh.ItemLinks.Add(this.btnNaviNganhDaoTao);
            this.popupMenuNganh.ItemLinks.Add(this.btnNaviChuyenNganh);
            this.popupMenuNganh.Name = "popupMenuNganh";
            this.popupMenuNganh.Ribbon = this.ribbon;
            // 
            // btnNaviLoaiNganh
            // 
            this.btnNaviLoaiNganh.Caption = "Loại ngành";
            this.btnNaviLoaiNganh.Id = 23;
            this.btnNaviLoaiNganh.Name = "btnNaviLoaiNganh";
            // 
            // btnNaviNganhDaoTao
            // 
            this.btnNaviNganhDaoTao.Caption = "Ngành đào tạo";
            this.btnNaviNganhDaoTao.Id = 24;
            this.btnNaviNganhDaoTao.Name = "btnNaviNganhDaoTao";
            // 
            // btnNaviChuyenNganh
            // 
            this.btnNaviChuyenNganh.Caption = "Chuyên ngành";
            this.btnNaviChuyenNganh.Id = 25;
            this.btnNaviChuyenNganh.Name = "btnNaviChuyenNganh";
            // 
            // btnNaviLoaiChungChi
            // 
            this.btnNaviLoaiChungChi.Caption = "Chứng chỉ";
            this.btnNaviLoaiChungChi.Id = 6;
            this.btnNaviLoaiChungChi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNaviLoaiChungChi.ImageOptions.Image")));
            this.btnNaviLoaiChungChi.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnNaviLoaiChungChi.ImageOptions.LargeImage")));
            this.btnNaviLoaiChungChi.Name = "btnNaviLoaiChungChi";
            this.btnNaviLoaiChungChi.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // btnNaviLoaiHopDong
            // 
            this.btnNaviLoaiHopDong.Caption = "Hợp đồng";
            this.btnNaviLoaiHopDong.Id = 7;
            this.btnNaviLoaiHopDong.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNaviLoaiHopDong.ImageOptions.Image")));
            this.btnNaviLoaiHopDong.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnNaviLoaiHopDong.ImageOptions.LargeImage")));
            this.btnNaviLoaiHopDong.Name = "btnNaviLoaiHopDong";
            this.btnNaviLoaiHopDong.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnDangXuat.Caption = "Đăng xuất";
            this.btnDangXuat.Id = 9;
            this.btnDangXuat.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnDangXuat.ItemAppearance.Normal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDangXuat.ItemAppearance.Normal.Options.UseFont = true;
            this.btnDangXuat.ItemAppearance.Normal.Options.UseForeColor = true;
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.Caption;
            // 
            // txtXinChao
            // 
            this.txtXinChao.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.txtXinChao.Id = 11;
            this.txtXinChao.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtXinChao.ItemAppearance.Normal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtXinChao.ItemAppearance.Normal.Options.UseFont = true;
            this.txtXinChao.ItemAppearance.Normal.Options.UseForeColor = true;
            this.txtXinChao.Name = "txtXinChao";
            this.txtXinChao.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnNaviMain
            // 
            this.btnNaviMain.Caption = "Màn hình chính";
            this.btnNaviMain.Id = 12;
            this.btnNaviMain.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNaviMain.ImageOptions.Image")));
            this.btnNaviMain.Name = "btnNaviMain";
            this.btnNaviMain.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "In ấn";
            this.barButtonItem3.Id = 13;
            this.barButtonItem3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.Image")));
            this.barButtonItem3.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.LargeImage")));
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.ActAsDropDown = true;
            this.barButtonItem1.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.barButtonItem1.Caption = "Đơn vị";
            this.barButtonItem1.DropDownControl = this.popupMenuDonVi;
            this.barButtonItem1.Id = 28;
            this.barButtonItem1.ImageOptions.LargeImage = global::QLNS_SGU.Properties.Resources.donvi;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // popupMenuDonVi
            // 
            this.popupMenuDonVi.ItemLinks.Add(this.btnNaviLoaiDonVi);
            this.popupMenuDonVi.ItemLinks.Add(this.btnNaviDonVi);
            this.popupMenuDonVi.ItemLinks.Add(this.btnNaviToChuyenMon);
            this.popupMenuDonVi.Name = "popupMenuDonVi";
            this.popupMenuDonVi.Ribbon = this.ribbon;
            // 
            // btnNaviLoaiDonVi
            // 
            this.btnNaviLoaiDonVi.Caption = "Loại đơn vị";
            this.btnNaviLoaiDonVi.Id = 29;
            this.btnNaviLoaiDonVi.Name = "btnNaviLoaiDonVi";
            // 
            // btnNaviDonVi
            // 
            this.btnNaviDonVi.Caption = "Đơn vị";
            this.btnNaviDonVi.Id = 30;
            this.btnNaviDonVi.Name = "btnNaviDonVi";
            // 
            // btnNaviToChuyenMon
            // 
            this.btnNaviToChuyenMon.Caption = "Tổ chuyên môn";
            this.btnNaviToChuyenMon.Id = 31;
            this.btnNaviToChuyenMon.Name = "btnNaviToChuyenMon";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.ActAsDropDown = true;
            this.barButtonItem2.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.barButtonItem2.Caption = "Ngạch && Bậc lương";
            this.barButtonItem2.DropDownControl = this.popupMenuNgachBac;
            this.barButtonItem2.Id = 32;
            this.barButtonItem2.ImageOptions.LargeImage = global::QLNS_SGU.Properties.Resources.salary;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // popupMenuNgachBac
            // 
            this.popupMenuNgachBac.ItemLinks.Add(this.btnNaviNgach);
            this.popupMenuNgachBac.ItemLinks.Add(this.btnNaviBac);
            this.popupMenuNgachBac.Name = "popupMenuNgachBac";
            this.popupMenuNgachBac.Ribbon = this.ribbon;
            // 
            // btnNaviNgach
            // 
            this.btnNaviNgach.Caption = "Ngạch";
            this.btnNaviNgach.Id = 33;
            this.btnNaviNgach.Name = "btnNaviNgach";
            // 
            // btnNaviBac
            // 
            this.btnNaviBac.Caption = "Bậc";
            this.btnNaviBac.Id = 34;
            this.btnNaviBac.Name = "btnNaviBac";
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.ActAsDropDown = true;
            this.barButtonItem6.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.barButtonItem6.Caption = "Chức vụ";
            this.barButtonItem6.DropDownControl = this.popupMenuChucVu;
            this.barButtonItem6.Id = 35;
            this.barButtonItem6.ImageOptions.LargeImage = global::QLNS_SGU.Properties.Resources.chucvu;
            this.barButtonItem6.Name = "barButtonItem6";
            // 
            // popupMenuChucVu
            // 
            this.popupMenuChucVu.ItemLinks.Add(this.btnNaviLoaiChucVu);
            this.popupMenuChucVu.ItemLinks.Add(this.btnNaviChucVu);
            this.popupMenuChucVu.Name = "popupMenuChucVu";
            this.popupMenuChucVu.Ribbon = this.ribbon;
            // 
            // btnNaviLoaiChucVu
            // 
            this.btnNaviLoaiChucVu.Caption = "Loại chức vụ";
            this.btnNaviLoaiChucVu.Id = 36;
            this.btnNaviLoaiChucVu.Name = "btnNaviLoaiChucVu";
            // 
            // btnNaviChucVu
            // 
            this.btnNaviChucVu.Caption = "Chức vụ";
            this.btnNaviChucVu.Id = 37;
            this.btnNaviChucVu.Name = "btnNaviChucVu";
            // 
            // btnNaviLoaiHocHamHocVi
            // 
            this.btnNaviLoaiHocHamHocVi.Caption = "Học hàm && Học vị";
            this.btnNaviLoaiHocHamHocVi.Id = 38;
            this.btnNaviLoaiHocHamHocVi.ImageOptions.LargeImage = global::QLNS_SGU.Properties.Resources.hochamhocvi;
            this.btnNaviLoaiHocHamHocVi.Name = "btnNaviLoaiHocHamHocVi";
            // 
            // btnNaviTrangThai
            // 
            this.btnNaviTrangThai.Caption = "Trạng thái";
            this.btnNaviTrangThai.Id = 39;
            this.btnNaviTrangThai.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNaviTrangThai.ImageOptions.Image")));
            this.btnNaviTrangThai.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnNaviTrangThai.ImageOptions.LargeImage")));
            this.btnNaviTrangThai.Name = "btnNaviTrangThai";
            // 
            // btnNaviVienChuc
            // 
            this.btnNaviVienChuc.Caption = "Viên chức";
            this.btnNaviVienChuc.Id = 40;
            this.btnNaviVienChuc.ImageOptions.LargeImage = global::QLNS_SGU.Properties.Resources.vienchuc;
            this.btnNaviVienChuc.Name = "btnNaviVienChuc";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonPage1.Image")));
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Màn hình";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnNaviMain);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnOpenImportData);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnNaviExportData);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnOpenCreateAndEditPersonInfoForm);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnNaviLoaiHopDong);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnNaviLoaiChungChi);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnNaviLoaiHocHamHocVi);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnNaviNganh);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem6);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnNaviTrangThai);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnNaviVienChuc);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "Chuyển màn hình";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.txtXinChao);
            this.ribbonStatusBar.ItemLinks.Add(this.btnDangXuat);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 491);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(996, 23);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2007 Blue";
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // btnNaviExportData
            // 
            this.btnNaviExportData.Caption = "Xuất dữ liệu";
            this.btnNaviExportData.Id = 41;
            this.btnNaviExportData.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.ImageOptions.Image")));
            this.btnNaviExportData.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.ImageOptions.LargeImage")));
            this.btnNaviExportData.Name = "btnNaviExportData";
            // 
            // ContainerForm
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 514);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "ContainerForm";
            this.Ribbon = this.ribbon;
            this.ShowIcon = false;
            this.StatusBar = this.ribbonStatusBar;
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuNganh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuDonVi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuNgachBac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuChucVu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.BarButtonItem btnOpenImportData;
        private DevExpress.XtraBars.BarButtonItem btnOpenCreateAndEditPersonInfoForm;
        private DevExpress.XtraBars.BarButtonItem btnNaviNganh;
        private DevExpress.XtraBars.BarButtonItem btnNaviLoaiChungChi;
        private DevExpress.XtraBars.BarButtonItem btnNaviLoaiHopDong;
        private DevExpress.XtraBars.BarButtonItem btnDangXuat;
        private DevExpress.XtraBars.BarStaticItem txtXinChao;
        private DevExpress.XtraBars.BarButtonItem btnNaviMain;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraBars.PopupMenu popupMenuNganh;
        private DevExpress.XtraBars.BarButtonItem btnNaviLoaiNganh;
        private DevExpress.XtraBars.BarButtonItem btnNaviNganhDaoTao;
        private DevExpress.XtraBars.BarButtonItem btnNaviChuyenNganh;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.PopupMenu popupMenuDonVi;
        private DevExpress.XtraBars.BarButtonItem btnNaviLoaiDonVi;
        private DevExpress.XtraBars.BarButtonItem btnNaviDonVi;
        private DevExpress.XtraBars.BarButtonItem btnNaviToChuyenMon;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.PopupMenu popupMenuNgachBac;
        private DevExpress.XtraBars.BarButtonItem btnNaviNgach;
        private DevExpress.XtraBars.BarButtonItem btnNaviBac;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.PopupMenu popupMenuChucVu;
        private DevExpress.XtraBars.BarButtonItem btnNaviLoaiChucVu;
        private DevExpress.XtraBars.BarButtonItem btnNaviChucVu;
        private DevExpress.XtraBars.BarButtonItem btnNaviLoaiHocHamHocVi;
        private DevExpress.XtraBars.BarButtonItem btnNaviTrangThai;
        private DevExpress.XtraBars.BarButtonItem btnNaviVienChuc;
        private DevExpress.XtraBars.BarButtonItem btnNaviExportData;
    }
}