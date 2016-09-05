namespace Anchi.ERP.UI.WinForm
{
    partial class MainForm
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
            this.menuRepair = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddRepair = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRepairList = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPurchase = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddPurchase = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPurchaseList = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLibary = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCustomerList = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSupplierList = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemList = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPartList = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUserList = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbountMe = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuRepair
            // 
            this.menuRepair.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddRepair,
            this.menuRepairList});
            this.menuRepair.Name = "menuRepair";
            this.menuRepair.Size = new System.Drawing.Size(44, 21);
            this.menuRepair.Text = "维修";
            // 
            // menuAddRepair
            // 
            this.menuAddRepair.Name = "menuAddRepair";
            this.menuAddRepair.Size = new System.Drawing.Size(136, 22);
            this.menuAddRepair.Text = "维修开单";
            this.menuAddRepair.Click += new System.EventHandler(this.menuAddRepair_Click);
            // 
            // menuRepairList
            // 
            this.menuRepairList.Name = "menuRepairList";
            this.menuRepairList.Size = new System.Drawing.Size(136, 22);
            this.menuRepairList.Text = "维修单管理";
            this.menuRepairList.Click += new System.EventHandler(this.menuRepairList_Click);
            // 
            // menuPurchase
            // 
            this.menuPurchase.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddPurchase,
            this.menuPurchaseList});
            this.menuPurchase.Name = "menuPurchase";
            this.menuPurchase.Size = new System.Drawing.Size(44, 21);
            this.menuPurchase.Text = "采购";
            // 
            // menuAddPurchase
            // 
            this.menuAddPurchase.Name = "menuAddPurchase";
            this.menuAddPurchase.Size = new System.Drawing.Size(136, 22);
            this.menuAddPurchase.Text = "配件采购";
            this.menuAddPurchase.Click += new System.EventHandler(this.menuAddPurchase_Click);
            // 
            // menuPurchaseList
            // 
            this.menuPurchaseList.Name = "menuPurchaseList";
            this.menuPurchaseList.Size = new System.Drawing.Size(136, 22);
            this.menuPurchaseList.Text = "采购单管理";
            this.menuPurchaseList.Click += new System.EventHandler(this.menuPurchaseList_Click);
            // 
            // menuLibary
            // 
            this.menuLibary.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCustomerList,
            this.menuSupplierList,
            this.menuItemList,
            this.menuPartList});
            this.menuLibary.Name = "menuLibary";
            this.menuLibary.Size = new System.Drawing.Size(44, 21);
            this.menuLibary.Text = "资料";
            // 
            // menuCustomerList
            // 
            this.menuCustomerList.Name = "menuCustomerList";
            this.menuCustomerList.Size = new System.Drawing.Size(148, 22);
            this.menuCustomerList.Text = "客户管理";
            this.menuCustomerList.Click += new System.EventHandler(this.menuCustomerList_Click);
            // 
            // menuSupplierList
            // 
            this.menuSupplierList.Name = "menuSupplierList";
            this.menuSupplierList.Size = new System.Drawing.Size(148, 22);
            this.menuSupplierList.Text = "供应商管理";
            this.menuSupplierList.Click += new System.EventHandler(this.menuSupplierList_Click);
            // 
            // menuItemList
            // 
            this.menuItemList.Name = "menuItemList";
            this.menuItemList.Size = new System.Drawing.Size(148, 22);
            this.menuItemList.Text = "维修项目管理";
            this.menuItemList.Click += new System.EventHandler(this.menuItemList_Click);
            // 
            // menuPartList
            // 
            this.menuPartList.Name = "menuPartList";
            this.menuPartList.Size = new System.Drawing.Size(148, 22);
            this.menuPartList.Text = "配件管理";
            this.menuPartList.Click += new System.EventHandler(this.menuPartList_Click);
            // 
            // menuSystem
            // 
            this.menuSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUserList});
            this.menuSystem.Name = "menuSystem";
            this.menuSystem.Size = new System.Drawing.Size(44, 21);
            this.menuSystem.Text = "系统";
            // 
            // menuUserList
            // 
            this.menuUserList.Name = "menuUserList";
            this.menuUserList.Size = new System.Drawing.Size(124, 22);
            this.menuUserList.Text = "用户管理";
            this.menuUserList.Click += new System.EventHandler(this.menuUserList_Click);
            // 
            // menuAbout
            // 
            this.menuAbout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAbountMe});
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(44, 21);
            this.menuAbout.Text = "关于";
            // 
            // menuAbountMe
            // 
            this.menuAbountMe.Name = "menuAbountMe";
            this.menuAbountMe.Size = new System.Drawing.Size(100, 22);
            this.menuAbountMe.Text = "关于";
            this.menuAbountMe.Click += new System.EventHandler(this.menuAbountMe_Click);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuRepair,
            this.menuPurchase,
            this.menuLibary,
            this.menuSystem,
            this.menuAbout});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.MdiWindowListItem = this.menuAbout;
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(831, 25);
            this.mainMenuStrip.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 454);
            this.Controls.Add(this.mainMenuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "安驰汽配维修ERP系统";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem menuRepair;
        private System.Windows.Forms.ToolStripMenuItem menuAddRepair;
        private System.Windows.Forms.ToolStripMenuItem menuRepairList;
        private System.Windows.Forms.ToolStripMenuItem menuPurchase;
        private System.Windows.Forms.ToolStripMenuItem menuAddPurchase;
        private System.Windows.Forms.ToolStripMenuItem menuPurchaseList;
        private System.Windows.Forms.ToolStripMenuItem menuLibary;
        private System.Windows.Forms.ToolStripMenuItem menuCustomerList;
        private System.Windows.Forms.ToolStripMenuItem menuSupplierList;
        private System.Windows.Forms.ToolStripMenuItem menuItemList;
        private System.Windows.Forms.ToolStripMenuItem menuPartList;
        private System.Windows.Forms.ToolStripMenuItem menuSystem;
        private System.Windows.Forms.ToolStripMenuItem menuUserList;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.ToolStripMenuItem menuAbountMe;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
    }
}