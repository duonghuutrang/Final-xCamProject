namespace ProjectxCam2
{
    partial class xCamMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xCamMainForm));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.backstageViewControl1 = new DevExpress.XtraBars.Ribbon.BackstageViewControl();
            this.backstageViewClientControl1 = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.backstageViewTabItem1 = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.btnCamera = new DevExpress.XtraBars.BarButtonItem();
            this.btnAddCamera = new DevExpress.XtraBars.BarButtonItem();
            this.btnAddPeople = new DevExpress.XtraBars.BarButtonItem();
            this.btnAddTrainImage = new DevExpress.XtraBars.BarButtonItem();
            this.btnThongKe = new DevExpress.XtraBars.BarButtonItem();
            this.btnLogin = new DevExpress.XtraBars.BarButtonItem();
            this.btnLogout = new DevExpress.XtraBars.BarButtonItem();
            this.btnSettings = new DevExpress.XtraBars.BarButtonItem();
            this.btnAllCamera = new DevExpress.XtraBars.BarButtonItem();
            this.btnCreateReconizerDB = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.btnDataFolder = new DevExpress.XtraBars.BarButtonItem();
            this.btnReconizerPeople = new DevExpress.XtraBars.BarButtonItem();
            this.btnReport = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageCategoryBanHang = new DevExpress.XtraBars.Ribbon.RibbonPageCategory();
            this.ribbonPage5 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage6 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup11 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup10 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup9 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.panelMain = new DevExpress.XtraEditors.PanelControl();
            this.backgroundDBTrainer = new System.ComponentModel.BackgroundWorker();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.popupMenu2 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnTrainUnknownDB = new DevExpress.XtraBars.BarButtonItem();
            this.backgroundDBUnknown = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backstageViewControl1)).BeginInit();
            this.backstageViewControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationButtonDropDownControl = this.backstageViewControl1;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnCamera,
            this.btnAddCamera,
            this.btnAddPeople,
            this.btnAddTrainImage,
            this.btnThongKe,
            this.btnLogin,
            this.btnLogout,
            this.btnSettings,
            this.btnAllCamera,
            this.btnCreateReconizerDB,
            this.barStaticItem1,
            this.btnDataFolder,
            this.btnReconizerPeople,
            this.btnReport,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barButtonItem5,
            this.barButtonItem6,
            this.barButtonItem7,
            this.btnTrainUnknownDB});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 23;
            this.ribbon.Name = "ribbon";
            this.ribbon.PageCategories.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageCategory[] {
            this.ribbonPageCategoryBanHang});
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2,
            this.ribbonPage3});
            this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1});
            this.ribbon.Size = new System.Drawing.Size(859, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // backstageViewControl1
            // 
            this.backstageViewControl1.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Yellow;
            this.backstageViewControl1.Controls.Add(this.backstageViewClientControl1);
            this.backstageViewControl1.Items.Add(this.backstageViewTabItem1);
            this.backstageViewControl1.Location = new System.Drawing.Point(71, 214);
            this.backstageViewControl1.Name = "backstageViewControl1";
            this.backstageViewControl1.OwnerControl = this.ribbon;
            this.backstageViewControl1.Size = new System.Drawing.Size(480, 150);
            this.backstageViewControl1.TabIndex = 5;
            // 
            // backstageViewClientControl1
            // 
            this.backstageViewClientControl1.Location = new System.Drawing.Point(188, 0);
            this.backstageViewClientControl1.Name = "backstageViewClientControl1";
            this.backstageViewClientControl1.Size = new System.Drawing.Size(292, 150);
            this.backstageViewClientControl1.TabIndex = 1;
            // 
            // backstageViewTabItem1
            // 
            this.backstageViewTabItem1.Caption = "backstageViewTabItem1";
            this.backstageViewTabItem1.ContentControl = this.backstageViewClientControl1;
            this.backstageViewTabItem1.Name = "backstageViewTabItem1";
            this.backstageViewTabItem1.Selected = false;
            // 
            // btnCamera
            // 
            this.btnCamera.Caption = "Camera";
            this.btnCamera.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCamera.Glyph")));
            this.btnCamera.Id = 1;
            this.btnCamera.Name = "btnCamera";
            this.btnCamera.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnCamera.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCamera_ItemClick);
            // 
            // btnAddCamera
            // 
            this.btnAddCamera.Caption = "Thêm Camera";
            this.btnAddCamera.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAddCamera.Glyph")));
            this.btnAddCamera.Id = 2;
            this.btnAddCamera.Name = "btnAddCamera";
            this.btnAddCamera.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnAddCamera.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddCamera_ItemClick);
            // 
            // btnAddPeople
            // 
            this.btnAddPeople.Caption = "Thêm Người Dùng";
            this.btnAddPeople.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAddPeople.Glyph")));
            this.btnAddPeople.Id = 3;
            this.btnAddPeople.Name = "btnAddPeople";
            this.btnAddPeople.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnAddPeople.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddPeople_ItemClick);
            // 
            // btnAddTrainImage
            // 
            this.btnAddTrainImage.Caption = "Hình ảnh nhận diện";
            this.btnAddTrainImage.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAddTrainImage.Glyph")));
            this.btnAddTrainImage.Id = 4;
            this.btnAddTrainImage.Name = "btnAddTrainImage";
            this.btnAddTrainImage.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnAddTrainImage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddTrainImage_ItemClick);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Caption = "Thống Kê Vào Ra";
            this.btnThongKe.Glyph = ((System.Drawing.Image)(resources.GetObject("btnThongKe.Glyph")));
            this.btnThongKe.Id = 5;
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnThongKe.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThongKe_ItemClick);
            // 
            // btnLogin
            // 
            this.btnLogin.Caption = "Đăng nhập";
            this.btnLogin.Glyph = ((System.Drawing.Image)(resources.GetObject("btnLogin.Glyph")));
            this.btnLogin.Id = 6;
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnLogin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLogin_ItemClick);
            // 
            // btnLogout
            // 
            this.btnLogout.Caption = "Đăng xuất";
            this.btnLogout.Glyph = ((System.Drawing.Image)(resources.GetObject("btnLogout.Glyph")));
            this.btnLogout.Id = 7;
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnLogout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLogout_ItemClick);
            // 
            // btnSettings
            // 
            this.btnSettings.Caption = "Cấu hình chung";
            this.btnSettings.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSettings.Glyph")));
            this.btnSettings.Id = 8;
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnSettings.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSettings_ItemClick);
            // 
            // btnAllCamera
            // 
            this.btnAllCamera.Caption = "Tất cả Camera";
            this.btnAllCamera.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAllCamera.Glyph")));
            this.btnAllCamera.Id = 9;
            this.btnAllCamera.Name = "btnAllCamera";
            this.btnAllCamera.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnAllCamera.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAllCamera_ItemClick);
            // 
            // btnCreateReconizerDB
            // 
            this.btnCreateReconizerDB.Caption = "Tạo dữ liệu nhận diện";
            this.btnCreateReconizerDB.Glyph = global::ProjectxCam2.Properties.Resources._1489158841_database_gear;
            this.btnCreateReconizerDB.Id = 10;
            this.btnCreateReconizerDB.Name = "btnCreateReconizerDB";
            this.btnCreateReconizerDB.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnCreateReconizerDB.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCreateReconizerDB_ItemClick);
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "barStaticItem1";
            this.barStaticItem1.Id = 11;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // btnDataFolder
            // 
            this.btnDataFolder.Caption = "Mở Thư mục dữ liệu";
            this.btnDataFolder.Glyph = ((System.Drawing.Image)(resources.GetObject("btnDataFolder.Glyph")));
            this.btnDataFolder.Id = 12;
            this.btnDataFolder.Name = "btnDataFolder";
            this.btnDataFolder.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnDataFolder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDataFolder_ItemClick);
            // 
            // btnReconizerPeople
            // 
            this.btnReconizerPeople.Caption = "Nhận diện bằng hình ảnh";
            this.btnReconizerPeople.Glyph = ((System.Drawing.Image)(resources.GetObject("btnReconizerPeople.Glyph")));
            this.btnReconizerPeople.Id = 13;
            this.btnReconizerPeople.Name = "btnReconizerPeople";
            this.btnReconizerPeople.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnReconizerPeople.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReconizerPeople_ItemClick);
            // 
            // btnReport
            // 
            this.btnReport.Caption = "Báo cáo chi tiết";
            this.btnReport.Glyph = global::ProjectxCam2.Properties.Resources._1489247941_Report;
            this.btnReport.Id = 14;
            this.btnReport.Name = "btnReport";
            this.btnReport.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReport_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Loại hàng";
            this.barButtonItem1.Id = 15;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Danh mục hàng";
            this.barButtonItem2.Id = 16;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Xuất nhập kho";
            this.barButtonItem3.Id = 17;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Bán hàng";
            this.barButtonItem4.Id = 18;
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Thống kê  bán hàng";
            this.barButtonItem5.Id = 19;
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "Báo cáo bán hàng";
            this.barButtonItem6.Id = 20;
            this.barButtonItem6.Name = "barButtonItem6";
            this.barButtonItem6.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "Nhận diện bằng Videos";
            this.barButtonItem7.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem7.Glyph")));
            this.barButtonItem7.Id = 21;
            this.barButtonItem7.Name = "barButtonItem7";
            this.barButtonItem7.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // ribbonPageCategoryBanHang
            // 
            this.ribbonPageCategoryBanHang.Name = "ribbonPageCategoryBanHang";
            this.ribbonPageCategoryBanHang.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage5,
            this.ribbonPage6});
            this.ribbonPageCategoryBanHang.Text = "Bán hàng";
            // 
            // ribbonPage5
            // 
            this.ribbonPage5.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4});
            this.ribbonPage5.Name = "ribbonPage5";
            this.ribbonPage5.Text = "Cài đặt bán hàng";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "ribbonPageGroup4";
            // 
            // ribbonPage6
            // 
            this.ribbonPage6.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup11});
            this.ribbonPage6.Name = "ribbonPage6";
            this.ribbonPage6.Text = "Bán hàng";
            // 
            // ribbonPageGroup11
            // 
            this.ribbonPageGroup11.ItemLinks.Add(this.barButtonItem4);
            this.ribbonPageGroup11.ItemLinks.Add(this.barButtonItem5);
            this.ribbonPageGroup11.ItemLinks.Add(this.barButtonItem6);
            this.ribbonPageGroup11.Name = "ribbonPageGroup11";
            this.ribbonPageGroup11.Text = "ribbonPageGroup11";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup6});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Hệ thống";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnLogin);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnLogout);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Quản trị";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.btnSettings);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.Text = "ribbonPageGroup6";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2,
            this.ribbonPageGroup10,
            this.ribbonPageGroup3});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Chức năng";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnCamera);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnAllCamera);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnAddCamera);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Camera";
            // 
            // ribbonPageGroup10
            // 
            this.ribbonPageGroup10.ItemLinks.Add(this.btnReconizerPeople);
            this.ribbonPageGroup10.ItemLinks.Add(this.barButtonItem7);
            this.ribbonPageGroup10.Name = "ribbonPageGroup10";
            this.ribbonPageGroup10.Text = "Nhận diện";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnThongKe);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnReport);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Thống kê & Báo cáo";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup5,
            this.ribbonPageGroup9});
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "Dữ liệu Nhận diện";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.btnAddPeople);
            this.ribbonPageGroup5.ItemLinks.Add(this.btnAddTrainImage);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "Dữ liệu người dùng";
            // 
            // ribbonPageGroup9
            // 
            this.ribbonPageGroup9.ItemLinks.Add(this.btnCreateReconizerDB);
            this.ribbonPageGroup9.ItemLinks.Add(this.btnTrainUnknownDB);
            this.ribbonPageGroup9.ItemLinks.Add(this.btnDataFolder);
            this.ribbonPageGroup9.Name = "ribbonPageGroup9";
            this.ribbonPageGroup9.Text = "Train Database";
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticItem1);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 458);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(859, 31);
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 143);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(859, 315);
            this.panelMain.TabIndex = 2;
            // 
            // backgroundDBTrainer
            // 
            this.backgroundDBTrainer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundDBTrainer_DoWork);
            this.backgroundDBTrainer.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundDBTrainer_RunWorkerCompleted);
            // 
            // popupMenu1
            // 
            this.popupMenu1.Name = "popupMenu1";
            this.popupMenu1.Ribbon = this.ribbon;
            // 
            // popupMenu2
            // 
            this.popupMenu2.Name = "popupMenu2";
            this.popupMenu2.Ribbon = this.ribbon;
            // 
            // btnTrainUnknownDB
            // 
            this.btnTrainUnknownDB.Caption = "Dữ liệu nhận diện người lạ";
            this.btnTrainUnknownDB.Glyph = ((System.Drawing.Image)(resources.GetObject("btnTrainUnknownDB.Glyph")));
            this.btnTrainUnknownDB.Id = 22;
            this.btnTrainUnknownDB.Name = "btnTrainUnknownDB";
            this.btnTrainUnknownDB.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnTrainUnknownDB.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTrainUnknownDB_ItemClick);
            // 
            // backgroundDBUnknown
            // 
            this.backgroundDBUnknown.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundDBUnknown_DoWork);
            this.backgroundDBUnknown.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundDBTrainer_RunWorkerCompleted);
            // 
            // xCamMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 489);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.backstageViewControl1);
            this.Controls.Add(this.ribbon);
            this.Name = "xCamMainForm";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "xCamMainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.xCamMainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backstageViewControl1)).EndInit();
            this.backstageViewControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem btnCamera;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraEditors.PanelControl panelMain;
        private DevExpress.XtraBars.BarButtonItem btnAddCamera;
        private DevExpress.XtraBars.BarButtonItem btnAddPeople;
        private DevExpress.XtraBars.BarButtonItem btnAddTrainImage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem btnThongKe;
        private DevExpress.XtraBars.BarButtonItem btnLogin;
        private DevExpress.XtraBars.BarButtonItem btnLogout;
        private DevExpress.XtraBars.BarButtonItem btnSettings;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.BarButtonItem btnAllCamera;
        private DevExpress.XtraBars.BarButtonItem btnCreateReconizerDB;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup9;
        private System.ComponentModel.BackgroundWorker backgroundDBTrainer;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarButtonItem btnDataFolder;
        private DevExpress.XtraBars.BarButtonItem btnReconizerPeople;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup10;
        private DevExpress.XtraBars.BarButtonItem btnReport;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.Ribbon.RibbonPageCategory ribbonPageCategoryBanHang;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage5;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage6;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup11;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.Ribbon.BackstageViewControl backstageViewControl1;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControl1;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageViewTabItem1;
        private DevExpress.XtraBars.PopupMenu popupMenu2;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraBars.BarButtonItem btnTrainUnknownDB;
        private System.ComponentModel.BackgroundWorker backgroundDBUnknown;
    }
}