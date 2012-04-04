namespace Electric
{
    partial class frm_Main
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
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("查找");
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("新增");
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("公司信息", new System.Windows.Forms.TreeNode[] {
            treeNode35,
            treeNode36});
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("节点9");
            System.Windows.Forms.TreeNode treeNode39 = new System.Windows.Forms.TreeNode("节点10");
            System.Windows.Forms.TreeNode treeNode40 = new System.Windows.Forms.TreeNode("基本信息", new System.Windows.Forms.TreeNode[] {
            treeNode37,
            treeNode38,
            treeNode39});
            System.Windows.Forms.TreeNode treeNode41 = new System.Windows.Forms.TreeNode("节点11");
            System.Windows.Forms.TreeNode treeNode42 = new System.Windows.Forms.TreeNode("节点12");
            System.Windows.Forms.TreeNode treeNode43 = new System.Windows.Forms.TreeNode("电机回收", new System.Windows.Forms.TreeNode[] {
            treeNode41,
            treeNode42});
            System.Windows.Forms.TreeNode treeNode44 = new System.Windows.Forms.TreeNode("节点13");
            System.Windows.Forms.TreeNode treeNode45 = new System.Windows.Forms.TreeNode("节点14");
            System.Windows.Forms.TreeNode treeNode46 = new System.Windows.Forms.TreeNode("电机再制造", new System.Windows.Forms.TreeNode[] {
            treeNode44,
            treeNode45});
            System.Windows.Forms.TreeNode treeNode47 = new System.Windows.Forms.TreeNode("节点15");
            System.Windows.Forms.TreeNode treeNode48 = new System.Windows.Forms.TreeNode("节点16");
            System.Windows.Forms.TreeNode treeNode49 = new System.Windows.Forms.TreeNode("报表", new System.Windows.Forms.TreeNode[] {
            treeNode47,
            treeNode48});
            System.Windows.Forms.TreeNode treeNode50 = new System.Windows.Forms.TreeNode("节点17");
            System.Windows.Forms.TreeNode treeNode51 = new System.Windows.Forms.TreeNode("系统", new System.Windows.Forms.TreeNode[] {
            treeNode50});
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmi_master = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_company = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_department = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_employee = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_partner = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_recycle = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_RecoveryContract = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_NewForOld = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_manufacture = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Purchase = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_buy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_reports = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_sys = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_User = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_base = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.tv = new System.Windows.Forms.TreeView();
            this.plMenu = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_master,
            this.tsmi_recycle,
            this.tsmi_manufacture,
            this.tsmi_reports,
            this.tsmi_sys});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(943, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmi_master
            // 
            this.tsmi_master.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_company,
            this.tsmi_department,
            this.tsmi_employee,
            this.tsmi_partner});
            this.tsmi_master.Name = "tsmi_master";
            this.tsmi_master.Size = new System.Drawing.Size(82, 20);
            this.tsmi_master.Text = "基本信息(&B)";
            // 
            // tsmi_company
            // 
            this.tsmi_company.Name = "tsmi_company";
            this.tsmi_company.Size = new System.Drawing.Size(122, 22);
            this.tsmi_company.Text = "公司信息";
            this.tsmi_company.Click += new System.EventHandler(this.tsmi_company_Click);
            // 
            // tsmi_department
            // 
            this.tsmi_department.Name = "tsmi_department";
            this.tsmi_department.Size = new System.Drawing.Size(122, 22);
            this.tsmi_department.Text = "部门信息";
            this.tsmi_department.Click += new System.EventHandler(this.tsmi_department_Click);
            // 
            // tsmi_employee
            // 
            this.tsmi_employee.Name = "tsmi_employee";
            this.tsmi_employee.Size = new System.Drawing.Size(122, 22);
            this.tsmi_employee.Text = "员工信息";
            this.tsmi_employee.Click += new System.EventHandler(this.tsmi_employee_Click);
            // 
            // tsmi_partner
            // 
            this.tsmi_partner.Name = "tsmi_partner";
            this.tsmi_partner.Size = new System.Drawing.Size(122, 22);
            this.tsmi_partner.Text = "合作伙伴";
            this.tsmi_partner.Click += new System.EventHandler(this.tsmi_partner_Click);
            // 
            // tsmi_recycle
            // 
            this.tsmi_recycle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_RecoveryContract,
            this.tsmi_NewForOld});
            this.tsmi_recycle.Name = "tsmi_recycle";
            this.tsmi_recycle.Size = new System.Drawing.Size(82, 20);
            this.tsmi_recycle.Text = "电机回收(&R)";
            // 
            // tsmi_RecoveryContract
            // 
            this.tsmi_RecoveryContract.Name = "tsmi_RecoveryContract";
            this.tsmi_RecoveryContract.Size = new System.Drawing.Size(122, 22);
            this.tsmi_RecoveryContract.Text = "回收合同";
            this.tsmi_RecoveryContract.Click += new System.EventHandler(this.tsmi_RecoveryContract_Click);
            // 
            // tsmi_NewForOld
            // 
            this.tsmi_NewForOld.Name = "tsmi_NewForOld";
            this.tsmi_NewForOld.Size = new System.Drawing.Size(122, 22);
            this.tsmi_NewForOld.Text = "以旧换新";
            this.tsmi_NewForOld.Click += new System.EventHandler(this.tsmi_NewForOld_Click);
            // 
            // tsmi_manufacture
            // 
            this.tsmi_manufacture.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Purchase,
            this.tsmi_buy});
            this.tsmi_manufacture.Name = "tsmi_manufacture";
            this.tsmi_manufacture.Size = new System.Drawing.Size(98, 20);
            this.tsmi_manufacture.Text = "电机再制造(&M)";
            // 
            // tsmi_Purchase
            // 
            this.tsmi_Purchase.Name = "tsmi_Purchase";
            this.tsmi_Purchase.Size = new System.Drawing.Size(122, 22);
            this.tsmi_Purchase.Text = "采购合同";
            this.tsmi_Purchase.Click += new System.EventHandler(this.tsmi_Purchase_Click);
            // 
            // tsmi_buy
            // 
            this.tsmi_buy.Name = "tsmi_buy";
            this.tsmi_buy.Size = new System.Drawing.Size(122, 22);
            this.tsmi_buy.Text = "购买信息";
            this.tsmi_buy.Click += new System.EventHandler(this.tsmi_buy_Click);
            // 
            // tsmi_reports
            // 
            this.tsmi_reports.Name = "tsmi_reports";
            this.tsmi_reports.Size = new System.Drawing.Size(57, 20);
            this.tsmi_reports.Text = "报表(&E)";
            // 
            // tsmi_sys
            // 
            this.tsmi_sys.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_User,
            this.tsmi_base,
            this.tsmi_exit});
            this.tsmi_sys.Name = "tsmi_sys";
            this.tsmi_sys.Size = new System.Drawing.Size(81, 20);
            this.tsmi_sys.Text = "系统管理(&S)";
            // 
            // tsmi_User
            // 
            this.tsmi_User.Name = "tsmi_User";
            this.tsmi_User.Size = new System.Drawing.Size(146, 22);
            this.tsmi_User.Text = "用户管理";
            this.tsmi_User.Click += new System.EventHandler(this.tsmi_User_Click);
            // 
            // tsmi_base
            // 
            this.tsmi_base.Name = "tsmi_base";
            this.tsmi_base.Size = new System.Drawing.Size(146, 22);
            this.tsmi_base.Text = "基础数据管理";
            this.tsmi_base.Click += new System.EventHandler(this.tsmi_base_Click);
            // 
            // tsmi_exit
            // 
            this.tsmi_exit.Name = "tsmi_exit";
            this.tsmi_exit.Size = new System.Drawing.Size(146, 22);
            this.tsmi_exit.Text = "退出";
            this.tsmi_exit.Click += new System.EventHandler(this.tsmi_exit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslUser});
            this.statusStrip1.Location = new System.Drawing.Point(0, 401);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(943, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslUser
            // 
            this.tsslUser.Name = "tsslUser";
            this.tsslUser.Size = new System.Drawing.Size(0, 17);
            // 
            // tv
            // 
            this.tv.Dock = System.Windows.Forms.DockStyle.Left;
            this.tv.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tv.Location = new System.Drawing.Point(0, 24);
            this.tv.Name = "tv";
            treeNode35.Name = "t2_company_query";
            treeNode35.Text = "查找";
            treeNode36.Name = "t2_company_add";
            treeNode36.Text = "新增";
            treeNode37.Name = "t1_company";
            treeNode37.Text = "公司信息";
            treeNode38.Name = "节点9";
            treeNode38.Text = "节点9";
            treeNode39.Name = "节点10";
            treeNode39.Text = "节点10";
            treeNode40.Name = "tMaster";
            treeNode40.Text = "基本信息";
            treeNode41.Name = "节点11";
            treeNode41.Text = "节点11";
            treeNode42.Name = "节点12";
            treeNode42.Text = "节点12";
            treeNode43.Name = "tRecyle";
            treeNode43.Text = "电机回收";
            treeNode44.Name = "节点13";
            treeNode44.Text = "节点13";
            treeNode45.Name = "节点14";
            treeNode45.Text = "节点14";
            treeNode46.Name = "tManufacture";
            treeNode46.Text = "电机再制造";
            treeNode47.Name = "节点15";
            treeNode47.Text = "节点15";
            treeNode48.Name = "节点16";
            treeNode48.Text = "节点16";
            treeNode49.Name = "tReport";
            treeNode49.Text = "报表";
            treeNode50.Name = "节点17";
            treeNode50.Text = "节点17";
            treeNode51.Name = "tSystem";
            treeNode51.Text = "系统";
            this.tv.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode40,
            treeNode43,
            treeNode46,
            treeNode49,
            treeNode51});
            this.tv.Size = new System.Drawing.Size(157, 377);
            this.tv.TabIndex = 4;
            this.tv.Visible = false;
            // 
            // plMenu
            // 
            this.plMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.plMenu.Location = new System.Drawing.Point(157, 24);
            this.plMenu.Name = "plMenu";
            this.plMenu.Size = new System.Drawing.Size(200, 377);
            this.plMenu.TabIndex = 6;
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 423);
            this.Controls.Add(this.plMenu);
            this.Controls.Add(this.tv);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frm_Main";
            this.ShowIcon = false;
            this.Text = "NEMS";
            this.Load += new System.EventHandler(this.Main_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_Main_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_sys;
        private System.Windows.Forms.ToolStripMenuItem tsmi_exit;
        private System.Windows.Forms.ToolStripMenuItem tsmi_master;
        private System.Windows.Forms.ToolStripMenuItem tsmi_company;
        private System.Windows.Forms.ToolStripMenuItem tsmi_department;
        private System.Windows.Forms.ToolStripMenuItem tsmi_employee;
        private System.Windows.Forms.ToolStripMenuItem tsmi_partner;
        private System.Windows.Forms.ToolStripMenuItem tsmi_recycle;
        private System.Windows.Forms.ToolStripMenuItem tsmi_manufacture;
        private System.Windows.Forms.ToolStripMenuItem tsmi_reports;
        private System.Windows.Forms.ToolStripStatusLabel tsslUser;
        private System.Windows.Forms.TreeView tv;
        private System.Windows.Forms.ToolStripMenuItem tsmi_RecoveryContract;
        private System.Windows.Forms.ToolStripMenuItem tsmi_NewForOld;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Purchase;
        private System.Windows.Forms.ToolStripMenuItem tsmi_buy;
        private System.Windows.Forms.ToolStripMenuItem tsmi_User;
        private System.Windows.Forms.Panel plMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmi_base;
    }
}