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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("查找");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("新增");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("公司信息", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("节点9");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("节点10");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("基本信息", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("节点11");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("节点12");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("电机回收", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("节点13");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("节点14");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("电机再制造", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("节点15");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("节点16");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("报表", new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("节点17");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("系统", new System.Windows.Forms.TreeNode[] {
            treeNode16});
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
            this.tsmi_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.tv = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.tsmi_exit});
            this.tsmi_sys.Name = "tsmi_sys";
            this.tsmi_sys.Size = new System.Drawing.Size(81, 20);
            this.tsmi_sys.Text = "系统管理(&S)";
            // 
            // tsmi_User
            // 
            this.tsmi_User.Name = "tsmi_User";
            this.tsmi_User.Size = new System.Drawing.Size(122, 22);
            this.tsmi_User.Text = "用户管理";
            this.tsmi_User.Click += new System.EventHandler(this.tsmi_User_Click);
            // 
            // tsmi_exit
            // 
            this.tsmi_exit.Name = "tsmi_exit";
            this.tsmi_exit.Size = new System.Drawing.Size(122, 22);
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
            treeNode1.Name = "t2_company_query";
            treeNode1.Text = "查找";
            treeNode2.Name = "t2_company_add";
            treeNode2.Text = "新增";
            treeNode3.Name = "t1_company";
            treeNode3.Text = "公司信息";
            treeNode4.Name = "节点9";
            treeNode4.Text = "节点9";
            treeNode5.Name = "节点10";
            treeNode5.Text = "节点10";
            treeNode6.Name = "tMaster";
            treeNode6.Text = "基本信息";
            treeNode7.Name = "节点11";
            treeNode7.Text = "节点11";
            treeNode8.Name = "节点12";
            treeNode8.Text = "节点12";
            treeNode9.Name = "tRecyle";
            treeNode9.Text = "电机回收";
            treeNode10.Name = "节点13";
            treeNode10.Text = "节点13";
            treeNode11.Name = "节点14";
            treeNode11.Text = "节点14";
            treeNode12.Name = "tManufacture";
            treeNode12.Text = "电机再制造";
            treeNode13.Name = "节点15";
            treeNode13.Text = "节点15";
            treeNode14.Name = "节点16";
            treeNode14.Text = "节点16";
            treeNode15.Name = "tReport";
            treeNode15.Text = "报表";
            treeNode16.Name = "节点17";
            treeNode16.Text = "节点17";
            treeNode17.Name = "tSystem";
            treeNode17.Text = "系统";
            this.tv.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode9,
            treeNode12,
            treeNode15,
            treeNode17});
            this.tv.Size = new System.Drawing.Size(157, 377);
            this.tv.TabIndex = 4;
            this.tv.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv_NodeMouseClick);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(157, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 377);
            this.panel1.TabIndex = 6;
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 423);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tv);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frm_Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
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
        private System.Windows.Forms.Panel panel1;
    }
}